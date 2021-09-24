using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class AllergyTypes
    {
        public AllergyTypes()
        {
            Allergies = new HashSet<Allergies>();
        }

        public int AllergyTypeId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? VisitId { get; set; }

        public virtual ICollection<Allergies> Allergies { get; set; }
    }
}
