using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Antlr.Runtime;
using Kendo.Mvc;
using Microsoft.Ajax.Utilities;
using Misi.MVC.SAPServiceClient;
using Misi.MVC.ViewModels.BillingReporting;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ProformaInvoice;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.Helpers
{
    public static class BillingReportingHelper
    {

        public static Misi.MVC.ViewModels.BillingReporting.PopupBillingDocumentViewModel GeneratePopupBillingDocumentViewModel(BillingNumberItemDTO[] billingNumber, MSTInvoiceBillingReportingViewModel iModel)
        {
            return new ViewModels.BillingReporting.PopupBillingDocumentViewModel
            {
                //petakan MST Model
                DateFromValue = iModel.DateFromValue,
                DateToValue = iModel.DateToValue,
                SoldToPartyValue = iModel.SoldToFromValue,
                HeaderTitle = ProformaInvoiceResource.BillingDocumentCreateNewPopupTitle,
                Lines = GenerateRadioButtonWithListViewModel(billingNumber)
            };
        }

        public static RadioButtonWithListViewModel GenerateRadioButtonWithListViewModel(
            BillingNumberItemDTO[] billingNumber)
        {
            return new RadioButtonWithListViewModel
            {
                RadioButtons = billingNumber.Select(e => new RadioButtonData
                {
                    Id = e.BillingDocNumber + string.Empty,
                    Text = e.BillingDocNumber + string.Empty
                }),
                Columns = billingNumber.Select(e => new Dictionary<string, string>
                {
                    {
                        ProformaInvoiceResource.BillingDocNumber, e.BillingDocNumber
                    },
                    {
                        ProformaInvoiceResource.CreatedBy, e.CreatedBy
                    },
                    {
                        ProformaInvoiceResource.CreatedDate, e.CreatedDate.ToString(ConfigResource.FormatDate)
                    },
                    {
                        ProformaInvoiceResource.CreatedTime, e.CreateTime.ToString(ConfigResource.FormatTime)
                    }
                })
            };
        }
        
         
            
        public static MSTInvoiceBillingReportingViewModel GenerateMSTInvoiceBillingReportingViewModel()
        {
            var yr = DateTime.Today.Year;
            var mth = DateTime.Today.Month;
            DateTime today = DateTime.Today;

            return new MSTInvoiceBillingReportingViewModel
            {
                BillingType = ProformaInvoiceResource.BillingTypeMSTProformaInvoice,
                //BillingDateFrom = DateTime.ParseExact("01 Jan 2015", ConfigResource.FormatDate, System.Globalization.CultureInfo.InvariantCulture),
                //BillingDateTo = DateTime.ParseExact("30 Jan 2015", ConfigResource.FormatDate, System.Globalization.CultureInfo.InvariantCulture),
                BillingDateFrom = new DateTime(yr, mth, 1),
                BillingDateTo = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month)),
                BillingTypeList = GeneralFormHelper.GenerateKendoDropDownListViewModel("GetSoldToPartyAsync", "SAPMasterData", "SoldToPartyName", "SoldToPartyID", "0"),
                SoldToPartyFrom = GeneralFormHelper.GenerateKendoDropDownListViewModel("GetSoldToPartyJson", "SAPMasterData"),
                SelectedDocuments = new SelectedDocumentViewModel
                {
                    IsActiveDocumentSelected = true
                }
            };
        }

        public static MSTInvoiceBillingReportingViewModel GenerateMSTInvoiceBillingReportingViewModel(SAPResponse x)
        {
            return new MSTInvoiceBillingReportingViewModel();
        }

        public static MSTInvoiceBillingReportingViewModel GenerateMSTInvoiceBillingReportingViewModel(ViewModels.BillingReporting.PopupBillingDocumentViewModel viewModel)
        {
            var resultViewModel = GenerateMSTInvoiceBillingReportingViewModel();
            
            resultViewModel.BillingDocNumber = viewModel.Lines.SelectedValue;
            resultViewModel.BillingDateFrom = Convert.ToDateTime(viewModel.DateFromValue);
            resultViewModel.BillingDateTo= Convert.ToDateTime(viewModel.DateToValue);
            resultViewModel.SoldToFromValue = viewModel.SoldToPartyValue;
            //TODO: Map from given viewModel

            return resultViewModel;
        }


        public static BillingServiceRequestViewModel GenerateBillingServiceRequestViewModel()
        {
            return new BillingServiceRequestViewModel
            {
                IssuedDateFrom = DateTime.Now,
                IssuedDateTo = DateTime.Now,
                ScenarioCheckList = new ScenarioCheckListViewModel()
            };
        }

        public static ReportInvoiceViewModel GenerateInvoiceViewModel()
        {
            return new ReportInvoiceViewModel();
        }

        public static ReportInvoiceViewModel GenerateInvoiceViewModel(RunPrintBillingsDTO serviceModel)
        {
            
            return new ReportInvoiceViewModel
            {
                
                Kunrg = serviceModel._printBillingHeader.KUNRG,
                Name1 = serviceModel._printBillingHeader.NAME1,
                Name2 = serviceModel._printBillingHeader.NAME2,
                Name3 = serviceModel._printBillingHeader.NAME3,
                Name4 = serviceModel._printBillingHeader.NAME4,
                Street = serviceModel._printBillingHeader.STREET,
                Vtext = serviceModel._printBillingHeader.VTEXT,
                Waerk = serviceModel._printBillingHeader.WAERK,
                City1 = serviceModel._printBillingHeader.CITY1,
                PostCode1 = serviceModel._printBillingHeader.POST_CODE1, 
                InvoiceNo   = serviceModel._printBillingHeader.VBELN,
                Fkdat = DateTime.ParseExact(serviceModel._printBillingHeader.FKDAT, 
                    "yyyy-MM-dd", CultureInfo.CurrentCulture).ToString("dd.MM.yyyy"),
                Htotal1 = serviceModel._printBillingHeader.HTOTAL1,
                Htotal2 = Convert.ToDecimal(serviceModel._printBillingHeader.HTOTAL2).ToString("#,##0"),
                Htotal3 = Convert.ToDecimal(serviceModel._printBillingHeader.HTOTAL3).ToString("#,##0"),
                FakturPajak = serviceModel._printBillingHeader.FPAJAK_NO,
                Stceg = serviceModel._printBillingHeader.STCEG,
                Tdline = serviceModel._printBillingHeader.TDLINE,
                Text1 = serviceModel._printBillingHeader.TEXT1,
                Zterm = serviceModel._printBillingHeader.ZTERM,
                TotalInvoice = Convert.ToDecimal(Convert.ToDecimal(serviceModel._printBillingHeader.HTOTAL2) + Convert.ToDecimal(serviceModel._printBillingHeader.HTOTAL3)).ToString("#,##0"),
                
            };
        }

        public static HeaderInoviceDetailViewModel GenerateHeaderInvoiceDetailViewModel()
        {
            return new HeaderInoviceDetailViewModel();

        }

        public static HeaderInoviceDetailViewModel GenerateHeaderInvoiceDetailViewModel(RunPrintBillingsDTO serviceModel)
        {
            return new HeaderInoviceDetailViewModel
            {
                PayerName = serviceModel._printBillingHeader.NAME1,
                Currency = serviceModel._printBillingHeader.WAERK,
                HeaderNote = serviceModel._printBillingHeader.TDLINE,
                InvoiceNo = serviceModel._printBillingHeader.VBELN
               
            };
        }

        public static ReportInvoiceDetailViewModel GenerateInvoiceDetailViewModel()
        {
            return new ReportInvoiceDetailViewModel();
        }

        public static ReportInvoiceDetailViewModel GenerateInvoiceDetailViewModel(RunPrintBillingsDTO serviceModel)
        {

            return new ReportInvoiceDetailViewModel
            {
                //properti unntuk Header
                Name1 = serviceModel._printBillingHeader.NAME1 ?? string.Empty,
                Tdline = serviceModel._printBillingHeader.TDLINE ?? string.Empty,
                TotalCharges = Convert.ToDecimal(serviceModel._printBillingHeader.HTOTAL5).ToString("#,##0") ?? string.Empty,
                Deduction = Convert.ToDecimal(serviceModel._printBillingHeader.HTOTAL4).ToString("#,##0") ?? string.Empty,
                TotatalChargesAfterDiscount = Convert.ToDecimal(serviceModel._printBillingHeader.HTOTAL2).ToString("#,##0") ?? string.Empty,
                InvoiceNo = serviceModel._printBillingHeader.VBELN ?? string.Empty,
                Currency = serviceModel._printBillingHeader.WAERK ?? string.Empty,

                //tabel item properti
                ReportInvoiceDetailLineViewModelList = serviceModel._printBillingHeader.ReportInvoiceDetail.Select(a => new ReportInvoiceDetailLineViewModel
                {
                    MaterialCategoryName = a.MaterialCategoryName ?? string.Empty,
                    Qty = a.Qty ?? string.Empty,
                    TotalCharges = Convert.ToDecimal(a.TotalCharges).ToString("#,##0") ?? string.Empty,
                    MaterialSubCategoryLineViewModels = a.MaterialSubCategoryLineViewModel.Select(b => new MaterialSubCategoryLineViewModel
                    {
                        MaterialSubCategoryName = b.MaterialSubCategoryName ?? string.Empty,
                        SubQty = b.SubQty ?? string.Empty,
                        SubTotalCharges = Convert.ToDecimal(b.SubTotalCharges).ToString("#,##0") ?? string.Empty,
                        DetailMaterialSubCategoryLineViewModels = b.MaterialSubCategoryLineViewModel.Select(c => new DetailMaterialSubCategoryLineViewModel
                        {
                            MaterialNo = c.MaterialNo ?? string.Empty,
                            MaterialDescription = c.MaterialDescription ?? string.Empty,
                            SubTotal = Convert.ToDecimal(c.SubTotal).ToString("#,##0") ?? string.Empty,
                            MaterialQty = c.MatQty ?? string.Empty,
                            DetailMaterialRate = Convert.ToDecimal(c.MatCharge).ToString("#,##0") ?? string.Empty,
                            DetailSubMaterialDescriptionLineViewModels = c.DetailSubMaterialDescriptionLineViewModels.Select(d => new DetailSubMaterialDescriptionLineViewModel
                            {
                                No = d.No ?? string.Empty,
                                DetailSubDescription = d.DetailSubDescription ?? string.Empty,
                                ChargesDetailSubMaterialDescription = Convert.ToDecimal(d.ChargesDetailSubMaterialDescription).ToString("#,##0") ?? string.Empty,
                                RateDetailSubMaterialDescription = Convert.ToDecimal(d.ChargesDetailSubMaterialDescription).ToString("#,##0") ?? string.Empty
                                
                            })

                        })
                    })

                })


            };
        }

        public static RunPrintBillingsDTO GenerateMockedInvoiceDetailViewModel()
        {
            return new RunPrintBillingsDTO
            {
                _printBillingHeader =  ReflectionHelper.GetRandomValueForAllProperties(new PrintBillingHeaderDTO(),
                    typeof (PrintBillingHeaderDTO)) as PrintBillingHeaderDTO
            };
        }


        public static PreviewAppendixViewModel GenerateBillingItemsViewModel(Contract serviceModel)
        {
            //TODO: BillingItemID should be revised based on ID given by Service
            return new PreviewAppendixViewModel
            {
                AppendixTableViewModels = serviceModel.conItem.Select(a => new AppendixTableViewModel
                {
                    BillingItem = a.POSNR ?? string.Empty,
                    Type = a.ITEM_TYPE ?? string.Empty,
                    MaterialType = a.WGBEZ ?? string.Empty,
                    MaterialNo = a.MATNR ?? string.Empty,
                    Description = a.ARKTX ?? string.Empty,
                    Equipment = a.VBAK_BSTKD_E ?? string.Empty,
                    SerialNumber = a.VBAK_SERGE ?? string.Empty,
                    Location = a.VBAK_LOCATION ?? string.Empty,
                    SalaryNumber = a.VBAK_PERNR2 ?? string.Empty,
                    Holder = a.VBAK_EMPNAME ?? string.Empty,
                    SubArea = a.VBAK_SUBAREA_T ?? string.Empty,
                    Year = a.VBAK_EQ_YEAR ?? string.Empty,
                    Currency = a.VBAK_WAERK ?? string.Empty,
                    Charges = a.TOTAL5 ?? string.Empty,
                    Deduction = a.TOTAL4 ?? string.Empty,
                    ContractNo = a.AUBEL ?? string.Empty,
                    ContractItem = a.AUPOS ?? string.Empty,
                    IdrNo = a.VBAK_BSTKD ?? string.Empty,
                    IdrDate = a.VBAK_BSTDK ?? string.Empty,
                    ValidFrom = a.VBAK_BEDAT ?? string.Empty,
                    ValidTo = a.VBAK_ENDAT ?? string.Empty,
                    PersArea = a.VBAK_PERSAREA_T ?? string.Empty,
                    OrgUnit = a.VBAK_ORGUNIT_T ?? string.Empty,
                    OuCode = a.VBAK_OUCODE ?? string.Empty,
                    CostCenter = a.VBAK_KOSTL ?? string.Empty,
                    OriginMatCode = SharedResource.NA ?? string.Empty,
                    OtherInformation = a.VBAK_NAME ?? string.Empty,
                    Remarks = SharedResource.NA ?? string.Empty
                })
            };
        }
    }
}