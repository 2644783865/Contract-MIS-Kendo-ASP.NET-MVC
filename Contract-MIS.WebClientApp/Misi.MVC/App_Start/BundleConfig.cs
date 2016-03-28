using System.Web.Optimization;

namespace Misi.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region ScriptBundles
            bundles.Add(new ScriptBundle("~/bundles/jquery", "//ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js").Include(
                           "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.

            bundles.Add(new ScriptBundle("~/bundles/bootstrap", "//maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //Scripts bundles for kendo
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/kendo/2014.3.1411/kendo.all.min.js",
                "~/Scripts/kendo/2014.3.1411/kendo.aspnetmvc.min.js"));

            //Custom scripts for admin-theme
            bundles.Add(new ScriptBundle("~/bundles/jsadmintheme").IncludeDirectory(
                "~/Scripts/admintheme", "*.js"));

            #endregion

            #region CSSBundles

            bundles.Add(new StyleBundle("~/Content/css", "//maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css").Include(
                      "~/Content/bootstrap.css"));

            //content css for kendo
            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                "~/Content/kendo/2014.3.1411/kendo.common-bootstrap.min.css",
                "~/Content/kendo/2014.3.1411/kendo.bootstrap.mobile.min.css",
                "~/Content/kendo/2014.3.1411/kendo.bootstrap.min.css"));

            //content css for admin theme
            bundles.Add(new StyleBundle("~/Content/cssadmintheme").Include(
                "~/Content/admin-theme.css",
                "~/Content/fontawesome/css/font-awesome.css")); 
            #endregion

            bundles.IgnoreList.Clear();

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
