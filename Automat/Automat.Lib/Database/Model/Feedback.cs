using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Model;

[Table("Feedback")]
public partial class Feedback
{
    [Key]
    public int FeedbackId { get; set; }

    [Column(TypeName = "integer(2)")]
    public int? Bewertung { get; set; }

    [Column(TypeName = "datetime")]
    public byte[]? Zeitpunkt { get; set; }
}
