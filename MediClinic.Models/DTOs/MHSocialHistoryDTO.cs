using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PMHistory
{
    public class MHSocialHistoryDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [Required(ErrorMessage = "Smoking is required")]
        public string Smoking { get; set; }
        [Required(ErrorMessage = "Alcohol is required")]
        public string Alcohol { get; set; }
        public int? AlcoholDrinks { get; set; }
        public string AlcoholPreferredDrink { get; set; }
        public int? AlcoholYearQuit { get; set; }
        [Required(ErrorMessage = "Drugs is required")]
        public string Drugs { get; set; }
        public string Caffeine { get; set; }
        public string CaffeineDrinks { get; set; }
        public string Tobacco { get; set; }
        public string TobaccoType { get; set; }
        public int? TobaccoUsedYear { get; set; }
        [StringLength(50, ErrorMessage = "Amount Per Day cannot be longer than {1} characters.")]
        public string TobaccoAmountPerDay { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Integers value are accepted only")]
        public int? TobaccoYearQuit { get; set; }
        public string SmokingNotes { get; set; }
        public string CaffeineNotes { get; set; }
        public string AlcoholNotes { get; set; }

    }
}
