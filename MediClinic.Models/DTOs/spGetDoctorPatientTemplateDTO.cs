using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class spGetDoctorPatientTemplateDTO
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string ComponentType { get; set; }
        public string ComponentLabel { get; set; }
        public string ComponentId { get; set; }
        public string ComponentPlaceholder { get; set; }
        public string ComponentName { get; set; }

        public string Value { get; set; }
        public int PatientId { get; set; }
        public int VisitId { get; set; }
        public string DoctorId { get; set; }
        public string DoctorTemplateId { get; set; }
        public string TemplateName { get; set; }

        public List<TemplateComponentDetailDTO> TemplateComponentDetailDTO { set; get; }
    }
}
