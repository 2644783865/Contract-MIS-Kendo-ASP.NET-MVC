using System;
using System.Web.UI.WebControls;
using Misi.MVC.Filters;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.ScenarioTermination
{
    public class PreviewRequestInfoSubTableLineViewModel
    {
        [LocalizedDisplayName("Item", NameResourceType = typeof (SharedResource))]
        public string Item { get; set; }

        [LocalizedDisplayName("Company", NameResourceType = typeof (SharedResource))]
        public string Company { get; set; }

        [LocalizedDisplayName("HolderName", NameResourceType = typeof (SharedResource))]
        public string HolderName { get; set; }

        [LocalizedDisplayName("SalaryNumber", NameResourceType = typeof (SharedResource))]
        public int SalaryNumber { get; set; }

        [LocalizedDisplayName("UserId", NameResourceType = typeof (SharedResource))]
        public string UserId { get; set; }

        [LocalizedDisplayName("Application", NameResourceType = typeof (SharedResource))]
        public string Application { get; set; }

        [LocalizedDisplayName("Status", NameResourceType = typeof (SharedResource))]
        public string Status { get; set; }

        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof (SharedResource))]
        public int ContractNumber { get; set; }

        [LocalizedDisplayName("LineNumber", NameResourceType = typeof (SharedResource))]
        public int LineNumber { get; set; }

        [LocalizedDisplayName("Material", NameResourceType = typeof (SharedResource))]
        public string Material { get; set; }

        [LocalizedDisplayName("TargetQty", NameResourceType = typeof (SharedResource))]
        public string TargetQty { get; set; }

        [LocalizedDisplayName("Unit", NameResourceType = typeof (SharedResource))]
        public string Unit { get; set; }

        [LocalizedDisplayName("MaterialDescription", NameResourceType = typeof (SharedResource))]
        public string MaterialDescription { get; set; }

        [LocalizedDisplayName("ReasonForRejection", NameResourceType = typeof (SharedResource))]
        public string ReasonForRejection { get; set; }

        [LocalizedDisplayName("ItemCategory", NameResourceType = typeof (SharedResource))]
        public string ItemCategory { get; set; }

        [LocalizedDisplayName("ContractStart", NameResourceType = typeof (SharedResource))]
        public DateTime ContractStart { get; set; }

        [LocalizedDisplayName("ContractEnd", NameResourceType = typeof(SharedResource))]
        public DateTime ContractEnd { get; set; }

        [LocalizedDisplayName("Currency", NameResourceType = typeof (SharedResource))]
        public string Currency { get; set; }

        [LocalizedDisplayName("Charges", NameResourceType = typeof (SharedResource))]
        public int Charges { get; set; }

        [LocalizedDisplayName("WbsElement", NameResourceType = typeof (SharedResource))]
        public int WbsElement { get; set; }

        [LocalizedDisplayName("Purchase", NameResourceType = typeof (SharedResource))]

        public int Purchase { get; set; }

        [LocalizedDisplayName("PoNumber", NameResourceType = typeof (SharedResource))]
        public int PoNumber { get; set; }

        [LocalizedDisplayName("MaterialPricing", NameResourceType = typeof (SharedResource))]
        public string MaterialPricing { get; set; }

        [LocalizedDisplayName("PriceGroup", NameResourceType = typeof(SharedResource))]
        public string PriceGroup { get; set; }
        
    }
}