namespace Core.Tests;
public class CreatePatientEventHandlerTest
{
    public CreatePatient Create_Patient_Object_OK(DpTest dpTest)
    {
        var patient = PatientTest.Create_Patient_Required_Properties_OK(dpTest);
        var createPatient = new CreatePatient();
        dpTest.SetDomainEventObject(createPatient, patient);
        return createPatient;
    }
    [Fact]
    [Trait("EventHandler", "CreatePatientEventHandler")]
    [Trait("EventHandler", "Success")]
    public void Handle_PatientObjectFilled_Success()
    {
        //Arrange
        var dpTest = new DpTest();
        object parameter = null;
        var createPatient = Create_Patient_Object_OK(dpTest);
        var patient = dpTest.GetDomainEventObject<Domain.Aggregates.Patient.Patient>(createPatient);
        var repositoryMock = new Mock<IPatientRepository>();
        repositoryMock.Setup((o) => o.Add(patient)).Returns(true).Callback(() =>
        {
            parameter = patient;
        });
        var repository = repositoryMock.Object;
        var stateMock = new Mock<IPatientState>();
        stateMock.SetupGet((o) => o.Patient).Returns(repository);
        var state = stateMock.Object;
        var createPatientEventHandler = new Application.EventHandlers.Patient.CreatePatientEventHandler(state, dpTest.MockDp<IPatientState>(state));
        //Act
        var result = createPatientEventHandler.Handle(createPatient);
        //Assert
        Assert.Equal(parameter, patient);
        Assert.Equal(result, true);
    }
}