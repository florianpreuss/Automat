using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Model;

[Table("Bewertungskategorie")]
public partial class Bewertungskategorie
{
    [Key]
    public int BewertungskategorieId { get; set; }

    [Column(TypeName = "varchar(32)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(3, 2)")]
    public decimal Gewichtung { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string Fragestellung { get; set; } = null!;

    [Column(TypeName = "varchar(32)")]
    public string? TagMin { get; set; }

    [Column(TypeName = "varchar(32)")]
    public string? TagMax { get; set; }

    [InverseProperty("Bewertungskategorie")]
    public virtual ICollection<Autobewertung> Autobewertungen { get; set; } = new List<Autobewertung>();
}
