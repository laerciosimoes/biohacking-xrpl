namespace Core.Tests;
public class DeletePatientEventHandlerTest
{
    public DeletePatient Create_Patient_Object_OK(DpTest dpTest)
    {
        var patient = PatientTest.Create_Patient_Required_Properties_OK(dpTest);
        var deletePatient = new DeletePatient();
        dpTest.SetDomainEventObject(deletePatient, patient);
        return deletePatient;
    }
    [Fact]
    [Trait("EventHandler", "DeletePatientEventHandler")]
    [Trait("EventHandler", "Success")]
    public void Handle_PatientObjectFilled_Success()
    {
        //Arrange
        var dpTest = new DpTest();
        object parameter = null;
        var deletePatient = Create_Patient_Object_OK(dpTest);
        var patient = dpTest.GetDomainEventObject<Domain.Aggregates.Patient.Patient>(deletePatient);
        var repositoryMock = new Mock<IPatientRepository>();
        repositoryMock.Setup((o) => o.Delete(patient.ID)).Returns(true).Callback(() =>
        {
            parameter = patient;
        });
        var repository = repositoryMock.Object;
        var stateMock = new Mock<IPatientState>();
        stateMock.SetupGet((o) => o.Patient).Returns(repository);
        var state = stateMock.Object;
        var deletePatientEventHandler = new Application.EventHandlers.Patient.DeletePatientEventHandler(state, dpTest.MockDp<IPatientState>(state));
        //Act
        var result = deletePatientEventHandler.Handle(deletePatient);
        //Assert
        Assert.Equal(parameter, patient);
        Assert.Equal(result, true);
    }
}