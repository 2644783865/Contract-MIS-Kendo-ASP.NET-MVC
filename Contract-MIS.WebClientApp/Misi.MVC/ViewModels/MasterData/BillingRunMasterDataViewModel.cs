using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Misi.MVC.ViewModels.MasterData
{
    public class BillingRunMasterDataViewModel
    {
        public int BillingRunId { get; set; }

        public string SoldToPartyId { get; set; }

        public int Version { get; set; }

        public string CreatedDate { get; set; }

        public string Status { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

    }
}