using System.Data.Entity.ModelConfiguration;
using HealthSchedule.Domain.Entities.ValueObjects;

namespace HealthSchedule.Infra.Mapping;

public class PeopleMap : EntityTypeConfiguration<People>
{
    public PeopleMap()
    {
        ToTable("People");
        HasKey(x => x.Cpf).Property(x => x.Cpf).HasMaxLength(11).IsRequired();
        Property(x => x.Name).HasMaxLength(60).IsRequired();
        Property(x => x.Birthday).IsRequired();
    }
}
