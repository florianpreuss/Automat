using System.ComponentModel.DataAnnotations;

namespace Aut_O_Mat.Database.Model;

public class Autobewertung
{
    [Key]    
    [MaxLength(11)]
    public int AutobewertungId { get; set; }
    
    [Required]
    [MaxLength(11)]
    public int AutomodellId { get; set; }
    public Automodell Automodell { get; set; }
    
    [Required]
    [MaxLength(11)]
    public int BewertungskategorieId { get; set; }
    public Bewertungskategorie Bewertungskategorie { get; set; }
    
    [Required]
    [Range(3,2)]
    public decimal Bewertung { get; set; }
}