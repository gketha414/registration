using System.Web;
using System.Web.Optimization;

namespace PreRegistration
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(

                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                         "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                             "~/Scripts/bootstrap.js",
                             "~/Scripts/moment.js",
                             "~/Scripts/DataTables/jquery.dataTables.js",
                             "~/Scripts/DataTables/dataTables.buttons.js",
                             "~/Scripts/bootstrap-datetimepicker.js",
                             "~/Scripts/jquery.pnotify.min.js",
                             "~/Scripts/jquery-ui.js",
                             "~/Scripts/jquery.inputmask.bundle.js",
                             "~/Scripts/DataTables/dataTables.select.min.js",
                             "~/Scripts/DataTables/dataTables.buttons.js",
                             "~/Scripts/DataTables/buttons.flash.js",
                             "~/Scripts/DataTables/buttons.html5.js",
                             "~/Scripts/DataTables/buttons.print.js",
                             "~/Scripts/DataTables/jszip.js",
                             "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/DataTables/css/responsive.dataTables.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/DataTables/css/buttons.dataTables.css",
                      "~/Content/jquery.pnotify.css",
                       "~/Content/jquery-ui.css",
                      "~/Content/font-awesome.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/site.css"));
        }
    }
}
