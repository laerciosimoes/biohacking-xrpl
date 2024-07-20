namespace Application.EventHandlers.Patient;
public class PatientGetEventHandler : EventHandler<PatientGet, IPatientState>
{
    public PatientGetEventHandler(IPatientState state, IDp dp) : base(state, dp)
    {
    }
    public override dynamic Handle(PatientGet domainEvent)
    {
        var source = Dp.State.Patient.GetAll(domainEvent.Limit, domainEvent.Offset, domainEvent.Ordering, domainEvent.Sort, domainEvent.Filter);
        var total = Dp.State.Patient.Total(domainEvent.Filter);
        return (source, total);
    }
}