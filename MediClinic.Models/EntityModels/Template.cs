using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Template
    {
        public Template()
        {
            DoctorTemplate = new HashSet<DoctorTemplate>();
            TemplateComponent = new HashSet<TemplateComponent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<DoctorTemplate> DoctorTemplate { get; set; }
        public virtual ICollection<TemplateComponent> TemplateComponent { get; set; }
    }
}
