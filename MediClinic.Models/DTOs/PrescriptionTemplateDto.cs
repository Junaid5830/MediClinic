using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.TemplateDto
{
    public class PrescriptionTemplateDto
    {
        public long Id { get; set; }
        public long TemplateId { get; set; }

        [Required(ErrorMessage ="Medication is required")]
        public long MedicineId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int? Quantity { get; set; }
        [Required(ErrorMessage = "Frequency is required")]
        public string FrequencyId { get; set; }
        public int VisitId { get; set; }

        [Required(ErrorMessage = "Dose is required")]
        public int? Dose { get; set; }
        [Required(ErrorMessage = "Unit is required")]
        public string Unit { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Notes { get; set; }
    }
}
