using System;
using System.Collections.Generic;
using Automat.Lib.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Data;

public partial class AutomatDbContext : DbContext
{
    public AutomatDbContext()
    {
    }

    public AutomatDbContext(DbContextOptions<AutomatDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ModelRating> ModelRatings { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Model.Model> Models { get; set; }

    public virtual DbSet<RatingCategory> RatingCategories { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<BodyStyle> BodyStyles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ModelRating>(entity =>
        {
            entity.HasOne(d => d.Model).WithMany(p => p.ModelRatings).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.RatingCategory).WithMany(p => p.ModelRatings).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Model.Model>(entity =>
        {
            entity.HasOne(d => d.Brand).WithMany(p => p.Models).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.BodyStyle).WithMany(p => p.Models).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
