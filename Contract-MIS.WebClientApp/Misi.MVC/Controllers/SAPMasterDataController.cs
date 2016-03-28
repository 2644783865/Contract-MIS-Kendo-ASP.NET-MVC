using System;
using System.Linq;
using System.Web.Mvc;
using Elmah;
using Misi.MVC.Helpers;
using Misi.MVC.Resources;
using Misi.MVC.ServiceClient;

namespace Misi.MVC.Controllers
{
    [HandleError]
    public class SAPMasterDataController : Controller
    {
        public JsonResult GetSoldToPartyJson()
        {
            string[] soldToParties = null;
            try
            {
                soldToParties = WCFClientManager.SAPServiceClient.QuerySoldToParties(UserManagementHelper.GetSessionId());
                soldToParties = soldToParties.GroupBy(e => e).Select(e => e.FirstOrDefault()).ToArray();
            }
            catch(Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return Json(JsonHelper.GenerateEmptyJson(), JsonRequestBehavior.AllowGet);
            }

            if (soldToParties == null || !soldToParties.Any())
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception(ErrorResource.WCFNullObject));
                return Json(JsonHelper.GenerateEmptyJson(), JsonRequestBehavior.AllowGet);
            }
            
            var jsonModel = JsonHelper.ConvertToJson(soldToParties);
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }
    }
}