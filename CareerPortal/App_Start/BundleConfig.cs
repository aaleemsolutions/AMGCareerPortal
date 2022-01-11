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



            bundles.Add(new StyleBundle("~/bundles/CandidateThemesCSS").Include(
                    "~/CndDashboardAssets/vendors/feather/feather.css",
                    "~/CndDashboardAssets/vendors/ti-icons/css/themify-icons.css",
                    "~/CndDashboardAssets/vendors/css/vendor.bundle.base.css",
                    "~/CndDashboardAssets/vendors/datatables.net-bs4/dataTables.bootstrap4.css",
                    "~/CndDashboardAssets/vendors/dropify/dropify.min.css",
                    "~/CndDashboardAssets/css/vertical-layout-light/style.css",
                    "~/Content/CustomStyle.css",
                    "~/CndDashboardAssets/vendors/jquery-toast-plugin/jquery.toast.min.css",
                    "~/CndDashboardAssets/vendors/bootstrap-datepicker/bootstrap-datepicker.min.css",
                    "~/CndDashboardAssets/SummerNote/summernote.min.css"


        ));

            bundles.Add(new ScriptBundle("~/bundles/CandidateThemesJS").Include(
                    "~/Scripts/jquery-3.4.1.min.js",
                    "~/Scripts/jquery-ui-1.13.0.js",
                    "~/Scripts/jquery.inputmask.bundle.min.js",
                    "~/CndDashboardAssets/vendors/js/vendor.bundle.base.js",
                    "~/CndDashboardAssets/vendors/dropify/dropify.min.js",
                    "~/CndDashboardAssets/vendors/jquery-steps/jquery.steps.min.js",
                    "~/CndDashboardAssets/vendors/jquery-validation/jquery.validate.min.js",
                    "~/CndDashboardAssets/vendors/inputmask/jquery.inputmask.bundle.js",
                    "~/CndDashboardAssets/vendors/quill/quill.min.js",
                    "~/CndDashboardAssets/vendors/datatables.net/jquery.dataTables.js",
                    "~/CndDashboardAssets/vendors/datatables.net-bs4/dataTables.bootstrap4.js",
                    "~/CndDashboardAssets/vendors/jquery-toast-plugin/jquery.toast.min.js",
                    "~/CndDashboardAssets/vendors/sweetalert/sweetalert.min.js",
                    "~/CndDashboardAssets/vendors/jquery.avgrund/jquery.avgrund.min.js",
                       "~/CndDashboardAssets/vendors/bootstrap-datepicker/bootstrap-datepicker.min.js",
                "~/CndDashboardAssets/js/inputmask.js",
                "~/CndDashboardAssets/js/jquery.cookie.js",
                "~/CndDashboardAssets/js/formpickers.js",
                "~/CndDashboardAssets/js/alerts.js",
                "~/CndDashboardAssets/js/avgrund.js",
                "~/CndDashboardAssets/js/off-canvas.js",
                "~/CndDashboardAssets/js/hoverable-collapse.js",
                "~/CndDashboardAssets/js/template.js",
                "~/CndDashboardAssets/js/settings.js",
                "~/CndDashboardAssets/js/todolist.js",
                "~/CndDashboardAssets/js/wizard.js",
                "~/CndDashboardAssets/js/dropify.js",
                "~/CndDashboardAssets/js/editorDemo.js",
                "~/CndDashboardAssets/js/data-table.js",
                "~/CndDashboardAssets/js/toastDemo.js",
                "~/Scripts/Main.js",
                "~/CndDashboardAssets/SummerNote/summernote.min.js"

               ));


            bundles.Add(new StyleBundle("~/bundles/RecruiterThemesCSS").Include(
                    "~/CndDashboardAssets/vendors/feather/feather.css",
                    "~/CndDashboardAssets/vendors/ti-icons/css/themify-icons.css",
                    "~/CndDashboardAssets/vendors/css/vendor.bundle.base.css",
                    "~/CndDashboardAssets/vendors/datatables.net-bs4/dataTables.bootstrap4.css",
                    "~/CndDashboardAssets/vendors/dropify/dropify.min.css",
                    "~/CndDashboardAssets/css/vertical-layout-light/style.css",
                    "~/Content/CustomStyle.css",
                    "~/CndDashboardAssets/vendors/jquery-toast-plugin/jquery.toast.min.css",
                    "~/CndDashboardAssets/vendors/bootstrap-datepicker/bootstrap-datepicker.min.css",
                    "~/CndDashboardAssets/SummerNote/summernote.min.css"


        ));

            bundles.Add(new ScriptBundle("~/bundles/RecruiterThemesAssets").Include(
                    "~/Scripts/jquery-3.4.1.min.js",
                    "~/Scripts/jquery-ui-1.13.0.js",
                    "~/Scripts/jquery.inputmask.bundle.min.js",
                    "~/CndDashboardAssets/vendors/js/vendor.bundle.base.js",
                    "~/CndDashboardAssets/vendors/dropify/dropify.min.js",
                    "~/CndDashboardAssets/vendors/jquery-steps/jquery.steps.min.js",
                    "~/CndDashboardAssets/vendors/jquery-validation/jquery.validate.min.js",
                    "~/CndDashboardAssets/vendors/inputmask/jquery.inputmask.bundle.js",
                    "~/CndDashboardAssets/vendors/quill/quill.min.js",
                    "~/CndDashboardAssets/vendors/datatables.net/jquery.dataTables.js",
                    "~/CndDashboardAssets/vendors/datatables.net-bs4/dataTables.bootstrap4.js",
                    "~/CndDashboardAssets/vendors/jquery-toast-plugin/jquery.toast.min.js",
                    "~/CndDashboardAssets/vendors/sweetalert/sweetalert.min.js",
                    "~/CndDashboardAssets/vendors/jquery.avgrund/jquery.avgrund.min.js",
                       "~/CndDashboardAssets/vendors/bootstrap-datepicker/bootstrap-datepicker.min.js",
                "~/CndDashboardAssets/js/inputmask.js",
                "~/CndDashboardAssets/js/jquery.cookie.js",
                "~/CndDashboardAssets/js/formpickers.js",
                "~/CndDashboardAssets/js/alerts.js",
                "~/CndDashboardAssets/js/avgrund.js",
                "~/CndDashboardAssets/js/off-canvas.js",
                "~/CndDashboardAssets/js/hoverable-collapse.js",
                "~/CndDashboardAssets/js/template.js",
                "~/CndDashboardAssets/js/settings.js",
                "~/CndDashboardAssets/js/todolist.js",
                "~/CndDashboardAssets/js/wizard.js",
                "~/CndDashboardAssets/js/dropify.js",
                "~/CndDashboardAssets/js/editorDemo.js",
                "~/CndDashboardAssets/js/data-table.js",
                "~/CndDashboardAssets/js/toastDemo.js",
               "~/CndDashboardAssets/js/jq.tablesort.js",
               "~/CndDashboardAssets/js/tablesorter.js",
                "~/Scripts/Main.js",
                "~/CndDashboardAssets/SummerNote/summernote.min.js"

               ));


            BundleTable.EnableOptimizations = true;

        }
    }
}
