using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MHSocialHistory
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Smoking { get; set; }
        public string Alcohol { get; set; }
        public int? AlcoholDrinks { get; set; }
        public string AlcoholPreferredDrink { get; set; }
        public int? AlcoholYearQuit { get; set; }
        public string Drugs { get; set; }
        public string Caffeine { get; set; }
        public string CaffeineDrinks { get; set; }
        public string Tobacco { get; set; }
        public string TobaccoType { get; set; }
        public int? TobaccoUsedYear { get; set; }
        public string TobaccoAmountPerDay { get; set; }
        public int? TobaccoYearQuit { get; set; }
        public string RecreationalDrugs { get; set; }
        public string RecreationalDrugsType { get; set; }
        public int? RecreationalDrugsAmountPerWeek { get; set; }
        public int? RecreationalDrugsLastUsed { get; set; }
        public string Exercise { get; set; }
        public string ExerciseType { get; set; }
        public string ExerciseNoOfDaysPerWeek { get; set; }
        public string HobbiesORLeisureActivities { get; set; }
        public string SmokingNotes { get; set; }
        public string CaffeineNotes { get; set; }
        public string AlcoholNotes { get; set; }
        public string LastMonthFeeling { get; set; }
        public string LastMonthPleasure { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
