using HealthSchedule.Domain.Entities.ValueObjects.Exceptions;

namespace HealthSchedule.Domain.Entities.ValueObjects;

public class Schedule : ValueObject
{
    /// <summary>
    /// Generate a new Schedule
    /// </summary>
    /// <param name="startTime">Init time of schedule</param>
    /// <param name="duration">Duration of service</param>
    /// <param name="dayOfWeek">Day of week (e.g. monday, tuesday)</param>
    /// <param name="model">Type of provision (e.g. Presential, Remote)</param>
    public Schedule(
        DateTime startTime,
        float duration,
        DayOfWeek dayOfWeek,
        Model model
    )
    {
        StartTime = startTime;
        Duration = duration;
        DayOfWeek = dayOfWeek;
        Model = model;
        EndTime = SetEndTime(Duration);
        
        InvalidScheduleException.ThrowEndTimeGreatThanStartTime(StartTime, EndTime);
        //InvalidScheduleException.ThrowUnavailableSchedule(startTime, EndTime);
    }
    
    public DateTime SetEndTime(float duration)
    {
        return StartTime.AddHours(duration);
    }

    /// <summary>
    /// Start time of schedule
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// End time of schedule
    /// </summary>
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Duration of service
    /// </summary>
    public float Duration { get; set; }

    /// <summary>
    /// Day of frequency
    /// </summary>
    public DayOfWeek DayOfWeek { get; set; }

    /// <summary>
    /// Model of service 
    /// </summary>
    public Model Model { get; set; }
}
