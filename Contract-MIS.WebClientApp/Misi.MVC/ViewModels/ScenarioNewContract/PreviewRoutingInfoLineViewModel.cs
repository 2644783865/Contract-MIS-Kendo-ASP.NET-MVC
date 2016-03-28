using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioNewCotract
{
    public class PreviewRoutingInfoLineViewModel
    {
        [LocalizedDisplayName("SubItem", NameResourceType = typeof (Resources.SharedResource))]
        public string SubItem { get; set; }

        [LocalizedDisplayName("RoutingCreationDate", NameResourceType = typeof (Resources.SharedResource))]
        public DateTime RoutingCreationDate { get; set; }

        [LocalizedDisplayName("IdrWebNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string IdrWebNumber { get; set; }

        [LocalizedDisplayName("QuotationNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string QuotationNumber { get; set; }

        //part of Contract Number
        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof (Resources.SharedResource))]
        public string ContractNumber { get; set; }

        //part of contract Number
        [LocalizedDisplayName("ContractNumberLine", NameResourceType = typeof (Resources.SharedResource))]
        public string ContractLineNumber { get; set; }

        //part of Predefined Scenario
        [LocalizedDisplayName("ScenarioName", NameResourceType = typeof (Resources.SharedResource))]
        public string ScenarioName { get; set; }

        //part of Predefined Scenario
        [LocalizedDisplayName("ScenarioType", NameResourceType = typeof (Resources.SharedResource))]
        public string ScenarioType { get; set; }

        [LocalizedDisplayName("RoutingMemo", NameResourceType = typeof (Resources.SharedResource))]
        public string RoutingMemo { get; set; }

        [LocalizedDisplayName("DivisionStatus", NameResourceType = typeof (Resources.SharedResource))]
        public bool DivisionStatus { get; set; }

        [LocalizedDisplayName("SaStatus", NameResourceType = typeof (Resources.SharedResource))]
        public bool SaStatus { get; set; }

        [LocalizedDisplayName("RoutingStatus", NameResourceType = typeof (Resources.SharedResource))]
        public string RoutingStatus { get; set; }

        [LocalizedDisplayName("ReasonForRejection", NameResourceType = typeof (Resources.SharedResource))]
        public IEnumerable<SelectListItem> ReasonForRejectionList { get; set; }
    }
}