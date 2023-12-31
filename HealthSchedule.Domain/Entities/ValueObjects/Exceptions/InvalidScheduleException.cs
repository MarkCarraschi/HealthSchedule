﻿namespace HealthSchedule.Domain.Entities.ValueObjects.Exceptions;

public partial class InvalidScheduleException : Exception
{
    private const string DefaultErrorMessage = "Invalid schedule";
    private const string PastStartEndTimeErrorMessage = "The end time should be later than the start time";
    private const string UnavailableScheduleErrorMessage = "Unavailable schedule";

    public InvalidScheduleException(string message = DefaultErrorMessage) 
        : base(message)
    {

    }

    public static void ThrowUnavailableSchedule(
        Schedule schedule,
        IEnumerable<Schedule> schedules
    )
    {
        bool unavailableSchedule = schedules.
                        Where(item => item.DayOfWeek == schedule.DayOfWeek && 
                                      item.StartTime == schedule.StartTime)
                        .ToList()
                        .Count > 0 ? true : false;

        if(unavailableSchedule)
            throw new InvalidScheduleException(UnavailableScheduleErrorMessage);

    }

    public static void ThrowEndTimeGreatThanStartTime(DateTime startTime, DateTime endTime)
    {
        if(endTime < startTime)
            throw new InvalidScheduleException(PastStartEndTimeErrorMessage);
    }
}
