using System;
using System.Collections.Generic;

namespace Offers.Data.Initializer.Models
{
    public partial class OfferNote
    {
        public int Id { get; set; }
        public int OfferID { get; set; }
        public string Content { get; set; }
    }
}
