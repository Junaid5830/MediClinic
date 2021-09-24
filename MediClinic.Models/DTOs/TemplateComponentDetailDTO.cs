using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class TemplateComponentDetailDTO
    {
        public int Id { get; set; }
        public int TemplateComponentId { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
    }
}
