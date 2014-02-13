using System;
using System.Collections.Generic;

namespace Offers.Entities
{
    public partial class OfferNote : Repository.EntityBase
    {
        public int Id { get; set; }
        public int OfferID { get; set; }
        public string Content { get; set; }
    }
}
