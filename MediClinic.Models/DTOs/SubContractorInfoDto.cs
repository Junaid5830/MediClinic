using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
	public class SubContractorInfoDto
	{
    public long SubContractorId { get; set; }

    [Required]
    [Display(Name = "Entity Name")]
    public string EntityName { get; set; }
    public string SubContractorProfilePic { get; set; }

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
    public int? Speciality { get; set; }

    [Required]
    [Display(Name = "Title")]
    public int? Title { get; set; }

    [Required]
    [Display(Name = "Suffix")]
    public int Suffix { get; set; }

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
    public string TaxId { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use digits only")]
    [Display(Name = "Assign Room Number")]
    public string AssignRoomNo { get; set; }

    [RegularExpression(@"^\$(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$", ErrorMessage = "Invalid! Starts with dollar sign.")]
    public string Rent { get; set; }
    public int? RentType { get; set; }

    [Required]
    [Display(Name = "Scanned Documents")]
    public int ScannedDocuments { get; set; }

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
    public long UserId { get; set; }

    [Required]
    [Display(Name = "Password")]
    [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]
    public string Password { get; set; }

    [Required]
    [Display(Name = "Status")]
    public int? Status { get; set; }

    public string SpecialityList { get; set; }
    public string TitleList { get; set; }
    public string SuffixList { get; set; }
    public string RentTypeList { get; set; }
    public string StatusList { get; set; }
  }
}
