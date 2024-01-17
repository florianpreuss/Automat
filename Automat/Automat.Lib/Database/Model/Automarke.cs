using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Model;

[Table("Automarke")]
public partial class Automarke
{
    [Key]
    public int AutomarkeId { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "varchar(255)")]
    public string? LogoUrl { get; set; }

    [InverseProperty("Automarke")]
    public virtual ICollection<Automodell> Automodelle { get; set; } = new List<Automodell>();
}
