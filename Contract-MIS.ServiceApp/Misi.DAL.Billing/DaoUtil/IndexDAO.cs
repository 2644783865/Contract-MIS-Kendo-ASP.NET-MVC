using System.Data.Entity;
using Misi.DAL.Billing.Model;
using Misi.DAL.Billing.Model.Common;

namespace Misi.DAL.Billing.DaoUtil
{
    public class IndexDAO
    {
        public string NewServiceRequestId()
        {
            using (var db = new BillingDbContext())
            {
                var o = new Index();
                db.Indexes.Add(o);
                db.SaveChanges();

                var counter = "" + o.Counter;
                while (counter.Length < 13)
                {
                    counter = "0" + counter;
                }
                o.UniqueId = "S-" + counter;
                db.Entry(o).State = EntityState.Modified;
                db.SaveChanges();
                return o.UniqueId;
            }
        }

        public string NewRequestInfoId()
        {
            using (var db = new BillingDbContext())
            {
                var o = new Index();
                db.Indexes.Add(o);
                db.SaveChanges();

                var counter = "" + o.Counter;
                while (counter.Length < 13)
                {
                    counter = "0" + counter;
                }
                o.UniqueId = "I-" + counter;
                db.Entry(o).State = EntityState.Modified;
                db.SaveChanges();
                return o.UniqueId;
            }
        }
    }
}
