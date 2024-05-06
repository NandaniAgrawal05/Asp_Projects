using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingCart.Models;

public partial class ShoppingcartdbContext : DbContext
{
    public ShoppingcartdbContext()
    {
    }

    public ShoppingcartdbContext(DbContextOptions<ShoppingcartdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Cartdetail> Cartdetails { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Orderstatus> Orderstatuses { get; set; }

    public virtual DbSet<Shoppingcart> Shoppingcarts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("book");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.BookName).HasMaxLength(40);
            entity.Property(e => e.GenreId).HasColumnType("int(11)");
            entity.Property(e => e.Image).HasMaxLength(50);
        });

        modelBuilder.Entity<Cartdetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cartdetail");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.BookId).HasColumnType("int(11)");
            entity.Property(e => e.Quantity).HasColumnType("int(11)");
            entity.Property(e => e.ShoppingCartId)
                .HasColumnType("int(11)")
                .HasColumnName("ShoppingCart_Id");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("genre");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.GenreName).HasMaxLength(40);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("order");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.OrderStatusId).HasColumnType("int(11)");
            entity.Property(e => e.UserId).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orderdetail");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.BookId).HasColumnType("int(11)");
            entity.Property(e => e.OrderId).HasColumnType("int(11)");
            entity.Property(e => e.Quantity).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Orderstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orderstatus");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.StatusName).HasMaxLength(20);
        });

        modelBuilder.Entity<Shoppingcart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("shoppingcart");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.UserId).HasColumnType("int(11)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
