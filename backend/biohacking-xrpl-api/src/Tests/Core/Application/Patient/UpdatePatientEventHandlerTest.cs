namespace Core.Tests;
public class UpdatePatientEventHandlerTest
{
    public UpdatePatient Create_Patient_Object_OK(DpTest dpTest)
    {
        var patient = PatientTest.Create_Patient_Required_Properties_OK(dpTest);
        var updatePatient = new UpdatePatient();
        dpTest.SetDomainEventObject(updatePatient, patient);
        return updatePatient;
    }
    [Fact]
    [Trait("EventHandler", "UpdatePatientEventHandler")]
    [Trait("EventHandler", "Success")]
    public void Handle_PatientObjectFilled_Success()
    {
        //Arrange
        var dpTest = new DpTest();
        object parameter = null;
        var updatePatient = Create_Patient_Object_OK(dpTest);
        var patient = dpTest.GetDomainEventObject<Domain.Aggregates.Patient.Patient>(updatePatient);
        var repositoryMock = new Mock<IPatientRepository>();
        repositoryMock.Setup((o) => o.Update(patient)).Returns(true).Callback(() =>
        {
            parameter = patient;
        });
        var repository = repositoryMock.Object;
        var stateMock = new Mock<IPatientState>();
        stateMock.SetupGet((o) => o.Patient).Returns(repository);
        var state = stateMock.Object;
        var updatePatientEventHandler = new Application.EventHandlers.Patient.UpdatePatientEventHandler(state, dpTest.MockDp<IPatientState>(state));
        //Act
        var result = updatePatientEventHandler.Handle(updatePatient);
        //Assert
        Assert.Equal(parameter, patient);
        Assert.Equal(result, true);
    }
}