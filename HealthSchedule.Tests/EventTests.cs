using HealthSchedule.Domain.Entities;
using HealthSchedule.Domain.Entities.ValueObjects;
using HealthSchedule.Domain.Entities.ValueObjects.Exceptions;

namespace HealthSchedule.Tests;

[TestClass]
public class EventTests
{    

    public const DayOfWeek constDayOfWeek = DayOfWeek.Thursday;
    public const Model constModel = Model.Presential;
    public const float constDuration = 1.0f;
    public DateTime startDate = new DateTime(2023,07,11,09,15,00);

    [TestMethod]
    [DataRow("Jorginho Dev Pleno", "Jorginho Dev Pleno","36809106065","36809106065", true)]
    [DataRow("Jorginho Burning Down", "Tudo errado!", "36809106065", "24840824878", false)]
    public void ShouldReturnExceptionWhenProfessionalBeingAssignedPacient(
        string professionalName,
        string patientName,
        string professionalCpf,
        string patientCpf,
        bool expectedException
    )
    {
        
        Professional professional = new Professional(
            professionalCpf,
            professionalName,
            new DateTime(1973,04,22),
            "Psychiatrist"
        );

        Patient pacient = new Patient(
            patientCpf,
            patientName,
            new DateTime(1973,04,22)
        );

        Schedule schedule = new Schedule(startDate, constDuration, constDayOfWeek, constModel);
        
        if(expectedException)
        {
            try
            {
                new Event(schedule, professional, pacient);
                Assert.Fail();
            }
            catch(InvalidEventException)
            {
                Assert.IsTrue(true);
            }
        }
        else
        {
            new Event(schedule, professional, pacient);
            Assert.IsTrue(true);
        }
    }
}