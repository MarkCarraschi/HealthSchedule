using System.Globalization;
using System;
using HealthSchedule.Core;
using HealthSchedule.Core.ValueObjects;

namespace HealthSchedule.Tests.ValueObjects;

[TestClass]
public class ScheduleTests
{
    public const DayOfWeek constDayOfWeek = DayOfWeek.Thursday;
    public const Model constModel = Model.Presential;
    public const decimal constDuration = 1.0m;
    public DateTime startDate = new DateTime(2023,07,11,09,15,00);

    [TestMethod]
    [DataRow(1.0F, false)]
    [DataRow(1.5F, false)]
    [DataRow(-1.0F, true)]
    [DataRow(-1.5F, true)]
    public void ShouldReturnExceptionWhenDurationScheduleIsInvalid(
        float duration,
        bool expectedException
    )
    {        
        if(expectedException)
        {
            try
            {
                new Schedule(startDate, duration, constDayOfWeek, constModel);
                Assert.Fail();
            }
            catch(InvalidScheduleException)
            {
                Assert.IsTrue(true);
            }
        }else{
            new Schedule(startDate, duration, constDayOfWeek, constModel);
            Assert.IsTrue(true);
        }
    }
}
