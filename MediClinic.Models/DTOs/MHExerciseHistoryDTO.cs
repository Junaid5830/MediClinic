using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PMHistory
{
    public class MHExerciseHistoryDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [Required(ErrorMessage = "Exercise field is required")]
        public string Exercise { get; set; }
        [Required(ErrorMessage = "Exercise type is required")]
        public string ExerciseType { get; set; }
        public string ExerciseNoOfDaysPerWeek { get; set; }
        public string HobbiesOrLeisureActivities { get; set; }
    }
}
