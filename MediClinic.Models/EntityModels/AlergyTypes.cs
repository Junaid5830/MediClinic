using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class AlergyTypes
    {
        public int AlergyItemsId { get; set; }
        public int? AlergyId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }

        public virtual Allergies Alergy { get; set; }
    }
}
