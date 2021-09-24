using MediClinic.Models.DTOs.LookupDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;

namespace MediClinic.Services.Interfaces.LookupInteface
{
    public interface ILookupService
    {
        public List<Lookups> lookupsByType(string lookupType,string name);
        public Task<ResponseDto<List<LookupBasicDto>>> LookupDtolist(string lookupType);
        public ResponseDto<List<LookupBasicDto>> lookupByTypeBasicDto(string lookupType);
        public Task<ResponseDto<bool>> IsLookUpValueExists(string value,string type);
        public Task<ResponseDto<int>> SaveLookUpValue(LookupBasicDto entity);
        public List<LookupBasicDto> GetClinicalNotelist(string lookupType);
    }
}
