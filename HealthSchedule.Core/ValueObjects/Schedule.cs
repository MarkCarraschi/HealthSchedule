namespace HealthSchedule.Core.ValueObjects;

public class Schedule : ValueObject
{
    public Schedule(
        DateTime startTime,
        decimal duration,
        DayOfWeek dayOfWeek,
        Model model
    )
    {
        StartTime = startTime;
        Duration = duration;
        DayOfWeek = dayOfWeek;
        Model = model;
    }    
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Duration { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public Model Model { get; set; }
}
