using System;
using System.Collections.Generic;

namespace Offers.Data.Initializer.Models
{
    public partial class OfferType
    {
        public OfferType()
        {
            this.Offers = new List<Offer>();
        }

        public int OfferTypeID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
