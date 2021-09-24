using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PMHistory
{
    public class MHPregnanciesHistoryDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [Required(ErrorMessage = "Mammogram is required")]

        [DataType(DataType.Date)]
        public DateTime? Mammogram { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BreastExam { get; set; }
        [DataType(DataType.Date)]
        public DateTime? PapSmear { get; set; }
        public string Contraception { get; set; }
        [StringLength(50, ErrorMessage = "What Kind Of Contraception cannot be longer than {1} characters.")]
        public string ContraceptionDetail { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Integers value are accepted only")]
        public int? FirstMensesAge { get; set; }
        public string MenstrualPeriods { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "Integers value are accepted only")]
        public int? MenopauseAge { get; set; }
        [StringLength(100, ErrorMessage = "Do You Have Hot Flashes Or Other Symptoms (Specify) cannot be longer than {1} characters.")]
        public string HotFlashesOrOther { get; set; }
        [StringLength(100, ErrorMessage = "Any Gynecological Conditions Or Problems cannot be longer than {1} characters.")]
        public string GynecologicalConditions { get; set; }
        [StringLength(500, ErrorMessage = "Notes cannot be longer than {1} characters.")]
        public string Notes { get; set; }
    }
}
