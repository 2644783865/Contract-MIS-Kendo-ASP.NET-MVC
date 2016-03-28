using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioTransferAssets
{
    public class RoutingInfoViewModel
    {
        [LocalizedDisplayName("RoutingTable", NameResourceType = typeof (Resources.SharedResource))]
        public IEnumerable<RoutingTableLine> RoutingTableLines { get; set; }

        [LocalizedDisplayName("PredScenario", NameResourceType = typeof (Resources.SharedResource))]
        public PredScenarioViewModel PredScenarioViewModel { get; set; }

        [LocalizedDisplayName("OldHolderName", NameResourceType = typeof (Resources.SharedResource))]
        public string OldHolderName { get; set; }

        [LocalizedDisplayName("OldSalaryNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string OldSalaryNumber { get; set; }

        [LocalizedDisplayName("OldLocation", NameResourceType = typeof (Resources.SharedResource))]
        public string OldLocation { get; set; }

        [LocalizedDisplayName("NewContractNumber", NameResourceType = typeof (Resources.SharedResource))]
        public NewContractNumberViewModel NewContractNumberViewModel { get; set; }

        [LocalizedDisplayName("ReturnDeliveryOrder", NameResourceType = typeof (Resources.SharedResource))]
        public IEnumerable<SelectListItem> ReturnDeliveryOrderList { get; set; }

        [LocalizedDisplayName("NewHolderName", NameResourceType = typeof (Resources.SharedResource))]
        public IEnumerable<SelectListItem> NewHolderNameList { get; set; }

        [LocalizedDisplayName("NewSalaryNumber", NameResourceType = typeof (Resources.SharedResource))]
        public IEnumerable<SelectListItem> NewSalaryNumberList { get; set; }

        [LocalizedDisplayName("SoDeliveryNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string SoDeliveryNumber { get; set; }

        [LocalizedDisplayName("DeliveryOrderToUser", NameResourceType = typeof (Resources.SharedResource))]
        public string DeliveryOrderToUser { get; set; }
    }

    public class PredScenarioViewModel
    {
        [LocalizedDisplayName("Scenarios", NameResourceType = typeof (Resources.SharedResource))]
        public IEnumerable<SelectListItem> Scenarios { get; set; }

        public string TransferAssetType { get; set; }
    }


    public class RoutingTableLine
    {
        [LocalizedDisplayName("Step", NameResourceType = typeof (Resources.SharedResource))]
        public int Step { get; set; }

        [LocalizedDisplayName("Division", NameResourceType = typeof (Resources.SharedResource))]
        public string Division { get; set; }

        [LocalizedDisplayName("Instruction", NameResourceType = typeof (Resources.SharedResource))]
        public string Instruction { get; set; }

        [LocalizedDisplayName("Response", NameResourceType = typeof (Resources.SharedResource))]
        public string Response { get; set; }

        [LocalizedDisplayName("CompletionDate", NameResourceType = typeof (Resources.SharedResource))]
        public IEnumerable<CompletionDateTable> CompletionDateTables { get; set; }

        [LocalizedDisplayName("Complete", NameResourceType = typeof (Resources.SharedResource))]
        public IEnumerable<CompleteTable> CompleteTables { get; set; }
    }

    public class CompleteTable
    {
        [LocalizedDisplayName("InProgress", NameResourceType = typeof (Resources.SharedResource))]
        public string InProgress { get; set; }
    }

    public class CompletionDateTable
    {
        [LocalizedDisplayName("BaseLine", NameResourceType = typeof (Resources.SharedResource))]
        public string BaseLine { get; set; }

        [LocalizedDisplayName("Plan", NameResourceType = typeof (Resources.SharedResource))]
        public string Plan { get; set; }

        [LocalizedDisplayName("Actual", NameResourceType = typeof (Resources.SharedResource))]
        public string Actual { get; set; }
    }
}