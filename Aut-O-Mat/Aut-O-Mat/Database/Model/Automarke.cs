using System.ComponentModel.DataAnnotations;

namespace Aut_O_Mat.Database.Model;

public class Automarke
{
    [Key] 
    [MaxLength(11)]
    public int AutomarkeId { get; set; }
    
    [Required]
    [MaxLength(16)]
    public string Name { get; set; }
    
    [MaxLength(255)]
    public string? LogoUrl { get; set; }

    public List<Automodell> Automodelle { get; set; }
}