using System.Data.Entity;
using System.Linq;
using Misi.DAL.Billing.Model.Request;
using Misi.DAL.Billing.Model.Object;
using Misi.DAL.Billing.Model.RoutingInfo;
using Misi.Common.Lib.Util;

namespace Misi.DAL.Billing.DaoUtil
{
    public class NewContractDAO
    {
        public int Create(NewContractRequest o)
        {
            using (var db = new BillingDbContext())
            {
                db.ServiceRequests.Add(o);
                return db.SaveChanges();
            }
        }

        public NewContractRequest Select(long no, bool all = false)
        {
            using (var db = new BillingDbContext())
            {
                if (all)
                {
                    var sql1 = from o in db.ServiceRequests.OfType<NewContractRequest>()
                              .Include(o => o.RequestInfo)
                              .Include(o => o.Routings)
                              .Where(o => o.No == no && o.State != EServiceRequestState.DELETED)
                               select o;
                    var req = sql1.SingleOrDefault();
                    if (req != null && req.Routings.Count > 0)
                    {
                        foreach (var ri in req.Routings)
                        {
                            if (ri.GetType() == typeof(NewContractExtLineRoutingInfo))
                            {
                                var ri1 = ri as NewContractExtLineRoutingInfo;
                                var sql2 = from r in db.RoutingInfos.OfType<NewContractExtLineRoutingInfo>()
                                    .Include(r => r.Contract).Include(r => r.Routings)
                                    .Where(r => r.No == ri1.No)
                                           select r;
                                ri1 = sql2.SingleOrDefault();
                            }
                            else if (ri.GetType() == typeof(NewContractIpPhoneRoutingInfo))
                            {
                                var ri1 = ri as NewContractIpPhoneRoutingInfo;
                                var sql2 = from r in db.RoutingInfos.OfType<NewContractIpPhoneRoutingInfo>()
                                    .Include(r => r.Contract).Include(r => r.Routings)
                                    .Where(r => r.No == ri1.No)
                                           select r;
                                ri1 = sql2.SingleOrDefault();
                            }
                            else if (ri.GetType() == typeof(NewContractLaptopRoutingInfo))
                            {
                                var ri1 = ri as NewContractLaptopRoutingInfo;
                                var sql2 = from r in db.RoutingInfos.OfType<NewContractLaptopRoutingInfo>()
                                    .Include(r => r.Contract).Include(r => r.Routings)
                                    .Where(r => r.No == ri1.No)
                                           select r;
                                ri1 = sql2.SingleOrDefault();
                            }
                            else if (ri.GetType() == typeof(NewContractSoftwareRoutingInfo))
                            {
                                var ri1 = ri as NewContractSoftwareRoutingInfo;
                                var sql2 = from r in db.RoutingInfos.OfType<NewContractSoftwareRoutingInfo>()
                                    .Include(r => r.Contract).Include(r => r.Routings)
                                    .Where(r => r.No == ri1.No)
                                           select r;
                                ri1 = sql2.SingleOrDefault();
                            }
                        }
                    }
                    return req;
                }
                var sql = from o in db.ServiceRequests.OfType<NewContractRequest>()
                              .Include(o => o.RequestInfo)
                              .Where(o => o.No == no && o.State != EServiceRequestState.DELETED)
                          select o;
                return sql.SingleOrDefault();
            }
        }

        public NewContractRequest Select(string id, bool all = false)
        {
            using (var db = new BillingDbContext())
            {
                if (all)
                {
                    var sql1 = from o in db.ServiceRequests.OfType<NewContractRequest>()
                              .Include(o => o.RequestInfo)
                              .Include(o => o.Routings)
                              .Where(o => o.Id == id && o.State != EServiceRequestState.DELETED)
                               select o;
                    var req = sql1.SingleOrDefault();
                    if (req != null && req.Routings.Count > 0)
                    {
                        foreach (var ri in req.Routings)
                        {
                            if (ri.GetType() == typeof(NewContractExtLineRoutingInfo))
                            {
                                var ri1 = ri as NewContractExtLineRoutingInfo;
                                var sql2 = from r in db.RoutingInfos.OfType<NewContractExtLineRoutingInfo>()
                                    .Include(r => r.Contract).Include(r => r.Routings)
                                    .Where(r => r.No == ri1.No)
                                           select r;
                                ri1 = sql2.SingleOrDefault();
                            }
                            else if (ri.GetType() == typeof(NewContractIpPhoneRoutingInfo))
                            {
                                var ri1 = ri as NewContractIpPhoneRoutingInfo;
                                var sql2 = from r in db.RoutingInfos.OfType<NewContractIpPhoneRoutingInfo>()
                                    .Include(r => r.Contract).Include(r => r.Routings)
                                    .Where(r => r.No == ri1.No)
                                           select r;
                                ri1 = sql2.SingleOrDefault();
                            }
                            else if (ri.GetType() == typeof(NewContractLaptopRoutingInfo))
                            {
                                var ri1 = ri as NewContractLaptopRoutingInfo;
                                var sql2 = from r in db.RoutingInfos.OfType<NewContractLaptopRoutingInfo>()
                                    .Include(r => r.Contract).Include(r => r.Routings)
                                    .Where(r => r.No == ri1.No)
                                           select r;
                                ri1 = sql2.SingleOrDefault();
                            }
                            else if (ri.GetType() == typeof(NewContractSoftwareRoutingInfo))
                            {
                                var ri1 = ri as NewContractSoftwareRoutingInfo;
                                var sql2 = from r in db.RoutingInfos.OfType<NewContractSoftwareRoutingInfo>()
                                    .Include(r => r.Contract).Include(r => r.Routings)
                                    .Where(r => r.No == ri1.No)
                                           select r;
                                ri1 = sql2.SingleOrDefault();
                            }
                        }
                    }
                    return req;
                }
                var sql = from o in db.ServiceRequests.OfType<NewContractRequest>()
                              .Include(o => o.RequestInfo)
                              .Where(o => o.Id == id && o.State != EServiceRequestState.DELETED)
                          select o;
                return sql.SingleOrDefault();
            }
        }

        public int Update(NewContractRequest o)
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
                            var oriri = ori.Routings.Find(x => x.No == ri1.No);
                            if (oriri != null)
                            {
                                db.RoutingInfos.Attach(oriri);
                                ClassCopier.Instance.Copy(ri1, oriri);
                                db.Entry(oriri).State = EntityState.Modified;
                                if (ri1.Routings.Count > 0)
                                {
                                    var list2 = ri1.Routings;
                                    foreach (var ri2 in list2)
                                    {
                                        if (ri2.No == 0)
                                        {
                                            oriri.Routings.Add(ri2);
                                            db.Entry(ri2).State = EntityState.Added;
                                        }
                                        else
                                        {
                                            var oriri2 = oriri.Routings.Find(y => y.No == ri2.No);
                                            db.RoutingItems.Attach(oriri2);
                                            db.Entry(oriri2).CurrentValues.SetValues(ri2);
                                            db.Entry(oriri2).State = EntityState.Modified;
                                        }
                                    }
                                }
                                if (ri1.GetType() == typeof(NewContractExtLineRoutingInfo))
                                {
                                    var oriri1 = oriri as NewContractExtLineRoutingInfo;
                                    var ri2 = ri1 as NewContractExtLineRoutingInfo;
                                    if (ri2 != null && ri2.Contract != null)
                                    {
                                        if (oriri1 != null)
                                        {
                                            var ct = ri2.Contract;
                                            if (ct.No == 0)
                                            {
                                                oriri1.Contract = ct;
                                                db.Entry(ct).State = EntityState.Added;
                                            }
                                            else
                                            {
                                                db.Entry(oriri1.Contract).CurrentValues.SetValues(ct);
                                                db.Entry(oriri1.Contract).State = EntityState.Modified;
                                            }
                                        }
                                    }
                                }
                                else if (ri1.GetType() == typeof(NewContractIpPhoneRoutingInfo))
                                {
                                    var oriri2 = oriri as NewContractIpPhoneRoutingInfo;
                                    var ri3 = ri1 as NewContractIpPhoneRoutingInfo;
                                    if (ri3 != null && ri3.Contract != null)
                                    {
                                        if (oriri2 != null)
                                        {
                                            var ct = ri3.Contract;
                                            if (ct.No == 0)
                                            {
                                                oriri2.Contract = ct;
                                                db.Entry(ct).State = EntityState.Added;
                                            }
                                            else
                                            {
                                                db.Entry(oriri2.Contract).CurrentValues.SetValues(ct);
                                                db.Entry(oriri2.Contract).State = EntityState.Modified;
                                            }
                                        }
                                    }
                                }
                                else if (ri1.GetType() == typeof(NewContractLaptopRoutingInfo))
                                {
                                    var oriri3 = oriri as NewContractLaptopRoutingInfo;
                                    var ri4 = ri1 as NewContractLaptopRoutingInfo;
                                    if (ri4 != null && ri4.Contract != null)
                                    {
                                        if (oriri3 != null)
                                        {
                                            var ct = ri4.Contract;
                                            if (ct.No == 0)
                                            {
                                                oriri3.Contract = ct;
                                                db.Entry(ct).State = EntityState.Added;
                                            }
                                            else
                                            {
                                                db.Entry(oriri3.Contract).CurrentValues.SetValues(ct);
                                                db.Entry(oriri3.Contract).State = EntityState.Modified;
                                            }
                                        }
                                    }
                                }
                                else if (ri1.GetType() == typeof(NewContractSoftwareRoutingInfo))
                                {
                                    var oriri4 = oriri as NewContractSoftwareRoutingInfo;
                                    var ri5 = ri1 as NewContractSoftwareRoutingInfo;
                                    if (ri5 != null && ri5.Contract != null)
                                    {
                                        if (oriri4 != null)
                                        {
                                            var ct = ri5.Contract;
                                            if (ct.No == 0)
                                            {
                                                oriri4.Contract = ct;
                                                db.Entry(ct).State = EntityState.Added;
                                            }
                                            else
                                            {
                                                db.Entry(oriri4.Contract).CurrentValues.SetValues(ct);
                                                db.Entry(oriri4.Contract).State = EntityState.Modified;
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
                if (o.Routings.Count > 0)
                {
                    var list1 = o.Routings;
                    foreach (var ri1 in list1)
                    {
                        db.Entry(ri1).State = EntityState.Deleted;
                        if (ri1.GetType() == typeof(NewContractExtLineRoutingInfo))
                        {
                            var ri2 = ri1 as NewContractExtLineRoutingInfo;
                            if (ri2 != null && ri2.Contract != null)
                            {
                                var ct = ri2.Contract;
                                db.Entry(ct).State = EntityState.Deleted;
                            }
                        }
                        else if (ri1.GetType() == typeof(NewContractIpPhoneRoutingInfo))
                        {
                            var ri2 = ri1 as NewContractIpPhoneRoutingInfo;
                            if (ri2 != null && ri2.Contract != null)
                            {
                                var ct = ri2.Contract;
                                db.Entry(ct).State = EntityState.Deleted;
                            }
                        }
                        else if (ri1.GetType() == typeof(NewContractLaptopRoutingInfo))
                        {
                            var ri2 = ri1 as NewContractLaptopRoutingInfo;
                            if (ri2 != null && ri2.Contract != null)
                            {
                                var ct = ri2.Contract;
                                db.Entry(ct).State = EntityState.Deleted;
                            }
                        }
                        else if (ri1.GetType() == typeof(NewContractSoftwareRoutingInfo))
                        {
                            var ri2 = ri1 as NewContractSoftwareRoutingInfo;
                            if (ri2 != null && ri2.Contract != null)
                            {
                                var ct = ri2.Contract;
                                db.Entry(ct).State = EntityState.Deleted;
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
                        if (ri1.GetType() == typeof(NewContractExtLineRoutingInfo))
                        {
                            var ri2 = ri1 as NewContractExtLineRoutingInfo;
                            if (ri2 != null && ri2.Contract != null)
                            {
                                var ct = ri2.Contract;
                                db.Entry(ct).State = EntityState.Deleted;
                            }
                        }
                        else if (ri1.GetType() == typeof(NewContractIpPhoneRoutingInfo))
                        {
                            var ri2 = ri1 as NewContractIpPhoneRoutingInfo;
                            if (ri2 != null && ri2.Contract != null)
                            {
                                var ct = ri2.Contract;
                                db.Entry(ct).State = EntityState.Deleted;
                            }
                        }
                        else if (ri1.GetType() == typeof(NewContractLaptopRoutingInfo))
                        {
                            var ri2 = ri1 as NewContractLaptopRoutingInfo;
                            if (ri2 != null && ri2.Contract != null)
                            {
                                var ct = ri2.Contract;
                                db.Entry(ct).State = EntityState.Deleted;
                            }
                        }
                        else if (ri1.GetType() == typeof(NewContractSoftwareRoutingInfo))
                        {
                            var ri2 = ri1 as NewContractSoftwareRoutingInfo;
                            if (ri2 != null && ri2.Contract != null)
                            {
                                var ct = ri2.Contract;
                                db.Entry(ct).State = EntityState.Deleted;
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
