using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class DoctorPatientTemplateDTO
    {
        public int Id { get; set; }
        public int DoctorTemplateId { get; set; }
        public int TemplateComponentId { get; set; }
        public string Value { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
