using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class DriverProfileDto
    {
        public int DriverId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]

        public string Address { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        [Required(ErrorMessage = "Zip Code is required")]

        [Display(Name = "ZIP Code")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use Digits only")]
        public string ZipCode { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage = "Mobile Phone is required")]
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string EmergencyPhone { get; set; }
        public string OtherPhone { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]

        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        [Required(ErrorMessage = "SSN Number is required")]

        public string SSNNumber { get; set; }
        [Required(ErrorMessage = "Licence Number required")]

        public string DriverLicence { get; set; }

        [Required(ErrorMessage = "Licence State is required")]

        public string LicenseState { get; set; }

        [Required(ErrorMessage = "Licence Class is required")]

        public string LicenseClass { get; set; }
        public int? GenderId { get; set; }
        public string Languages { get; set; }
        public string DriverImage { get; set; }
        public string DriverSignature { get; set; }
        public bool IsActive { get; set; }
        public int? TransportId { get; set; }
        public int? TransportIdHidden { get; set; }
        public bool? IsOwnVehicle { get; set; }
        [Required(ErrorMessage = "Start time is required")]
        public TimeSpan? WorkingStartTime { get; set; }
        [Required(ErrorMessage = "End time is required")]

        public TimeSpan? WorkingEndTime { get; set; }


        public string[] DriverLanguageList { get; set; }
        public string FullName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string HiddenPhoto { get; set; }
        public string HiddenSign { get; set; }
        public List<Langauges> Langauges { get; set; }
        public string Token { get; set; }
        public string Gender { get; set; }

        public bool IsOwnVehicleHidden { get; set; }

        public string DriverCurrentJobStatus { get; set; }

        public string PickUpLocation { get; set; }
        public string DestinationLocation { get; set; }
        public int JobRequestId { get; set; }

    }
    public class Langauges
    {
        public string LanguageName { get; set; }
        public int LanguageId { get; set; }
    }
    public class DriverDirectionForMap
    {
        public int? DriverId { get; set; }

        public string FullName { get; set; }

        public string PLat { get; set; }
        public string PLng { get; set; }

        public string DLat { get; set; }
        public string DLng { get; set; }

        public string CLat { get; set; }
        public string CLng { get; set; }

        public string Status { get; set; }
        public int? StatusId { get; set; }

        public string PickUpLocation { get; set; }
        public string DestinationLocation { get; set; }

    }
}
