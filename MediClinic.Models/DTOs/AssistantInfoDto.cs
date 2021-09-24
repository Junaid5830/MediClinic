using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class AssistantInfoDto
    {
        public long AssistantInfoID { get; set; }

        [Required]
        [Display(Name = "Entity Name")]
        //[RegularExpression(@"^[^-\s][a-zA-Z_\s-]+$", ErrorMessage = "Allow only alphabets and spaces except space at beginning.")]
        public string EntityName { get; set; }
        public string ReminderBy { get; set; }

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
        [Display(Name = "Suffix")]
        public int? Suffix { get; set; }

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

        [Required]
        [Display(Name = "Scanned Documents")]
        public int? ScannedDocument { get; set; }

        [Required]
        [Display(Name = "Electronic Sign Password")]
        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]
        public string ElectronicSignPassword { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("ElectronicSignPassword")]
        public string ElectronicConfirmPassword { get; set; }
        public string WriteSignature { get; set; }
        public string SignImage { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNo { get; set; }

        [Required]
        [Display(Name = "Fax Number")]
        public string FaxNo { get; set; }

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

        [Required]
        [Display(Name = "Status")]
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string Remindimage { get; set; }
        public string Signatureimage { get; set; }
        public string HiddenWriteSignImage { get; set; }
        public string HiddenSignImg { get; set; }
        public string Speciality { get; set; }
        public string Tittle { get; set; }
        public string Suf { get; set; }
        public string FullName { get; set; }
    }
}
