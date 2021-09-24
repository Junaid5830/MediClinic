using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Services.Interfaces.EmployeeInterface;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.UserInRolesInterface;
using MediClinic.Services.Interfaces.UserInterface;
using MedliClinic.Utilities.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediClinic.Controllers
{
    public class Employee : Controller
    {
        private readonly ILogger<Employee> _logger;
        private ISessionManager _sessionManager;
        private IEmployeeService _EmployeeService;
        private IUserService _userService;
        private readonly IUserInRolesService _UserInRole;
        private ILookupService _lookupService;


        public Employee(IEmployeeService employeeService, ILogger<Employee> logger, ISessionManager sessionManager,
            IUserService userService, IUserInRolesService UserInRole, ILookupService lookupService)
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _EmployeeService = employeeService;
            _userService = userService;
            _UserInRole = UserInRole;
            _lookupService = lookupService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EmployeeList()
        {
            EmployeeViewModal employeeViewModal = new EmployeeViewModal();
            employeeViewModal.EmployeesList = _EmployeeService.EmployeeList();
            return View(employeeViewModal);
           
        }
        public async Task<IActionResult> EmployeeAdd()
        {
            EmployeeViewModal employeeViewModal = new EmployeeViewModal();
            var list = await _UserInRole.authUserRole();
            
            employeeViewModal.UserRoleTypes = list.Data;
            if (employeeViewModal.UserRoleTypes.Count > 0)
            {
                var removeItem = employeeViewModal.UserRoleTypes.Single(r => r.UserRoleId == 1);
                employeeViewModal.UserRoleTypes.Remove(removeItem);
            }
            var GenderList = await _lookupService.LookupDtolist("Gender");
            employeeViewModal.gender = GenderList.Data;
            var MaritalStatusList = await _lookupService.LookupDtolist("MaritalStatus");
            employeeViewModal.maritalStatus = MaritalStatusList.Data;
            var RaceList = await _lookupService.LookupDtolist("Race/Ethnicity");
            employeeViewModal.RaceEthnicity = RaceList.Data;
            return View(employeeViewModal);
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeAdd(EmployeeViewModal employeeViewModal, string profileImage)
        {
            var UserId = _sessionManager.GetUserId();
            var isExistdata = await _EmployeeService.EmailisExistorNot(employeeViewModal.employeeBasicDto.Email);
            var isExistUserName = await _EmployeeService.UserisExistorNot(employeeViewModal.employeeBasicDto.UserName, employeeViewModal.employeeBasicDto.UserId, employeeViewModal.employeeBasicDto.Email);
            if (isExistdata.Data || isExistUserName.Data)
            {
                if (isExistdata.Data)
                {
                    var message = new { Success = isExistdata.Message, IsError = true };
                    return Json(message);
                }
                else
                {
                    var message = new { Success = isExistUserName.Message, IsError = true };
                    return Json(message);
                }
              
            }
            if (profileImage == "/app-assets/images/user/male-user.png")
            {
                employeeViewModal.employeeBasicDto.EmployeeImage = null;
            }
            else if (profileImage is null)
            {
                employeeViewModal.employeeBasicDto.EmployeeImage = null;
            }
            else
            {
                string pic = "data:image/png;base64,";
                profileImage = profileImage.Replace(pic, "");
                byte[] Picbytes = Convert.FromBase64String(profileImage);
                Image image_profile;
                using (MemoryStream pic_ms = new MemoryStream(Picbytes))
                {
                    image_profile = Image.FromStream(pic_ms);
                }
                MemoryStream pic_memStream = new MemoryStream();
                image_profile.Save(pic_memStream, ImageFormat.Png);
                pic_memStream.Seek(0, SeekOrigin.Begin);
                var ProfileImageFile = DateTime.UtcNow.ToString("ddMMyyyyhhmmss");
                ProfileImageFile = System.IO.Path.GetFileName(ProfileImageFile) + ".png";
                var ProfileImageFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", ProfileImageFile);
                using (var fileSteam = new FileStream(ProfileImageFilePath, FileMode.Create))
                {
                    await pic_memStream.CopyToAsync(fileSteam);
                }
                employeeViewModal.employeeBasicDto.EmployeeImage = ProfileImageFile;
                pic_memStream.Close();
            }
            //if (employeeViewModal.User.UserId == 0)
            //{

            //    employeeViewModal.User.RoleTypeId = 14;

            //    //patientViewModel.User.Password = patientViewModel.patientInfoBasicDto.Password;
            //    employeeViewModal.User.Email = employeeViewModal.employeeBasicDto.Email;
            //    //patientViewModel.User.UserName = patientViewModel.patientInfoBasicDto.UserName;

            //    var userforce = await _userService.userInfoCreate(employeeViewModal.User);
            //    employeeViewModal.employeeBasicDto.UserId = userforce.Data.UserId;

            //}
            //else
            //{
            //    employeeViewModal.employeeBasicDto.UserId = employeeViewModal.User.UserId;
            //}

            //var MergeLanguages = string.Join(",", language);
            //patientViewModel.patientInfoBasicDto.Language = MergeLanguages;
            var User = new UsersBasicDto();
            User.UserName = employeeViewModal.employeeBasicDto.UserName;
            User.Email = employeeViewModal.employeeBasicDto.Email;
            User.Password = employeeViewModal.employeeBasicDto.Password;
            User.RoleTypeId = (int)employeeViewModal.employeeBasicDto.EmploymentRoleId;
            var UserAdd = await _userService.userInfoCreate(User);

            employeeViewModal.employeeBasicDto.UserId = UserAdd.Data.UserId;
            employeeViewModal.employeeBasicDto.createdById = Convert.ToInt32(UserId);
            
            var EmployeeAdd  = await _EmployeeService.EmployeeCreate(employeeViewModal.employeeBasicDto);
            
            

            //CommonMethod.EmployeeVerificationEmail(employeeViewModal.employeeBasicDto.Email, EmployeeAdd.Data.Employee_id);
            //var data = new { Success = "Data saved successfully" };
            var data = new { UserId = employeeViewModal.employeeBasicDto.UserId, Success = "Data saved successfully" };

            return Json(data);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {

            var result = await _EmployeeService.EmployeetDeleteById(Id);
            var data = new { };
            return Json(data);
        }



    }
}
