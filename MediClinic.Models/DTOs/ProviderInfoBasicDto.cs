using MediClinic.Models.EntityModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.ProviderInfoDto
{
    public class ProviderInfoBasicDto
    {
        public long ProviderInfoId { get; set; }

        [Required(ErrorMessage = "Entity name is required.")]
        [Display(Name = "Entity Name")]
        //[RegularExpression(@"^[^-\s][a-zA-Z_\s-]+$", ErrorMessage = "Allow only alphabets and spaces except space at beginning.")]
        public string EntityName { get; set; }
        public string ProviderProfilePic { get; set; }
        public string FullName { get; set; }
        public string ScannedDocumentType { get; set; }


        [Required(ErrorMessage ="First name is required.")]
        [Display(Name = "First Name")]
        //[RegularExpression(@"^[^-\s][a-zA-Z_\s-]+$", ErrorMessage = "Allow only alphabets and spaces except space at beginning.")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        //[RegularExpression(@"^[^-\s][a-zA-Z_\s-]+$", ErrorMessage = "Allow only alphabets and spaces except space at beginning.")]
        public string LastName { get; set; }

        [Display(Name = "Speciality")]
        public int? Speciality { get; set; }

        [Display(Name = "Title")]
        public int? Title { get; set; }

        public int? Suffix { get; set; }

        public string LicenseNo { get; set; }

        [RegularExpression(@"^[0-9\-]*$", ErrorMessage = "Use 10 digits only")]
        public string NpiNumber { get; set; }

        public string TaxId { get; set; }

        public string AssignRoomNo { get; set; }

        public string Rent { get; set; }
        public int? RentType { get; set; }
            
        public string ScannedDocuments { get; set; }

        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]
        public string ElectronicSignPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("ElectronicSignPassword")]
        public string ElectronicConfirmPassword { get; set; }
        public string WriteSignature { get; set; }
        public string SignImage { get; set; }
        
        //[RegularExpression(@"^[0-9\-\(\)\s]*$", ErrorMessage = "Use digits only")]
        //[RegularExpression(@"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Invalid! Phone number.")]
        public string PhoneNo { get; set; }

        //[RegularExpression(@"^[0-9\-\(\)\s]*$", ErrorMessage = "Use digits only")]
        //[RegularExpression(@"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Invalid! Phone number.")]
        public string MobileNo { get; set; }

        //[RegularExpression(@"^[0-9\-]*$", ErrorMessage = "Use digits only")]
        public string FaxNo { get; set; }

        [Required(ErrorMessage ="Email is required.")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

       
        public string City { get; set; }

       
        public string State { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use Digits only")]
        public string Zip { get; set; }

     
        public int? RelatedFacilityId { get; set; }
        public string IsBilledAmountVisible { get; set; }
        public string IsAllowToBill { get; set; }
        public string IsAllowToAddVisits { get; set; }
        public string IsAllowToSchedule { get; set; }
        public string ProviderPermission { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Charges { get; set; }

        public int? UidType { get; set; }
        public string CodeByMasterProvider { get; set; }

        public bool isVisitor { get; set; }

        public int? Status { get; set; }
        public string AllowSms { get; set; }
        public long UserId { get; set; }
        [Required]
        [Display(Name = "Password")]
        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public IFormFile File { get; set; }
        public int? Term { get; set; }
        public bool? IsActive { get; set; }
        public virtual RelatedFacilities RelatedFacility { get; set; }
        public virtual Lookups RentTypeNavigation { get; set; }
        public virtual ProviderSpecialities SpecialityNavigation { get; set; }
        public virtual Lookups StatusNavigation { get; set; }
        public virtual Lookups SuffixNavigation { get; set; }
        public virtual ProviderTerms TermNavigation { get; set; }
        public virtual Lookups TitleNavigation { get; set; }
        public virtual ProviderUIDTypes UidTypeNavigation { get; set; }
        public virtual Users User { get; set; }

        public string Profileimage { get; set; }
        public string Signatureimage { get; set; }

        public string HiddentWriteSignImage{ get; set; }
        public string HiddenSignImg { get; set; }

        public bool? IsSchedule { get; set; }

    }
}
