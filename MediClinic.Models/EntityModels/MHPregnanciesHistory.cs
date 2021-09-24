using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MHPregnanciesHistory
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public DateTime? Mammogram { get; set; }
        public DateTime? BreastExam { get; set; }
        public DateTime? PapSmear { get; set; }
        public string Contraception { get; set; }
        public string ContraceptionDetail { get; set; }
        public int? FirstMensesAge { get; set; }
        public string MenstrualPeriods { get; set; }
        public int? MenopauseAge { get; set; }
        public string HotFlashesOrOther { get; set; }
        public string GynecologicalConditions { get; set; }
        public string Notes { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
