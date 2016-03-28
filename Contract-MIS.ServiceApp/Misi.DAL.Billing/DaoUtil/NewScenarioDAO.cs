using System.Data.Entity;
using System.Linq;
using Misi.DAL.Billing.Model.Object;
using Misi.DAL.Billing.Model.Request;
using Misi.DAL.Billing.Model.RoutingInfo;
using Misi.Common.Lib.Util;

namespace Misi.DAL.Billing.DaoUtil
{
    public class NewScenarioDAO
    {
        public int Create(NewScenarioRequest o)
        {
            using (var db = new BillingDbContext())
            {
                db.ServiceRequests.Add(o);
                return db.SaveChanges();
            }
        }

        public NewScenarioRequest Select(long no, bool all = false)
        {
            using (var db = new BillingDbContext())
            {
                if (all)
                {
                    var sql1 = from o in db.ServiceRequests.OfType<NewScenarioRequest>()
                              .Include(o => o.RequestInfo)
                              .Include(o => o.Routings)
                              .Where(o => o.No == no && o.State != EServiceRequestState.DELETED)
                               select o;
                    var req = sql1.SingleOrDefault();
                    if (req != null && req.Routings.Count > 0)
                    {
                        foreach (var ri in req.Routings)
                        {
                            NewScenarioRoutingInfo ri1 = ri;
                            var sql2 = from r in db.RoutingInfos.OfType<NewScenarioRoutingInfo>()
                                .Include(r => r.Contract)
                                .Include(r => r.Routings).Where(r => r.No == ri1.No)
                                       select r;
                            ri1 = sql2.SingleOrDefault();
                        }
                    }
                    return req;
                }
                var sql = from o in db.ServiceRequests.OfType<NewScenarioRequest>()
                              .Include(o => o.RequestInfo)
                              .Where(o => o.No == no && o.State != EServiceRequestState.DELETED)
                          select o;
                return sql.SingleOrDefault();
            }
        }

        public NewScenarioRequest Select(string id, bool all = false)
        {
            using (var db = new BillingDbContext())
            {
                if (all)
                {
                    var sql1 = from o in db.ServiceRequests.OfType<NewScenarioRequest>()
                              .Include(o => o.RequestInfo)
                              .Include(o => o.Routings)
                              .Where(o => o.Id == id && o.State != EServiceRequestState.DELETED)
                               select o;
                    var req = sql1.SingleOrDefault();
                    if (req != null && req.Routings.Count > 0)
                    {
                        foreach (var ri in req.Routings)
                        {
                            NewScenarioRoutingInfo ri1 = ri;
                            var sql2 = from r in db.RoutingInfos.OfType<NewScenarioRoutingInfo>()
                                .Include(r => r.Contract)
                                .Include(r => r.Routings).Where(r => r.No == ri1.No)
                                       select r;
                            ri1 = sql2.SingleOrDefault();
                        }
                    }
                    return req;
                }
                var sql = from o in db.ServiceRequests.OfType<NewScenarioRequest>()
                              .Include(o => o.RequestInfo)
                              .Where(o => o.Id == id && o.State != EServiceRequestState.DELETED)
                          select o;
                return sql.SingleOrDefault();
            }
        }

        public int Update(NewScenarioRequest o)
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
                if (o.Routings.Count > 0)
                {
                    var list1 = o.Routings;
                    foreach (var ri1 in list1)
                    {
                        if (ri1.No == 0)
                        {
                            ori.Routings.Add(ri1);
                            db.Entry(ri1).State = EntityState.Added;
                        }
                        else
                        {
                            var oriri1 = ori.Routings.Find(x => x.No == ri1.No);
                            if (oriri1 != null)
                            {
                                db.RoutingInfos.Attach(oriri1);
                                ClassCopier.Instance.Copy(ri1, oriri1);
                                db.Entry(oriri1).State = EntityState.Modified;
                                if (ri1.Routings.Count > 0)
                                {
                                    var list2 = ri1.Routings;
                                    foreach (var ri2 in list2)
                                    {
                                        if (ri2.No == 0)
                                        {
                                            oriri1.Routings.Add(ri2);
                                            db.Entry(ri2).State = EntityState.Added;
                                        }
                                        else
                                        {
                                            var oriri2 = oriri1.Routings.Find(y => y.No == ri2.No);
                                            db.RoutingItems.Attach(oriri2);
                                            db.Entry(oriri2).CurrentValues.SetValues(ri2);
                                            db.Entry(oriri2).State = EntityState.Modified;
                                        }
                                    }
                                }
                                if (ri1.Contract != null)
                                {
                                    var oc = ri1.Contract;
                                    if (oc.No == 0)
                                    {
                                        oriri1.Contract = oc;
                                        db.Entry(oc).State = EntityState.Added;
                                    }
                                    else
                                    {
                                        db.Entry(oriri1.Contract).CurrentValues.SetValues(oc);
                                        db.Entry(oriri1.Contract).State = EntityState.Modified;
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
                }
                if (o.Routings.Count > 0)
                {
                    var list1 = o.Routings;
                    foreach (var ri1 in list1)
                    {
                        db.Entry(ri1).State = EntityState.Deleted;
                        if (ri1.Contract != null)
                        {
                            var c = ri1.Contract;
                            db.Entry(c).State = EntityState.Deleted;
                        }
                        if (ri1.Routings.Count > 0)
                        {
                            var list2 = ri1.Routings;
                            foreach (var ri2 in list2)
                            {
                                db.Entry(ri2).State = EntityState.Deleted;
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
                }
                if (o.Routings.Count > 0)
                {
                    var list1 = o.Routings;
                    foreach (var ri1 in list1)
                    {
                        db.Entry(ri1).State = EntityState.Deleted;
                        if (ri1.Contract != null)
                        {
                            var c = ri1.Contract;
                            db.Entry(c).State = EntityState.Deleted;
                        }
                        if (ri1.Routings.Count > 0)
                        {
                            var list2 = ri1.Routings;
                            foreach (var ri2 in list2)
                            {
                                db.Entry(ri2).State = EntityState.Deleted;
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
