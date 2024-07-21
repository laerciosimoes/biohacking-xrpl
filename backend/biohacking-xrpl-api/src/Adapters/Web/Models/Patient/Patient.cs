namespace DevPrime.Web.Models.Patient;
public class Patient
{
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
    public static Application.Services.Patient.Model.Patient ToApplication(DevPrime.Web.Models.Patient.Patient patient)
    {
        if (patient is null)
            return new Application.Services.Patient.Model.Patient();
        Application.Services.Patient.Model.Patient _patient = new Application.Services.Patient.Model.Patient();
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
    public static List<Application.Services.Patient.Model.Patient> ToApplication(IList<DevPrime.Web.Models.Patient.Patient> patientList)
    {
        List<Application.Services.Patient.Model.Patient> _patientList = new List<Application.Services.Patient.Model.Patient>();
        if (patientList != null)
        {
            foreach (var patient in patientList)
            {
                Application.Services.Patient.Model.Patient _patient = new Application.Services.Patient.Model.Patient();
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
    public virtual Application.Services.Patient.Model.Patient ToApplication()
    {
        var model = ToApplication(this);
        return model;
    }
}