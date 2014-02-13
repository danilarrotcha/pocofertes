using System;
using System.Collections.Generic;

namespace Offers.Entities
{
    public partial class Offer : Repository.EntityBase
    {
        public int OfferID { get; set; }
        public int OfferTypeID { get; set; }
        public int OfferStatusID { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> FollowedOn { get; set; }
        public Nullable<int> SuccessAmount { get; set; }
        public int ReasonID { get; set; }
        public string Description { get; set; }
        public decimal PriceAmount { get; set; }
        public int CustomerID { get; set; }
        public int ManagerID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
