using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NrdAkademija.Ef.entities;

namespace NrdAkademija.Ef
{
    public partial class NrdAkademija2018Context : DbContext
    {
        public NrdAkademija2018Context(DbContextOptions<NrdAkademija2018Context> options)
    : base(options)
        { }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeInventory> EmployeeInventory { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryType> InventoryType { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.Workplace).IsRequired();
            });

            modelBuilder.Entity<EmployeeInventory>(entity =>
            {
                entity.HasKey(e => new { e.InventoryId, e.EmployeeId });

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeInventory)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeI__Emplo__2A4B4B5E");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.EmployeeInventory)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeI__Inven__2B3F6F97");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK__Inventory__Type__25869641");
            });

            modelBuilder.Entity<InventoryType>(entity =>
            {
                entity.ToTable("Inventory_Type");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}
