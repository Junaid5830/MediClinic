using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ImmunizationInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.ImmunizationService
{
    public class ImmunizationService : IimmunizationService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public ImmunizationService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<bool>> ImmunizationCreate(ImmunizationBasicDto immunizationBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<ImmunizationBasicDto, Immunization>(immunizationBasicDto);
            var data = await _context.Immunization.AddAsync(mapped);
            if (!(data is null))
            {
                result = true;
            }
            await _context.SaveChangesAsync();
           
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public bool ImmunizationDeleteById(int Id)
        {
            var rec = _context.Immunization.FirstOrDefault(x => x.ImmunizationId == Id);
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

        public async Task<ImmunizationBasicDto> ImmunizationGetById(int Id)
        {
            var Entity = await _context.Immunization.FirstOrDefaultAsync(x => x.ImmunizationId == Id);
            if (!(Entity is null))
            {
                var mappedData = _mapper.Map<ImmunizationBasicDto>(Entity);
                return mappedData;
            }
            else
            {
                return new ImmunizationBasicDto();
            }
           
        }

        public async Task<List<ImmunizationBasicDto>> ImmunizationList(long Id)
        {
            var joinData = await (from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                  join V in _context.Visits
                                  on P.AppointmentId equals V.AppoinmentId



                                  join N in _context.Immunization
                                  on V.VisitId equals N.VisitId
                                  select new ImmunizationBasicDto
                                  {
                                      ImmunizationId = N.ImmunizationId,
                                      VaccineName = N.VaccineName,
                                      VaccineAbberivation = N.VaccineAbberivation,
                                      DoesInRouten = N.DoesInRouten,
                                      Route = N.Route,
                                      PatientCurrentAge = N.PatientCurrentAge,
                                      RouteOfAdministration = N.RouteOfAdministration,
                                      ReasonOfVaccine = N.ReasonOfVaccine,
                                      ICDCode = N.ICDCode
                                  }).ToListAsync();
            return joinData;
        }

        public async Task<ResponseDto<bool>> ImmunizationUpdate(ImmunizationBasicDto immunizationBasicDto)
        {
            var mapped = _mapper.Map<ImmunizationBasicDto, Immunization>(immunizationBasicDto);
            
            var OldEntity = await _context.Immunization.FindAsync(mapped.ImmunizationId);
           
            _context.Entry(OldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
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

        public async Task<List<ImmunizationBasicDto>> AllImmunizationList()
        {
            var joinData = await(from N in _context.Immunization.Where(x => x.IsActive == true && x.VisitId != null).OrderByDescending(x => x.ImmunizationId)


                                 select new ImmunizationBasicDto
                                 {
                                     ImmunizationId = N.ImmunizationId,
                                     VaccineName = N.VaccineName,
                                     VaccineAbberivation = N.VaccineAbberivation,
                                     DoesInRouten = N.DoesInRouten,
                                     Route = N.Route,
                                     PatientCurrentAge = N.PatientCurrentAge,
                                     RouteOfAdministration = N.RouteOfAdministration,
                                     ReasonOfVaccine = N.ReasonOfVaccine,
                                     ICDCode = N.ICDCode
                                 }).ToListAsync();
            return joinData;
        }

        public async Task<List<ImmunizationBasicDto>> ImmunizationListForVisits(int Id)
        {
            var joinData = await(from N in _context.Immunization.Where(x => x.VisitId == Id && x.IsActive == true).OrderByDescending(x => x.ImmunizationId)


                                 select new ImmunizationBasicDto
                                 {
                                     ImmunizationId = N.ImmunizationId,
                                     VaccineName = N.VaccineName,
                                     VaccineAbberivation = N.VaccineAbberivation,
                                     DoesInRouten = N.DoesInRouten,
                                     Route = N.Route,
                                     PatientCurrentAge = N.PatientCurrentAge,
                                     RouteOfAdministration = N.RouteOfAdministration,
                                     ReasonOfVaccine = N.ReasonOfVaccine,
                                     ICDCode = N.ICDCode
                                 }).ToListAsync();
            return joinData;
        }

        public async Task<List<ImmunizationBasicDto>> ImmunizationListByVisits(long? Id)
        {
            var joinData = await(from A in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                 join V in _context.Visits
                                 on A.AppointmentId equals V.AppoinmentId

                                 join I in _context.Immunization
                                 on V.VisitId equals I.VisitId

                               

                                 select new ImmunizationBasicDto
                                 {

                                     ImmunizationId = I.ImmunizationId,
                                     VaccineName = I.VaccineName,
                                     VaccineAbberivation = I.VaccineAbberivation,
                                     DoesInRouten = I.DoesInRouten,
                                     Route = I.Route,
                                     PatientCurrentAge = I.PatientCurrentAge,
                                     RouteOfAdministration = I.RouteOfAdministration,
                                     ReasonOfVaccine = I.ReasonOfVaccine,
                                     ICDCode = I.ICDCode

                                 }).ToListAsync();

            return joinData;
        }
    }
}
