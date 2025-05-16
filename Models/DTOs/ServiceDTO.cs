using System.ComponentModel.DataAnnotations;

namespace HillarysHairCare.Models.DTOs;

public class Service {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal ServiceCost { get; set; }
}