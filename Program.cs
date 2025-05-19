using HillarysHairCare.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Npgsql;
using HillarysHairCare.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HillarysHairCareDbContext>(builder.Configuration["HillarysHairCareDBConnectionString"]);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .WithOrigins("http://localhost:5000", "http://localhost:5001", "http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

//get all stylists
app.MapGet("/stylists", (HillarysHairCareDbContext db) =>
{
    return db.Stylists.Select(s => new StylistDTO
    {
        Id = s.Id,
        Name = s.Name,
        ServiceId = s.ServiceId,
        Active = s.Active
    }).ToList();
});

app.MapGet("/customers", (HillarysHairCareDbContext db) =>
{
    return db.Customers.Select(c => new CustomerDTO
    {
        Id = c.Id,
        Name = c.Name,
       
    }).ToList();
});

app.MapPost("/stylists", (HillarysHairCareDbContext db, Stylist stylist) =>
{
    db.Stylists.Add(stylist);
    db.SaveChanges();
    return Results.Created($"/stylists/{stylist.Id}", stylist);
});

//get stylist by Id
app.MapGet("/stylists/{id}", (HillarysHairCareDbContext db, int id) =>
{
    return db.Stylists.Include(s => s.Service).Select(s => new StylistDTO
    {
        Id = s.Id,
        Name = s.Name,
        ServiceId = s.ServiceId,
        Service = new ServiceDTO {
            Id = s.Service.Id,
            Name = s.Service.Name,
            ServiceCost = s.Service.ServiceCost
        }
    }).Single(s => s.Id == id);
});

app.MapGet("/services", (HillarysHairCareDbContext db) =>
{
    return db.Services.Select(s => new ServiceDTO
    {
        Id = s.Id,
        Name = s.Name,
        ServiceCost = s.ServiceCost
    }).ToList();
});

app.MapGet("/appointments", (HillarysHairCareDbContext db) =>
{
    return db.Appointments.Select(a => new AppointmentDTO
    {
        Id = a.Id,
        AppointmentTime = a.AppointmentTime,
        CustomerId =  a.CustomerId,
        StylistId = a.StylistId,
        TotalCost = a.TotalCost
    }).ToList();
});

app.MapGet("/appointments/{id}", (HillarysHairCareDbContext db, int id) =>
{
    return db.Appointments.Include(a => a.Customer).Include(a => a.Stylist).Select(a => new AppointmentDTO
    {
        Id = a.Id,
        AppointmentTime = a.AppointmentTime,
        CustomerId = a.CustomerId,
        Customer = new CustomerDTO {
            Id = a.Customer.Id,
            Name = a.Customer.Name
        },
        StylistId = a.StylistId,
        Stylist = new StylistDTO {
            Id = a.Stylist.Id,
            Name = a.Stylist.Name,
            ServiceId = a.Stylist.Service.Id,
            Service = new ServiceDTO {
                Id = a.Stylist.Service.Id,
                Name = a.Stylist.Service.Name,
                ServiceCost = a.Stylist.Service.ServiceCost
            }
        }
    });
});

app.Run();