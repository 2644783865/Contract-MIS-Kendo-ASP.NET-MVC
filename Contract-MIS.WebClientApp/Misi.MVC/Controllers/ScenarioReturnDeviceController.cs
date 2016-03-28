using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Misi.MVC.Helpers;
using Misi.MVC.Resources;
using Misi.MVC.ViewModels.ScenarioReturnDevice;

namespace Misi.MVC.Controllers
{
    [HandleError]
    public class ScenarioReturnDeviceController : Controller
    {
        //
        // GET: /ScenarioReturnDevice/
        public ActionResult Index()
        {
            return RedirectToAction("CreateRequestInfo");
        }

        public ActionResult CreateRequestInfo()
        {
            var viewModel = ScenarioReturnDeviceHelper.GenerateRequestInfoViewModel();
            return View(viewModel);
        }

        public ActionResult Preview()
        {
            var viewModel = ScenarioReturnDeviceHelper.GeneratePreviewReturnDeviceViewModel();
            return View(viewModel);
        }

        //[HttpPost]
        //public ActionResult CreateRequestInfo(RequestInfoHeadingViewModel iModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ModelState.AddModelError("", ErrorResources.FormFieldNotValid);
        //        iModel = (RequestInfoHeadingViewModel)ScenarioFormHelper.GenerateViewModel(ScenarioType.RequestInfoHeadingViewModel);
        //        return View(iModel);
        //    }

        //    // pemrosesan ke WCF 

        //    return RedirectToAction("CreateRequestInfo", "ScenarioReturnDevice");
        //}

        /// <summary>
        /// TODO: 1. Buat Action Result untuk Get 
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateRoutingInfo()
        {
            //TODO: 2. Instansiasi view model dari Sub Scenario X
            var viewModel = ScenarioFormHelper.GenerateViewModel(ScenarioType.ReturnDevice);

            //TODO: 3. Parsing model ke View
            return View(viewModel);
        }

        /// <summary>
        /// TODO: 4. Setelah View untuk form disiapkan, buat Action Result untuk Post
        /// Beri nama yang SAMA dengan fungsi GET
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateRoutingInfo(RoutingInfoReturnDeviceViewModel iModel)
        {
            // Dicek dulu apakah 
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorResource.FormFieldNotValid);
                iModel = (RoutingInfoReturnDeviceViewModel)
                    ScenarioFormHelper.GenerateViewModel(ScenarioType.ReturnDevice);

                return View(iModel);
            }

            // Di sini nanti ada pemrosesan ke Service

            // Setelah itu diredirect ke halaman selanjutnya
            return RedirectToAction("CreateRoutingInfo");
        }
    }
}