using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Medicines
    {
        public Medicines()
        {
            PatientMedicationsTemplate = new HashSet<PatientMedicationsTemplate>();
            PatientPrescriptions = new HashSet<PatientPrescriptions>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<PatientMedicationsTemplate> PatientMedicationsTemplate { get; set; }
        public virtual ICollection<PatientPrescriptions> PatientPrescriptions { get; set; }
    }
}
