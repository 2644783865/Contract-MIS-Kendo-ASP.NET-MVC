using System;
using Misi.Service.Billing.Handler.SAP;
using Misi.Service.Billing.Model.SAP;

namespace Misi.Service.Billing.Handler
{
    public abstract class SAPRequestHandlerBase : ISAPRequestHandler
    {
        protected string Username;

        public virtual void SetHandlerArguments(string user, object[] args = null)
        {
            throw new NotImplementedException();
        }

        public virtual SAPResponse ExecuteQuery()
        {
            throw new NotImplementedException();
        }

        public virtual SAPResponse ExecuteCommand()
        {
            throw new NotImplementedException();
        }

        protected CredentialDTO ParseCredential(string param)
        {
            var cred = new CredentialDTO();
            if (param.Contains(":"))
            {
                string[] raw = param.Split(':');
                cred.SAPUsername = raw[0];
                cred.SAPPassword = raw[1];
                cred.SessionKey = raw[2];
            }
            return cred;
        }

    }
}