using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class TemplateForPatientViewDto
    {
        public int DoctorTemplateId { get; set; }
        public string Name { get; set; }
        public int DoctorId { get; set; }
        public int VisitId { get; set; }
        public string VisitDetail { get; set; }
        public List<VisitDetail>  VisitDetails { get; set; }
    }
    public class VisitDetail
    {
        public string Label { get; set; }
        public int TemplateNo { get; set; }
        public string Value { get; set; }
        public int VisitId { get; set; }
    }
    public class Root
    {
        public List<TemplateForPatientViewDto> List { get; set; }
    }
}
