namespace Application.EventHandlers.Patient;
public class PatientDeletedEventHandler : EventHandler<PatientDeleted, IPatientState>
{
    public PatientDeletedEventHandler(IPatientState state, IDp dp) : base(state, dp)
    {
    }
    public override dynamic Handle(PatientDeleted patientDeleted)
    {
        var success = false;
        var patient = patientDeleted.Get<Domain.Aggregates.Patient.Patient>();
        var destination = Dp.Settings.Default("stream.patientevents");
        var eventName = "PatientDeleted";
        var eventData = new PatientDeletedEventDTO()
        {
            ID = patient.ID,
            WalletAddress = patient.WalletAddress,
            Name = patient.Name,
            Email = patient.Email,
            Phone = patient.Phone,
            Address = patient.Address,
            City = patient.City,
            State = patient.State,
            Zip = patient.Zip,
            Country = patient.Country,
            DateOfBirth = patient.DateOfBirth,
            EmergencyContact = patient.EmergencyContact,
            MedicalConditions = patient.MedicalConditions,
            MedicalHistoric = patient.MedicalHistoric,
            Medications = patient.Medications,
            Allergies = patient.Allergies,
            BloodType = patient.BloodType,
            SocialHistory = patient.SocialHistory
        };
        Dp.Stream.Send(destination, eventName, eventData);
        success = true;
        return success;
    }
}