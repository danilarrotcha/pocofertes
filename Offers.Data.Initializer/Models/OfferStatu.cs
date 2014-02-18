using System;
using System.Collections.Generic;

namespace Offers.Data.Initializer.Models
{
    public partial class OfferStatu
    {
        public OfferStatu()
        {
            this.Offers = new List<Offer>();
        }

        public int OfferStatusID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
