namespace Domain.Aggregates.Patient;
public class Patient : AggRoot
{
    public string WalletAddress { get; private set; }
    public string Name { get; private set; }
#nullable enable
    public string? Email { get; private set; }
    public string? Phone { get; private set; }
    public string? Address { get; private set; }
    public string? City { get; private set; }
    public string? State { get; private set; }
    public string? Zip { get; private set; }
    public string? Country { get; private set; }
    public DateTime? DateOfBirth { get; private set; }
    public string? EmergencyContact { get; private set; }
    public string? MedicalConditions { get; private set; }
    public string? MedicalHistoric { get; private set; }
    public string? Medications { get; private set; }
    public string? Allergies { get; private set; }
    public string? BloodType { get; private set; }
    public string? SocialHistory { get; private set; }
    public Patient(Guid id, string walletAddress, string name, string? email, string? phone, string? address, string? city, string? state, string? zip, string? country, DateTime? dateOfBirth, string? emergencyContact, string? medicalConditions, string? medicalHistoric, string? medications, string? allergies, string? bloodType, string? socialHistory)
    {
        ID = id;
        WalletAddress = walletAddress;
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
        City = city;
        State = state;
        Zip = zip;
        Country = country;
        DateOfBirth = dateOfBirth;
        EmergencyContact = emergencyContact;
        MedicalConditions = medicalConditions;
        MedicalHistoric = medicalHistoric;
        Medications = medications;
        Allergies = allergies;
        BloodType = bloodType;
        SocialHistory = socialHistory;
    }
    
#nullable restore
    public Patient()
    {
    }
    public virtual void Add()
    {
        Dp.Pipeline(Execute: () =>
        {
            ValidFields();
            ID = Guid.NewGuid();
            IsNew = true;
            var success = Dp.ProcessEvent<bool>(new CreatePatient());
            if (success)
            {
                Dp.ProcessEvent(new PatientCreated());
            }
        });
    }
    public virtual void Update()
    {
        Dp.Pipeline(Execute: () =>
        {
            if (ID.Equals(Guid.Empty))
                Dp.Notifications.Add("ID is required");
            ValidFields();
            var success = Dp.ProcessEvent<bool>(new UpdatePatient());
            if (success)
            {
                Dp.ProcessEvent(new PatientUpdated());
            }
        });
    }
    public virtual void Delete()
    {
        Dp.Pipeline(Execute: () =>
        {
            if (ID != Guid.Empty)
            {
                var success = Dp.ProcessEvent<bool>(new DeletePatient());
                if (success)
                {
                    Dp.ProcessEvent(new PatientDeleted());
                }
            }
        });
    }
    public virtual (List<Patient> Result, long Total) Get(int? limit, int? offset, string ordering, string sort, string filter)
    {
        return Dp.Pipeline(ExecuteResult: () =>
        {
            ValidateOrdering(limit, offset, ordering, sort);
            if (!string.IsNullOrWhiteSpace(filter))
            {
                bool filterIsValid = false;
                if (filter.Contains("="))
                {
                    if (filter.ToLower().StartsWith("id="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("walletaddress="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("name="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("email="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("phone="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("address="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("city="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("state="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("zip="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("country="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("dateofbirth="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("emergencycontact="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("medicalconditions="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("medicalhistoric="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("medications="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("allergies="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("bloodtype="))
                        filterIsValid = true;
                    if (filter.ToLower().StartsWith("socialhistory="))
                        filterIsValid = true;
                }
                if (!filterIsValid)
                    throw new PublicException($"Invalid filter '{filter}' is invalid try: 'ID', 'WalletAddress', 'Name', 'Email', 'Phone', 'Address', 'City', 'State', 'Zip', 'Country', 'DateOfBirth', 'EmergencyContact', 'MedicalConditions', 'MedicalHistoric', 'Medications', 'Allergies', 'BloodType', 'SocialHistory',");
            }
            var source = Dp.ProcessEvent(new PatientGet() { Limit = limit, Offset = offset, Ordering = ordering, Sort = sort, Filter = filter });
            return source;
        });
    }
    public virtual Patient GetByID()
    {
        var result = Dp.Pipeline(ExecuteResult: () =>
        {
            return Dp.ProcessEvent<Patient>(new PatientGetByID());
        });
        return result;
    }
    private void ValidFields()
    {
        if (String.IsNullOrWhiteSpace(WalletAddress))
            Dp.Notifications.Add("WalletAddress is required");
        if (String.IsNullOrWhiteSpace(Name))
            Dp.Notifications.Add("Name is required");
        Dp.Notifications.ValidateAndThrow();
    }
}