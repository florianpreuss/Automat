using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Model;

[Table("Automodell")]
public partial class Automodell
{
    [Key]
    public int AutomodellId { get; set; }

    [Column(TypeName = "varchar(32)")]
    public string Name { get; set; } = null!;

    public int AutomarkeId { get; set; }

    public int KarosserieformId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Listenpreis { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string? Kraftstoff { get; set; }

    [Column(TypeName = "integer(4)")]
    public int? LeistungPs { get; set; }

    [Column(TypeName = "integer(4)")]
    public int? Modelljahr { get; set; }

    [Column(TypeName = "integer(2)")]
    public int? AnzahlSitze { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? BildUrl { get; set; }

    [InverseProperty("Automodell")]
    public virtual ICollection<Autobewertung> Autobewertungen { get; set; } = new List<Autobewertung>();

    [ForeignKey("AutomarkeId")]
    [InverseProperty("Automodelle")]
    public virtual Automarke Automarke { get; set; } = null!;

    [ForeignKey("KarosserieformId")]
    [InverseProperty("Automodelle")]
    public virtual Karosserieform Karosserieform { get; set; } = null!;
}
