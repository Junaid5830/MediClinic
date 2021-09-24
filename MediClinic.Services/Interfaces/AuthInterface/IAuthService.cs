using MediClinic.Models.ApiDtos;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.UsersDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.AuthInterface
{
    public interface IAuthService
    {
        public Task<ResponseDto<UsersBasicDto>> AuthUserAsync(AuthUserDto authUserDto);
        public Task<long> GetPatientInfoId(long userId);
        public Task<long> GetProviderInfoId(long userId);

        public Task<long> GetEmployeeId(long UserId);
        public Task<ResponseDto<bool>> CheckEmailExistOrNot(string email, long? userId, string UserName);

        public Task<ResponseDto<bool>> CreateClient(AuthUserDto authUserDto);

        public string ProfilePic(long UserId, int RoleId);

        #region For Api
        Task<ResponseDto<DriverProfileApiDto>> DriverLogin(DriverAuthDto authDto);
        Task<ResponseDto<bool>> Logout(LogoutRequestDto request);

        #endregion
    }
}

