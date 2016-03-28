using System.Collections.Generic;
using System.Web.Mvc;

namespace Misi.MVC.ViewModels.Shared
{
    public class DropDownListViewModel
    {
        public string PostData { get; set; }
        public IEnumerable<SelectListItem> Sources { get; set; }

    }
}