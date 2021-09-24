using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.TemplateDto
{
    public class MedicationTemplateDto
    {
        public long? Id { get; set; }
        public long? MedicineId { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public string FrequencyId { get; set; }
        public int? Dose { get; set; }
        public string Unit { get; set; }
        public string Notes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
