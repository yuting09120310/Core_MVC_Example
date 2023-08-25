﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core_MVC_Example.Models;

public partial class CoreMvcExampleContext : DbContext
{
    public CoreMvcExampleContext()
    {
    }

    public CoreMvcExampleContext(DbContextOptions<CoreMvcExampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminGroup> AdminGroups { get; set; }

    public virtual DbSet<AdminRole> AdminRoles { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MenuGroup> MenuGroups { get; set; }

    public virtual DbSet<MenuSub> MenuSubs { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsClass> NewsClasses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductClass> ProductClasses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=Core_MVC_Example;User ID=sa;Password=Obiz@0000;Trusted_Connection=True;Integrated Security=False;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminNum);

            entity.ToTable("Admin");

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasColumnName("IP");
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
        });

        modelBuilder.Entity<AdminGroup>(entity =>
        {
            entity.HasKey(e => e.GroupNum).HasName("PK_LoginGroup");

            entity.ToTable("AdminGroup");

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasColumnName("IP");
        });

        modelBuilder.Entity<AdminRole>(entity =>
        {
            entity.HasKey(e => e.RoleNum).HasName("PK_LoginRole");

            entity.ToTable("AdminRole");

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Ip).HasColumnName("IP");
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.BannerNum);

            entity.ToTable("Banner");

            entity.Property(e => e.BannerContxt).HasComment("");
            entity.Property(e => e.BannerOffTime).HasColumnType("datetime");
            entity.Property(e => e.BannerPutTime).HasColumnType("datetime");
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasColumnName("IP");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactNum);

            entity.ToTable("Contact");

            entity.Property(e => e.ContactReTxt).HasComment("");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasColumnName("IP");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberNum);

            entity.ToTable("Member");

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasColumnName("IP");
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
        });

        modelBuilder.Entity<MenuGroup>(entity =>
        {
            entity.HasKey(e => e.MenuGroupNum);

            entity.ToTable("MenuGroup");

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasColumnName("IP");
            entity.Property(e => e.MenuGroupSort).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<MenuSub>(entity =>
        {
            entity.HasKey(e => e.MenuSubNum);

            entity.ToTable("MenuSub");

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasColumnName("IP");
            entity.Property(e => e.MenuSubSort).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsNum);

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasComment("")
                .HasColumnType("datetime");
            entity.Property(e => e.Creator).HasComment("");
            entity.Property(e => e.EditTime)
                .HasComment("")
                .HasColumnType("datetime");
            entity.Property(e => e.Editor).HasComment("");
            entity.Property(e => e.Ip)
                .HasComment("")
                .HasColumnName("IP");
            entity.Property(e => e.NewsClass).HasComment("");
            entity.Property(e => e.NewsContxt).HasComment("");
            entity.Property(e => e.NewsImg1).HasComment("");
            entity.Property(e => e.NewsImgAlt).HasComment("");
            entity.Property(e => e.NewsImgUrl).HasComment("");
            entity.Property(e => e.NewsOffTime)
                .HasComment("")
                .HasColumnType("datetime");
            entity.Property(e => e.NewsPublish).HasComment("");
            entity.Property(e => e.NewsPutTime)
                .HasComment("")
                .HasColumnType("datetime");
            entity.Property(e => e.NewsSort).HasComment("");
            entity.Property(e => e.NewsTitle).HasComment("");
            entity.Property(e => e.NewsViews).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<NewsClass>(entity =>
        {
            entity.HasKey(e => e.NewsClassNum);

            entity.ToTable("NewsClass");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasColumnName("IP");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductNum).HasName("PK_Product_1");

            entity.ToTable("Product");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasColumnName("IP");
            entity.Property(e => e.ProductImgAlt).HasComment("");
            entity.Property(e => e.ProductImgUrl).HasComment("");
            entity.Property(e => e.ProductOffTime).HasColumnType("datetime");
            entity.Property(e => e.ProductPutTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductClass>(entity =>
        {
            entity.HasKey(e => e.ProductClassNum).HasName("PK_Product");

            entity.ToTable("ProductClass");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasColumnName("IP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
