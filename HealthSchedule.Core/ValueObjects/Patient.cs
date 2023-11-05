namespace HealthSchedule.Core.ValueObjects;

public class Patient : ValueObject
{
    public Patient(
        long id,
        String name
    )
    {
        Id = id;
        Name = name;
    }

    public long Id { get; set; }
    public string Name { get; set; }
}
