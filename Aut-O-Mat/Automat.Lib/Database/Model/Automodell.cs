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
    public long AutomodellId { get; set; }

    [Column(TypeName = "varchar(32)")]
    public string Name { get; set; } = null!;

    public long AutomarkeId { get; set; }

    public long KarosserieformId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public byte[]? Listenpreis { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string? Kraftstoff { get; set; }

    [Column(TypeName = "integer(4)")]
    public long? LeistungPs { get; set; }

    [Column(TypeName = "integer(4)")]
    public long? Modelljahr { get; set; }

    [Column(TypeName = "integer(2)")]
    public long? AnzahlSitze { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? BildUrl { get; set; }

    [InverseProperty("Automodell")]
    public virtual ICollection<Autobewertung> Autobewertungs { get; set; } = new List<Autobewertung>();

    [ForeignKey("AutomarkeId")]
    [InverseProperty("Automodells")]
    public virtual Automarke Automarke { get; set; } = null!;

    [ForeignKey("KarosserieformId")]
    [InverseProperty("Automodells")]
    public virtual Karosserieform Karosserieform { get; set; } = null!;
}
