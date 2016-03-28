using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Misi.DAL.Billing.DaoUtil;
using Misi.DAL.Billing.Model.SAP;
using Misi.Service.Billing.Model.SAP;
using Misi.Service.Billing.Object;
using System.Threading;

namespace Misi.Service.Billing.Handler.SAP
{
    public class QueryInvoiceBillingsAllHandler : InvoiceProformaBaseHandler
    {
        public override void SetHandlerArguments(string user, object[] args = null)
        {
            Username = user;
        }

        public override SAPResponse ExecuteQuery()
        {
            var resp = new InvoiceProformaItemsDTO();
            var isFromDB = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_FROM_DB) is bool && (bool)InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_FROM_DB);
            #region "QUERY FROM DB"
            if (isFromDB)
            {
                System.Diagnostics.Debug.WriteLine("<QUERY_TOTAL_RECORDS FROM = 'DB'>");
                var rawHead = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_PROFORMA_HEADER) as InvoiceProformaHeaderDto;
                InMemoryCache.Instance.ClearCached(Username + Suffix.CACHED_VERSION);
                using (var dao = new BillingDbContext())
                {
                    var sql0 = from o in dao.InvoiceProformaHeaders.Where(o => o.No == rawHead.No) select o;
                    var count = sql0.Count();
                    if (count > 0)
                    {
                        var cachedVersion = DateTime.Now.Ticks;
                        InMemoryCache.Instance.Cache(Username + Suffix.CACHED_VERSION, cachedVersion);

                        // Load all by selected version
                        var sql2 = from o in dao.InvoiceProformaHeaders.Where(o => o.No == rawHead.No).Include(o => o.Billings) select o;
                        var verHead = sql2.AsParallel().FirstOrDefault();
                        if (verHead != null && verHead.Version == 0)
                        {
                            var list1 = verHead.Billings;
                            InMemoryCache.Instance.Cache(Username + Suffix.QUERIED_PROFORMA_TOTAL_RECS, list1.Count);
                            var list2 = SAPHandlerHelper.Instance.FromListOfBillingModels2DTOs(list1, cachedVersion);
                            resp.Items = list2.ToList();
                        }
                        else if (verHead != null)
                        {
                            // Load all version 0
                            System.Diagnostics.Debug.WriteLine("<ROWS_QUERY VERSION = '0'/>");
                            var sql1 =
                                from o in dao.InvoiceProformaHeaders.Where(o => o.BillingNo == verHead.BillingNo &&
                                                                                o.BillingBlock == verHead.BillingBlock &&
                                                                                o.ProformaFlag == verHead.ProformaFlag &&
                                                                                o.ReasonForRejection ==
                                                                                verHead.ReasonForRejection &&
                                                                                o.Version == 0).Include(o => o.Billings)
                                select o;
                            var zeroHeader = sql1.FirstOrDefault();
                            if (zeroHeader == null) return null;
                            var list1 = zeroHeader.Billings;

                            System.Diagnostics.Debug.WriteLine("<ROWS_QUERY COMBINING'/>");
                            var list2 = verHead.Billings;
                            foreach (var upb in list2)
                            {
                                InvoiceProformaBilling upb1 = upb;
                                var bil = from o in list1.Where(o => o.VBAK_VBELN == upb1.VBAK_VBELN &&
                                                                     o.VBAK_POSNR == upb1.VBAK_POSNR)
                                          select o;
                                var dest = bil.FirstOrDefault();
                                if (dest == null)
                                {
                                    list1.Add(upb);
                                }
                                else
                                {
                                    SAPHandlerHelper.Instance.CopyBillingValues(upb, dest);
                                }
                            }

                            var list3 = SAPHandlerHelper.Instance.FromListOfBillingModels2DTOs(list1, cachedVersion);
                            //var list4 = list3 as InvoiceProformaItemDTO[] ?? list3.ToArray();
                            InMemoryCache.Instance.Cache(Username + Suffix.QUERIED_PROFORMA_TOTAL_RECS, list3.Count());
                            resp.Items = list3;
                        }
                        else
                        {
                            throw new FaultException("Selected header is null!");
                        }
                    }
                    else
                    {
                        throw new FaultException("Selected header is null!");
                    }
                }
            }
            #endregion
            #region "QUERY FROM SAP"
            else
            {
                InMemoryCache.Instance.ClearCached(Username + Suffix.CACHED_VERSION);
                System.Diagnostics.Debug.WriteLine("<QUERY_TOTAL_RECORDS FROM = 'SAP'>");
                var cred = ParseCredential(Username);
                var dest = SAPConnectionFactory.Instance.GetRfcDestination(cred);
                if (dest != null)
                {
                    var cachedVersion = DateTime.Now.Ticks;
                    InMemoryCache.Instance.Cache(Username + Suffix.CACHED_VERSION, cachedVersion);
                    var totalBills = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_PROFORMA_TOTAL_RECS) is int
                        ? (int)InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_PROFORMA_TOTAL_RECS)
                        : 0;
                    var sessionId = WaitForSessionId();
                    var repo = dest.Repository;

                    var func = repo.CreateFunction("ZBAPI_PROFORMA_PAGING");
                    func.SetValue("SESSIONID", sessionId);
                    func.SetValue("STARTROW", 0);
                    func.SetValue("ENDROW", totalBills);
                    func.Invoke(dest);
                    var proformaTbl = func.GetTable("PROFORMA");

                    var ret = proformaTbl.Select(e => new InvoiceProformaItemDTO
                    {
                        VBELN = e.GetString("VBELN"),
                        POSNR = e.GetString("POSNR"),
                        AUBEL = e.GetString("AUBEL"),
                        AUPOS = e.GetString("AUPOS"),
                        MATKL = e.GetString("MATKL"),
                        ITEM_TYPE = e.GetString("ITEM_TYPE"),
                        CATEGORY = e.GetString("CATEGORY"),
                        SUBCATEGORY = e.GetString("SUBCATEGORY"),
                        WGBEZ = e.GetString("WGBEZ"),
                        MATNR = e.GetString("MATNR"),
                        ARKTX = e.GetString("ARKTX"),
                        FKIMG = e.GetString("FKIMG"),
                        VRKME = e.GetString("VRKME"),
                        TOTAL1 = e.GetString("TOTAL1"),
                        TOTAL2 = e.GetString("TOTAL2"),
                        TOTAL3 = e.GetString("TOTAL3"),
                        TOTAL4 = e.GetString("TOTAL4"),
                        TOTAL5 = e.GetString("TOTAL5"),
                        VBAK_VBELN = e.GetString("VBAK_VBELN"),
                        VBAK_POSNR = e.GetString("VBAK_POSNR"),
                        VBAK_ZMENG = e.GetString("VBAK_ZMENG"),
                        VBAK_ZIEME = e.GetString("VBAK_ZIEME"),
                        VBAK_KONDM = e.GetString("VBAK_KONDM"),
                        VBAK_VTEXT1 = e.GetString("VBAK_VTEXT1"),
                        VBAK_BSTKD_E = e.GetString("VBAK_BSTKD_E"),
                        VBAK_EQUNR = e.GetString("VBAK_EQUNR"),
                        VBAK_TYPBZ = e.GetString("VBAK_TYPBZ"),
                        VBAK_MAPAR = e.GetString("VBAK_MAPAR"),
                        VBAK_SERGE = e.GetString("VBAK_SERGE"),
                        VBAK_LOCATION = e.GetString("VBAK_LOCATION"),
                        VBAK_PERNR1 = e.GetString("VBAK_PERNR1"),
                        VBAK_PERNR2 = e.GetString("VBAK_PERNR2"),
                        VBAK_EMPNAME = e.GetString("VBAK_EMPNAME"),
                        VBAK_PERSAREA = e.GetString("VBAK_PERSAREA"),
                        VBAK_PERSAREA_T = e.GetString("VBAK_PERSAREA_T"),
                        VBAK_SUBAREA = e.GetString("VBAK_SUBAREA"),
                        VBAK_SUBAREA_T = e.GetString("VBAK_SUBAREA_T"),
                        VBAK_ORGUNIT = e.GetString("VBAK_ORGUNIT"),
                        VBAK_ORGUNIT_T = e.GetString("VBAK_ORGUNIT_T"),
                        VBAK_OUCODE = e.GetString("VBAK_OUCODE"),
                        VBAK_KOSTL = e.GetString("VBAK_KOSTL"),
                        VBAK_WAERK = e.GetString("VBAK_WAERK"),
                        VBAK_NETWR = e.GetString("VBAK_NETWR"),
                        VBAK_BEDAT = e.GetString("VBAK_BEDAT"),
                        VBAK_ENDAT = e.GetString("VBAK_ENDAT"),
                        VBAK_ABGRU_T = e.GetString("VBAK_ABGRU_T"),
                        VBAK_PS_PSP_PNR = e.GetString("VBAK_PS_PSP_PNR"),
                        VBAK_PSTYV = e.GetString("VBAK_PSTYV"),
                        VBAK_KONDA = e.GetString("VBAK_KONDA"),
                        VBAK_VTEXT2 = e.GetString("VBAK_VTEXT2"),
                        VBAK_BSTKD = e.GetString("VBAK_BSTKD"),
                        VBAK_BSTDK = e.GetString("VBAK_BSTDK"),
                        VBAK_NAME = e.GetString("VBAK_NAME"),
                        VBAK_APPROVAL = e.GetString("VBAK_APPROVAL"),
                        VBAK_NOTE = e.GetString("VBAK_NOTE"),
                        VBAK_ADDRESS = e.GetString("VBAK_ADDRESS"),
                        VBAK_FAKSK_T = e.GetString("VBAK_FAKSK_T"),
                        VBAK_EQ_YEAR = e.GetString("VBAK_EQ_YEAR"),
                        LogMessage = "", //NOTO
                        CachedVersion = cachedVersion,
                        NO = e.GetString("VBAK_VBELN") + "#" + e.GetString("VBAK_POSNR"),
                    });

                    Task.Run(() => PersistsToCache(ret));
                    resp.Items = ret.ToList();

                   // InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_SAP_SESSIONID);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("</QUERY_TOTAL_RECORDS>");
                    throw new FaultException("RfcDestination is null!");
                }
            }
            #endregion
            return resp;
        }

        private int? WaitForSessionId() 
        {
            int? sessionId = null;
            try
            {
                do
                {
                    sessionId = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_SAP_SESSIONID) as int?;
                   
                } while (sessionId == null);
            }
            catch (Exception ex) 
            {
                throw ex;
            }

            return sessionId;
        }

        private static async void PersistsToCache(IEnumerable<InvoiceProformaItemDTO> list)
        {
            System.Diagnostics.Debug.WriteLine("<WRITING_TO_CACHE>");
            var recsPerWrite = Properties.Settings.Default.RecordsPerWrite;
            var list1 = list.ToArray();
            var list2 = new List<InvoiceProformaItemDTO>();
            using (var dao = new BillingDbContext())
            {
                dao.Configuration.AutoDetectChangesEnabled = false;
                for (var i = 0; i < list1.Count(); i++)
                {
                    list2.Add(list1[i]);
                    if (i % recsPerWrite == 0 && i != 0)
                    {

                        dao.CachedBillings.AddRange(list2);
                        dao.SaveChanges();
                        list2 = new List<InvoiceProformaItemDTO>();
                    }
                }
                dao.CachedBillings.AddRange(list2);
                dao.SaveChanges();
                dao.Configuration.AutoDetectChangesEnabled = true;
            }
            System.Diagnostics.Debug.WriteLine("</WRITING_TO_CACHE>");
            await Task.Delay(2000);
        }
    }
}