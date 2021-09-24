using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientCaseType
    {
        public int CaseTypeId { get; set; }
        public string CaseTypeName { get; set; }
        public long UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
