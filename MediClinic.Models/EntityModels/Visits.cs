using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Visits
    {
        public Visits()
        {
            Allergies = new HashSet<Allergies>();
            Claims = new HashSet<Claims>();
            ClinicalReminder = new HashSet<ClinicalReminder>();
            CurrentLocationFacility = new HashSet<CurrentLocationFacility>();
            DMESupplyEquipment = new HashSet<DMESupplyEquipment>();
            DocumentReports = new HashSet<DocumentReports>();
            EUO = new HashSet<EUO>();
            GrowthChart = new HashSet<GrowthChart>();
            IME = new HashSet<IME>();
            Imaging = new HashSet<Imaging>();
            Immunization = new HashSet<Immunization>();
            Invoices = new HashSet<Invoices>();
            Lab = new HashSet<Lab>();
            MHFamilyHistory = new HashSet<MHFamilyHistory>();
            Messages = new HashSet<Messages>();
            PatientClinicalNotes = new HashSet<PatientClinicalNotes>();
            PatientsClaimInfo = new HashSet<PatientsClaimInfo>();
            ReportBillingInformation = new HashSet<ReportBillingInformation>();
            ReportDoctorInformation = new HashSet<ReportDoctorInformation>();
            ReportEmployeeInfo = new HashSet<ReportEmployeeInfo>();
            ReportHistory = new HashSet<ReportHistory>();
            ReportPatientInformation = new HashSet<ReportPatientInformation>();
            Tests = new HashSet<Tests>();
        }

        public int VisitId { get; set; }
        public int AppoinmentId { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual PatientAppointments Appoinment { get; set; }
        public virtual ICollection<Allergies> Allergies { get; set; }
        public virtual ICollection<Claims> Claims { get; set; }
        public virtual ICollection<ClinicalReminder> ClinicalReminder { get; set; }
        public virtual ICollection<CurrentLocationFacility> CurrentLocationFacility { get; set; }
        public virtual ICollection<DMESupplyEquipment> DMESupplyEquipment { get; set; }
        public virtual ICollection<DocumentReports> DocumentReports { get; set; }
        public virtual ICollection<EUO> EUO { get; set; }
        public virtual ICollection<GrowthChart> GrowthChart { get; set; }
        public virtual ICollection<IME> IME { get; set; }
        public virtual ICollection<Imaging> Imaging { get; set; }
        public virtual ICollection<Immunization> Immunization { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<Lab> Lab { get; set; }
        public virtual ICollection<MHFamilyHistory> MHFamilyHistory { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<PatientClinicalNotes> PatientClinicalNotes { get; set; }
        public virtual ICollection<PatientsClaimInfo> PatientsClaimInfo { get; set; }
        public virtual ICollection<ReportBillingInformation> ReportBillingInformation { get; set; }
        public virtual ICollection<ReportDoctorInformation> ReportDoctorInformation { get; set; }
        public virtual ICollection<ReportEmployeeInfo> ReportEmployeeInfo { get; set; }
        public virtual ICollection<ReportHistory> ReportHistory { get; set; }
        public virtual ICollection<ReportPatientInformation> ReportPatientInformation { get; set; }
        public virtual ICollection<Tests> Tests { get; set; }
    }
}
