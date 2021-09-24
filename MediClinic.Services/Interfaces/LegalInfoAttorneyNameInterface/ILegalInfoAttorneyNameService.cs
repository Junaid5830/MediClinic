using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.LegalInfoAttorneyNameDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.LegalInfoAttorneyNameInterface
{
    public interface ILegalInfoAttorneyNameService
    {
        public Task<ResponseDto<int>> LegalInfoAttorneyName(LegalInfoAttorneyNameBasicDto legalInfoAttorneyNameBasicDto);

        public Task<ResponseDto<bool>> LegalInfoAttorneyNameUpdate(LegalInfoAttorneyNameBasicDto legalInfoFirmNameBasicDto);
        public Task<ResponseDto<List<LegalInfoAttorneyNameBasicDto>>> LegalInfoAttorneyList();

        public Task<ResponseDto<LegalInfoAttorneyNameBasicDto>> LegalInfoAttorneyNameId(int Id);

        public Task<ResponseDto<bool>> IsExistorNot(string Name);
    }
}
