using System.ComponentModel.DataAnnotations;

namespace Aut_O_Mat.Database.Model;

public class Automarke
{
    [Key] 
    public int AutomarkeId { get; set; }
    
    [Required]
    [MaxLength(16)]
    public string Name { get; set; }
    
    public string? LogoUrl { get; set; }

    public List<Automodell> Automodelle { get; set; }
}