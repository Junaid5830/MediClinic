using MediClinic.Models.DTOs.PatientMissingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class PatientMissingViewModel
    {
        public PatientMissingsDto PatientMissingsDto { get; set; }
        public List<PatientMissingsDto> PatientMissingsListDto { get; set; }
    }
}
