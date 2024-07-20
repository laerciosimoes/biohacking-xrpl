namespace DevPrime.State.States;
public class PatientState : IPatientState
{
    public IPatientRepository Patient { get; set; }
    public PatientState(IPatientRepository patient)
    {
        Patient = patient;
    }
}