using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Offers.Data.Initializer.Models.Mapping
{
    public class OfferReasonMap : EntityTypeConfiguration<OfferReason>
    {
        public OfferReasonMap()
        {
            // Primary Key
            this.HasKey(t => t.ReasonID);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("OfferReasons");
            this.Property(t => t.ReasonID).HasColumnName("ReasonID");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
