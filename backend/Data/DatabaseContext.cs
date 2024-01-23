#nullable disable
using backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DbAuction> Auctions { get; set; }

    public virtual DbSet<DbBid> Bids { get; set; }

    public virtual DbSet<DbComment> Comments { get; set; }

    public virtual DbSet<DbFixedPriceListing> FixedPriceListings { get; set; }

    public virtual DbSet<DbFixedPriceListingPurchase> FixedPriceListingPurchases { get; set; }

    public virtual DbSet<DbLike> Likes { get; set; }

    public virtual DbSet<DbPost> Posts { get; set; }

    public virtual DbSet<DbProduct> Products { get; set; }

    public virtual DbSet<DbProductImage> ProductImages { get; set; }

    public virtual DbSet<DbUser> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbAuction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Auction__3214EC07D838AC30");

            entity.ToTable("Auction");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.EndsAt).HasColumnType("datetime");
            entity.Property(e => e.EstimateMaxPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EstimateMinPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReservePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.StartingPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Auction__Product__2CDD9F46");
        });

        modelBuilder.Entity<DbBid>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bid__3214EC0786CA9266");

            entity.ToTable("Bid");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Auction).WithMany(p => p.Bids)
                .HasForeignKey(d => d.AuctionId)
                .HasConstraintName("FK__Bid__AuctionId__2FBA0BF1");

            entity.HasOne(d => d.User).WithMany(p => p.Bids)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bid__UserId__30AE302A");
        });

        modelBuilder.Entity<DbComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comment__3214EC07B0C61482");

            entity.ToTable("Comment");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Text)
                .IsRequired()
                .HasMaxLength(1024)
                .IsUnicode(false);

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__Comment__PostId__36670980");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__UserId__375B2DB9");
        });

        modelBuilder.Entity<DbFixedPriceListing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FixedPri__3214EC071075F3C4");

            entity.ToTable("FixedPriceListing");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.FixedPriceListings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__FixedPric__Produ__40E497F3");
        });

        modelBuilder.Entity<DbFixedPriceListingPurchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FixedPri__3214EC078562B13A");

            entity.ToTable("FixedPriceListingPurchase");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Buyer).WithMany(p => p.FixedPriceListingPurchases)
                .HasForeignKey(d => d.BuyerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FixedPric__Buyer__43C1049E");

            entity.HasOne(d => d.FixedPriceListing).WithMany(p => p.FixedPriceListingPurchases)
                .HasForeignKey(d => d.FixedPriceListingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FixedPric__Fixed__44B528D7");
        });

        modelBuilder.Entity<DbLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Like__3214EC07F6DE6723");

            entity.ToTable("Like");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Post).WithMany(p => p.Likes)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__Like__PostId__3A379A64");

            entity.HasOne(d => d.User).WithMany(p => p.Likes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Like__UserId__3B2BBE9D");
        });

        modelBuilder.Entity<DbPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC071AE87F12");

            entity.ToTable("Post");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ImageLink)
                .IsRequired()
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.Text)
                .IsRequired()
                .HasMaxLength(2048)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Post__UserId__338A9CD5");
        });

        modelBuilder.Entity<DbProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC077D544273");

            entity.ToTable("Product");

            entity.Property(e => e.Artist)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Depth).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(2048)
                .IsUnicode(false);
            entity.Property(e => e.Height).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Width).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Seller).WithMany(p => p.Products)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Product__SellerI__2A01329B");
        });

        modelBuilder.Entity<DbProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductI__3214EC07A58C21C9");

            entity.ToTable("ProductImage");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Link)
                .IsRequired()
                .HasMaxLength(1024)
                .IsUnicode(false);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductIm__Produ__3E082B48");
        });

        modelBuilder.Entity<DbUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07113F229B");

            entity.ToTable("User");

            entity.Property(e => e.Bio)
                .HasMaxLength(2048)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImageLink)
                .IsRequired()
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PersonalLink)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImageLink)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public List<string> ApplyMigrations()
    {
        var pending = Database.GetPendingMigrations();

        if (pending.Any())
        {
            Database.Migrate();
            return pending.ToList();
        }

        return new List<string>();
    }
}