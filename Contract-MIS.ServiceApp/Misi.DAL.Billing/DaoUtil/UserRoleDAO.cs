using System.Data.Entity;
using System.Linq;
using Misi.DAL.Billing.Model;
using Misi.DAL.Billing.Model.Common;

namespace Misi.DAL.Billing.DaoUtil
{
    public class UserRoleDAO
    {
        public long Create(UserAndRole o)
        {
            using (var db = new BillingDbContext())
            {
                db.Entry(o).State = EntityState.Added;
                db.SaveChanges();
                return o.No;
            }
        }

        public long Delete(long id)
        {
            using (var db = new BillingDbContext())
            {
                var o = db.UserRoles.Find(id);
                if (o != null)
                    db.Entry(o).State = EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public UserAndRole SelectByUsername(string username)
        {
            using (var db = new BillingDbContext())
            {
                var sql = from o in db.UserRoles where o.Username == username select o;
                return sql.SingleOrDefault();
            }
        }
    }
}
