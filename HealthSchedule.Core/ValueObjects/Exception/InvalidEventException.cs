namespace HealthSchedule.Core.ValueObjects;

public class InvalidEventException : Exception
{

    private const string DefaultErrorMessage = "Invalid event";
    private const string PatientBeingAssignedProfessionalErrorMessage = "Peoples in the role of a patient cannot assume the role of a professional";

    public InvalidEventException(string message = DefaultErrorMessage) : base(message)
    {

    }

    public static void ThrowPatientBeingAssignedProfessional(
        Patient patient,
        Professional professional
    )
    {
        string cpfPatient = patient.Cpf;
        string cpfProfessional = professional.Cpf;

        if(cpfPatient.Equals(cpfProfessional))
            throw new InvalidEventException(PatientBeingAssignedProfessionalErrorMessage);
    }

}