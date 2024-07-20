namespace Application.EventHandlers.Patient;
public class PatientGetByIDEventHandler : EventHandler<PatientGetByID, IPatientState>
{
    public PatientGetByIDEventHandler(IPatientState state, IDp dp) : base(state, dp)
    {
    }
    public override dynamic Handle(PatientGetByID patientGetByID)
    {
        var patient = patientGetByID.Get<Domain.Aggregates.Patient.Patient>();
        var result = Dp.State.Patient.Get(patient.ID);
        return result;
    }
}