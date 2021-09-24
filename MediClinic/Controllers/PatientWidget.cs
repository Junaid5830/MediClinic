using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs.PatientTreatmentStatusDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Services.Interfaces.AuthInterface;
using MediClinic.Services.Interfaces.EmployeeInterface;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using MediClinic.Services.Interfaces.PatientSettings;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.UserInterface;
using MediClinic.Utility;
using MedliClinic.Utilities.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediClinic.Controllers
{
    public class PatientWidget : Controller
    {
        private readonly IPatientInfoService _patientInfoService;
        private ISessionManager _sessionManager;
        private IUserService _userService;
        private IPatientSettings _patientSettings;
        private ILookupService _lookupService;
        private IEmployeeService _EmployeeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IProviderInfoService _providerInfoService;

        private IAuthService _authService;


        public PatientWidget(IPatientInfoService patientInfoService, ISessionManager sessionManager,
            IAuthService authService, IUserService userService,
            IPatientSettings patientSettings, ILookupService lookupService,
            IEmployeeService employeeService, IWebHostEnvironment webHostEnvironment,
            IProviderInfoService providerInfoService)
        {
            _patientInfoService = patientInfoService;
            _sessionManager = sessionManager;
            _authService = authService;
            _userService = userService;
            _patientSettings = patientSettings;
            _lookupService = lookupService;
            _EmployeeService = employeeService;
            _webHostEnvironment = webHostEnvironment;
            _providerInfoService = providerInfoService;
        }
        public async Task<IActionResult> PatientInfoAdd(int? id)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.patientTreatmentStatuslist = new List<PatientTreatmentStatusBasicDto>();
            ViewBag.RoleId = _sessionManager.GetRoleId();
            ViewBag.PatientId = id;
            //In Case of Edit
            if (!(id is null))
            {
                //if (clickfrom is null)
                //{
                //    ViewBag.clickValue = string.Empty;
                //}
                //else if (clickfrom.Equals("Editicon"))
                //{
                //    ViewBag.clickValue = clickfrom;
                //}


                ViewBag.BtnSubmit = "Save";
                ViewBag.Action = "Update";
                patientViewModel.patientInfoBasicDto = await _patientInfoService.GetPatientDetailInfo((int)id);
                patientViewModel.PatientInfoIdForDisplay = patientViewModel.patientInfoBasicDto.PatientInfoId;
                
                if (!(patientViewModel.patientInfoBasicDto.PatientLanguage is null))
                {
                    patientViewModel.patientInfoBasicDto.PatientLanguages = patientViewModel.patientInfoBasicDto.PatientLanguage.Split(",");
                }
                ViewBag.InfoId = id;
                ViewBag.Password = patientViewModel.patientInfoBasicDto.Password;
              
                
                if (patientViewModel.patientInfoBasicDto.SecondaryAddress1 != null || patientViewModel.patientInfoBasicDto.SecondaryAddress2 != null || patientViewModel.patientInfoBasicDto.SecondaryAddress3 != null)
                {
                    ViewBag.SecondaryAddressContains = true;
                }
                else
                {
                    ViewBag.SecondaryAddressContains = string.Empty;
                }

                patientViewModel.patientCaseTypeBasicDto = _patientInfoService.mappedCaseType(patientViewModel.patientInfoBasicDto.PatientCaseType);
                if (patientViewModel.patientCaseTypeBasicDto != null)
                {
                    ViewBag.CaseType = patientViewModel.patientCaseTypeBasicDto.CaseTypeName;
                }
                patientViewModel.patientClaimInfo = _patientInfoService.mappedClaimInfo(patientViewModel.patientInfoBasicDto.PatientsClaimInfo);

                patientViewModel.patientSecondaryInsurance = _patientInfoService.mappedSecondaryInsurance(patientViewModel.patientInfoBasicDto.SecondaryInsurenceProvider);
                patientViewModel.PatientTertiaryInsuranceBasicDto = _patientInfoService.mappedTertiaryInsurance(patientViewModel.patientInfoBasicDto.TertiaryInsurenceProvider);
                patientViewModel.patientPersonalInjury = _patientInfoService.mappedPersonalInjury(patientViewModel.patientInfoBasicDto.PatientPersonal);
                patientViewModel.patientArbitrationAttorney = _patientInfoService.mappedArbitrationAttorney(patientViewModel.patientInfoBasicDto.PatientArbitrationAttorney);

                patientViewModel.PatientInfoFormRequireSettingsDto = _patientSettings.GetPatientRequireFieldSettingsById();


            }
            // In case of new
            else
            {
                ViewBag.BtnSubmit = "Save";
                ViewBag.IsShowVehicleButton = true;
                ViewBag.Action = "Save";

                //Get Settings For PatientInfo
                //For next ID
                patientViewModel.PatientInfoIdForDisplay = _patientInfoService.GetMaxPatientId();
            }

            // Dropdown Data For All 11 Forms
            var data = await _patientInfoService.GetPatientDropDownData();

            patientViewModel.EmploymentTitleList = data.EmploymentTitleList;
            patientViewModel.EmploymentStatuslist = data.EmploymentStatuslist;
            patientViewModel.ClaimStatusList = data.ClaimStatusList;
            patientViewModel.Nf2list = data.Nf2list;
            patientViewModel.IncidentReportStatusList = data.IncidentReportStatusList;
            patientViewModel.IncidentList = data.IncidentList;
            patientViewModel.prefixs = data.prefixs;
            patientViewModel.suffix = data.suffix;
            patientViewModel.gender = data.gender;
            ViewBag.Gender = data.gender;
            patientViewModel.maritalStatus = data.maritalStatus;
            patientViewModel.RaceEthnicity = data.RaceEthnicity;
            patientViewModel.RelationShip = data.RelationShip;
            patientViewModel.patientTreatmentStatuslist = data.patientTreatmentStatuslist;
            patientViewModel.patientLegalStatusBasicDtoslist = data.patientLegalStatusBasicDtoslist;
           
            
            patientViewModel.PatientSignatureIdTypeList = data.PatientSignatureIdTypeList;
            patientViewModel.patientLanguageList = data.patientLanguageList;

            return View(patientViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PatientInfoAdd(PatientViewModel patientViewModel, string[] language)
        {
            // For Save patient form
            if (patientViewModel.patientInfoBasicDto.PatientInfoId > 0)
            {
                var isExistdata = await _authService.CheckEmailExistOrNot(patientViewModel.patientInfoBasicDto.Email, patientViewModel.patientInfoBasicDto.UserId, patientViewModel.patientInfoBasicDto.UserName);
                if (isExistdata.Data)
                {
                    var message = new { Success = isExistdata.Message, IsError = true };
                    return Json(message);
                }

                //patientViewModel.patientInfoBasicDto.Language = MergeLanguages;
                patientViewModel.patientInfoBasicDto.Password = patientViewModel.patientInfoBasicDto.WPassword;
                    patientViewModel.User.Password = patientViewModel.patientInfoBasicDto.WPassword;
                patientViewModel.User.UserId = patientViewModel.patientInfoBasicDto.UserId;
                patientViewModel.User.Email = patientViewModel.patientInfoBasicDto.Email;
                patientViewModel.User.UserName = patientViewModel.patientInfoBasicDto.UserName;
                patientViewModel.User.RoleTypeId = 1;
                patientViewModel.User.IsActive = true;
                int UserId = (int)patientViewModel.patientInfoBasicDto.UserId;
                var Userdata = _userService.GetUserDetail(UserId);
                var userforce = await _userService.userInfoUpdate(patientViewModel.User);
                var PIupdate = await _patientInfoService.patientInfoUpdate(patientViewModel.patientInfoBasicDto, language);

                //var userUpdate = await _userService.userInfoUpdate(patientViewModel.User);
                var data = new { Success = "Data updated successfully" };
                return RedirectToAction("Authuser", "Auth");
            }
            // Update
            else
            {
                if (patientViewModel.User.UserId == 0)
                {
                    var isExistdata = await _authService.CheckEmailExistOrNot(patientViewModel.patientInfoBasicDto.Email, null, patientViewModel.patientInfoBasicDto.UserName);
                    if (isExistdata.Data)
                    {
                        var message = new { Success = isExistdata.Message, IsError = true };
                        return Json(message);
                    }
                    patientViewModel.User.RoleTypeId = 1;

                    patientViewModel.User.Password = patientViewModel.patientInfoBasicDto.Password;
                    patientViewModel.User.Email = patientViewModel.patientInfoBasicDto.Email;
                    patientViewModel.User.UserName = patientViewModel.patientInfoBasicDto.UserName;

                    var userforce = await _userService.userInfoCreate(patientViewModel.User);
                    patientViewModel.patientInfoBasicDto.UserId = userforce.Data.UserId;

                    _sessionManager.SetPatientUserId(userforce.Data.UserId);
                }
                else
                {
                   
                    patientViewModel.patientInfoBasicDto.UserId = patientViewModel.User.UserId;
                }

                //var MergeLanguages = string.Join(",", language);
                //patientViewModel.patientInfoBasicDto.Language = MergeLanguages;
                var patientAdded = await _patientInfoService.patientInfoCreate(patientViewModel.patientInfoBasicDto, language);
                var patientInfoId = patientAdded.Data.PatientInfoId;
                MedliClinic.Utilities.Utility.CommonMethod.VerificationEmail(patientViewModel.patientInfoBasicDto.Email, patientInfoId);
                var data = new { PatientUserId = patientViewModel.patientInfoBasicDto.UserId, PatientInfoId = patientInfoId, Success = "Data saved successfully" };
                return Json(data);
            }

        }
        public async Task<IActionResult> EmployeeWidget(int? Id)
        {
            EmployeeViewModal employeeViewModal = new EmployeeViewModal();
            if (!(Id is null))
            {
              var rec = await _EmployeeService.EmployeeGetById((int)Id);
                employeeViewModal.employeeBasicDto = rec.Data;
                ViewBag.Password = employeeViewModal.employeeBasicDto.Password;
                ViewBag.RoleId = rec.Data.EmploymentRoleId;
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
        public async Task<IActionResult> EmployeeWidget(EmployeeViewModal employeeViewModal, string profileImage)
        {
            
            if (employeeViewModal.employeeBasicDto.Employee_id > 0)
            {
                if (employeeViewModal.User.UserId == 0)
                {
                    var isExistdata = await _EmployeeService.UserisExistorNot(employeeViewModal.employeeBasicDto.UserName, employeeViewModal.employeeBasicDto.UserId, employeeViewModal.employeeBasicDto.Email);
                    if (isExistdata.Data)
                    {
                        var message = new { Success = isExistdata.Message, IsError = true };
                        return Json(message);
                    }
                    employeeViewModal.User.RoleTypeId = (int)employeeViewModal.employeeBasicDto.EmploymentRoleId;

                    employeeViewModal.User.Password = employeeViewModal.employeeBasicDto.Password;
                    employeeViewModal.User.Email = employeeViewModal.employeeBasicDto.Email;
                    employeeViewModal.User.UserName = employeeViewModal.employeeBasicDto.UserName;
                    
                    if (employeeViewModal.employeeBasicDto.EmploymentRoleId == 4)
                    {
                        employeeViewModal.User.IsActive = false;
                        employeeViewModal.User.IsClient = true;
                    }
                    _sessionManager.SetUserId(Convert.ToInt32(employeeViewModal.employeeBasicDto.createdById));
                    var userforce = await _userService.userInfoCreate(employeeViewModal.User);
                    employeeViewModal.employeeBasicDto.UserId = userforce.Data.UserId;
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

                }
                else
                {
                    employeeViewModal.employeeBasicDto.UserId = employeeViewModal.User.UserId;
                }

               
            }
            if (employeeViewModal.employeeBasicDto.EmploymentRoleId == 2)
            {
                ProviderInfoBasicDto providerInfoBasicDto = new ProviderInfoBasicDto();
                providerInfoBasicDto.FirstName = employeeViewModal.employeeBasicDto.FirstName;
                providerInfoBasicDto.MiddleName = employeeViewModal.employeeBasicDto.MiddleName;
                providerInfoBasicDto.LastName = employeeViewModal.employeeBasicDto.LastName;
                providerInfoBasicDto.AddressLine1 = employeeViewModal.employeeBasicDto.Addressline1;
                providerInfoBasicDto.AddressLine2 = employeeViewModal.employeeBasicDto.Addressline2;
                providerInfoBasicDto.AddressLine3 = employeeViewModal.employeeBasicDto.Addressline3;
                providerInfoBasicDto.Email = employeeViewModal.employeeBasicDto.Email;
                providerInfoBasicDto.Password = employeeViewModal.employeeBasicDto.Password;
                providerInfoBasicDto.Profileimage = employeeViewModal.employeeBasicDto.EmployeeImage;
                providerInfoBasicDto.UserId = (long)employeeViewModal.employeeBasicDto.UserId;
                providerInfoBasicDto.CreatedDate = (DateTime)employeeViewModal.employeeBasicDto.CreatedDate;
                providerInfoBasicDto.City = employeeViewModal.employeeBasicDto.City;
                providerInfoBasicDto.Zip = employeeViewModal.employeeBasicDto.ZipCode;
                providerInfoBasicDto.State = employeeViewModal.employeeBasicDto.State;
                await _providerInfoService.providerInfoCreate(providerInfoBasicDto);
            }

            var update = await _EmployeeService.EmployeeUpdate(employeeViewModal.employeeBasicDto);
            var GenderList = await _lookupService.LookupDtolist("Gender");
            employeeViewModal.gender = GenderList.Data;
            var MaritalStatusList = await _lookupService.LookupDtolist("MaritalStatus");
            employeeViewModal.maritalStatus = MaritalStatusList.Data;
            var RaceList = await _lookupService.LookupDtolist("Race/Ethnicity");
            employeeViewModal.RaceEthnicity = RaceList.Data;

            return RedirectToAction("Authuser", "Auth");
        }
        private string GetFullPath(string filename)
        {
            return this._webHostEnvironment.WebRootPath + "\\images\\" + filename;
        }

        public async  Task<IActionResult> EmployeeProfile(int? Id)
        {
            EmployeeViewModal employeeViewModal = new EmployeeViewModal();
            if (!(Id is null))
            {
                ViewBag.action = "Update";
                var rec = await _EmployeeService.EmployeeGetById((int)Id);
                employeeViewModal.employeeBasicDto = rec.Data;
                ViewBag.Password = employeeViewModal.employeeBasicDto.Password;
                ViewBag.RoleId = rec.Data.EmploymentRoleId;
                 if (employeeViewModal.employeeBasicDto is null)
                {
                    ViewBag.ProviderImage = string.Empty;
                 
                }
                else
                {
                    ViewBag.ProviderImage = employeeViewModal.employeeBasicDto.EmployeeImage;


                }
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
        public async Task<IActionResult> EmployeeProfile(EmployeeViewModal employeeViewModal, string profileImage)
        {

            if (employeeViewModal.employeeBasicDto.Employee_id > 0)
            {

                string previousImage = employeeViewModal.employeeBasicDto.EmployeeImage;
                if (profileImage == "/app-assets/images/user/male-user.png")
                {
                    employeeViewModal.employeeBasicDto.EmployeeImage = null;
                }
                else if (profileImage is null)
                {
                    employeeViewModal.employeeBasicDto.EmployeeImage = previousImage;
                }
                else if (profileImage=="/images/"+employeeViewModal.employeeBasicDto.EmployeeImage)
                {
                    employeeViewModal.employeeBasicDto.EmployeeImage = previousImage;
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


                if (employeeViewModal.employeeBasicDto.EmploymentRoleId == 2)
                {
                    ProviderInfoBasicDto providerInfoBasicDto = new ProviderInfoBasicDto();
                    providerInfoBasicDto.FirstName = employeeViewModal.employeeBasicDto.FirstName;
                    providerInfoBasicDto.MiddleName = employeeViewModal.employeeBasicDto.MiddleName;
                    providerInfoBasicDto.LastName = employeeViewModal.employeeBasicDto.LastName;
                    providerInfoBasicDto.AddressLine1 = employeeViewModal.employeeBasicDto.Addressline1;
                    providerInfoBasicDto.AddressLine2 = employeeViewModal.employeeBasicDto.Addressline2;
                    providerInfoBasicDto.AddressLine3 = employeeViewModal.employeeBasicDto.Addressline3;
                    providerInfoBasicDto.Email = employeeViewModal.employeeBasicDto.Email;
                    providerInfoBasicDto.Password = employeeViewModal.employeeBasicDto.Password;
                    providerInfoBasicDto.Profileimage = employeeViewModal.employeeBasicDto.EmployeeImage;
                    providerInfoBasicDto.UserId = (long)employeeViewModal.employeeBasicDto.UserId;
                    providerInfoBasicDto.CreatedDate = (DateTime)employeeViewModal.employeeBasicDto.CreatedDate;
                    providerInfoBasicDto.City = employeeViewModal.employeeBasicDto.City;
                    providerInfoBasicDto.Zip = employeeViewModal.employeeBasicDto.ZipCode;
                    providerInfoBasicDto.State = employeeViewModal.employeeBasicDto.State;
                    await _providerInfoService.providerInfoCreate(providerInfoBasicDto);
                }

                var data = await _EmployeeService.EmployeeUpdate(employeeViewModal.employeeBasicDto);

                var message = new { Success = data.Status, IsError = false };
                return Json(message);
            }
            var result = new { Success = "Erorr!", IsError = true };
            return Json(result);
        }

    }
}
