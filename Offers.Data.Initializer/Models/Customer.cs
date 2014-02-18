using System;
using System.Collections.Generic;

namespace Offers.Data.Initializer.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.Offers = new List<Offer>();
        }

        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool IsClient { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
