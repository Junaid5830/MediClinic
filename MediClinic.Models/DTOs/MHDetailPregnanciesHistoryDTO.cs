using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PMHistory
{
    public class MHDetailPregnanciesHistoryDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Delivery Date is required")]
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryType { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [StringLength(100, ErrorMessage = "Complications cannot be longer than {1} characters.")]
        public string Complications { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Integers value are accepted only")]
        public int? NoOfPregnancies { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "Integers value are accepted only")]
        public int? NoOfLivingChildren { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "Integers value are accepted only")]
        public int? NoOfAbortions { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "Integers value are accepted only")]
        public int? NoOfMiscarriages { get; set; }
    }
}
