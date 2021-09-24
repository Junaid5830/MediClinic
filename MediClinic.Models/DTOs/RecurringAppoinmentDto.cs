using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientAppointmentsDto
{
    public class RecurringAppoinmentDto
    {
        public int AppointmentId { get; set; }
        public long? PatientInfoId { get; set; }
        public string AppointmentType { get; set; }
        public bool IsSundayChecked { get; set; }
        public bool IsMondayChecked { get; set; }
        public bool IsTuesdayChecked { get; set; }
        public bool IsWednesdayChecked { get; set; }
        public bool IsThursdayChecked { get; set; }
        public bool IsFridayChecked { get; set; }
        public bool IsSaturdayChecked { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public string ExactTime { get; set; }

        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        public long? RecursionNo { get; set; }
        public int Duration { get; set; }
        public long[] PatientId { get; set; }
        public long? ProviderInfoId { get; set; }

        public virtual ProviderInfo ProviderInfo { get; set; }
    }
}
