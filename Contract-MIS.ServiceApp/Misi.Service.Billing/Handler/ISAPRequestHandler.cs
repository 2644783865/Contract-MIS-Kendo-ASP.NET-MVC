using Misi.Service.Billing.Model.SAP;

namespace Misi.Service.Billing.Handler
{
    public interface ISAPRequestHandler
    {
        void SetHandlerArguments(string user, object[] args = null);
        SAPResponse ExecuteQuery();
        SAPResponse ExecuteCommand();
    }
}
