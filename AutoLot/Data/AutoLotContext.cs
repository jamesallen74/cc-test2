using Microsoft.EntityFrameworkCore;
using AutoLot.Models;

namespace AutoLot.Data
{
    public class AutoLotContext : DbContext
    {
        public AutoLotContext(DbContextOptions<AutoLotContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Make).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Model).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Trim).HasMaxLength(50);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
                entity.Property(e => e.Color).HasMaxLength(30);
                entity.Property(e => e.Engine).HasMaxLength(100);
                entity.Property(e => e.Transmission).HasMaxLength(50);
                entity.Property(e => e.FuelType).HasMaxLength(20);
                entity.Property(e => e.Drivetrain).HasMaxLength(20);
                entity.Property(e => e.Features).HasMaxLength(1000);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.VIN).HasMaxLength(17);
                entity.Property(e => e.DateAdded).HasDefaultValueSql("datetime('now')");
            });
        }
    }
}