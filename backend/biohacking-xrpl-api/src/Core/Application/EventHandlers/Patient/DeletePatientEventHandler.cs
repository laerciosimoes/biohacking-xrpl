namespace Application.EventHandlers.Patient;
public class DeletePatientEventHandler : EventHandler<DeletePatient, IPatientState>
{
    public DeletePatientEventHandler(IPatientState state, IDp dp) : base(state, dp)
    {
    }
    public override dynamic Handle(DeletePatient deletePatient)
    {
        var patient = deletePatient.Get<Domain.Aggregates.Patient.Patient>();
        var result = Dp.State.Patient.Delete(patient.ID);
        return result;
    }
}