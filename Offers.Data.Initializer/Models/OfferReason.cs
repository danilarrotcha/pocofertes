using System;
using System.Collections.Generic;

namespace Offers.Data.Initializer.Models
{
    public partial class OfferReason
    {
        public OfferReason()
        {
            this.Offers = new List<Offer>();
        }

        public int ReasonID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
