using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.LegalInfoFirmNameDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.LeagalInfoFirmNameInterface
{
    public interface ILegalInfoFirmNameService
    {
        public Task<ResponseDto<int>> LegalInfoFirmName(LegalInfoFirmNameBasicDto legalInfoFirmNameBasicDto);

        public Task<ResponseDto<bool>> LegalInfoFirmNameUpdte(LegalInfoFirmNameBasicDto legalInfoFirmNameBasicDto);
        public Task<ResponseDto<List<LegalInfoFirmNameBasicDto>>> LegalInfoFirmNameList();

        public Task<ResponseDto<LegalInfoFirmNameBasicDto>> LegalInfoFirmNameId(int Id);

        public Task<ResponseDto<bool>> isExistorNot(string Name);
    }
}
