using System.Collections.Generic;

namespace Misi.MVC.ViewModels.BillingReporting
{
    public class DetailMaterialSubCategoryLineViewModel
    {
        public string MaterialNo { get; set; }
        public string MaterialDescription { get; set; }
        public string SubTotal { get; set; }
        public string MaterialQty { get; set; } 
        public string DetailMaterialRate { get; set; } 
        public IEnumerable<DetailSubMaterialDescriptionLineViewModel> DetailSubMaterialDescriptionLineViewModels { get; set; }
    }
}