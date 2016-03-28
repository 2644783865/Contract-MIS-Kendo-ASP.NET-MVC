using System.Data.Entity;
using System.Linq;
using Misi.DAL.Billing.Model.Contract;
using Misi.DAL.Billing.Model.Object;
using Misi.DAL.Billing.Model.Request;
using Misi.Common.Lib.Util;

namespace Misi.DAL.Billing.DaoUtil
{
    public class ErrorChargesDAO
    {
        public int Create(ErrorChargesRequest o)
        {
            using (var db = new BillingDbContext())
            {
                db.ServiceRequests.Add(o);
                return db.SaveChanges();
            }
        }

        public ErrorChargesRequest Select(long no, bool all = false)
        {
            using (var db = new BillingDbContext())
            {
                if (all)
                {
                    var sql1 = from o in db.ServiceRequests.OfType<ErrorChargesRequest>()
                              .Include(o => o.RequestInfo)
                              .Include(o => o.Routing).Include(o => o.Routing.Contracts)
                              .Where(o => o.No == no && o.State != EServiceRequestState.DELETED)
                               select o;
                    var req = sql1.SingleOrDefault();
                    if (req != null && req.Routing.Contracts.Count > 0)
                    {
                        foreach (var cwb in req.Routing.Contracts)
                        {
                            ContractWithBillings cwb1 = cwb;
                            var sql2 = from c in db.Contracts.OfType<ContractWithBillings>().Include(c => c.Billings)
                                       where c.No == cwb1.No
                                       select c;
                            cwb1 = sql2.SingleOrDefault();
                        }
                    }
                    return req;
                }
                var sql = from o in db.ServiceRequests.OfType<ErrorChargesRequest>()
                    .Include(o => o.RequestInfo)
                    .Where(o => o.No == no && o.State != EServiceRequestState.DELETED)
                          select o;
                return sql.SingleOrDefault();
            }
        }

        public ErrorChargesRequest Select(string id, bool all = false)
        {
            using (var db = new BillingDbContext())
            {
                if (all)
                {
                    var sql1 = from o in db.ServiceRequests.OfType<ErrorChargesRequest>()
                              .Include(o => o.RequestInfo)
                              .Include(o => o.Routing).Include(o => o.Routing.Contracts)
                              .Where(o => o.Id == id && o.State != EServiceRequestState.DELETED)
                               select o;
                    var req = sql1.SingleOrDefault();
                    if (req != null && req.Routing.Contracts.Count > 0)
                    {
                        foreach (var cwb in req.Routing.Contracts)
                        {
                            ContractWithBillings cwb1 = cwb;
                            var sql2 = from c in db.Contracts.OfType<ContractWithBillings>().Include(c => c.Billings)
                                       where c.No == cwb1.No
                                       select c;
                            cwb1 = sql2.SingleOrDefault();
                        }
                    }
                    return req;
                }
                var sql = from o in db.ServiceRequests.OfType<ErrorChargesRequest>()
                    .Include(o => o.RequestInfo)
                    .Where(o => o.Id == id && o.State != EServiceRequestState.DELETED)
                          select o;
                return sql.SingleOrDefault();
            }
        }

        public int Update(ErrorChargesRequest o)
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
                        if (ri1.Contracts.Count > 0)
                        {
                            var list1 = ri1.Contracts;
                            foreach (var cwb in list1)
                            {
                                if (cwb.No == 0)
                                {
                                    ori.Routing.Contracts.Add(cwb);
                                    db.Entry(cwb).State = EntityState.Added;
                                }
                                else
                                {
                                    var oricwb = ori.Routing.Contracts.Find(x => x.No == cwb.No);
                                    if (oricwb != null)
                                    {
                                        ClassCopier.Instance.Copy(cwb, oricwb);
                                        db.Entry(oricwb).State = EntityState.Modified;
                                        if (cwb.Billings.Count > 0)
                                        {
                                            var list2 = cwb.Billings;
                                            foreach (var cb in list2)
                                            {
                                                if (cb.No == 0)
                                                {
                                                    oricwb.Billings.Add(cb);
                                                    db.Entry(cb).State = EntityState.Added;
                                                }
                                                else
                                                {
                                                    var orib = oricwb.Billings.Find(y => y.No == cb.No);
                                                    db.Contracts.Attach(orib);
                                                    db.Entry(orib).CurrentValues.SetValues(cb);
                                                    db.Entry(orib).State = EntityState.Modified;
                                                }
                                            }
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
                }
                if (o.Routing != null)
                {
                    var ri1 = o.Routing;
                    db.Entry(ri1).State = EntityState.Deleted;
                    if (ri1.Contracts.Count > 0)
                    {
                        var list1 = ri1.Contracts;
                        foreach (var cwb in list1)
                        {
                            db.Entry(cwb).State = EntityState.Deleted;
                            if (cwb.Billings.Count > 0)
                            {
                                var list2 = cwb.Billings;
                                foreach (var cb in list2)
                                {
                                    db.Entry(cb).State = EntityState.Deleted;
                                }
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
                if (o.Routing != null)
                {
                    var ri1 = o.Routing;
                    db.Entry(ri1).State = EntityState.Deleted;
                    if (ri1.Contracts.Count > 0)
                    {
                        var list1 = ri1.Contracts;
                        foreach (var cwb in list1)
                        {
                            db.Entry(cwb).State = EntityState.Deleted;
                            if (cwb.Billings.Count > 0)
                            {
                                var list2 = cwb.Billings;
                                foreach (var cb in list2)
                                {
                                    db.Entry(cb).State = EntityState.Deleted;
                                }
                            }
                        }
                    }
                    if (ri1.Routings.Count > 0)
                    {
                    }
                }
                db.Entry(o).State = EntityState.Deleted;
                return db.SaveChanges();
            }
        }
    }
}
