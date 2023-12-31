﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NewsAppDB.Models
{
  public partial class NewsAppDBContext : DbContext
  {
    public NewsAppDBContext()
    {
    }

    public NewsAppDBContext(DbContextOptions<NewsAppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//      if (!optionsBuilder.IsConfigured)
//      {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NewsAppDB;Trusted_Connection=True;");
//      }
//    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

      modelBuilder.Entity<Article>(entity =>
      {
        entity.ToTable("Article");

        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.Author)
                  .IsRequired()
                  .HasMaxLength(50)
                  .IsUnicode(false);

        entity.Property(e => e.Content)
                  .IsRequired()
                  .IsUnicode(false);

        entity.Property(e => e.Headline)
                  .IsRequired()
                  .HasMaxLength(100)
                  .IsUnicode(false);

        entity.Property(e => e.ImageFile)
                  .IsRequired()
                  .HasMaxLength(50)
                  .IsUnicode(false);
      });

      OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
