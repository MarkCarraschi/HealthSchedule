namespace HealthSchedule.Domain.Entities.ValueObjects;

public abstract class People : ValueObject
{   
    public People(
        String cpf,
        String name,
        DateTime birthday
    )
    {
        Cpf = cpf;
        Name = name;
        Birthday = birthday;
    }

    public String Cpf { get; set; }
    public String Name { get; set; }
    public DateTime Birthday { get; set; }
    public int Age { get; set; }
}
