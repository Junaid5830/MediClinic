using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.UserInRolesDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.UserInRolesInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;

namespace MediClinic.Services.Services.UserInRolesService
{
    public class UserInRolesService : IUserInRolesService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public UserInRolesService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<UserInRolesBasicDto>>> authUserRole()
        {
            var rec = await _context.UserInRoles.ToListAsync();
            var response = new ResponseDto<List<UserInRolesBasicDto>>();
            response.Data = _mapper.Map<List<UserInRoles> ,List<UserInRolesBasicDto>>(rec);
            return response;
            
        }

        public async Task<ResponseDto<bool>> CreateUserRole(UserInRolesBasicDto userInRolesBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<UserInRolesBasicDto, UserInRoles>(userInRolesBasicDto);
            mapped.CreatedById = 1;
            mapped.CreatedDate = DateTime.Now;
            var data = await _context.UserInRoles.AddAsync(mapped);
            if (!(data is null))
            {
                result = true;
            }
            await _context.SaveChangesAsync();

            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto<bool>> Update(UserInRolesBasicDto userInRolesBasicDto)
        {
            var mapped = _mapper.Map<UserInRolesBasicDto, UserInRoles>(userInRolesBasicDto);
            var OldEntity = await _context.UserInRoles.FindAsync(mapped.UserRoleId);
            mapped.CreatedById = OldEntity.CreatedById;
            mapped.CreatedDate = OldEntity.CreatedDate;
            mapped.ModifiedById = 1;
            mapped.ModifiedDate = DateTime.Now;
            _context.Entry(OldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public bool UserInRolesDelete(int Id)
        {
            var rec = _context.UserInRoles.FirstOrDefault(x => x.UserRoleId == Id);
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

        public async Task<UserInRolesBasicDto> UserRoleGetById(int Id)
        {
            var Entity = await _context.UserInRoles.FirstOrDefaultAsync(x => x.UserRoleId == Id);
            if (!(Entity is null))
            {
                var mappedData = _mapper.Map<UserInRolesBasicDto>(Entity);
                return mappedData;
            }
            else
            {
                return new UserInRolesBasicDto();
            }
        }
    }
}
