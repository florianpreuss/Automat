using System;
using System.Collections.Generic;
using Aut_O_Mat_Lib.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Aut_O_Mat_Lib.Database.Data;

public partial class SqliteDbContext : DbContext
{
    public SqliteDbContext()
    {
    }

    public SqliteDbContext(DbContextOptions<SqliteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autobewertung> Autobewertungs { get; set; }

    public virtual DbSet<Automarke> Automarkes { get; set; }

    public virtual DbSet<Automodell> Automodells { get; set; }

    public virtual DbSet<Bewertungskategorie> Bewertungskategories { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Karosserieform> Karosserieforms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Name=ConnectionStrings:Automat");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autobewertung>(entity =>
        {
            entity.HasOne(d => d.Automodell).WithMany(p => p.Autobewertungs).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Bewertungskategorie).WithMany(p => p.Autobewertungs).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Automodell>(entity =>
        {
            entity.HasOne(d => d.Automarke).WithMany(p => p.Automodells).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Karosserieform).WithMany(p => p.Automodells).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
