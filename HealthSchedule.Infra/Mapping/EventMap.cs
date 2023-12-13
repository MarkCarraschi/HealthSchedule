using HealthSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthSchedule.Infra.Mapping;

public class EventMap : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        //Try to split tables and relate this
        builder.ToTable("Event");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();        
    }
}
