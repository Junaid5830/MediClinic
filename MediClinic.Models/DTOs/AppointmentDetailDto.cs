using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class AppointmentDetailDto
    {
        public int AppointmentId { get; set; }
        public long? PatientInfoId { get; set; }
        public string AppointmentType { get; set; }

        [DataType(DataType.Time)]
        public DateTime? ExactTime { get; set; }
        public DateTime? Date { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? StartTime { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? EndTime { get; set; }
        public DateTime? EndDate { get; set; }

        public string PatientFullName { get; set; }
        public long? ProviderInfoId { get; set; }
        public string DocFullName { get; set; }
    }
}
