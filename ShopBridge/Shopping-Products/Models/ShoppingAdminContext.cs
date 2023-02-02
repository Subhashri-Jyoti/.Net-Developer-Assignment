using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Shopping_Products.Models;

public partial class ShoppingAdminContext : DbContext
{
    
    //This class manages the db connection and is used tio retrieve and save data in database.
    //DbContext - carries config information
    public ShoppingAdminContext(DbContextOptions<ShoppingAdminContext> options)
        : base(options)
    {
    }

    //DbSet - To query and save instances of MobileProduct class.
    public virtual DbSet<MobileProduct> MobileProducts { get; set; }

    //Seeding 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MobileProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__MobilePr__B40CC6EDC6B92F3C");

            entity.ToTable("MobileProduct");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductDesc).HasMaxLength(50);
            entity.Property(e => e.ProductName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
