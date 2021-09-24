using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediClinic.Services.Interfaces.AuthInterface;
using MediClinic.Models.DTOs.CommonDto;
using AutoMapper;
using System.Linq;
using MediClinic.Models.DTOs;
using MedliClinic.Utilities.Utility.Enum;
using MediClinic.Models.ApiDtos;

namespace MediClinic.Services.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        public AuthService(MediClinicContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<ResponseDto<UsersBasicDto>> AuthUserAsync(AuthUserDto authUserDto)
        {
            try
            {
                var response = new ResponseDto<UsersBasicDto>();
                var rec = await _context.Users.Include(s => s.PatientIdAndSignature).Include(p => p.ProviderInfo).Include(e => e.Employee).
                FirstOrDefaultAsync(x => (x.Email.Equals(authUserDto.Email) || x.UserName.Equals(authUserDto.Email))
                && x.Password.Equals(authUserDto.Password) && x.RoleTypeId.Equals(authUserDto.RoleTypeId));
                if (!(rec is null))
                {
                    if (rec.IsActive is false)
                    {
                        response = new ResponseDto<UsersBasicDto> { Status = 0, Message = "Your Acount is InActive." };
                    }
                    else
                    {
                        response = !(rec is null) ?
                             new ResponseDto<UsersBasicDto>() { Data = _mapper.Map<UsersBasicDto>(rec) }
                             : new ResponseDto<UsersBasicDto> { Status = 0, Message = "Invalid Email or Password" };
                    }

                }
                else
                {
                    response = new ResponseDto<UsersBasicDto> { Status = 0, Message = "Invalid Email or Password" };

                }

                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<ResponseDto<bool>> CheckEmailExistOrNot(string email, long? userId, string UserName)
        {
            bool isExist = false;
            try
            {
                if (userId == null)
                {
                    var record = await _context.Users.FirstOrDefaultAsync(x => x.Email == email || x.UserName == UserName);
                    if (!(record is null))
                    {
                        isExist = true;
                    }
                }
                else
                {
                    var record = await _context.Users.FirstOrDefaultAsync(x => x.Email == email || x.UserName == UserName);
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
                    Message = "Email/UserName is already exist"
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<ResponseDto<bool>> CreateClient(AuthUserDto authUserDto)
        {
            try
            {
                var result = false;
                Users users = new Users();
                users.Email = authUserDto.Email;
                users.UserName = authUserDto.UserName;
                users.Password = authUserDto.Password;
                users.CreatedDate = DateTime.Now;
                users.IsActive = true;
                users.RoleTypeId = 5;
                users.IsClient = true;
                var data = await _context.Users.AddAsync(users);
                await _context.SaveChangesAsync();
                if (!(data is null))
                {
                    result = true;
                }
                var response = new ResponseDto<bool>();

                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }


        public async Task<long> GetEmployeeId(long UserId)
        {
            try
            {
                var data = await _context.Employee.Where(x => x.UserId == UserId).FirstOrDefaultAsync();
                return data.Employee_id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }

        public async Task<long> GetPatientInfoId(long userId )
        {
            var data = await _context.PatientInfo.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            return data.PatientInfoId;
        }
        public async Task<long> GetProviderInfoId(long userId)
        {
            var data = await _context.ProviderInfo.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            return data.ProviderInfoId;
        }

        public string ProfilePic(long UserId, int RoleId)
        {
            var Path = "";
            if (RoleId == 1)
            {
                var  data = _context.PatientIdAndSignature.Where(x => x.UserId == UserId).FirstOrDefault();
                if (data is null)
                {
                    Path = null;
                }
                else
                {
                    Path = data.PaitentImage;
                }
               
                
            }
            else if (RoleId == 2)
            {
                var data = _context.ProviderInfo.Where(x => x.UserId == UserId).FirstOrDefault();
                Path = data.ProviderProfilePic;
            }
            else
            {
                var data = _context.Employee.Where(e => e.UserId == UserId).FirstOrDefault();
                Path = data.EmployeeImage;
            }
            return Path;
        }

        #region Api
        public async Task<ResponseDto<DriverProfileApiDto>> DriverLogin(DriverAuthDto authDto)
        {
            try
            {
                var response = new ResponseDto<DriverProfileApiDto>();
                var rec = await _context.DriverProfile.FirstOrDefaultAsync(x =>x.Email.ToLower().Equals(authDto.Email.ToLower())
                && x.Password.ToLower().Equals(authDto.Password.ToLower()));
                
                if (!(rec is null))
                {
                    if (rec.isActive is false)
                    {
                        response = new ResponseDto<DriverProfileApiDto> { Status = 0, Message = "Your Acount is InActive.", Data = null };
                    }
                    else
                    {
                        if (rec.IsOwnVehicle is null)
                        {
                            rec.IsOwnVehicle = false;
                        }
                        var DeviceTypeId = 0;
                        if (authDto.DeviceTypeId == Convert.ToInt32(DeviceType.Android))
                        {
                            DeviceTypeId = Convert.ToInt32(DeviceTypeKeys.Android);
                        }
                        else if(authDto.DeviceTypeId == Convert.ToInt32(DeviceType.IOS))
                        {
                            DeviceTypeId = Convert.ToInt32(DeviceTypeKeys.IOS);
                        }

                        var isEntryExist = await _context.UserDevices.FirstOrDefaultAsync(x => x.UserId == rec.DriverId && x.DeviceTypeId == DeviceTypeId
                                           && x.DeviceToken.Equals(authDto.DeviceToken));
                        if (isEntryExist is null)
                        {
                            var mapObj = _mapper.Map<UserDevices>(authDto);
                            mapObj.CreatedDate = DateTime.UtcNow;

                            mapObj.DeviceTypeId = DeviceTypeId;

                            mapObj.UserId = rec.DriverId;
                            _context.UserDevices.Add(mapObj);
                            await _context.SaveChangesAsync();
                        }

                        var profileMapped = new DriverProfileApiDto();
                        if (!(rec is null))
                        {
                            profileMapped = _mapper.Map<DriverProfileApiDto>(rec);
                            if (rec.WorkingStartTime != null)
                            {
                                profileMapped.StartTime = rec.WorkingStartTime.ToString();
                                var index = profileMapped.StartTime.LastIndexOf(":");
                                profileMapped.StartTime = profileMapped.StartTime.Substring(0, index);
                            }
                            if (rec.WorkingEndTime != null)
                            {
                                profileMapped.EndTime = rec.WorkingEndTime.ToString();
                                var index = profileMapped.EndTime.LastIndexOf(":");
                                profileMapped.EndTime = profileMapped.EndTime.Substring(0, index);
                            }
                        }

                        response = !(rec is null) ?
                             new ResponseDto<DriverProfileApiDto>() { Data = profileMapped, Status = 1, Message = "Success" }
                             : new ResponseDto<DriverProfileApiDto> { Status = 0, Message = "Invalid Email or Password", Data = null };
                    }
                }
                else
                {
                    response = new ResponseDto<DriverProfileApiDto>() {  Data = null, Status = 0, Message = "Invalid Email or Password"} ;
                }
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        public async Task<ResponseDto<bool>> Logout(LogoutRequestDto request)
        {
            try
            {
                var userLogout = _context.UserDevices.FirstOrDefault(a =>a.UserId == request.DriverId &&
                                 a.DeviceTypeId == request.DeviceTypeId && a.DeviceToken == request.DeviceToken);
                if (!(userLogout is null))
                {
                    _context.UserDevices.Remove(userLogout);
                    await _context.SaveChangesAsync();
                }
                return new ResponseDto<bool>()
                {
                    Data = true,
                    Status = 1,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
