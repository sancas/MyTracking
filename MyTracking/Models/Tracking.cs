namespace MyTracking.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Tracking : DbContext
    {
        public Tracking()
            : base("name=Tracking")
        {
        }

        public virtual DbSet<Arrive> Arrives { get; set; }
        public virtual DbSet<Package> Packages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>()
                .HasMany(e => e.Arrives)
                .WithRequired(e => e.Package)
                .HasForeignKey(e => e.IdPackage)
                .WillCascadeOnDelete(false);
        }
    }
}
