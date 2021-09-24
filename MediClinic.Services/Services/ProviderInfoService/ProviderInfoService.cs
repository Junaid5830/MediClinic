using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientAppointmentsDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.DTOs.ProviderBasicSummaryDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.ProviderInfoService
{
    public class ProviderInfoService: IProviderInfoService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public ProviderInfoService(MediClinicContext context, IMapper mapper, ISessionManager session)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = session;
        }
        public async Task<ResponseDto<List<ProviderInfoBasicDto>>> providerInfo()
        {
            List<ProviderInfo> rec = new List<ProviderInfo>();
            var RoleId = _sessionManager.GetRoleId();
            if (RoleId == 2)
            {
                var ProvildeId = _sessionManager.GetProviderInfoId();
                rec = await _context.ProviderInfo.Where(x => x.ProviderInfoId == ProvildeId && x.IsActive==true).ToListAsync();

            }
            else
            {
                rec = await _context.ProviderInfo.Include(x=>x.RelatedFacility).Include(x=>x.SpecialityNavigation).Include(x=>x.TitleNavigation).Include(x=>x.RentTypeNavigation).Include(x=>x.StatusNavigation).Include(x=>x.SuffixNavigation).OrderByDescending(x => x.ProviderInfoId).Where(x=>x.IsActive==true).ToListAsync();
                int days = DateTime.UtcNow.DayOfWeek - DayOfWeek.Sunday;
                DateTime weekStart = DateTime.Now.AddDays(-days);
                DateTime weekEnd = weekStart.AddDays(6);
                foreach (var item in rec)
                {
                    var result = false;
                  var check =  _context.ProviderSessions.
                                  FirstOrDefault(x => x.IsActive == true && x.ProviderInfoId == item.ProviderInfoId && x.DateOfWeek >= weekStart.Date && x.DateOfWeek <= weekEnd);
                    if (!(check is null))
                    {
                        item.IsSchedule = true;
                    }
                }
            }

            var response = new ResponseDto<List<ProviderInfoBasicDto>>();
            response.Data = _mapper.Map<List<ProviderInfo>, List<ProviderInfoBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<ProviderInfoBasicDto>> providerInfoCreate(ProviderInfoBasicDto providerInfoBasicDto)
        {
            try
            {
                var mapped = _mapper.Map<ProviderInfoBasicDto, ProviderInfo>(providerInfoBasicDto);
                if (mapped.AllowSms is null)
                {
                    mapped.AllowSms = "No";
                }
                mapped.IsActive = true;
                var data = await _context.ProviderInfo.AddAsync(mapped);
                _context.SaveChanges();
                var entity = _mapper.Map<ProviderInfo, ProviderInfoBasicDto>(mapped);
                var response = new ResponseDto<ProviderInfoBasicDto>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }

        public async Task<ResponseDto<bool>> providerInfoDeleteById(int Id)
        {
            var oldEntity = await _context.ProviderInfo.FirstOrDefaultAsync(x => x.ProviderInfoId == Id);
            oldEntity.IsActive = false;
            //_context.Remove(oldEntity);
            await _context.SaveChangesAsync();

            var userOldEntity = await _context.Users.FirstOrDefaultAsync(x => x.UserId == oldEntity.UserId);
            userOldEntity.IsActive = false;
            await _context.SaveChangesAsync();

            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<ProviderInfoBasicDto>> providerInfoGetId(int Id)
        {
            var oldEntity = await _context.ProviderInfo.Include("SpecialityNavigation").Include("SuffixNavigation").Include("TitleNavigation").FirstOrDefaultAsync(x => x.ProviderInfoId == Id);
            var mapped = _mapper.Map<ProviderInfo, ProviderInfoBasicDto>(oldEntity);
            var response = new ResponseDto<ProviderInfoBasicDto>();
            response.Data = mapped;
            return response;
        }

        public ProviderInfo GetProviderUserId(long Id)
        {
            ProviderInfo data = _context.ProviderInfo.Where(x => x.ProviderInfoId == Id).FirstOrDefault();
            return data;
        }
        public async Task<ResponseDto<ProviderInfoBasicDto>> providerInfoGetLastAdded()
        {
            var oldEntity = await _context.ProviderInfo.OrderByDescending(x => x.ProviderInfoId).FirstOrDefaultAsync();
            var mapped = _mapper.Map<ProviderInfo, ProviderInfoBasicDto>(oldEntity);
            var response = new ResponseDto<ProviderInfoBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<ProviderInfoBasicDto>> providerInfoUpdate(ProviderInfoBasicDto providerInfoBasicDto)
        {
            try
            {
                var mapped = _mapper.Map<ProviderInfoBasicDto, ProviderInfo>(providerInfoBasicDto);
                var oldEntity = await _context.ProviderInfo.FindAsync(mapped.ProviderInfoId);
                if (mapped.AllowSms is null)
                {
                    mapped.AllowSms = "No";
                }
                mapped.IsActive = true;
                _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _context.SaveChangesAsync();
                var entity = _mapper.Map<ProviderInfo, ProviderInfoBasicDto>(mapped);

                var response = new ResponseDto<ProviderInfoBasicDto>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }          
        }

        public async Task<ResponseDto<bool>> CheckEmailExistOrNot(string email, long? userId,string UserName)
        {
            bool isExist = false;
            if (userId == null)
            {
                var record = await _context.Users.FirstOrDefaultAsync(x => x.Email.Trim().ToLower() == email.Trim().ToLower() || x.UserName.Trim().ToLower() == UserName.Trim().ToLower());
                if (!(record is null))
                {
                    isExist = true;
                }
            }
            else
            {
                var record = await _context.Users.FirstOrDefaultAsync(x => x.Email == email.Trim().ToLower() || x.UserName == UserName.Trim().ToLower());
                if (!(record is null))
                {
                    if (record.UserId != userId)
                    {
                        isExist = false;
                    }
                }
            }

            return new ResponseDto<bool>()
            {
                Data = isExist,
                Message = "Email/UserName is already exist"
            };
        }


        public async Task<ProviderSummaryDto> GetProviderSummaryDetails(long providerInfoId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ProviderSummaryDto>(sql: "[spGetProviderInfoById]", param: new { providerId = providerInfoId },
                commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }
        public async Task<ProviderDetails> GetProviderDetails(long providerInfoId)
        {
            try
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = await conn.QueryAsync<ProviderDetails>(sql: "[spGetProviderInfoById]", param: new { providerId = providerInfoId },
                    commandType: CommandType.StoredProcedure);

                    return result.FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;

            }
            
        }

        public async Task<List<ProviderInfoBasicDto>> GetProviderList()
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ProviderInfoBasicDto>(sql: "[spGetProviderList]",
                commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public async Task<bool> SaveWorkingHours(List<WeekDayWithSessionTypeDto> dayWithSessionTypeList, long providerId, long userId)
        {
            ProviderSessions providerSessions = new ProviderSessions();
            List<ProviderSessions> sessionList = new List<ProviderSessions>();
            try
            {
                var sessionTypes = await _context.ProviderSessionTypes.ToListAsync();

                if (!(dayWithSessionTypeList is null) && dayWithSessionTypeList.Count > 0)
                {
                    foreach (var item in dayWithSessionTypeList)
                    {
                        foreach (var SessionArray in item.ProviderSessionTypeArray)
                        {
                            providerSessions.WeekDayId = item.WeekDayId;
                            //providerSessions.ProviderSessionTypeId = SessionArray;
                            providerSessions.ProviderInfoId = providerId;
                            providerSessions.CreatedById = userId;
                            providerSessions.ModifiedById = userId;
                            providerSessions.CreatedDate = DateTime.Now;
                            providerSessions.ModifiedDate = DateTime.Now;
                            providerSessions.StartTime = (TimeSpan)sessionTypes.Where(x => x.ProviderSessionTypeId.Equals(SessionArray)).Select(x => x.StartTime).FirstOrDefault();
                            providerSessions.EndTime = (TimeSpan)sessionTypes.Where(x => x.ProviderSessionTypeId.Equals(SessionArray)).Select(x => x.EndTime).FirstOrDefault();
                            sessionList.Add(providerSessions);
                            providerSessions = new ProviderSessions();
                        }

                       
                    }
                    
                    await _context.ProviderSessions.AddRangeAsync(sessionList);
                     await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }
  
        }

        public async Task<List<ProviderWorkHrsDto>> GetAllProviderSessions(long providerId)
        {
            var sessionList = await _context.ProviderSessions.Include(x=>x.WeekDay).Where(x => x.ProviderInfoId == providerId && x.IsActive==true).ToListAsync();
            //var mappedData = _mapper.Map<List<ProviderWorkHrsDto>>(sessionList);
            ProviderWorkHrsDto workHrsDto = new ProviderWorkHrsDto();
            var workHrsList = new List<ProviderWorkHrsDto>();

            if (!(sessionList is null) && sessionList.Count > 0)
            {
                foreach (var item in sessionList)
                {
                    workHrsDto.ProviderSessionId = item.ProviderSessionId;
                    workHrsDto.ProviderInfoId = item.ProviderInfoId;
                    //workHrsDto.ProviderSessionTypeId = item.ProviderSessionTypeId;
                    workHrsDto.WeekDayId = item.WeekDayId;
                    //workHrsDto.SessionTypeName = item.ProviderSessionType.ProviderSessionType.Trim().Replace(" ", "");
                    workHrsDto.WeekDayName = item.WeekDay.WeekDayName;

                    workHrsList.Add(workHrsDto);
                    workHrsDto = new ProviderWorkHrsDto();

                }

                return workHrsList;
            }
            else
            {
                return new List<ProviderWorkHrsDto>();
            }
        }

        public async Task<bool> ProviderScheduling(List<ProviderWorkHrsDto> Schedule, long providerId)
        {
            ProviderSessions providerSessions = new ProviderSessions();
            List<ProviderSessions> sessionList = new List<ProviderSessions>();
            try
            {
                if (!(Schedule is null) && Schedule.Count > 0)
                {
                    var now = DateTime.Now;
                    var currentDay = now.DayOfWeek;
                    int days = (int)currentDay;
                    DateTime sunday = now.AddDays(-days);
                    var daysThisWeek = Enumerable.Range(0, 7)
                        .Select(d => sunday.AddDays(d))
                        .ToList();

                    foreach (var item in Schedule)
                    {
                        providerSessions.WeekDayId = item.WeekDayId;
                        //providerSessions.ProviderSessionTypeId = SessionArray;
                        providerSessions.ProviderInfoId = providerId;
                        providerSessions.StartTime = item.StartTime.TimeOfDay;
                        providerSessions.EndTime = item.EndTime.TimeOfDay;
                        providerSessions.CreatedDate = DateTime.Now;
                        providerSessions.DepartmentName = item.DepartmentName;
                        providerSessions.IsActive = true;
                        
                        if (item.Days == "Sunday")
                        {
                            providerSessions.DateOfWeek = daysThisWeek[0].Date;
                        }
                        if (item.Days == "Monday")
                        {
                            providerSessions.DateOfWeek = daysThisWeek[1].Date;
                        }
                        if (item.Days == "Tuesday")
                        {
                            providerSessions.DateOfWeek = daysThisWeek[2].Date;
                        }
                        if (item.Days == "Wednesday")
                        {
                            providerSessions.DateOfWeek = daysThisWeek[3].Date;
                        }
                        if (item.Days == "Thusday")
                        {
                            providerSessions.DateOfWeek = daysThisWeek[4].Date;
                        }
                        if (item.Days == "Friday")
                        {
                            providerSessions.DateOfWeek = daysThisWeek[5].Date;
                        }
                        if (item.Days == "Saturday")
                        {
                            providerSessions.DateOfWeek = daysThisWeek[6].Date;
                        }
                        
                        sessionList.Add(providerSessions);
                        providerSessions = new ProviderSessions();

                    }

                    await _context.ProviderSessions.AddRangeAsync(sessionList);
                    await _context.SaveChangesAsync();
                    
                    
                }
                ProviderSlots providerSlots = new ProviderSlots();
                List<ProviderSlots> SlotsList = new List<ProviderSlots>();
                if (!(sessionList is null) && sessionList.Count>0)
                {
                    foreach (var item in sessionList)
                    {
                        var Duration = (item.EndTime.TotalMinutes - item.StartTime.TotalMinutes)/ 15;
                        int i;
                        int ST = 0;
                        int ET = 0;
                        for (i= 0; i < Duration; i++)
                        {
                            TimeSpan ts = item.StartTime;
                            TimeSpan time1 = TimeSpan.FromMinutes(15);
                            
                            TimeSpan STime = TimeSpan.FromMinutes(ST);
                            TimeSpan ETime = TimeSpan.FromMinutes(ET);
                            providerSlots.ProviderInfoId = providerId;
                            providerSlots.DayOfWeek = item.DateOfWeek;
                            providerSlots.ProviderSessionId = item.ProviderSessionId;
                            providerSlots.Duration = Duration.ToString();
                            providerSlots.CreatedDate = DateTime.Now;
                            providerSlots.CreatedById = providerId;
                            if (i is 0)
                            {
                                providerSlots.StartTime = item.StartTime;
                                providerSlots.EndTime = ts.Add(time1);
                                ST = ST + 15;
                                ET = 15 * 2;

                            }
                            if (!(i is 0))
                            {
                                providerSlots.StartTime = ts.Add(STime);
                                providerSlots.EndTime = ts.Add(ETime);
                                ST = ST + 15;
                                ET = ET + 15;
                               
                            }
                            SlotsList.Add(providerSlots);
                            providerSlots = new ProviderSlots();
                        }

                        
                    }
                    await _context.ProviderSlots.AddRangeAsync(SlotsList);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }
        }

        public async Task<List<ProviderWorkHrsDto>> ProviderScheduleList(long ProviderId)
        {
            var joinData = await(from PA in _context.ProviderSessions.OrderByDescending(x=>x.DateOfWeek).Where(x => x.ProviderInfoId == ProviderId && x.IsActive==true)
                                 
                                 join M in _context.WeekDays
                                 on PA.WeekDayId equals M.WeekDayId
                                 select new ProviderWorkHrsDto
                                 {
                                     STime = PA.StartTime,
                                     ETime = PA.EndTime,
                                     WeekDayName = M.WeekDayName,
                                     WeekDate = PA.DateOfWeek,
                                     DepartmentName = PA.DepartmentName

                                 }).ToListAsync();

            return joinData;
        }

        public async Task<List<ProviderWorkHrsDto>> AllScheduleList()
        {
            var joinData = await (from PA in _context.ProviderSessions.Where(x=>x.IsActive==true)

                                  join M in _context.WeekDays
                                  on PA.WeekDayId equals M.WeekDayId

                                  join P in _context.ProviderInfo
                                  on PA.ProviderInfoId equals P.ProviderInfoId
                                  select new ProviderWorkHrsDto
                                  {
                                      ProviderSessionId = PA.ProviderSessionId,
                                      STime = PA.StartTime,
                                      ETime = PA.EndTime,
                                      WeekDayName = M.WeekDayName,
                                      WeekDate = PA.DateOfWeek,
                                      DepartmentName = PA.DepartmentName,
                                      DoctorName = "Dr" + " " + P.FirstName + " " + P.LastName

                                  }).ToListAsync();

            return joinData;
        }

        public async Task<ResponseDto<ProviderInfoBasicDto>> providerInfoGetByUserId(int Id)
        {
            var oldEntity = await _context.ProviderInfo.Include("SpecialityNavigation").Include("SuffixNavigation").Include("TitleNavigation").FirstOrDefaultAsync(x => x.UserId == Id);
            var mapped = _mapper.Map<ProviderInfo, ProviderInfoBasicDto>(oldEntity);
            var response = new ResponseDto<ProviderInfoBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<bool> DeleteScheduleByProviderId(int Id)
        {
            try
            {
                var result = false;
                var oldEntity = await _context.ProviderSessions.Where(x => x.ProviderSessionId == Id).FirstOrDefaultAsync();
                oldEntity.IsActive=false;
                await _context.SaveChangesAsync();

                result = true;
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<List<PatientAppointmentBasicDto>> ProviderPatientBookSlotsList(long ProviderId)
        {
            var joinData = await(from PA in _context.PatientAppointments.Where(x => x.ProviderInfoId == ProviderId)

                              
                                 join P in _context.PatientInfo
                                 on PA.PatientInfoId equals P.PatientInfoId
                                 
                                 join L in _context.Lookups
                                 on P.GenderId equals L.LookupId
                                 select new PatientAppointmentBasicDto
                                 {
                                    PatientInfoId=P.PatientInfoId,
                                    PatientFullName = P.FirstName +" "+ P.LastName,
                                    PatientDateOfBirth= (DateTime)P.DateOfBirth,
                                    Gender=L.LookupValue,
                                    Email=P.Email,
                                    StartTime=PA.StartTime,
                                    EndTime=PA.EndTime,
                                    ExactTime=PA.ExactTime,
                                    AppointmentType=PA.AppointmentType,
                                    EndDate=PA.EndDate,
                                    Date=PA.Date
                               }).ToListAsync();

            return joinData;
        }



        public async Task<List<ProviderWorkHrsDto>> GetAllScheduleListById(long providerId)
        {

            int days = DateTime.UtcNow.DayOfWeek - DayOfWeek.Sunday;
            DateTime weekStart = DateTime.Now.AddDays(-days);
            DateTime weekEnd = weekStart.AddDays(6);

            //var records = holidays.Where(h => h.StartDate <= weekEnd && h.EndDate >= weekStart);

            var joinData = await (from PA in _context.ProviderSessions.
                                  Where(x => x.IsActive == true && x.ProviderInfoId == providerId && x.DateOfWeek >= weekStart.Date && x.DateOfWeek <= weekEnd)

                                  join M in _context.WeekDays
                                  on PA.WeekDayId equals M.WeekDayId

                                  join P in _context.ProviderInfo
                                  on PA.ProviderInfoId equals P.ProviderInfoId
                                  select new ProviderWorkHrsDto
                                  {
                                      ProviderSessionId = PA.ProviderSessionId,
                                      STime = PA.StartTime,
                                      ETime = PA.EndTime,
                                      WeekDayName = M.WeekDayName,
                                      WeekDate = PA.DateOfWeek,
                                      DepartmentName = PA.DepartmentName,
                                      DoctorName = "Dr" + " " + P.FirstName + " " + P.LastName,
                                      WeekDayId = PA.WeekDayId

                                  }).ToListAsync();

            return joinData;
        }

        public async Task<List<PatientAppointmentBasicDto>> ProviderBookedAppointment(long ProviderId)
        {
            var bookedAppointment = await _context.PatientAppointments.Where(x => x.ProviderInfoId == ProviderId).ToListAsync();
            var mapped = _mapper.Map<List<PatientAppointments>, List<PatientAppointmentBasicDto>>(bookedAppointment);
            return mapped;
        }

        public async Task<List<PatientInfoBasicDto>> ProviderPatientsList(long ProviderId)
        {
            var joinData = await(from PA in _context.PatientAppointments.Where(x => x.ProviderInfoId == ProviderId)


                                 join P in _context.PatientInfo
                                 on PA.PatientInfoId equals P.PatientInfoId

                                 join PN in _context.PatientPhoneNumber
                                 on P.UserId equals PN.UserId

                                 join PII in _context.PatientPersonalInjury
                                 on P.UserId equals PII.UserId

                                 join LInAN in _context.LegalInfoFirmName
                                 on PII.FirmId equals LInAN.FirmId

                                 join LILP in _context.LegalInfoLeadingParalegal
                                 on PII.LeadingParalegalId equals LILP.LeadingParalegalId
                                 join L in _context.Lookups
                                 on P.GenderId equals L.LookupId
                                 select new PatientInfoBasicDto
                                 {
                                     PatientInfoId = P.PatientInfoId,
                                     FirstName = P.FirstName,
                                     LastName = P.LastName,
                                     DateOfBirth = (DateTime)P.DateOfBirth,
                                     MobNo = PN.MobilePhone,
                                     HomeNo = PN.HomePhone,
                                     ReferralName = P.ReferralName,
                                     AddressLine1 = P.AddressLine1,
                                     FirmAttorneyName= LInAN.FirmName,
                                     LeadingParalegal = LILP.LeadingParalegalName,
                                     UserId = (long)P.UserId

                                 }).Distinct().ToListAsync();

            return joinData;
        }

        public async Task<ProviderSummarySettingsDto> GetProviderSummarySetting()
        {
            var entity = await _context.ProviderSummarySettings.FirstOrDefaultAsync();
            var mapper = _mapper.Map<ProviderSummarySettingsDto>(entity);
            return mapper;
        }

        public async Task<List<PatientAppointmentBasicDto>> ProviderPatientsbookedSlots(long ProviderId)
        {
            var joinData = await(from PA in _context.PatientAppointments.Where(x => x.ProviderInfoId == ProviderId)


                                 join P in _context.PatientInfo
                                 on PA.PatientInfoId equals P.PatientInfoId

                                 join L in _context.Lookups
                                 on P.GenderId equals L.LookupId
                                 select new PatientAppointmentBasicDto
                                 {
                                     PatientInfoId = P.PatientInfoId,
                                     PatientFullName = P.FirstName + " " + P.LastName,
                                     PatientDateOfBirth = (DateTime)P.DateOfBirth,
                                     Gender = L.LookupValue,
                                     Email = P.Email,

                                 }).Distinct().ToListAsync();

            return joinData;
        }
    }
}
