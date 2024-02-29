using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Model;

[Table("Model")]
public partial class Model
{
    [Key]
    public int ModelId { get; set; }

    [Column(TypeName = "varchar(32)")]
    public string Name { get; set; } = null!;

    public int BrandId { get; set; }

    public int BodyStyleId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Price { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string? FuelType { get; set; }

    [Column(TypeName = "integer(4)")]
    public int? Horsepower { get; set; }

    [Column(TypeName = "integer(4)")]
    public int? ModelYear { get; set; }

    [Column(TypeName = "integer(2)")]
    public int? Seats { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? ThumbnailUrl { get; set; }

    [InverseProperty("Model")]
    public virtual ICollection<ModelRating> ModelRatings { get; set; } = new List<ModelRating>();

    [ForeignKey("BrandId")]
    [InverseProperty("Models")]
    public virtual Brand Brand { get; set; } = null!;

    [ForeignKey("BodyStyleId")]
    [InverseProperty("Models")]
    public virtual BodyStyle BodyStyle { get; set; } = null!;
}
