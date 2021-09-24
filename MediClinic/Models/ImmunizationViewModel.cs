using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.PatientInfoListDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class ImmunizationViewModel
    {
        public ImmunizationBasicDto immunization { get; set; }
        public List<ImmunizationBasicDto> Listimmunization { get; set; }

        public List<ICDDto> ICDList { get; set; }

        public List<PatientInfoListDto> patientListWithUsers { get; set; }

        public List<ProviderInfoBasicDto> ProviderList { get; set; }

    }
}
