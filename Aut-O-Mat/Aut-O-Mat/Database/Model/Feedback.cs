using System.ComponentModel.DataAnnotations;

namespace Aut_O_Mat.Database.Model;

public class Feedback
{
    [Key]
    [MaxLength(11)]
    public int FeedbackId { get; set; }
    
    [MaxLength(1)]
    public int BewertungApp { get; set; }
    
    [Required]
    [MaxLength(1)]
    public int BewertungErgebnis { get; set; }

    [Required]
    public DateTime Zeitpunkt { get; set; }
}