using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.ScenarioTermination
{
    public class TerminationRoutingInfoLineViewModel
    {
        [LocalizedDisplayName("Item", NameResourceType = typeof (ScenarioTerminationResource))]
        public string Item { get; set; }

        [LocalizedDisplayName("Company", NameResourceType = typeof (ScenarioTerminationResource))]
        public string Company { get; set; }

        [LocalizedDisplayName("HolderName", NameResourceType = typeof (ScenarioTerminationResource))]
        public string HolderName { get; set; }

        [LocalizedDisplayName("SalaryNumber", NameResourceType = typeof (ScenarioTerminationResource))]
        public int SalaryNumber { get; set; }

        [LocalizedDisplayName("UserId", NameResourceType = typeof (ScenarioTerminationResource))]
        public string UserId { get; set; }

        [LocalizedDisplayName("Branch", NameResourceType = typeof (ScenarioTerminationResource))]
        public string Branch { get; set; }

        [LocalizedDisplayName("Application", NameResourceType = typeof (ScenarioTerminationResource))]
        public string Application { get; set; }

        [LocalizedDisplayName("RequestedDate", NameResourceType = typeof (ScenarioTerminationResource))]
        public DateTime RequestedDate { get; set; }

        [LocalizedDisplayName("RequestedBy", NameResourceType = typeof (ScenarioTerminationResource))]
        public string RequestedBy { get; set; }

        [LocalizedDisplayName("Status", NameResourceType = typeof (ScenarioTerminationResource))]
        public string Status { get; set; }

        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof (ScenarioTerminationResource))]
        public IEnumerable<SelectList> ContractNumber { get; set; }

        [LocalizedDisplayName("LineNumber", NameResourceType = typeof (ScenarioTerminationResource))]
        public int LineNumber { get; set; }

        [LocalizedDisplayName("Material", NameResourceType = typeof (ScenarioTerminationResource))]
        public string Material { get; set; }

        [LocalizedDisplayName("TargetQty", NameResourceType = typeof (ScenarioTerminationResource))]
        public int TargetQty { get; set; }

        [LocalizedDisplayName("Unit", NameResourceType = typeof (ScenarioTerminationResource))]
        public string Unit { get; set; }

        [LocalizedDisplayName("MaterialDescription", NameResourceType = typeof (ScenarioTerminationResource))]
        public string MaterialDescription { get; set; }

        [LocalizedDisplayName("ReasonForRejection", NameResourceType = typeof (ScenarioTerminationResource))]
        public IEnumerable<SelectList> ReasonForRejection { get; set; }

        [LocalizedDisplayName("ItemCategory", NameResourceType = typeof (ScenarioTerminationResource))]
        public string ItemCategory { get; set; }

        [LocalizedDisplayName("ContractStart", NameResourceType = typeof (ScenarioTerminationResource))]
        public DateTime ContractStart { get; set; }

        [LocalizedDisplayName("ContractEnd", NameResourceType = typeof (ScenarioTerminationResource))]
        public DateTime ContractEnd { get; set; }

        [LocalizedDisplayName("Currency", NameResourceType = typeof (ScenarioTerminationResource))]
        public string Currency { get; set; }

        [LocalizedDisplayName("Charges", NameResourceType = typeof (ScenarioTerminationResource))]
        public int Charges { get; set; }

        [LocalizedDisplayName("WbsElement", NameResourceType = typeof (ScenarioTerminationResource))]
        public int WbsElement { get; set; }

        [LocalizedDisplayName("PurchaseOrder", NameResourceType = typeof (ScenarioTerminationResource))]
        public int PurchaseOrder { get; set; }

        [LocalizedDisplayName("PoNumber", NameResourceType = typeof (ScenarioTerminationResource))]
        public int PoNumber { get; set; }

        [LocalizedDisplayName("MaterialPricing", NameResourceType = typeof (ScenarioTerminationResource))]
        public string MaterialPricing { get; set; }

        [LocalizedDisplayName("PriceGroup", NameResourceType = typeof (ScenarioTerminationResource))]
        public string PriceGroup { get; set; }
    }
}