using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientSignatureIdType
    {
        public PatientSignatureIdType()
        {
            PatientIdAndSignature = new HashSet<PatientIdAndSignature>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<PatientIdAndSignature> PatientIdAndSignature { get; set; }
    }
}
