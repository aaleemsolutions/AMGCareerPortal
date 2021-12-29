using System.Web;
using System.Web.Optimization;

namespace CareerPortal
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/ThemeCss").Include(
                "~/assets/css/bootstrap.min.css",
                "~/assets/css/font-awesome.min.css",
                "~/assets/css/style.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/ThemeJS").Include(
                      "~/assets/js/jquery-3.4.1.min.js",
                      "~/assets/plugins/owl.carousel.js",
                      "~/assets/plugins/slick.js",
                      "~/assets/js/popper.min.js",
                      "~/assets/js/bootstrap.min.js",
                      "~/assets/js/slider.js",
                      "~/assets/js/main.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/ThemeOtherPagesJS").Include(
                
                "~/assets/js/jquery-3.4.1.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js",
                

                "~/assets/js/popper.min.js",
                "~/assets/js/bootstrap.min.js",
                
                "~/assets/js/main.js"
                ));

        }
    }
}
