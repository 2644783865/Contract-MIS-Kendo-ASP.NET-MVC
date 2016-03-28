using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ProformaInvoice
{
    /// <summary>
    /// Table level I (Biru Muda)
    /// </summary>
    public class BillingItemViewModel
    {
        public string BillingItemId { get; set; }

        [LocalizedDisplayName("BillingBlock", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public string BillingBlock { get; set; }

        [LocalizedDisplayName("BillingItem", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public int BillingItem { get; set; }

        [LocalizedDisplayName("BillingNo", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public int BillingNo { get; set; }

        [LocalizedDisplayName("Type", NameResourceType = typeof (Resources.SharedResource))]
        public string Type { get; set; }

        [LocalizedDisplayName("MaterialType", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string MaterialType { get; set; }

        [LocalizedDisplayName("MaterialNo", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string MaterialNo { get; set; }

        [LocalizedDisplayName("Description", NameResourceType = typeof (Resources.SharedResource))]
        public string Description { get; set; }

        [LocalizedDisplayName("Equipment", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public string Equipment { get; set; }

        [LocalizedDisplayName("SerialNumber", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public string SerialNumber { get; set; }

        [LocalizedDisplayName("Location", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public string Location { get; set; }

        [LocalizedDisplayName("SalaryNumber", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public int SalaryNumber { get; set; }

        [LocalizedDisplayName("HolderName", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string HolderName { get; set; }

        [LocalizedDisplayName("SubArea", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string SubArea { get; set; }

        [LocalizedDisplayName("Year", NameResourceType = typeof (Resources.SharedResource))]
        public int Year { get; set; }

        [LocalizedDisplayName("Currency", NameResourceType = typeof (Resources.SharedResource))]
        public string Currency { get; set; }

        [LocalizedDisplayName("Charge", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public double Charge { get; set; }

        [LocalizedDisplayName("Deduction", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string Deduction { get; set; }

        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public int ContractNumber { get; set; }

        [LocalizedDisplayName("ContractItem", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public int ContractItem { get; set; }

        [LocalizedDisplayName("IdrNo", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public string IdrNo { get; set; }

        [LocalizedDisplayName("IdrDate", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string IdrDate { get; set; }

        [LocalizedDisplayName("ValidFrom", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string ValidFrom { get; set; }

        [LocalizedDisplayName("ValidTo", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string ValidTo { get; set; }

        [LocalizedDisplayName("PersArea", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string PersArea { get; set; }

        [LocalizedDisplayName("OrgUnit", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string OrgUnit { get; set; }

        [LocalizedDisplayName("OUCode", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string OuCode { get; set; }

        [LocalizedDisplayName("CostCenter", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string CostCenter { get; set; }

        [LocalizedDisplayName("OriginMatCode", NameResourceType = typeof (Resources.ProformaInvoiceResource))]
        public string OriginMatCode { get; set; }

        [LocalizedDisplayName("OtherInformation", NameResourceType = typeof (Resources.SharedResource))]
        public string OtherInformation { get; set; }

        [LocalizedDisplayName("Remarks", NameResourceType = typeof (Resources.SharedResource))]
        public string Remarks { get; set; }

        [LocalizedDisplayName("LogMessage", NameResourceType = typeof(Resources.SharedResource))]
        public string LogMessage { get; set; }

        [UIHint("ClientCategory")]
        [LocalizedDisplayName("ReasonForRejection", NameResourceType = typeof(Resources.ProformaInvoiceResource))]
        public CategoryViewModel ReasonForRejectionVM { get; set; }
    }
}