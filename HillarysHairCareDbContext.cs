using Microsoft.EntityFrameworkCore;
using HillarysHairCare.Models;

public class HillarysHairCareDbContext : DbContext
{

    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Service> Services { get; set; }

    public HillarysHairCareDbContext(DbContextOptions<HillarysHairCareDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<Appointment>().HasData(new Appointment[]
        {
        new Appointment {Id = 1, AppointmentTime = new DateTime (2025, 4 , 5), CustomerId = 1, StylistId = 1, TotalCost = 10.00M},
        new Appointment {Id = 2, AppointmentTime = new DateTime (2025, 3, 5), CustomerId = 2, StylistId = 2, TotalCost = 20.00M},
        new Appointment {Id = 3, AppointmentTime = new DateTime (2025, 4 , 7), CustomerId = 3, StylistId = 3, TotalCost = 30.00M},
        new Appointment {Id = 4, AppointmentTime = new DateTime (2025, 2 , 5), CustomerId = 4, StylistId = 4, TotalCost = 40.00M}
    });
        modelBuilder.Entity<AppointmentService>().HasData(new AppointmentService[]
    {
    new AppointmentService {Id = 1, AppointmentId = 1, ServiceId = 1, },
    new AppointmentService {Id = 2, AppointmentId = 2, ServiceId = 2, },
    new AppointmentService {Id = 3, AppointmentId = 3, ServiceId = 3, },
    new AppointmentService {Id = 4, AppointmentId = 4, ServiceId = 4, },

    });
        modelBuilder.Entity<Customer>().HasData(new Customer[]
    {
    new Customer { Id = 1, Name = "Jonny Haircare" },
    new Customer { Id = 2, Name = "Mister Fabulous" },
    new Customer { Id = 3, Name = "Barbra Lashes" },
    new Customer { Id = 4, Name = "Ben Roller" },
    });
        modelBuilder.Entity<Service>().HasData(new Service[]
    {
    new Service { Id = 1, Name = "Haircut", ServiceCost = 20.00M },
    new Service { Id = 2, Name = "Spa Treatment", ServiceCost = 30.00M },
    new Service { Id = 3, Name = "Hair Coloring", ServiceCost = 40.00M  },
    new Service { Id = 4, Name = "Beard Trim", ServiceCost = 15.00M }


    });

    modelBuilder.Entity<Stylist>().HasData(new Stylist[]
{
    new Stylist { Id = 1, Name = "Mister Styleman", ServiceId = 1, Active = true },
    new Stylist { Id = 2, Name = "Master Beard", ServiceId = 2, Active = true },
    new Stylist { Id = 3, Name = "Spaman", ServiceId = 3, Active = true  },
    new Stylist { Id = 4, Name = "Mister Colors", ServiceId = 4, Active = true}


});
    }
}