using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.LookupDto;
using MediClinic.Models.DTOs.PatientInfoListDto;
using MediClinic.Models.DTOs.PatientSettingsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class SurgeryCenterViewModel
    {
            public SurgeryCenterDto SurgeryCenterDto { get; set; }
            public List<SurgeryCenterDto> SurgeryCenterDtoList { get; set; }
            public List<LookupBasicDto> GenderDtoList { get; set; }
        public List<PatientInfoListDto> patientListWithUsers { get; set; }
        public PatientInfoListDto patientCompleteInfo { get; set; }

        public ProceduresDto Procedures { get; set; }
        public List<ProceduresDto> ProceduresList { get; set; }

        public ImagingDto imagingDto { get; set; }

        public List<ImagingDto> getImagingDto { get; set; }
    }
}
