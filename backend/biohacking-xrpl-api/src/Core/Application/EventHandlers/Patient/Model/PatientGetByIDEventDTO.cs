namespace Application.Services.Patient.Model;
public class PatientGetByIDEventDTO
{
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
    public DateTime DateOfBirth { get; set; }
    public string EmergencyContact { get; set; }
    public string MedicalConditions { get; set; }
    public string MedicalHistoric { get; set; }
    public string Medications { get; set; }
    public string Allergies { get; set; }
    public string BloodType { get; set; }
    public string SocialHistory { get; set; }
}