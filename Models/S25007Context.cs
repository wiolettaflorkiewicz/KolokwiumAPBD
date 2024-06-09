using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumDF.Models;

public partial class S25007Context : DbContext
{
    public S25007Context()
    {
    }

    public S25007Context(DbContextOptions<S25007Context> options)
        : base(options)
    {
    }


    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=s25007;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {  

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("Client_pk");

            entity.ToTable("Client");

            entity.Property(e => e.IdClient).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(100);
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.IdDiscount).HasName("Discount_pk");

            entity.ToTable("Discount");

            entity.Property(e => e.IdDiscount).ValueGeneratedNever();
            entity.Property(e => e.DateFrom).HasColumnType("date");
            entity.Property(e => e.DateTo).HasColumnType("date");

            entity.HasOne(d => d.IdSubscriptionNavigation).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.IdSubscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Discount_Subscription");
        });


        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.IdPayment).HasName("Payment_pk");

            entity.ToTable("Payment");

            entity.Property(e => e.IdPayment).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payment_Client");

            entity.HasOne(d => d.IdSubscriptionNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdSubscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payment_Subscription");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale).HasName("Sale_pk");

            entity.ToTable("Sale");

            entity.Property(e => e.IdSale).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("date");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Table_5_Client");

            entity.HasOne(d => d.IdSubscriptionNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdSubscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Table_5_Subscription");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.IdSubscription).HasName("Subscription_pk");

            entity.ToTable("Subscription");

            entity.Property(e => e.IdSubscription).ValueGeneratedNever();
            entity.Property(e => e.EndTime).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
