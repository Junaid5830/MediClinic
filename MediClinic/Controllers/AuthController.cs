using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Services.Interfaces.AuthInterface;
using Microsoft.AspNetCore.Mvc;
using MediClinic.Models.DTOs.UsersDto;
using Microsoft.Extensions.Logging;
using MediClinic.Services.Interfaces.UserInRolesInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MedliClinic.Utilities.Utility.Enum;
using MediClinic.Services.Interfaces.UserInterface;
using MediClinic.Models.DTOs.UserInRolesDto;
using MediClinic.Services.Interfaces.UserRolePageInterface;
using MediClinic.Services.Interfaces.EmployeeInterface;
using MedliClinic.Utilities.Utility;
using MediClinic.Services.Interfaces.SubscriptionPackageInterface;

namespace MediClinic.Controllers.Auth
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authservice;
        private readonly IUserInRolesService _authUserInRole;
        private readonly ISessionManager _sessionManager;
        private readonly IUserService _userService;
        private readonly IUserRolePageService _userRolePageService;
        private IEmployeeService _EmployeeService;
        private readonly ISubscriptionPackageService _subscriptionPackageService;

        public AuthController(ILogger<AuthController> logger,
            IAuthService authservice,
            IUserInRolesService authUserInRole,
            ISessionManager sessionManager,
            IUserService userService, IUserRolePageService userRolePageService,
            IEmployeeService employeeService, ISubscriptionPackageService subscriptionPackageService)
        {
            _logger = logger;
            _authservice = authservice;
            _authUserInRole = authUserInRole;
            _sessionManager = sessionManager;
            _userService = userService;
            _userRolePageService = userRolePageService;
            _EmployeeService = employeeService;
            _subscriptionPackageService = subscriptionPackageService;
        }
        public async Task<IActionResult> AuthUser()
        {
            var list = await _authUserInRole.authUserRole();
            var model = new AuthUserDto();
            model.UserRoleTypes = list.Data;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AuthUser(AuthUserDto model)
        {
            
            if (ModelState.IsValid)
            {
                var rec = await _authservice.AuthUserAsync(model);
                if (!(rec.Data is null))
                {
                    _sessionManager.SetUserName(rec.Data.UserName);
                    _sessionManager.SetUserId(rec.Data.UserId);
                    _sessionManager.SetRoleId(rec.Data.RoleTypeId);
                   
                    var PermisionPageList = await _userRolePageService.GetSideBarList(rec.Data.RoleTypeId);
                    _sessionManager.SetPermisionPage(PermisionPageList);
                    int providerId;
                    if (model.RoleTypeId.Equals(Convert.ToInt32(RoleNames.Patient)))
                    {
                        var ImagePath = _authservice.ProfilePic(rec.Data.UserId,rec.Data.RoleTypeId);
                        if (ImagePath is null)
                        {
                            _sessionManager.SetProfilePic("Null");

                        }
                        else
                        {
                            _sessionManager.SetProfilePic(ImagePath);
                        }
                        var userPatientInfoId = await _authservice.GetPatientInfoId(rec.Data.UserId);
                        _sessionManager.SetPatientInfoId(userPatientInfoId);

                        return Json(Url.Action("PatientSummary2", "PatientSideElite", new { id = (int)userPatientInfoId }));
                        //return RedirectToAction("PatientSummary", "PatientSide", new { id = (int)userPatientInfoId });
                    }
                    else if (model.RoleTypeId.Equals(Convert.ToInt32(RoleNames.Doctor)))
                    {
                        var ImagePath = _authservice.ProfilePic(rec.Data.UserId, rec.Data.RoleTypeId);
                        if (ImagePath is null)
                        {
                            _sessionManager.SetProfilePic("Null");

                        }
                        else
                        {
                            _sessionManager.SetProfilePic(ImagePath);
                        }
                        await _userRolePageService.pageListOnUserRoleId(Convert.ToInt32(RoleNames.Doctor));
                        providerId = (int)await _authservice.GetProviderInfoId(rec.Data.UserId);
                        _sessionManager.SetProviderInfoId(providerId);

                        return Json(Url.Action("DocCurrentAppointment", "Appointment", new { id = (int)providerId }));
                    }
                              
                    else
                    {
                        var ImagePath = _authservice.ProfilePic(rec.Data.UserId, rec.Data.RoleTypeId);
                        if (ImagePath is null)
                        {
                            _sessionManager.SetProfilePic("Null");

                        }
                        else
                        {
                            _sessionManager.SetProfilePic(ImagePath);
                        }
                        var EmployeeId = await _authservice.GetEmployeeId(rec.Data.UserId);
                        _sessionManager.SetEmployeeId(EmployeeId);
                        providerId = (int)EmployeeId;
                    }
                    return Json(Url.Action("Index2", "Home", new { id = (int)providerId }));

                }
                else if (!(rec.Message is null))
                {
                   
                    var obj = new { isError = true, ErrorMessage = rec.Message };
                   
                    return Json(obj);
                }
               
            }

            var roleObj = new { isError = true, ErrorMessage = "Please Select Role" };

            return Json(roleObj);


        }

        [HttpPost]
        public async Task<IActionResult> AddClient(AuthUserDto model)
        {
            long EmpId=0;
            if (model.currentTab == 1)
            {
                model.employeeBasicDto.EmploymentRoleId = 4;
                model.employeeBasicDto.isUser = true;
                var isExistdata = await _EmployeeService.EmailisExistorNot(model.employeeBasicDto.Email);
                if (isExistdata.Data)
                {
                    var message = new { Success = isExistdata.Message, IsError = true };
                    return Json(message);
                }
                var EmployeeAdd = await _EmployeeService.EmployeeCreate(model.employeeBasicDto);
                
                //employeeId = EmployeeAdd.Data.Employee_id;
                _sessionManager.SetEmployeeId(EmployeeAdd.Data.Employee_id);
                _sessionManager.SetEmployeeEmail(EmployeeAdd.Data.Email);
                _sessionManager.SetEmployeeMobNo(EmployeeAdd.Data.MobNo);
                ViewBag.Email = EmployeeAdd.Data.Email;
                ViewBag.Mob = EmployeeAdd.Data.MobNo;
                
               
            }
            else if (model.currentTab == 2)
            {
                await _subscriptionPackageService.CreateTransaction(model.SubscriptionId, _sessionManager.GetEmployeeId());
            }
            else
            {
                int num = new Random().Next(1111, 9999);
                _subscriptionPackageService.UpdateTransactionForVerifcationCode(_sessionManager.GetEmployeeId(), num);
                var EmailName = _sessionManager.GetEmoloyeeEmail();
                var MobileNo = _sessionManager.GetEmoloyeeMobNo();
                if (model.VerificationType == "Email")
                {   
                    ViewBag.EmailOrMob = _sessionManager.GetEmoloyeeEmail();
                    CommonMethod.SendVerificationCodeToEmail(EmailName, num);
                }
                else
                {
                    ViewBag.EmailOrMob = _sessionManager.GetEmoloyeeMobNo();
                    CommonMethod.SendVerificationCodeToPhoneNo(MobileNo, num);
                }
            }
            //var data = new { Success = "Data saved successfully" };
            var data = new { UserId = model.employeeBasicDto.UserId, Success = "Data saved successfully" };

            return Json(data);
            //await _authservice.CreateClient(model);
            //var Data = new { Success = "SuccessFully Created" };
            //return Json(Data);
        }
        public IActionResult VerifyCode(int Code)
        {
            long EmpId = _sessionManager.GetEmployeeId();
            var rec = _subscriptionPackageService.GetRecByEmpId(EmpId);
           
            if (rec.CodeForVerification == Code)
            {
                var Match = "Verification Match";
                CommonMethod.EmployeeVerificationEmail(_sessionManager.GetEmoloyeeEmail(), _sessionManager.GetEmployeeId());
                return Json(Match);
            }
            else
            {
                return Json("Don't Match");
            }
        }
        public void NotificationInfo(string connectionId)
        {
            var data = _userService.UpdateConnectionId(connectionId);
        }
        [HttpGet]
        public IActionResult Logout()
        {
            _sessionManager.SessionClear();
            return RedirectToAction("AuthUser","Auth");
        }

       
    }
}