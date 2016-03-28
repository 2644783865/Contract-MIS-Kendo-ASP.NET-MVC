using System.Collections.Generic;
using System.Globalization;
using Misi.Service.Billing.Handler.SAP;
using SAP.Middleware.Connector;

namespace Misi.Service.Billing.Handler
{
    public class SAPConnectionFactory
    {
        private static volatile Dictionary<string, RfcDestination> _pool; 
        private static volatile SAPConnectionFactory _factory;
        private static readonly object SyncRoot2 = new object();

        public static SAPConnectionFactory Instance
        {
            get
            {
                if (_factory != null) return _factory;
                lock (SyncRoot2)
                {
                    if (_factory == null)
                    {
                        _factory = new SAPConnectionFactory();
                        _pool = new Dictionary<string, RfcDestination>();
                    }
                }
                return _factory;
            }
        }

        public RfcDestination GetRfcDestination(CredentialDTO user)
        {
            RfcDestination dest = null;
            
            if (_pool.ContainsKey(user.SAPUsername))
            {
                _pool.TryGetValue(user.SAPUsername, out dest);
            }
            if (dest == null)
            {
                dest = GetNewRfcDestination(user);
                _pool.Add(user.SAPUsername, dest);
            }
            else
            {
                if (dest.IsShutDown)
                    dest = GetNewRfcDestination(user);
            }
            return dest;
        }



        public RfcDestination GetRfcDestinationSoldToParty(CredentialDTO user)
        {
            RfcDestination dest = GetNewRfcDestination(user);
            return dest;
        }


        private RfcDestination GetNewRfcDestination(CredentialDTO user)
        {
            var p = new
            {
                Name = Properties.Settings.Default.SAP_Name,
                AppServerHost = Properties.Settings.Default.SAP_ServerIP,
                SystemNumber = Properties.Settings.Default.SAP_SysNumber,
                SystemID = Properties.Settings.Default.SAP_SystemID,
                SAPUser = user.SAPUsername,
                Password = user.SAPPassword,
                Client = Properties.Settings.Default.SAP_Client,
                Language = Properties.Settings.Default.SAP_Lang,
                PoolSize = Properties.Settings.Default.SAPConnPoolSize
            };

            System.Diagnostics.Debug.WriteLine("<NEW_SAP_CONNECTION USER = '" + user.SAPUsername + "'/>");

            var config = new RfcConfigParameters
                {
                    {RfcConfigParameters.Name, p.Name},
                    {RfcConfigParameters.AppServerHost, p.AppServerHost},
                    {RfcConfigParameters.SystemNumber, p.SystemNumber},
                    {RfcConfigParameters.SystemID, p.SystemID},
                    {RfcConfigParameters.User, p.SAPUser},
                    {RfcConfigParameters.Password, p.Password},
                    {RfcConfigParameters.Client, p.Client},
                    {RfcConfigParameters.Language, p.Language},
                    {RfcConfigParameters.ConnectionIdleTimeout, "43200"},
                    {RfcConfigParameters.PoolIdleTimeout, "43200"},
                    {RfcConfigParameters.RepositoryConnectionIdleTimeout, "43200"},
                    {RfcConfigParameters.PoolSize, p.PoolSize.ToString(CultureInfo.InvariantCulture)}
                };
            var dest = RfcDestinationManager.GetDestination(config);
            return dest;
        }

    }
}