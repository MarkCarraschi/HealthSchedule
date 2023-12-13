using System.Data.Entity;
using HealthSchedule.Domain.Entities.ValueObjects;
using HealthSchedule.Domain.Repositories;
using HealthSchedule.Infra.Contexts;

namespace HealthSchedule.Infra.Repositories;

public class PatientRepository : IPatientRepository
{

    private readonly AppDataContext _db;

    public PatientRepository(AppDataContext db)
    {
        this._db = db;
    }

    public void Delete(string cpf)
    {
        var people = GetByCpf(cpf);
        _db.Patients.Remove(people);
        _db.SaveChanges();
    }

    public void Dispose()
    {
        _db.Dispose();
    }

    public Patient GetByCpf(string cpf)
    {
        return _db.Patients.FirstOrDefault<Patient>(x => x.Cpf == cpf);
    }

    public void Insert(Patient patient)
    {
        _db.Patients.Add(patient);
        _db.SaveChanges();
    }

    public void Update(Patient patient)
    {
        _db.Entry<Patient>(patient).State = (Microsoft.EntityFrameworkCore.EntityState) EntityState.Modified;
        _db.SaveChanges();
    }
}

