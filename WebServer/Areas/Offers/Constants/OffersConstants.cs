
using System.Configuration;

namespace WebServer.Areas.Offers.Constants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Provides access to application constants
    /// </summary>
    public class OffersConstants
    {
        /// <summary>
        /// Gets the carousel enabled state
        /// </summary>
        public static bool EnableCarousel
        {
            get
            {
                var enabled = false;
                Boolean.TryParse(ConfigurationManager.AppSettings["carouselEnabled"], out enabled);

                return enabled;
            }
        }
    }
}