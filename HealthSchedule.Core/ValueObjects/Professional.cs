namespace HealthSchedule.Core.ValueObjects;

public class Professional
{

    public Professional(
        long id, 
        String name)
    {
        Id = id;
        Name = name;
    }

    public long Id { get; set; }
    public String Name { get; set; }
}