using System.Linq;
using Misi.DAL.Billing.DaoUtil;
using Misi.Service.Billing.Model.SAP;
using Misi.Service.Billing.Object;

namespace Misi.Service.Billing.Handler.SAP
{
    public class QueryBillingRunsFromDBHandler : InvoiceProformaBaseHandler
    {

        public override void SetHandlerArguments(string username, object[] args = null)
        {
            Username = username;
        }

        public override SAPResponse ExecuteQuery()
        {
            InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_VERSION_FROM_DB);
            using (var dao = new BillingDbContext())
            {
                var resp = new InvoiceProformaBillingRunsDTO();
                var sql = from o in dao.InvoiceProformaHeaders.Where(o => o.Version > -1) select o;
                var list2 = sql.ToList();
                resp.Items = list2.Select(h => new InvoiceProformaBillingRunDTO
                {
                    Created = h.Created,
                    Version = h.Version,
                    No = (int) h.No,
                    SoldToParty = h.SoldToParty,
                    Draft = h.Draft,
                    EndDate = h.EndDate,
                    StartDate = h.StartDate
                }).ToList();

                return resp;
            }
        }
    }
}