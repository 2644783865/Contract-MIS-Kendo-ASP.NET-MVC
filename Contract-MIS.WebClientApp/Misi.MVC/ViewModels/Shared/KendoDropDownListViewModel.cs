namespace Misi.MVC.ViewModels.Shared
{
    public class KendoDropDownListViewModel
    {
        /// <summary>
        /// Selected item
        /// </summary>
        public string SelectedItem { get; set; }

        /// <summary>
        /// Default value
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Text field retrieved from the action method
        /// </summary>
        public string DataTextField { get; set; }

        /// <summary>
        /// Value field retrieved from the action method
        /// </summary>
        public string DataValueField { get; set; }

        /// <summary>
        /// Message to display on the top of the dropdown list
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// Controller invoked to retrieve all the items of the list
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// Action invoked to retrieve all the items of the list
        /// </summary>
        public string Action { get; set; } 
    }
}