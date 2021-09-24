using MediClinic.Models.DTOs.PatientEmergencyContactDto;
using MediClinic.Models.DTOs.PatientPhoneNumberDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientInfoDto
{
    public class PatientInfoBasicDto
    {
        public long PatientInfoId { get; set; }
        public int? PrefixId { get; set; }
        [Display(Name = "First Name")]
       // [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Use Characters only")]

        //[RegularExpression(@"[a-zA-Z]", ErrorMessage = "Enter only characters.")]
        public string FirstName { get; set; }
      //  [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Use Characters only")]

        public string MiddleName { get; set; }
        
       // [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Use Characters only")]
        public string LastName { get; set; }
        public Nullable<double> Rating { get; set; }
        public int? GenderId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public string SSN { get; set; }
        //[Required(ErrorMessage = "Marital Status is required")]
        public int? MaitalStatusId { get; set; }
        public int? RaceEthnicityId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string SecondaryCity { get; set; }
        public string SecondaryState { get; set; }
        public string SecondaryZip { get; set; }
        public string SecondaryCountry { get; set; }
        public string City { get; set; }
       
        public string State { get; set; }
        //[Required]
        [Display(Name = "ZIP Code")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use Digits only")]
        public string ZIP { get; set; }

        public string SecondaryAddress1 { get; set; }
        public string SecondaryAddress2 { get; set; }
        public string SecondaryAddress3 { get; set; }
        public string ReferralName { get; set; }
        public long UserId { get; set; }
        public int? PatientTreatmentId { get; set; }
        public int? PatientLegalId { get; set; }
        public int? Suffix { get; set; }
        
        public string Country { get; set; }
        public int? EmploymentStatusId { get; set; }
        public int? EmploymentTitleId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]
        public string WPassword { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string WConfirmPassword { get; set; }
        [Required(ErrorMessage ="Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Email is required.")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required.")]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string PatientColor { get; set; }
        public string Language { get; set; }
        public string[] PatientLanguages { get; set; }
        public string PatientLanguage { get; set; }

        public string MobNo { get; set; }

        public string HomeNo { get; set; }

        public string FirmAttorneyName { get; set; }
        public string LeadingParalegal { get; set; }

        public int? Age { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public virtual Lookups Gender { get; set; }

        public  EmploymentStatus EmploymentStatus { get; set; }
        public  EmploymentTitle EmploymentTitle { get; set; }
        public  PatientLegalStatus PatientLegal { get; set; }
        public  PatientTreatmentStatus PatientTreatment { get; set; }
        public  Users User { get; set; }
        public PatientPhoneNumber PatientPhoneNumber { get; set; }
        public PatientsClaimInfo PatientsClaimInfo { get; set; }

        public PatientCaseType PatientCaseType { get; set; }
        public PatientEmergencyContact PatientEmergencyContact { get; set; }
        public PatientIdAndSignature PatientIdAndSignature { get; set; }
        public VehicalsOrEntityInvolved VehicalsOrEntityInvolved { get; set; }
        public SecondaryInsurenceProvider SecondaryInsurenceProvider { get; set; }
        public TertiaryInsurenceProvider TertiaryInsurenceProvider { get; set; }
        public PatientArbitrationAttorney PatientArbitrationAttorney { get; set; }

        public PatientPersonalInjury PatientPersonal { get; set; }
        public PatientPhoneNumberBasicDto patientPhoneNumberObj { get; set; }
        public PatientEmergencyContactBasicDto patientEmergencyContactObj { get; set; }
    }
}
