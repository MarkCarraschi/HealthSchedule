using HealthSchedule.Domain.Entities.ValueObjects;

namespace HealthSchedule.Domain.Repositories;

public interface IPeopleRepository : IDisposable
{
    void InsertPeople(People people);
}
