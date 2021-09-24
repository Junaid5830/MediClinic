using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.PatientAppointmentsDto
{
    public class AppointmentQueueDto
    {
        public int AppointmentId { get; set; }
        public long? PatientInfoId { get; set; }
        public string AppointmentType { get; set; }
        public string PatientName { get; set; }
        public long? ProviderInfoId { get; set; }
        public string DoctorName { get; set; }
        public string Speciality { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string ProviderProfilePic { get; set; }
        public bool? IsCompleted { get; set; }
        //public string BookAppointments { get; set; }
        public List<BookAppointment> BookAppointments { get; set; }

        public DateTime? ExactAppointmentTime { get; set; }
    }
    public class BookAppointment
    {
        public string StartTime { get; set; }
        public int AppointmentId { get; set; }
        public string FirstName { get; set; }
        public int PatientInfoId { get; set; }
    }
}
