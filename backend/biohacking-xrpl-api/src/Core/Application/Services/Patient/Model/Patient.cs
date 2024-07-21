namespace Application.Services.Patient.Model;
public class Patient
{
    internal int? Limit { get; set; }
    internal int? Offset { get; set; }
    internal string Ordering { get; set; }
    internal string Filter { get; set; }
    internal string Sort { get; set; }
    public Patient(int? limit, int? offset, string ordering, string sort, string filter)
    {
        Limit = limit;
        Offset = offset;
        Ordering = ordering;
        Filter = filter;
        Sort = sort;
    }
    public Guid ID { get; set; }
    public string WalletAddress { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
    public Nullable<System.DateTime> DateOfBirth { get; set; }
    public string EmergencyContact { get; set; }
    public string MedicalConditions { get; set; }
    public string MedicalHistoric { get; set; }
    public string Medications { get; set; }
    public string Allergies { get; set; }
    public string BloodType { get; set; }
    public string SocialHistory { get; set; }
    public virtual PagingResult<IList<Patient>> ToPatientList(IList<Domain.Aggregates.Patient.Patient> patientList, long? total, int? offSet, int? limit)
    {
        var _patientList = ToApplication(patientList);
        return new PagingResult<IList<Patient>>(_patientList, total, offSet, limit);
    }
    public virtual Patient ToPatient(Domain.Aggregates.Patient.Patient patient)
    {
        var _patient = ToApplication(patient);
        return _patient;
    }
    public virtual Domain.Aggregates.Patient.Patient ToDomain()
    {
        var _patient = ToDomain(this);
        return _patient;
    }
    public virtual Domain.Aggregates.Patient.Patient ToDomain(Guid id)
    {
        var _patient = new Domain.Aggregates.Patient.Patient();
        _patient.ID = id;
        return _patient;
    }
    public Patient()
    {
    }
    public Patient(Guid id)
    {
        ID = id;
    }
    public static Application.Services.Patient.Model.Patient ToApplication(Domain.Aggregates.Patient.Patient patient)
    {
        if (patient is null)
            return new Application.Services.Patient.Model.Patient();
        Application.Services.Patient.Model.Patient _patient = new Application.Services.Patient.Model.Patient();
        _patient.ID = patient.ID;
        _patient.WalletAddress = patient.WalletAddress;
        _patient.Name = patient.Name;
        _patient.Email = patient.Email;
        _patient.Phone = patient.Phone;
        _patient.Address = patient.Address;
        _patient.City = patient.City;
        _patient.State = patient.State;
        _patient.Zip = patient.Zip;
        _patient.Country = patient.Country;
        _patient.DateOfBirth = patient.DateOfBirth;
        _patient.EmergencyContact = patient.EmergencyContact;
        _patient.MedicalConditions = patient.MedicalConditions;
        _patient.MedicalHistoric = patient.MedicalHistoric;
        _patient.Medications = patient.Medications;
        _patient.Allergies = patient.Allergies;
        _patient.BloodType = patient.BloodType;
        _patient.SocialHistory = patient.SocialHistory;
        return _patient;
    }
    public static List<Application.Services.Patient.Model.Patient> ToApplication(IList<Domain.Aggregates.Patient.Patient> patientList)
    {
        List<Application.Services.Patient.Model.Patient> _patientList = new List<Application.Services.Patient.Model.Patient>();
        if (patientList != null)
        {
            foreach (var patient in patientList)
            {
                Application.Services.Patient.Model.Patient _patient = new Application.Services.Patient.Model.Patient();
                _patient.ID = patient.ID;
                _patient.WalletAddress = patient.WalletAddress;
                _patient.Name = patient.Name;
                _patient.Email = patient.Email;
                _patient.Phone = patient.Phone;
                _patient.Address = patient.Address;
                _patient.City = patient.City;
                _patient.State = patient.State;
                _patient.Zip = patient.Zip;
                _patient.Country = patient.Country;
                _patient.DateOfBirth = patient.DateOfBirth;
                _patient.EmergencyContact = patient.EmergencyContact;
                _patient.MedicalConditions = patient.MedicalConditions;
                _patient.MedicalHistoric = patient.MedicalHistoric;
                _patient.Medications = patient.Medications;
                _patient.Allergies = patient.Allergies;
                _patient.BloodType = patient.BloodType;
                _patient.SocialHistory = patient.SocialHistory;
                _patientList.Add(_patient);
            }
        }
        return _patientList;
    }
    public static Domain.Aggregates.Patient.Patient ToDomain(Application.Services.Patient.Model.Patient patient)
    {
        if (patient is null)
            return new Domain.Aggregates.Patient.Patient();
        Domain.Aggregates.Patient.Patient _patient = new Domain.Aggregates.Patient.Patient(patient.ID, patient.WalletAddress, patient.Name, patient.Email, patient.Phone, patient.Address, patient.City, patient.State, patient.Zip, patient.Country, patient.DateOfBirth, patient.EmergencyContact, patient.MedicalConditions, patient.MedicalHistoric, patient.Medications, patient.Allergies, patient.BloodType, patient.SocialHistory);
        return _patient;
    }
    public static List<Domain.Aggregates.Patient.Patient> ToDomain(IList<Application.Services.Patient.Model.Patient> patientList)
    {
        List<Domain.Aggregates.Patient.Patient> _patientList = new List<Domain.Aggregates.Patient.Patient>();
        if (patientList != null)
        {
            foreach (var patient in patientList)
            {
                Domain.Aggregates.Patient.Patient _patient = new Domain.Aggregates.Patient.Patient(patient.ID, patient.WalletAddress, patient.Name, patient.Email, patient.Phone, patient.Address, patient.City, patient.State, patient.Zip, patient.Country, patient.DateOfBirth, patient.EmergencyContact, patient.MedicalConditions, patient.MedicalHistoric, patient.Medications, patient.Allergies, patient.BloodType, patient.SocialHistory);
                _patientList.Add(_patient);
            }
        }
        return _patientList;
    }
}