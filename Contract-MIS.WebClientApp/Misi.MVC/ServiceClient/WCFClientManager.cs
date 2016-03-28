using System;
using Misi.MVC.SAPServiceClient;

namespace Misi.MVC.ServiceClient
{
    public class WCFClientManager
    {
        private static volatile ISAPProxyService _SAPServiceClient;
        private static readonly object SyncRoot = new Object();

        public static ISAPProxyService SAPServiceClient
        {
            get
            {
                if (_SAPServiceClient != null) 
                    return _SAPServiceClient;
                lock (SyncRoot)
                {
                    if (_SAPServiceClient == null)
                        _SAPServiceClient = new SAPProxyServiceClient();
                }
                return _SAPServiceClient;
            }
        }
    }
}
