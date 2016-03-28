using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Misi.MVC.Filters;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioGeneral;

namespace Misi.MVC.ViewModels.ScenarioErrorCharges
{
    public class RequestInfoViewModel
    {
        public RequestInfoHeadingViewModel RequestInfoMainViewModel { get; set; }
    }
}