﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<AuctionPurchase> AuctionPurchases { get; set; }

    public virtual DbSet<Bid> Bids { get; set; }

    public virtual DbSet<InstaBuy> InstaBuys { get; set; }

    public virtual DbSet<InstaBuyPurchase> InstaBuyPurchases { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    => optionsBuilder.UseSqlServer("Server=hildur.ucn.dk; Database=CSC-CSD-S211_10407554;User Id=CSC-CSD-S211_10407554; Password=Password1!;TrustServerCertificate=True;Connection Timeout = 30; Integrated Security = False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Auction__3214EC07808F1ADD");

            entity.ToTable("Auction");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.EndsAt).HasColumnType("datetime");
            entity.Property(e => e.EstimatedMaximum).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EstimatedMinimum).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Auction__Product__1BC821DD");
        });

        modelBuilder.Entity<AuctionPurchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AuctionP__3214EC07C83BB9B8");

            entity.Property(e => e.FinalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PurchasedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Auction).WithMany(p => p.AuctionPurchases)
                .HasForeignKey(d => d.AuctionId)
                .HasConstraintName("FK__AuctionPu__Aucti__208CD6FA");

            entity.HasOne(d => d.Buyer).WithMany(p => p.AuctionPurchaseBuyers)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK__AuctionPu__Buyer__1F98B2C1");

            entity.HasOne(d => d.Seller).WithMany(p => p.AuctionPurchaseSellers)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__AuctionPu__Selle__1EA48E88");
        });

        modelBuilder.Entity<Bid>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bids__3214EC078BCDA67A");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PlacedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Auction).WithMany(p => p.Bids)
                .HasForeignKey(d => d.AuctionId)
                .HasConstraintName("FK__Bids__AuctionId__236943A5");

            entity.HasOne(d => d.Bidder).WithMany(p => p.Bids)
                .HasForeignKey(d => d.BidderId)
                .HasConstraintName("FK__Bids__BidderId__245D67DE");
        });

        modelBuilder.Entity<InstaBuy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InstaBuy__3214EC0781E4602B");

            entity.ToTable("InstaBuy");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.InstaBuys)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__InstaBuy__Produc__160F4887");
        });

        modelBuilder.Entity<InstaBuyPurchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InstaBuy__3214EC07EEBD59B9");

            entity.Property(e => e.PurchasedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Insta).WithMany(p => p.InstaBuyPurchases)
                .HasForeignKey(d => d.InstaId)
                .HasConstraintName("FK__InstaBuyP__Insta__18EBB532");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC0763456B68");

            entity.ToTable("Product");

            entity.Property(e => e.Depth).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Height).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Width).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Artist).WithMany(p => p.Products)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK__Product__ArtistI__1332DBDC");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC072606A507");

            entity.ToTable("User");

            entity.Property(e => e.Bio)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PersonalLink)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}