using System.ComponentModel.DataAnnotations;

namespace Aut_O_Mat.Database.Model;

public class Bewertungskategorie
{
    [Key]
    [MaxLength(11)]
    public int BewertungskategorieId { get; set; }
    
    [Required]
    [MaxLength(32)]
    public string Name { get; set; }
    
    [Required]
    [Range(3, 2)]
    public decimal Gewichtung { get; set; }
    
    public List<Autobewertung> Autobewertungen { get; set; }
}