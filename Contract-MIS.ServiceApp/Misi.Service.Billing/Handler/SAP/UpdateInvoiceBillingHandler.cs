using System.Collections.Generic;
using System.Threading;
using Misi.Service.Billing.Model.SAP;
using Misi.Service.Billing.Object;

namespace Misi.Service.Billing.Handler.SAP
{
    public class UpdateInvoiceBillingHandler : InvoiceProformaBaseHandler
    {
        private string _recNo;
        private string _reason;
        private string _remarks;

        public override void SetHandlerArguments(string user, object[] args = null)
        {
            Username = user;
            if (args == null) return;
            _recNo = (string) args[0];
            _reason = (string) args[1];
            _remarks = (string) args[2];
        }

        public override SAPResponse ExecuteCommand()
        {
            var toUpdateList = InMemoryCache.Instance.GetCached(Username + Suffix.BILLINGS_TO_UPDATE) as List<BillingToUpdate>;
            if (toUpdateList != null && toUpdateList.Count > 0)
            {
                InMemoryCache.Instance.ClearCached(Username + Suffix.BILLINGS_TO_UPDATE);
                var tu = new BillingToUpdate
                {
                    No = _recNo,
                    Content = _reason,
                    Remarks = _remarks
                };
                if (string.IsNullOrEmpty(_reason) || _reason == "")
                    tu.Content = Properties.Settings.Default.Unblock;
                toUpdateList.Add(tu);
                InMemoryCache.Instance.Cache(Username + Suffix.BILLINGS_TO_UPDATE, toUpdateList);
            }
            else
            {
                var newToUpdateList = new List<BillingToUpdate>();
                var tu = new BillingToUpdate
                {
                    No = _recNo,
                    Content = _reason,
                    Remarks = _remarks
                };
                if (string.IsNullOrEmpty(_reason) || _reason == "")
                    tu.Content = Properties.Settings.Default.Unblock;
                newToUpdateList.Add(tu);
                InMemoryCache.Instance.Cache(Username + Suffix.BILLINGS_TO_UPDATE, newToUpdateList);
            }
            Thread.Sleep(2000);
            return new OKResponse();
        }
    }
}