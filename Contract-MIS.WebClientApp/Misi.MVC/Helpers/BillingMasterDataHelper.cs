using System;
using System.Collections.Generic;
using Misi.MVC.Resources;
using Misi.MVC.SAPServiceClient;
using Misi.MVC.ViewModels.MasterData;
using System.Linq;

namespace Misi.MVC.Helpers
{
    public class BillingMasterDataHelper
    { 
        public static IEnumerable<BillingRunMasterDataViewModel> GenerateBillingRunMasterDataViewModel(string soldToPartyId, InvoiceProformaBillingRunDTO[] serviceModel)
        {
            var allBillingRun = serviceModel.Select(e => new BillingRunMasterDataViewModel
            {
                BillingRunId = e.No,
                CreatedDate = e.Created.ToString(ConfigResource.FormatDate),
                SoldToPartyId = e.SoldToParty,
                Status = SharedResource.Draft,
                Version = e.Version
            });
            
            // if sold to party NA is chosen, then all list are returned
            return soldToPartyId == SharedResource.NA ? allBillingRun.ToList() :
                allBillingRun.Where(bil => bil.SoldToPartyId == soldToPartyId).ToList();
        }

        public static IEnumerable<BillingRunMasterDataViewModel> GenerateBillingRunMasterDataViewModel(InvoiceProformaBillingRunDTO[] serviceModel)
        {
            var allBillingRun = serviceModel.Select(e => new BillingRunMasterDataViewModel
            {
                BillingRunId = e.No,
                CreatedDate = e.Created.ToString(ConfigResource.FormatDate),
                SoldToPartyId = e.SoldToParty,
                Status = e.Draft ? SharedResource.Draft : SharedResource.Final,
                Version = e.Version,
                StartDate = e.StartDate.ToString(ConfigResource.FormatDate),
                EndDate = e.EndDate.ToString(ConfigResource.FormatDate)
            });

            // if sold to party NA is chosen, then all list are returned
            return allBillingRun.ToList();
        }
    }
}