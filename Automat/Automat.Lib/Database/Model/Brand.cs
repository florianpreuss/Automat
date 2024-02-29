using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Model;

[Table("Brand")]
public partial class Brand
{
    [Key]
    public int BrandId { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "varchar(255)")]
    public string? IconUrl { get; set; }

    [InverseProperty("Brand")]
    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
