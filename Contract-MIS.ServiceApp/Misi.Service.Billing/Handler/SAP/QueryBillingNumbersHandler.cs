using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel;
using Misi.Common.Lib.Util;
using Misi.Service.Billing.Model.SAP;
using Misi.Service.Billing.Object;

namespace Misi.Service.Billing.Handler.SAP
{
    public class QueryBillingNumbersHandler : InvoiceProformaBaseHandler
    {
        private const string FUNCTIONAL_BAPI = "ZBAPI_GET_BILLING";

        private string _soldToParty;
        private DateTime _startDate;
        private DateTime _endDate;

        public override void SetHandlerArguments(string username, object[] args = null)
        {
            Username = username;
            if (args == null) return;
            _soldToParty = (string) args[0];
            _startDate = (DateTime) args[1];
            _endDate = (DateTime) args[2];
        }

        public override SAPResponse ExecuteQuery()
        {
            var cred = ParseCredential(Username);
            var resp = new BillingNumberItemsDTO();
            var dest = SAPConnectionFactory.Instance.GetRfcDestination(cred);
            if (dest == null) return null;
            var repo = dest.Repository;
            var func = repo.CreateFunction(FUNCTIONAL_BAPI);
            func.SetValue("SOLD_TO", _soldToParty);
            func.SetValue("BILLING_START_DATE", _startDate.ToString("yyyyMMdd"));
            func.SetValue("BILLING_END_DATE", _endDate.ToString("yyyyMMdd"));
            func.SetValue("BILLING_TYPE", "ZF9");
            func.Invoke(dest);

            var billNumsTbl = func.GetTable("BILLING_DOC");
            var rawList = new List<InvoiceProformaBillingNumberDTO>();
            for (var a = 0; a < billNumsTbl.RowCount; a++)
            {
                billNumsTbl.CurrentIndex = a;
                var it = new InvoiceProformaBillingNumberDTO();
                SAPDataCopier.Instance.CopyFromStruct(billNumsTbl.CurrentRow, it);
                rawList.Add(it);

                var li = new BillingNumberItemDTO
                {
                    BillingDocNumber = it.VBELN,
                    CreateTime = DateTime.ParseExact(it.ERZET, "HH:mm:ss", CultureInfo.InvariantCulture),
                    CreatedBy = it.ERNAM,
                    CreatedDate = DateTime.ParseExact(it.ERDAT, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                };
                resp.Numbers.Add(li);
            }

            InMemoryCache.Instance.ClearCached(Username + Suffix.REQUEST_HEADER);
            InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_BILLING_NUMBERS);

            var head = new RunInvoiceHeaderDTO
            {
                BillingDateFrom = _startDate,
                BillingDateTo = _endDate,
                SoldToParty = _soldToParty
            };
            InMemoryCache.Instance.Cache(Username + Suffix.REQUEST_HEADER, head);
            InMemoryCache.Instance.Cache(Username + Suffix.QUERIED_BILLING_NUMBERS, rawList.ToArray());

            return resp;
        }
    }

}