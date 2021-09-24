using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class TemplateViewModal
    {
        public TemplateDTO TemplateDTO { get; set; }
        public List<TemplateDTO> GetAllTemplate { get; set; }

        public TemplateComponentDTO TemplateComponentDTO { set; get; }
        public List<TemplateComponentDTO> GetComponentList { get; set; }

        public DoctorTemplateDTO DoctorTemplateDTO { set; get; }
        public List<spGetDoctorTemplateDTO> GetDoctorTemplateList { get; set; }

        public List<spGetDoctorPatientTemplateDTO> GetDoctorPatientTemplateList { get; set; }

        public TemplateComponentDetailDTO TemplateComponentDetailDTO { get; set; }
        public List<PatientInfoBasicDto> patientInfoBasicDtos { get; set; }
        public List<TemplateForPatientViewDto> TemplateList { get; set; }
        public List<ProviderInfoBasicDto> ProviderList { get; set; }

        public List<VisitsDto> getVisits { get; set; }
        public List<ICDDto> ICDList { get; set; }

    }
}
