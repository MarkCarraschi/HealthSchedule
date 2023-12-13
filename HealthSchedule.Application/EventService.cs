using HealthSchedule.Domain.Entities;
using HealthSchedule.Domain.Repositories;
using HealthSchedule.Domain.Services;

namespace HealthSchedule.Application;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(
        IEventRepository eventRepository
    )
    {
        _eventRepository = eventRepository;
    }

    public async Task Delete(Guid idEvent)
    {
        await _eventRepository.Delete(idEvent);
    }

    public async Task<Event> GetEventById(Guid idEvent)
    {
        return await _eventRepository.GetById(idEvent);
    }

    public async Task Insert(Event modelEvent)
    {
        await _eventRepository.Insert(modelEvent);
    }

    public async Task Update(Event modelEvent)
    {
        await _eventRepository.Update(modelEvent);
    }
}
