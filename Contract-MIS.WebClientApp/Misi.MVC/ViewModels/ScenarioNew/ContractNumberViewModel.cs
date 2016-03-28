using Misi.MVC.Filters;

namespace Misi.MVC.ViewModels.ScenarioNew
{
    public class ContractNumberViewModel
    {
        [LocalizedDisplayName("ContractNumber", NameResourceType = typeof(Resources.SharedResource))]
        public string ContractNumber { get; set; }

        [LocalizedDisplayName("ContractLineNumber", NameResourceType = typeof(Resources.SharedResource))]
        public string ContractLineNumber { get; set; }
    }
}