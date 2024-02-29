using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Model;

[Table("ModelRating")]
public partial class ModelRating
{
    [Key]
    public int ModelRatingId { get; set; }

    public int ModelId { get; set; }

    public int RatingCategoryId { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal Rating { get; set; }

    [ForeignKey("ModelId")]
    [InverseProperty("ModelRatings")]
    public virtual Model Model { get; set; } = null!;

    [ForeignKey("RatingCategoryId")]
    [InverseProperty("ModelRatings")]
    public virtual RatingCategory RatingCategory { get; set; } = null!;
}
