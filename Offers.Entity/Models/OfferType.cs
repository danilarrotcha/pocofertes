using System;
using System.Collections.Generic;

namespace Offers.Entities
{
    public partial class OfferType : Repository.EntityBase
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
