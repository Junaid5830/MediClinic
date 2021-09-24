using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.CptHspcCodesInterface
{
    public interface ICptHspcCodes
    {
        public Task<ResponseDto<CptHspcCodesDto>> AddUpdateCptHspcCode(CptHspcCodesDto cptHspcCodesDto);
        public Task<ResponseDto<bool>> DeleteCptHspcCode(int? Id);
        public Task<ResponseDto<List<CptHspcCodesDto>>> ListCptHspcCode();

        public Task<ResponseDto<CptCodeGroupListDto>> AddUpdateCptCodeGroup(CptCodeGroupListDto cptCodesGroupDto);
        public Task<ResponseDto<bool>> DeleteCptCodeGroup(int? Id);
        public Task<ResponseDto<List<CptCodeGroupListDto>>> ListCptCodeGroup();
    }
}
