using System.Web.Mvc;
using Misi.MVC.Helpers;
using Misi.MVC.Resources;

namespace Misi.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string errorKey = null)
        {
            var errorViewModel = new ViewModels.Error.ErrorViewModel();
            if (errorKey != null)
            {
                errorViewModel.ErrorNumber = errorKey;
                errorViewModel.ErrorMessage = ErrorResource.ResourceManager.GetString(errorKey);
            }
            else
            {
                errorViewModel.ErrorMessage = ErrorResource.UnknownError;
            }

            return View(errorViewModel);
        }

        public ActionResult Error404()
        {
            try
            {
                UserManagementHelper.GetSessionId();
            }
            catch
            {
                return View();
            }  
            return View("Error404Inside");
        }
    }
}