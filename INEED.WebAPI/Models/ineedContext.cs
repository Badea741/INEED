using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace INEED.WebAPI.Models
{
    public partial class IneedContext : DbContext
    {
        public IneedContext()
        {
        }

        public IneedContext(DbContextOptions<IneedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<PropertyCategory> PropertyCategories { get; set; } = null!;
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
        public virtual DbSet<ServiceProvider> ServiceProviders { get; set; } = null!;
        public virtual DbSet<Unique> Uniques { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.PhoneNumber)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.EmailNavigation)
                    .WithOne(p => p.CustomerEmailNavigation)
                    .HasPrincipalKey<Unique>(p => p.Email)
                    .HasForeignKey<Customer>(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customers_ibfk_2");

                entity.HasOne(d => d.PhoneNumberNavigation)
                    .WithOne(p => p.CustomerPhoneNumberNavigation)
                    .HasForeignKey<Customer>(d => d.PhoneNumber)
                    .HasConstraintName("customers_ibfk_1");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.IsSent).HasDefaultValueSql("'0'");

                entity.HasOne(d => d.ReceiverPhoneNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ReceiverPhone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("messages_ibfk_2");

                entity.HasOne(d => d.SenderPhoneNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.SenderPhone)
                    .HasConstraintName("messages_ibfk_1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.IsSent).HasDefaultValueSql("'0'");

                entity.HasOne(d => d.CustomerPhoneNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerPhone)
                    .HasConstraintName("orders_ibfk_1");

                entity.HasOne(d => d.WorkerPhoneNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.WorkerPhone)
                    .HasConstraintName("orders_ibfk_2");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("properties_ibfk_1");
            });

            modelBuilder.Entity<PropertyCategory>(entity =>
            {
                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("propertyCategories_ibfk_1");
            });

            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("serviceCategories_ibfk_1");
            });

            modelBuilder.Entity<ServiceProvider>(entity =>
            {
                entity.HasKey(e => e.PhoneNumber)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.EmailNavigation)
                    .WithOne(p => p.ServiceProviderEmailNavigation)
                    .HasPrincipalKey<Unique>(p => p.Email)
                    .HasForeignKey<ServiceProvider>(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("serviceProviders_ibfk_3");

                entity.HasOne(d => d.PhoneNumberNavigation)
                    .WithOne(p => p.ServiceProviderPhoneNumberNavigation)
                    .HasForeignKey<ServiceProvider>(d => d.PhoneNumber)
                    .HasConstraintName("serviceProviders_ibfk_2");

                entity.HasOne(d => d.Service)
                    .WithOne(p => p.ServiceProvider)
                    .HasForeignKey<ServiceProvider>(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("serviceProviders_ibfk_1");
            });

            modelBuilder.Entity<Unique>(entity =>
            {
                entity.HasKey(e => e.PhoneNumber)
                    .HasName("PRIMARY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
