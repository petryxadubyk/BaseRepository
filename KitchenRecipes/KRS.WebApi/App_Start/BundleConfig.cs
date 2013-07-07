using System.Web.Optimization;

namespace KRS.WebApi
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // either use a Content delivery networks
            bundles.UseCdn = false;

            // .debug.js, -vsdoc.js and .intellisense.js files 
            // are in BundleTable.Bundles.IgnoreList by default.
            // Clear out the list and add back the ones we want to ignore.
            // Don't add back .debug.js.
            bundles.IgnoreList.Clear();
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*intellisense.js");

            // Modernizer goes separate since it loads first
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/lib/modernizr-{version}.js"));

            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery",
                "//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js")
                .Include("~/Scripts/lib/jquery-{version}.js"));

            // 3rd Party JavaScript files
            bundles.Add(new ScriptBundle("~/bundles/extlibs")
                .Include(
                    // IE7 needs this
                    "~/Scripts/lib/json2.js",

                    // jQuery plugins
                    "~/Scripts/lib/jquery.mockjson.js",
                    "~/Scripts/lib/TrafficCop.js",
                    "~/Scripts/lib/infuser.js", //depends on TrafficCop

                    // Knockout and its plugins
                    "~/Scripts/lib/knockout-{version}.js",
                    "~/Scripts/lib/knockout.validation.js",
                    "~/Scripts/lib/knockout.dirtyFlag.js",
                    "~/Scripts/lib/knockout.command.js",
                    "~/Scripts/lib/knockout.activity.js",
                    "~/Scripts/lib/koExternalTemplateEngine.js",
                    "~/Scripts/lib/koExternalTemplateEngine_all.js",

                    // Other 3rd party libraries
                    "~/Scripts/lib/underscore.js",
                    "~/Scripts/lib/moment.js",
                    "~/Scripts/lib/sammy-{version}.js",
                    "~/Scripts/lib/amplify.*",
                    "~/Scripts/lib/toastr.js"
                ));

            // cross-browser behaviour resolve scripts
            bundles.Add(new ScriptBundle("~/bundles/infrastructure")
                .IncludeDirectory("~/Scripts/infrastructure/", "*.js", searchSubdirectories: true));

            // application scripts
            bundles.Add(new ScriptBundle("~/bundles/application")
                .IncludeDirectory("~/Scripts/app/", "*.js", searchSubdirectories: false));

            // mock scripts
            bundles.Add(new ScriptBundle("~/bundles/jsmocks")
                .IncludeDirectory("~/Scripts/app/mock", "*.js", searchSubdirectories: false));

            // CSS files
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/normalize.css")
                .Include("~/Content/base.css")
                .Include("~/Content/toastr.css")
                );

            // LESS files
            bundles.Add(new Bundle("~/Content/less",
                new LessTransform(), new CssMinify())
                .Include("~/Content/styles.less"));
        }
    }
}