using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Misi.Common.Lib.Util;
using Misi.DAL.Billing.DaoUtil;
using Misi.DAL.Billing.Model.SAP;
using Misi.Service.Billing.Model.SAP;
using Misi.Service.Billing.Object;

namespace Misi.Service.Billing.Handler.SAP
{

    public class SaveBillingsUpdatesHandler : InvoiceProformaBaseHandler
    {
        public override void SetHandlerArguments(string user, object[] args = null)
        {
            Username = user;
        }

        public override SAPResponse ExecuteCommand()
        {
            var resp = new NumberResult();
            var cachedVersion = (long)InMemoryCache.Instance.GetCached(Username + Suffix.CACHED_VERSION);
            var toUpdateList = InMemoryCache.Instance.GetCached(Username + Suffix.BILLINGS_TO_UPDATE) as List<BillingToUpdate>;
            #region "CREATING NEW OR UPDATES HEADER"
            if (toUpdateList != null && toUpdateList.Count > 0)
            {
                System.Diagnostics.Debug.WriteLine("=========> CREATE OR UPDATES THE OLD OR NEW VERSION ON DATA LOADED FROM SAP OR DB....");

                var rawHeader = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_PROFORMA_HEADER) as InvoiceProformaHeaderDto;
                var header = InMemoryCache.Instance.GetCached(Username + Suffix.REQUEST_HEADER) as RunInvoiceHeaderDTO;
                if (rawHeader != null && header != null)
                {
                    #region "CREATE OR UPDATES DATA LOADED FROM DB"
                    var isFromDB = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_FROM_DB) is bool && (bool)InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_FROM_DB);
                    if (isFromDB)
                    {
                        #region "UPDATING 0 VERSION"
                        var vrFromDb = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_VERSION_FROM_DB) is int ? (int)InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_VERSION_FROM_DB) : 0;
                        if (vrFromDb == 0)
                        {
                            System.Diagnostics.Debug.WriteLine("IS FROM DB = " + true + " - VER LOADED = " + vrFromDb);
                            using (var dao = new BillingDbContext())
                            {
                                System.Diagnostics.Debug.WriteLine("LOADED VER FROM DB = " + vrFromDb);
                                var loadedVersion = vrFromDb;
                                // Query the version which loaded
                                var sql1 = from o in dao.InvoiceProformaHeaders.Where(o => o.BillingNo == header.BillingNo &&
                                                                                           o.ReasonForRejection ==
                                                                                           header.ReasonForRejection &&
                                                                                           o.BillingBlock ==
                                                                                           header.BillingDocsCriteria &&
                                                                                           o.Version == loadedVersion)
                                           select o;
                                var loadedHeaderVersion = sql1.FirstOrDefault();

                                // Query the latest version from DB
                                var sql2 = from o in dao.InvoiceProformaHeaders.Where(o => o.BillingNo == header.BillingNo &&
                                                                                           o.ReasonForRejection ==
                                                                                           header.ReasonForRejection &&
                                                                                           o.BillingBlock ==
                                                                                           header.BillingDocsCriteria &&
                                                                                           o.Version > 0).OrderBy(o => o.Version)
                                           select o;

                                var latestHeaderVersion = 0;
                                var count = sql2.Count();
                                if (count > 0)
                                    latestHeaderVersion = sql2.ToArray()[count - 1].Version;

                                var newHeaderVersion = new InvoiceProformaHeader
                                {
                                    BillingNo = header.BillingNo,
                                    SoldToParty = header.SoldToParty,
                                    StartDate = header.BillingDateFrom,
                                    EndDate = header.BillingDateTo,
                                    BillingBlock = header.BillingDocsCriteria,
                                    ReasonForRejection = header.ReasonForRejection,
                                    ProformaFlag = header.ProformaFlag,
                                    Created = DateTime.Now,
                                    Version = latestHeaderVersion + 1,
                                    Draft = true
                                };
                                ClassCopier.Instance.Copy(rawHeader, newHeaderVersion);
                                ClassCopier.Instance.Copy(loadedHeaderVersion, newHeaderVersion);
                                // Add newly updated billings to newly version
                                foreach (var b2u in toUpdateList)
                                {
                                    var u = b2u;
                                    var VBELN = u.No.Split('#')[0];
                                    var POSNR = u.No.Split('#')[1];
                                    var getCachedBillSql = from o in dao.InvoiceProformaBillings.Where(o => o.VBAK_VBELN == VBELN && o.VBAK_POSNR == POSNR && o.CachedVersion == 0).OrderByDescending(o => o.No) select o;
                                    var sbil = getCachedBillSql.FirstOrDefault();
                                    if (sbil == null) continue;
                                    // Check if content changed
                                    if (sbil.VBAK_ABGRU_T != b2u.Content)
                                    {
                                        var upbi = new InvoiceProformaBilling();
                                        SAPHandlerHelper.Instance.CopyBillingValues(sbil, upbi);
                                        upbi.VBAK_ABGRU_T = b2u.Content;
                                        upbi.Remarks = b2u.Remarks;
                                        if (b2u.Content == Properties.Settings.Default.Unblock)
                                            upbi.VBAK_ABGRU_T = String.Empty;
                                        upbi.CachedVersion = cachedVersion;
                                        newHeaderVersion.Billings.Add(upbi);
                                    }
                                }
                                // Clear updated billings from cached
                                InMemoryCache.Instance.ClearCached(Username + Suffix.BILLINGS_TO_UPDATE);
                                // Persists new header version and all related billings to DB
                                dao.InvoiceProformaHeaders.Add(newHeaderVersion);
                                dao.SaveChanges();
                                resp.Value = int.Parse(newHeaderVersion.No.ToString(CultureInfo.InvariantCulture));
                            }
                        }
                        #endregion
                        #region "UPDATING ABOVE 0 VERSION"
                        else
                        {
                            using (var dao = new BillingDbContext())
                            {
                                System.Diagnostics.Debug.WriteLine("LOADED VER FROM DB = " + vrFromDb);
                                var loadedVersion = vrFromDb;
                                // Query the version which loaded
                                var sql1 = from o in dao.InvoiceProformaHeaders.Where(o => o.BillingNo == header.BillingNo &&
                                                                                           o.ReasonForRejection ==
                                                                                           header.ReasonForRejection &&
                                                                                           o.BillingBlock ==
                                                                                           header.BillingDocsCriteria &&
                                                                                           o.Version == loadedVersion)
                                    .Include(o => o.Billings)
                                           select o;
                                var loadedHeaderVersion = sql1.FirstOrDefault();

                                // Query the latest version from DB
                                var sql2 = from o in dao.InvoiceProformaHeaders.Where(o => o.BillingNo == header.BillingNo &&
                                                                                           o.ReasonForRejection ==
                                                                                           header.ReasonForRejection &&
                                                                                           o.BillingBlock ==
                                                                                           header.BillingDocsCriteria &&
                                                                                           o.Version > 0)
                                           select o;
                                var count = sql2.Count();
                                var latestHeaderVersion = sql2.ToArray()[count - 1];

                                System.Diagnostics.Debug.WriteLine("=========> CREATE NEW HEADER VERSION FOR UPDATED BILLINGS");

                                // Check if the cached version of old header version's billing similar to current
                                // cached version
                                System.Diagnostics.Debug.WriteLine("=========> CREATE NEW HEADER VERSION FOR UPDATED BILLINGS");
                                // If queried billing cache version != current cachedVersion, create new header
                                var newHeaderVersion = new InvoiceProformaHeader
                                {
                                    BillingNo = header.BillingNo,
                                    SoldToParty = header.SoldToParty,
                                    StartDate = header.BillingDateFrom,
                                    EndDate = header.BillingDateTo,
                                    BillingBlock = header.BillingDocsCriteria,
                                    ReasonForRejection = header.ReasonForRejection,
                                    ProformaFlag = header.ProformaFlag,
                                    Created = DateTime.Now,
                                    Version = latestHeaderVersion.Version + 1,
                                    Draft = true
                                };
                                ClassCopier.Instance.Copy(rawHeader, newHeaderVersion);
                                ClassCopier.Instance.Copy(loadedHeaderVersion, newHeaderVersion);

                                // Add newly updated billings to newly version
                                foreach (var b2u in toUpdateList)
                                {
                                    var u = b2u;
                                    var VBELN = u.No.Split('#')[0];
                                    var POSNR = u.No.Split('#')[1];
                                    var getCachedBillSql = from o in dao.InvoiceProformaBillings.Where(o => o.VBAK_VBELN == VBELN && o.VBAK_POSNR == POSNR && o.CachedVersion == 0).OrderByDescending(o => o.No) select o;
                                    var sbil = getCachedBillSql.FirstOrDefault();
                                    if (sbil == null) continue;
                                    // Check if content changed
                                    if (sbil.VBAK_ABGRU_T != b2u.Content)
                                    {
                                        var upbi = new InvoiceProformaBilling();
                                        SAPHandlerHelper.Instance.CopyBillingValues(sbil, upbi);
                                        upbi.VBAK_ABGRU_T = b2u.Content;
                                        upbi.Remarks = b2u.Remarks;
                                        if (b2u.Content == Properties.Settings.Default.Unblock)
                                            upbi.VBAK_ABGRU_T = String.Empty;
                                        upbi.CachedVersion = cachedVersion;
                                        newHeaderVersion.Billings.Add(upbi);
                                    }
                                }

                                // Add updated billings from previous version to current version
                                foreach (var bi in loadedHeaderVersion.Billings)
                                {
                                    InvoiceProformaBilling bi1 = bi;
                                    var chk =
                                        from o in
                                            newHeaderVersion.Billings.Where(
                                                o =>
                                                    o.VBAK_VBELN == bi1.VBAK_VBELN &&
                                                    o.VBAK_POSNR == bi1.VBAK_POSNR)
                                        select o;
                                    if (chk.Count() == 0)
                                    {
                                        var nbi = new InvoiceProformaBilling();
                                        SAPHandlerHelper.Instance.CopyBillingValues(bi, nbi);
                                        nbi.CachedVersion = cachedVersion;
                                        newHeaderVersion.Billings.Add(nbi);
                                    }
                                }

                                // Clear updated billings from cached
                                InMemoryCache.Instance.ClearCached(Username + Suffix.BILLINGS_TO_UPDATE);
                                // Persists new header version and all related billings to DB
                                dao.InvoiceProformaHeaders.Add(newHeaderVersion);
                                dao.SaveChanges();
                                resp.Value = int.Parse(newHeaderVersion.No.ToString(CultureInfo.InvariantCulture));
                                   
                            }
                        }
                        #endregion
                        System.Diagnostics.Debug.WriteLine("=========> FROM DB");
                    }
                    #endregion
                    #region "CREATE OR UPDATES DATA LOADED FROM SAP"
                    else
                    {
                        using (var dao = new BillingDbContext())
                        {
                            System.Diagnostics.Debug.WriteLine("=========> FROM SAP");
                            // Query any version above 0
                            var sql1 = from o in dao.InvoiceProformaHeaders.Where(o => o.BillingNo == header.BillingNo &&
                                                                                       o.ReasonForRejection ==
                                                                                       header.ReasonForRejection &&
                                                                                       o.BillingBlock ==
                                                                                       header.BillingDocsCriteria &&
                                                                                       o.Version > 0)
                                       select o;

                            var count = sql1.Count();
                            if (count > 0)
                            {
                                // If there is an older version which is above 0 get latest header
                                System.Diagnostics.Debug.WriteLine("=========> OLD HEADER EXISTS");
                                var oldHeaderVersion = sql1.ToArray()[count - 1];
                                #region "WORKING ON HEADER THAT HAS UPDATED BILLINGS"
                                var sample = 0;
                                // Check if the cached version of old header version's billing similar to current
                                // cached version
                                #region "CREATE NEW HEADER VERSION"
                                if (sample == 0)
                                {
                                    System.Diagnostics.Debug.WriteLine("=========> CREATE NEW HEADER VERSION FOR UPDATED BILLINGS");
                                    // If queried billing cache version != current cachedVersion, create new header
                                    var newHeaderVersion = new InvoiceProformaHeader
                                    {
                                        BillingNo = header.BillingNo,
                                        SoldToParty = header.SoldToParty,
                                        StartDate = header.BillingDateFrom,
                                        EndDate = header.BillingDateTo,
                                        BillingBlock = header.BillingDocsCriteria,
                                        ReasonForRejection = header.ReasonForRejection,
                                        ProformaFlag = header.ProformaFlag,
                                        Created = DateTime.Now,
                                        Version = oldHeaderVersion.Version + 1,
                                        Draft = true
                                    };
                                    ClassCopier.Instance.Copy(rawHeader, newHeaderVersion);
                                    ClassCopier.Instance.Copy(oldHeaderVersion, newHeaderVersion);

                                    // Add newly updated billings to newly version
                                    foreach (var b2u in toUpdateList)
                                    {
                                        var u = b2u;
                                        var VBELN = u.No.Split('#')[0];
                                        var POSNR = u.No.Split('#')[1];
                                        var getCachedBillSql = from o in dao.InvoiceProformaBillings.Where(o => o.VBAK_VBELN == VBELN && o.VBAK_POSNR == POSNR && o.CachedVersion == 0) select o;
                                        var sbil = getCachedBillSql.FirstOrDefault();
                                        if (sbil == null) continue;
                                        // Check if content changed
                                        if (sbil.VBAK_ABGRU_T != b2u.Content)
                                        {
                                            var upbi = new InvoiceProformaBilling();
                                            SAPHandlerHelper.Instance.CopyBillingValues(sbil, upbi);
                                            upbi.VBAK_ABGRU_T = b2u.Content;
                                            upbi.Remarks = b2u.Remarks;
                                            if (b2u.Content == Properties.Settings.Default.Unblock)
                                                upbi.VBAK_ABGRU_T = String.Empty;
                                            upbi.CachedVersion = cachedVersion;
                                            newHeaderVersion.Billings.Add(upbi);
                                        }
                                    }

                                    // Add updated billings from previous version to current version
                                    foreach (var bi in oldHeaderVersion.Billings)
                                    {
                                        InvoiceProformaBilling bi1 = bi;
                                        var chk =
                                            from o in
                                                newHeaderVersion.Billings.Where(
                                                    o =>
                                                        o.VBAK_VBELN == bi1.VBAK_VBELN &&
                                                        o.VBAK_POSNR == bi1.VBAK_POSNR)
                                            select o;
                                        if (chk.ToList().Count == 0)
                                        {
                                            var nbi = new InvoiceProformaBilling();
                                            SAPHandlerHelper.Instance.CopyBillingValues(bi, nbi);
                                            nbi.CachedVersion = cachedVersion;
                                            newHeaderVersion.Billings.Add(nbi);
                                        }
                                    }

                                    // Clear update billings list from cache
                                    InMemoryCache.Instance.ClearCached(Username + Suffix.BILLINGS_TO_UPDATE);
                                    // Persists new header version and all related billings to DB
                                    dao.InvoiceProformaHeaders.Add(newHeaderVersion);
                                    dao.SaveChanges();
                                    resp.Value = int.Parse(newHeaderVersion.No.ToString(CultureInfo.InvariantCulture));
                                }
                                #endregion
                                #region "UPDATE HEADER DATA"
                                else
                                {
                                    // If old header sample billing cached version equals to current cached version
                                    // add newly updated billings to old header version as add items
                                    System.Diagnostics.Debug.WriteLine("=========> UPDATE OLD HEADER WITH UPDATED BILLINGS");
                                    foreach (var b2u in toUpdateList)
                                    {
                                        var u = b2u;
                                        var VBELN = u.No.Split('#')[0];
                                        var POSNR = u.No.Split('#')[1];
                                        var getCachedBillSql = from o in dao.InvoiceProformaBillings.Where(o => o.VBAK_VBELN == VBELN && o.VBAK_POSNR == POSNR && o.CachedVersion == 0) select o;
                                        var sbil = getCachedBillSql.FirstOrDefault();
                                        if (sbil == null) continue;
                                        // Check if content changed
                                        if (sbil.VBAK_ABGRU_T != b2u.Content)
                                        {
                                            var upbi = new InvoiceProformaBilling();
                                            SAPHandlerHelper.Instance.CopyBillingValues(sbil, upbi);
                                            dao.Entry(upbi).State = EntityState.Added;
                                            upbi.CachedVersion = cachedVersion;
                                            upbi.VBAK_ABGRU_T = b2u.Content;
                                            upbi.Remarks = b2u.Remarks;
                                            if (b2u.Content == Properties.Settings.Default.Unblock)
                                                upbi.VBAK_ABGRU_T = String.Empty;
                                            oldHeaderVersion.Billings.Add(upbi);
                                        }
                                    }
                                    // Clear update billings list from cache
                                    InMemoryCache.Instance.ClearCached(Username + Suffix.BILLINGS_TO_UPDATE);
                                    // Persists old header version and all newly added updated billings to DB
                                    dao.Entry(oldHeaderVersion).State = EntityState.Modified;
                                    dao.SaveChanges();
                                    resp.Value = int.Parse(oldHeaderVersion.No.ToString(CultureInfo.InvariantCulture));
                                }
                                #endregion
                                
                            }
                            #endregion
                            #region "WORKING ON DATA THAT HAS NO VERSION ABOVE 0 IN DB"
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("=========> NO OLD HEADER ABOVE 0 EXISTS");
                                System.Diagnostics.Debug.WriteLine("=========> CREATE 1st HEADER VERSION WITH UPDATED BILLINGS");
                                // If there is no version above 0
                                var newHeaderVersion = new InvoiceProformaHeader
                                {
                                    BillingNo = header.BillingNo,
                                    SoldToParty = header.SoldToParty,
                                    StartDate = header.BillingDateFrom,
                                    EndDate = header.BillingDateTo,
                                    BillingBlock = header.BillingDocsCriteria,
                                    ReasonForRejection = header.ReasonForRejection,
                                    ProformaFlag = header.ProformaFlag,
                                    Created = DateTime.Now,
                                    Version = 1,
                                    Draft = true
                                };
                                ClassCopier.Instance.Copy(rawHeader, newHeaderVersion);
                                dao.InvoiceProformaHeaders.Add(newHeaderVersion);

                                dao.SaveChanges();
                                // Add newly updated billings to newly version
                                foreach (var b2u in toUpdateList)
                                {
                                    var u = b2u;
                                    var getCachedBillSql = from o in dao.CachedBillings.Where(o => o.NO == u.No) select o;
                                    var sbil = getCachedBillSql.FirstOrDefault();
                                    if (sbil == null) continue;
                                    // Check if content changed
                                    if (sbil.VBAK_ABGRU_T != b2u.Content)
                                    {
                                        var upbi = SAPHandlerHelper.Instance.FromBillingDTO2Model(sbil);
                                        upbi.CachedVersion = cachedVersion;
                                        upbi.VBAK_ABGRU_T = b2u.Content;
                                        upbi.Remarks = b2u.Remarks;
                                        if (b2u.Content == Properties.Settings.Default.Unblock)
                                            upbi.VBAK_ABGRU_T = String.Empty;
                                        newHeaderVersion.Billings.Add(upbi);
                                    }
                                }
                                dao.SaveChanges();

                                var isSaved = InMemoryCache.Instance.GetCached(Username + Suffix.PERFORMED_INITIAL_SAVE) is bool && (bool) InMemoryCache.Instance.GetCached(Username + Suffix.PERFORMED_INITIAL_SAVE);
                                if (isSaved == false)
                                {
                                    System.Diagnostics.Debug.WriteLine("<CREATE_ZERO_VERSION CALL = 'FROM SAVE BILLINGS UPDATES' />");
                                    CreateOrOverwriteZeroVersion(false, dao);
                                    InMemoryCache.Instance.ClearCached(Username + Suffix.PERFORMED_INITIAL_SAVE);
                                }
                               
                                // Clear update billings list from cache
                                InMemoryCache.Instance.ClearCached(Username + Suffix.BILLINGS_TO_UPDATE);
                                // Persists new header version and all related billings to DB
                                resp.Value = int.Parse(newHeaderVersion.No.ToString(CultureInfo.InvariantCulture));
                            }
                            #endregion
                        }
                    }

                    #endregion
                }

                InMemoryCache.Instance.ClearCached(Username + Suffix.BILLINGS_TO_UPDATE);
            }
            #endregion
            #region "CREATING OR UPDATING HEADER AS FINAL HEADER"
            else
            {
                System.Diagnostics.Debug.WriteLine("=========> CREATE FINAL VERSION....");
                using (var dao = new BillingDbContext())
                {
                    var rawHeader = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_PROFORMA_HEADER) as InvoiceProformaHeaderDto;
                    var header = InMemoryCache.Instance.GetCached(Username + Suffix.REQUEST_HEADER) as RunInvoiceHeaderDTO;
                    if (rawHeader != null && header != null)
                    {
                        var vrFromDb = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_VERSION_FROM_DB) is int ? (int)InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_VERSION_FROM_DB) : 0;
                        
                        // Query any version above 0
                        var sql1 = from o in dao.InvoiceProformaHeaders.Where(o => o.BillingNo == header.BillingNo &&
                                                                                   o.ReasonForRejection ==
                                                                                   header.ReasonForRejection &&
                                                                                   o.BillingBlock ==
                                                                                   header.BillingDocsCriteria &&
                                                                                   o.Version == vrFromDb &&
                                                                                   o.Version > 0)
                            .Include(o => o.Billings)
                                   select o;
                        var count = sql1.Count();
                        #region "UPDATES THE LATEST HEADER TO FINAL"
                        if (count > 0)
                        {
                            // If there is an older version which is above 0, get latest header
                            System.Diagnostics.Debug.WriteLine("=========> OLD HEADER EXISTS");
                            System.Diagnostics.Debug.WriteLine("=========> UPDATES OLD HEADER AS FINAL");
                            var oldHeaderVersion = sql1.ToArray()[count - 1];
                            if (oldHeaderVersion != null)
                            {
                                oldHeaderVersion.Draft = false;
                                dao.Entry(oldHeaderVersion).State = EntityState.Modified;
                                dao.SaveChanges();
                                resp.Value = int.Parse(oldHeaderVersion.No.ToString(CultureInfo.InvariantCulture));
                            }
                        }
                        #endregion
                        #region "CREATE A NEW FIRST VERSION AS FINAL"
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("=========> NO OLD HEADER EXISTS");
                            System.Diagnostics.Debug.WriteLine("=========> CREATE 1st HEADER VERSION AS FINAL");
                            // If there is no version above 0
                            var sql2 = from o in dao.InvoiceProformaHeaders.Where(o => o.BillingNo == header.BillingNo &&
                                                                                       o.ReasonForRejection ==
                                                                                       header.ReasonForRejection &&
                                                                                       o.BillingBlock ==
                                                                                       header.BillingDocsCriteria
                                                                                      ).OrderByDescending(o => o.Version)select o;
                            var latestHeaderVersion = sql2.ToArray()[0].Version;

                            var finalHeaderVersion = new InvoiceProformaHeader
                            {
                                BillingNo = header.BillingNo,
                                SoldToParty = header.SoldToParty,
                                StartDate = header.BillingDateFrom,
                                EndDate = header.BillingDateTo,
                                BillingBlock = header.BillingDocsCriteria,
                                ReasonForRejection = header.ReasonForRejection,
                                ProformaFlag = header.ProformaFlag,
                                Created = DateTime.Now,
                                Version = latestHeaderVersion + 1,
                                Draft = false
                            };
                            ClassCopier.Instance.Copy(rawHeader, finalHeaderVersion);
                            InMemoryCache.Instance.ClearCached(Username + Suffix.BILLINGS_TO_UPDATE);
                            // Persists new header version and all related billings to DB
                            dao.InvoiceProformaHeaders.Add(finalHeaderVersion);
                            dao.SaveChanges();

                            InMemoryCache.Instance.Cache(Username + Suffix.QUERIED_VERSION_FROM_DB, latestHeaderVersion + 1);
                            resp.Value = int.Parse(finalHeaderVersion.No.ToString(CultureInfo.InvariantCulture));
                        }
                        #endregion
                    }
                }
            }
            #endregion
            return resp;
        }
    }
}