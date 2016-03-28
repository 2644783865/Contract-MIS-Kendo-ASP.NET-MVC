using System.Data.Entity;
using System.Linq;
using Misi.Common.Lib.Util;
using Misi.DAL.Billing.Model.Object;
using Misi.DAL.Billing.Model.Request;

namespace Misi.DAL.Billing.DaoUtil
{
    public class BrokenDeviceDAO
    {
        public int Create(BrokenDeviceRequest o)
        {
            using (var db = new BillingDbContext())
            {
                db.ServiceRequests.Add(o);
                return db.SaveChanges();
            }
        }

        public BrokenDeviceRequest Select(long no, bool all = false)
        {
            using (var db = new BillingDbContext())
            {
                if (all)
                {
                    var sql1 = from o in db.ServiceRequests.OfType<BrokenDeviceRequest>()
                              .Include(o => o.RequestInfo)
                              .Include(o => o.Routing).Include(o => o.Routing.Contract)
                              .Where(o => o.No == no && o.State != EServiceRequestState.DELETED)
                               select o;
                    return sql1.SingleOrDefault();
                }
                var sql = from o in db.ServiceRequests.OfType<BrokenDeviceRequest>()
                    .Include(o => o.RequestInfo)
                    .Where(o => o.No == no && o.State != EServiceRequestState.DELETED)
                          select o;
                return sql.SingleOrDefault();
            }
        }

        public BrokenDeviceRequest Select(string id, bool all = false)
        {
            using (var db = new BillingDbContext())
            {
                if (all)
                {
                    var sql1 = from o in db.ServiceRequests.OfType<BrokenDeviceRequest>()
                              .Include(o => o.RequestInfo)
                              .Include(o => o.Routing).Include(o => o.Routing.Contract)
                              .Where(o => o.Id == id && o.State != EServiceRequestState.DELETED)
                               select o;                    
                    return sql1.SingleOrDefault();
                }
                var sql = from o in db.ServiceRequests.OfType<BrokenDeviceRequest>()
                    .Include(o => o.RequestInfo)
                    .Where(o => o.Id == id && o.State != EServiceRequestState.DELETED)
                          select o;
                return sql.SingleOrDefault();
            }
        }

        public int Update(BrokenDeviceRequest o)
        {
            using (var db = new BillingDbContext())
            {
                var ori = Select(o.No, true);
                if (o.RequestInfo != null)
                {
                    var ri = o.RequestInfo;
                    if (ri.No == 0)
                    {
                        ori.RequestInfo = ri;
                        db.Entry(ri).State = EntityState.Added;
                    }
                    else
                    {
                        db.RequestInfos.Attach(ori.RequestInfo);
                        db.Entry(ori.RequestInfo).CurrentValues.SetValues(ri);
                        db.Entry(ori.RequestInfo).State = EntityState.Modified;
                    }
                }
                if (o.Routing != null)
                {
                    var ri1 = o.Routing;
                    if (ri1.No == 0)
                    {
                        ori.Routing = ri1;
                        db.Entry(ri1).State = EntityState.Added;
                    }
                    else
                    {
                        ClassCopier.Instance.Copy(ri1, ori.Routing);
                        db.Entry(ori.Routing).State = EntityState.Modified;
                        if (ri1.Routings.Count > 0)
                        {
                            var list2 = ri1.Routings;
                            foreach (var ri2 in list2)
                            {
                                if (ri2.No == 0)
                                {
                                    ori.Routing.Routings.Add(ri2);
                                    db.Entry(ri1).State = EntityState.Added;
                                }
                                else
                                {
                                    var oriri = ori.Routing.Routings.Find(x => x.No == ri2.No);
                                    db.RoutingItems.Attach(oriri);
                                    db.Entry(oriri).CurrentValues.SetValues(ri2);
                                    db.Entry(oriri).State = EntityState.Modified;
                                }
                            }
                        }
                        if (ri1.Contract != null)
                        {
                            var ct = ri1.Contract;
                            if (ct.No == 0)
                            {
                                ori.Routing.Contract = ct;
                                db.Entry(ct).State = EntityState.Added;
                            }
                            else
                            {
                                db.Contracts.Attach(ori.Routing.Contract);
                                db.Entry(ori.Routing.Contract).CurrentValues.SetValues(ct);
                                db.Entry(ori.Routing.Contract).State = EntityState.Modified;
                            }
                        }
                    }
                }
                db.Entry(o).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public int Delete(long no)
        {
            using (var db = new BillingDbContext())
            {
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (var db = new BillingDbContext())
            {
                return db.SaveChanges();
            }
        }
    }
}
