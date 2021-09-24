using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs.LookupDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MedliClinic.Utilities.Utility;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces.ProviderSpecialityInterface;
using MediClinic.Services.Interfaces.ProviderTemplateInterface;
using MediClinic.Services.Interfaces.ProviderTermInterface;
using MediClinic.Services.Interfaces.ProviderUidTypeInterface;
using MediClinic.Services.Interfaces.RelatedFacilityInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.SubProviderInterface;
using MediClinic.Services.Interfaces.UserInterface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Drawing;
using MediClinic.Filters;
using MedliClinic.Utilities.Utility.Enum;
using MediClinic.Services.Interfaces.Doctor;
using MediClinic.Models.DTOs.TemplateDto;
using MediClinic.Services.Interfaces.PrescriptionTemplateService;
using MediClinic.Services.Interfaces.PatientAppointmentInterface;
using System.Globalization;
using MediClinic.Services.Interfaces;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.ClinicalNotesInterface;
using MediClinic.Models.DTOs.DMESuppliesDto;
using MediClinic.Services.Interfaces.DMEInterface;
using MediClinic.Services.Services.DMEService;
using MediClinic.Services.Interfaces.ClaimInterface;
using MediClinic.Services.Interfaces.Patient;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using MediClinic.Services.Interfaces.PatientSettings;

namespace MediClinic.Controllers.Provider
{
    //[AuthFilter(RoleNames.Doctor,RoleNames.Admin)]
    public class ProviderController : Controller
    {
        private readonly ILogger<ProviderController> _logger;
        private IProviderInfoService _providerInfoService;
        private IPatientInfoService _patientInfoService;
        private IProviderTemplateService _providerTemplateService;
        private IRelatedFacilityService _relatedFacilityService;
        private ILookupService _lookupService;
        private IUserService _userService;
        private IProviderSpecialityService _providerSpecialityService;
        private IProviderTermService _providerTermService;
        private IProviderUidTypeService _providerUidTypeService;
        private ISubProviderService _subProviderService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ISessionManager _sessionManager;
        private readonly IDoctorService _doctorService;
        private readonly IMediTemplateService _templateService;
        private readonly IProviderSettingsService _providerSettingsService;
        private IClaimService _claimService;
        private IDMEService _dmeService;
        private IPatientService _patientService;
        private IPatientSettings _patientSettings;

        public ProviderController(ILogger<ProviderController> logger, 
            IProviderInfoService providerInfoService, IPatientInfoService patientInfoService, IProviderTemplateService providerTemplateService, IUserService userService,
            IRelatedFacilityService relatedFacilityService, ILookupService lookupService, IProviderSpecialityService providerSpecialityService,
            IProviderTermService providerTermService, IProviderUidTypeService providerUidTypeService, ISubProviderService subProviderService,
            IWebHostEnvironment webHostEnvironment, ISessionManager sessionManager, IDMEService dmeService,
            IDoctorService doctorService, IClaimService claimService, IMediTemplateService templateService, 
            IPatientAppointmentService patientAppointmentService, IProviderSettingsService providerSettingsService, 
            IPatientService patientService, IPatientSettings patientSettings)
        {
            _logger = logger;
            _patientInfoService = patientInfoService;
            _providerInfoService = providerInfoService;
            _providerTemplateService = providerTemplateService;
            _relatedFacilityService = relatedFacilityService;
            _lookupService = lookupService;
            _userService = userService;
            _providerSpecialityService = providerSpecialityService;
            _providerTermService = providerTermService;
            _providerUidTypeService = providerUidTypeService;
            _subProviderService = subProviderService;
            _webHostEnvironment = webHostEnvironment;
            _sessionManager = sessionManager;
            _doctorService = doctorService;
            _templateService = templateService;
            _providerSettingsService = providerSettingsService;
            _claimService = claimService;
            _dmeService = dmeService;
            _patientService = patientService;
            _patientSettings = patientSettings;
        }
        #region provider info
        public async Task<IActionResult> ProviderInfo(int? providerId)
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            providerViewModel.User = new UsersBasicDto();
            providerViewModel.Provider = new ProviderInfoBasicDto();
            if (providerId != null)
            {
               
                ViewBag.action = "Update";
                var providerInfo = await _providerInfoService.providerInfoGetId((int)providerId);
                var userInfo = await _userService.userInfoGetId(providerInfo.Data.UserId);
                ViewBag.ProviderSessions = await _providerInfoService.GetAllProviderSessions((long)providerId);


                

                providerViewModel.Provider = providerInfo.Data;

                providerViewModel.Provider.ElectronicConfirmPassword = providerViewModel.Provider.ElectronicSignPassword;
                providerViewModel.User = userInfo.Data;
                providerViewModel.Password = providerViewModel.User.Password;
                providerViewModel.ConfirmPassword = providerViewModel.User.Password;
                ViewBag.Password = providerInfo.Data.Password;
                ViewBag.EPassword = providerInfo.Data.ElectronicConfirmPassword;
                providerViewModel.Provider.ElectronicConfirmPassword = providerViewModel.Provider.ElectronicSignPassword;
                if (providerViewModel.Provider is null)
                {
                    ViewBag.ProviderImage = string.Empty;
                    ViewBag.ProviderSignatureImage = string.Empty;
                    ViewBag.WriteSignature = string.Empty;
                }
                else
                {
                    ViewBag.ProviderImage = providerViewModel.Provider.ProviderProfilePic;
                    TempData["ProfileImage"] = providerViewModel.Provider.ProviderProfilePic;
                    ViewBag.ProviderSignatureImage = providerViewModel.Provider.SignImage;
                    ViewBag.WriteSignature = providerViewModel.Provider.WriteSignature;
                }

                ViewBag.BtnSubmit = "Edit";
                ViewBag.ViewHeader = "Update Provider";
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                ViewBag.ViewHeader = "Add Provider";

            }
            
            providerViewModel.ProviderSessionTypeList = await _providerSettingsService.GetAllSessionSettings();
            var infoList = await _providerTemplateService.providerTemplate();
            providerViewModel.ProviderTemplateList = infoList.Data;
            var infoSpecList = await _providerSpecialityService.providerSpeciality();
            providerViewModel.ProviderSpecialityList = infoSpecList.Data;
            var infoTitleList = _lookupService.lookupByTypeBasicDto("ProviderTitle");
            providerViewModel.ProviderTitleList = infoTitleList.Data;
            var infoSuffixList = _lookupService.lookupByTypeBasicDto("ProviderSuffix");
            providerViewModel.ProviderSuffixList = infoSuffixList.Data;
            var infoRentTypeList = _lookupService.lookupByTypeBasicDto("ProviderRentType");
            providerViewModel.ProviderRentTypeList = infoRentTypeList.Data;
            var infoScannedDocumentList = _lookupService.lookupByTypeBasicDto("ScannedDocument");
            providerViewModel.ProviderScannedDocumentsList = infoScannedDocumentList.Data;
            var infoStatusList = _lookupService.lookupByTypeBasicDto("ProviderStatus");
            providerViewModel.ProviderStatusList = infoStatusList.Data;
            var infoRelatedFacilityList = await _relatedFacilityService.relatedFacility();
            providerViewModel.ProviderRelatedFacilityList = infoRelatedFacilityList.Data;
            var infoProviderTermList = await _providerTermService.providerTerm();
            providerViewModel.ProviderTermList = infoProviderTermList.Data;
            var infoSubProviderList = await _subProviderService.subProvider();
            providerViewModel.SubProviderList = infoSubProviderList.Data;

            var infoUidTypeList = _providerUidTypeService.providerUidTypeBasicDto();
            providerViewModel.ProviderUidTypeList = infoUidTypeList;
            return View(providerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProviderInfo(ProviderViewModel providerViewModel, string Signature, string profileImage)
        {
            if (providerViewModel.Provider.ProviderInfoId > 0)
            {
               
                //var isExistdata = await _providerInfoService.CheckEmailExistOrNot(providerViewModel.Provider.Email, providerViewModel.Provider.UserId);
                //if (isExistdata.Data)
                //{
                //    var message = new { Success = isExistdata.Message, IsError = true };
                //    return Json(message);
                //}
                //var fileName = "";
                //if (providerViewModel.Provider.File != null)
                //{
                //    //upload files to wwwroot
                //    fileName = Path.GetFileName(providerViewModel.Provider.File.FileName);
                //    //judge if it is pdf file
                //    string ext = Path.GetExtension(providerViewModel.Provider.File.FileName);

                //    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Files", fileName);

                //    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                //    {
                //        await providerViewModel.Provider.File.CopyToAsync(fileSteam);
                //    }
                //}
                //if (fileName != "")
                //{
                //    providerViewModel.Provider.ScannedDocuments = fileName;
                //}
              
                
                var UpdateProfile = TempData["ProfileImage"];
                if (profileImage == "/images/" + UpdateProfile)
                {
                    providerViewModel.Provider.ProviderProfilePic = providerViewModel.Provider.Profileimage;
                }
                else if (profileImage == "/app-assets/images/user/male-user.png")
                {
                    providerViewModel.Provider.ProviderProfilePic = null;
                }
                else if (profileImage == "/images/" + providerViewModel.Provider.Profileimage)
                {
                    providerViewModel.Provider.ProviderProfilePic = providerViewModel.Provider.Profileimage;
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
                    providerViewModel.Provider.ProviderProfilePic = ProfileImageFile;
                    pic_memStream.Close();
                }

                if (Signature is null)
                {
                    providerViewModel.Provider.WriteSignature = providerViewModel.Provider.HiddentWriteSignImage;
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
                    providerViewModel.Provider.WriteSignature = Signfilenames;
                    memStreams.Close();
                }

                var files = Request.Form.Files;
                if (files.Count > 0)
                {
                    string filename = "";
                    string Signfile = "";
                    string patientfile = "";
                    string scanDocument = "";
                    foreach (IFormFile source in files)
                    {
                        var ControlName = source.Name;
                        filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');
                        filename = DateTime.UtcNow.ToString("ddMMyyyyhhmmss") + "_" + System.IO.Path.GetFileName(filename);
                        string extension = System.IO.Path.GetExtension(filename);

                        using (FileStream output = System.IO.File.Create(this.GetFullPath(filename)))
                            await source.CopyToAsync(output);
                        if (ControlName == "Provider.SignImage")
                        {
                            Signfile = filename;
                            if (providerViewModel.Provider.SignImage is null)
                            {
                                providerViewModel.Provider.ProviderProfilePic = providerViewModel.Provider.Profileimage;
                            }
                        }
                        if (ControlName == "Provider.ProviderProfilePic")
                        {
                            patientfile = filename;
                            if (providerViewModel.Provider.ProviderProfilePic is null)
                            {
                                providerViewModel.Provider.SignImage = providerViewModel.Provider.Signatureimage;
                            }
                        }
                        if (ControlName == "Provider.File")
                        {
                            scanDocument = filename;
                           
                        }
                    };
                    if (!string.IsNullOrEmpty(patientfile))
                    {

                        providerViewModel.Provider.ProviderProfilePic = patientfile;

                    }

                    if (!string.IsNullOrEmpty(Signfile))
                    {

                        providerViewModel.Provider.SignImage = Signfile;

                    }
                    if (!string.IsNullOrEmpty(scanDocument))
                    {

                        providerViewModel.Provider.ScannedDocuments = scanDocument;

                    }

                }
                else if (files.Count == 0)
                {
                    providerViewModel.Provider.SignImage = providerViewModel.Provider.Signatureimage;

                }
                providerViewModel.User.UserId = providerViewModel.Provider.UserId;
                providerViewModel.User.Email = providerViewModel.Provider.Email;
                providerViewModel.User.Password = providerViewModel.Password;
                var PIupdate = await _providerInfoService.providerInfoUpdate(providerViewModel.Provider);
                //var userUpdate = await _userService.userInfoUpdate(providerViewModel.User);
                var providerInfoId = PIupdate.Data.ProviderInfoId;

                var data = new { ProviderUserId = providerViewModel.Provider.UserId, ProviderInfoId = providerInfoId, Success = "Data updated successfully" };
                return Json(data);
            }
            else
            {
                if (providerViewModel.User.UserId == 0)
                {
                    var isExistdata = await _providerInfoService.CheckEmailExistOrNot(providerViewModel.Provider.Email, null,providerViewModel.User.UserName);
                    if (isExistdata.Data)
                    {
                        var message = new { Success = isExistdata.Message, IsError = true };
                        return Json(message);
                    }

                    providerViewModel.User.RoleTypeId = 2;
                    providerViewModel.User.Email = providerViewModel.Provider.Email;
                    providerViewModel.User.Password = providerViewModel.Password;
                    var userforce = await _userService.userInfoCreate(providerViewModel.User);
                    providerViewModel.Provider.UserId = userforce.Data.UserId;
                }

                else
                {
                    providerViewModel.Provider.UserId = providerViewModel.User.UserId;
                }
                //var fileName = "";
                //if (providerViewModel.Provider.File != null)
                //{
                //    //upload files to wwwroot
                //    fileName = Path.GetFileName(providerViewModel.Provider.File.FileName);
                //    //judge if it is pdf file
                //    string ext = Path.GetExtension(providerViewModel.Provider.File.FileName);

                //    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Files", fileName);

                //    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                //    {
                //        await providerViewModel.Provider.File.CopyToAsync(fileSteam);
                //    }
                //}
                //providerViewModel.Provider.ScannedDocuments = fileName;
                if (profileImage == "/app-assets/images/user/male-user.png")
                {
                    providerViewModel.Provider.ProviderProfilePic = null;
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
                    providerViewModel.Provider.ProviderProfilePic = ProfileImageFile;
                    pic_memStream.Close();
                }

                if (Signature is null)
                {

                    var Signfilenames = "Empty.png";

                    providerViewModel.Provider.WriteSignature = Signfilenames;

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
                    providerViewModel.Provider.WriteSignature = Signfilename;
                    memStream.Close();
                }



                var files = Request.Form.Files;
                if (files.Count > 0)
                {
                    string filename = "";
                    string Signfile = "";
                    string patientfile = "";
                    string scanDocuments = "";
                    foreach (IFormFile source in files)
                    {
                        var ControlName = source.Name;
                        filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');
                        filename = DateTime.UtcNow.ToString("ddMMyyyyhhmmss") + "_" + System.IO.Path.GetFileName(filename);
                        string extension = System.IO.Path.GetExtension(filename);

                        using (FileStream output = System.IO.File.Create(this.GetFullPath(filename)))
                            await source.CopyToAsync(output);
                        if (ControlName == "Provider.SignImage")
                        {
                            Signfile = filename;
                        }
                        if (ControlName == "Provider.ProviderProfilePic")
                        {
                            patientfile = filename;
                        }
                        if (ControlName == "Provider.File")
                        {
                            scanDocuments = filename;
                        }
                    };
                    if (!string.IsNullOrEmpty(patientfile))
                    {

                        providerViewModel.Provider.ProviderProfilePic = patientfile;

                    }

                    if (!string.IsNullOrEmpty(Signfile))
                    {

                        providerViewModel.Provider.SignImage = Signfile;

                    }
                    if (!string.IsNullOrEmpty(scanDocuments))
                    {

                        providerViewModel.Provider.ScannedDocuments = scanDocuments;

                    }

                }
                var providerAdded = await _providerInfoService.providerInfoCreate(providerViewModel.Provider);
                var providerInfoId = providerAdded.Data.ProviderInfoId;
                _sessionManager.SetProviderInfoId(providerAdded.Data.ProviderInfoId);
                var data = new { ProviderUserId = providerViewModel.Provider.UserId, ProviderInfoId = providerInfoId, Success = "Data saved successfully" };
                return Json(data);
            }
        }
        [HttpPost]
        public IActionResult LookupByType(string lookupType, string name)
        {
            var infoList = _lookupService.lookupsByType(lookupType, name);
            return Json(infoList);
        }
        [HttpPost]
        public IActionResult ProviderSpecialityByName(string name)
        {
            var infoList = _providerSpecialityService.providerSpecialityByName(name);
            return Json(infoList);
        }
        [HttpPost]
        public IActionResult ProviderTermByName(string name)
        {
            var infoList = _providerTermService.providerTermByName(name);
            return Json(infoList);
        }
        [HttpPost]
        public IActionResult ProviderUidTypeByName(string name)
        {
            var infoList = _providerUidTypeService.providerUidTypeByName(name);
            return Json(infoList);
        }
        public SelectList LookupByTypeBasicDto(string lookupType)
        {
            List<LookupBasicDto> Lookup = new List<LookupBasicDto>();
            var lookup = _lookupService.lookupByTypeBasicDto(lookupType);
            Lookup = lookup.Data;
            List<SelectListItem> Lookups = new List<SelectListItem>();

            foreach (LookupBasicDto item in Lookup)
            {
                Lookups.Add(new SelectListItem { Selected = false, Text = item.LookupValue, Value = item.LookupId.ToString() });
            }
            return new SelectList(Lookups, "Value", "Text", null);
        }
        [HttpPost]
        public IActionResult ProviderTemplateByName(string name)
        {
            var infoList = _providerTemplateService.providerTemplateByname(name);
            return Json(infoList);
        }
        [HttpPost]
        public IActionResult RelatedFacilityByName(string name)
        {
            var infoList = _relatedFacilityService.RelatedFacilityByName(name);
            return Json(infoList);
        }
        public async Task<IActionResult> ProviderList()
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            var userId = (long?)_sessionManager.GetUserId();
            if (!(userId is null))
            {
                providerViewModel.ProviderListSettingDto = _providerSettingsService.getProviderListSettingsById((int)userId);
            }
            else
            {
                providerViewModel.ProviderListSettingDto = new Models.DTOs.ProviderListSettingDto();
            }

            var infoList = await _providerInfoService.providerInfo();
            providerViewModel.ProviderList = infoList.Data;
            return View(providerViewModel);
        }

        public async Task<IActionResult> ProviderSummary(long id)
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            var providerData = await _providerInfoService.GetProviderSummaryDetails(id);
            providerViewModel.ProviderSummarySettingDto = await _providerInfoService.GetProviderSummarySetting();
            providerViewModel.ProviderSummary = providerData;
            providerViewModel.patientAppointmentBasicsList = await _providerInfoService.ProviderPatientBookSlotsList(id);
            providerViewModel.ProviderPatientsLists = await _providerInfoService.ProviderPatientsList(id);
            providerViewModel.BookedAppointment = await _providerInfoService.ProviderPatientsbookedSlots(id);
            providerViewModel.ScheduleList = await _providerInfoService.ProviderScheduleList(id);
            _sessionManager.SetProviderInfoId(id);
            return View(providerViewModel);
        }
        public async Task<IActionResult> PrintProviderSummary(long id)
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            ViewBag.ProviderID = id;
            providerViewModel.ProviderSummarySettingDto = await _providerInfoService.GetProviderSummarySetting();
            var providerData = await _providerInfoService.GetProviderSummaryDetails(id);
            providerViewModel.ProviderSummary = providerData;
            providerViewModel.patientAppointmentBasicsList = await _providerInfoService.ProviderPatientBookSlotsList(id);
            providerViewModel.ProviderPatientsLists = await _providerInfoService.ProviderPatientsList(id);
            providerViewModel.BookedAppointment = await _providerInfoService.ProviderPatientsbookedSlots(id);
            providerViewModel.ScheduleList = await _providerInfoService.ProviderScheduleList(id);
            _sessionManager.SetProviderInfoId(id);
            return View(providerViewModel);
        }
        public async Task<IActionResult> PrintProviderList()
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();

            var userId = (long?)_sessionManager.GetUserId();
            if (!(userId is null))
            {
                providerViewModel.ProviderListSettingDto = _providerSettingsService.getProviderListSettingsById((int)userId);
            }
            else
            {
                providerViewModel.ProviderListSettingDto = new Models.DTOs.ProviderListSettingDto();
            }

            var infoList = await _providerInfoService.providerInfo();
            foreach (var item in infoList.Data)
            {
                if (!(Path.HasExtension(item.ScannedDocuments)))
                {
                    item.ScannedDocuments = null;
                }
            }
            providerViewModel.ProviderList = infoList.Data;
            return View(providerViewModel);
        }
        [HttpPost]
        public IActionResult GetProviderUserId(int Id)
        {
            var data = _providerInfoService.GetProviderUserId(Id);
            return Json(data);
        }
        public async Task<IActionResult> ProviderInfoDelete(int providerId)
        {
            var ProviderById = await _providerInfoService.providerInfoDeleteById(providerId);
            return RedirectToAction("ProviderList", "Provider");
        }
        #endregion provider info
        #region provider template
        [HttpPost]
        public async Task<IActionResult> ProviderTemplate(ProviderViewModel providerViewModel)
        {
            if (providerViewModel.ProviderTemplate.ProviderTemplateId > 0)
            {
                var PIupdate = await _providerTemplateService.providerTemplateUpdate(providerViewModel.ProviderTemplate);
                var data = new { Success = "Data updated successfully" };
                return Json(data);
            }
            else
            {
                var infocre = await _providerTemplateService.providerTemplateCreate(providerViewModel.ProviderTemplate);
                var data = new { Success = "Data saved successfully" };
                return Json(data);
            }
        }
        public async Task<IActionResult> ProviderTemplateList()
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            var infoList = await _providerTemplateService.providerTemplate();
            providerViewModel.ProviderTemplateList = infoList.Data;
            return View(providerViewModel);
        }
        public async Task<IActionResult> ProviderTemplateEdit(int providerTemplateId)
        {
            var ProviderTemplateById = await _providerTemplateService.providerTemplateGetId(providerTemplateId);
            return Json(ProviderTemplateById.Data);
        }
        public async Task<IActionResult> ProviderTemplateDelete(int providerTemplateId)
        {
            var ProviderTemplateById = await _providerTemplateService.providerTemplateDeleteById(providerTemplateId);
            var data = new { Success = "Data deleted successfully" };
            return Json(data);
        }
        #endregion provider template

        #region related facility
        [HttpPost]
        public async Task<IActionResult> RelatedFacility(ProviderViewModel providerViewModel)
        {
            var ExistName = await _relatedFacilityService.isExistorNot(providerViewModel.RelatedFacilitiy.RelatedFacility);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }


            var infocre = await _relatedFacilityService.relatedFacilityCreate(providerViewModel.RelatedFacilitiy);
            var data = new { RelatedFacilityId = infocre.Data, RelatedFacility = providerViewModel.RelatedFacilitiy.RelatedFacility };

            return Json(data);
        }
        public async Task<IActionResult> RelatedFacilitiesList()
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            var infoList = await _relatedFacilityService.relatedFacility();
            providerViewModel.RelatedFacilitiyList = infoList.Data;
            return View(providerViewModel);
        }
        public async Task<IActionResult> RelatedFacilitiesEdit(int Id)
        {
            var ProviderById = await _relatedFacilityService.relatedFacilityGetId(Id);
            return View("ProviderInfo", ProviderById.Data);
        }
        public async Task<IActionResult> RelatedFacilitiesDelete(int Id)
        {
            var ProviderById = await _relatedFacilityService.relatedFacilityDeleteById(Id);
            return RedirectToAction("ProviderList", "Provider");
        }
        #endregion related facility
        #region sub provider
        [HttpPost]
        public async Task<IActionResult> SubProvider(ProviderViewModel providerViewModel)
        {
            if (providerViewModel.SubProvider.SubProviderId > 0)
            {
                var PIupdate = await _subProviderService.subProviderUpdate(providerViewModel.SubProvider);
                var data = new { Success = "Data updated successfully" };
                return Json(data);
            }
            else
            {
                var infocre = await _subProviderService.subProviderCreate(providerViewModel.SubProvider);
                var data = new { Success = "Data saved successfully" };
                return Json(data);
            }
        }
        public async Task<IActionResult> SubProviderEdit(int subProviderId)
        {
            var SubProviderById = await _subProviderService.subProviderGetId(subProviderId);
            return Json(SubProviderById.Data);
        }
        public async Task<IActionResult> SubProviderDelete(int subProviderId)
        {
            var SubProviderId = await _subProviderService.subProviderDeleteById(subProviderId);
            var data = new { Success = "Data deleted successfully" };
            return Json(data);
        }
        #endregion sub provider

        #region provider speciality
        public async Task<IActionResult> ProviderSpecility()
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            var infoList = await _providerSpecialityService.providerSpeciality();
            providerViewModel.ProviderSpecialityDetail = infoList.Data;
            return View(providerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ProviderSpecility(ProviderViewModel providerViewModel)
        {
            if (providerViewModel.ProviderSpeciality.ProviderSpecialityId > 0)
            {
                var PIupdate = await _providerSpecialityService.providerSpecialityUpdate(providerViewModel.ProviderSpeciality);
                var data = new { Success = "Data updated successfully" };
                return Json(data);
            }
            else
            {
                var infocre = await _providerSpecialityService.providerSpecialityCreate(providerViewModel.ProviderSpeciality);
                var data = new { Success = "Data saved successfully" };
                return Json(data);
            }
        }
        public async Task<IActionResult> ProviderSpecialityEdit(int providerSpecialityId)
        {
            var ProviderSpecialityById = await _providerSpecialityService.providerSpecialityGetId(providerSpecialityId);
            return Json(ProviderSpecialityById.Data);
        }
        public async Task<IActionResult> ProviderSpecialityDelete(int providerSpecialityId)
        {
            var ProviderSpecialityById = await _providerSpecialityService.providerSpecialityDeleteById(providerSpecialityId);
            var data = new { Success = "Data deleted successfully" };
            return Json(data);
        }
        #endregion provider speciality

        #region provider term
        public async Task<IActionResult> ProviderTerm()
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            var infoList = await _providerTermService.providerTerm();
            providerViewModel.ProviderTermDetail = infoList.Data;
            return View(providerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ProviderTerm(ProviderViewModel providerViewModel)
        {
            if (providerViewModel.ProviderTerm.ProviderTermId > 0)
            {
                var PIupdate = await _providerTermService.providerTermUpdate(providerViewModel.ProviderTerm);
                var data = new { Success = "Data updated successfully" };
                return Json(data);
            }
            else
            {
                var infocre = await _providerTermService.providerTermCreate(providerViewModel.ProviderTerm);
                var data = new { Success = "Data saved successfully" };
                return Json(data);
            }
        }

        public async Task<IActionResult> ProviderTermEdit(int providerTermId)
        {
            var ProviderTermById = await _providerTermService.providerTermGetId(providerTermId);
            return Json(ProviderTermById.Data);
        }
        public async Task<IActionResult> ProviderTermDelete(int providerTermId)
        {
            var ProviderTermById = await _providerTermService.providerTermDeleteById(providerTermId);
            var data = new { Success = "Data deleted successfully" };
            return Json(data);
        }
        #endregion provider term

        #region provider uid type
        public async Task<IActionResult> ProviderUidType()
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            var infoList = await _providerUidTypeService.providerUidType();
            providerViewModel.ProviderUidTypeDetail = infoList.Data;
            return View(providerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ProviderUidType(ProviderViewModel providerViewModel)
        {
            if (providerViewModel.ProviderUidType.ProviderUIDTypeId > 0)
            {
                var PIupdate = await _providerUidTypeService.providerUidTypeUpdate(providerViewModel.ProviderUidType);
                var data = new { Success = "Data updated successfully" };
                return Json(data);
            }
            else
            {
                var infocre = await _providerUidTypeService.providerUidTypeCreate(providerViewModel.ProviderUidType);
                var data = new { Success = "Data saved successfully" };
                return Json(data);
            }
        }

        public async Task<IActionResult> ProviderUidTypeEdit(int providerUidTypeId)
        {
            var ProviderUidTypeById = await _providerUidTypeService.providerUidTypeGetId(providerUidTypeId);
            return Json(ProviderUidTypeById.Data);
        }
        public async Task<IActionResult> ProviderUidTypeDelete(int providerUidTypeId)
        {
            var ProviderUidTypeById = await _providerUidTypeService.providerUidTypeDeleteById(providerUidTypeId);
            var data = new { Success = "Data deleted successfully" };
            return Json(data);
        }
        #endregion provider uid type
        private string GetFullPath(string filename)
        {
            return this._webHostEnvironment.WebRootPath + "\\images\\" + filename;
        }

        #region MedicalTemplate
        public async Task<IActionResult> Template()
        {
            ViewBag.Template = "nav-active";
            ProviderViewModel model = new ProviderViewModel();
            model.TemplateBasicList = await _templateService.ProviderTemplateList();
            return View(model);
        }

        public IActionResult AddTemplate()
        {
            ProviderViewModel model = new ProviderViewModel();
            model.MedicineList = _doctorService.GetMedicinesForTemplate().Take(10);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMedicationTemplate(ProviderViewModel model)
        {
            if (model.PrescriptionTemplateDto != null && model.TemplateBasicDto.TemplateId == 0)
            {
                var exist = await _templateService.isTemplateExistOrNot(model.TemplateBasicDto.Name);
                if (exist.Data)
                {
                    return Json("exist");
                }
                model.TemplateBasicDto.ProviderInfoId = _sessionManager.GetProviderInfoId();
                var create = await _templateService.SaveMedicationTemplate(model.TemplateBasicDto);

                string[] data = model.SelectedData.Split(new string[] { "|-|" }, StringSplitOptions.None);
                foreach (var item in data)
                {
                    if (item != "")
                    {
                        model.PrescriptionTemplateDto.TemplateId = create.Data.TemplateId;
                        string[] metadata = item.Split(new string[] { "_" }, StringSplitOptions.None);

                        CultureInfo provider = CultureInfo.InvariantCulture;
                        DateTime sDate = DateTime.ParseExact(metadata[4], "mm/dd/yyyy", provider);
                        DateTime eDate = DateTime.ParseExact(metadata[5], "mm/dd/yyyy", provider);

                        model.PrescriptionTemplateDto.MedicineId = Convert.ToInt32(metadata[0]);
                        model.PrescriptionTemplateDto.FrequencyId = metadata[1];
                        model.PrescriptionTemplateDto.Quantity = Convert.ToInt32(metadata[2]);
                        model.PrescriptionTemplateDto.Dose = Convert.ToInt32(metadata[3]);
                        model.PrescriptionTemplateDto.StartDate = sDate;
                        model.PrescriptionTemplateDto.EndDate = eDate;
                        model.PrescriptionTemplateDto.Unit = metadata[6];
                        model.PrescriptionTemplateDto.Notes = metadata[7];

                        await _templateService.SaveTemplatesPrescriptions(model.PrescriptionTemplateDto);
                    }
                }
            }

            return Json("success");
        }
        public IActionResult DeleteTemplates(int Id)
        {
            var result = _templateService.DeleteTemplate(Id);
            return Json(result);
        }
        public async Task<IActionResult> GetTemplateMedications(long Id)
        {
            List<MedicationTemplateDto> templateView = new List<MedicationTemplateDto>();
            templateView = await _templateService.GetTemplatesMedicinesById(Id);
            return Json(templateView);
        }
        

        [HttpPost]
        public async Task<IActionResult> SaveWorkingHours(List<WeekDayWithSessionTypeDto> dayWithSessionTypeList)
        {
            var userId = _sessionManager.GetUserId();
            var providerId = _sessionManager.GetProviderInfoId();

            await _providerInfoService.SaveWorkingHours(dayWithSessionTypeList, providerId, userId);
            return Json(dayWithSessionTypeList);
        }

        public async Task<IActionResult> EditTemplate(long Id)
        {
            ProviderViewModel model = new ProviderViewModel();
            model.MedicineList = _doctorService.GetMedicinesForTemplate().Take(10);
            model.TemplateBasicDto = await _templateService.GetTemplateById(Id);
            return View(model);
        }

        public async Task<IActionResult> EditPrescriptiontemplate(long Id)
        {
            ProviderViewModel model = new ProviderViewModel();
            model.MedicineList = _doctorService.GetMedicinesForTemplate().Take(10);
            model.medicationsTemplate = await _templateService.GetTemplatePrescriptionById(Id);
            model.StartDate = Convert.ToString(model.medicationsTemplate.StartDate);
            model.EndDate = Convert.ToString(model.medicationsTemplate.EndDate);
            return PartialView("~/Views/_PatientPartialView/_EditPrescriptionTemplate.cshtml", model);
        }

        public async  Task<IActionResult> DeleteTemplatePrescriptionById(long Id,long TemplateId)
        {
            _templateService.DeleteTemplatePrescriptionById(Id);
            List<MedicationTemplateDto> templateView = new List<MedicationTemplateDto>();
            templateView = await _templateService.GetTemplatesMedicinesById(TemplateId);
            return Json(templateView);
        }

        public async Task<IActionResult> SaveSingleMedicationTemplate(ProviderViewModel model)
        {

            DateTime sDate;
            DateTime eDate;
            CultureInfo provider = CultureInfo.InvariantCulture;
            model.medicationsTemplate.TemplateId = model.TemplateBasicDto.TemplateId;
            sDate = DateTime.ParseExact(model.StartDate, "mm/dd/yyyy", provider);
            eDate = DateTime.ParseExact(model.EndDate, "mm/dd/yyyy", provider);
            model.medicationsTemplate.StartDate = sDate;
            model.medicationsTemplate.EndDate = eDate;

            if (model.medicationsTemplate.Id == 0)
            {
                await _templateService.SaveTemplatesPrescriptions(model.medicationsTemplate);
            }
            else
            {
                await _templateService.UpdateTemplatePrescription(model.medicationsTemplate);
            }
            return Json("success");
        }
        #endregion MedicalTemplate
        #region EliteThemePages

        #region SubContractor
        public IActionResult Subcontractors()
        {
            return View();
        }
        public IActionResult AddNewcontractors()
        {
            return View();
        }

        #endregion SubContractor

        #region Provider Assistants
        public IActionResult Assistants()
        {
            return View();
        }
        public IActionResult AddNewAssistant()
        {
            return View();
        }

        #endregion Provider Assistants

        #region Provider DME
        public IActionResult DME()
        {
            return View();
        }
        public IActionResult AddNewDME()
        {
            return View();
        }

        #endregion Provider DME

        #region Provider Pharmacy
        public IActionResult Pharmacy()
        {
            return View();
        }
        public IActionResult AddNewRx()
        {
            return View();
        }
        #endregion Provider Pharmacy
        
        #region  SurgeryCenter

        public IActionResult SurgeryCenter()
        {
            return View();
        }
        public IActionResult AddNewProcedure()
        {
            return View();
        }
        #endregion SurgeryCenter

        #region Test
        public IActionResult Tests()
        {
            return View();
        }

        public IActionResult AddNewTest()
        {
            return View();
        }

        #endregion Test
        
        #region Reports
        public async Task<IActionResult> Reports(int Id)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.GetVisitsListDto = await _patientInfoService.GetVisitsList(Id);
            return View(patientViewModel);
        }

        public IActionResult GenerateReports()
        {
            return View();
        }

        #endregion Reports

        #region Claims
        public async Task<IActionResult> Claims(long? Id)
        {
            var VisitId = (Int32)_sessionManager.GetVisitId();
            ClaimViewModal claimVM = new ClaimViewModal();
            //claimVM.Claimlist = await _claimService.ClaimList();
            claimVM.Claimlist = await _claimService.ClaimListByPatientId((int)Id);
            return View(claimVM);
        }
        
        public async Task<IActionResult> AddNewClaim(int? Id)
        {
            ClaimViewModal claimVM = new ClaimViewModal();
            if (Id > 0)
            {
                var GetById =  await _claimService.ClaimGetById((int)Id);
                claimVM.claim = GetById;
            }
            claimVM.CPTList = await _claimService.GetAllCPTCodes();
            claimVM.ICDList = await _claimService.GetAllICDCodes(true);
            return View(claimVM);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewClaim(ClaimViewModal claimVM)
        {
            var VisitId = _sessionManager.GetVisitId();
            
            if (claimVM.claim.Claim_Id > 0)
            {
                await _claimService.ClaimUpdate(claimVM.claim);
            }
            else
            {
                claimVM.claim.VisitId = VisitId;
                await _claimService.ClaimCreate(claimVM.claim);
            }
            var Data = "Sucessfull";
            return Json(Data);
        }
        public  IActionResult DeleteClaim(int Id)
        {
            var DeletebyID =  _claimService.DeleteClaim(Id);
            var Data = "Sucessfull";

            return Json(Data);

        }
        #endregion Claims

        #region Billing
        public IActionResult Billing()
        {
            return View();
        }
        public IActionResult AddNewBill()
        {
            return View();
        }

        #endregion Billing

        #region IME
        public IActionResult IME()
        {
            return View();
        }
        public IActionResult AddNewIME()
        {
            return View();
        }

        #endregion IME

        #region EUO
        public IActionResult EUO()
        {
            return View();
        }
        public IActionResult AddNewEUO()
        {
            return View();
        }

        #endregion EUo

        #region CheckIn
        public IActionResult CheckInOut()
        {
            return View();
        }

        #endregion CheckIn

        #region Transport
        public IActionResult TransportEMS()
        {
            return View();
        }
        public IActionResult AddNewTransportSource()
        {
            return View();
        }

        #endregion Transport

        #region Employees
        public IActionResult Employees()
        {
            return View();
        }
        public IActionResult AddNewEmployee()
        {
            return View();
        }

        #endregion Employees

        #region Hippa
        public IActionResult HIPAA()
        {
            return View();
        }

        #endregion Hippa

        #region Invoice

        public IActionResult Invoices()
        {
            return View();
        }
        public IActionResult AddNewInvoice()
        {
            return View();
        }
        #endregion Invoice

        #region ClinicOverView
        public IActionResult ClinicOverview()
        {
            ClinicalViewModel viewModel = new ClinicalViewModel();
            viewModel.Clinicviewcount = _patientService.GetClinicView();
            return View(viewModel);
        }

        #endregion ClinicOverView

        #region ProviderListElite
        public async Task<IActionResult> ProviderEliteList()
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            var userId = (long?)_sessionManager.GetUserId();
            if (!(userId is null))
            {
                providerViewModel.ProviderListSettingDto = _providerSettingsService.getProviderListSettingsById((int)userId);
            }
            else
            {
                providerViewModel.ProviderListSettingDto = new Models.DTOs.ProviderListSettingDto();
            }

            var infoList = await _providerInfoService.providerInfo();
            foreach (var item in infoList.Data)
            {
                if(!(Path.HasExtension(item.ScannedDocuments)))
                {
                    item.ScannedDocuments = null;
                }
            }
            providerViewModel.ProviderList = infoList.Data;
            return View(providerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveSpeciality(ProviderViewModel entity)
        {
            var ExistName = await _providerSpecialityService.IsSpecialityExistOrNot(entity.ProviderSpeciality.ProviderSpeciality);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var result = await _providerSpecialityService.providerSpecialityCreate(entity.ProviderSpeciality);
            var data = new { specialityId = result.Data, specialityName = entity.ProviderSpeciality.ProviderSpeciality };
            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> SaveLookUpValue(ProviderViewModel entity)
        {
            var ExistName = await _lookupService.IsLookUpValueExists(entity.lookupBasicDto.LookupValue,entity.lookupBasicDto.LookupType);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var result = await _lookupService.SaveLookUpValue(entity.lookupBasicDto);
            var data = new { titleId = result.Data, titleName = entity.lookupBasicDto.LookupValue };
            return Json(data);
        }

        public async Task<IActionResult> ProviderEliteAdd(int? id, string clickfrom)
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            providerViewModel.User = new UsersBasicDto();
            providerViewModel.Provider = new ProviderInfoBasicDto();
            if (id != null)
            {
                _sessionManager.SetProviderInfoId(Convert.ToInt64(id));

                ViewBag.action = "Update";
                if (clickfrom is null)
                {
                    ViewBag.clickValue = string.Empty;
                }
                else if (clickfrom.Equals("Editicon"))
                {
                    ViewBag.clickValue = clickfrom;
                }
                else
                {
                    ViewBag.clickValue = clickfrom;
                }
                ViewBag.ProId = id;
                var providerInfo = await _providerInfoService.providerInfoGetId((int)id);
                if (Path.HasExtension(providerInfo.Data.ScannedDocuments))
                {
                    ViewBag.DocumentName = providerInfo.Data.ScannedDocuments;
                }
                else
                {
                    ViewBag.DocumentName = "";
                }
                
               var userInfo = await _userService.userInfoGetId(providerInfo.Data.UserId);
                //ViewBag.ProviderSessions = await _providerInfoService.GetAllProviderSessions((long)id);
                ViewBag.ProviderSessions = await _providerInfoService.GetAllScheduleListById((long)id);
                if (providerInfo.Data.ElectronicSignPassword is null)
                {
                    ViewBag.ElectricPass = null;
                }
                else
                {
                    ViewBag.ElectricPass = providerInfo.Data.ElectronicSignPassword;
                }
                if (userInfo.Data.Password is null)
                {
                    ViewBag.Password = null;
                }
                else
                {
                    ViewBag.Password = userInfo.Data.Password;
                }
                providerViewModel.ScheduleList = await _providerInfoService.ProviderScheduleList((long)id);
                providerViewModel.Provider = providerInfo.Data;
                providerViewModel.Provider.ElectronicConfirmPassword = providerViewModel.Provider.ElectronicSignPassword;
                providerViewModel.User = userInfo.Data;
                providerViewModel.Password = providerViewModel.User.Password;
                providerViewModel.ConfirmPassword = providerViewModel.User.Password;
                providerViewModel.Provider.ElectronicConfirmPassword = providerViewModel.Provider.ElectronicSignPassword;
                if (providerViewModel.Provider is null)
                {
                    ViewBag.ProviderImage = string.Empty;
                    ViewBag.ProviderSignatureImage = string.Empty;
                    ViewBag.WriteSignature = string.Empty;
                }
                else
                {
                    ViewBag.ProviderImage = providerViewModel.Provider.ProviderProfilePic;
                    TempData["ProfileImage"] = providerViewModel.Provider.ProviderProfilePic;

                    ViewBag.ProviderSignatureImage = providerViewModel.Provider.SignImage;
                    ViewBag.WriteSignature = providerViewModel.Provider.WriteSignature;
                }
               
                ViewBag.BtnSubmit = "Edit";
                ViewBag.ViewHeader = "Update Provider";
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                ViewBag.ViewHeader = "Add Provider";

            }

            providerViewModel.ProviderSessionTypeList = await _providerSettingsService.GetAllSessionSettings();
            var infoList = await _providerTemplateService.providerTemplate();
            providerViewModel.ProviderTemplateList = infoList.Data;
            var infoSpecList = await _providerSpecialityService.providerSpeciality();
            providerViewModel.ProviderSpecialityList = infoSpecList.Data;
            var infoTitleList = _lookupService.lookupByTypeBasicDto("ProviderTitle");
            providerViewModel.ProviderTitleList = infoTitleList.Data;
            var infoSuffixList = _lookupService.lookupByTypeBasicDto("ProviderSuffix");
            providerViewModel.ProviderSuffixList = infoSuffixList.Data;
            var infoRentTypeList = _lookupService.lookupByTypeBasicDto("ProviderRentType");
            providerViewModel.ProviderRentTypeList = infoRentTypeList.Data;
            var infoScannedDocumentList = _lookupService.lookupByTypeBasicDto("ScannedDocument");
            providerViewModel.ProviderScannedDocumentsList = infoScannedDocumentList.Data;
            var infoStatusList = _lookupService.lookupByTypeBasicDto("ProviderStatus");
            providerViewModel.ProviderStatusList = infoStatusList.Data;
            var infoRelatedFacilityList = await _relatedFacilityService.relatedFacility();
            providerViewModel.ProviderRelatedFacilityList = infoRelatedFacilityList.Data;
            var infoProviderTermList = await _providerTermService.providerTerm();
            providerViewModel.ProviderTermList = infoProviderTermList.Data;
            var infoSubProviderList = await _subProviderService.subProvider();
            providerViewModel.SubProviderList = infoSubProviderList.Data;

            var infoUidTypeList = _providerUidTypeService.providerUidTypeBasicDto();
            providerViewModel.ProviderUidTypeList = infoUidTypeList;
            return View(providerViewModel);
        }
        #endregion ProviderListElite

        [HttpPost]
        public async Task<IActionResult> ProviderScheduleTime(List<ProviderWorkHrsDto> providerWorkHrsDtos, long Id)
        {
            
            
            foreach (var item in providerWorkHrsDtos)
            {
                if (item.Days == "Sunday")
                {
                    item.WeekDayId = 1;
                }
                if (item.Days == "Monday")
                {
                    item.WeekDayId = 2;
                }
                if (item.Days == "Tuesday")
                {
                    item.WeekDayId = 3;
                }
                if (item.Days == "Wednesday")
                {
                    item.WeekDayId = 4;
                }
                if (item.Days == "Thusday")
                {
                    item.WeekDayId = 5;
                }
                if (item.Days == "Friday")
                {
                    item.WeekDayId = 6;
                }
                if (item.Days == "Saturday")
                {
                    item.WeekDayId = 7;
                }
                
            }

            if (providerWorkHrsDtos.Count > 0)
            {
                providerWorkHrsDtos.RemoveAll(x => x.DepartmentName == null);

            }
            if (providerWorkHrsDtos.Count > 0)
            {
                await _providerInfoService.ProviderScheduling(providerWorkHrsDtos, Id);

            }

            var data = new { Success = "Data Save successfully" };
            return Json(data);
        }
        #endregion EliteThemePages
        public IActionResult Radiology()
        {
            return View();
        }
        public IActionResult AddRadiologyList()
        {
            return View();
        }
        public async Task<IActionResult> DocTemplate()
        {
            ViewBag.Template = "nav-active";
            ProviderViewModel model = new ProviderViewModel();
            model.TemplateBasicList = await _templateService.ProviderTemplateList();
            return View(model);
        }
        public IActionResult AddDocTemplate()
        {
            ProviderViewModel model = new ProviderViewModel();
            model.MedicineList = _doctorService.GetMedicinesForTemplate().Take(10);
            return View(model);    
        }
        public IActionResult Labs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EmailSend(ProviderViewModel providerViewModel)
        {
            var result = CommonMethod.SendEmail(providerViewModel.EmailBasicDto);
            return Json(result);
        }

        public IActionResult EmailSms(ProviderViewModel providerViewModel)
        {
            if (string.IsNullOrEmpty(providerViewModel.SmsDto.PhoneNo))
            {
                return Json(false);
            }
            //providerViewModel.SmsDto.PhoneNo = "+" + providerViewModel.SmsDto.PhoneNo;
            var rec = CommonMethod.SendMessageToPhoneNo(providerViewModel.SmsDto);
            return Json(rec);
        }
        public IActionResult PrintPaitentOption(long userId)
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            providerViewModel.PatientSettingDto = _patientSettings.getPatientSettingsById((int)userId);
            providerViewModel.PatientPrintSettingDto = _patientSettings.getPatientPrintSettingsById((int)userId);

            return PartialView("~/Views/Provider/PartialView/_PatientPrintForm.cshtml", providerViewModel);
        }
    }
}