using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MHFamilyHistory
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Relation { get; set; }
        public string DeceasedOrDeathAge { get; set; }
        public string MedicalConditionsOrCauseDeath { get; set; }
        public string BloodRelativeCondition { get; set; }
        public string Notes { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? VisitId { get; set; }

        public virtual Visits Visit { get; set; }
    }
}
