using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Misi.MVC.Filters;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.BillingReporting
{
    public class AppendixTableViewModel
    {
        public string BillingDocumentNumber { get; set; }
        
        [LocalizedDisplayName("BillingItem", NameResourceType = typeof (BillingReportingResource))]
        public string BillingItem { get; set; }

        [LocalizedDisplayName("Type", NameResourceType = typeof(BillingReportingResource))]
        public string Type { get; set; }

        [LocalizedDisplayName("MaterialType", NameResourceType = typeof(BillingReportingResource))]
        public string MaterialType { get; set; }

        [LocalizedDisplayName("MaterialNo", NameResourceType = typeof(BillingReportingResource))]
        public string MaterialNo { get; set; }

        [LocalizedDisplayName("Description", NameResourceType = typeof(BillingReportingResource))]
        public string Description { get; set; }
        
        [LocalizedDisplayName("Equipment", NameResourceType = typeof(BillingReportingResource))]
        public string Equipment { get; set; }

        [LocalizedDisplayName("SerialNumber", NameResourceType = typeof(BillingReportingResource))]
        public string SerialNumber { get; set; }

        [LocalizedDisplayName("Location", NameResourceType = typeof(BillingReportingResource))]
        public string Location { get; set; }
        
        [LocalizedDisplayName("SalaryNumber", NameResourceType = typeof(BillingReportingResource))]
        public string SalaryNumber { get; set; }
        
        [LocalizedDisplayName("Holder", NameResourceType = typeof(BillingReportingResource))]
        public string Holder { get; set; }
        
        [LocalizedDisplayName("SubArea", NameResourceType = typeof(BillingReportingResource))]
        public string SubArea { get; set; }
        
        [LocalizedDisplayName("Year", NameResourceType = typeof(BillingReportingResource))]
        public string Year { get; set; }
        
        [LocalizedDisplayName("Currency", NameResourceType = typeof(BillingReportingResource))]
        public string Currency { get; set; }
        
        [LocalizedDisplayName("Charges", NameResourceType = typeof(BillingReportingResource))]
        public string Charges { get; set; }
        
        [LocalizedDisplayName("Deduction", NameResourceType = typeof(BillingReportingResource))]
        public string Deduction { get; set; }

        [LocalizedDisplayName("ContractNo", NameResourceType = typeof(BillingReportingResource))]
        public string ContractNo { get; set; }
        
        [LocalizedDisplayName("ContractItem", NameResourceType = typeof(BillingReportingResource))]
        public string ContractItem { get; set; }

        [LocalizedDisplayName("IdrNo", NameResourceType = typeof(BillingReportingResource))]
        public string  IdrNo { get; set; }
        
        [LocalizedDisplayName("IdrDate", NameResourceType = typeof(BillingReportingResource))]
        public string IdrDate { get; set; }
        
        [LocalizedDisplayName("ValidFrom", NameResourceType = typeof(BillingReportingResource))]
        public string ValidFrom { get; set; }
        
        [LocalizedDisplayName("ValidTo", NameResourceType = typeof(BillingReportingResource))]
        public string ValidTo { get; set; }
        
        [LocalizedDisplayName("PersArea", NameResourceType = typeof(BillingReportingResource))]
        public string PersArea { get; set; }

        [LocalizedDisplayName("OrgUnit", NameResourceType = typeof(BillingReportingResource))]
        public string OrgUnit { get; set; }

        [LocalizedDisplayName("OuCode", NameResourceType = typeof (BillingReportingResource))]
        public string OuCode { get; set; }
        
        [LocalizedDisplayName("CostCenter", NameResourceType = typeof (BillingReportingResource))]
        public string CostCenter { get; set; }

        [LocalizedDisplayName("OriginMatCode", NameResourceType = typeof (BillingReportingResource))]
        public string OriginMatCode { get; set; }

        [LocalizedDisplayName("OtherInformation", NameResourceType = typeof (BillingReportingResource))]
        public string OtherInformation { get; set; }

        [LocalizedDisplayName("Remarks", NameResourceType = typeof (BillingReportingResource))]
        public string Remarks { get; set; }

    }
}