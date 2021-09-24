﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientSecondaryInsuranceDto
{
    public class PatientSecondaryInsuranceBasicDto
    {
        public long SecondaryInsuranceProviderID { get; set; }
        [Required]
        [Display(Name = "Provider Name")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Use Characters only")]
        public int? ProviderId { get; set; }
        public string PlanName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; }

        [StringLength(18, ErrorMessage = "Policy number should be 5-18 digit long")]
        public string PolicyNumber { get; set; }
        public int? GroupId { get; set; }

        public string SubscriberEmployer { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
       
        public string Country { get; set; }
       
        public string City { get; set; }
       
        public string State { get; set; }
        [Required]
        [Display(Name = "ZIP Code")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use Digits only")]

        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string website { get; set; }

        public long UserId { get; set; }

    }
}
