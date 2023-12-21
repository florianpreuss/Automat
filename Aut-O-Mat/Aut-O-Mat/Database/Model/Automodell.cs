using System.ComponentModel.DataAnnotations;

namespace Aut_O_Mat.Database.Model;

public class Automodell
{
    [Key]
    [MaxLength(11)]
    public int AutomodellId { get; set; }
    
    [Required]
    [MaxLength(32)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(11)]
    public int AutomarkenId { get; set; }
    public Automarke Automarke { get; set; }
    
    [Required]
    [MaxLength(11)]
    public int KarosserieformId { get; set; }
    public Karosserieform Karosserieform { get; set; }
    
    [Range(10, 2)]
    public decimal? Listenpreis { get; set; }
    
    [MaxLength(16)]
    public string? Kraftstoff { get; set; }
    
    [MaxLength(4)]
    public int? LeistungPs { get; set; }
    
    [MaxLength(4)]
    public int? Modelljahr { get; set;  }
    
    [MaxLength(2)]
    public int AnzahlSitze { get; set; }
    
    [MaxLength(255)]
    public string BildUrl { get; set; }
    
    public List<Autobewertung> Autobewertungen { get; set; }
}