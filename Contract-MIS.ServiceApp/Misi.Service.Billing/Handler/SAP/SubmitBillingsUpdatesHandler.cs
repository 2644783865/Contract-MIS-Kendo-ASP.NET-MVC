using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using Misi.Common.Lib.Util;
using Misi.DAL.Billing.DaoUtil;
using Misi.DAL.Billing.Model.SAP;
using Misi.Service.Billing.Model.SAP;
using Misi.Service.Billing.Object;

using SAP.Middleware.Connector;
using System.Diagnostics;

namespace Misi.Service.Billing.Handler.SAP
{
    public class SubmitBillingsUpdatesHandler : InvoiceProformaBaseHandler
    {
        public override void SetHandlerArguments(string user, object[] args = null)
        {
            Username = user;
        }

        public override SAPResponse ExecuteCommand()
        {
            try
            {
                InvoiceProformaBillingRunsDTO ret = new InvoiceProformaBillingRunsDTO();
                System.Diagnostics.Debug.WriteLine("=========> MASUK SUBMIT TO SAP BY HEADER....");
                using (var dao = new BillingDbContext())
                {
                    var rawHeader = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_PROFORMA_HEADER) as InvoiceProformaHeaderDto;
                    var header = InMemoryCache.Instance.GetCached(Username + Suffix.REQUEST_HEADER) as RunInvoiceHeaderDTO;
                    var vrFromDb = InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_VERSION_FROM_DB) is int ? (int)InMemoryCache.Instance.GetCached(Username + Suffix.QUERIED_VERSION_FROM_DB) : 0;

                    InMemoryCache.Instance.ClearCached(Username + Suffix.QUERIED_VERSION_FROM_DB);

                    var resp = new InvoiceProformaBillingRunsDTO();
                    const string FUNCTIONAL_BAPI = "ZBAPI_SALESORDER_CHANGE";
                    var sql2 = from o in dao.InvoiceProformaHeaders.Where(o =>
                        o.BillingNo == header.BillingNo &&
                        o.Version == vrFromDb && !o.Draft).OrderByDescending(o => o.Version).Include(o => o.Billings)
                               select o;
                    var count1 = sql2.ToList().Count();
                    var list2 = sql2.ToList();
                    resp.Items = list2.Select(h => new InvoiceProformaBillingRunDTO
                    {
                        Created = h.Created,
                        Version = h.Version,
                        No = (int)h.No,
                        SoldToParty = h.SoldToParty,
                        Draft = h.Draft
                    }).ToList();

                    ret = resp;
                    var reasonForRejection = new Dictionary<string, string>();
                    reasonForRejection["ASSIGNED BY THE SYSTEM (INTERNAL)"] = "00";
                    reasonForRejection["DELIVERY DATE TOO LATE"] = "01";
                    reasonForRejection["POOR QUALITY"] = "02";
                    reasonForRejection["TOO EXPENSIVE"] = "03";
                    reasonForRejection["COMPETITOR BETTER"] = "04";
                    reasonForRejection["GUARANTEE"] = "05";
                    reasonForRejection["UNREASONABLE REQUEST"] = "10";
                    reasonForRejection["CUST.TO RECEIVE REPLACEMENT"] = "11";
                    reasonForRejection["BILLING BLOCKED"] = "12";
                    reasonForRejection["DOUBLE INPUT"] = "13";
                    reasonForRejection["AVAILABILITY"] = "20";
                    reasonForRejection["COVERAGE"] = "21";
                    reasonForRejection["PRICE"] = "22";
                    reasonForRejection["RELATIONSHIP"] = "23";
                    reasonForRejection["STANDARDIZATON"] = "24";
                    reasonForRejection["PRODUCT SPECIFICATION"] = "25";
                    reasonForRejection["TERM OF PAYMENT"] = "26";
                    reasonForRejection["OTHERS"] = "27";
                    reasonForRejection["DON'T PRINT"] = "28";
                    reasonForRejection["TRANSACTION IS BEING BLOCK"] = "29";
                    reasonForRejection["DOCUMENT HELD"] = "30";
                    reasonForRejection["LOST SALES"] = "31";
                    reasonForRejection["ZPROGRAM DO NOT USE"] = "32";
                    reasonForRejection["TRANSACTION IS BEING CHECKED"] = "50";
                    reasonForRejection["EQUIPMENT REPLACEMENT"] = "60";
                    reasonForRejection["EQUIPMENT REJECTION"] = "61";
                    reasonForRejection["EXCESS HOURS"] = "63";
                    reasonForRejection["REVOKE USER APPLICATION"] = "65";
                    reasonForRejection["RETURNED IT DEVICE"] = "66";
                    reasonForRejection["REPLACEMENT IT DEVICE"] = "67";
                    reasonForRejection["REPAIR AND MAINTENANCE"] = "68";
                    reasonForRejection["UPGRADE IT DEVICE"] = "69";
                    reasonForRejection["COMPLETION OF CONTRACT"] = "70";
                    reasonForRejection["REJECT IN PROGRESS"] = "91";
                    reasonForRejection["PTTU SERVICE REJECTION"] = "99";
                    reasonForRejection["ADDITIONAL PARTS"] = "C1";
                    reasonForRejection["REPLACEMENT PARTS"] = "C2";
                    reasonForRejection["TRANSACTION TO BE DEAL"] = "C3";
                    reasonForRejection["SSB SERVICE REJECTION"] = "Z1";
                    reasonForRejection["TECHNICAL REASON"] = "Z2";
                    reasonForRejection["BILLING BY DEBIT MEMO"] = "Z3";

                    if (count1 > 0)
                    {
                        InvoiceProformaHeader oldHeaderVersion1 = sql2.ToArray()[0];
                        System.Diagnostics.Debug.WriteLine(">>>> " + Username);
                        var cred = ParseCredential(Username);
                        var dest = SAPConnectionFactory.Instance.GetRfcDestination(cred);

                        if (dest != null)
                        {
                            var repo = dest.Repository;
                            var stopwatch = new Stopwatch();
                            stopwatch.Start();
                            var func = repo.CreateFunction(FUNCTIONAL_BAPI);

                            IRfcTable I_REJECT1 = func.GetTable("I_REJECT1");
                            foreach (var bi in oldHeaderVersion1.Billings)
                            {
                                I_REJECT1.Append();

                                I_REJECT1.SetValue("MANDT", "999");
                                I_REJECT1.SetValue("VBELN", bi.VBAK_VBELN);
                                I_REJECT1.SetValue("POSNR", bi.VBAK_POSNR);
                                try
                                {
                                    I_REJECT1.SetValue("ABGRU", reasonForRejection[bi.VBAK_ABGRU_T.ToUpper()]);
                                }
                                catch (Exception ex)
                                {
                                    I_REJECT1.SetValue("ABGRU", "");
                                }
                               // bi.LogMessage="test";
                            }
                           
                            //dao.SaveChanges();

                            System.Diagnostics.Debug.WriteLine("<EXECUTING_BAPI NAME = '" + FUNCTIONAL_BAPI + "'>");
                            func.Invoke(dest);
                            var getDataMessage = func.GetTable("O_BLOCK_STAT");
                            var list = new OstatusBlock();
                            var list3 = getDataMessage.Select(e => new OstatusBlock
                            {
                                VBELN = e.GetString("VBELN"),
                                POSNR = e.GetString("POSNR"),
                                FLAG = e.GetString("FLAG"),
                                MESSAGE = e.GetString("MESSAGE"),
                                
                            });
                            
                             foreach (var item in list3)
                             {
                                 if (item.MESSAGE == "")
                                 {
                                     foreach (var xx in oldHeaderVersion1.Billings)
                                     {
                                         xx.LogMessage = "Success";
                                     }
                                 }
                                 else
                                 {
                                     foreach (var xx in oldHeaderVersion1.Billings)
                                     {
                                         xx.LogMessage = item.MESSAGE;
                                     }
                                 }
                               
                             }
                            dao.SaveChanges();
                            System.Diagnostics.Debug.WriteLine("<EXECUTING_BAPI/>");
                            stopwatch.Stop();
                            System.Diagnostics.Debug.WriteLine(">>>> " + stopwatch.Elapsed);
                        }
                    }else{

                        throw new FaultException("Version Final not Found!");
                    }
                }
                return ret;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}