namespace Application.Interfaces.Services;
public interface IPatientService
{
    void Add(Application.Services.Patient.Model.Patient command);
    void Update(Application.Services.Patient.Model.Patient command);
    void Delete(Application.Services.Patient.Model.Patient command);
    Application.Services.Patient.Model.Patient Get(Application.Services.Patient.Model.Patient query);
    PagingResult<IList<Application.Services.Patient.Model.Patient>> GetAll(Application.Services.Patient.Model.Patient query);
}