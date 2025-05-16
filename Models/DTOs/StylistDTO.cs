using System.ComponentModel.DataAnnotations;

namespace HillarysHairCare.Models.DTOs;

public class Stylist {
    public int Id { get; set; }
    public string Name { get; set; }
    public int SeriveId { get; set; }
    public bool Active { get; set; }
}