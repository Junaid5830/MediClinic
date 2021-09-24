using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{

    public class EmployeeBasicDto
    {
       [Required]
        public string Email { get; set; }
        public long Employee_id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public int? GenderId { get; set; }
        public int? MaritalStatusId { get; set; }
        public int? RaceEthnicityId { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string Addressline3 { get; set; }
        [Display(Name = "ZIP Code")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use Digits only")]
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [Required]

        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]

        public string Password { get; set; }
        [Required]

        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public long? UserId { get; set; }
        public string EmployeeImage { get; set; }
        public int? EmploymentRoleId { get; set; }
        public int? createdById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool isUser { get; set; }
        public string MobNo { get; set; }
        public string LicenseNo { get; set; }
        public bool isActive { get; set; }
        public string HiddenPicture { get; set; }

        public virtual UserInRoles EmploymentRole { get; set; }

        public virtual Users User { get; set; }

    }
}
