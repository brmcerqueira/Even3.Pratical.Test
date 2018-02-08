using System.Web.Optimization;

namespace Even3.Pratical.Test.Presentation
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/ui").Include(
                "~/Scripts/jquery-3.0.0.slim.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-route.min.js",
                "~/Scripts/angular-sanitize.min.js",
                "~/Scripts/webcam.min.js",
                "~/Scripts/angular-clock.min.js",
                "~/Scripts/main-ui.js"));

            bundles.Add(new AngularTemplateCacheBundle("even3-pratical-test", "~/bundles/views").Include(
                "~/Presentation/Ui/Views/*.html"));


            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Presentation/Ui/Styles/main.css",
                "~/Presentation/Ui/Styles/angular-clock.css"));
        }
    }
}