namespace DevPrime.State.Repositories.Patient;
public class PatientRepository : RepositoryBase, IPatientRepository
{
    public PatientRepository(IDpState dp) : base(dp)
    {
        ConnectionAlias = "State1";
    }

#region Write
    public bool Add(Domain.Aggregates.Patient.Patient patient)
    {
        var result = Dp.Pipeline(ExecuteResult: (stateContext) =>
        {
            var state = new ConnectionMongo(stateContext, Dp);
            var _patient = ToState(patient);
            state.Patient.InsertOne(_patient);
            return true;
        });
        if (result is null)
            return false;
        return result;
    }
    public bool Delete(Guid patientID)
    {
        var result = Dp.Pipeline(ExecuteResult: (stateContext) =>
        {
            var state = new ConnectionMongo(stateContext, Dp);
            state.Patient.DeleteOne(p => p.ID == patientID);
            return true;
        });
        if (result is null)
            return false;
        return result;
    }
    public bool Update(Domain.Aggregates.Patient.Patient patient)
    {
        var result = Dp.Pipeline(ExecuteResult: (stateContext) =>
        {
            var state = new ConnectionMongo(stateContext, Dp);
            var _patient = ToState(patient);
            _patient._Id = state.Patient.Find(p => p.ID == patient.ID).FirstOrDefault()._Id;
            state.Patient.ReplaceOne(p => p.ID == patient.ID, _patient);
            return true;
        });
        if (result is null)
            return false;
        return result;
    }

#endregion Write

#region Read
    public Domain.Aggregates.Patient.Patient Get(Guid patientID)
    {
        return Dp.Pipeline(ExecuteResult: (stateContext) =>
        {
            var state = new ConnectionMongo(stateContext, Dp);
            var patient = state.Patient.Find(p => p.ID == patientID).FirstOrDefault();
            var _patient = ToDomain(patient);
            return _patient;
        });
    }
    public List<Domain.Aggregates.Patient.Patient> GetAll(int? limit, int? offset, string ordering, string sort, string filter)
    {
        return Dp.Pipeline(ExecuteResult: (stateContext) =>
        {
            var state = new ConnectionMongo(stateContext, Dp);
            List<Model.Patient> patient = null;
            if (sort?.ToLower() == "desc")
            {
                var result = state.Patient.Find(GetFilter(filter)).SortByDescending(GetOrdering(ordering));
                if (limit != null && offset != null)
                    patient = result.Skip((offset - 1) * limit).Limit(limit).ToList();
                else
                    patient = result.ToList();
            }
            else if (sort?.ToLower() == "asc")
            {
                var result = state.Patient.Find(GetFilter(filter)).SortBy(GetOrdering(ordering));
                if (limit != null && offset != null)
                    patient = result.Skip((offset - 1) * limit).Limit(limit).ToList();
                else
                    patient = result.ToList();
            }
            else
            {
                var result = state.Patient.Find(GetFilter(filter));
                if (limit != null && offset != null)
                    patient = result.Skip((offset - 1) * limit).Limit(limit).ToList();
                else
                    patient = result.ToList();
            }
            var _patient = ToDomain(patient);
            return _patient;
        });
    }
    private Expression<Func<Model.Patient, object>> GetOrdering(string field)
    {
        Expression<Func<Model.Patient, object>> exp = p => p.ID;
        if (!string.IsNullOrWhiteSpace(field))
        {
            if (field.ToLower() == "walletaddress")
                exp = p => p.WalletAddress;
            else if (field.ToLower() == "name")
                exp = p => p.Name;
            else if (field.ToLower() == "email")
                exp = p => p.Email;
            else if (field.ToLower() == "phone")
                exp = p => p.Phone;
            else if (field.ToLower() == "address")
                exp = p => p.Address;
            else if (field.ToLower() == "city")
                exp = p => p.City;
            else if (field.ToLower() == "state")
                exp = p => p.State;
            else if (field.ToLower() == "zip")
                exp = p => p.Zip;
            else if (field.ToLower() == "country")
                exp = p => p.Country;
            else if (field.ToLower() == "dateofbirth")
                exp = p => p.DateOfBirth;
            else if (field.ToLower() == "emergencycontact")
                exp = p => p.EmergencyContact;
            else if (field.ToLower() == "medicalconditions")
                exp = p => p.MedicalConditions;
            else if (field.ToLower() == "medicalhistoric")
                exp = p => p.MedicalHistoric;
            else if (field.ToLower() == "medications")
                exp = p => p.Medications;
            else if (field.ToLower() == "allergies")
                exp = p => p.Allergies;
            else if (field.ToLower() == "bloodtype")
                exp = p => p.BloodType;
            else if (field.ToLower() == "socialhistory")
                exp = p => p.SocialHistory;
            else
                exp = p => p.ID;
        }
        return exp;
    }
    private FilterDefinition<Model.Patient> GetFilter(string filter)
    {
        var builder = Builders<Model.Patient>.Filter;
        FilterDefinition<Model.Patient> exp;
        string WalletAddress = string.Empty;
        string Name = string.Empty;
        string Email = string.Empty;
        string Phone = string.Empty;
        string Address = string.Empty;
        string City = string.Empty;
        string State = string.Empty;
        string Zip = string.Empty;
        string Country = string.Empty;
        DateTime? DateOfBirth = null;
        string EmergencyContact = string.Empty;
        string MedicalConditions = string.Empty;
        string MedicalHistoric = string.Empty;
        string Medications = string.Empty;
        string Allergies = string.Empty;
        string BloodType = string.Empty;
        string SocialHistory = string.Empty;
        if (!string.IsNullOrWhiteSpace(filter))
        {
            var conditions = filter.Split(",");
            if (conditions.Count() >= 1)
            {
                foreach (var condition in conditions)
                {
                    var slice = condition?.Split("=");
                    if (slice.Length > 1)
                    {
                        var field = slice[0];
                        var value = slice[1];
                        if (field.ToLower() == "walletaddress")
                            WalletAddress = value;
                        else if (field.ToLower() == "name")
                            Name = value;
                        else if (field.ToLower() == "email")
                            Email = value;
                        else if (field.ToLower() == "phone")
                            Phone = value;
                        else if (field.ToLower() == "address")
                            Address = value;
                        else if (field.ToLower() == "city")
                            City = value;
                        else if (field.ToLower() == "state")
                            State = value;
                        else if (field.ToLower() == "zip")
                            Zip = value;
                        else if (field.ToLower() == "country")
                            Country = value;
                        else if (field.ToLower() == "dateofbirth")
                            DateOfBirth = Convert.ToDateTime(value);
                        else if (field.ToLower() == "emergencycontact")
                            EmergencyContact = value;
                        else if (field.ToLower() == "medicalconditions")
                            MedicalConditions = value;
                        else if (field.ToLower() == "medicalhistoric")
                            MedicalHistoric = value;
                        else if (field.ToLower() == "medications")
                            Medications = value;
                        else if (field.ToLower() == "allergies")
                            Allergies = value;
                        else if (field.ToLower() == "bloodtype")
                            BloodType = value;
                        else if (field.ToLower() == "socialhistory")
                            SocialHistory = value;
                    }
                }
            }
        }
        var bfilter = builder.Empty;
        if (!string.IsNullOrWhiteSpace(WalletAddress))
        {
            var WalletAddressFilter = builder.Eq(x => x.WalletAddress, WalletAddress);
            bfilter &= WalletAddressFilter;
        }
        if (!string.IsNullOrWhiteSpace(Name))
        {
            var NameFilter = builder.Eq(x => x.Name, Name);
            bfilter &= NameFilter;
        }
        if (!string.IsNullOrWhiteSpace(Email))
        {
            var EmailFilter = builder.Eq(x => x.Email, Email);
            bfilter &= EmailFilter;
        }
        if (!string.IsNullOrWhiteSpace(Phone))
        {
            var PhoneFilter = builder.Eq(x => x.Phone, Phone);
            bfilter &= PhoneFilter;
        }
        if (!string.IsNullOrWhiteSpace(Address))
        {
            var AddressFilter = builder.Eq(x => x.Address, Address);
            bfilter &= AddressFilter;
        }
        if (!string.IsNullOrWhiteSpace(City))
        {
            var CityFilter = builder.Eq(x => x.City, City);
            bfilter &= CityFilter;
        }
        if (!string.IsNullOrWhiteSpace(State))
        {
            var StateFilter = builder.Eq(x => x.State, State);
            bfilter &= StateFilter;
        }
        if (!string.IsNullOrWhiteSpace(Zip))
        {
            var ZipFilter = builder.Eq(x => x.Zip, Zip);
            bfilter &= ZipFilter;
        }
        if (!string.IsNullOrWhiteSpace(Country))
        {
            var CountryFilter = builder.Eq(x => x.Country, Country);
            bfilter &= CountryFilter;
        }
        if (DateOfBirth != null)
        {
            var DateOfBirthFilter = builder.Eq(x => x.DateOfBirth, DateOfBirth);
            bfilter &= DateOfBirthFilter;
        }
        if (!string.IsNullOrWhiteSpace(EmergencyContact))
        {
            var EmergencyContactFilter = builder.Eq(x => x.EmergencyContact, EmergencyContact);
            bfilter &= EmergencyContactFilter;
        }
        if (!string.IsNullOrWhiteSpace(MedicalConditions))
        {
            var MedicalConditionsFilter = builder.Eq(x => x.MedicalConditions, MedicalConditions);
            bfilter &= MedicalConditionsFilter;
        }
        if (!string.IsNullOrWhiteSpace(MedicalHistoric))
        {
            var MedicalHistoricFilter = builder.Eq(x => x.MedicalHistoric, MedicalHistoric);
            bfilter &= MedicalHistoricFilter;
        }
        if (!string.IsNullOrWhiteSpace(Medications))
        {
            var MedicationsFilter = builder.Eq(x => x.Medications, Medications);
            bfilter &= MedicationsFilter;
        }
        if (!string.IsNullOrWhiteSpace(Allergies))
        {
            var AllergiesFilter = builder.Eq(x => x.Allergies, Allergies);
            bfilter &= AllergiesFilter;
        }
        if (!string.IsNullOrWhiteSpace(BloodType))
        {
            var BloodTypeFilter = builder.Eq(x => x.BloodType, BloodType);
            bfilter &= BloodTypeFilter;
        }
        if (!string.IsNullOrWhiteSpace(SocialHistory))
        {
            var SocialHistoryFilter = builder.Eq(x => x.SocialHistory, SocialHistory);
            bfilter &= SocialHistoryFilter;
        }
        exp = bfilter;
        return exp;
    }
    public bool Exists(Guid patientID)
    {
        var result = Dp.Pipeline(ExecuteResult: (stateContext) =>
        {
            var state = new ConnectionMongo(stateContext, Dp);
            var patient = state.Patient.Find(x => x.ID == patientID).Project<Model.Patient>("{ ID: 1 }").FirstOrDefault();
            return (patientID == patient?.ID);
        });
        if (result is null)
            return false;
        return result;
    }
    public long Total(string filter)
    {
        return Dp.Pipeline(ExecuteResult: (stateContext) =>
        {
            var state = new ConnectionMongo(stateContext, Dp);
            var total = state.Patient.Find(GetFilter(filter)).CountDocuments();
            return total;
        });
    }

#endregion Read

#region mappers
    public static DevPrime.State.Repositories.Patient.Model.Patient ToState(Domain.Aggregates.Patient.Patient patient)
    {
        if (patient is null)
            return new DevPrime.State.Repositories.Patient.Model.Patient();
        DevPrime.State.Repositories.Patient.Model.Patient _patient = new DevPrime.State.Repositories.Patient.Model.Patient();
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
    public static Domain.Aggregates.Patient.Patient ToDomain(DevPrime.State.Repositories.Patient.Model.Patient patient)
    {
        if (patient is null)
            return new Domain.Aggregates.Patient.Patient()
            {
                IsNew = true
            };
        Domain.Aggregates.Patient.Patient _patient = new Domain.Aggregates.Patient.Patient(patient.ID, patient.WalletAddress, patient.Name, patient.Email, patient.Phone, patient.Address, patient.City, patient.State, patient.Zip, patient.Country, patient.DateOfBirth, patient.EmergencyContact, patient.MedicalConditions, patient.MedicalHistoric, patient.Medications, patient.Allergies, patient.BloodType, patient.SocialHistory);
        return _patient;
    }
    public static List<Domain.Aggregates.Patient.Patient> ToDomain(IList<DevPrime.State.Repositories.Patient.Model.Patient> patientList)
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

#endregion mappers
}