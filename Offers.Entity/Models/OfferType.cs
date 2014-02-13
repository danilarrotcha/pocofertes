using System;
using System.Collections.Generic;

namespace Offers.Entities
{
    public partial class OfferType : Repository.EntityBase
    {
        public int OfferTypeID { get; set; }
        public string Description { get; set; }
    }
}
