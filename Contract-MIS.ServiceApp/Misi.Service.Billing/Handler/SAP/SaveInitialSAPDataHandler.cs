using Misi.DAL.Billing.DaoUtil;
using Misi.Service.Billing.Model.SAP;

namespace Misi.Service.Billing.Handler.SAP
{
    public class SaveInitialSAPDataHandler : InvoiceProformaBaseHandler
    {
        public override void SetHandlerArguments(string user, object[] args = null)
        {
            Username = user;
        }

        public override SAPResponse ExecuteCommand()
        {
            InMemoryCache.Instance.ClearCached(Username + Suffix.PERFORMED_INITIAL_SAVE);
            InMemoryCache.Instance.Cache(Username + Suffix.PERFORMED_INITIAL_SAVE, true);
            var header = InMemoryCache.Instance.GetCached(Username + Suffix.REQUEST_HEADER) as RunInvoiceHeaderDTO;
            if (header == null) return null;
            using (var dao = new BillingDbContext())
            {
                System.Diagnostics.Debug.WriteLine("<CREATE_ZERO_VERSION CALL = 'FROM SAVE INITIAL' />");
                CreateOrOverwriteZeroVersion(true, dao);
            }
            return null;
        }

    }
}