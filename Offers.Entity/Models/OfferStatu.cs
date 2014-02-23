using System;
using System.Collections.Generic;

namespace Offers.Entities
{
    public partial class OfferStatus : Repository.EntityBase
    {
        public OfferStatus()
        {
            this.Offers = new List<Offer>();
        }

        public int OfferStatusID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
