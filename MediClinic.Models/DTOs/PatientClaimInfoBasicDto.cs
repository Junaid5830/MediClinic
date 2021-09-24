using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientClaimInfo
{
    public class PatientClaimInfoBasicDto
    {
        public long PatientClaimID { get; set; }
        [Required(ErrorMessage = "Primary Insurance Provider is required.")]
        public string PrimaryInsuranceProvider { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string Addressline3 { get; set; }

        public string EmployerName { get; set; }
        public string EmployerAddress { get; set; }
        public string EmployerPhone { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage ="ZIP Code is required.")]
        [Display(Name = "ZIP Code")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use Digits only")]
        public string Zip { get; set; }
        

        public string Country { get; set; }
       
        public string City { get; set; }
        public string WebPage { get; set; }
        public string PrimaryPhone { get; set; }
        public string Fax { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Adjuster Name is required.")]
        [Display(Name = "Adjuster Name")]
        //[RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Use Characters only.")]
        public string AdjusterName { get; set; }
        public string AdjusterID { get; set; }
        [Required(ErrorMessage = "Adjuster Phone is required.")]
        [Display(Name = "Adjuster Phone")]
        public string AdjusterPhone { get; set; }
        public string AdjusterExtension { get; set; }
        [Required(ErrorMessage = "Adjuster Fax is required.")]
        public string AdjusterFax { get; set; }
        [Required(ErrorMessage = "Adjuster Email is required.")]
        public string AdjusterEmail { get; set; }
        [Required(ErrorMessage = "Nf2 Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Nf2 Date")]
        public DateTime? NF2FillingDate { get; set; }
        [Required(ErrorMessage ="Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime? DateOfIncident { get; set; }
        [DataType(DataType.Time)]
        public DateTime? TimeOfIncident { get; set; }
        public string IncidentInCourse { get; set; }
        public int? PatientIncidentRoleId { get; set; }
        public int? IncidentReportId { get; set; }
        [Required(ErrorMessage = "Nf2 status is required.")]
        public int? Nf2Id { get; set; }
        public string PlaceOfIncident { get; set; }
        public int? ClaimStatusId { get; set; }
        public string WasCasuseOfEmployment { get; set; }
        [Required(ErrorMessage = "Case Type is required.")]
        public string CaseType { get; set; }
        public long UserId { get; set; }
        [StringLength(18,ErrorMessage = "Policy number should be 5-18 digit long.")]
        public string PolicyNumber { get; set; }
        public string PolicyHolderName { get; set; }
        public string PolicyLimits { get; set; }
        public string ClaimNumber { get; set; }
        public string WCBNumber { get; set; }
        public string WCBCaseNumber { get; set; }
        public string GroupNumber { get; set; }
        [RegularExpression(@"^\$(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$", ErrorMessage = "Invalid! Starts with dollar sign.")]
        public string CoPay { get; set; }
        public string AcceptAssignment { get; set; } 
        [DataType(DataType.Date)]
        public DateTime? PolicyEffectiveDate { get; set; }
        public string RelationShipToPolicyHolder { get; set; }
        public string PolicyEffectAtIncidentTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime? PolicyEffectEndDate { get; set; }
        public int? VIsitId { get; set; }
        public int? AttorneyId { get; set; }
        public long? PatientInfo { get; set; }
        public bool? IsActive { get; set; }

        public string AttorneyName { get; set; }
        public string claimStatusName { get; set; }
        public string nf2Name { get; set; }
        public virtual LegalInfoAttorneyName Attorney { get; set; }
        public virtual MediClinic.Models.EntityModels.ClaimStatus ClaimStatus { get; set; }
        public virtual IncidentReportStatus IncidentReport { get; set; }
        public virtual Nf2Status Nf2 { get; set; }
        public virtual PatientRoleIncident PatientIncidentRole { get; set; }
    }
}
