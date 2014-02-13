using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Offers.Entities;

namespace Offers.DAL.Mapping
{
    public class ManagerMap : EntityTypeConfiguration<Manager>
    {
        public ManagerMap()
        {
            // Primary Key
            this.HasKey(t => t.ManagerID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SurName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Managers");
            this.Property(t => t.ManagerID).HasColumnName("ManagerID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SurName).HasColumnName("SurName");
        }
    }
}
