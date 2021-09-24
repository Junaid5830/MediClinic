using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientAttachments
    {
        public long PatientAttachmentId { get; set; }
        public string PatientPhoto { get; set; }
        public string PatientId { get; set; }
        public string PatientImage { get; set; }
    }
}
