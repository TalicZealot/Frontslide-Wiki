using System.Web;
using System.Web.Optimization;

namespace SotnWiki.MvcClient
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                        "~/Scripts/spa/navigo.min.js",
                        "~/Scripts/spa/navigo-router.js",
                        "~/Scripts/spa/row-generator.js",
                        "~/Scripts/spa/leaderboards-controller.js",
                        "~/Scripts/spa/indexjs"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                      "~/Scripts/menu-extend.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));
        }
    }
}
