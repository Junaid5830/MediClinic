using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MediClinic.Filters;
using MediClinic.Models;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.PatientInfoListDto;
using MediClinic.Models.DTOs.PatientSettingsDto;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Services.Interfaces;
using MediClinic.Services.Interfaces.Assistant;
using MediClinic.Services.Interfaces.ClaimStatusInterface;
using MediClinic.Services.Interfaces.DMEInterface;
using MediClinic.Services.Interfaces.EmployeeInterface;
using MediClinic.Services.Interfaces.IncidentReportStatusInterface;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.Nf2StatusInterface;
using MediClinic.Services.Interfaces.PatientAppointmentInterface;
using MediClinic.Services.Interfaces.PatientIncidentRoleInterface;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using MediClinic.Services.Interfaces.PatientLegalStatusInterface;
using MediClinic.Services.Interfaces.PatientMissingInterface;
using MediClinic.Services.Interfaces.PatientRelationshipInterface;
using MediClinic.Services.Interfaces.PatientSettings;
using MediClinic.Services.Interfaces.PatientTreatmentStatusInterface;
using MediClinic.Services.Interfaces.PatientVitalInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.SubscriptionPackageInterface;
using MediClinic.Services.Interfaces.UserInRolesInterface;
using MediClinic.Services.Interfaces.UserInterface;
using MediClinic.Services.Interfaces.UserRolePageInterface;
using MedliClinic.Utilities.Utility.Enum;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediClinic.Controllers
{
    //[AuthFilter(RoleNames.Doctor, RoleNames.Patient, RoleNames.Admin)]

    public class SettingsEliteController : Controller
    {
        private readonly ILogger<SettingsEliteController> _logger;
        private IPatientTreatmentStatusService _patientTreatmentStatus;
        private IPatientLegalStatusService _patientLegalStatusService;
        private INf2StatusService _nf2StatusService;
        private IPatientRelationshipService _patientRelationshipService;
        private ISessionManager _sessionManager;
        private IPatientIncidentRoleService _patientIncident;
        private IIncidentReportStatusService _incidentReportStatusService;
        private IClaimStatusService _claimStatusService;
        private IPatientSettings _patientSettings;
        private readonly IPatientInfoService _patientInfoService;
        private IPatientVitalService _patientVitalService;
        private IPatientMissingService _patientMissingService;
        private IProviderSettingsService _providerSettingsService;
        private readonly IUserInRolesService _authUserInRole;
        private readonly IUserRolePageService _userRolePageService;
        private ISubscriptionPackageService _subscriptionPackageService;
        private IEmployeeService _EmployeeService;
        private AssistantViewModel assistantViewModel;
        private IAssistantService _assistantInfoService;
        private ILookupService _lookupService;
        private IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IPatientAppointmentService _patientAppointmentService;
        private readonly IDMESuppliesService _dMESupplies;
        private readonly IDMEService _dmeService;

        public SettingsEliteController(ILogger<SettingsEliteController> logger, IPatientTreatmentStatusService patientTreatmentStatus,
            IPatientLegalStatusService patientLegalStatusService, IPatientRelationshipService patientRelationshipService, INf2StatusService nf2StatusService, IIncidentReportStatusService incidentReportStatusService, IClaimStatusService claimStatusService, IPatientIncidentRoleService patientIncident, ISessionManager sessionManager, IPatientSettings patientSettings, IPatientInfoService patientInfoService
            , IPatientVitalService patientVitalService, IPatientMissingService patientMissingService, IProviderSettingsService providerSettingsService,
                        IUserInRolesService authUserInRole, IUserRolePageService userRolePageService,
                        ISubscriptionPackageService subscriptionPackageService, IEmployeeService employeeService,
                        IAssistantService assistantService, ILookupService lookupService, IUserService userService,
                        IWebHostEnvironment webHostEnvironment, IPatientAppointmentService patientAppointmentService,
                        IDMESuppliesService dMESupplies,
                        IDMEService dMEService

            )
        {
            _logger = logger;
            _incidentReportStatusService = incidentReportStatusService;
            _patientIncident = patientIncident;
            _claimStatusService = claimStatusService;
            _patientTreatmentStatus = patientTreatmentStatus;
            _patientLegalStatusService = patientLegalStatusService;
            _nf2StatusService = nf2StatusService;
            _patientRelationshipService = patientRelationshipService;
            _sessionManager = sessionManager;
            _patientSettings = patientSettings;
            _patientInfoService = patientInfoService;
            _patientVitalService = patientVitalService;
            _patientMissingService = patientMissingService;
            _providerSettingsService = providerSettingsService;
            _authUserInRole = authUserInRole;
            _userRolePageService = userRolePageService;
            _subscriptionPackageService = subscriptionPackageService;
            _EmployeeService = employeeService;
            assistantViewModel = new AssistantViewModel();
            _assistantInfoService = assistantService;
            _lookupService = lookupService;
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
            _dMESupplies = dMESupplies;
            _patientAppointmentService = patientAppointmentService;
            _dmeService = dMEService;
        }

        public IActionResult Setting(int? Id)
        {
            return View();
        }
        public IActionResult SettingPatient(long Id)
        {
            SettingViewModel model = new SettingViewModel();
            var userId = (long?)_sessionManager.GetUserId();

            if (!(userId is null))
            {
                model.PatientSettingDto = _patientSettings.getPatientSettingsById((int)userId);
                model.PatientPrintSettingDto = _patientSettings.getPatientPrintSettingsById((int)userId);
                model.PatientListSettingDto = _patientSettings.getPatientListSettingsById((int)userId);
                model.PatientRequireFieldSettingDto = _patientSettings.GetPatientRequireFieldSettingsById();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult PatientSummarySetting(PatientSettingDto settingValues)
        {
            var userId = (long?)_sessionManager.GetUserId();
            settingValues.UserId = userId.Value;
            var result = _patientSettings.SavePatientSummaryDisplaySettings(settingValues);
            return Json(result);
        }
        [HttpPost]
        public IActionResult PatientPrintSetting(PatientPrintSettingDto settingValues)
        {
            var userId = (long?)_sessionManager.GetUserId();
            settingValues.UserId = userId.Value;
            var result = _patientSettings.SavePatientPrintSettings(settingValues);
            return Json(result);
        }
        [HttpGet]
        public IActionResult PatientListSetting()
        {
            SettingViewModel model = new SettingViewModel();
            var userId = (long?)_sessionManager.GetUserId();
            if (!(userId is null))
            {
                model.PatientListSettingDto = _patientSettings.getPatientListSettingsById((int)userId);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult PatientListSetting(PatientListSettingDto settingValues)
        {
            var userId = (long?)_sessionManager.GetUserId();
            settingValues.UserId = userId.Value;
            var result = _patientSettings.SavePatientListDispalySettings(settingValues);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> PrintPreview(PatientViewModel printValues)
        {
            PatientViewModel patientViewModel = new PatientViewModel();

            var patientInfos = await _patientInfoService.GetPatientSummaryDetails(printValues.PatientPrintSettingDto.PatientId.Value);
            if (patientInfos.DateOfBirth != null)
            {
                var result = DateTime.Parse(patientInfos.DateOfBirth.ToString(), new CultureInfo("en-US")).Year;
                var age = DateTime.Today.Year - result;
                patientInfos.Age = age;
            }

            //IF relatedPatientList checkbox is checked
            if (printValues.PatientPrintSettingDto.RelatedPatientList)
            {
                patientViewModel.patientListWithUsers = await _patientInfoService.GetRelevantPatientDetails(patientInfos.HomePhone, patientInfos.AddressLine1, patientInfos.EmergencyMobileNumber, patientInfos.EmergencyPerson, patientInfos.AdjusterName);
                if (patientViewModel.patientListWithUsers != null)
                {
                    foreach (var item in patientViewModel.patientListWithUsers)
                    {
                        var result = DateTime.Parse(item.DateOfBirth.ToString(), new CultureInfo("en-US")).Year;
                        var age = DateTime.Today.Year - result;
                        item.Age = age;
                    }
                }
            }
            else
            {
                patientViewModel.patientListWithUsers = new List<PatientInfoListDto>();
            }

            //IF vitals or body status checkBoxes are checked
            if (printValues.PatientPrintSettingDto.BodyStatus)
            {
                patientViewModel.VitalDto = _patientVitalService.GetVitalSummaryByPatientInfoId(printValues.PatientPrintSettingDto.PatientId.Value);
            }
            else
            {
                patientViewModel.VitalDto = new Models.DTOs.VitalBasicDto.VitalDto();
            }

            //IF patient remainders checkBoxe is checked
            if (printValues.PatientPrintSettingDto.Reminder)
            {
                patientViewModel.PatientMissingsListDto = await _patientMissingService.GetPatientInfoMissingFieldsByPatientId(printValues.PatientPrintSettingDto.PatientId.Value);
            }

            patientViewModel.PatientPrintSettingDto = printValues.PatientPrintSettingDto;


            patientViewModel.patientCompleteInfo = patientInfos;
            return View(patientViewModel);
        }
        #region Provider Settings
        public IActionResult ProviderSettings(long Id)
        {
            SettingViewModel model = new SettingViewModel();
            var userId = (long?)_sessionManager.GetUserId();

            if (!(userId is null))
            {
                //model.PatientSettingDto = _patientSettings.getPatientSettingsById((int)userId);
                //model.PatientPrintSettingDto = _patientSettings.getPatientPrintSettingsById((int)userId);
                model.ProviderListSettingDto = _providerSettingsService.getProviderListSettingsById((int)userId);
                //model.PatientRequireFieldSettingDto = _patientSettings.GetPatientRequireFieldSettingsById();
            }
            return View(model);
        }


        [HttpPost]
        public IActionResult SaveProviderListSettings(ProviderListSettingDto settingValues)
        {
            var userId = (long?)_sessionManager.GetUserId();
            settingValues.UserId = userId.Value;
            var result = _providerSettingsService.SaveProviderListSettings(settingValues);
            return Json(result);
        }


        public async Task<IActionResult> ProviderSessionSettings()
        {
            ProviderSessionTypeDto sessionTypeDto = new ProviderSessionTypeDto();
            sessionTypeDto.providerSessionTypeList = await _providerSettingsService.GetAllSessionSettings();
            return View(sessionTypeDto);
        }

        public IActionResult SaveProviderSessionSettings(ProviderSessionTypeDto dto)
        {
            var userId = _sessionManager.GetUserId();

            return Json(_providerSettingsService.AddProviderSessionSettings(dto, userId));
        }

        public async Task<IActionResult> GetProviderSessionSettings()
        {
            return Json(await _providerSettingsService.GetAllSessionSettings());
        }

        public async Task<IActionResult> DeleteSessionSettings(long providerSessionId)
        {
            return Json(await _providerSettingsService.DeleteSessionSettings(providerSessionId));
        }
        #endregion

        #region Role
        public async Task<IActionResult> Role(int? Id)
        {
            var model = new AuthUserDto();


            var list = await _authUserInRole.authUserRole();
            var PageList = await _userRolePageService.PagesList();
            model.UserRolePagesList = PageList;
            model.UserRoleTypes = list.Data;
            //if (model.UserRoleTypes.Count > 0)
            //{
            //    var removeItem = model.UserRoleTypes.Single(r => r.UserRoleId == 5);
            //    model.UserRoleTypes.Remove(removeItem);
            //}
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Role(AuthUserDto userInRolesBasicDto)
        {


            if (userInRolesBasicDto.UserRoleTypesDto.UserRoleId > 0)
            {
                await _authUserInRole.Update(userInRolesBasicDto.UserRoleTypesDto);
            }
            else
            {
                await _authUserInRole.CreateUserRole(userInRolesBasicDto.UserRoleTypesDto);
            }
            var list = await _authUserInRole.authUserRole();

            userInRolesBasicDto.UserRoleTypes = list.Data;
            var data = new { Success = "Data saved successfully" };
            return Json(data);

        }
        public async Task<IActionResult> GetRoleRecordById(int Id)
        {
            var Rec = await _authUserInRole.UserRoleGetById(Id);
            return Json(Rec);
        }
        public IActionResult GetRoleRecordDelete(int Id)
        {
            var RoleId = _authUserInRole.UserInRolesDelete(Id);
            //return RedirectToAction("PatientList", "PatientSide");
            return Json(RoleId);
        }
        public async Task<IActionResult> GetAllRoleList()
        {
            var model = new AuthUserDto();


            var list = await _authUserInRole.authUserRole();

            model.UserRoleTypes = list.Data;
            return PartialView("~/Views/SettingsElite/_PartialSetting/_RoleList.cshtml", model);

        }

        #endregion Role

        #region Role Module
        public async Task<IActionResult> Module(int? Id)
        {
            var model = new AuthUserDto();
            var Rolelist = await _authUserInRole.authUserRole();

            model.UserRoleTypes = Rolelist.Data;
            //if (model.UserRoleTypes.Count > 0)
            //{
            //    var removeItem = model.UserRoleTypes.Single(r => r.UserRoleId == 5);
            //    model.UserRoleTypes.Remove(removeItem);
            //}
            var list = await _userRolePageService.PagesList();
            model.UserRolePagesList = list;
            return View(model);
        }
        public async Task<IActionResult> PageListForPageActive(int Id)
        {
            var model = new AuthUserDto();
            if (Id > 0)
            {
                _userRolePageService.PageActive(Id);
            }
            var Rolelist = await _authUserInRole.authUserRole();

            model.UserRoleTypes = Rolelist.Data;
            var list = await _userRolePageService.PagesList();
            model.UserRolePagesList = list;
            return PartialView("~/Views/SettingsElite/_PartialSetting/_AllPagesList.cshtml", model);

        }
        public async Task<IActionResult> PageListForPageInActive(int Id)
        {
            var model = new AuthUserDto();
            if (Id > 0)
            {
                _userRolePageService.PageInActive(Id);
            }
            var Rolelist = await _authUserInRole.authUserRole();

            model.UserRoleTypes = Rolelist.Data;
            var list = await _userRolePageService.PagesList();
            model.UserRolePagesList = list;
            return PartialView("~/Views/SettingsElite/_PartialSetting/_AllPagesList.cshtml", model);

        }

        public async Task<IActionResult> GetUserRolePagesList(int? Id)
        {
            var model = new AuthUserDto();
         
            var list = await _userRolePageService.pageListOnUserRoleId((int)Id);
            model.UserRolePagesList = list;
            return PartialView("~/Views/SettingsElite/_PartialSetting/_UserRolePageList.cshtml", model);

        }
        public async Task<IActionResult> UserRolePageAdd(int PageId, int RoleId)
        {
            var model = new AuthUserDto();
            if (PageId > 0 && RoleId > 0)
            {
                _userRolePageService.AdduserRolePage(PageId, RoleId);
            }
            var Rolelist = await _authUserInRole.authUserRole();

            model.UserRoleTypes = Rolelist.Data;
            var list = await _userRolePageService.pageListOnUserRoleId(RoleId);
            model.UserRolePagesList = list;
            return PartialView("~/Views/SettingsElite/_PartialSetting/_UserRolePageList.cshtml", model);
        }
        [HttpGet]
        public async Task<IActionResult> UserRolePageDelete(int PageId, int RoleId)
        {
            var model = new AuthUserDto();
            if (PageId > 0 && RoleId > 0)
            {
                _userRolePageService.DeleteuserRolePage(PageId, RoleId);
            }
            var Rolelist = await _authUserInRole.authUserRole();

            model.UserRoleTypes = Rolelist.Data;
            var list = await _userRolePageService.pageListOnUserRoleId(RoleId);
            model.UserRolePagesList = list;
            return PartialView("~/Views/SettingsElite/_PartialSetting/_UserRolePageList.cshtml", model);
        }
        #endregion  Role Module

        #region SubscriptionPackages
        public async Task<IActionResult> SubscriptionPackage(int? Id)
        {
            PackageViewModel package = new PackageViewModel();
            var list = await _subscriptionPackageService.SubscriptionPackageList();

            package.subsriptionPackagesList = list.Data;
            return View(package);
        }
        [HttpPost]
        public async Task<IActionResult> SubscriptionPackage(PackageViewModel packageViewModel)
        {
            var rec = await _subscriptionPackageService.CreateSubScription(packageViewModel.subsriptionPackageDto);
            var data = new { Success = "Data saved successfully" };
            return Json(data);
        }

        public async Task<IActionResult> GetPackageList()
        {
            var model = new PackageViewModel();


            var list = await _subscriptionPackageService.SubscriptionPackageList();

            model.subsriptionPackagesList = list.Data;
            return PartialView("~/Views/SettingsElite/_PartialSetting/_SubscriptionPackageList.cshtml", model);
        }
        #endregion SubscriptionPackages

        #region User client
        public IActionResult UserClient(int? Id)
        {
            EmployeeViewModal employeeViewModal = new EmployeeViewModal();
            employeeViewModal.EmployeesList = _EmployeeService.EmployeeClientList();
            return View(employeeViewModal);
        }
        public IActionResult ClientActive(int Id)
        {
            var rec = _EmployeeService.ClientActive(Id);
            return Json(rec);
        }
        public IActionResult ClientInActive(int Id)
        {
            var rec = _EmployeeService.ClientInActive(Id);
            return Json(rec);
        }
        #endregion

        #region Calendar Setting
        public IActionResult CalendarSetting()
        {
            SettingViewModel settingViewModel = new SettingViewModel();
            settingViewModel.calendarSettingDto = _patientAppointmentService.GetCalendarViewSet();
            return View(settingViewModel);
        }
        [HttpPost]
        public IActionResult calendarSetting(CalendarSettingDto calendarSettingDto)
        {
            var result = _patientAppointmentService.SaveCalendarViewSetting(calendarSettingDto);
            return Json(result);
        }
        #endregion

        #region Assistant Setting
        public async Task<IActionResult> AssistantListSetting()
        {
            assistantViewModel = new AssistantViewModel();
            assistantViewModel.AssistantList = await _assistantInfoService.AssistantInfoList(null);
            return View(assistantViewModel);
        }
        public async Task<IActionResult> AssistanSettingAdd(int? assistantid)
        {
            assistantViewModel = new AssistantViewModel();
            var specialityList = _lookupService.lookupByTypeBasicDto("ProviderSpeciality");
            assistantViewModel.AssistantSpeciality = specialityList.Data;
            var infoTitleList = _lookupService.lookupByTypeBasicDto("ProviderTitle");
            assistantViewModel.AssistantTitleList = infoTitleList.Data;
            var infoSuffixList = _lookupService.lookupByTypeBasicDto("ProviderSuffix");
            assistantViewModel.AssistantSuffixList = infoSuffixList.Data;
            var infoRentTypeList = _lookupService.lookupByTypeBasicDto("ProviderRentType");
            assistantViewModel.AssistantRentTypeList = infoRentTypeList.Data;
            var infoScannedDocumentList = _lookupService.lookupByTypeBasicDto("ScannedDocument");
            assistantViewModel.AssistantScannedDocumentsList = infoScannedDocumentList.Data;
            var infoStatusList = _lookupService.lookupByTypeBasicDto("ProviderStatus");
            assistantViewModel.AssistantStatuslist = infoStatusList.Data;
            assistantViewModel.User = new UsersBasicDto();
            assistantViewModel.assistantSettingDto = new AssistantSettingDto();
            if (assistantid != null)
            {
                ViewBag.action = "Update";
                var assistantinfo = await _assistantInfoService.SettingAssistantInfoGetId((int)assistantid);
                var userInfo = await _userService.userInfoGetId(assistantinfo.Data.UserID);
                assistantViewModel.assistantSettingDto = assistantinfo.Data;
                assistantViewModel.User = userInfo.Data;
                if (assistantViewModel.assistantSettingDto is null)
                {
                    ViewBag.AssistantImage = string.Empty;
                    ViewBag.AssistantSignatureImage = string.Empty;
                    ViewBag.WriteSignature = string.Empty;
                }
                else
                {
                    ViewBag.AssistantImage = assistantViewModel.assistantSettingDto.ReminderBy;
                    ViewBag.AssistantSignatureImage = assistantViewModel.assistantSettingDto.SignImage;
                    ViewBag.WriteSignature = assistantViewModel.assistantSettingDto.WriteSignature;
                    TempData["ProfileImage"] = assistantViewModel.assistantSettingDto.ReminderBy;
                }

                ViewBag.BtnSubmit = "Update";
                ViewBag.ViewHeader = "Update Assistant";
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                ViewBag.ViewHeader = "Add Assistant";

            }
            return View(assistantViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AssistanSettingAdd(AssistantViewModel assistantViewModel, string Signature, string profileImage)
        {
            if (assistantViewModel.assistantSettingDto.AssistantInfoID > 0)
            {
                var isExistdata = await _assistantInfoService.CheckEmailExistOrNot(assistantViewModel.Assistant.Email, assistantViewModel.Assistant.UserID);
                if (isExistdata.Data)
                {
                    var message = new { Success = isExistdata.Message, IsError = true };
                    return Json(message);
                }
                var UpdateProfile = TempData["ProfileImage"];
                if (profileImage == "/images/" + UpdateProfile)
                {
                    assistantViewModel.assistantSettingDto.ReminderBy = assistantViewModel.assistantSettingDto.Remindimage;
                }
                else if (profileImage == "/app-assets/images/user/male-user.png")
                {
                    assistantViewModel.assistantSettingDto.ReminderBy = null;
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
                    assistantViewModel.assistantSettingDto.ReminderBy = ProfileImageFile;
                    pic_memStream.Close();
                }

                if (Signature is null)
                {
                    assistantViewModel.assistantSettingDto.WriteSignature = assistantViewModel.assistantSettingDto.HiddenWriteSignImage;
                }
                else
                {
                    string xs = "data:image/png;base64,";
                    Signature = Signature.Replace(xs, "");
                    byte[] bytess = Convert.FromBase64String(Signature);
                    Image images;
                    using (MemoryStream ms = new MemoryStream(bytess))
                    {
                        images = Image.FromStream(ms);
                    }
                    MemoryStream memStreams = new MemoryStream();
                    images.Save(memStreams, ImageFormat.Png);
                    memStreams.Seek(0, SeekOrigin.Begin);
                    var Signfilenames = DateTime.UtcNow.ToString("ddMMyyyyhhmmss");
                    Signfilenames = System.IO.Path.GetFileName(Signfilenames) + ".png";
                    var SignfilePaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\SignatureImages", Signfilenames);
                    using (var fileSteam = new FileStream(SignfilePaths, FileMode.Create))
                    {
                        await memStreams.CopyToAsync(fileSteam);
                    }
                    assistantViewModel.assistantSettingDto.WriteSignature = Signfilenames;
                    memStreams.Close();
                }

                var files = Request.Form.Files;
                if (files.Count > 0)
                {
                    string filename = "";
                    string Signfile = "";
                    string patientfile = "";
                    foreach (IFormFile source in files)
                    {
                        var ControlName = source.Name;
                        filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');
                        filename = DateTime.UtcNow.ToString("ddMMyyyyhhmmss") + "_" + System.IO.Path.GetFileName(filename);
                        string extension = System.IO.Path.GetExtension(filename);

                        using (FileStream output = System.IO.File.Create(this.GetFullPath(filename)))
                            await source.CopyToAsync(output);
                        if (ControlName == "Assistant.SignImage")
                        {
                            Signfile = filename;
                            if (assistantViewModel.assistantSettingDto.SignImage is null)
                            {
                                assistantViewModel.assistantSettingDto.ReminderBy = assistantViewModel.assistantSettingDto.Remindimage;
                            }
                        }
                        if (ControlName == "Assistant.ReminderBy")
                        {
                            patientfile = filename;
                            if (assistantViewModel.assistantSettingDto.ReminderBy is null)
                            {
                                assistantViewModel.assistantSettingDto.SignImage = assistantViewModel.assistantSettingDto.Signatureimage;
                            }
                        }
                    };
                    if (!string.IsNullOrEmpty(patientfile))
                    {
                        assistantViewModel.assistantSettingDto.ReminderBy = patientfile;
                    }
                    if (!string.IsNullOrEmpty(Signfile))
                    {
                        assistantViewModel.assistantSettingDto.SignImage = Signfile;
                    }
                }
                else if (files.Count == 0)
                {
                    assistantViewModel.assistantSettingDto.SignImage = assistantViewModel.assistantSettingDto.Signatureimage;
                }
                assistantViewModel.User.UserId = assistantViewModel.assistantSettingDto.UserID;
                assistantViewModel.User.Email = assistantViewModel.assistantSettingDto.Email;
                assistantViewModel.User.Password = assistantViewModel.Password;
                assistantViewModel.assistantSettingDto.ModifiedBy = Convert.ToInt32(_sessionManager.GetUserId());
                assistantViewModel.assistantSettingDto.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                assistantViewModel.assistantSettingDto.isFromSetting = true;
                var PIupdate = await _assistantInfoService.assistantInfoUpdate(assistantViewModel.Assistant);
                var data = new { Success = "Data updated successfully" };
                return RedirectToAction("AssistantListSetting","SettingsElites");
            }
            else
            {
                if (assistantViewModel.User.UserId == 0)
                {
                    var isExistdata = await _assistantInfoService.CheckEmailExistOrNot(assistantViewModel.Assistant.Email, null);
                    if (isExistdata.Data)
                    {
                        var message = new { Success = isExistdata.Message, IsError = true };
                        return Json(message);
                    }
                    assistantViewModel.User.RoleTypeId = 13;

                    assistantViewModel.User.Password = assistantViewModel.assistantSettingDto.Password;
                    assistantViewModel.User.Email = assistantViewModel.assistantSettingDto.Email;
                    assistantViewModel.User.UserName = assistantViewModel.assistantSettingDto.UserName;

                    var userforce = await _userService.userInfoCreate(assistantViewModel.User);
                    assistantViewModel.assistantSettingDto.UserID = userforce.Data.UserId;
                }
                else
                {
                    assistantViewModel.assistantSettingDto.UserID = assistantViewModel.User.UserId;
                }
                if (profileImage == "/app-assets/images/user/male-user.png")
                {
                    assistantViewModel.Assistant.ReminderBy = null;
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
                    assistantViewModel.assistantSettingDto.ReminderBy = ProfileImageFile;
                    pic_memStream.Close();
                }

                if (Signature is null)
                {

                    var Signfilenames = "Empty.png";

                    assistantViewModel.assistantSettingDto.WriteSignature = Signfilenames;

                }
                else
                {
                    string x = "data:image/png;base64,";
                    Signature = Signature.Replace(x, "");
                    byte[] bytes = Convert.FromBase64String(Signature);
                    Image image;
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        image = Image.FromStream(ms);
                    }

                    MemoryStream memStream = new MemoryStream();
                    image.Save(memStream, ImageFormat.Png);
                    memStream.Seek(0, SeekOrigin.Begin);
                    var Signfilename = DateTime.UtcNow.ToString("ddMMyyyyhhmmss");
                    Signfilename = System.IO.Path.GetFileName(Signfilename) + ".png";
                    var SignfilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\SignatureImages", Signfilename);

                    using (var fileSteam = new FileStream(SignfilePath, FileMode.Create))
                    {
                        await memStream.CopyToAsync(fileSteam);


                    }
                    assistantViewModel.assistantSettingDto.WriteSignature = Signfilename;
                    memStream.Close();
                }



                var files = Request.Form.Files;
                if (files.Count > 0)
                {
                    string filename = "";
                    string Signfile = "";
                    string patientfile = "";
                    foreach (IFormFile source in files)
                    {
                        var ControlName = source.Name;
                        filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');
                        filename = DateTime.UtcNow.ToString("ddMMyyyyhhmmss") + "_" + System.IO.Path.GetFileName(filename);
                        string extension = System.IO.Path.GetExtension(filename);

                        using (FileStream output = System.IO.File.Create(this.GetFullPath(filename)))
                            await source.CopyToAsync(output);
                        if (ControlName == "Assistant.SignImage")
                        {
                            Signfile = filename;
                        }
                        if (ControlName == "Assistant.ReminderBy")
                        {
                            patientfile = filename;
                        }
                    };
                    if (!string.IsNullOrEmpty(patientfile))
                    {

                        assistantViewModel.assistantSettingDto.ReminderBy = patientfile;

                    }

                    if (!string.IsNullOrEmpty(Signfile))
                    {

                        assistantViewModel.assistantSettingDto.SignImage = Signfile;

                    }

                }
                assistantViewModel.User = new UsersBasicDto();

                assistantViewModel.assistantSettingDto.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                assistantViewModel.assistantSettingDto.ModifiedBy = Convert.ToInt32(_sessionManager.GetUserId());
                assistantViewModel.assistantSettingDto.isFromSetting = true;
                var add = await _assistantInfoService.SettingassistantInfoAdd(assistantViewModel.assistantSettingDto);
                ViewBag.BtnSubmit = "Save";
                var data = new {Success = "Data saved successfully",IsError = true };

                return Json(data);
            }
        }
        private string GetFullPath(string filename)
        {
            return this._webHostEnvironment.WebRootPath + "\\images\\" + filename;
        }

        #endregion


        #region Attorney
        public IActionResult AttorneySettingList()
        {
            return View();
        }
        public IActionResult AttorneySettingAdd()
        {
            return View();
        }
        #endregion

        #region Billing
        public IActionResult Billing()
        {
            return View();
        }
        public IActionResult CompanyBilling()
        {
            return View();
        } 
        public IActionResult AddCompanyBilling()
        {
            return View();
        }
        public IActionResult AddUserBilling()
        {
            return View();
        }
        #endregion


        
        #region DME
        public async Task<IActionResult> DMESetting()
        {
            var dMEViewModel = new DmeInvetoryViewModel();
            var roleId = _sessionManager.GetRoleId();
            var userId = _sessionManager.GetUserId();
            if (roleId == 5)
            {
                var DmeManufacturesList = await _dmeService.GetListManufactures();
                var MakeNameModelList = await _dmeService.GetListMakeNameModel();
                var DmeInventoryList = await _dmeService.GetListDmeInventory();
                dMEViewModel.DmeInventoryList = DmeInventoryList.Data;
                dMEViewModel.DmeManufacturesList = DmeManufacturesList.Data;
                dMEViewModel.MakeNameModelList = MakeNameModelList.Data;
                var GroupItemList = await _dmeService.GroupList();
                dMEViewModel.dMEGroupitemList = GroupItemList.Data;
            }
            else
            {
                var DmeManufacturesList = await _dmeService.GetListManufactures(userId);
                var MakeNameModelList = await _dmeService.GetListMakeNameModel(userId);
                var DmeInventoryList = await _dmeService.GetListDmeInventory(userId);
                dMEViewModel.DmeInventoryList = DmeInventoryList.Data;
                dMEViewModel.DmeManufacturesList = DmeManufacturesList.Data;
                dMEViewModel.MakeNameModelList = MakeNameModelList.Data;
                var GroupItemList = await _dmeService.GroupList(userId);
                dMEViewModel.dMEGroupitemList = GroupItemList.Data;
            }
             
            
            return View(dMEViewModel);
        }

        public async Task<IActionResult> CPTHSPCCodes()
        {
            var dMEViewModel = new DmeInvetoryViewModel();
            var GroupItemList = await _dmeService.GroupList();
            dMEViewModel.dMEGroupitemList = GroupItemList.Data;

            return View(dMEViewModel);
           
        }

        public async Task<IActionResult> Inventory()
        {
            var dMEViewModel = new DmeInvetoryViewModel();
           
            var DmeInventoryList = await _dmeService.GetListDmeInventory();
            dMEViewModel.DmeInventoryList = DmeInventoryList.Data;
           
            return View(dMEViewModel);
        }
        public async Task<IActionResult> AddInventory(int? Id)
        {
            var dMEViewModel = new DmeInvetoryViewModel();
            if (!(Id is null))
            {
                var response = await _dmeService.GetByIdDmeInventory((int)Id);
                dMEViewModel.DmeInventory = response.Data;
            }
            var roleId = _sessionManager.GetRoleId();
            var userId = _sessionManager.GetUserId();
            if (!(Id is null))
            {
                var response = await _dmeService.GetByIdDmeInventory((int)Id);
                dMEViewModel.DmeInventory = response.Data;
            }

            if (roleId == 5)
            {
                dMEViewModel.SelectListItemForManufacture = _dmeService.SelectListForManufacture(null);
                dMEViewModel.SelectListItemsForMakeNameModel = _dmeService.SelectListForMakeNameModel(null);
                
            }
            else
            {
                dMEViewModel.SelectListItemForManufacture = _dmeService.SelectListForManufacture(userId);
                dMEViewModel.SelectListItemsForMakeNameModel = _dmeService.SelectListForMakeNameModel(userId);
              
            }
            
            return View(dMEViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddInventory(DmeInvetoryViewModel dmeInvetoryViewModel)
        {
            var response = await _dmeService.AddUpdateDmeInventory(dmeInvetoryViewModel.DmeInventory);
            var data = new { Data = response.Data, Message = "Successfully Created" };
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInventory(int Id)
        {
            var Message = "";
            var result = await _dmeService.DeleteDmeInventory(Id);
            if (result.Data)
            {
                Message = "Deleted Succefully";
            }
            else
            {
                Message = "There is some error";
            }
            var data = new { Result = result.Data, Message = Message };
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> GetModelByMakeNameValue(int Id)
        {
            var response = await _dmeService.GetByIdMakeNameModel(Id);
            var data = new { Model = response.Data.Model };
            return Json(data);
        }


        public async Task<IActionResult> AddManufacturer(int? Id)
        {

            var dMEViewModel = new DmeInvetoryViewModel();
            if (!(Id is null))
            {
                var response = await _dmeService.GetByIdManufacture((int)Id);
                dMEViewModel.SuppliesManufacture = response.Data;
            }

            return View(dMEViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddManufacturer(DmeInvetoryViewModel dMEViewModal)
        {
            var IsExist = await _dmeService.IsExist(dMEViewModal.SuppliesManufacture.Manufactures);
            if (IsExist.Data)
            {
                var error = new { IsErorr = true };
                return Json(error);
            }
            if (dMEViewModal.SuppliesManufacture.Id > 0)
            {
                dMEViewModal.SuppliesManufacture.ModifiedBy = _sessionManager.GetUserId();
                dMEViewModal.SuppliesManufacture.ModifiedDate = DateTime.UtcNow;
            }
            else
            {
                dMEViewModal.SuppliesManufacture.CreatedBy = _sessionManager.GetUserId();
                dMEViewModal.SuppliesManufacture.CreatedDate = DateTime.UtcNow;
            }
            var response = await _dmeService.AddUpdateManufacture(dMEViewModal.SuppliesManufacture);
            var data = new { Data = response.Data, Message = "Successfully Created" };
            return Json(data);
           
        }
        [HttpPost]
        public async Task<IActionResult> DeleteManufacturer(int Id)
        {
            var Message = "";
            var result = await _dmeService.DeleteManufacture(Id);
            if (result.Data)
            {
                Message = "Deleted Succefully";
            }
            else
            {
                Message = "There is some error";
            }
            var data = new { Result = result.Data, Message = Message };
            return Json(data);
        }
        public async Task<IActionResult> AddMakeName(int? Id)
        {
            var dMEViewModel = new DmeInvetoryViewModel();
            if(!(Id is null))
            {
                var response = await _dmeService.GetByIdMakeNameModel((int)Id);
                dMEViewModel.MakeNameModel = response.Data;
            }

            return View(dMEViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddMakeName(DmeInvetoryViewModel dMEViewModal)
        {
            if (dMEViewModal.MakeNameModel.Id > 0)
            {
                dMEViewModal.MakeNameModel.ModifiedBy = _sessionManager.GetUserId();
                dMEViewModal.MakeNameModel.ModifiedDate = DateTime.UtcNow;
            }
            else
            {
                dMEViewModal.MakeNameModel.CreatedBy = _sessionManager.GetUserId();
                dMEViewModal.MakeNameModel.CreatedDate = DateTime.UtcNow;
            }
            var response = await _dmeService.AddUpdateMakeNameModel(dMEViewModal.MakeNameModel);
            var data = new { Data = response.Data, Message = "Successfully Created" };
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMakeName(int Id)
        {
            var Message = "";
            var result = await _dmeService.DeleteMakeNameModel(Id);
            if (result.Data)
            {
                Message = "Deleted Succefully";
            }
            else
            {
                Message = "There is some error";
            }
            var data = new { Result = result.Data, Message =Message};
            return Json(data);
        }
        public IActionResult AddGroup()
        {
            return View();
        }
        #endregion


        #region ICD Setting
        public async Task<IActionResult> ICDList()
        {
            var result = await _dMESupplies.GetAllICDCodes(false);
            return View(result);
        }
        #endregion

    }
}