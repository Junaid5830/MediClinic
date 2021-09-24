using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class TemplateComponent
    {
        public TemplateComponent()
        {
            DoctorPatientTemplate = new HashSet<DoctorPatientTemplate>();
            TemplateComponentDetail = new HashSet<TemplateComponentDetail>();
        }

        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string ComponentType { get; set; }
        public string ComponentLabel { get; set; }
        public string ComponentId { get; set; }
        public string ComponentPlaceholder { get; set; }
        public string ComponentName { get; set; }

        public virtual Template Template { get; set; }
        public virtual ICollection<DoctorPatientTemplate> DoctorPatientTemplate { get; set; }
        public virtual ICollection<TemplateComponentDetail> TemplateComponentDetail { get; set; }
    }
}
