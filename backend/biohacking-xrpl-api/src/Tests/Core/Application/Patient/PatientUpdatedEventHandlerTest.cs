namespace Core.Tests;
public class PatientUpdatedEventHandlerTest
{
    public Dictionary<string, string> CustomSettings()
    {
        var settings = new Dictionary<string, string>();
        settings.Add("stream.patientevents", "patientevents");
        return settings;
    }
    private PatientUpdatedEventDTO SetEventData(Domain.Aggregates.Patient.Patient patient)
    {
        return new PatientUpdatedEventDTO()
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
    public PatientUpdated Create_Patient_Object_OK(DpTest dpTest)
    {
        var patient = PatientTest.Create_Patient_Required_Properties_OK(dpTest);
        var patientUpdated = new PatientUpdated();
        dpTest.SetDomainEventObject(patientUpdated, patient);
        return patientUpdated;
    }
    [Fact]
    [Trait("EventHandler", "PatientUpdatedEventHandler")]
    [Trait("EventHandler", "Success")]
    public void Handle_PatientObjectFilled_Success()
    {
        //Arrange
        var dpTest = new DpTest();
        var settings = CustomSettings();
        var patientUpdated = Create_Patient_Object_OK(dpTest);
        var patient = dpTest.GetDomainEventObject<Domain.Aggregates.Patient.Patient>(patientUpdated);
        var patientUpdatedEventHandler = new Application.EventHandlers.Patient.PatientUpdatedEventHandler(null, dpTest.MockDp<IPatientState>(null));
        dpTest.SetupSettings(patientUpdatedEventHandler.Dp, settings);
        dpTest.SetupStream(patientUpdatedEventHandler.Dp);
        //Act
        var result = patientUpdatedEventHandler.Handle(patientUpdated);
        //Assert
        var sentEvents = dpTest.GetSentEvents(patientUpdatedEventHandler.Dp);
        var patientUpdatedEventDTO = SetEventData(patient);
        Assert.Equal(sentEvents[0].Destination, settings["stream.patientevents"]);
        Assert.Equal("PatientUpdated", sentEvents[0].EventName);
        Assert.Equivalent(sentEvents[0].EventData, patientUpdatedEventDTO);
        Assert.Equal(result, true);
    }
}