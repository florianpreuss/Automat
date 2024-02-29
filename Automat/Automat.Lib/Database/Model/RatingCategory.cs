using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Model;

[Table("RatingCategory")]
public partial class RatingCategory
{
    [Key]
    public int RatingCategoryId { get; set; }

    [Column(TypeName = "varchar(32)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(3, 2)")]
    public decimal Weighting { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string Question { get; set; } = null!;

    [Column(TypeName = "varchar(32)")]
    public string? TagMin { get; set; }

    [Column(TypeName = "varchar(32)")]
    public string? TagMax { get; set; }

    [InverseProperty("RatingCategory")]
    public virtual ICollection<ModelRating> ModelRatings { get; set; } = new List<ModelRating>();
}
