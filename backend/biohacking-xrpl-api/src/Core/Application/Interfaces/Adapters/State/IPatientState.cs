namespace Application.Interfaces.Adapters.State;
public interface IPatientState
{
    IPatientRepository Patient { get; set; }
}