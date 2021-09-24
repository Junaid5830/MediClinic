using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientProfiles
    {
        public PatientProfiles()
        {
            EmploymentStatus = new HashSet<EmploymentStatus>();
            PatientArbitrationAttorney = new HashSet<PatientArbitrationAttorney>();
            PatientEmergency = new HashSet<PatientEmergency>();
            PatientPersonalInjury = new HashSet<PatientPersonalInjury>();
            PatientsClaimInfo = new HashSet<PatientsClaimInfo>();
            SecondaryInsurenceProvider = new HashSet<SecondaryInsurenceProvider>();
            TertiaryInsurenceProvider = new HashSet<TertiaryInsurenceProvider>();
            VehicalsOrEntityInvolved = new HashSet<VehicalsOrEntityInvolved>();
        }

        public long PatientID { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SSN { get; set; }
        public string MaitalStatus { get; set; }
        public string RaceEthnicity { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public string SecondaryAddress { get; set; }
        public string ReferralName { get; set; }
        public string TreatmentStatus { get; set; }
        public string LegalStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedById { get; set; }
        public bool IsActive { get; set; }
        public long? UserId { get; set; }
        public string PassportNumber { get; set; }
        public string IDType { get; set; }
        public string IDNumber { get; set; }
        public string UploadPatientID { get; set; }
        public string Image { get; set; }
        public string WriteSignature { get; set; }
        public string UploadSignature { get; set; }
        public bool? SMSNotification { get; set; }
        public bool? EmailNotification { get; set; }
        public bool? FaceRecognition { get; set; }
        public bool? SMSForCommunication { get; set; }
        public bool? PhoneForCommunication { get; set; }
        public string EmailForCommunication { get; set; }
        public string HomeNumber { get; set; }
        public string WorkPlaceNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmergencyNumber { get; set; }
        public string Fax { get; set; }
        public string ElectronicPassword { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<EmploymentStatus> EmploymentStatus { get; set; }
        public virtual ICollection<PatientArbitrationAttorney> PatientArbitrationAttorney { get; set; }
        public virtual ICollection<PatientEmergency> PatientEmergency { get; set; }
        public virtual ICollection<PatientPersonalInjury> PatientPersonalInjury { get; set; }
        public virtual ICollection<PatientsClaimInfo> PatientsClaimInfo { get; set; }
        public virtual ICollection<SecondaryInsurenceProvider> SecondaryInsurenceProvider { get; set; }
        public virtual ICollection<TertiaryInsurenceProvider> TertiaryInsurenceProvider { get; set; }
        public virtual ICollection<VehicalsOrEntityInvolved> VehicalsOrEntityInvolved { get; set; }
    }
}
