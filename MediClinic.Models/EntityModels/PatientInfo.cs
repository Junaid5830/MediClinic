using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientInfo
    {
        public PatientInfo()
        {
            DMESupplyEquipment = new HashSet<DMESupplyEquipment>();
            DmePatientsPrescription = new HashSet<DmePatientsPrescription>();
            DriverJobRequest = new HashSet<DriverJobRequest>();
            Imaging = new HashSet<Imaging>();
            Immunization = new HashSet<Immunization>();
            Invoices = new HashSet<Invoices>();
            PatientAppointments = new HashSet<PatientAppointments>();
            PatientClinicalNotes = new HashSet<PatientClinicalNotes>();
            PatientDisplaySetting = new HashSet<PatientDisplaySetting>();
            PatientMedicalHistory = new HashSet<PatientMedicalHistory>();
            PatientMedicalProblem = new HashSet<PatientMedicalProblem>();
            PatientPrescriptions = new HashSet<PatientPrescriptions>();
            PatientPrintSetting = new HashSet<PatientPrintSetting>();
            Procedures = new HashSet<Procedures>();
            ProviderSlots = new HashSet<ProviderSlots>();
            ReportExamInformation = new HashSet<ReportExamInformation>();
            ReportPatientInformation = new HashSet<ReportPatientInformation>();
            SurgeryCenter = new HashSet<SurgeryCenter>();
        }

        public long PatientInfoId { get; set; }
        public int? PrefixId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? GenderId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string SSN { get; set; }
        public int? MaitalStatusId { get; set; }
        public int? RaceEthnicityId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public string SecondaryAddress1 { get; set; }
        public string ReferralName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedById { get; set; }
        public bool? IsActive { get; set; }
        public long? UserId { get; set; }
        public int? Suffix { get; set; }
        public int? PatientTreatmentId { get; set; }
        public int? PatientLegalId { get; set; }
        public string Country { get; set; }
        public string SecondaryAddress2 { get; set; }
        public string SecondaryAddress3 { get; set; }
        public int? EmploymentStatusId { get; set; }
        public int? EmploymentTitleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string PatientColor { get; set; }
        public int? Language { get; set; }
        public string PatientLanguage { get; set; }
        public string SecondaryCity { get; set; }
        public string SecondaryState { get; set; }
        public string SecondaryZip { get; set; }
        public string SecondaryCountry { get; set; }
        public double? Rating { get; set; }

        public virtual EmploymentStatus EmploymentStatus { get; set; }
        public virtual EmploymentTitle EmploymentTitle { get; set; }
        public virtual Lookups Gender { get; set; }
        public virtual PatientLanguage LanguageNavigation { get; set; }
        public virtual PatientLegalStatus PatientLegal { get; set; }
        public virtual PatientTreatmentStatus PatientTreatment { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<DMESupplyEquipment> DMESupplyEquipment { get; set; }
        public virtual ICollection<DmePatientsPrescription> DmePatientsPrescription { get; set; }
        public virtual ICollection<DriverJobRequest> DriverJobRequest { get; set; }
        public virtual ICollection<Imaging> Imaging { get; set; }
        public virtual ICollection<Immunization> Immunization { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<PatientAppointments> PatientAppointments { get; set; }
        public virtual ICollection<PatientClinicalNotes> PatientClinicalNotes { get; set; }
        public virtual ICollection<PatientDisplaySetting> PatientDisplaySetting { get; set; }
        public virtual ICollection<PatientMedicalHistory> PatientMedicalHistory { get; set; }
        public virtual ICollection<PatientMedicalProblem> PatientMedicalProblem { get; set; }
        public virtual ICollection<PatientPrescriptions> PatientPrescriptions { get; set; }
        public virtual ICollection<PatientPrintSetting> PatientPrintSetting { get; set; }
        public virtual ICollection<Procedures> Procedures { get; set; }
        public virtual ICollection<ProviderSlots> ProviderSlots { get; set; }
        public virtual ICollection<ReportExamInformation> ReportExamInformation { get; set; }
        public virtual ICollection<ReportPatientInformation> ReportPatientInformation { get; set; }
        public virtual ICollection<SurgeryCenter> SurgeryCenter { get; set; }
    }
}
