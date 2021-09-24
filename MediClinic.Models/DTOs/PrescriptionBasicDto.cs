using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PrescriptionDto
{
    public class PrescriptionBasicDto
    {
        public long Id { get; set; }
        [Required]
        public long MedicationId { get; set; }
        [Required]

        public int? Quantity { get; set; }
        public string FrequencyId { get; set; }
        public int? Dose { get; set; }
        public string Unit { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }

        public long PatientInfoId { get; set; }
        public int? VisitId { get; set; }

        public virtual Medicines Medication { get; set; }


    }
}
