using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Misi.DAL.Billing.DaoUtil;
using Misi.DAL.Billing.Model.SAP;
using Misi.Service.Billing.Handler;
using Misi.Service.Billing.Handler.SAP;
using Misi.Service.Billing.Model.SAP;
using Misi.Service.Billing.Object;
using SAP.Middleware.Connector;
using Misi.Common.Lib.Util;

namespace Misi.Service.Billing.Service
{
    public class SAPProxyService : ISAPProxyService
    {
        public List<string> QuerySoldToParties(string user)
        {
            var list = new List<string>();
            var handler = SAPRequestHandlerFactory.Instance.GetSAPRequestHandler(ESAPScenario.QUERY_SOLD_TO_PARTIES_LIST);

            var param = new object[3];
            handler.SetHandlerArguments(user, param);
            var resp = handler.ExecuteQuery() as SoldToPartiesListDTO;
            if (resp != null)
                list.AddRange(resp.List.Select(kv => kv.Key + ";" + kv.Value));
            return list;
        }

        public List<BillingNumberItemDTO> QueryBillingNumbers(string user, string soldToParty, DateTime startDate, DateTime endDate)
        {
            var handler = SAPRequestHandlerFactory.Instance.GetSAPRequestHandler(ESAPScenario.QUERY_BILLING_NUMBERS);
            var param = new object[3];
            param[0] = soldToParty;
            param[1] = startDate;
            param[2] = endDate;
            handler.SetHandlerArguments(user, param);
            var resp = handler.ExecuteQuery() as BillingNumberItemsDTO;
            return resp == null ? null : resp.Numbers;
        }

        public int QueryTotalBillingRecords(string user)
        {
            var head = InMemoryCache.Instance.GetCached(user + InvoiceProformaBaseHandler.Suffix.REQUEST_HEADER) as RunInvoiceHeaderDTO;
            if (head != null)
            {
                var handler = SAPRequestHandlerFactory.Instance.GetSAPRequestHandler(ESAPScenario.QUERY_BILLING_TOTAL_RECORDS);
                var param = new object[4];
                param[0] = head.BillingNo;
                param[1] = head.BillingDocsCriteria;
                param[2] = head.ReasonForRejection;
                param[3] = head.ProformaFlag;
                handler.SetHandlerArguments(user, param);
                var resp = handler.ExecuteQuery() as NumberResult;
                return resp == null ? 0 : resp.Value;
            }
            return 0;
        }

        public RunInvoiceHeaderDTO QueryRunInvoiceHeader(string user, string billingNo, bool billingBlock, bool reasonForRejection, bool proformaFlag)
        {
            InMemoryCache.Instance.ClearCached(user + InvoiceProformaBaseHandler.Suffix.CURRENT_PAGE);
            var handler = SAPRequestHandlerFactory.Instance.GetSAPRequestHandler(ESAPScenario.QUERY_INVOICE_HEADER_FROM_SAP);
            var param = new object[4];
            param[0] = billingNo;
            param[1] = billingBlock;
            param[2] = reasonForRejection;
            param[3] = proformaFlag;
            handler.SetHandlerArguments(user, param);
            return handler.ExecuteQuery() as RunInvoiceHeaderDTO;
        }

        public RunInvoiceHeaderDTO QueryRunInvoiceHeaderFromDB(string user, long no)
        {
            InMemoryCache.Instance.ClearCached(user + InvoiceProformaBaseHandler.Suffix.CURRENT_PAGE);
            var handler = SAPRequestHandlerFactory.Instance.GetSAPRequestHandler(ESAPScenario.QUERY_INVOICE_HEADER_FROM_DB);
            var param = new object[5];
            param[0] = no;
            handler.SetHandlerArguments(user, param);
            return handler.ExecuteQuery() as RunInvoiceHeaderDTO;
        }

        public IEnumerable<InvoiceProformaItemDTO> QueryRunInvoiceBillingsAll(string user)
        {
            var handler = SAPRequestHandlerFactory.Instance.GetSAPRequestHandler(ESAPScenario.QUERY_INVOICE_BILLINGS_ALL);
            handler.SetHandlerArguments(user, null);
            var resp = handler.ExecuteQuery() as InvoiceProformaItemsDTO;
            return resp == null ? null : resp.Items;
        }

        public IEnumerable<InvoiceProformaBillingRunDTO> QueryBillingRunsFromDB(string user)
        {
            InMemoryCache.Instance.ClearCached(user + InvoiceProformaBaseHandler.Suffix.QUERIED_VERSION_FROM_DB);
            var handler = SAPRequestHandlerFactory.Instance.GetSAPRequestHandler(ESAPScenario.QUERY_BILLING_RUNS);
            handler.SetHandlerArguments(user, null);
            var resp = handler.ExecuteQuery() as InvoiceProformaBillingRunsDTO;
            return resp == null ? null : resp.Items;
        }

        public void UpdateRunInvoiceBilling(string user, string recNo, string reason, string remarks)
        {
            var handler = SAPRequestHandlerFactory.Instance.GetSAPRequestHandler(ESAPScenario.UPDATE_BILLING_ITEM);
            var param = new object[3];
            param[0] = recNo;
            param[1] = reason;
            param[2] = remarks;
            handler.SetHandlerArguments(user, param);
            handler.ExecuteCommand();
        }

        public int? SaveRunInvoiceBillings(string user)
        {
            var handler = SAPRequestHandlerFactory.Instance.GetSAPRequestHandler(ESAPScenario.SAVE_UPDATED_BILLING_ITEMS);
            var param = new object[0];
            handler.SetHandlerArguments(user, param);
            var resp = handler.ExecuteCommand() as NumberResult;
            if (resp != null)
                return resp.Value;
            return null;
        }

        public void SaveInitialSAPData(string user)
        {
            var handler = SAPRequestHandlerFactory.Instance.GetSAPRequestHandler(ESAPScenario.SAVE_INITIAL_SAP_DATA);
            var param = new object[0];
            handler.SetHandlerArguments(user, param);
            handler.ExecuteCommand();
        }

        private RfcDestination GetRfcDestination()
        {
            var p = new
            {
                Name = "DEV",
                AppServerHost = "10.1.3.115",
                SystemNumber = "00",
                SystemID = "QM5",
                SAPUser = "ECEOS.BROMO",
                Password = "trakindo1",
                Client = "999",
                Language = "EN",
                PoolSize = 10
            };

            var config = new RfcConfigParameters
                {
                    {RfcConfigParameters.Name, p.Name},
                    {RfcConfigParameters.AppServerHost, p.AppServerHost},
                    {RfcConfigParameters.SystemNumber, p.SystemNumber},
                    {RfcConfigParameters.SystemID, p.SystemID},
                    {RfcConfigParameters.User, p.SAPUser},
                    {RfcConfigParameters.Password, p.Password},
                    {RfcConfigParameters.Client, p.Client},
                    {RfcConfigParameters.Language, p.Language},
                    {RfcConfigParameters.PoolSize, p.PoolSize.ToString(CultureInfo.InvariantCulture)}
                };
            var dest = RfcDestinationManager.GetDestination(config);
            return dest;
        }


        /******************************************************************************************************************************
         * BANG FEBRI CODES... :)
         ******************************************************************************************************************************/

        public SAPResponse GetBillingsToPrintAppendix(string user, string billingNumber)
        {


            var cred = ParseCredential(user);
            var dest = SAPConnectionFactory.Instance.GetRfcDestination(cred);
            if (dest == null) return null;
            const string FUNCTIONAL_BAPI1 = "ZBAPI_PRINT_BILLING";

            var repo = dest.Repository;
            var func1 = repo.CreateFunction(FUNCTIONAL_BAPI1);
            func1.SetValue("BILL_NO", billingNumber);
            func1.SetValue("PROFORMA_FLAG", "X");
            func1.SetValue("ITEM_FLAG", "X");

            func1.SetValue("BILLING_BLOCK", " ");
            func1.SetValue("REASON_FOR_REJECTION", " ");
            func1.Invoke(dest);

            var proformaTbl = func1.GetTable("PROFORMA");
            System.Diagnostics.Debug.WriteLine("START PARSING AT = " + DateTime.Now);

            var ret = new Contract();
            ret.conItem = new List<ContractItem>();

            for (var a = 0; a < proformaTbl.RowCount; a++)
            {
                proformaTbl.CurrentIndex = a;
                if (proformaTbl.CurrentRow.GetString("VBELN") != "")
                {
                    var pit = new ContractItem();
                    SAPDataCopier.Instance.CopyFromStruct(proformaTbl.CurrentRow, pit);
                    ret.conItem.Add(pit);
                }
            }

            return ret;
        }



        public SAPResponse GetBillingsToPrintHeader(string user, string billingNumber)
        {
            var cred = ParseCredential(user);
            var dest = SAPConnectionFactory.Instance.GetRfcDestination(cred);
            if (dest == null) return null;
            var getitem = "";

            // if (anvoiceDetail.ToUpper()=="X" || appendix.ToUpper()=="X")
            // {
            getitem = "";
            //}

            const string FUNCTIONAL_BAPI1 = "ZBAPI_PRINT_BILLING";

            var repo = dest.Repository;
            var func1 = repo.CreateFunction(FUNCTIONAL_BAPI1);
            func1.SetValue("BILL_NO", billingNumber);
            func1.SetValue("PROFORMA_FLAG", " ");

            func1.SetValue("ITEM_FLAG", getitem);

            func1.SetValue("BILLING_BLOCK", " ");
            func1.SetValue("REASON_FOR_REJECTION", " ");
            func1.Invoke(dest);

            //var proformaTbl = func1.GetTable("PROFORMA");

            var headerTbl = func1.GetTable("HEADER");
            headerTbl.CurrentIndex = 0;
            var headerStruct = headerTbl.CurrentRow;


            var ret = new RunPrintBillingsDTO();
            ret._printBillingHeader = new PrintBillingHeaderDTO();

            ret._printBillingHeader.ReportInvoiceDetail = new List<PrintBillingItemDTO>();
            var ReportInvoiceDetailExcel = new List<ContractItem>();
            SAPDataCopier.Instance.CopyFromStruct(headerStruct, ret._printBillingHeader);


            //for (var a = 0; a < proformaTbl.RowCount; a++)
            //{
            //    proformaTbl.CurrentIndex = a;
            //    var pit = new ContractItem();
            //    SAPDataCopier.Instance.CopyFromStruct(proformaTbl.CurrentRow, pit);
            //    ReportInvoiceDetailExcel.Add(pit);
            //}


            //var It = ReportInvoiceDetailExcel.ToList();
            //var categorylist = (from c in It
            //                    select c.CATEGORY).Distinct().ToList();
            //Int32 j = 0;
            //Int64 jj = 0;
            //foreach (var category in categorylist)
            //{
            //    PrintBillingItemDTO cat = new PrintBillingItemDTO();
            //    cat.MaterialSubCategoryLineViewModel = new List<MaterialSubCategory>();
            //    cat.MaterialCategoryName = category;

            //    var subcategorylist = (from c in It
            //                           where c.CATEGORY == category
            //                           select c.SUBCATEGORY).Distinct().ToList();

            //    Int32 k = 0;
            //    Int64 kk = 0;
            //    foreach (var subcategory in subcategorylist)
            //    {
            //        MaterialSubCategory subCat = new MaterialSubCategory();
            //        subCat.MaterialSubCategoryLineViewModel = new List<DetailMaterialSubCategory>();
            //        var materiallist = (from c in It
            //                            where c.SUBCATEGORY == subcategory && c.CATEGORY == category
            //                            select new { c.MATNR }).Distinct().ToList();
            //        int l = 0;
            //        Int64 ll = 0;
            //        foreach (var material in materiallist)
            //        {
            //            DetailMaterialSubCategory mat = new DetailMaterialSubCategory();

            //            mat.DetailSubMaterialDescriptionLineViewModels = new List<DetailSubMaterialDescription>();

            //            var billinglist = It.Where(x => x.CATEGORY == category && x.SUBCATEGORY == subcategory && x.MATNR == material.MATNR);

            //            Int32 i = 0;
            //            Int64 ii = Convert.ToInt64(billinglist.Sum(x => double.Parse(x.TOTAL5)));
            //            ll = ll + ii;
            //            mat.MatCharge = "0";
            //            foreach (var lineitem in billinglist)
            //            {
            //                i++;
            //                DetailSubMaterialDescription subMat = new DetailSubMaterialDescription();
            //                subMat.No = i.ToString();
            //                subMat.ChargesDetailSubMaterialDescription = ii.ToString();
            //                subMat.DetailSubDescription = "Holder : " + lineitem.VBAK_EMPNAME + "; SN : " + lineitem.VBAK_PERNR2 + "Location : " + lineitem.VBAK_SUBAREA_T;

            //                subMat.ChargesDetailSubMaterialDescription = lineitem.TOTAL5;
            //                if (mat.MatCharge=="0")
            //                {
            //                    mat.MatCharge = lineitem.TOTAL5;
            //                }

            //                mat.MaterialDescription = lineitem.ARKTX;
            //                mat.DetailSubMaterialDescriptionLineViewModels.Add(subMat);

            //            }
            //            l = l + i;

            //            mat.MaterialNo = material.MATNR;
            //            mat.SubTotal = ii.ToString();
            //            mat.MatQty = billinglist.Count().ToString();
            //            subCat.MaterialSubCategoryLineViewModel.Add(mat);
            //        }
            //        kk = kk + ll;

            //        k = k + l;
            //        subCat.SubQty = materiallist.Count().ToString();
            //        subCat.MaterialSubCategoryName = subcategory;
            //        subCat.SubTotalCharges = ll.ToString();
            //        subCat.SubQty = k.ToString();

            //        cat.MaterialSubCategoryLineViewModel.Add(subCat);
            //    }
            //    j = j + k;
            //    jj = jj + kk;

            //    cat.MaterialCategoryName = category;
            //    cat.Qty = k.ToString();
            //    cat.TotalCharges = kk.ToString();
            //    ret._printBillingHeader.ReportInvoiceDetail.Add(cat);
            //}

            //NOTO
            //RfcDestinationManager.UnregisterDestinationConfiguration(dest);
            return ret;
        }

        public SAPResponse GetBillingsToPrint(string user, string billingNumber/*,string invoiceDetail="x",string appendix="x"*/)
        {
            var cred = ParseCredential(user);
            var dest = SAPConnectionFactory.Instance.GetRfcDestination(cred);
            if (dest == null) return null;
            var getitem = "";

            // if (anvoiceDetail.ToUpper()=="X" || appendix.ToUpper()=="X")
            // {
            getitem = "x";
            //}

            const string FUNCTIONAL_BAPI1 = "ZBAPI_PRINT_BILLING";

            var repo = dest.Repository;
            var func1 = repo.CreateFunction(FUNCTIONAL_BAPI1);
            func1.SetValue("BILL_NO", billingNumber);
            func1.SetValue("PROFORMA_FLAG", "X");

            func1.SetValue("ITEM_FLAG", getitem);

            func1.SetValue("BILLING_BLOCK", " ");
            func1.SetValue("REASON_FOR_REJECTION", " ");
            func1.Invoke(dest);

            var proformaTbl = func1.GetTable("PROFORMA");
            var itemTbl = func1.GetTable("ITEM");

            var headerTbl = func1.GetTable("HEADER");
            headerTbl.CurrentIndex = 0;
            var headerStruct = headerTbl.CurrentRow;


            var ret = new RunPrintBillingsDTO();
            ret._printBillingHeader = new PrintBillingHeaderDTO();

            ret._printBillingHeader.ReportInvoiceDetail = new List<PrintBillingItemDTO>();
            var ReportInvoiceDetailExcel = new List<ContractItem>();
            SAPDataCopier.Instance.CopyFromStruct(headerStruct, ret._printBillingHeader);


            for (var a = 0; a < proformaTbl.RowCount; a++)
            {
                proformaTbl.CurrentIndex = a;

                if (proformaTbl.CurrentRow.GetString("VBELN")!="")
                {
                    var pit = new ContractItem();
                    SAPDataCopier.Instance.CopyFromStruct(proformaTbl.CurrentRow, pit);
                    ReportInvoiceDetailExcel.Add(pit);
                }
            }



            var It = ReportInvoiceDetailExcel.ToList();
            var categorylist = (from c in It
                                select c.CATEGORY).Distinct().ToList();
            Int32 j = 0;
            Int64 jj = 0;
            foreach (var category in categorylist)
            {
                PrintBillingItemDTO cat = new PrintBillingItemDTO();
                cat.MaterialSubCategoryLineViewModel = new List<MaterialSubCategory>();
                cat.MaterialCategoryName = category;

                var subcategorylist = (from c in It
                                       where c.CATEGORY == category
                                       select c.SUBCATEGORY).Distinct().ToList();

                Int32 k = 0;
                Int64 kk = 0;
                foreach (var subcategory in subcategorylist)
                {
                    MaterialSubCategory subCat = new MaterialSubCategory();
                    subCat.MaterialSubCategoryLineViewModel = new List<DetailMaterialSubCategory>();
                    var materiallist = (from c in It
                                        where c.SUBCATEGORY == subcategory && c.CATEGORY == category
                                        select new { c.MATNR }).Distinct().ToList();
                    int l = 0;
                    Int64 ll = 0;
                    foreach (var material in materiallist)
                    {
                        DetailMaterialSubCategory mat = new DetailMaterialSubCategory();

                        mat.DetailSubMaterialDescriptionLineViewModels = new List<DetailSubMaterialDescription>();

                        var billinglist = It.Where(x => x.CATEGORY == category && x.SUBCATEGORY == subcategory && x.MATNR == material.MATNR);

                        Int32 i = 0;
                        Int64 ii = Convert.ToInt64(billinglist.Sum(x => double.Parse(x.TOTAL5)));
                        ll = ll + ii;
                        foreach (var lineitem in billinglist)
                        {
                            i++;
                            DetailSubMaterialDescription subMat = new DetailSubMaterialDescription();
                            subMat.No = i.ToString();
                            subMat.ChargesDetailSubMaterialDescription = ii.ToString();
                            subMat.DetailSubDescription = "Holder : " + lineitem.VBAK_EMPNAME + "; SN : " + lineitem.VBAK_PERNR2 + "Location : " + lineitem.VBAK_SUBAREA_T;

                            subMat.ChargesDetailSubMaterialDescription = lineitem.TOTAL5;
                            mat.MatCharge = lineitem.TOTAL5;

                            mat.MaterialDescription = lineitem.ARKTX;
                            mat.DetailSubMaterialDescriptionLineViewModels.Add(subMat);

                        }
                        l = l + i;

                        mat.MaterialNo = material.MATNR;
                        mat.SubTotal = ii.ToString();
                        mat.MatQty = billinglist.Count().ToString();
                        subCat.MaterialSubCategoryLineViewModel.Add(mat);
                    }
                    kk = kk + ll;

                    k = k + l;
                    subCat.SubQty = materiallist.Count().ToString();
                    subCat.MaterialSubCategoryName = subcategory;
                    subCat.SubTotalCharges = ll.ToString();
                    subCat.SubQty = k.ToString();

                    cat.MaterialSubCategoryLineViewModel.Add(subCat);
                }
                j = j + k;
                jj = jj + kk;

                cat.MaterialCategoryName = category;
                cat.Qty = k.ToString();
                cat.TotalCharges = kk.ToString();
                ret._printBillingHeader.ReportInvoiceDetail.Add(cat);
            }



            return ret;
        }


        public int? SaveBillingBlock(string user, string billingNumber)
        {
            List<ContractBlock> listContract = new List<ContractBlock>();


            const string FUNCTIONAL_BAPI = "ZBAPI_SALESORDER_CHANGE";

            using (var dao = new BillingDbContext())
            {
                var sql1 = from o in dao.InvoiceProformaHeaders.Where(o => o.BillingNo == billingNumber).OrderByDescending(o => o.Version).Include(o => o.Billings)

                           select o;
                var count = sql1.ToList().Count;
                if (count > 1)
                {
                    InvoiceProformaHeader oldHeaderVersion = sql1.ToArray()[0];

                    var dest = GetRfcDestination();
                    if (dest != null)
                    {
                        var repo = dest.Repository;



                        var func = repo.CreateFunction(FUNCTIONAL_BAPI);

                        IRfcTable I_REJECT1 = func.GetTable("I_REJECT1");
                        foreach (var bi in oldHeaderVersion.Billings)
                        {
                            I_REJECT1.Append();

                            I_REJECT1.SetValue("MANDT", "999");
                            I_REJECT1.SetValue("VBELN", bi.AUBEL);
                            I_REJECT1.SetValue("POSNR", bi.AUPOS);
                            I_REJECT1.SetValue("ABGRU", bi.VBAK_ABGRU_T);
                        }

                        func.Invoke(dest);
                    }


                }


            }



            return 1;
        }



        public SAPResponse GetBillingsToPrintTotal(string user, string billingNumber)
        {

            var cred = ParseCredential(user);
            var dest = SAPConnectionFactory.Instance.GetRfcDestination(cred);
            if (dest == null) return null;
            var getitem = "";

            // if (anvoiceDetail.ToUpper()=="X" || appendix.ToUpper()=="X")
            // {
            getitem = "";
            //}

            const string FUNCTIONAL_BAPI1 = "ZBAPI_PRINT_BILLING";

            var repo = dest.Repository;
            var func1 = repo.CreateFunction(FUNCTIONAL_BAPI1);
            func1.SetValue("BILL_NO", billingNumber);
            func1.SetValue("PROFORMA_FLAG", "");

            func1.SetValue("ITEM_FLAG", getitem);

            func1.SetValue("BILLING_BLOCK", " ");
            func1.SetValue("REASON_FOR_REJECTION", " ");
            func1.Invoke(dest);

            var proformaTbl = func1.GetTable("PROFORMA");

            var headerTbl = func1.GetTable("HEADER");
            headerTbl.CurrentIndex = 0;
            var headerStruct = headerTbl.CurrentRow;


            var ret = new RunPrintBillingsDTO();
            ret._printBillingHeader = new PrintBillingHeaderDTO();

            ret._printBillingHeader.ReportInvoiceDetail = new List<PrintBillingItemDTO>();
            var ReportInvoiceDetailExcel = new List<ContractItem>();
            SAPDataCopier.Instance.CopyFromStruct(headerStruct, ret._printBillingHeader);



            return ret;
        }

        public int? SubmitInvoiceProforma(string user)
        {
            var handler = SAPRequestHandlerFactory.Instance.GetSAPRequestHandler(ESAPScenario.SUBMIT_BILLING_ITEMS);
            var param = new object[0];
            handler.SetHandlerArguments(user, param);
            var ret = handler.ExecuteCommand() as InvoiceProformaBillingRunsDTO;
            return ret.Items[0].No;
        }

        public int? SubmitInvoiceProformaByID(string user, long ID)
        {
            var handler = SAPRequestHandlerFactory.Instance.GetSAPRequestHandler(ESAPScenario.SUBMIT_BILLING_ITEMS_BY_ID);
            var param = new object[1];
            param[0] = ID;
            handler.SetHandlerArguments(user, param);
            var ret = handler.ExecuteCommand() as InvoiceProformaBillingRunsDTO;
            return ret.Items[0].No;
        }

        protected CredentialDTO ParseCredential(string param)
        {
            var cred = new CredentialDTO();
            if (param.Contains(":"))
            {
                string[] raw = param.Split(':');
                cred.SAPUsername = raw[0];
                cred.SAPPassword = raw[1];
                cred.SessionKey = raw[2];
            }
            return cred;
        }

    }

}
