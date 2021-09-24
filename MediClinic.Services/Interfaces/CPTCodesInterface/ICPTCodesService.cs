using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.CPTCodesInterface
{
    public interface ICPTCodesService
    {
        public List<CPTCodesDto> cptCodesDtoList(long id, string name);
        public Task<ResponseDto<List<CPTCodesDto>>> CPTCodesDtolist(long id);
        public ResponseDto<List<CPTCodesDto>> CPTByIdDto(long id);
        public Task<List<CPTCodesDto>> GetAllCPTCodes();
    }
}
