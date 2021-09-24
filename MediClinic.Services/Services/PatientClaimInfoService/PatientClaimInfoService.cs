using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientClaimInfo;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientClaimInfoInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientClaimInfoService
{
    public class PatientClaimInfoService : IPatientClaimInfoService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;
        public PatientClaimInfoService(MediClinicContext context,IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }

        public bool ClaimDelete(int Id)
        {
            var rec = _context.PatientsClaimInfo.FirstOrDefault(x => x.PatientClaimID == Id);
            if (!(rec is null))
            {
                rec.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<PatientClaimInfoBasicDto>> ClaimInfoList(long Id) 
        {
            var joinData = await(from PA in _context.PatientsClaimInfo.Where(x => x.PatientInfo == Id && x.IsActive == true)
                                 
                                 join L in _context.LegalInfoAttorneyName
                                 on PA.AttorneyId equals L.AttorneyId

                                 join C in _context.ClaimStatus
                                 on PA.ClaimStatusId equals C.ClaimStatusId

                                 join N in _context.Nf2Status
                                 on PA.Nf2Id equals N.Nf2Id 

                                 select new PatientClaimInfoBasicDto
                                 {
                                     
                                     DateOfIncident = PA.DateOfIncident,
                                     PrimaryInsuranceProvider = PA.PrimaryInsuranceProvider,
                                     ClaimNumber = PA.ClaimNumber,
                                     AdjusterName = PA.AdjusterName,
                                     CaseType = PA.CaseType,
                                     PatientClaimID = PA.PatientClaimID,
                                     AttorneyName = L.AttorneyName,
                                     claimStatusName = C.ClaimStatus1,
                                     nf2Name = N.Nf2Status1
                                 }).ToListAsync();

            return joinData;
        }

        public async Task<ResponseDto<bool>> patientClaimInfo(PatientClaimInfoBasicDto patientClaimInfoBasicDto)
        {
            try
            {
                var result = false;
                var mapped = _mapper.Map<PatientClaimInfoBasicDto, PatientsClaimInfo>(patientClaimInfoBasicDto);
                mapped.CreatedDate = DateTime.UtcNow;
                mapped.ModifiedDate = DateTime.UtcNow;
                mapped.CreatedById = Convert.ToInt32(_sessionManager.GetUserId());


                var data = await _context.PatientsClaimInfo.AddAsync(mapped);
                _context.SaveChanges();
                if (!(data is null))
                {
                    result = true;
                }
                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
       
        public async Task<ResponseDto<bool>> patientClaimInfoUpdate(PatientClaimInfoBasicDto patientClaimInfoBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<PatientClaimInfoBasicDto, PatientsClaimInfo>(patientClaimInfoBasicDto);
            var oldEntity = await _context.PatientsClaimInfo.FindAsync(mapped.PatientClaimID);

            mapped.CreatedDate = oldEntity.CreatedDate;
            mapped.ModifiedDate = DateTime.UtcNow;
            mapped.ModifiedById = Convert.ToInt32(_sessionManager.GetUserId());

            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();

            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;

        }

        public async Task<PatientClaimInfoBasicDto> ClaimInfoGetById(int Id)
        {
           var Entity = await _context.PatientsClaimInfo.FirstOrDefaultAsync(x => x.PatientClaimID == Id);
            if (!(Entity is null))
            {
                var mappedData = _mapper.Map<PatientClaimInfoBasicDto>(Entity);
                return mappedData;
            }
            else
            {
                return new PatientClaimInfoBasicDto();
            }
        }

        public async Task<List<PatientClaimInfoBasicDto>> AllClaimInfoList()
        {
            var joinData = await(from PA in _context.PatientsClaimInfo.Where(x => x.IsActive == true)

                                 join L in _context.LegalInfoAttorneyName
                                 on PA.AttorneyId equals L.AttorneyId

                                 join C in _context.ClaimStatus
                                 on PA.ClaimStatusId equals C.ClaimStatusId

                                 join N in _context.Nf2Status
                                 on PA.Nf2Id equals N.Nf2Id

                                 select new PatientClaimInfoBasicDto
                                 {

                                     DateOfIncident = PA.DateOfIncident,
                                     PrimaryInsuranceProvider = PA.PrimaryInsuranceProvider,
                                     ClaimNumber = PA.ClaimNumber,
                                     AdjusterName = PA.AdjusterName,
                                     CaseType = PA.CaseType,
                                     PatientClaimID = PA.PatientClaimID,
                                     AttorneyName = L.AttorneyName,
                                     claimStatusName = C.ClaimStatus1,
                                     nf2Name = N.Nf2Status1
                                 }).ToListAsync();

            return joinData;
        }
    }
}
