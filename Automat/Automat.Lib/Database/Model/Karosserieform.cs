using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Model;

[Table("Karosserieform")]
public partial class Karosserieform
{
    [Key]
    public int KarosserieformId { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "varchar(255)")]
    public string? IconUrl { get; set; }

    [InverseProperty("Karosserieform")]
    public virtual ICollection<Automodell> Automodelle { get; set; } = new List<Automodell>();
}
