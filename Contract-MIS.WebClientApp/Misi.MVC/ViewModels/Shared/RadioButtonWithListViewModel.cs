using System.Collections;
using System.Collections.Generic;

namespace Misi.MVC.ViewModels.Shared
{
    public class RadioButtonWithListViewModel
    {
        /// <summary>
        /// Values to provide in the radio button list
        /// </summary>
        public IEnumerable<RadioButtonData> RadioButtons { set; get; }

        /// <summary>
        /// List of columns and their record. The number of rows
        /// is always same with the number of rows in the RadioButtons prop.
        /// </summary>
        public IEnumerable<IDictionary<string, string>> Columns { get; set; }

        /// <summary>
        /// Value returns in the post form
        /// </summary>
        public string SelectedValue { get; set; }
    }
}