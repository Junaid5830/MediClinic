using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.LookupDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class TestsViewModel
    {
        public TestsDto TestsDto { get; set; }
        public List<TestsDto> TestsDtoList { get; set; }
        public List<LookupBasicDto> VisitProcedureCategoryDtoList { get; set; }
        public List<DoctorsInfoDto> DoctorsNamesDtoList { get; set; }
        public List<CPTCodesDto> CPTCodesDtoList { get; set; }
        public List<ICDCodesDto> ICDCodesDtoList { get; set; }
        public List<ProviderInfoBasicDto> ProviderList { get; set; }

    }

}