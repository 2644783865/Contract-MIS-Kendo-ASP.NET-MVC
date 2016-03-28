using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Misi.DAL.Billing.DaoUtil;
using Misi.DAL.Billing.Model.SAP;
using Misi.Service.Billing.Model.SAP;
using Misi.Service.Billing.Object;

namespace Misi.Service.Billing.Handler.SAP
{
    public class InvoiceProformaBaseHandler : SAPRequestHandlerBase
    {
        public class Suffix
        {
            public const string UPDATED_BILLINGS = "_updated_billings";
            public const string QUERIED_FROM_DB = "_queried_from_db";
            public const string QUERIED_VERSION_FROM_DB = "_queried_version_from_db";
            public const string REQUEST_HEADER = "_request_header";
            public const string CACHED_VERSION = "_cached_version";
            public const string BILLINGS_TO_UPDATE = "_billings_to_update";
            public const string QUERIED_PROFORMA_TOTAL_RECS = "_queried_proforma_total_recs";
            public const string QUERIED_CURRENT_PAGE = "_queried_current_page";
            public const string QUERIED_SAP_SESSIONID = "_queried_sap_sessionid";
            public const string QUERIED_PROFORMA_HEADER = "_queried_proforma_header";
            public const string QUERIED_BILLING_NUMBERS = "_queried_billing_numbers";
            public const string CACHED_BILLINGS_BUFFER = "_cached_billings_buffer";
            public const string CURRENT_PAGE = "_current_page";
            public const string CACHED_READY = "_cached_ready";
            public const string STACK_COUNTER = "_stack_counter";
            public const string LAST_OFFSET = "_last_offset";
            public const string LAST_LIMIT = "_last_limit";
            public const string PERFORMED_INITIAL_SAVE = "_performed_initial_save";
        }

        protected List<InvoiceProformaItemDTO> GetCachedBillings(long cachedVersion)
        {
            using (var dao = new BillingDbContext())
            {
                System.Diagnostics.Debug.WriteLine("<READ_FROM_CACHE/>");
                var sql = from o in dao.CachedBillings where o.CachedVersion == cachedVersion select o;
                var list1 = sql.AsParallel().ToList();
                return list1;
            }
        }

        protected int GetTotalCached(long cachedVersion)
        {
            using (var dao = new BillingDbContext())
            {
                return (from o in dao.CachedBillings where o.CachedVersion == cachedVersion select o).Count();
                //return sql.AsParallel().ToList().Count;
            }
        }

        protected int CountZeroVersion(RunInvoiceHeaderDTO head, BillingDbContext dao)
        {
            var sql = from o in dao.InvoiceProformaHeaders.Where(o => o.BillingBlock == head.BillingDocsCriteria &&
                                                                          o.ReasonForRejection ==
                                                                          head.ReasonForRejection &&
                                                                          o.ProformaFlag == head.ProformaFlag &&
                                                                          o.BillingNo == head.BillingNo &&
                                                                          o.SoldToParty == head.SoldToParty &&
                                                                          o.Version == 0)
                      select o;
            return sql.Count();
        }

        private const string createZero = "BEGIN TRAN DELETE FROM [dbo].[InvoiceProformaBilling]  where [InvoiceProformaHeader_No] = @no INSERT INTO [dbo].[InvoiceProformaBilling] ([cached_version],[VBELN] ,[POSNR] ,[AUBEL] ,[AUPOS] ,[MATKL] ,[ITEM_TYPE] ,[CATEGORY] ,[SUBCATEGORY] ,[WGBEZ] ,[MATNR] ,[ARKTX] ,[FKIMG] ,[VRKME] ,[TOTAL1] ,[TOTAL2] ,[TOTAL3] ,[TOTAL4] ,[TOTAL5] ,[VBAK_VBELN] ,[VBAK_POSNR] ,[VBAK_ZMENG] ,[VBAK_ZIEME] ,[VBAK_KONDM] ,[VBAK_VTEXT1] ,[VBAK_BSTKD_E] ,[VBAK_EQUNR] ,[VBAK_TYPBZ] ,[VBAK_MAPAR] ,[VBAK_SERGE] ,[VBAK_LOCATION] ,[VBAK_PERNR1] ,[VBAK_PERNR2] ,[VBAK_EMPNAME] ,[VBAK_PERSAREA] ,[VBAK_PERSAREA_T] ,[VBAK_SUBAREA] ,[VBAK_SUBAREA_T] ,[VBAK_ORGUNIT] ,[VBAK_ORGUNIT_T] ,[VBAK_OUCODE] ,[VBAK_KOSTL] ,[VBAK_WAERK] ,[VBAK_NETWR] ,[VBAK_BEDAT] ,[VBAK_ENDAT] ,[VBAK_ABGRU_T] ,[VBAK_PS_PSP_PNR] ,[VBAK_PSTYV] ,[VBAK_KONDA] ,[VBAK_VTEXT2] ,[VBAK_BSTKD] ,[VBAK_BSTDK] ,[VBAK_NAME] ,[VBAK_APPROVAL] ,[VBAK_NOTE] ,[VBAK_ADDRESS] ,[VBAK_FAKSK_T] ,[VBAK_EQ_YEAR] , [LogMessage] ," +
            "[InvoiceProformaHeader_No])SELECT 0 ,[VBELN] ,[POSNR] ,[AUBEL] ,[AUPOS] ,[MATKL] ,[ITEM_TYPE] ,[CATEGORY] ,[SUBCATEGORY] ,[WGBEZ] ,[MATNR] ,[ARKTX] ,[FKIMG] ,[VRKME] ,[TOTAL1] ,[TOTAL2] ,[TOTAL3] ,[TOTAL4] ,[TOTAL5] ,[VBAK_VBELN] ,[VBAK_POSNR] ,[VBAK_ZMENG] ,[VBAK_ZIEME] ,[VBAK_KONDM] ,[VBAK_VTEXT1] ,[VBAK_BSTKD_E] ,[VBAK_EQUNR] ,[VBAK_TYPBZ] ,[VBAK_MAPAR] ,[VBAK_SERGE] ,[VBAK_LOCATION] ,[VBAK_PERNR1] ,[VBAK_PERNR2] ,[VBAK_EMPNAME] ,[VBAK_PERSAREA] ,[VBAK_PERSAREA_T] ,[VBAK_SUBAREA] ,[VBAK_SUBAREA_T] ,[VBAK_ORGUNIT] ,[VBAK_ORGUNIT_T] ,[VBAK_OUCODE] ,[VBAK_KOSTL] ,[VBAK_WAERK] ,[VBAK_NETWR] ,[VBAK_BEDAT] ,[VBAK_ENDAT] ,[VBAK_ABGRU_T] ,[VBAK_PS_PSP_PNR] ,[VBAK_PSTYV] ,[VBAK_KONDA] ,[VBAK_VTEXT2] ,[VBAK_BSTKD] ,[VBAK_BSTDK] ,[VBAK_NAME] ,[VBAK_APPROVAL] ,[VBAK_NOTE] ,[VBAK_ADDRESS] ,[VBAK_FAKSK_T] ,[VBAK_EQ_YEAR],[LogMessage] ,@no  FROM [dbo].[InvoiceProformaItemDTO] where cached_version = @cachedVersion IF @@Error <>0 	BEGIN ROLLBACK TRANSACTION; END ELSE BEGIN COMMIT TRANSACTION; END";

        protected void CreateOrOverwriteZeroVersion(bool doOverride, BillingDbContext dao)
        {
            var header = InMemoryCache.Instance.GetCached(Username + Suffix.REQUEST_HEADER) as RunInvoiceHeaderDTO;
            var total = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_PROFORMA_TOTAL_RECS) is int ? (int)InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_PROFORMA_TOTAL_RECS) : 0;
            var cachedVersion = InMemoryCache.Instance.GetCached(Username + Suffix.CACHED_VERSION) is long ? (long)InMemoryCache.Instance.GetCached(Username + Suffix.CACHED_VERSION) : 0;

            
             if (GetTotalCached(cachedVersion) >= total)
             {
                 InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_FROM_DB);
                 InMemoryCache.Instance.Cache(Username + Suffix.QUERIED_FROM_DB, true);
                  InMemoryCache.Instance.Cache(Username + Suffix.QUERIED_VERSION_FROM_DB, 0);

                var rawHeader = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_PROFORMA_HEADER) as InvoiceProformaHeaderDto;
                var cachedBills = GetCachedBillings(cachedVersion);
                if (CountZeroVersion(header, dao) <= 0 && header != null && rawHeader != null)
                {
                    var newZeroHeaderVersion = new InvoiceProformaHeader
                    {
                        Version = 0,
                        SoldToParty = header.SoldToParty,
                        BillingBlock = header.BillingDocsCriteria,
                        ReasonForRejection = header.ReasonForRejection,
                        ProformaFlag = header.ProformaFlag,
                        BillingNo = header.BillingNo,
                        Created = DateTime.Now,
                        StartDate = header.BillingDateFrom,
                        EndDate = header.BillingDateTo,
                        Draft = true,
                        CITY1 = rawHeader.CITY1,
                        ERDAT = rawHeader.ERDAT,
                        ERNAM = rawHeader.ERNAM,
                        ERZET = rawHeader.ERZET,
                        FKDAT = rawHeader.FKDAT,
                        FPAJAK_NO = rawHeader.FPAJAK_NO,
                        HTOTAL1 = rawHeader.HTOTAL1,
                        HTOTAL2 = rawHeader.HTOTAL2,
                        HTOTAL3 = rawHeader.HTOTAL3,
                        HTOTAL4 = rawHeader.HTOTAL4,
                        HTOTAL5 = rawHeader.HTOTAL5,
                        KUNRG = rawHeader.KUNRG,
                        KURRF = rawHeader.KURRF,
                        NAME1 = rawHeader.NAME1,
                        NAME2 = rawHeader.NAME2,
                        NAME3 = rawHeader.NAME3,
                        NAME4 = rawHeader.NAME4,
                        POST_CODE1 = rawHeader.POST_CODE1,
                        STCEG = rawHeader.STCEG,
                        STREET = rawHeader.STREET,
                        TDLINE = rawHeader.TDLINE,
                        TEXT1 = rawHeader.TEXT1,
                        VBELN = rawHeader.VBELN,
                        VTEXT = rawHeader.VTEXT,
                        WAERK = rawHeader.WAERK,
                        ZTERM = rawHeader.ZTERM,
                    };
                    // Add new header
                    dao.InvoiceProformaHeaders.Add(newZeroHeaderVersion);
                    dao.SaveChanges();

                    // Add newly retrieved billings
                    var createZeroSql = createZero.Replace("@no", newZeroHeaderVersion.No + "").Replace("@cachedVersion", cachedVersion + "");
                    dao.Database.ExecuteSqlCommand(createZeroSql);
                }
                else
                {
                    if (!doOverride) return;
                    if (cachedBills.Count <= 0 || rawHeader == null || header == null) return;
                    var sql1 =
                        from o in
                            dao.InvoiceProformaHeaders.Where(
                                o => o.BillingBlock == header.BillingDocsCriteria &&
                                     o.ReasonForRejection ==
                                     header.ReasonForRejection &&
                                     o.ProformaFlag == header.ProformaFlag &&
                                     o.BillingNo == header.BillingNo &&
                                     o.SoldToParty == header.SoldToParty)
                        select o;
                    InvoiceProformaHeader oldZeroHeaderVersion = sql1.FirstOrDefault();
                    if (oldZeroHeaderVersion != null)
                    {
                        // Deletes old billings
                        dao.Database.ExecuteSqlCommand("DELETE FROM dbo.InvoiceProformaBilling WHERE InvoiceProformaHeader_No = " + oldZeroHeaderVersion.No);
                        var createZeroSql = createZero.Replace("@no", oldZeroHeaderVersion.No + "").Replace("@cachedVersion", cachedVersion + "");
                        // Add newly retrieved billings
                        dao.Database.ExecuteSqlCommand(createZeroSql);
                    }
                }
            }
            else
            {
                Thread.Sleep(2000);
                CreateOrOverwriteZeroVersion(doOverride, dao);
            }
        }

    }
}