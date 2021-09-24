using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PMHistory
{
    public class MHPastMedicationHistoryDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than {1} characters.")]
        public string Name { get; set; }
        [StringLength(100, ErrorMessage = "Reason For Taking Medicine cannot be longer than {1} characters.")]
        public string ReasonForMedicine { get; set; }
        [StringLength(50, ErrorMessage = "Doctor Name cannot be longer than {1} characters.")]
        public string DocName { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid Phone No.(+923211234567)")]
        [StringLength(50, ErrorMessage = "Doctor Number cannot be longer than {1} characters.")]
        public string DocNumber { get; set; }
        [StringLength(50, ErrorMessage = "Pharmacy Number cannot be longer than {1} characters.")]
        public string PharName { get; set; }
        [StringLength(50, ErrorMessage = "Pharmacy Number cannot be longer than {1} characters.")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid Phone No.(+923211234567)")]

        public string PharNumber { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Integers value are accepted only")]
        [StringLength(50, ErrorMessage = "Dose cannot be longer than {1} characters.")]
        public string Dose { get; set; }
        public bool AsNeeded { get; set; }
        public string DoseFrequency { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot be longer than {1} characters.")]
        public string Notes { get; set; }
    }
}
