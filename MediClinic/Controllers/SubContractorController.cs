using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Filters;
using MediClinic.Models;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.SubContractorInfoInterface;
using MediClinic.Services.Interfaces.UserInterface;
using MedliClinic.Utilities.Utility.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.SessionManager;

namespace MediClinic.Controllers
{
    [AuthFilter(RoleNames.Doctor,RoleNames.MasterAdmin)]
    public class SubContractorController : Controller
    {


        private readonly ILogger<SubContractorController> _logger;
        private ISubContractorInfoService _subContractorInfoService;
        private ILookupService _lookupService;
        private IUserService _userService;
        private ISessionManager _sessionManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SubContractorController(ILogger<SubContractorController> logger,
            ISubContractorInfoService subContractorInfoService, IUserService userService, ILookupService lookupService)
        {
            _logger = logger;
            _subContractorInfoService = subContractorInfoService;
            _lookupService = lookupService;
            _userService = userService;
        }
        public async Task<IActionResult> Subcontractors()
        {
            SubContractorViewModel subContractorViewModel = new SubContractorViewModel();

            subContractorViewModel.SubContractorList = await _subContractorInfoService.subContractorInfo(null);
            return View(subContractorViewModel);
        }




        public async Task<IActionResult> Add(int? subcontractorId)
        {
            SubContractorViewModel subContractorViewModel = new SubContractorViewModel();

            subContractorViewModel.User = new UsersBasicDto();
            subContractorViewModel.SubContractor = new SubContractorInfoDto();
            if (subcontractorId != null)
            {
                ViewBag.action = "Update";
                var subContractorInfo = await _subContractorInfoService.subContractorInfoGetId((int)subcontractorId);
                var userInfo = await _userService.userInfoGetId(subContractorInfo.Data.UserId);

                subContractorViewModel.SubContractor = subContractorInfo.Data;
                subContractorViewModel.SubContractor.ElectronicConfirmPassword = subContractorViewModel.SubContractor.ElectronicSignPassword;
                subContractorViewModel.User = userInfo.Data;
                subContractorViewModel.Password = subContractorViewModel.User.Password;
                subContractorViewModel.ConfirmPassword = subContractorViewModel.User.Password;
                subContractorViewModel.SubContractor.ElectronicConfirmPassword = subContractorViewModel.SubContractor.ElectronicSignPassword;
                ViewBag.Password = subContractorViewModel.SubContractor.Password;
                ViewBag.ElectronicPassword = subContractorViewModel.SubContractor.ElectronicSignPassword;
                if (subContractorViewModel.SubContractor is null)
                {
                    ViewBag.SubContractorImage = string.Empty;
                    ViewBag.SubContractorSignatureImage = string.Empty;
                    ViewBag.WriteSignature = string.Empty;
                }
                else
                {
                    ViewBag.SubContractorImage = subContractorViewModel.SubContractor.SubContractorProfilePic;
                    ViewBag.SubContractorSignatureImage = subContractorViewModel.SubContractor.SignImage;
                    ViewBag.WriteSignature = subContractorViewModel.SubContractor.WriteSignature;
                    TempData["ProfileImage"] = subContractorViewModel.SubContractor.SubContractorProfilePic;
                }

                ViewBag.BtnSubmit = "Edit";
                ViewBag.ViewHeader = "Update SubContractor";
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                ViewBag.ViewHeader = "Add SubContractor";

            }
            var specialityList = _lookupService.lookupByTypeBasicDto("ProviderSpeciality");
            subContractorViewModel.SubContractorSpecialityList = specialityList.Data;
            var infoTitleList = _lookupService.lookupByTypeBasicDto("ProviderTitle");
            subContractorViewModel.SubContractorTitleList = infoTitleList.Data;
            var infoSuffixList = _lookupService.lookupByTypeBasicDto("ProviderSuffix");
            subContractorViewModel.SubContractorSuffixList = infoSuffixList.Data;
            var infoRentTypeList = _lookupService.lookupByTypeBasicDto("ProviderRentType");
            subContractorViewModel.SubContractorRentTypeList = infoRentTypeList.Data;
            var infoScannedDocumentList = _lookupService.lookupByTypeBasicDto("ScannedDocument");
            subContractorViewModel.SubContractorScannedDocumentsList = infoScannedDocumentList.Data;
            var infoStatusList = _lookupService.lookupByTypeBasicDto("ProviderStatus");
            subContractorViewModel.SubContractorStatusList = infoStatusList.Data;
            //ViewBag.BtnSubmit = "Save";
            return View(subContractorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SubContractorViewModel subContractorViewModel, string Signature, string profileImage)
        {
            if (subContractorViewModel.SubContractor.SubContractorId > 0)
            {
                var isExistdata = await _subContractorInfoService.CheckEmailExistOrNot(subContractorViewModel.SubContractor.Email, subContractorViewModel.SubContractor.UserId);
                if (isExistdata.Data)
                {
                    var message = new { Success = isExistdata.Message, IsError = true };
                    return Json(message);
                }
                var UpdateProfile = TempData["ProfileImage"];
                if (profileImage == "/images/" + UpdateProfile)
                {
                    subContractorViewModel.SubContractor.SubContractorProfilePic = subContractorViewModel.SubContractor.SubContractorProfilePic;
                }
                else if (profileImage == "/app-assets/images/user/male-user.png")
                {
                    subContractorViewModel.SubContractor.SubContractorProfilePic = null;
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
                    subContractorViewModel.SubContractor.SubContractorProfilePic = ProfileImageFile;
                    pic_memStream.Close();
                }

                if (Signature is null)
                {
                    subContractorViewModel.SubContractor.WriteSignature = subContractorViewModel.SubContractor.WriteSignature;
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
                    subContractorViewModel.SubContractor.WriteSignature = Signfilenames;
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
                        if (ControlName == "SubContractor.SignImage")
                        {
                            Signfile = filename;
                            if (subContractorViewModel.SubContractor.SignImage is null)
                            {
                                subContractorViewModel.SubContractor.SubContractorProfilePic = subContractorViewModel.SubContractor.SubContractorProfilePic;
                            }
                        }
                        if (ControlName == "SubContractor.SubContractorProfilePic")
                        {
                            patientfile = filename;
                            if (subContractorViewModel.SubContractor.SubContractorProfilePic is null)
                            {
                                subContractorViewModel.SubContractor.SignImage = subContractorViewModel.SubContractor.SignImage;
                            }
                        }
                    };
                    if (!string.IsNullOrEmpty(patientfile))
                    {

                        subContractorViewModel.SubContractor.SubContractorProfilePic = patientfile;

                    }

                    if (!string.IsNullOrEmpty(Signfile))
                    {

                        subContractorViewModel.SubContractor.SignImage = Signfile;

                    }

                }
                else if (files.Count == 0)
                {
                    subContractorViewModel.SubContractor.SignImage = subContractorViewModel.SubContractor.SignImage;

                }
                subContractorViewModel.User.UserId = subContractorViewModel.SubContractor.UserId;
                subContractorViewModel.User.Email = subContractorViewModel.SubContractor.Email;
                subContractorViewModel.User.Password = subContractorViewModel.Password;
                var SCupdate = await _subContractorInfoService.subContractorInfoUpdate(subContractorViewModel.SubContractor);
                //var userUpdate = await _userService.userInfoUpdate(subContractorViewModel.User);
                var data = new { Success = "Data updated successfully" };
                return Json(data);
            }
            else
            {
                if (subContractorViewModel.User.UserId == 0)
                {
                    var isExistdata = await _subContractorInfoService.CheckEmailExistOrNot(subContractorViewModel.SubContractor.Email, null);
                    if (isExistdata.Data)
                    {
                        var message = new { Success = isExistdata.Message, IsError = true };
                        return Json(message);
                    }

                    subContractorViewModel.User.RoleTypeId = 2;
                    subContractorViewModel.User.Email = subContractorViewModel.SubContractor.Email;
                    subContractorViewModel.User.Password = subContractorViewModel.Password;
                    var userforce = await _userService.userInfoCreate(subContractorViewModel.User);
                    subContractorViewModel.SubContractor.UserId = userforce.Data.UserId;
                }
                else
                {
                    subContractorViewModel.SubContractor.UserId = subContractorViewModel.User.UserId;
                }
                if (profileImage == "/app-assets/images/user/male-user.png")
                {
                    subContractorViewModel.SubContractor.SubContractorProfilePic = null;
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
                    subContractorViewModel.SubContractor.SubContractorProfilePic = ProfileImageFile;
                    pic_memStream.Close();
                }

                if (Signature is null)
                {

                    var Signfilenames = "Empty.png";

                    subContractorViewModel.SubContractor.WriteSignature = Signfilenames;

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
                    subContractorViewModel.SubContractor.WriteSignature = Signfilename;
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
                        if (ControlName == "SubContractor.SignImage")
                        {
                            Signfile = filename;
                        }
                        if (ControlName == "SubContractor.SubContractorProfilePic")
                        {
                            patientfile = filename;
                        }
                    };
                    if (!string.IsNullOrEmpty(patientfile))
                    {

                        subContractorViewModel.SubContractor.SubContractorProfilePic = patientfile;

                    }

                    if (!string.IsNullOrEmpty(Signfile))
                    {

                        subContractorViewModel.SubContractor.SignImage = Signfile;

                    }

                }
                var SubContractorAdded = await _subContractorInfoService.subContractorInfoCreate(subContractorViewModel.SubContractor);
                var subContractorInfoId = SubContractorAdded.Data.SubContractorId;
                var data = new { SubContractorUserId = subContractorViewModel.SubContractor.UserId, SubContractorInfoId = subContractorInfoId, Success = "Data saved successfully" };
                return Json(data);
            }
        }


        private string GetFullPath(string filename)
        {
            return this._webHostEnvironment.WebRootPath + "\\images\\" + filename;
        }

        public async Task<IActionResult> SubContractorInfoDelete(int subcontractorInfoId)
        {
            var ProviderById = await _subContractorInfoService.subContractorInfoDeleteById(subcontractorInfoId);
            return RedirectToAction("Subcontractors", "SubContractor");
        }
    }
}
