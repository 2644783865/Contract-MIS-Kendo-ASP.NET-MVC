using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using Misi.DAL.Billing.DaoUtil;
using Misi.Service.Billing.Model.SAP;

namespace Misi.Service.Billing.Handler.SAP
{
    public class QueryTotalBillingRecordsHandler : InvoiceProformaBaseHandler
    {
        private string _billingNo;
        private bool _billingBlock;
        private bool _reasonForRejection;
        private bool _proformaFlag;

        public override void SetHandlerArguments(string username, object[] args = null)
        {
            Username = username;
            if (args == null) return;
            _billingNo = (string) args[0];
            _billingBlock = (bool) args[1];
            _reasonForRejection = (bool) args[2];
            _proformaFlag = (bool) args[3];
        }

        public override SAPResponse ExecuteQuery()
        {
            var isFromDB = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_FROM_DB) is bool && (bool)InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_FROM_DB);
            if (isFromDB)
            {
                System.Diagnostics.Debug.WriteLine("<QUERY_TOTAL_RECORDS FROM = 'DB'>");
                var loadedHead = InMemoryCache.Instance.GetCached(Username + Suffix.REQUEST_HEADER) as RunInvoiceHeaderDTO;
                if (loadedHead != null)
                {
                    System.Diagnostics.Debug.WriteLine("MASUK....");
                    using (var dao = new BillingDbContext())
                    {
                        var sql1 =
                                from o in dao.InvoiceProformaHeaders.Where(o => o.BillingNo == loadedHead.BillingNo &&
                                                                                o.BillingBlock == loadedHead.BillingDocsCriteria &&
                                                                                o.ProformaFlag == loadedHead.ProformaFlag &&
                                                                                o.ReasonForRejection ==
                                                                                loadedHead.ReasonForRejection &&
                                                                                o.Version == 0).Include(o => o.Billings)
                                select o;
                        var zeroHeader = sql1.AsParallel().FirstOrDefault();
                        if (zeroHeader != null)
                        {
                            var total = zeroHeader.Billings.Count;
                            var resp = new NumberResult {Value = total};
                            return resp;
                        }
                        throw new FaultException("Header not found in Database!");
                    }
                }
                throw new FaultException("Header not found in Session!");
            }
            System.Diagnostics.Debug.WriteLine("<QUERY_TOTAL_RECORDS FROM = 'SAP'>");

            InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_SAP_SESSIONID);
            var cred = ParseCredential(Username);
            var dest = SAPConnectionFactory.Instance.GetRfcDestination(cred);
            if (dest != null)
            {
                var repo = dest.Repository;

                if (_billingBlock == false && _reasonForRejection == false)
                    _proformaFlag = true;

                System.Diagnostics.Debug.WriteLine("<REQUEST_FOR_SESSION_ID>");
                var func1 = repo.CreateFunction("ZBAPI_PRINT_BILLING");
                func1.SetValue("BILL_NO", _billingNo);
                func1.SetValue("PROFORMA_FLAG", _proformaFlag ? "X" : " ");
                func1.SetValue("ITEM_FLAG", "X");
                func1.SetValue("BILLING_BLOCK", _billingBlock ? "X" : " ");
                func1.SetValue("REASON_FOR_REJECTION", _reasonForRejection ? "X" : " ");
                func1.SetValue("PAGING", "X");
                func1.SetValue("MAXROWS", 1);
                func1.Invoke(dest);

                var sessionId = func1.GetInt("SESSIONID");
                System.Diagnostics.Debug.WriteLine("<SESSION ID = '" + sessionId + "'/>");

                InMemoryCache.Instance.Cache(Username + Suffix.QUERIED_SAP_SESSIONID, sessionId);

                dest = SAPConnectionFactory.Instance.GetRfcDestination(cred);
                repo = dest.Repository;

                var func0 = repo.CreateFunction("ZBAPI_PROFORMA_CHECK");
                func0.SetValue("SESSIONID", sessionId);

                func0.Invoke(dest);
                var totalBills = func0.GetInt("ROWS");

                System.Diagnostics.Debug.WriteLine("<ROWS_QUERY TOTAL = '" + totalBills + "'/>");

                InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_PROFORMA_TOTAL_RECS);
                InMemoryCache.Instance.Cache(Username + Suffix.QUERIED_PROFORMA_TOTAL_RECS, totalBills);

                System.Diagnostics.Debug.WriteLine("</QUERY_TOTAL_RECORDS>");

                var resp = new NumberResult { Value = totalBills };
                return resp;
            }

            System.Diagnostics.Debug.WriteLine("</QUERY_TOTAL_RECORDS>");
            throw new FaultException("RfcDestination is null!");
        }
        
    }
}