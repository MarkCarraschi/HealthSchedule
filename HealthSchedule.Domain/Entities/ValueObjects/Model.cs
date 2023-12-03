using System.ComponentModel;

namespace HealthSchedule.Domain.Entities.ValueObjects;

public enum Model
{
    [Description("Presential")]
    Presential,
    [Description("Remote")]
    Remote
}
