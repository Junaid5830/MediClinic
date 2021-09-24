using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.UserInRolesDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.UserInRolesInterface
{
    public interface IUserInRolesService
    {
        public Task<ResponseDto<List<UserInRolesBasicDto>>> authUserRole();

        public Task<ResponseDto<bool>> CreateUserRole(UserInRolesBasicDto userInRolesBasicDto);
        public Task<ResponseDto<bool>> Update(UserInRolesBasicDto userInRolesBasicDto);

        public Task<UserInRolesBasicDto> UserRoleGetById(int Id);

        public bool UserInRolesDelete(int Id);


    }
}
