using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecycleCoin.Entities.Concrete.EntityFramework;

public partial class RecycleCoinContext : DbContext
{
    public RecycleCoinContext()
    {
    }

    public RecycleCoinContext(DbContextOptions<RecycleCoinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Recycle> Recycles { get; set; }

    public virtual DbSet<RecycleDetail> RecycleDetails { get; set; }

    public virtual DbSet<Reply> Replies { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=RecyleCoin;Username=postgres;Password=1236");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Customer_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Customer_id_seq\"'::regclass)");

            entity.HasOne(d => d.User).WithMany(p => p.Customers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Customer_userId_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");
        });

        modelBuilder.Entity<Recycle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Recycle_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Recycle_id_seq\"'::regclass)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Recycles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Recycle_customerId_fkey");
        });

        modelBuilder.Entity<RecycleDetail>(entity =>
        {
            entity.HasKey(e => e.ıd).HasName("RecycleDetails_pkey");

            entity.Property(e => e.ıd).HasDefaultValueSql("nextval('\"RecycleDetails_ıd_seq\"'::regclass)");

            entity.HasOne(d => d.Product).WithMany(p => p.RecycleDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recycle_detail_product_id_fkey");

            entity.HasOne(d => d.Recycle).WithMany(p => p.RecycleDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RecycleDetails_recycleId_fkey");
        });

        modelBuilder.Entity<Reply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reply_pkey");

            entity.HasOne(d => d.Topic).WithMany(p => p.Replies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reply_topic_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Replies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reply_user_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("topic_pkey");

            entity.HasOne(d => d.User).WithMany(p => p.Topics)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("topic_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"User_id_seq\"'::regclass)");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
