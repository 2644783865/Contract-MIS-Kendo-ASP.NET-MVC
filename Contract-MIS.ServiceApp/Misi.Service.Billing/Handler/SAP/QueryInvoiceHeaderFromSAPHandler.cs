using System;
using System.Linq;
using System.ServiceModel;
using Misi.Common.Lib.Util;
using Misi.Service.Billing.Model.SAP;
using Misi.Service.Billing.Object;

namespace Misi.Service.Billing.Handler.SAP
{
    public class QueryInvoiceHeaderFromSAPHandler : InvoiceProformaBaseHandler
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
            System.Diagnostics.Debug.WriteLine("<HEADER_REQUEST BILL_NO = '" + _billingNo + "' BIL_BLK = '" + _billingBlock + "' REJECT = '" + _reasonForRejection + "' PRO_FLG = '" + _proformaFlag + "'/>");
        }

        public override SAPResponse ExecuteQuery()
        {
            InMemoryCache.Instance.ClearCached(Username + Suffix.PERFORMED_INITIAL_SAVE);
            InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_SAP_SESSIONID);
            System.Diagnostics.Debug.WriteLine("<HEADER_QUERY FROM = 'SAP'>");
            var cred = ParseCredential(Username);
            var dest = SAPConnectionFactory.Instance.GetRfcDestination(cred);
            if (dest != null)
            {
                var rawHeader = new InvoiceProformaHeaderDto();
                var repo = dest.Repository;

                System.Diagnostics.Debug.WriteLine("<HEADER_QUERY START_TIME = '" + DateTime.Now + "'/>");

                var func = repo.CreateFunction("ZBAPI_PRINT_BILLING");
                func.SetValue("BILL_NO", _billingNo);
                func.SetValue("PROFORMA_FLAG", " ");
                func.SetValue("BILLING_BLOCK", " ");
                func.SetValue("REASON_FOR_REJECTION", " ");
                func.SetValue("PAGING", " ");
                func.SetValue("MAXROWS", 1);
                func.Invoke(dest);

                System.Diagnostics.Debug.WriteLine("<HEADER_QUERY END_TIME = '" + DateTime.Now + "'/>");

                var headerTbl = func.GetTable("HEADER");
                headerTbl.CurrentIndex = 0;
                var headerStruct = headerTbl.CurrentRow;
                SAPDataCopier.Instance.CopyFromStruct(headerStruct, rawHeader);

                InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_PROFORMA_HEADER);
                InMemoryCache.Instance.Cache(Username + Suffix.QUERIED_PROFORMA_HEADER, rawHeader);

                var cachedBillingNumbers = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_BILLING_NUMBERS) as InvoiceProformaBillingNumberDTO[];
                var head = InMemoryCache.Instance.GetCached(Username + Suffix.REQUEST_HEADER) as RunInvoiceHeaderDTO;
                if (head != null)
                {
                    InMemoryCache.Instance.ClearCached(Username + Suffix.REQUEST_HEADER);
                    head.BillingNo = _billingNo;
                    head.BillingDocsCriteria = _billingBlock;
                    head.ReasonForRejection = _reasonForRejection;
                    head.ProformaFlag = _proformaFlag;
                    head.BillingDateFrom = head.BillingDateFrom;
                    head.BillingDateTo = head.BillingDateTo;
                    head.CreatedBy = rawHeader.ERNAM;
                    head.CreateOn = rawHeader.ERDAT;
                    head.Time = rawHeader.ERZET;
                    head.BillingType = Properties.Settings.Default.BillingType;
                    head.BillingRun = head.SoldToParty + " | 0 | " + DateTime.Now.ToString("dd MMM yyyy") + " | draft";
                    head.Version = "0";

                    InMemoryCache.Instance.ClearCached(Username + Suffix.REQUEST_HEADER);
                    InMemoryCache.Instance.Cache(Username + Suffix.REQUEST_HEADER, head);

                    if (cachedBillingNumbers != null)
                    {
                        var bil = cachedBillingNumbers.ToList().Find(o => o.VBELN == _billingNo);
                        if (bil != null)
                        {
                            head.SoldToPartyName = bil.NAME1;
                        }
                    }
                    
                    InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_FROM_DB);
                    InMemoryCache.Instance.Cache(Username + Suffix.QUERIED_FROM_DB, false);
                    InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_VERSION_FROM_DB);

                    System.Diagnostics.Debug.WriteLine("</HEADER_QUERY>");
                    return head;
                }
                System.Diagnostics.Debug.WriteLine("</HEADER_QUERY>");
                throw new FaultException("Header not found received username = " + Username + " is not in Session!");
            }
            System.Diagnostics.Debug.WriteLine("</HEADER_QUERY>");
            throw new FaultException("RfcDestination is null!");
        }

    }
}