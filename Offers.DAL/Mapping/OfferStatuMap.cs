using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Offers.Entities;

namespace Offers.DAL.Mapping
{
    public class OfferStatusMap : EntityTypeConfiguration<OfferStatus>
    {
        public OfferStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.OfferStatusID);

            // Properties
            this.Property(t => t.OfferStatusID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OfferStatus");
            this.Property(t => t.OfferStatusID).HasColumnName("OfferStatusID");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
