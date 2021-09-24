using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DoctorPatientTemplate
    {
        public int Id { get; set; }
        public int DoctorTemplateId { get; set; }
        public int PatientId { get; set; }
        public int TemplateComponentId { get; set; }
        public string Value { get; set; }
        public int VisitId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual DoctorTemplate DoctorTemplate { get; set; }
        public virtual TemplateComponent TemplateComponent { get; set; }
    }
}
