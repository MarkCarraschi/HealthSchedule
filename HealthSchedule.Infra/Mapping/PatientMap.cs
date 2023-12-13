using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HealthSchedule.Domain.Entities.ValueObjects;

namespace HealthSchedule.Infra.Mapping;

public class PatientMap : IEntityTypeConfiguration<Patient>
{

    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patient");
        builder.HasKey(x => x.Cpf);
        builder.Property(x => x.Cpf).HasMaxLength(11).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(60).IsRequired();
        builder.Property(x => x.Birthday).IsRequired();
    }
}
