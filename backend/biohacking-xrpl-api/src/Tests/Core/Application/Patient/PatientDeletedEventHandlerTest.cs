namespace Core.Tests;
public class PatientDeletedEventHandlerTest
{
    public Dictionary<string, string> CustomSettings()
    {
        var settings = new Dictionary<string, string>();
        settings.Add("stream.patientevents", "patientevents");
        return settings;
    }
    private PatientDeletedEventDTO SetEventData(Domain.Aggregates.Patient.Patient patient)
    {
        return new PatientDeletedEventDTO()
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
    }
    public PatientDeleted Create_Patient_Object_OK(DpTest dpTest)
    {
        var patient = PatientTest.Create_Patient_Required_Properties_OK(dpTest);
        var patientDeleted = new PatientDeleted();
        dpTest.SetDomainEventObject(patientDeleted, patient);
        return patientDeleted;
    }
    [Fact]
    [Trait("EventHandler", "PatientDeletedEventHandler")]
    [Trait("EventHandler", "Success")]
    public void Handle_PatientObjectFilled_Success()
    {
        //Arrange
        var dpTest = new DpTest();
        var settings = CustomSettings();
        var patientDeleted = Create_Patient_Object_OK(dpTest);
        var patient = dpTest.GetDomainEventObject<Domain.Aggregates.Patient.Patient>(patientDeleted);
        var patientDeletedEventHandler = new Application.EventHandlers.Patient.PatientDeletedEventHandler(null, dpTest.MockDp<IPatientState>(null));
        dpTest.SetupSettings(patientDeletedEventHandler.Dp, settings);
        dpTest.SetupStream(patientDeletedEventHandler.Dp);
        //Act
        var result = patientDeletedEventHandler.Handle(patientDeleted);
        //Assert
        var sentEvents = dpTest.GetSentEvents(patientDeletedEventHandler.Dp);
        var patientDeletedEventDTO = SetEventData(patient);
        Assert.Equal(sentEvents[0].Destination, settings["stream.patientevents"]);
        Assert.Equal("PatientDeleted", sentEvents[0].EventName);
        Assert.Equivalent(sentEvents[0].EventData, patientDeletedEventDTO);
        Assert.Equal(result, true);
    }
}