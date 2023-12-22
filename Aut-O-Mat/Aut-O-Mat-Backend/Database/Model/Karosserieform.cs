using System.ComponentModel.DataAnnotations;

namespace Aut_O_Mat_Backend.Database.Model;

public class Karosserieform
{
    [Key]
    [MaxLength(11)]
    public int KarosserieformId { get; set; }
    
    [Required]
    [MaxLength(16)]
    public string Name { get; set; }
    
    [MaxLength(255)]
    public string IconUrl { get; set; }
    
    public List<Automodell> Automodelle { get; set; }
}