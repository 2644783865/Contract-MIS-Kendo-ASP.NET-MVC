using System.ComponentModel.DataAnnotations;
using Misi.MVC.Filters;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioNew
{
    public class ScenarioAttributeNewScenarioViewModel : BaseScenarioAttributeViewModel
    {
        [Required]
        [LocalizedDisplayName("AttributeDescription", NameResourceType = typeof (Resources.ScenarioNewResource))]
        public string AttributeDescription { get; set; }
    }
}