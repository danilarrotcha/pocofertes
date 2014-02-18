using System;
using System.Collections.Generic;

namespace Offers.Entities
{
    public partial class OfferReason : Repository.EntityBase
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
