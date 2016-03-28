using System.Collections.Generic;

namespace Misi.MVC.ViewModels.BillingReporting
{
    public class MaterialSubCategoryLineViewModel
    {
        public string MaterialSubCategoryName { get; set; }
        public string SubQty { get; set; }
        public string SubTotalCharges { get; set; } 
        public IEnumerable<DetailMaterialSubCategoryLineViewModel> DetailMaterialSubCategoryLineViewModels { get; set; } 

    }
}