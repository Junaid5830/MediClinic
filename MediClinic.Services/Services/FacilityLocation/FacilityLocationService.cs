using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.FacilityLocation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.FacilityLocation
{
    public class FacilityLocationService : IFacilityLocation
    {

        private MediClinicContext _context;
        private IMapper _mapper;

        public FacilityLocationService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddUpdate(CurrentLocationFacilityDto currentLocationFacilityDto)
        {
            var result = false;
            try
            {
                var mapped = _mapper.Map<CurrentLocationFacilityDto, CurrentLocationFacility>(currentLocationFacilityDto);

                if (currentLocationFacilityDto.CurrentLocationId == 0)
                {
                    mapped.IsActive = true;
                     _context.CurrentLocationFacility.Add(mapped);
                   await _context.SaveChangesAsync();
                    result = true;
                    return result;
                }
                else
                {
                    var OldEntity = await _context.CurrentLocationFacility.FirstOrDefaultAsync(x => x.CurrentLocationId == mapped.CurrentLocationId);
                    OldEntity.CurrentLocationId = currentLocationFacilityDto.CurrentLocationId;
                    OldEntity.Location = currentLocationFacilityDto.Location;
                    OldEntity.Condition = currentLocationFacilityDto.Condition;
                    OldEntity.DateCheckedIn = currentLocationFacilityDto.DateCheckedIn;
                    OldEntity.Duration = currentLocationFacilityDto.Duration;
                    OldEntity.AnticipatedTime = currentLocationFacilityDto.AnticipatedTime;
                    OldEntity.CaregiverOfLocation = currentLocationFacilityDto.CaregiverOfLocation;
                    OldEntity.Nurse = currentLocationFacilityDto.Nurse;
                    OldEntity.Assistant = currentLocationFacilityDto.Assistant;
                    OldEntity.PatientId = currentLocationFacilityDto.PatientId;
                    OldEntity.IsActive = true;
                    OldEntity.VisitId = currentLocationFacilityDto.VisitId;
                    await  _context.SaveChangesAsync();
                    result = true;
                    return result;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public async Task<bool> Delete(int Id)
        {
            var result = false;
            try
            {
                var OldEntity = await _context.CurrentLocationFacility.FirstOrDefaultAsync(x => x.CurrentLocationId == Id);
                OldEntity.IsActive = false;
                await _context.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public async Task<CurrentLocationFacilityDto> GetById(int Id)
        {
            var oldEntity = await _context.CurrentLocationFacility.FirstOrDefaultAsync(x => x.CurrentLocationId == Id);
            var mapped = _mapper.Map<CurrentLocationFacility, CurrentLocationFacilityDto>(oldEntity);
           
            return mapped;
        }

        public async Task<List<CurrentLocationFacilityDto>> GetListLocation()
        {
            var rec = await _context.CurrentLocationFacility.Where(x => x.IsActive == true && x.VisitId != null).ToListAsync();
            var mapper = _mapper.Map<List<CurrentLocationFacility>, List<CurrentLocationFacilityDto>>(rec);
            return mapper;

        }

        public async Task<List<CurrentLocationFacilityDto>> GetListLocationByPatientId(long? Id)
        {
            var joinData = await(from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                 join V in _context.Visits
                                 on P.AppointmentId equals V.AppoinmentId

                                 join C in _context.CurrentLocationFacility.Where(x=>x.IsActive==true)
                                 on V.VisitId equals C.VisitId

                                 //join A in _context.Claims
                                 //on AT.AllergyTypeId equals A.AllergyTypeId

                                 select new CurrentLocationFacilityDto
                                 {
                                     CurrentLocationId=C.CurrentLocationId,
                                     Location=C.Location,
                                     Condition=C.Condition,
                                     DateCheckedIn=C.DateCheckedIn,
                                     Duration=C.Duration,
                                     AnticipatedTime=C.AnticipatedTime,
                                     CaregiverOfLocation=C.CaregiverOfLocation,
                                     Nurse=C.Nurse,
                                     Assistant=C.Assistant



                                 }).ToListAsync();

            return joinData;
        }
    }
}
