using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Offers.Entities;
using Offers.DAL.Mapping;
using Repository.Providers.EntityFramework;


namespace Offers.DAL
{
    public partial class OffersContext : DataContext
    {
        static OffersContext()
        {
            Database.SetInitializer<OffersContext>(null);
        }

        public OffersContext()
            : base("Name=offersContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<MSreplication_options> MSreplication_options { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferNote> OfferNotes { get; set; }
        public DbSet<OfferReason> OfferReasons { get; set; }
        public DbSet<OfferStatus> OfferStatus { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
        public DbSet<spt_fallback_db> spt_fallback_db { get; set; }
        public DbSet<spt_fallback_dev> spt_fallback_dev { get; set; }
        public DbSet<spt_fallback_usg> spt_fallback_usg { get; set; }
        public DbSet<spt_monitor> spt_monitor { get; set; }
        public DbSet<spt_values> spt_values { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new ManagerMap());
            modelBuilder.Configurations.Add(new MSreplication_optionsMap());
            modelBuilder.Configurations.Add(new OfferMap());
            modelBuilder.Configurations.Add(new OfferNoteMap());
            modelBuilder.Configurations.Add(new OfferReasonMap());
            modelBuilder.Configurations.Add(new OfferStatusMap());
            modelBuilder.Configurations.Add(new OfferTypeMap());
            modelBuilder.Configurations.Add(new spt_fallback_dbMap());
            modelBuilder.Configurations.Add(new spt_fallback_devMap());
            modelBuilder.Configurations.Add(new spt_fallback_usgMap());
            modelBuilder.Configurations.Add(new spt_monitorMap());
            modelBuilder.Configurations.Add(new spt_valuesMap());
        }
    }
}
