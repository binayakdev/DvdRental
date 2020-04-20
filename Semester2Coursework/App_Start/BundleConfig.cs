using System.Web;
using System.Web.Optimization;

namespace Semester2Coursework
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/solmusic/jquery-3.2.1.min.js",  
                      "~/Scripts/solmusic/jquery.slicknav.min.js",
                      "~/Scripts/solmusic/owl.carousel.min.js",
                      "~/Scripts/solmusic/mixitup.min.js",
                      "~/Scripts/solmusic/main.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/owl.carousel.min.css",
                      "~/Content/slicknav.min.css",
                      "~/Content/style.css"
                      ));

            bundles.Add(new StyleBundle("~/Fonts/css").Include(
                    "~/Fonts/fontawesome.css"
                ));
        }
    }
}
