using HealthSchedule.Core.ValueObjects;
namespace HealthSchedule.Core;

public class Event
{

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

    public Guid Id { get; set; }
    public Schedule Schedule { get; set; }
    public Professional Professional { get; set; }
    public Patient Patient { get; set; }
}
