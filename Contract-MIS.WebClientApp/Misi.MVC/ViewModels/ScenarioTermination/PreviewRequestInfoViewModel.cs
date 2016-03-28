using System.Collections.Generic;
using System.Web.Mvc;
using Misi.MVC.Resources;

namespace Misi.MVC.ViewModels.ScenarioTermination
{
    public class PreviewRequestInfoViewModel
    {
        public IEnumerable<PreviewRequestInfoTableViewModel> PreviewRequestInfoTableViewModel { get; set; }
        public IEnumerable<PreviewRequestInfoTableLineViewModel> PreviewRequestInfoTableLineViewModel { get; set; }
        public IEnumerable<PreviewRequestInfoSubTableLineViewModel> PreviewRequestInfoSubTableLineViewModel { get; set; }
    }
}