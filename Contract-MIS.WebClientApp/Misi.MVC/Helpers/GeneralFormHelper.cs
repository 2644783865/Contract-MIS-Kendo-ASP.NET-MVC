using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.Helpers
{
    public class GeneralFormHelper
    {
        public static DropDownListViewModel GenerateDropDownListViewModel(string selected, bool isSelected,
            params string[] items)
        {
            return new DropDownListViewModel
            {
                PostData = selected,
                Sources = DictionaryHelper.ToSelectListItems(selected, isSelected, items)
            };
        }

        public static KendoDropDownListViewModel GenerateKendoDropDownListViewModel(string actionName, 
            string controllerName, string dataTextField, string dataValueField, string defaultValue)
        {
            return new KendoDropDownListViewModel
            {
                Action = actionName,
                Controller = controllerName,
                DataTextField = dataTextField,
                DataValueField = dataValueField,
                DefaultValue = defaultValue           
            };
        }


        public static KendoDropDownListViewModel GenerateKendoDropDownListViewModel(string actionName, string controllerName)
        {
            return new KendoDropDownListViewModel
            {
                Action = actionName,
                Controller = controllerName,
                DataTextField = "text",
                DataValueField = "value",
                DefaultValue = "1",
            };
        }
    }
}