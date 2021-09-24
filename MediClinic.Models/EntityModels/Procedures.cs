using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Procedures
    {
        public Procedures()
        {
            SurgeryCenter = new HashSet<SurgeryCenter>();
        }

        public int ProcedureId { get; set; }
        public string ProcedureType { get; set; }
        public DateTime? DateofProcedure { get; set; }
        public string ScanImage { get; set; }
        public string ScanImportant { get; set; }
        public long? PatientId { get; set; }
        public long? ProviderId { get; set; }

        public virtual PatientInfo Patient { get; set; }
        public virtual ProviderInfo Provider { get; set; }
        public virtual ICollection<SurgeryCenter> SurgeryCenter { get; set; }
    }
}
