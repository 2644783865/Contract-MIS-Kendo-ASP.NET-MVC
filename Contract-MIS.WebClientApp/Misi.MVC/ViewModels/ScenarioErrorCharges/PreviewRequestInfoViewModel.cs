using System.Collections.Generic;
using System.Security.Principal;

namespace Misi.MVC.ViewModels.ScenarioErrorCharges
{
    public class PreviewRequestInfoViewModel
    {
        public IEnumerable<PreviewRequestInfoTableViewModel> PreviewRequestInfoTableViewModel;
        public IEnumerable<PreviewRequestInfoSubTableViewModel> PreviewRequestInfoSubTableViewModel;
    }
}