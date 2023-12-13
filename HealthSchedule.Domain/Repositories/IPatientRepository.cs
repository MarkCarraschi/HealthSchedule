using HealthSchedule.Domain.Entities.ValueObjects;

namespace HealthSchedule.Domain.Repositories;

public interface IPatientRepository : IDisposable
{
    public Patient GetByCpf(String cpf);
    public void Insert(Patient patient);
    public void Update(Patient patient);
    public void Delete(string cpf);
}
