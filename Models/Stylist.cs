using System.ComponentModel.DataAnnotations;

namespace HillarysHairCare.Models;

public class Stylist {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int ServiceId { get; set; }
    public bool Active { get; set; }
}