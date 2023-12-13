using System.Drawing.Text;
using HealthSchedule.Domain.Entities;
using HealthSchedule.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthSchedule.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;
    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost]
    [Route("Create")]
    public IActionResult Post([FromBody] Event modelEvent)
    {
        _eventService.Insert(modelEvent);
        return Ok();
    }

    [HttpGet]
    [Route("GetEventById")]
    public async Task<ActionResult<Event>> GetEventById(Guid idEvent)
    {
        var result = await _eventService.GetEventById(idEvent);
        return result;
    }

    [HttpPut]
    [Route("Update")]
    public async Task<ActionResult> Update([FromBody] Event modelEvent)
    {
        await _eventService.Update(modelEvent);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<ActionResult> Delete(Guid idEvent)
    {
        await _eventService.Delete(idEvent);
        return Ok();
    }
}
