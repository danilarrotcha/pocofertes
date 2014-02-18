using System;
using System.Collections.Generic;

namespace Offers.Data.Initializer.Models
{
    public partial class Manager
    {
        public Manager()
        {
            this.Offers = new List<Offer>();
        }

        public int ManagerID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
