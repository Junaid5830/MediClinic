using MediClinic.Models.DTOs.ClaimStatus;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.ClaimStatusInterface
{
    public interface IClaimStatusService
    {
        public Task<ResponseDto<int>> claimStatus(ClaimStatusBasicDto claimStatusBasicDto);
        public Task<ResponseDto<bool>> ClaimStatusUpdate(ClaimStatusBasicDto claimStatusBasicDto);

        public Task<ResponseDto<ClaimStatusBasicDto>> ClaimStatusGetId(int id);
        public Task<ResponseDto<bool>> ClaimStatusDeleteId(int Id);
        public List<ClaimStatus> claimStatuelist(string name);

        public Task<ResponseDto<List<ClaimStatusBasicDto>>> PatientClaimStatusList();

        public Task<ResponseDto<bool>> isExistorNot(string Name);
    }
}
