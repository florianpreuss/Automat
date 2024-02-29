using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Model;

[Table("BodyStyle")]
public partial class BodyStyle
{
    [Key]
    public int BodyStyleId { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "varchar(255)")]
    public string? IconUrl { get; set; }

    [InverseProperty("BodyStyle")]
    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
