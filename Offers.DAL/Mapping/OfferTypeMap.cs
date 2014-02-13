using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Offers.Entities;

namespace Offers.DAL.Mapping
{
    public class OfferTypeMap : EntityTypeConfiguration<OfferType>
    {
        public OfferTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.OfferTypeID);

            // Properties
            this.Property(t => t.OfferTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OfferType");
            this.Property(t => t.OfferTypeID).HasColumnName("OfferTypeID");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
