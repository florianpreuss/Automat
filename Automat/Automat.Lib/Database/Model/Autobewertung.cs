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
    public int AutobewertungId { get; set; }

    public int AutomodellId { get; set; }

    public int BewertungskategorieId { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public byte[] Bewertung { get; set; } = null!;

    [ForeignKey("AutomodellId")]
    [InverseProperty("Autobewertungen")]
    public virtual Automodell Automodell { get; set; } = null!;

    [ForeignKey("BewertungskategorieId")]
    [InverseProperty("Autobewertungen")]
    public virtual Bewertungskategorie Bewertungskategorie { get; set; } = null!;
}
