using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.ImmunizationInterface
{
    public interface IimmunizationService
    {
        public Task<ResponseDto<bool>> ImmunizationCreate(ImmunizationBasicDto immunizationBasicDto);
        public Task<ResponseDto<bool>> ImmunizationUpdate(ImmunizationBasicDto immunizationBasicDto);

        public Task<ImmunizationBasicDto> ImmunizationGetById(int Id);

        public bool ImmunizationDeleteById(int Id);

        public Task<List<ImmunizationBasicDto>> ImmunizationList(long Id);
        public Task<List<ImmunizationBasicDto>> ImmunizationListByVisits(long? Id);
        public Task<List<ImmunizationBasicDto>> ImmunizationListForVisits(int Id);

        public Task<List<ImmunizationBasicDto>> AllImmunizationList();

        Task<List<ICDDto>> GetAllICDCodes(bool withDetail);

    }
}
