using HealthSchedule.Domain.Entities.ValueObjects;

namespace HealthSchedule.Domain;

public interface IPatientService
{
    public Task Insert(Patient patient);
    public Task Update(Patient patient);
    public Task Delete(string cpf);
    public Task<Patient> GetPacientByCpf(string cpf);
}
