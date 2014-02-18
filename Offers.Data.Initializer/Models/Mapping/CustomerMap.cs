using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Offers.Data.Initializer.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SurName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Customers");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SurName).HasColumnName("SurName");
            this.Property(t => t.IsClient).HasColumnName("IsClient");
        }
    }
}
