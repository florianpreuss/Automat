using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Aut_O_Mat_Lib.Database.Model;

[Table("Karosserieform")]
public partial class Karosserieform
{
    [Key]
    public long KarosserieformId { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "varchar(255)")]
    public string? IconUrl { get; set; }

    [InverseProperty("Karosserieform")]
    public virtual ICollection<Automodell> Automodells { get; set; } = new List<Automodell>();
}
