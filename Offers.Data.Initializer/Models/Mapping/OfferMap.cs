using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Offers.Data.Initializer.Models.Mapping
{
    public class OfferMap : EntityTypeConfiguration<Offer>
    {
        public OfferMap()
        {
            // Primary Key
            this.HasKey(t => t.OfferID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Offer");
            this.Property(t => t.OfferID).HasColumnName("OfferID");
            this.Property(t => t.OfferTypeID).HasColumnName("OfferTypeID");
            this.Property(t => t.OfferStatusID).HasColumnName("OfferStatusID");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.FollowedOn).HasColumnName("FollowedOn");
            this.Property(t => t.SuccessAmount).HasColumnName("SuccessAmount");
            this.Property(t => t.ReasonID).HasColumnName("ReasonID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.PriceAmount).HasColumnName("PriceAmount");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.ManagerID).HasColumnName("ManagerID");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Offers)
                .HasForeignKey(d => d.CustomerID);
            this.HasRequired(t => t.Manager)
                .WithMany(t => t.Offers)
                .HasForeignKey(d => d.ManagerID);
            this.HasRequired(t => t.OfferReason)
                .WithMany(t => t.Offers)
                .HasForeignKey(d => d.ReasonID);
            this.HasRequired(t => t.OfferStatu)
                .WithMany(t => t.Offers)
                .HasForeignKey(d => d.OfferStatusID);
            this.HasRequired(t => t.OfferType)
                .WithMany(t => t.Offers)
                .HasForeignKey(d => d.OfferTypeID);

        }
    }
}
