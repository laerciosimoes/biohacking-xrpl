namespace Application.EventHandlers.Patient;
public class UpdatePatientEventHandler : EventHandler<UpdatePatient, IPatientState>
{
    public UpdatePatientEventHandler(IPatientState state, IDp dp) : base(state, dp)
    {
    }
    public override dynamic Handle(UpdatePatient updatePatient)
    {
        var patient = updatePatient.Get<Domain.Aggregates.Patient.Patient>();
        var result = Dp.State.Patient.Update(patient);
        return result;
    }
}