using System;
using System.Collections.Generic;

namespace Offers.Entities
{
    public partial class OfferReason : Repository.EntityBase
    {
        public int ReasonID { get; set; }
        public string Description { get; set; }
    }
}
