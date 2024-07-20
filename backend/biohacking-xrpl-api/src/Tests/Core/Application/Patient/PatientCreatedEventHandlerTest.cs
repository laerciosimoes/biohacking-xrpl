namespace Core.Tests;
public class PatientCreatedEventHandlerTest
{
    public Dictionary<string, string> CustomSettings()
    {
        var settings = new Dictionary<string, string>();
        settings.Add("stream.patientevents", "patientevents");
        return settings;
    }
    private PatientCreatedEventDTO SetEventData(Domain.Aggregates.Patient.Patient patient)
    {
        return new PatientCreatedEventDTO()
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
    public PatientCreated Create_Patient_Object_OK(DpTest dpTest)
    {
        var patient = PatientTest.Create_Patient_Required_Properties_OK(dpTest);
        var patientCreated = new PatientCreated();
        dpTest.SetDomainEventObject(patientCreated, patient);
        return patientCreated;
    }
    [Fact]
    [Trait("EventHandler", "PatientCreatedEventHandler")]
    [Trait("EventHandler", "Success")]
    public void Handle_PatientObjectFilled_Success()
    {
        //Arrange
        var dpTest = new DpTest();
        var settings = CustomSettings();
        var patientCreated = Create_Patient_Object_OK(dpTest);
        var patient = dpTest.GetDomainEventObject<Domain.Aggregates.Patient.Patient>(patientCreated);
        var patientCreatedEventHandler = new Application.EventHandlers.Patient.PatientCreatedEventHandler(null, dpTest.MockDp<IPatientState>(null));
        dpTest.SetupSettings(patientCreatedEventHandler.Dp, settings);
        dpTest.SetupStream(patientCreatedEventHandler.Dp);
        //Act
        var result = patientCreatedEventHandler.Handle(patientCreated);
        //Assert
        var sentEvents = dpTest.GetSentEvents(patientCreatedEventHandler.Dp);
        var patientCreatedEventDTO = SetEventData(patient);
        Assert.Equal(sentEvents[0].Destination, settings["stream.patientevents"]);
        Assert.Equal("PatientCreated", sentEvents[0].EventName);
        Assert.Equivalent(sentEvents[0].EventData, patientCreatedEventDTO);
        Assert.Equal(result, true);
    }
}