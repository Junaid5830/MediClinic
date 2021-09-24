using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class AppointmentListForReceptionist
    {
        public int AppointmentId { get; set; }
        public long? PatientInfoId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public DateTime? DateOfWeek { get; set; }
        public long? ProviderSessionId { get; set; }
        public bool IsBook { get; set; }
        public string DoctrFullName { get; set; }
        public long? ProviderInfoId { get; set; }
        public string PatientName { get; set; }
        public string AppointmentType { get; set; }

        public int StatusId { get; set; }

    }
}
