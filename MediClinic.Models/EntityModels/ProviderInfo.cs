using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ProviderInfo
    {
        public ProviderInfo()
        {
            DMESupplyEquipment = new HashSet<DMESupplyEquipment>();
            DmePatientsPrescription = new HashSet<DmePatientsPrescription>();
            Immunization = new HashSet<Immunization>();
            PatientAppointments = new HashSet<PatientAppointments>();
            PatientClinicalNotes = new HashSet<PatientClinicalNotes>();
            PatientListDisplaySetting = new HashSet<PatientListDisplaySetting>();
            PatientMedicalHistory = new HashSet<PatientMedicalHistory>();
            PatientMedicalProblem = new HashSet<PatientMedicalProblem>();
            PatientVitals = new HashSet<PatientVitals>();
            PrescriptionTemplates = new HashSet<PrescriptionTemplates>();
            Procedures = new HashSet<Procedures>();
            ProviderListSettingss = new HashSet<ProviderListSettingss>();
            ProviderSessions = new HashSet<ProviderSessions>();
            ProviderSlots = new HashSet<ProviderSlots>();
            Tests = new HashSet<Tests>();
        }

        public long ProviderInfoId { get; set; }
        public string EntityName { get; set; }
        public string ProviderProfilePic { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? Speciality { get; set; }
        public int? Title { get; set; }
        public int? Suffix { get; set; }
        public string LicenseNo { get; set; }
        public string NpiNumber { get; set; }
        public string TaxId { get; set; }
        public string AssignRoomNo { get; set; }
        public string Rent { get; set; }
        public int? RentType { get; set; }
        public string ScannedDocuments { get; set; }
        public string ElectronicSignPassword { get; set; }
        public string WriteSignature { get; set; }
        public string SignImage { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int? RelatedFacilityId { get; set; }
        public string IsBilledAmountVisible { get; set; }
        public string IsAllowToBill { get; set; }
        public string IsAllowToAddVisits { get; set; }
        public string IsAllowToSchedule { get; set; }
        public string ProviderPermission { get; set; }
        public int? UidType { get; set; }
        public string CodeByMasterProvider { get; set; }
        public int? Status { get; set; }
        public string AllowSms { get; set; }
        public long UserId { get; set; }
        public int? Term { get; set; }
        public bool? IsActive { get; set; }
        public bool isVisitor { get; set; }
        public string ScannedDocumentType { get; set; }
        public string Charges { get; set; }
        public bool? IsSchedule { get; set; }

        public virtual RelatedFacilities RelatedFacility { get; set; }
        public virtual Lookups RentTypeNavigation { get; set; }
        public virtual ProviderSpecialities SpecialityNavigation { get; set; }
        public virtual Lookups StatusNavigation { get; set; }
        public virtual Lookups SuffixNavigation { get; set; }
        public virtual ProviderTerms TermNavigation { get; set; }
        public virtual Lookups TitleNavigation { get; set; }
        public virtual ProviderUIDTypes UidTypeNavigation { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<DMESupplyEquipment> DMESupplyEquipment { get; set; }
        public virtual ICollection<DmePatientsPrescription> DmePatientsPrescription { get; set; }
        public virtual ICollection<Immunization> Immunization { get; set; }
        public virtual ICollection<PatientAppointments> PatientAppointments { get; set; }
        public virtual ICollection<PatientClinicalNotes> PatientClinicalNotes { get; set; }
        public virtual ICollection<PatientListDisplaySetting> PatientListDisplaySetting { get; set; }
        public virtual ICollection<PatientMedicalHistory> PatientMedicalHistory { get; set; }
        public virtual ICollection<PatientMedicalProblem> PatientMedicalProblem { get; set; }
        public virtual ICollection<PatientVitals> PatientVitals { get; set; }
        public virtual ICollection<PrescriptionTemplates> PrescriptionTemplates { get; set; }
        public virtual ICollection<Procedures> Procedures { get; set; }
        public virtual ICollection<ProviderListSettingss> ProviderListSettingss { get; set; }
        public virtual ICollection<ProviderSessions> ProviderSessions { get; set; }
        public virtual ICollection<ProviderSlots> ProviderSlots { get; set; }
        public virtual ICollection<Tests> Tests { get; set; }
    }
}
