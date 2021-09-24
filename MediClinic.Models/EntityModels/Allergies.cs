using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Allergies
    {
        public int AllergyId { get; set; }
        public int? AllergyTypeId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? VisitId { get; set; }

        public virtual AllergyTypes AllergyType { get; set; }
        public virtual Visits Visit { get; set; }
    }
}
