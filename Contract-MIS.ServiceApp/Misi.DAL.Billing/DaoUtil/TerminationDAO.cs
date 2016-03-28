using System.Data.Entity;
using System.Linq;
using Misi.DAL.Billing.Model.Common;
using Misi.DAL.Billing.Model.Request;
using Misi.DAL.Billing.Model.Object;
using Misi.Common.Lib.Util;

namespace Misi.DAL.Billing.DaoUtil
{
    public class TerminationDAO
    {
        public int Create(TerminationRequest o)
        {
            using (var db = new BillingDbContext())
            {
                db.ServiceRequests.Add(o);
                return db.SaveChanges();
            }
        }

        public TerminationRequest Select(long no, bool all = false)
        {
            using (var db = new BillingDbContext())
            {
                if (all)
                {
                    var sql1 = from o in db.ServiceRequests.OfType<TerminationRequest>()
                              .Include(o => o.RequestInfo)
                              .Include(o => o.Routing)
                              .Where(o => o.No == no && o.State != EServiceRequestState.DELETED)
                               select o;
                    var req = sql1.SingleOrDefault();
                    if (req != null && req.Routing.Terminations.Count > 0)
                    {
                        foreach (var ti in req.Routing.Terminations)
                        {
                            TerminationItem ti1 = ti;
                            var sql2 = from t in db.Terminations.Include(t => t.TerminatedContract)
                                       where t.No == ti1.No
                                       select t;
                            ti1 = sql2.SingleOrDefault();
                        }
                    }
                    return req;
                }
                var sql = from o in db.ServiceRequests.OfType<TerminationRequest>()
                    .Include(o => o.RequestInfo)
                    .Where(o => o.No == no && o.State != EServiceRequestState.DELETED)
                          select o;
                return sql.SingleOrDefault();
            }
        }

        public TerminationRequest Select(string id, bool all = false)
        {
            using (var db = new BillingDbContext())
            {
                if (all)
                {
                    var sql1 = from o in db.ServiceRequests.OfType<TerminationRequest>()
                              .Include(o => o.RequestInfo).Include(o => o.RequestInfo.Terminations)
                              .Include(o => o.Routing).Include(o => o.Routing.Terminations)
                              .Where(o => o.Id == id && o.State != EServiceRequestState.DELETED)
                               select o;
                    var req = sql1.SingleOrDefault();
                    if (req != null && req.Routing.Terminations.Count > 0)
                    {
                        foreach (var ti in req.Routing.Terminations)
                        {
                            TerminationItem ti1 = ti;
                            var sql2 = from t in db.Terminations.Include(t => t.TerminatedContract)
                                       where t.No == ti1.No
                                       select t;
                            ti1 = sql2.SingleOrDefault();
                        }
                    }
                    return req;
                }
                var sql = from o in db.ServiceRequests.OfType<TerminationRequest>()
                    .Include(o => o.RequestInfo)
                    .Where(o => o.Id == id && o.State != EServiceRequestState.DELETED)
                          select o;
                return sql.SingleOrDefault();
            }
        }

        public int Update(TerminationRequest o)
        {
            using (var db = new BillingDbContext())
            {
                var ori = Select(o.No, true);
                if (ori == null) return 0;
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
                        ClassCopier.Instance.Copy(ri, ori.RequestInfo);
                        if (ri.Terminations.Count > 0)
                        {
                            var list1 = ri.Terminations;
                            foreach (var ti in list1)
                            {
                                if (ti.No == 0)
                                {
                                    ori.RequestInfo.Terminations.Add(ti);
                                    db.Entry(ti).State = EntityState.Added;
                                }
                                else
                                {
                                    var list2 = ori.RequestInfo.Terminations;
                                    var term = list2.Find(x => x.No == ti.No);
                                    db.Terminations.Attach(term);
                                    db.Entry(term).CurrentValues.SetValues(ti);
                                    db.Entry(term).State = EntityState.Modified;
                                }
                            }
                        }
                    }
                }
                if (o.Routing != null)
                {
                    var ri = o.Routing;
                    if (ri.No == 0)
                    {
                        ori.Routing = ri;
                        db.Entry(ri).State = EntityState.Added;
                    }
                    else
                    {
                        ClassCopier.Instance.Copy(o.Routing, ori.Routing);
                        db.Entry(ori.Routing).State = EntityState.Modified;
                        if (ri.Routings.Count > 0)
                        {
                            var list2 = ri.Routings;
                            foreach (var ri1 in list2)
                            {
                                if (ri1.No == 0)
                                {
                                    ori.Routing.Routings.Add(ri1);
                                    db.Entry(ri1).State = EntityState.Added;
                                }
                                else
                                {
                                    var oriri = ori.Routing.Routings.Find(x => x.No == ri1.No);
                                    db.RoutingItems.Attach(oriri);
                                    db.Entry(oriri).CurrentValues.SetValues(ri1);
                                    db.Entry(oriri).State = EntityState.Modified;
                                }
                            }
                        }
                        if (ri.Terminations.Count > 0)
                        {
                            var list3 = ri.Terminations;
                            foreach (var ti in list3)
                            {
                                if (ti.No == 0)
                                {
                                    ori.Routing.Terminations.Add(ti);
                                    db.Entry(ti).State = EntityState.Added;
                                }
                                else
                                {
                                    var oriti = ori.Routing.Terminations.Find(y => y.No == ti.No);
                                    db.Terminations.Attach(oriti);
                                    if (ti.TerminatedContract != null)
                                    {
                                        var tc = ti.TerminatedContract;
                                        if (tc.No == 0)
                                        {
                                            oriti.TerminatedContract = tc;
                                            db.Entry(tc).State = EntityState.Added;
                                        }
                                        else
                                        {
                                            db.Entry(oriti.TerminatedContract).CurrentValues.SetValues(tc);
                                            db.Entry(tc).State = EntityState.Modified;
                                        }
                                    }
                                }
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
                var o = Select(no, true);
                if (o.RequestInfo != null)
                {
                    var ri = o.RequestInfo;
                    db.Entry(ri).State = EntityState.Deleted;
                    if (ri.Terminations.Count > 0)
                    {
                        var list1 = ri.Terminations;
                        foreach (var ti in list1)
                        {
                            db.Entry(ti).State = EntityState.Deleted;
                        }
                    }
                }
                if (o.Routing != null)
                {
                    var ri = o.Routing;
                    db.Entry(ri).State = EntityState.Deleted;
                    if (ri.Routings.Count() > 0)
                    {
                        var list = ri.Routings;
                        foreach (var ri1 in list)
                        {
                            db.Entry(ri1).State = EntityState.Deleted;
                        }
                    }
                    if (ri.Terminations.Count > 0)
                    {
                        var list2 = ri.Terminations;
                        foreach (var ti in list2)
                        {
                            db.Entry(ti).State = EntityState.Deleted;
                            if (ti.TerminatedContract != null)
                            {
                                var tc = ti.TerminatedContract;
                                db.Entry(tc).State = EntityState.Deleted;
                            }
                        }
                    }
                }
                db.Entry(o).State = EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (var db = new BillingDbContext())
            {
                var o = Select(id, true);
                if (o.RequestInfo != null)
                {
                    var ri = o.RequestInfo;
                    db.Entry(ri).State = EntityState.Deleted;
                    if (ri.Terminations.Count > 0)
                    {
                        var list1 = ri.Terminations;
                        foreach (var ti in list1)
                        {
                            db.Entry(ti).State = EntityState.Deleted;
                        }
                    }
                }
                if (o.Routing != null)
                {
                    var ri = o.Routing;
                    db.Entry(ri).State = EntityState.Deleted;
                    if (ri.Terminations.Count > 0)
                    {
                        var list2 = ri.Terminations;
                        foreach (var ti in list2)
                        {
                            db.Entry(ti).State = EntityState.Deleted;
                            if (ti.TerminatedContract != null)
                            {
                                var tc = ti.TerminatedContract;
                                db.Entry(tc).State = EntityState.Deleted;
                            }
                        }
                    }
                }
                db.Entry(o).State = EntityState.Deleted;
                return db.SaveChanges();
            }
        }
    }
}
