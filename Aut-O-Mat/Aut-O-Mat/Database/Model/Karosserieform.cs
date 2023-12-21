using System.ComponentModel.DataAnnotations;

namespace Aut_O_Mat.Database.Model;

public class Karosserieform
{
    [Key]
    public int KarosserieformId { get; set; }
    
    [Required]
    [MaxLength(16)]
    public string Name { get; set; }
    
    public string IconUrl { get; set; }

    public List<Automodell> Automodelle { get; set; }
}