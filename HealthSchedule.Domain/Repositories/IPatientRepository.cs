using HealthSchedule.Domain.Entities.ValueObjects;

namespace HealthSchedule.Domain.Repositories;

public interface IPatientRepository : IDisposable
{
    Patient GetByCpf(String cpf);
    void Insert(Patient patient);
    void Update(Patient patient);
    void Delete(string cpf);
}
