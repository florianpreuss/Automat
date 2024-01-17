using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Model;

[Table("Autobewertung")]
public partial class Autobewertung
{
    [Key]
    public long AutobewertungId { get; set; }

    public long AutomodellId { get; set; }

    public long BewertungskategorieId { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public byte[] Bewertung { get; set; } = null!;

    [ForeignKey("AutomodellId")]
    [InverseProperty("Autobewertungs")]
    public virtual Automodell Automodell { get; set; } = null!;

    [ForeignKey("BewertungskategorieId")]
    [InverseProperty("Autobewertungs")]
    public virtual Bewertungskategorie Bewertungskategorie { get; set; } = null!;
}
