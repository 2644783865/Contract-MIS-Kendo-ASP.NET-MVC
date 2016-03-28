using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Elmah.ContentSyndication;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Misi.MVC.SAPServiceClient;
using Misi.MVC.ViewModels.ProformaInvoice;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.Shared;
using System.Linq;

namespace Misi.MVC.Helpers
{
    public class ProformaInvoiceHelper
    {
        /// <summary>
        /// A threshold to define if the proforma invoice is treated as large data
        /// </summary>
        public const int MaxRowNumbers = 3500;

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MainProformaInvoiceViewModel GenerateMainProformaInvoiceViewModel()
        {
            var yr = DateTime.Today.Year;
            var mth = DateTime.Today.Month;
            DateTime today = DateTime.Today;
            
            return new MainProformaInvoiceViewModel
            {
                BillingDateFrom = new DateTime(yr, mth, 1),
                BillingDateTo = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month)),
                BillingType = ProformaInvoiceResource.BillingTypeMSTProformaInvoice,
                BillingRun =
                    GeneralFormHelper.GenerateKendoDropDownListViewModel("GetBillingRunJson",
                        "BillingMasterData"),
                SoldToPartyFrom =
                    GeneralFormHelper.GenerateKendoDropDownListViewModel("GetSoldToPartyJson", "SAPMasterData"),
                SelectedDocuments = new SelectedDocumentViewModel
                {
                    IsActiveDocumentSelected = true
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="runInvoiceHeaderDto"></param>
        /// <returns></returns>
        public static RunProformaInvoiceHeaderViewModel GenerateRunProformaInvoiceViewModel(
            RunInvoiceHeaderDTO runInvoiceHeaderDto)
        {
            return new RunProformaInvoiceHeaderViewModel
            {
                CreatedBy = runInvoiceHeaderDto.CreatedBy,
                BillingRun = string.IsNullOrEmpty(runInvoiceHeaderDto.BillingRun)
                    ? SharedResource.NotReady
                    : runInvoiceHeaderDto.BillingRun,
                BillingType = ProformaInvoiceResource.BillingTypeMSTProformaInvoice,
                BillingDateFrom = runInvoiceHeaderDto.BillingDateFrom.ToString(ConfigResource.FormatDate),
                BillingDateTo = runInvoiceHeaderDto.BillingDateTo.ToString(ConfigResource.FormatDate),
                SoldToParty = runInvoiceHeaderDto.SoldToParty,
                CreatedOn = Convert.ToString(Convert.ToDateTime(runInvoiceHeaderDto.CreateOn).ToString("dd MMM yyyy")),
                Time = runInvoiceHeaderDto.Time
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="billingNumber"></param>
        /// <param name="iModel"></param>
        /// <returns></returns>
        public static PopupBillingDocumentViewModel GeneratePopupBillingDocumentViewModel(
            BillingNumberItemDTO[] billingNumber, MainProformaInvoiceViewModel iModel)
        {
            return new PopupBillingDocumentViewModel
            {
                IsActiveDocSelectedValue = iModel.IsActiveDocSelectedValue,
                IsBlockedDocSelectedValue = iModel.IsBlockedDocSelectedValue,
                HeaderTitle = ProformaInvoiceResource.BillingDocumentCreateNewPopupTitle,
                Lines = GenerateRadioButtonWithListViewModel(billingNumber)
            };
        }

        /// <summary>
        /// To generate viewmodel used 
        /// </summary>
        /// <param name="billingNumber"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static CreateIncorrectExternalDataViewModel GenerateCreateIncorrectExternalDataViewModel()
        {
            return new CreateIncorrectExternalDataViewModel
            {
                BillingItemViewModel = new List<BillingItemViewModel>()
            };
        }


        /// <summary>
        /// In order not to get Circular Dependency exception when performing 
        /// property projection for large data 
        /// </summary>
        /// <param name="serviceModel"></param>
        /// <returns></returns>
        public static DataSourceResult GenerateBillingItemsViewModelJSON([DataSourceRequest] DataSourceRequest request,
            IEnumerable<InvoiceProformaItemDTO> serviceModel)
        {
            return serviceModel.ToDataSourceResult(request, e => new
            {
                BillingItemId = e.NO ?? string.Empty,
                BillingBlock = e.VBAK_FAKSK_T ?? string.Empty,
                BillingNo = Convert.ToInt32(DictionaryHelper.ConvertToIntegerSafeString(e.VBELN)),
                BillingItem = Convert.ToInt32(DictionaryHelper.ConvertToIntegerSafeString(e.POSNR)),
                Charge = Convert.ToDouble(e.TOTAL5),
                ContractItem = Convert.ToInt32(DictionaryHelper.ConvertToIntegerSafeString(e.VBAK_POSNR)),
                ContractNumber = Convert.ToInt32(DictionaryHelper.ConvertToIntegerSafeString(e.VBAK_VBELN)),
                CostCenter = e.VBAK_KOSTL ?? string.Empty,
                Currency = e.VBAK_WAERK ?? string.Empty,
                Deduction = Convert.ToDecimal(e.TOTAL4).ToString("#,##0"),
                Description = e.ARKTX ?? string.Empty,
                Equipment = e.VBAK_BSTKD_E,
                HolderName = e.VBAK_EMPNAME ?? string.Empty,
                IdrDate = e.VBAK_BSTDK ?? string.Empty,
                IdrNo = e.VBAK_BSTKD ?? string.Empty,
                Location = e.VBAK_LOCATION ?? string.Empty,
                MaterialNo = e.MATNR ?? string.Empty,
                MaterialType = e.WGBEZ ?? string.Empty,
                OrgUnit = e.VBAK_ORGUNIT_T ?? string.Empty,
                OriginMatCode = SharedResource.NA ?? string.Empty,
                OtherInformation = e.VBAK_NAME ?? string.Empty,
                OuCode = e.VBAK_OUCODE ?? string.Empty,
                PersArea = e.VBAK_PERSAREA_T ?? string.Empty,
                Remarks = e.Remarks ?? string.Empty,
                LogMessage = e.LogMessage ?? string.Empty,
                SalaryNumber = Convert.ToInt32(DictionaryHelper.ConvertToIntegerSafeString(e.VBAK_PERNR2)),
                SerialNumber = e.VBAK_SERGE,
                SubArea = e.VBAK_SUBAREA_T ?? string.Empty,
                Type = e.ITEM_TYPE ?? string.Empty,
                ValidFrom = e.VBAK_BEDAT ?? string.Empty,
                ValidTo = e.VBAK_ENDAT ?? string.Empty,
                Year = Convert.ToInt32(DictionaryHelper.ConvertToIntegerSafeString(e.VBAK_EQ_YEAR)),
                ReasonForRejectionVM = !string.IsNullOrEmpty(e.VBAK_ABGRU_T)
                    ? GenerateReasonForRejectionListViewModel().FirstOrDefault(f => f.CategoryName == e.VBAK_ABGRU_T)
                    ?? GenerateReasonForRejectionListViewModel().FirstOrDefault(f => f.CategoryName == SharedResource.SpaceChar)
                        : GenerateReasonForRejectionListViewModel().FirstOrDefault(f => f.CategoryName == SharedResource.SpaceChar)
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CategoryViewModel> GenerateReasonForRejectionListViewModel()
        {
            var index = 0;
            return new[]
            {
                ProformaInvoiceResource.PleaseSelectReasonForRejection,
                SharedResource.SpaceChar,
                ProformaInvoiceResource.BillingBlocked,
                ProformaInvoiceResource.TechnicalReason,
                ProformaInvoiceResource.CompletionOfContract,
                ProformaInvoiceResource.EquipmentRejection,
                ProformaInvoiceResource.RepairAndMaintenance,

                ProformaInvoiceResource.AssignedbytheSystem,
                ProformaInvoiceResource.Deliverydatetoolate,
                ProformaInvoiceResource.Poorquality,
                ProformaInvoiceResource.Tooexpensive,
                ProformaInvoiceResource.Competitorbetter,
                ProformaInvoiceResource.Guarantee,
                ProformaInvoiceResource.Unreasonablerequest,
                ProformaInvoiceResource.Custtoreceivereplacement,
                ProformaInvoiceResource.DoubleInput,
                ProformaInvoiceResource.Availability,
                ProformaInvoiceResource.Coverage,
                ProformaInvoiceResource.Price,
                ProformaInvoiceResource.Relationship,
                ProformaInvoiceResource.Standardizaton,
                ProformaInvoiceResource.ProductSpecification,
                ProformaInvoiceResource.Termofpayment,
                ProformaInvoiceResource.Others,
                ProformaInvoiceResource.DontPrint,  
                ProformaInvoiceResource.Transactionisbeingblock,
                ProformaInvoiceResource.DocumentHeld,
                ProformaInvoiceResource.LostSales,
                ProformaInvoiceResource.ZProgramDoNotUse,
                ProformaInvoiceResource.Transactionisbeingchecked,
                ProformaInvoiceResource.EquipmentReplacement,
                ProformaInvoiceResource.ExcessHours,
                ProformaInvoiceResource.RevokeUserApplication,
                ProformaInvoiceResource.ReturnedITDevice,
                ProformaInvoiceResource.ReplacementITDevice,
                ProformaInvoiceResource.UpgradeITDevice,
                ProformaInvoiceResource.Rejectinprogress,
                ProformaInvoiceResource.PTTUservicerejection,
                ProformaInvoiceResource.Additionalparts,
                ProformaInvoiceResource.Replacementparts,
                ProformaInvoiceResource.Transactiontobedeal,
                ProformaInvoiceResource.SSBServiceRejection,
                ProformaInvoiceResource.BillingbyDebitMemo
            }.Select(e => new CategoryViewModel
            {
                CategoryID = index++,
                CategoryName = e
            });
        }

        /// <summary>
        /// Create one row used only to show if the data is not ready
        /// </summary>
        /// <param name="currentRows"></param>
        /// <param name="totalRows"></param>
        /// <returns></returns>
        public static IEnumerable<BillingItemViewModel> GenerateNotReadyBillingItemsViewModel(int? currentRows,
            int? totalRows)
        {
            return
                new[] {0}.Select(e => new BillingItemViewModel
                {
                    BillingItemId = SharedResource.NotReady,
                    BillingBlock = SharedResource.NotReady,
                    CostCenter = SharedResource.NotReady,
                    Currency = SharedResource.NotReady,
                    Description = SharedResource.NotReady,
                    Equipment = SharedResource.NotReady,
                    HolderName = SharedResource.NotReady,
                    IdrDate = SharedResource.NotReady,
                    IdrNo = SharedResource.NotReady,
                    Location = SharedResource.NotReady,
                    MaterialNo = SharedResource.NotReady,
                    MaterialType = SharedResource.NotReady,
                    OrgUnit = SharedResource.NotReady,
                    OriginMatCode = SharedResource.NotReady,
                    OtherInformation = SharedResource.NotReady,
                    OuCode = SharedResource.NotReady,
                    PersArea = SharedResource.NotReady,
                    Remarks = currentRows + "",
                    SerialNumber = SharedResource.NotReady,
                    SubArea = SharedResource.NotReady,
                    Type = SharedResource.NotReady,
                    ValidFrom = SharedResource.NotReady,
                    ValidTo = SharedResource.NotReady,
                    ReasonForRejectionVM = GenerateReasonForRejectionListViewModel().FirstOrDefault()
                });
        }
    }
}