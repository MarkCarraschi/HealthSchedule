using HealthSchedule.Core.ValueObjects;

namespace HealthSchedule.Core;

public class Professional : People
{
    public Professional(
        String cpf, 
        String name,
        DateTime birthday,
        String role
    ) : base (cpf, name, birthday)
    {
        Role = role;
    }
    public String Role { get; set; }
}