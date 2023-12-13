using System.Data.Entity.ModelConfiguration;
using HealthSchedule.Domain.Entities.ValueObjects;

namespace HealthSchedule.Infra;

public class PeopleMap : EntityTypeConfiguration<People>
{
    public PeopleMap()
    {       

    }
}
