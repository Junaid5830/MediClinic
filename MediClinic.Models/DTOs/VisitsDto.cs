using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class VisitsDto
    {
        public int VisitId { get; set; }
        public int AppoinmentId { get; set; }
        public string Status { get; set; }
        public string PatientName { get; set; }
        public string ProviderName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual PatientAppointments Appoinment { get; set; }
    }
}
