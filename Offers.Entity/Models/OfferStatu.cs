using System;
using System.Collections.Generic;

namespace Offers.Entities
{
    public partial class OfferStatu : Repository.EntityBase
    {
        public int OfferStatusID { get; set; }
        public string Description { get; set; }
    }
}
