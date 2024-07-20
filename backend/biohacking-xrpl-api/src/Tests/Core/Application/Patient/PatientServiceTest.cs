namespace Core.Tests;
public class PatientServiceTest
{
    public Application.Services.Patient.Model.Patient SetupCommand(Action add, Action update, Action delete, DpTest dpTest)
    {
        var domainPatientMock = new Mock<Domain.Aggregates.Patient.Patient>();
        domainPatientMock.Setup((o) => o.Add()).Callback(add);
        domainPatientMock.Setup((o) => o.Update()).Callback(update);
        domainPatientMock.Setup((o) => o.Delete()).Callback(delete);
        var patient = domainPatientMock.Object;
        dpTest.MockDpDomain(patient);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<DateTime>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        var applicationPatientMock = new Mock<Application.Services.Patient.Model.Patient>();
        applicationPatientMock.Setup((o) => o.ToDomain()).Returns(patient);
        var applicationPatient = applicationPatientMock.Object;
        return applicationPatient;
    }
    public IPatientService SetupApplicationService(DpTest dpTest)
    {
        var state = new Mock<IPatientState>().Object;
        var patientService = new Application.Services.Patient.PatientService(state, dpTest.MockDp());
        return patientService;
    }
    [Fact]
    [Trait("ApplicationService", "PatientService")]
    [Trait("ApplicationService", "Success")]
    public void Add_CommandNotNull_Success()
    {
        //Arrange
        var dpTest = new DpTest();
        var addCalled = false;
        var add = () =>
        {
            addCalled = true;
        };
        var command = SetupCommand(add, () =>
        {
        }, () =>
        {
        }, dpTest);
        var patientService = SetupApplicationService(dpTest);
        //Act
        patientService.Add(command);
        //Assert
        Assert.True(addCalled);
    }
    [Fact]
    [Trait("ApplicationService", "PatientService")]
    [Trait("ApplicationService", "Success")]
    public void Update_CommandFilled_Success()
    {
        //Arrange
        var dpTest = new DpTest();
        var updateCalled = false;
        var update = () =>
        {
            updateCalled = true;
        };
        var command = SetupCommand(() =>
        {
        }, update, () =>
        {
        }, dpTest);
        var patientService = SetupApplicationService(dpTest);
        //Act
        patientService.Update(command);
        //Assert
        Assert.True(updateCalled);
    }
    [Fact]
    [Trait("ApplicationService", "PatientService")]
    [Trait("ApplicationService", "Success")]
    public void Delete_CommandFilled_Success()
    {
        //Arrange        
        var dpTest = new DpTest();
        var deleteCalled = false;
        var delete = () =>
        {
            deleteCalled = true;
        };
        var command = SetupCommand(() =>
        {
        }, () =>
        {
        }, delete, dpTest);
        var patientService = SetupApplicationService(dpTest);
        //Act
        patientService.Delete(command);
        //Assert
        Assert.True(deleteCalled);
    }
}