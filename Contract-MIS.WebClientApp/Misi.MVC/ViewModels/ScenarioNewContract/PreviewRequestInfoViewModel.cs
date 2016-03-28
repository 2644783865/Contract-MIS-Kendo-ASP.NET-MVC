using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Misi.MVC.ViewModels.ScenarioNewContract
{
    public class PreviewRequestInfoViewModel
    {
        public IEnumerable<PreviewRequestInfoTableLineViewModel> PreviewRequestInfoTableLineViewModel;
        public IEnumerable<PreviewRequestInfoSubTableViewModel> PreviewRequestInfoSubTableViewModel;
    }
}