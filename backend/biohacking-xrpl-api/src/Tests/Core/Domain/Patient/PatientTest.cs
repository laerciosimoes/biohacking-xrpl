namespace Core.Tests;
public class PatientTest
{
    public static Guid FixedID = new Guid("98c14744-f441-4e24-83af-804a6338d2f1");

#region fixtures
    public static Domain.Aggregates.Patient.Patient Create_Patient_Required_Properties_OK(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_WalletAddress_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_Name_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_Email_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_Phone_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_Address_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_City_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_State_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_Zip_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_Country_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_DateOfBirth_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_EmergencyContact_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_MedicalConditions_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_MedicalHistoric_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_Medications_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_Allergies_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_BloodType_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "SocialHistory", Faker.Lorem.Sentence(1));
        return patient;
    }
    public static Domain.Aggregates.Patient.Patient Create_Patient_With_SocialHistory_Required_Property_Missing(DpTest dpTest)
    {
        var patient = new Domain.Aggregates.Patient.Patient();
        dpTest.MockDpDomain(patient);
        dpTest.Set<Guid>(patient, "ID", FixedID);
        dpTest.Set<string>(patient, "WalletAddress", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Name", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Email", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Phone", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Address", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "City", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "State", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Zip", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Country", Faker.Lorem.Sentence(1));
        dpTest.Set<Nullable<System.DateTime>>(patient, "DateOfBirth", DateTime.Now);
        dpTest.Set<string>(patient, "EmergencyContact", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalConditions", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "MedicalHistoric", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Medications", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "Allergies", Faker.Lorem.Sentence(1));
        dpTest.Set<string>(patient, "BloodType", Faker.Lorem.Sentence(1));
        return patient;
    }

#endregion fixtures

#region add
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Success")]
    public void Add_Required_properties_filled_Success()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_Required_Properties_OK(dpTest);
        dpTest.MockDpProcessEvent<bool>(patient, "CreatePatient", true);
        dpTest.MockDpProcessEvent(patient, "PatientCreated");
        //Act
        patient.Add();
        //Assert
        var domainevents = dpTest.GetDomainEvents(patient);
        Assert.True(domainevents[0] is CreatePatient);
        Assert.True(domainevents[1] is PatientCreated);
        Assert.NotEqual(patient.ID, Guid.Empty);
        Assert.True(patient.IsNew);
        Assert.True(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_WalletAddress_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_WalletAddress_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("WalletAddress is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_Name_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Name_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Name is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_Email_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Email_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Email is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_Phone_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Phone_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Phone is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_Address_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Address_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Address is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_City_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_City_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("City is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_State_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_State_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("State is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_Zip_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Zip_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Zip is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_Country_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Country_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Country is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_DateOfBirth_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_DateOfBirth_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("DateOfBirth is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_EmergencyContact_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_EmergencyContact_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("EmergencyContact is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_MedicalConditions_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_MedicalConditions_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("MedicalConditions is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_MedicalHistoric_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_MedicalHistoric_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("MedicalHistoric is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_Medications_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Medications_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Medications is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_Allergies_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Allergies_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Allergies is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_BloodType_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_BloodType_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("BloodType is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Add")]
    [Trait("Aggregate", "Fail")]
    public void Add_SocialHistory_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_SocialHistory_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Add);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("SocialHistory is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }

#endregion add

#region update
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Success")]
    public void Update_Required_properties_filled_Success()
    {
        //Arrange        
        var dpTest = new DpTest();
        var patient = Create_Patient_Required_Properties_OK(dpTest);
        dpTest.MockDpProcessEvent<bool>(patient, "UpdatePatient", true);
        dpTest.MockDpProcessEvent(patient, "PatientUpdated");
        //Act
        patient.Update();
        //Assert
        var domainevents = dpTest.GetDomainEvents(patient);
        Assert.True(domainevents[0] is UpdatePatient);
        Assert.True(domainevents[1] is PatientUpdated);
        Assert.NotEqual(patient.ID, Guid.Empty);
        Assert.True(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_WalletAddress_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_WalletAddress_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("WalletAddress is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_Name_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Name_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Name is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_Email_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Email_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Email is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_Phone_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Phone_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Phone is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_Address_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Address_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Address is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_City_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_City_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("City is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_State_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_State_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("State is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_Zip_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Zip_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Zip is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_Country_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Country_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Country is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_DateOfBirth_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_DateOfBirth_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("DateOfBirth is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_EmergencyContact_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_EmergencyContact_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("EmergencyContact is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_MedicalConditions_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_MedicalConditions_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("MedicalConditions is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_MedicalHistoric_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_MedicalHistoric_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("MedicalHistoric is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_Medications_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Medications_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Medications is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_Allergies_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_Allergies_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("Allergies is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_BloodType_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_BloodType_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("BloodType is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }
    [Fact]
    [Trait("Aggregate", "Update")]
    [Trait("Aggregate", "Fail")]
    public void Update_SocialHistory_Missing_Fail()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_With_SocialHistory_Required_Property_Missing(dpTest);
        //Act and Assert
        var ex = Assert.Throws<PublicException>(patient.Update);
        Assert.Equal("Public exception", ex.ErrorMessage);
        Assert.Collection(ex.Exceptions, i => Assert.Equal("SocialHistory is required", i));
        Assert.False(patient.Dp.Notifications.IsValid);
    }

#endregion update

#region delete
    [Fact]
    [Trait("Aggregate", "Delete")]
    [Trait("Aggregate", "Success")]
    public void Delete_IDFilled_Success()
    {
        //Arrange
        var dpTest = new DpTest();
        var patient = Create_Patient_Required_Properties_OK(dpTest);
        dpTest.MockDpProcessEvent<bool>(patient, "DeletePatient", true);
        dpTest.MockDpProcessEvent(patient, "PatientDeleted");
        //Act
        patient.Delete();
        //Assert
        var domainevents = dpTest.GetDomainEvents(patient);
        Assert.True(domainevents[0] is DeletePatient);
        Assert.True(domainevents[1] is PatientDeleted);
    }

#endregion delete
}