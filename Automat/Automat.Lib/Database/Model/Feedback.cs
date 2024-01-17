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
    public long FeedbackId { get; set; }

    [Column(TypeName = "integer(2)")]
    public long? Bewertung { get; set; }

    [Column(TypeName = "datetime")]
    public byte[]? Zeitpunkt { get; set; }
}
