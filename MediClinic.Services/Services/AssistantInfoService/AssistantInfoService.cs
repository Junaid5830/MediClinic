using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Services.Interfaces.Assistant;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
using System.Linq;

namespace MediClinic.Services.Services.AssistantInfoService
{
    public class AssistantInfoService : IAssistantService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public AssistantInfoService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<AssistantInfoDto>> assistantInfoGetId(int Id)
        {
            var oldEntity = await _context.AssistanInfo.Where(x => x.AssistantInfoID == Id).FirstOrDefaultAsync();
            var mapped = _mapper.Map<AssistanInfo, AssistantInfoDto>(oldEntity);
            var response = new ResponseDto<AssistantInfoDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<AssistantInfoDto>> assistantInfoAdd(AssistantInfoDto assistantInfoDto)
        {
            //var result = false;
            var mapped = _mapper.Map<AssistantInfoDto, AssistanInfo>(assistantInfoDto);
            mapped.CreatedDate = DateTime.UtcNow;
            mapped.ModifiedDate = DateTime.UtcNow;
            var data = await _context.AssistanInfo.AddAsync(mapped);
            _context.SaveChanges();

            var response = new ResponseDto<AssistantInfoDto>();
            //response.Data = result;
            return response;
        }

        public async Task<List<AssistantInfoDto>> AssistantInfoList(int? userid)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<AssistantInfoDto>(sql: "[spGetAssistantInfo]", param: new { UserID = userid },
                commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<ResponseDto<bool>> assistantInfoDeleteById(int Id)
        {
            long userId = 0;
            var oldEntity = await _context.AssistanInfo.FirstOrDefaultAsync(x => x.AssistantInfoID == Id);
            userId = (long)oldEntity.UserID;
            _context.Remove(oldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
         public async Task<List<DepartmentDto>> GetDepartmentList()
        {
            var list = await _context.Department.ToListAsync();
            var mapped = _mapper.Map<List<Department>, List<DepartmentDto>>(list);

            return mapped;
            
        }

        public async Task<List<DoctorsInfoDto>> GetDoctorList()
        {
            var list = await _context.DoctorsInfo.ToListAsync();
            var mapped = _mapper.Map<List<DoctorsInfo>, List<DoctorsInfoDto>>(list);

            return mapped;
        }
        public async Task<ResponseDto<bool>> assistantInfoUpdate(AssistantInfoDto assistantInfoDto)
        {
            try
            {
                var mapped = _mapper.Map<AssistantInfoDto, AssistanInfo>(assistantInfoDto);
                mapped.CreatedDate = DateTime.UtcNow;
                mapped.ModifiedDate = DateTime.UtcNow;
                var oldEntity = await _context.AssistanInfo.FindAsync(mapped.AssistantInfoID);
                _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _context.SaveChangesAsync();
                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ResponseDto<bool>> CheckEmailExistOrNot(string email, long? userId)
        {
            bool isExist = false;
            if (userId == null)
            {
                var record = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
                if (!(record is null))
                {
                    isExist = true;
                }
            }
            else
            {
                var record = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
                if (!(record is null))
                {
                    if (record.UserId != userId)
                    {
                        isExist = true;
                    }
                }
            }

            return new ResponseDto<bool>()
            {
                Data = isExist,
                Message = "Email is already exist"
            };
        }

        public async Task<ResponseDto<AssistantWorkingScheduleDto>> workingScheduleAdd(List<AssistantWorkingScheduleDto> WorkingSchedule)
        {
            
            //var result = false;
            var mapped = _mapper.Map<List<AssistantWorkingScheduleDto>, List<AssistantWorkingSchedule>>(WorkingSchedule);
            for (int i=0; i < mapped.Count; i++)
            {
                mapped[i].StartDate = DateTime.UtcNow;
                mapped[i].CreatedDate = DateTime.UtcNow;
                mapped[i].ModifiedDate = DateTime.UtcNow;
            }
            await _context.AssistantWorkingSchedule.AddRangeAsync(mapped);
            _context.SaveChanges();
            var response = new ResponseDto<AssistantWorkingScheduleDto>();
            return response;
        }
        public async Task<List<AssistantWorkingScheduleDto>> getworkschedule(int id)
        {
            
                var list = await _context.AssistantWorkingSchedule.Where(x => x.CreatedBy == id).ToListAsync();
                var mapped = _mapper.Map<List<AssistantWorkingSchedule>, List<AssistantWorkingScheduleDto>>(list);

                return mapped;
            
        }
        public async Task<ResponseDto<AssistantWorkingScheduleDto>> removeSchedule(int id)
        {
            var list = await _context.AssistantWorkingSchedule.Where(x => x.CreatedBy==id).ToListAsync(); 
            _context.AssistantWorkingSchedule.RemoveRange(list);
            await _context.SaveChangesAsync();

            var response = new ResponseDto<AssistantWorkingScheduleDto>();
            //response.Data = result;
            return response;
        }

        public async Task<ResponseDto<AssistantSettingDto>> SettingassistantInfoAdd(AssistantSettingDto settingassistantInfoDto)
        {
            var mapped = _mapper.Map<AssistantSettingDto, AssistanInfo>(settingassistantInfoDto);
            mapped.CreatedDate = DateTime.UtcNow;
            mapped.ModifiedDate = DateTime.UtcNow;
            var data = await _context.AssistanInfo.AddAsync(mapped);
            _context.SaveChanges();

            var response = new ResponseDto<AssistantSettingDto>();
            //response.Data = result;
            return response;
        }

        public async Task<ResponseDto<AssistantSettingDto>> SettingAssistantInfoGetId(int Id)
        {
            var oldEntity = await _context.AssistanInfo.Where(x => x.AssistantInfoID == Id).FirstOrDefaultAsync();
            var mapped = _mapper.Map<AssistanInfo, AssistantSettingDto>(oldEntity);
            var response = new ResponseDto<AssistantSettingDto>();
            response.Data = mapped;
            return response;
        }
    }
}
