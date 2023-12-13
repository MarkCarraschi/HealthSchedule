using HealthSchedule.Domain.Entities;

namespace HealthSchedule.Domain.Repositories;

public interface IEventRepository
{
    public Task<Event> GetById(Guid idEvent);
    public Task Insert(Event modelEvent);
    public Task Update(Event modelEvent);
    public Task Delete(Guid idEvent);
}
