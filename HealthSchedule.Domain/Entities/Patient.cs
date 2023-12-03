namespace HealthSchedule.Domain.Entities.ValueObjects;

public class Patient : People
{
    public Patient(
        String cpf, 
        String name,
        DateTime birthday
    ) : base(cpf, name, birthday)
    {

    }
}