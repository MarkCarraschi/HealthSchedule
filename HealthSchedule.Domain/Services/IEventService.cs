using HealthSchedule.Domain.Entities;
namespace HealthSchedule.Domain.Services;

public interface IEventService
{
    public Task Insert(Event modelEvent);
    public Task Update(Event modelEvent);
    public Task Delete(Guid idEvent);
    public Task<Event> GetEventById(Guid idEvent);
}
