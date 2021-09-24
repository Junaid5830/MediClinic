using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    
    public class AssistantSettingDto
    {
        public string ReminderBy { get; set; }

        public long AssistantInfoID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Use Characters only")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Use Characters only")]

        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Use Characters only")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Speciality")]
        public int? SpecialityID { get; set; }
        [Required]
        [Display(Name = "Title")]
        public int? TittleID { get; set; }

        [Required]
        [Display(Name = "License Number")]
        [RegularExpression(@"^[0-9\-]*$", ErrorMessage = "Use digits only")]
        public string LicenseNo { get; set; }
        [Required]
        [Display(Name = "Npi Number")]
        [RegularExpression(@"^[0-9\-]*$", ErrorMessage = "Use digits only")]
        public string NpiNumber { get; set; }
        [Required]
        [RegularExpression(@"^[0-9\-]*$", ErrorMessage = "Use digits only")]
        public string TaxID { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use digits only")]
        [Display(Name = "Assign Room Number")]
        public string AssignRoomNo { get; set; }
        [RegularExpression(@"^\$(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$", ErrorMessage = "Invalid! Starts with dollar sign.")]

        public string RentFee { get; set; }
        public int? RentType { get; set; }
        public string SignImage { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Required]
        [Display(Name = "Zip")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use Digits only")]
        public string Zip { get; set; }
        public long UserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        [Required]
        [Display(Name = "Facility Association")]
        public string FacilityAssociation { get; set; }
        public string FacilityAddress1 { get; set; }
        public string FacilityAddress2 { get; set; }
        public string FacilityAddress3 { get; set; }
        [Required]
        [Display(Name = "Zip")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use Digits only")]
        public string FacilityZip { get; set; }
        public string FacilityCity { get; set; }
        public string FacilityState { get; set; }
        public string FacilityCountry { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Enter a valid email address.")]
        public string FacilityEmail { get; set; }
        public string FacilityPhone { get; set; }
        public bool AuthorizedToPrescribe { get; set; }
        public bool AuthorizedToExamin { get; set; }
        public bool AuthorizedToBill { get; set; }
        public bool AuthorizedFaceId { get; set; }
        public bool AuthorizedBioMetric { get; set; }
        public bool isFromSetting { get; set; }
        public string WriteSignature { get; set; }
        public string Remindimage { get; set; }
        public string Signatureimage { get; set; }
        public string HiddenWriteSignImage { get; set; }
        public string HiddenSignImg { get; set; }
        public string Speciality { get; set; }
        public string Tittle { get; set; }
        public string Suf { get; set; }
        public string FullName { get; set; }

        public DateTime? DOB { get; set; }
        public string BillPeriod { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]
        public string Password { get; set; }
    }
}
