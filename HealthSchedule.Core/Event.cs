using HealthSchedule.Core.ValueObjects;
namespace HealthSchedule.Core;

public class Event
{
    /// <summary>
    /// Create a new event
    /// </summary>
    /// <param name="schedule">A plan for carrying out of events and times</param>
    /// <param name="professional">Who do the service</param>
    /// <param name="patient">Who receive the service</param>
    public Event(
        Schedule schedule,
        Professional professional,
        Patient patient
    )
    {
        Id = new Guid();
        Schedule = schedule;
        Professional = professional;
        Patient = patient;

        InvalidEventException.ThrowPatientBeingAssignedProfessional(patient, professional);
    }
    /// <summary>
    /// Exclusive identifier of event
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// A plan for carrying out of events and times.
    /// </summary>
    public Schedule Schedule { get; set; }

    /// <summary>
    /// Who do the service
    /// </summary>
    public Professional Professional { get; set; }
    
    /// <summary>
    /// Who receive the service
    /// </summary>
    public Patient Patient { get; set; }
}
