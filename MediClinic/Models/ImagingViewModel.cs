using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.PatientInfoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class ImagingViewModel
    {
        public List<PatientInfoBasicDto> patientInfoBasicDto { get; set; }
        public ImagingDto imagingDto { get; set; }

        public List<ImagingDto> getImagingDto { get; set; }
    }
}
