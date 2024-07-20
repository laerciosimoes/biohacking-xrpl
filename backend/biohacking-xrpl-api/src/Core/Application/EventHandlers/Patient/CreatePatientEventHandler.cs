namespace Application.EventHandlers.Patient;
public class CreatePatientEventHandler : EventHandler<CreatePatient, IPatientState>
{
    public CreatePatientEventHandler(IPatientState state, IDp dp) : base(state, dp)
    {
    }
    public override dynamic Handle(CreatePatient createPatient)
    {
        var patient = createPatient.Get<Domain.Aggregates.Patient.Patient>();
        var result = Dp.State.Patient.Add(patient);
        return result;
    }
}