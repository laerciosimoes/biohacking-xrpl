namespace Application.Services.Patient;
public class PatientService : ApplicationService<IPatientState>, IPatientService
{
    public PatientService(IPatientState state, IDp dp) : base(state, dp)
    {
    }
    public void Add(Model.Patient command)
    {
        Dp.Pipeline(Execute: () =>
        {
            var patient = command.ToDomain();
            Dp.Attach(patient);
            patient.Add();
        });
    }
    public void Update(Model.Patient command)
    {
        Dp.Pipeline(Execute: () =>
        {
            var patient = command.ToDomain();
            Dp.Attach(patient);
            patient.Update();
        });
    }
    public void Delete(Model.Patient command)
    {
        Dp.Pipeline(Execute: () =>
        {
            var patient = command.ToDomain();
            Dp.Attach(patient);
            patient.Delete();
        });
    }
    public PagingResult<IList<Model.Patient>> GetAll(Model.Patient query)
    {
        return Dp.Pipeline(ExecuteResult: () =>
        {
            var patient = query.ToDomain();
            Dp.Attach(patient);
            var patientList = patient.Get(query.Limit, query.Offset, query.Ordering, query.Sort, query.Filter);
            var result = query.ToPatientList(patientList.Result, patientList.Total, query.Offset, query.Limit);
            return result;
        });
    }
    public Model.Patient Get(Model.Patient query)
    {
        return Dp.Pipeline(ExecuteResult: () =>
        {
            var patient = query.ToDomain();
            Dp.Attach(patient);
            patient = patient.GetByID();
            var result = query.ToPatient(patient);
            return result;
        });
    }
}