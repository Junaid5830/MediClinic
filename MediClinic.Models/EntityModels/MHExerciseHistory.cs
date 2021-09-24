using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MHExerciseHistory
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Exercise { get; set; }
        public string ExerciseType { get; set; }
        public string ExerciseNoOfDaysPerWeek { get; set; }
        public string HobbiesOrLeisureActivities { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
