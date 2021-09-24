using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PrescriptionTemplates
    {
        public PrescriptionTemplates()
        {
            PatientMedicationsTemplate = new HashSet<PatientMedicationsTemplate>();
        }

        public long TemplateId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public long? ProviderInfoId { get; set; }

        public virtual ProviderInfo ProviderInfo { get; set; }
        public virtual ICollection<PatientMedicationsTemplate> PatientMedicationsTemplate { get; set; }
    }
}
