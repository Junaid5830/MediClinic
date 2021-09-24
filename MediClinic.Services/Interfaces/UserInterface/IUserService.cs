using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.UserInterface
{
    public interface IUserService
    {
        public Task<ResponseDto<List<UsersBasicDto>>> userInfo();
        public Task<ResponseDto<UsersBasicDto>> userInfoCreate(UsersBasicDto userBasicDto);

        public Task<ResponseDto<bool>> userInfoUpdate(UsersBasicDto userBasicDto);

        public Task<ResponseDto<UsersBasicDto>> userInfoGetId(long Id);

        public Task<ResponseDto<bool>> userInfoDeleteById(int Id);
        public Task<ResponseDto<UsersBasicDto>> userInfoGetLastAdded();
        public Task<ResponseDto<UsersBasicDto>> userInfoGetCreatedDate(DateTime date);
        public bool UpdateConnectionId(string connectionId);
        public Users GetUserDetail(int userId);
        Task userInfoGetId(object userID);
    }
}
