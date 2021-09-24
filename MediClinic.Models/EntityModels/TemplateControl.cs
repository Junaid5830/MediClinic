using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class TemplateControl
    {
        public TemplateControl()
        {
            TemplateComponent = new HashSet<TemplateComponent>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TemplateComponent> TemplateComponent { get; set; }
    }
}
