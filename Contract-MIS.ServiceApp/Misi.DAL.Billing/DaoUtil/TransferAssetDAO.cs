using System.Data.Entity;
using System.Linq;
using Misi.Common.Lib.Util;
using Misi.DAL.Billing.Model.Object;
using Misi.DAL.Billing.Model.Request;
using Misi.DAL.Billing.Model.RoutingInfo;

namespace Misi.DAL.Billing.DaoUtil
{
    public class TransferAssetDAO
    {
        public int Create(TransferAssetRequest o)
        {
            using (var db = new BillingDbContext())
            {
                db.ServiceRequests.Add(o);
                return db.SaveChanges();
            }
        }

        public TransferAssetRequest Select(long no, bool all = false)
        {
            using (var db = new BillingDbContext())
            {
                if (all)
                {
                    var sql1 = from o in db.ServiceRequests.OfType<TransferAssetRequest>()
                              .Include(o => o.RequestInfo)
                              .Include(o => o.Routings)
                              .Where(o => o.No == no && o.State != EServiceRequestState.DELETED)
                               select o;
                    var req = sql1.SingleOrDefault();
                    if (req != null && req.Routings.Count > 0)
                    {
                        foreach (var ri in req.Routings)
                        {
                            if (ri.GetType() == typeof(TransferAssetByHolderRoutingInfo))
                            {
                                var ri1 = ri as TransferAssetByHolderRoutingInfo;
                                var sql2 = from r in db.RoutingInfos.OfType<TransferAssetByHolderRoutingInfo>()
                                    .Include(r => r.NewContract).Include(r => r.OldContract).Include(r => r.Routings)
                                    .Where(r => r.No == ri1.No) 
                                           select r;
                                ri1 = sql2.SingleOrDefault();
                            }
                            else if (ri.GetType() == typeof(TransferAssetByLocationRoutingInfo))
                            {
                                var ri1 = ri as TransferAssetByLocationRoutingInfo;
                                var sql2 = from r in db.RoutingInfos.OfType<TransferAssetByLocationRoutingInfo>()
                                    .Include(r => r.OldContract).Include(r => r.UpdContract).Include(r => r.Routings)
                                    .Where(r => r.No == ri1.No)
                                           select r;
                                ri1 = sql2.SingleOrDefault();
                            }
                        }
                    }
                    return req;
                }
                var sql = from o in db.ServiceRequests.OfType<TransferAssetRequest>()
                    .Include(o => o.RequestInfo)
                    .Where(o => o.No == no && o.State != EServiceRequestState.DELETED)
                    select o;
                return sql.SingleOrDefault();
            }
        }

        public TransferAssetRequest Select(string id, bool all = false)
        {
            using (var db = new BillingDbContext())
            {
                if (all)
                {
                    var sql1 = from o in db.ServiceRequests.OfType<TransferAssetRequest>()
                              .Include(o => o.RequestInfo)
                              .Include(o => o.Routings)
                              .Where(o => o.Id == id && o.State != EServiceRequestState.DELETED)
                               select o;
                    var req = sql1.SingleOrDefault();
                    if (req != null && req.Routings.Count > 0)
                    {
                        foreach (var ri in req.Routings)
                        {
                            if (ri.GetType() == typeof(TransferAssetByHolderRoutingInfo))
                            {
                                var ri1 = ri as TransferAssetByHolderRoutingInfo;
                                var sql2 = from r in db.RoutingInfos.OfType<TransferAssetByHolderRoutingInfo>()
                                    .Include(r => r.NewContract).Include(r => r.OldContract).Include(r => r.Routings)
                                    .Where(r => r.No == ri1.No)
                                           select r;
                                ri1 = sql2.SingleOrDefault();
                            }
                            else if (ri.GetType() == typeof(TransferAssetByLocationRoutingInfo))
                            {
                                var ri1 = ri as TransferAssetByLocationRoutingInfo;
                                var sql2 = from r in db.RoutingInfos.OfType<TransferAssetByLocationRoutingInfo>()
                                    .Include(r => r.OldContract).Include(r => r.UpdContract).Include(r => r.Routings)
                                    .Where(r => r.No == ri1.No)
                                           select r;
                                ri1 = sql2.SingleOrDefault();
                            }
                        }
                    }
                    return req;
                }
                var sql = from o in db.ServiceRequests.OfType<TransferAssetRequest>()
                    .Include(o => o.RequestInfo)
                    .Where(o => o.Id == id && o.State != EServiceRequestState.DELETED)
                    select o;
                return sql.SingleOrDefault();
            }
        }

        public int Update(TransferAssetRequest o)
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
                        db.Entry(ori.RequestInfo).CurrentValues.SetValues(ri);
                        db.Entry(ori.RequestInfo).State = EntityState.Modified;
                    }
                }
                if (o.Routings.Count > 0)
                {
                    var list1 = o.Routings;
                    foreach (var ri in list1)
                    {
                        if (ri.GetType() == typeof (TransferAssetByHolderRoutingInfo))
                        {
                            var ri1 = ri as TransferAssetByHolderRoutingInfo;
                            if (ri1 != null)
                            {
                                if (ri1.No == 0)
                                {
                                    ori.Routings.Add(ri1);
                                    db.Entry(ri1).State = EntityState.Added;
                                }
                                else
                                {
                                    var tahri = ori.Routings.Find(x => x.No == ri1.No) as TransferAssetByHolderRoutingInfo;
                                    if (tahri != null)
                                    {
                                        ClassCopier.Instance.Copy(ri1, tahri);
                                        //System.Diagnostics.Debug.WriteLine("1. TransferAssetByHolderRoutingInfo NO = " + tahri.No);
                                        db.RoutingInfos.Attach(tahri);
                                        if (ri1.NewContract != null)
                                        {
                                            var nc = ri1.NewContract;
                                            if (nc.No == 0)
                                            {
                                                tahri.NewContract = nc;
                                                db.Entry(tahri.NewContract).State = EntityState.Added;
                                            }
                                            else
                                            {
                                                db.Entry(tahri.NewContract).CurrentValues.SetValues(nc);
                                                db.Entry(tahri.NewContract).State = EntityState.Modified;
                                            }
                                        }
                                        if (ri1.OldContract != null)
                                        {
                                            var oc = ri1.OldContract;
                                            if (oc.No == 0)
                                            {
                                                tahri.OldContract = oc;
                                                db.Entry(tahri.OldContract).State = EntityState.Added;
                                            }
                                            else
                                            {
                                                db.Entry(tahri.OldContract).CurrentValues.SetValues(oc);
                                                db.Entry(tahri.OldContract).State = EntityState.Modified;
                                            }
                                        }
                                        if (ri1.Routings.Count > 0)
                                        {
                                            var list2 = ri1.Routings;
                                            //System.Diagnostics.Debug.WriteLine("1. INPUT WF ROUTING SIZE = " + list2.Count);
                                            foreach (var ri2 in list2)
                                            {
                                                if (ri2.No == 0)
                                                {
                                                    tahri.Routings.Add(ri2);
                                                    db.Entry(ri2).State = EntityState.Added;
                                                }
                                                else
                                                {
                                                    //System.Diagnostics.Debug.WriteLine("1. LOADED WORKFLOW SIZE = " + tahri.Routings.Count);
                                                    //System.Diagnostics.Debug.WriteLine("1. LOOKUP FOR WORKFLOW ROUTING NO = " + ri2.No);
                                                    var oririw1 = tahri.Routings.Find(z => z.No == ri2.No);
                                                    db.RoutingItems.Attach(oririw1);
                                                    db.Entry(oririw1).CurrentValues.SetValues(ri2);
                                                    db.Entry(oririw1).State = EntityState.Modified;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (ri.GetType() == typeof(TransferAssetByLocationRoutingInfo))
                        {
                            var ri3 = ri as TransferAssetByLocationRoutingInfo;
                            if (ri3 != null)
                            {
                                if (ri3.No == 0)
                                {
                                    ori.Routings.Add(ri3);
                                    db.Entry(ri3).State = EntityState.Added;
                                }
                                else
                                {
                                    var talri = ori.Routings.Find(x => x.No == ri3.No) as TransferAssetByLocationRoutingInfo;
                                    if (talri != null)
                                    {
                                        ClassCopier.Instance.Copy(ri3, talri);
                                        //System.Diagnostics.Debug.WriteLine("2. TransferAssetByLocationRoutingInfo NO = " + talri.No);
                                        db.RoutingInfos.Attach(talri);
                                        if (ri3.UpdContract != null)
                                        {
                                            var nc = ri3.UpdContract;
                                            if (nc.No == 0)
                                            {
                                                talri.UpdContract = nc;
                                                db.Entry(talri.UpdContract).State = EntityState.Added;
                                            }
                                            else
                                            {
                                                db.Entry(talri.UpdContract).CurrentValues.SetValues(nc);
                                                db.Entry(talri.UpdContract).State = EntityState.Modified;
                                            }
                                        }
                                        if (ri3.OldContract != null)
                                        {
                                            var oc = ri3.OldContract;
                                            if (oc.No == 0)
                                            {
                                                talri.OldContract = oc;
                                                db.Entry(talri.OldContract).State = EntityState.Added;
                                            }
                                            else
                                            {
                                                db.Entry(talri.OldContract).CurrentValues.SetValues(oc);
                                                db.Entry(talri.OldContract).State = EntityState.Modified;
                                            }
                                        }
                                        if (ri3.Routings.Count > 0)
                                        {
                                            var list3 = ri3.Routings;
                                            //System.Diagnostics.Debug.WriteLine("2. INPUT WF ROUTING SIZE = " + list3.Count);
                                            foreach (var ri4 in list3)
                                            {
                                                if (ri4.No == 0)
                                                {
                                                    talri.Routings.Add(ri4);
                                                    db.Entry(ri4).State = EntityState.Added;
                                                }
                                                else
                                                {
                                                    //System.Diagnostics.Debug.WriteLine("2. LOADED WORKFLOW SIZE = " + talri.Routings.Count);
                                                    //System.Diagnostics.Debug.WriteLine("2. LOOKUP FOR WORKFLOW ROUTING NO = " + ri4.No);
                                                    var oririw2 = talri.Routings.Find(z => z.No == ri4.No);
                                                    db.RoutingItems.Attach(oririw2);
                                                    db.Entry(oririw2).CurrentValues.SetValues(ri4);
                                                    db.Entry(oririw2).State = EntityState.Modified;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                db.Entry(ori).State = EntityState.Modified;
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
                        if (ri1.Routings.Count > 0)
                        {
                            var list2 = ri1.Routings;
                            foreach (var ri2 in list2)
                            {
                                db.Entry(ri2).State = EntityState.Deleted;
                            }
                        }

                        if (ri1.GetType() == typeof(TransferAssetByHolderRoutingInfo))
                        {
                            var ri3 = ri1 as TransferAssetByHolderRoutingInfo;
                            if (ri3 != null)
                            {
                                if (ri3.NewContract != null)
                                {
                                    var nc = ri3.NewContract;
                                    db.Entry(nc).State = EntityState.Deleted;
                                }
                                if (ri3.OldContract != null)
                                {
                                    var oc = ri3.OldContract;
                                    db.Entry(oc).State = EntityState.Deleted;
                                }
                            }
                        }
                        if (ri1.GetType() == typeof(TransferAssetByLocationRoutingInfo))
                        {
                            var ri3 = ri1 as TransferAssetByLocationRoutingInfo;
                            if (ri3 != null)
                            {
                                if (ri3.UpdContract != null)
                                {
                                    var nc = ri3.UpdContract;
                                    db.Entry(nc).State = EntityState.Deleted;
                                }
                                if (ri3.OldContract != null)
                                {
                                    var oc = ri3.OldContract;
                                    db.Entry(oc).State = EntityState.Deleted;
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
                if (o.Routings.Count > 0)
                {
                    var list1 = o.Routings;
                    foreach (var ri1 in list1)
                    {
                        db.Entry(ri1).State = EntityState.Deleted;
                        if (ri1.Routings.Count > 0)
                        {
                            var list2 = ri1.Routings;
                            foreach (var ri2 in list2)
                            {
                                db.Entry(ri2).State = EntityState.Deleted;
                            }
                        }

                        if (ri1.GetType() == typeof(TransferAssetByHolderRoutingInfo))
                        {
                            var ri3 = ri1 as TransferAssetByHolderRoutingInfo;
                            if (ri3 != null)
                            {
                                if (ri3.NewContract != null)
                                {
                                    var nc = ri3.NewContract;
                                    db.Entry(nc).State = EntityState.Deleted;
                                }
                                if (ri3.OldContract != null)
                                {
                                    var oc = ri3.OldContract;
                                    db.Entry(oc).State = EntityState.Deleted;
                                }
                            }
                        }
                        if (ri1.GetType() == typeof(TransferAssetByLocationRoutingInfo))
                        {
                            var ri3 = ri1 as TransferAssetByLocationRoutingInfo;
                            if (ri3 != null)
                            {
                                if (ri3.UpdContract != null)
                                {
                                    var nc = ri3.UpdContract;
                                    db.Entry(nc).State = EntityState.Deleted;
                                }
                                if (ri3.OldContract != null)
                                {
                                    var oc = ri3.OldContract;
                                    db.Entry(oc).State = EntityState.Deleted;
                                }
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
