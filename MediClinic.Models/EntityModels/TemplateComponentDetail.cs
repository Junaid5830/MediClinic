using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class TemplateComponentDetail
    {
        public int Id { get; set; }
        public int TemplateComponentId { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }

        public virtual TemplateComponent TemplateComponent { get; set; }
    }
}
