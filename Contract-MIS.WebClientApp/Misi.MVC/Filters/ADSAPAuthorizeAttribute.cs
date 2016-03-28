using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Misi.MVC.Helpers;

namespace Misi.MVC.Filters
{
    public class ADSAPAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                UserManagementHelper.GetSessionId();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}