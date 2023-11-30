using HealthSchedule.Core.ValueObjects;

namespace HealthSchedule.Core;

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
