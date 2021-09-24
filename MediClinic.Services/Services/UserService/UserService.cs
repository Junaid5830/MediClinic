using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.UserInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.UserService
{
    public class UserService : IUserService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;
        public UserService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public async Task<ResponseDto<List<UsersBasicDto>>> userInfo()
        {
            var rec = await _context.Users.ToListAsync();
            var response = new ResponseDto<List<UsersBasicDto>>();
            response.Data = _mapper.Map<List<Users>, List<UsersBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<UsersBasicDto>> userInfoCreate(UsersBasicDto userBasicDto)
        {
            //var result = false;
            //var mapped = _mapper.Map<UsersBasicDto, Users>(userBasicDto);
            //var data = await _context.Users.AddAsync(mapped);
            //var d = _context.SaveChanges();
            //if (!(data is null))
            //{
            //    result = true;
            //}
            //var response = new ResponseDto<bool>();
            //response.Data = result;
            //return response;
            var mapped = _mapper.Map<UsersBasicDto, Users>(userBasicDto);
            mapped.CreatedDate = DateTime.UtcNow;
            mapped.CreatedById = Convert.ToInt32(_sessionManager.GetUserId());
            mapped.IsActive = true;
            if (mapped.RoleTypeId == 4)
            {
                mapped.IsActive = false;
            }
            else
            {
                mapped.IsActive = true;
            }
            var data = await _context.Users.AddAsync(mapped);
            _context.SaveChanges();
            var entity = _mapper.Map<Users, UsersBasicDto>(mapped);
            var response = new ResponseDto<UsersBasicDto>();
            response.Data = entity;
            return response;
        }
        //public async Task<ResponseDto<UsersBasicDto>> userInfoCreate(UsersBasicDto userBasicDto)
        //{
        //    var mapped = _mapper.Map<UsersBasicDto, Users>(userBasicDto);
        //    var data = await _context.Users.AddAsync(mapped);
        //    _context.SaveChanges();
        //    var entity = _mapper.Map<Users, UsersBasicDto>(mapped);
        //    var response = new ResponseDto<UsersBasicDto>();
        //    response.Data = entity;
        //    return response;
        //}
        public async Task<ResponseDto<bool>> userInfoDeleteById(int Id)
        {
            var oldEntity = await _context.Users.FirstOrDefaultAsync(x => x.UserId == Id);
            _context.Remove(oldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<UsersBasicDto>> userInfoGetId(long Id)
        {
            var oldEntity = await _context.Users.FirstOrDefaultAsync(x => x.UserId == Id);
            var mapped = _mapper.Map<Users, UsersBasicDto>(oldEntity);
            var response = new ResponseDto<UsersBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> userInfoUpdate(UsersBasicDto userBasicDto)
        {
            var mapped = _mapper.Map<UsersBasicDto, Users>(userBasicDto);
            var oldEntity = await _context.Users.FindAsync(mapped.UserId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
        public async Task<ResponseDto<UsersBasicDto>> userInfoGetLastAdded()
        {
            var oldEntity = await _context.Users.OrderByDescending(x => x.UserId).FirstOrDefaultAsync();
            var mapped = _mapper.Map<Users, UsersBasicDto>(oldEntity);
            var response = new ResponseDto<UsersBasicDto>();
            response.Data = mapped;
            return response;
        }
        public async Task<ResponseDto<UsersBasicDto>> userInfoGetCreatedDate(DateTime date)
        {
            var oldEntity = await _context.Users.OrderByDescending(x => x.CreatedDate == date).FirstOrDefaultAsync();
            var mapped = _mapper.Map<Users, UsersBasicDto>(oldEntity);
            var response = new ResponseDto<UsersBasicDto>();
            response.Data = mapped;
            return response;
        }

        public Users GetUserDetail(int userId)
        {
            Users data = _context.Users.Where(x => x.UserId == userId).FirstOrDefault();
            return data;
        }
        public bool UpdateConnectionId(string connectionId)
        {
            Users user = new Users();
            var userId = _sessionManager.GetUserId();
            var detail = _context.Users.Where(x => x.UserId == userId).FirstOrDefault();
            detail.ConnectionId = connectionId;
            _context.Entry(detail).CurrentValues.SetValues(detail);
            _context.SaveChanges();
            return true;
        }

        public Task userInfoGetId(object userID)
        {
            throw new NotImplementedException();
        }
    }
}
