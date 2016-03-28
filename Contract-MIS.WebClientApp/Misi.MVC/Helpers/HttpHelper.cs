using System;
using System.Collections;
using System.Web;

namespace Misi.MVC.Helpers
{
    public class HttpHelper
    {
        public static void ClearCache()
        {
            IDictionaryEnumerator enumerator = HttpContext.Current.Cache.GetEnumerator();

            while (enumerator.MoveNext())
            {
                HttpContext.Current.Cache.Remove(Convert.ToString(enumerator.Key));
            }
        }
    }
}