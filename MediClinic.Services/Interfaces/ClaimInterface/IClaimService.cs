using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio.Http;

namespace MediClinic.Services.Interfaces.ClaimInterface
{
    public interface IClaimService
    {

        Task<ResponseDto<bool>> ClaimCreate(ClaimBasicDto claimBasicDto);
        Task<ResponseDto<bool>> ClaimUpdate(ClaimBasicDto claimBasicDto);
        Task<ClaimBasicDto> ClaimGetById(int Id);
        Task<List<ClaimBasicDto>> ClaimList();
        Task<List<ClaimBasicDto>> ClaimListByPatientId(int VisitId);

        bool DeleteClaim(int Id);

        Task<List<ICDDto>> GetAllICDCodes(bool withDetail);
        Task<List<CPTCodeDto>> GetAllCPTCodes();

    }
}
