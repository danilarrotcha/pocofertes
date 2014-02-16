
namespace WebServer.App_Start
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
            new ScriptBundle(BundleConstants.Scripts.Main).Include(
                      "~/Scripts/jquery/jquery-1.10.2.js",
                      "~/Scripts/twitter/bootstrap.js",
                      "~/Scripts/require/require.js"));
            
            bundles.Add(new StyleBundle(BundleConstants.Styles.GeneralCss).Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/site.css",
                      "~/Content/css/bootstrap-responsive.css",
                      "~/Content/css/angular-csp.css"));
        }
    }
}