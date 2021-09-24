using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.PatientCaseTypeDto
{
    public class PatientCaseTypeBasicDto
    {

        public string CaseTypeName { get; set; }
        public long UserId { get; set; }
        public long CaseTypeId { get; set; }
    }
}
