using System.Globalization;
using System.Linq;
using System.ServiceModel;
using Misi.DAL.Billing.DaoUtil;
using Misi.Service.Billing.Model.SAP;
using Misi.Service.Billing.Object;

namespace Misi.Service.Billing.Handler.SAP
{
    public class QueryInvoiceHeaderFromDBHandler : InvoiceProformaBaseHandler
    {
        private long _no;

        public override void SetHandlerArguments(string username, object[] args = null)
        {
            Username = username;
            if (args == null) return;
            _no = (long) args[0];
        }

        public override SAPResponse ExecuteQuery()
        {
            System.Diagnostics.Debug.WriteLine("<HEADER_QUERY FROM = 'DATABASE'>");
            using (var dao = new BillingDbContext())
            {
                var sql = from o in dao.InvoiceProformaHeaders.Where(o => o.No == _no) select o;
                var dbRawHead = sql.FirstOrDefault();
                if (dbRawHead != null)
                {
                    var ver = "Final";
                    if (dbRawHead.Draft)
                    {
                        ver = "Draft";
                    }
                    var head = new RunInvoiceHeaderDTO
                    {
                        BillingDateFrom = dbRawHead.StartDate,
                        BillingDateTo = dbRawHead.EndDate,
                        BillingDocsCriteria = dbRawHead.BillingBlock,
                        BillingNo = dbRawHead.BillingNo,
                        ReasonForRejection = dbRawHead.ReasonForRejection,
                        SoldToParty = dbRawHead.SoldToParty,
                        Version = dbRawHead.Version.ToString(CultureInfo.InvariantCulture),
                        CreatedBy = dbRawHead.ERNAM,
                        CreateOn = dbRawHead.ERDAT,
                        Time = dbRawHead.ERZET,
                        ProformaFlag = dbRawHead.ProformaFlag,
                        BillingType = Properties.Settings.Default.BillingType,
                        SoldToPartyName = dbRawHead.SoldToParty,
                        Draft = dbRawHead.Draft,
                        BillingRun =
                            dbRawHead.SoldToParty + " | " + dbRawHead.Version + " | " +
                            dbRawHead.Created.ToString("dd MMM yyyy") + " | " + ver
                    };

                    InMemoryCache.Instance.ClearCached(Username + Suffix.REQUEST_HEADER);
                    InMemoryCache.Instance.Cache(Username + Suffix.REQUEST_HEADER, head);

                    var rawHead = new InvoiceProformaHeaderDto
                    {
                        CITY1 = dbRawHead.CITY1,
                        ERDAT = dbRawHead.ERDAT,
                        ERNAM = dbRawHead.ERNAM,
                        ERZET = dbRawHead.ERZET,
                        FKDAT = dbRawHead.FKDAT,
                        FPAJAK_NO = dbRawHead.FPAJAK_NO,
                        HTOTAL1 = dbRawHead.HTOTAL1,
                        HTOTAL2 = dbRawHead.HTOTAL2,
                        HTOTAL3 = dbRawHead.HTOTAL3,
                        HTOTAL4 = dbRawHead.HTOTAL4,
                        HTOTAL5 = dbRawHead.HTOTAL5,
                        KUNRG = dbRawHead.KUNRG,
                        KURRF = dbRawHead.KURRF,
                        NAME1 = dbRawHead.NAME1,
                        NAME2 = dbRawHead.NAME2,
                        NAME3 = dbRawHead.NAME3,
                        NAME4 = dbRawHead.NAME4,
                        No = dbRawHead.No,
                        POST_CODE1 = dbRawHead.POST_CODE1,
                        STCEG = dbRawHead.STCEG,
                        STREET = dbRawHead.STREET,
                        TDLINE = dbRawHead.TDLINE,
                        TEXT1 = dbRawHead.TEXT1,
                        VBELN = dbRawHead.VBELN,
                        VTEXT = dbRawHead.VTEXT,
                        WAERK = dbRawHead.WAERK,
                        ZTERM = dbRawHead.ZTERM
                    };

                    InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_PROFORMA_HEADER);
                    InMemoryCache.Instance.Cache(Username + Suffix.QUERIED_PROFORMA_HEADER, rawHead);

                    InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_VERSION_FROM_DB);
                    InMemoryCache.Instance.Cache(Username + Suffix.QUERIED_VERSION_FROM_DB, dbRawHead.Version);
                    System.Diagnostics.Debug.WriteLine("<HEADER_QUERY VERSION = '" + head.Version + "'/>");

                    InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_FROM_DB);
                    InMemoryCache.Instance.Cache(Username + Suffix.QUERIED_FROM_DB, true);

                    System.Diagnostics.Debug.WriteLine("</HEADER_QUERY>");

                    return head;
                }
                throw new FaultException("Selected header is null!");
            }
        }
    }
}