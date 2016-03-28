using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Misi.MVC.ViewModels.Shared
{
    public class RadioButtonViewModel
    {
        /// <summary>
        /// Values to provide in the radio button list
        /// </summary>
        public IEnumerable<RadioButtonData> Data { set; get; }

        /// <summary>
        /// Value returns in the post form
        /// </summary>
        public string SelectedValue { get; set; }

    }
}