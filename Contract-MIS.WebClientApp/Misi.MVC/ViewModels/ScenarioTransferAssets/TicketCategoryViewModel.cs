using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioTransferAssets
{
    public class TicketCategoryViewModel
    {
        public string TicketCategory { get; set; }

        [LocalizedDisplayName("DetailCategory", NameResourceType = typeof (Resources.ScenarioTransferAssetsResource))]
        public string DetailCategory { get; set; }
    }
}