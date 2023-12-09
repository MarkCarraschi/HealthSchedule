//using System.Data.Entity;
using HealthSchedule.Domain.Entities.ValueObjects;
using HealthSchedule.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace HealthSchedule.Infra.Contexts;

public class AppDataContext : DbContext
{
    public AppDataContext( DbContextOptions<AppDataContext> options
        
    ) : base(options) 
    {
    }    
    public DbSet<Patient> Patients { get; set; }
    /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new PeopleMap());
    }*/
}
