using System.Data.Entity;
using HealthSchedule.Domain.Entities;
using HealthSchedule.Domain.Repositories;
using HealthSchedule.Infra.Contexts;

namespace HealthSchedule.Infra;

public class EventRepository : IEventRepository
{

    private readonly AppDataContext _db;

    public EventRepository(AppDataContext db)
    {
        _db = db;
    }

    public async Task Delete(Guid idEvent)
    {
        var eventModel = await GetById(idEvent);
        _db.Events.Remove(eventModel);
        await _db.SaveChangesAsync();
    }

    public async Task Insert(Event modelEvent)
    {
        _db.Events.Add(modelEvent);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Event modelEvent)
    {
        _db.Entry<Event>(modelEvent).State = (Microsoft.EntityFrameworkCore.EntityState) EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task<Event> GetById(Guid idEvent)
    {
        return await _db.Events.FirstOrDefaultAsync(e => e.Id == idEvent);
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}
