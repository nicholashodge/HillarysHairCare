using System.ComponentModel.DataAnnotations;

namespace HillarysHairCare.Models;

public class Appointment {
    public int Id { get; set; }
    [Required]
    public DateTime AppointmentTime { get; set; }
    public int CustomerId { get; set; }
    public int StylistId { get; set; }
    public decimal TotalCost { get; set; }
}