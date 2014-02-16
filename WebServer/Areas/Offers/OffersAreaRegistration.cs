using System.Web.Mvc;

namespace WebServer.Areas.Offers
{
    public class OffersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Offers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Spa_default",
                "Areas/Offers/{action}/{id}",
                new { controller = "App", id = UrlParameter.Optional }
            );
        }
    }
}