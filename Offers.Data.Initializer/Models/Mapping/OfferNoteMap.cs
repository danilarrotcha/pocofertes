using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Offers.Data.Initializer.Models.Mapping
{
    public class OfferNoteMap : EntityTypeConfiguration<OfferNote>
    {
        public OfferNoteMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Content)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("OfferNotes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OfferID).HasColumnName("OfferID");
            this.Property(t => t.Content).HasColumnName("Content");
        }
    }
}
