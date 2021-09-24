using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientsClaimInfo
    {
        public long PatientClaimID { get; set; }
        public string PrimaryInsuranceProvider { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string Addressline3 { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string WebPage { get; set; }
        public string PrimaryPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string AdjusterName { get; set; }
        public string AdjusterID { get; set; }
        public string AdjusterPhone { get; set; }
        public string AdjusterExtension { get; set; }
        public string AdjusterFax { get; set; }
        public string AdjusterEmail { get; set; }
        public DateTime? NF2FillingDate { get; set; }
        public DateTime? DateOfIncident { get; set; }
        public DateTime? TimeOfIncident { get; set; }
        public string IncidentInCourse { get; set; }
        public int? PatientIncidentRoleId { get; set; }
        public int? IncidentReportId { get; set; }
        public int? Nf2Id { get; set; }
        public string PlaceOfIncident { get; set; }
        public int? ClaimStatusId { get; set; }
        public long UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedById { get; set; }
        public bool? IsActive { get; set; }
        public string WasCasuseOfEmployment { get; set; }
        public string CaseType { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyHolderName { get; set; }
        public string PolicyLimits { get; set; }
        public string ClaimNumber { get; set; }
        public string WCBNumber { get; set; }
        public string WCBCaseNumber { get; set; }
        public string GroupNumber { get; set; }
        public string CoPay { get; set; }
        public string AcceptAssignment { get; set; }
        public DateTime? PolicyEffectiveDate { get; set; }
        public string RelationShipToPolicyHolder { get; set; }
        public string PolicyEffectAtIncidentTime { get; set; }
        public DateTime? PolicyEffectEndDate { get; set; }
        public int? AttorneyId { get; set; }
        public long? PatientInfo { get; set; }
        public int? VIsitId { get; set; }
        public string EmployerPhone { get; set; }
        public string EmployerName { get; set; }
        public string EmployerAddress { get; set; }

        public virtual LegalInfoAttorneyName Attorney { get; set; }
        public virtual ClaimStatus ClaimStatus { get; set; }
        public virtual IncidentReportStatus IncidentReport { get; set; }
        public virtual Nf2Status Nf2 { get; set; }
        public virtual PatientRoleIncident PatientIncidentRole { get; set; }
        public virtual Users User { get; set; }
        public virtual Visits VIsit { get; set; }
    }
}
