using System.Data.Entity;
using HealthSchedule.Domain.Entities.ValueObjects;
using HealthSchedule.Infra.Mapping;

namespace HealthSchedule.Infra.Contexts;

public class AppDataContext : DbContext
{
    public AppDataContext() : base("AppConnectionString") {}    
    public DbSet<People> Peoples { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new PeopleMap());
    }
}
