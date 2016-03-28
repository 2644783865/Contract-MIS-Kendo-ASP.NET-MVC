using System;
using System.Collections.Generic;
using System.Web;
using Elmah;
using Misi.MVC.Resources;

namespace Misi.MVC.Helpers
{
    public class UserManagementHelper
    {
        /// <summary>
        /// Temporary solution to get unique Session ID
        /// </summary>
        /// <returns></returns>
        public static string GetSessionId()
        {
            if (HttpContext.Current.Session["SessionId"] != null)
                return HttpContext.Current.Session["SessionId"] as string;

            ErrorSignal.FromCurrentContext().Raise(new Exception(AccountResource.NotAuthorized));
            throw new Exception(AccountResource.NotAuthorized);
        }

        /// <summary>
        /// To get SAP User from given AD User
        /// </summary>
        /// <param name="adUsername"></param>
        /// <returns></returns>
        public static string GetSAPUser(string adUsername)
        {
            return SapUserDictionary[adUsername];
        }

        /// <summary>
        /// Map SAP username here!!
        /// </summary>
        private static readonly IDictionary<string, string> SapUserDictionary = new Dictionary<string, string>
        {
            {"bachtiar.julianto", "xb035467bcj"},
            {"hendra.oscar", "xupj21hoc"},
            {"maria.susan", "XM033006MSU"},
            {"dwi.rantika", "XD036502DRA"},
            {"yetta.nydia", "XY034363YTN"},

            //TODO:please comment the following users if it is deployed on Production
            {"annisa.nadya","ECEOS.HORASI"},
            {"alfan.zahriyono","ECEOS.HORASI"},
            {"bromo.adji","ECEOS.BROMO"},
            {"febri.ardiansyah","ECEOS.HORASI"},
            {"yulianik.indarwati", "MISI1"},
            {"agnies.adyan", "ECEOS.BROMO"},
            {"agus.setiawan", "MSTWEB"},
            {"adha.liyanto", "MSTWEB"},
            {"karnoto.suhartono", "MSTWEB"}
        };

        /// <summary>
        /// Set UserSession to store username SAP and password SAP delimited by :
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passwordSap"></param>
        public static void SetUserSession(string userName, string passwordSap)
        {
            // By Default, use ECEOS.BROMO password: trakindo1
            var usernameSAP = SapUserDictionary[userName];
            if (usernameSAP == null)
                throw new Exception(AccountResource.AccountController_Login_The_SAP_credential_provided_is_neither_valid_nor_incorrect_);


            HttpContext.Current.Session["SessionId"] = string.Format("{0}:{1}:{2}:{3}", usernameSAP, passwordSap, 
                ReflectionHelper.GenerateRandomString(6),userName);
        }

        public static string GetADUsername()
        {
            return HttpContext.Current.Session["SessionId"] != null
                ? (HttpContext.Current.Session["SessionId"] as string).Split(':')[3]
                : string.Empty;
        }

        public static void ClearSessionId()
        {
            HttpContext.Current.Session["SessionId"] = null;
            HttpContext.Current.Session.Abandon();
        }
    }
}