using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientAppointmentsDto
{
    public class PatientAppointmentBasicDto
    {
        public int AppointmentId { get; set; }
        public long? PatientInfoId { get; set; }
        public string AppointmentType { get; set; }
        [Required]
        public DateTime? ExactTime { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public TimeSpan? StartTime { get; set; }
        [Required]
        public TimeSpan? EndTime { get; set; }
        public DateTime? EndDate { get; set; }

        public string PatientFullName { get; set; }
        public long? ProviderInfoId { get; set; }
        public int? ModifyBy { get; set; }
        public long? RecursionNo { get; set; }

        public string DocFullName { get; set; }

        public int Duration { get; set; }
        public string SelectedData { get; set; }
        public string PatFirstName { get; set; }

        public int? StatusId { get; set; }
        public string DocFirstName { get; set; }
        public long[] PatientId { get; set; }
        public int? DepartmentType { get; set; }

        public DateTime PatientDateOfBirth { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public long[] CheckBoxByProviderId { get; set; }
        public virtual ProviderInfo ProviderInfo { get; set; }
        public virtual PatientInfo PatientInfo { get; set; }


    }
}
