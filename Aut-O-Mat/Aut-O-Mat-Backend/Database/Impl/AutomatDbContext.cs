using Aut_O_Mat_Backend.Database.Model;

namespace Aut_O_Mat_Backend.Database.Impl;

using System.Reflection;
using Microsoft.EntityFrameworkCore;

public class AutomatDbContext : Microsoft.EntityFrameworkCore.DbContext {
    public DbSet<Autobewertung> Autobewertung { get; set; }
    public DbSet<Automarke> Automarke { get; set; }
    public DbSet<Automodell> Automodell { get; set; }
    public DbSet<Bewertungskategorie> Bewertungskategorie { get; set; }
    public DbSet<Feedback> Feedback { get; set; }
    public DbSet<Karosserieform> Karosserieform { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=automatDb1",
                option => { option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName); });
            base.OnConfiguring(optionsBuilder);
        }
    
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IAutobewertung>().ToTable("Autobewertung", "schema1");
            modelBuilder.Entity<IAutobewertung>(entity =>
            {
                entity.HasKey(k => k.autobewertungId);
            });
            base.OnModelCreating(modelBuilder);
        }*/
}