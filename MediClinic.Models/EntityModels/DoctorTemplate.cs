using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DoctorTemplate
    {
        public DoctorTemplate()
        {
            DoctorPatientTemplate = new HashSet<DoctorPatientTemplate>();
        }

        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int TemplateId { get; set; }

        public virtual Template Template { get; set; }
        public virtual ICollection<DoctorPatientTemplate> DoctorPatientTemplate { get; set; }
    }
}
