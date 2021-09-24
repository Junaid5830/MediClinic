using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Services.Interfaces.Assistant;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.UserInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediClinic.Services.Interfaces.LookupInteface;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using MediClinic.Models.EntityModels;

namespace MediClinic.Controllers
{
    public class AssistantController : Controller
    {
        private readonly ILogger<AssistantController> _logger;
        private ISessionManager _sessionManager;
        private IAssistantService _assistantInfoService;
        private IUserService _userService;
        private ILookupService _lookupService;
        private AssistantViewModel assistantViewModel;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AssistantController(
            ILogger<AssistantController> logger,
            ISessionManager sessionManager,
            IAssistantService assistantInfoService,
            ILookupService lookupService,
            IUserService userService,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _assistantInfoService = assistantInfoService;
            assistantViewModel  = new AssistantViewModel();
            _lookupService = lookupService;
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add(int? assistantid)
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
            assistantViewModel.Assistant = new AssistantInfoDto();
            if(assistantid != null)
            {
                ViewBag.action = "Update";
                var assistantinfo = await _assistantInfoService.assistantInfoGetId((int)assistantid);
                var userInfo = await _userService.userInfoGetId(assistantinfo.Data.UserID);
                assistantViewModel.Assistant = assistantinfo.Data;
                assistantViewModel.Assistant.ElectronicConfirmPassword = assistantViewModel.Assistant.ElectronicSignPassword;
                assistantViewModel.User = userInfo.Data;
                assistantViewModel.Assistant.ElectronicConfirmPassword = assistantViewModel.Assistant.ElectronicSignPassword;
                ViewBag.Password = assistantViewModel.Assistant.ElectronicSignPassword;
                if (assistantViewModel.Assistant is null)
                {
                    ViewBag.AssistantImage = string.Empty;
                    ViewBag.AssistantSignatureImage = string.Empty;
                    ViewBag.WriteSignature = string.Empty;
                }
                else
                {
                    ViewBag.AssistantImage = assistantViewModel.Assistant.ReminderBy;
                    ViewBag.AssistantSignatureImage = assistantViewModel.Assistant.SignImage;
                    ViewBag.WriteSignature = assistantViewModel.Assistant.WriteSignature;
                    TempData["ProfileImage"] = assistantViewModel.Assistant.ReminderBy;
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
        public async Task<IActionResult> Add(AssistantViewModel assistantViewModel, string Signature, string profileImage)
        {
            if (assistantViewModel.Assistant.AssistantInfoID > 0)
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
                    assistantViewModel.Assistant.ReminderBy = assistantViewModel.Assistant.Remindimage;
                }
                else if (profileImage == "/app-assets/images/user/male-user.png")
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
                    assistantViewModel.Assistant.ReminderBy = ProfileImageFile;
                    pic_memStream.Close();
                }

                if (Signature is null)
                {
                    assistantViewModel.Assistant.WriteSignature = assistantViewModel.Assistant.HiddenWriteSignImage;
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
                    assistantViewModel.Assistant.WriteSignature = Signfilenames;
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
                            if (assistantViewModel.Assistant.SignImage is null)
                            {
                                assistantViewModel.Assistant.ReminderBy = assistantViewModel.Assistant.Remindimage;
                            }
                        }
                        if (ControlName == "Assistant.ReminderBy")
                        {
                            patientfile = filename;
                            if (assistantViewModel.Assistant.ReminderBy is null)
                            {
                                assistantViewModel.Assistant.SignImage = assistantViewModel.Assistant.Signatureimage;
                            }
                        }
                    };
                    if (!string.IsNullOrEmpty(patientfile))
                    {
                        assistantViewModel.Assistant.ReminderBy = patientfile;
                    }
                    if (!string.IsNullOrEmpty(Signfile))
                    {
                        assistantViewModel.Assistant.SignImage = Signfile;
                    }
                }
                else if (files.Count == 0)
                {
                    assistantViewModel.Assistant.SignImage = assistantViewModel.Assistant.Signatureimage;
                }
                assistantViewModel.User.UserId = assistantViewModel.Assistant.UserID;
                assistantViewModel.User.Email = assistantViewModel.Assistant.Email;
                assistantViewModel.User.Password = assistantViewModel.Password;
                assistantViewModel.Assistant.ModifiedBy = Convert.ToInt32(_sessionManager.GetUserId());
                assistantViewModel.Assistant.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                var PIupdate = await _assistantInfoService.assistantInfoUpdate(assistantViewModel.Assistant);
                var data = new { Success = "Data updated successfully" };
                return RedirectToAction("AssistantList");
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
                }
                else
                {
                    assistantViewModel.Assistant.UserID = assistantViewModel.User.UserId;
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
                    assistantViewModel.Assistant.ReminderBy = ProfileImageFile;
                    pic_memStream.Close();
                }

                if (Signature is null)
                {

                    var Signfilenames = "Empty.png";

                    assistantViewModel.Assistant.WriteSignature = Signfilenames;

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
                    assistantViewModel.Assistant.WriteSignature = Signfilename;
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

                        assistantViewModel.Assistant.ReminderBy = patientfile;

                    }

                    if (!string.IsNullOrEmpty(Signfile))
                    {

                        assistantViewModel.Assistant.SignImage = Signfile;

                    }

                }
                assistantViewModel.User = new UsersBasicDto();

                assistantViewModel.Assistant.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                assistantViewModel.Assistant.ModifiedBy = Convert.ToInt32(_sessionManager.GetUserId());

                var add = await _assistantInfoService.assistantInfoAdd(assistantViewModel.Assistant);
                ViewBag.BtnSubmit = "Save";
                return RedirectToAction("AssistantList");
            }
        }
        private string GetFullPath(string filename)
        {
            return this._webHostEnvironment.WebRootPath + "\\images\\" + filename;
        }

        [HttpGet]
        public async Task<IActionResult> AssistantList(int? Id)
        {
            assistantViewModel = new AssistantViewModel();
            assistantViewModel.AssistantList = await _assistantInfoService.AssistantInfoList(null);
            return View(assistantViewModel);
        }

        public async Task<IActionResult> AssistantInfoDelete(int assistantId)
        {
             var PatById = await _assistantInfoService.assistantInfoDeleteById(assistantId);
            //return RedirectToAction("PatientList", "PatientSide");
            return Json(PatById.Data);
        }

        #region Assistant Workin Schedule

        [HttpGet]
        public async Task<IActionResult> AssisatntSchedule()
        {
            assistantViewModel.Department = await _assistantInfoService.GetDepartmentList();
            assistantViewModel.Doctor = await _assistantInfoService.GetDoctorList();
            return Json(new { assistantViewModel });
        }

        [HttpGet]
        public async Task<IActionResult> fillScheduleform()
        {
            var id = Convert.ToInt32(_sessionManager.GetUserId());
            assistantViewModel.WorkingSchedule = await _assistantInfoService.getworkschedule(id);
            return Json(new { assistantViewModel });
        }

        [HttpPost]
        public async Task<IActionResult> AssisatntSchedule(AssistantViewModel assistantViewModel)
        {
            if (assistantViewModel.WorkingSchedule.Count > 0)
            {
                var id = Convert.ToInt32(_sessionManager.GetUserId());
                foreach(var item in assistantViewModel.WorkingSchedule)
                {
                    item.CreatedBy = id;
                    item.ModifiedBy = id;
                }
                await _assistantInfoService.workingScheduleAdd(assistantViewModel.WorkingSchedule);
            }
            return RedirectToAction("AssistantList");
        }
        public async Task<IActionResult> UpdateSchedule(AssistantViewModel assistantViewModel)
        {
            var id = Convert.ToInt32(_sessionManager.GetUserId());
            if (assistantViewModel.WorkingSchedule.Count > 0)
            {
                await _assistantInfoService.removeSchedule(id);
                foreach (var item in assistantViewModel.WorkingSchedule)
                {
                    item.CreatedBy = id;
                    item.ModifiedBy = id;
                }
                await _assistantInfoService.workingScheduleAdd(assistantViewModel.WorkingSchedule);
            }
            return RedirectToAction("AssistantList");
        }
        #endregion

    }
}
