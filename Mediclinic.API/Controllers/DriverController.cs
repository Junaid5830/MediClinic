using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediClinic.Models.ApiDtos;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces;
using MediClinic.Services.Interfaces.AuthInterface;
using MediClinic.Services.Interfaces.EmployeeInterface;
using MediClinic.Services.Interfaces.TransportEmsInterface;
using MedliClinic.Utilities.Utility.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using static MediClinic.Models.ApiDtos.DefaultDtos;

namespace Mediclinic.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthService _authservice;
        private readonly IEmployeeService _EmployeeService;
        private readonly IDriverService _driverService;
        private readonly ITransportEmsService _transportEms;

        public DriverController(IConfiguration config, IAuthService authService,
            IEmployeeService employeeService, IDriverService driverService, ITransportEmsService transportEms)
        {
            _authservice = authService;
            _EmployeeService = employeeService;
            _driverService = driverService;
            _transportEms = transportEms;
            _config = config;
        }
        [HttpPost]
        public async Task<IActionResult> Login(DriverAuthDto authDto)
        {
            var response = await _authservice.DriverLogin(new DriverAuthDto() 
            { Email = authDto.Email,Password = authDto.Password,DeviceTypeId = authDto.DeviceTypeId, DeviceToken = authDto.DeviceToken});

            if (response.Status == 1)
            {
                await _driverService.UpdateDriverAvailability(new DriverAvailabilityDto()
                { DriverId = response.Data.DriverId }, DriverStatuses.Active);

                var token = GenerateJsonWebToken(response.Data, authDto.Password);
                response.Data.Token = token;
                return Ok(response);
            }
            else
            {
                response.Message = ErrorMessages.InvalidEmailPassword;
                response.Status = 0;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(LogoutRequestDto request)
        {
            
            return Ok(await _authservice.Logout(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetDriverProfile(int requestId )
        {
            var rec = await _transportEms.GetDriverDetailById(requestId);
            return Ok(rec);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDriverProfile(DriverProfileUpdateDto driverDto)
        {
            var rec = await _driverService.DriverProfileUpdateApi(driverDto);
            return Ok(rec);
        }

        [HttpGet]
        public async Task<IActionResult> Languages()
        {          
            return Ok(await _transportEms.LanguageList());
        }


        [HttpPost]
        public async Task<IActionResult> CreateAttendance(AttendanceDto attendanceDto)
        {
            var data = await _driverService.CreateDriverAttendance(attendanceDto);
            return Ok(data);
        }



        [NonAction]
        public string GenerateJsonWebToken(DriverProfileApiDto driver, string password)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  new List<Claim>()
                  {
                    new Claim(SessionNames.Email,driver.Email),
                    new Claim(SessionNames.Password,password)
                  },
                  expires: DateTime.Now.AddDays(1),
                  signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
