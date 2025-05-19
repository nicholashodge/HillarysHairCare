using System.ComponentModel.DataAnnotations;

namespace HillarysHairCare.Models.DTOs;

public class StylistDTO {
    public int Id { get; set; }
    public string Name { get; set; }
    public int ServiceId { get; set; }
    public ServiceDTO Service { get; set; }
    public bool Active { get; set; }
}