using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientClaimInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientClaimInfoInterface
{
    public interface IPatientClaimInfoService
    {
        public Task<ResponseDto<bool>> patientClaimInfo(PatientClaimInfoBasicDto patientClaimInfoBasicDto);
        public Task<ResponseDto<bool>> patientClaimInfoUpdate(PatientClaimInfoBasicDto patientClaimInfoBasicDto);

        public Task<List<PatientClaimInfoBasicDto>> ClaimInfoList(long Id);

        public Task<List<PatientClaimInfoBasicDto>> AllClaimInfoList();

        public bool ClaimDelete(int Id);
        public Task<PatientClaimInfoBasicDto> ClaimInfoGetById(int Id);
    }
}
