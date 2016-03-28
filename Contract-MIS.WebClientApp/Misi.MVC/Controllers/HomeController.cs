using System.Web.Mvc;

namespace Misi.MVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            return RedirectToAction("Main", "ProformaInvoice");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}