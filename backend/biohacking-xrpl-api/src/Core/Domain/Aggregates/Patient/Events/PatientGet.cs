namespace Domain.Aggregates.Patient.Events;
public class PatientGet : DomainEvent
{
    public PatientGet() : base()
    {
    }
    public int? Limit { get; set; }
    public int? Offset { get; set; }
    public string Ordering { get; set; }
    public string Filter { get; set; }
    public string Sort { get; set; }
}