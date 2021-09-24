using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.MessagesService
{
    public class MessagesService : IMessagesService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public MessagesService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public async Task<List<UsersBasicDto>> Getlist()
        {
            try
            {
                var list = await _context.Users.ToListAsync();
                var mapped = _mapper.Map<List<Users>, List<UsersBasicDto>>(list);
                return mapped;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<bool> Add(MessagesDto mesgDto)
        {
            MediClinicContext context = new MediClinicContext();
            try
            {
                var mapped = _mapper.Map<MessagesDto, Messages>(mesgDto);

                if (mesgDto.MessageId == 0)
                {
                    mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                    mesgDto.CreatedBy = mapped.CreatedBy;
                    mapped.CreatedDate = DateTime.UtcNow;
                    mesgDto.CreatedDate = mapped.CreatedDate;
                    context.Messages.Add(mapped);
                    await context.SaveChangesAsync();
                }

                else
                {
                    var oldEntity = _context.Messages.FirstOrDefault(x => x.MessageId == mesgDto.MessageId);
                    oldEntity.FromId = mesgDto.FromId;
                    oldEntity.ToId = mesgDto.ToId;
                    oldEntity.Message = mesgDto.Message;
                    mapped.ModifiedBy = Convert.ToInt32(_sessionManager.GetUserId());
                    mapped.ModifiedDate = DateTime.UtcNow;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return true;

        }

        public List<MessagesDto> GetMessageList(int id)
        {

            try
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = conn.Query<MessagesDto>(sql: "[spGetMessageList]", param: new { msgId = id },
                    commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<MessagesDto> GetReceiveMessageList(int id) 
        {
            try
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = conn.Query<MessagesDto>(sql: "[spGetReceiveMessageList]", param: new { msgId = id },
                    commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int mesgId)
        {
            var mesg = _context.Messages.Where(a => a.MessageId == mesgId).FirstOrDefault();
            if (mesg != null)
            {
                _context.Messages.Remove(mesg);
                _context.SaveChanges();
            }
            return true;
        }

        public MessagesDto GetMesgById(int mesgId)
        {
            var mesg = _context.Messages.Where(a => a.MessageId == mesgId).FirstOrDefault();
            var mapped = _mapper.Map<Messages, MessagesDto>(mesg);
            return mapped;
        }



        public async Task<ResponseDto<MessagesDto>> messageInfoGetId(int Id)
        {
            var oldEntity = await _context.Messages.Where(x => x.MessageId == Id).FirstOrDefaultAsync();
            var mapped = _mapper.Map<Messages, MessagesDto>(oldEntity);
            var response = new ResponseDto<MessagesDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<List<MessagesDto>> GetFacilityList()
        {
            var joinData = await(from U in _context.Users.Where(x => x.IsActive == true)
                                 join E in _context.Employee
                                 on U.UserId equals E.UserId

                               
                                 select new MessagesDto
                                 {
                                     UserID = U.UserId,
                                     FacilityName = E.FirstName  +' '+E.LastName
                                 }).ToListAsync();

            return joinData;
        }

        public Employee FaciltyDetail(long Id)
        {
           
            return _context.Employee.Where(x => x.UserId == Id).FirstOrDefault();
           
        }

        public List<MessagesDto> GetSendMasterMessageList(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = conn.Query<MessagesDto>(sql: "[spGetMessageSendListforMaster]", param: new { msgId = id },
                    commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MessagesDto> GetReceiveMessageListForRoles(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = conn.Query<MessagesDto>(sql: "[spGetReceiveMessageListForRoles]", param: new { msgId = id },
                    commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

