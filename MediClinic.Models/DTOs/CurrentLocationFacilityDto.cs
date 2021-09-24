using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class CurrentLocationFacilityDto
    {
        public int CurrentLocationId { get; set; }
        public string Location { get; set; }
        public string Condition { get; set; }
        public DateTime? DateCheckedIn { get; set; }
        public string Duration { get; set; }
        public string AnticipatedTime { get; set; }
        public string CaregiverOfLocation { get; set; }
        public string Nurse { get; set; }
        public string Assistant { get; set; }
        public int? PatientId { get; set; }
        public bool? IsActive { get; set; }
        public int? VisitId { get; set; }
    }
}
