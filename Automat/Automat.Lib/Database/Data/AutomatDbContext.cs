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

    public virtual DbSet<Autobewertung> Autobewertungen { get; set; }

    public virtual DbSet<Automarke> Automarken { get; set; }

    public virtual DbSet<Automodell> Automodelle { get; set; }

    public virtual DbSet<Bewertungskategorie> Bewertungskategorien { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Karosserieform> Karosserieformen { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autobewertung>(entity =>
        {
            entity.HasOne(d => d.Automodell).WithMany(p => p.Autobewertungen).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Bewertungskategorie).WithMany(p => p.Autobewertungen).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Automodell>(entity =>
        {
            entity.HasOne(d => d.Automarke).WithMany(p => p.Automodelle).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Karosserieform).WithMany(p => p.Automodelle).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
