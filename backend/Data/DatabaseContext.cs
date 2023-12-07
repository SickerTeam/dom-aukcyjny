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

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<InstaBuy> InstaBuys { get; set; }

    public virtual DbSet<InstaBuyPurchase> InstaBuyPurchases { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Auction__3214EC079EFB0EE2");

            entity.ToTable("Auction");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.EndsAt).HasColumnType("datetime");
            entity.Property(e => e.EstimatedMaximum).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EstimatedMinimum).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FirstPrice).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<AuctionPurchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AuctionP__3214EC0792BAD9F6");

            entity.Property(e => e.FinalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PurchasedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Auction).WithMany(p => p.AuctionPurchases)
                .HasForeignKey(d => d.AuctionId)
                .HasConstraintName("FK__AuctionPu__Aucti__09746778");
        });

        modelBuilder.Entity<Bid>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bids__3214EC070ABD2750");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PlacedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Auction).WithMany(p => p.Bids)
                .HasForeignKey(d => d.AuctionId)
                .HasConstraintName("FK__Bids__AuctionId__0C50D423");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comment__3214EC077AD20965");

            entity.ToTable("Comment");

            entity.Property(e => e.Text).IsUnicode(false);
            entity.Property(e => e.TimePosted).HasColumnType("datetime");
        });

        modelBuilder.Entity<InstaBuy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InstaBuy__3214EC07333064FD");

            entity.ToTable("InstaBuy");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<InstaBuyPurchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InstaBuy__3214EC076BAF49DF");

            entity.Property(e => e.PurchasedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Insta).WithMany(p => p.InstaBuyPurchases)
                .HasForeignKey(d => d.InstaId)
                .HasConstraintName("FK__InstaBuyP__Insta__01D345B0");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Likes__3214EC076FDBD8D0");

            entity.Property(e => e.TimeLiked).HasColumnType("datetime");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pictures__3214EC07DFA325CB");

            entity.Property(e => e.PictureUrl).IsUnicode(false);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC0727F5C211");

            entity.ToTable("Post");

            entity.Property(e => e.Text).IsUnicode(false);
            entity.Property(e => e.TimePosted).HasColumnType("datetime");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07C60A696C");

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
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07F76EC8BA");

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