using HealthSchedule.Domain;
using HealthSchedule.Domain.Entities.ValueObjects;
using HealthSchedule.Domain.Repositories;
namespace HealthSchedule.Application;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task Insert(Patient pacient)
    {
        _patientRepository.Insert(pacient);
    }

    public async Task Update(Patient pacient)
    {
        _patientRepository.Update(pacient);
    }

    public async Task Delete(string cpf)
    {
        _patientRepository.Delete(cpf);
    }

    public async Task<Patient> GetPacientByCpf(string cpf)
    {
        return _patientRepository.GetByCpf(cpf);
    }
}
