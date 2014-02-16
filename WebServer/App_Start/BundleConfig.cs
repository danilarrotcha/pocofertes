
namespace WebServer.App_Start
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(BundleConstants.Scripts.Jquery).Include(
                        "~/Scripts/jquery/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle(BundleConstants.Scripts.AngularJs)
                 .Include("~/Scripts/angular/angular.js")
            );

            bundles.Add(new ScriptBundle(BundleConstants.Scripts.AngularJsUiBootstrap)
                .Include("~/Scripts/angular/ui-bootstrap-0.10.0.js")    
            );

            bundles.Add(new ScriptBundle(BundleConstants.Scripts.TwitterUiBootstrap).Include(
                      "~/Scripts/twitter/bootstrap.js"));
            bundles.Add(new ScriptBundle(BundleConstants.Scripts.App).Include(
                      "~/Scripts/app/app.js"));
            
            bundles.Add(new StyleBundle(BundleConstants.Styles.GeneralCss).Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/site.css",
                      "~/Content/css/bootstrap-responsive.css",
                      "~/Content/css/angular-csp.css"));
        }
    }
}