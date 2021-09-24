using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ClaimInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.ClaimService
{
    public class ClaimService : IClaimService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        public ClaimService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<bool>> ClaimCreate(ClaimBasicDto claimBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<ClaimBasicDto, Claims>(claimBasicDto);
            mapped.isActive = true;
            var data = await _context.Claims.AddAsync(mapped);
            if (!(data is null))
            {
                result = true;
            }
            await _context.SaveChangesAsync();

            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public async Task<ClaimBasicDto> ClaimGetById(int Id)
        {
            var Entity = await _context.Claims.FirstOrDefaultAsync(x => x.Claim_Id == Id);
            if (!(Entity is null))
            {
                var mappedData = _mapper.Map<ClaimBasicDto>(Entity);
                return mappedData;
            }
            else
            {
                return new ClaimBasicDto();
            }
        }

        public async Task<List<ClaimBasicDto>> ClaimList()
        {
            var rec = await _context.Claims.Include(p=>p.CPTCodeNavigation).Where(x=>x.isActive == true).ToListAsync();
            var response = new List<ClaimBasicDto>();
            return  _mapper.Map<List<Claims>, List<ClaimBasicDto>>(rec);
        }

        public async Task<List<ClaimBasicDto>> ClaimListByPatientId(int Id)
        {
            var joinData = await(from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                 join V in _context.Visits
                                 on P.AppointmentId equals V.AppoinmentId

                                 join C in _context.Claims
                                 on V.VisitId equals C.VisitId



                                 join CPT in _context.CPTCodes
                                 on C.CPTCode equals CPT.CPTCodeId

                                 select new ClaimBasicDto
                                 {
                                    BillDate = C.BillDate,
                                    Claim_Id = C.Claim_Id,
                                    BillStatus=C.BillStatus,
                                    DueDate=C.DueDate,
                                    DosFrom=C.DosFrom,
                                    DosTo=C.DosTo,
                                    TreatingProvider=C.TreatingProvider,
                                    CPTCodeNavigation=new CPTCodes() { Name=CPT.Name },
                                     TotalBill=C.TotalBill,
                                     DurationOfService=C.DurationOfService,
                                     TypeOfService=C.TypeOfService,



                                 }).ToListAsync();

            return joinData;
        }

        public async Task<ResponseDto<bool>> ClaimUpdate(ClaimBasicDto claimBasicDto)
        {
            var mapped = _mapper.Map<ClaimBasicDto, Claims>(claimBasicDto);
            var OldEntity = await _context.UserInRoles.FindAsync(mapped.Claim_Id);
           
            mapped.isActive = true;
            _context.Entry(OldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public bool DeleteClaim(int Id)
        {
            var rec = _context.Claims.FirstOrDefault(x => x.Claim_Id == Id);
            if (!(rec is null))
            {
                _context.Remove(rec);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<CPTCodeDto>> GetAllCPTCodes()
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<CPTCodeDto>(sql: "[GetAllCPTCodes]",
                commandType: CommandType.StoredProcedure);
                var response = result.ToList();
                if (response.Any())
                {
                    return result.ToList();
                }
                else
                {
                    return new List<CPTCodeDto>();
                }
            }
        }

        public async Task<List<ICDDto>> GetAllICDCodes(bool withDetail)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ICDDto>(sql: "[GetAllICDCodes]",
                param: new { withDescription = withDetail },
                commandType: CommandType.StoredProcedure);

                var response = result.ToList();
                if (response.Any())
                {
                    return result.ToList();
                }
                else
                {
                    return new List<ICDDto>();
                }

            }
        }
    }
}
