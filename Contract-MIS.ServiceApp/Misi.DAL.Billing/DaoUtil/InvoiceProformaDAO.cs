using System;
using Misi.DAL.Billing.Model.SAP;

namespace Misi.DAL.Billing.DaoUtil
{
    public class InvoiceProformaDAO
    {
        public long Create(InvoiceProformaHeader o)
        {
            using (var db = new BillingDbContext())
            {
                db.InvoiceProformaHeaders.Add(o);
                db.SaveChanges();
                return o.No;
            }
        }

        public InvoiceProformaHeader SelectByQueryParam(string soldToParty, 
            DateTime startDate, DateTime endDate, bool billingBlock = false, 
            bool reasonForRejection = false)
        {
            using (var db = new BillingDbContext())
            {
                return null;
            }
        }

    }
}
