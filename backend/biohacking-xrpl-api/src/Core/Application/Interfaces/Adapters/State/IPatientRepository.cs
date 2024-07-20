namespace Application.Interfaces.Adapters.State;
public interface IPatientRepository
{
    bool Add(Domain.Aggregates.Patient.Patient source);
    bool Delete(Guid Id);
    bool Update(Domain.Aggregates.Patient.Patient source);
    Domain.Aggregates.Patient.Patient Get(Guid Id);
    List<Domain.Aggregates.Patient.Patient> GetAll(int? limit, int? offset, string ordering, string sort, string filter);
    bool Exists(Guid id);
    long Total(string filter);
}