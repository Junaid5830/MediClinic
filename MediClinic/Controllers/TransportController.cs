using MediClinic.Models;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.TransportEmsInterface;
using MediClinic.Utility;
using MedliClinic.Utilities.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Controllers
{
    public class TransportController : Controller
    {
        private readonly ILogger<TransportController> _logger;
        private ISessionManager _sessionManager;
        private ITransportEmsService _TransportEmsService;
        private ILookupService _lookupService;
        private IDriverService _driverService;
        private readonly IPatientInfoService _patientInfoService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TransportController(
            ILogger<TransportController> logger,
            ISessionManager sessionManager,
            ITransportEmsService TransportEmsService,
            ILookupService lookupService,
            IDriverService driverService,
            IPatientInfoService patientInfoService,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _TransportEmsService = TransportEmsService;
            _lookupService = lookupService;
            _driverService = driverService;
            _patientInfoService = patientInfoService;
            _webHostEnvironment = webHostEnvironment;
        }

        public ILogger<TransportController> Logger => _logger;
        public IActionResult Index()
        {
            TransportViewModel vm = new TransportViewModel();
            vm.TransportList = _TransportEmsService.getlist();
            return View(vm);
        }
        public async Task<IActionResult> Add(int id)
        {
            TransportEmsDTO TransportEms = await _TransportEmsService.GetTransportById(id);
            return View(TransportEms);
        }


        public IActionResult Delete(int transportId)
        {
            var Id = _TransportEmsService.Delete(transportId);
            return Json(Id);
        }
        public async Task<IActionResult> TransportView(int id)
        {
            TransportEmsDTO TransportEms = await _TransportEmsService.GetTransportById(id);
            return View(TransportEms);
        }


        public async Task<IActionResult> TransportAndDriver(int? Id)
        {
            TransportViewModel transportViewModel = new TransportViewModel();
            var DriverList = await _TransportEmsService.GetDriverDetailList();
            transportViewModel.TransportList = _TransportEmsService.getlist();
            transportViewModel.DriverList = DriverList.Data;
            var AvailableDriver = await _TransportEmsService.AvailableDriverListForResptionisit();
            transportViewModel.DriverListForAssign = AvailableDriver.Data;
            var DiverJobStatus = await _TransportEmsService.AvailableDriverJobStatus();
            transportViewModel.DriverJobStatus = DiverJobStatus.Data;
            var DriverJobRequestStatus = await _TransportEmsService.DriverJobRequestStatus();
            transportViewModel.DriverJobRequestStatus = DriverJobRequestStatus.Data;
            var DriverListDrop = await _TransportEmsService.SelectDriversForDropDow();
            transportViewModel.DriversDropDownList = DriverListDrop.Data;
            transportViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();

            return View(transportViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> PatientDetails(long PatientId)
        {
            var patientRec = await _patientInfoService.PatientDetails(PatientId);
            if (patientRec.AddressLine2 is null)
            {
                patientRec.AddressLine2 = string.Empty;
            }
            if (patientRec.AddressLine3 is null)
            {
                patientRec.AddressLine3 = string.Empty;
            }
            return Json(patientRec);
        }
        public async Task<IActionResult> TransportAdd(int? Id)
        {
            var transportViewModel = new TransportViewModel();
            transportViewModel.VehicleTypeList = _TransportEmsService.SelectListForVehicleType();
            transportViewModel.VehicleMakeList = _TransportEmsService.SelectSelectListForVehicleMake();
            transportViewModel.VehicleModelList = _TransportEmsService.SelectListForVehicleModel();
            if (Id > 0)
            {
                transportViewModel.Transport =await _TransportEmsService.GetTransportById((int)Id);
                transportViewModel.Transport.vehicleAttchments = _TransportEmsService.GetVehicleAttachmentsById((int)Id);
                ViewBag.Action = "Update";

                if (transportViewModel.Transport.VehiclePhoto is null)
                {
                    ViewBag.VehiclePhoto = string.Empty;

                }
                else
                {
                    TempData["DriverImage"] = transportViewModel.Transport.VehiclePhoto;

                    ViewBag.VehiclePhoto = transportViewModel.Transport.VehiclePhoto;

                }
                if (transportViewModel.Transport.RegistrationDocuments is null)
                {
                    ViewBag.RegistrationDocument = string.Empty ;

                }
                else
                {

                    TempData["Vehicle"] = transportViewModel.Transport.RegistrationDocuments;
                    ViewBag.RegistrationDocument = transportViewModel.Transport.RegistrationDocuments;
                }
                if(!(transportViewModel.Transport.vehicleAttchments is null))
                {
                    ViewBag.Attachments = transportViewModel.Transport.vehicleAttchments;
                }
                else
                {
                    ViewBag.Attachments = "";
                }
            }
            else
            {
                ViewBag.Action = "AddNew";
                ViewBag.LatestVehicleId = _TransportEmsService.GetMaxLatestVehicle();
            }
            
            return View(transportViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> TransportAdd(TransportViewModel ViewModel, string profileImage)
        {
            

            if (ViewModel.Transport.TransportId > 0)
            {
                var document = TempData["Vehicle"];
                if (ViewModel.Transport.RegistrationDocuments == document)
                {
                    ViewModel.Transport.RegistrationDocuments = ViewModel.Transport.RegistrationDocuments;
                }
                else
                {
                    if (ViewModel.Transport.File != null)
                    {
                        var RegistrationDoc = await AzureBlobHandler.Upload(ViewModel.Transport.File);
                        ViewModel.Transport.RegistrationDocuments = RegistrationDoc;

                    }
                }
            
                var PhotoPath = TempData["DriverImage"];
                if (profileImage == "/images/" + PhotoPath)
                {
                    ViewModel.Transport.VehiclePhoto = (string)PhotoPath;
                }
                else if (profileImage == "/app-assets/images/user/male-user.png")
                {
                    ViewModel.Transport.VehiclePhoto = null;
                }
                else
                {
                    ViewModel.Transport.VehiclePhoto = profileImage.GetImageUrl("wwwroot\\Images");
                }

                if (ViewModel.Transport.Attachments.Length > 0)
                {
                    foreach (var item in ViewModel.Transport.Attachments)
                    {
                        var attachment = new VehicleAttchmentsDto();
                        attachment.Url = await AzureBlobHandler.UploadAttachments(item);
                        ViewModel.Transport.vehicleAttchments.Add(attachment);
                    }

                }
                ViewModel.Transport.ModifiedBy = _sessionManager.GetUserId();
                var rec = await _TransportEmsService.AddTransport(ViewModel.Transport);

            }
            else
            {
                var isExisitVehicle = await _TransportEmsService.VehicleNumberExist(ViewModel.Transport.VehicleLicencePlateNo);
                if (isExisitVehicle.Data)
                {
                    var data = new { Message = isExisitVehicle.Message, IsError = true };
                    return Json(data);

                }
                var fileName = "";
                if (ViewModel.Transport.File != null)
                {
                    var RegistrationDoc = await AzureBlobHandler.Upload(ViewModel.Transport.File);
                    ViewModel.Transport.RegistrationDocuments = RegistrationDoc;

                }
                if (ViewModel.Transport.Attachments.Length > 0)
                {
                    foreach (var item in ViewModel.Transport.Attachments)
                    {
                        var attachment = new VehicleAttchmentsDto();
                        attachment.Url = await AzureBlobHandler.UploadAttachments(item);
                        ViewModel.Transport.vehicleAttchments.Add(attachment);
                    }

                }
                //upload files to wwwroot
                //    fileName = Path.GetFileName(ViewModel.Transport.File.FileName);
                //    //judge if it is pdf file
                //    string ext = Path.GetExtension(ViewModel.Transport.File.FileName);

                //    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Files", fileName);

                //    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                //    {
                //        await ViewModel.Transport.File.CopyToAsync(fileSteam);
                //    }
                //}
                var PicturePath = "";
                if (!(profileImage is null))
                {
                    if(profileImage== "/app-assets/images/user/male-user.png")
                    {
                        PicturePath = null;
                    }
                    else
                    {
                        PicturePath = profileImage.GetImageUrl("wwwroot\\Images");
                    }
                    
                }

                ViewModel.Transport.VehiclePhoto = PicturePath;
                ViewModel.Transport.CreatedBy = _sessionManager.GetUserId();

                var rec = await _TransportEmsService.AddTransport(ViewModel.Transport);


            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DriverAdd(int? Id)
        {
            TransportViewModel transportViewModel = new TransportViewModel();
            if (Id > 0)
            {
                transportViewModel.DriverDto = await _TransportEmsService.GetDriveById((int)Id);
                transportViewModel.DriverDto.IsOwnVehicleHidden = (bool)transportViewModel.DriverDto.IsOwnVehicle;
                ViewBag.Password = transportViewModel.DriverDto.Password;
                ViewBag.Action = "Update";
                TempData["IsOwn"] = (bool)transportViewModel.DriverDto.IsOwnVehicle;
                TempData["OldVehicleId"] = transportViewModel.DriverDto.TransportId;
                if (!(transportViewModel.DriverDto.Languages is null))
                {
                    transportViewModel.DriverDto.DriverLanguageList = transportViewModel.DriverDto.Languages.Split(",");

                }
                transportViewModel.DriverDto.TransportIdHidden = transportViewModel.DriverDto.TransportId;
                //for Update Case

                if (!(transportViewModel.DriverDto.IsOwnVehicle is null))
                {
                    if ((bool)transportViewModel.DriverDto.IsOwnVehicle)
                    {
                    

                        transportViewModel.Transport = await _TransportEmsService.GetTransportById((int)transportViewModel.DriverDto.TransportId);
                        transportViewModel.Transport.vehicleAttchments = _TransportEmsService.GetVehicleAttachmentsById((int)Id);
                        transportViewModel.DriverDto.IsOwnVehicleHidden = (bool)transportViewModel.DriverDto.IsOwnVehicle;
                        if (transportViewModel.Transport.VehiclePhoto is null)
                        {
                            ViewBag.TransportPhoto = string.Empty;
                        }
                        else
                        {
                            TempData["TransportPhoto"] = transportViewModel.Transport.VehiclePhoto;
                        }
                    }

                }
                else
                {
                    ViewBag.TransportPhoto = string.Empty;
                }

                if (transportViewModel.DriverDto.DriverSignature is null)
                {
                    ViewBag.WriteSignature = string.Empty;

                }
                else
                {
                    ViewBag.WriteSignature = transportViewModel.DriverDto.DriverSignature;

                }
                if (transportViewModel.DriverDto.DriverImage is null)
                {
                    ViewBag.PatientImage = string.Empty;

                }
                else
                {
                    TempData["DriverImage"] = transportViewModel.DriverDto.DriverImage;

                    ViewBag.PatientImage = transportViewModel.DriverDto.DriverImage;

                }
            }
            else
            {
                ViewBag.Action = "Add New";
            }
            transportViewModel.VehicleTypeList = _TransportEmsService.SelectListForVehicleType();
            transportViewModel.VehicleMakeList = _TransportEmsService.SelectSelectListForVehicleMake();
            transportViewModel.VehicleModelList = _TransportEmsService.SelectListForVehicleModel();
            transportViewModel.patientLanguageList = _TransportEmsService.SelectListForLangauges();
            transportViewModel.VehiclesListForDropDown = _TransportEmsService.VehiclesListForDropDown();

            var GenderList = await _lookupService.LookupDtolist("Gender");
            transportViewModel.gender = GenderList.Data;
            return View(transportViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> DriverAdd(TransportViewModel transportViewModel, string Signature, string profileImage, string[] language, string transportImage)
        {
            bool isExistdata = false;
            if (transportViewModel.DriverDto.DriverId == 0)
            {
              
               var data = await _TransportEmsService.EmailisExistorNot(transportViewModel.DriverDto.Email);
                isExistdata = data.Data;

                if (isExistdata)
                {
                    var dataObj = new { Error = data.Message, IsError = true };
                    return Json(dataObj);
                }
            }

            transportViewModel.DriverDto.IsOwnVehicle = transportViewModel.DriverDto.IsOwnVehicleHidden;
            if (transportViewModel.DriverDto.DriverId > 0)
            {
                var PhotoPath = TempData["DriverImage"];
                if (profileImage.Equals(PhotoPath.ToString()))
                {
                    transportViewModel.DriverDto.DriverImage = (string)PhotoPath;
                }
                else if (profileImage == "/app-assets/images/user/male-user.png")
                {
                    transportViewModel.DriverDto.DriverImage = null;
                }
                else
                {
                    transportViewModel.DriverDto.DriverImage = await AzureBlobHandler.UploadBase64(profileImage);
                }
                if (Signature is null)
                {
                    transportViewModel.DriverDto.DriverSignature = transportViewModel.DriverDto.HiddenSign;
                }
                else
                {
                    transportViewModel.DriverDto.DriverSignature = await AzureBlobHandler.UploadBase64(Signature);
                }
                if (transportViewModel.DriverDto.IsOwnVehicleHidden == true)
                {

                    var TransportPhoto = TempData["TransportPhoto"];
                    if (transportImage == "/images/" + PhotoPath)
                    {
                        transportViewModel.Transport.VehiclePhoto = (string)TransportPhoto;
                    }
                    else if (transportImage == "/app-assets/images/user/male-user.png")
                    {
                        transportViewModel.Transport.VehiclePhoto = null;
                    }
                    else
                    {
                        transportViewModel.Transport.VehiclePhoto = await AzureBlobHandler.UploadBase64(transportImage);
                    }
                    if (transportViewModel.Transport.Attachments.Length > 0)
                    {
                        foreach (var item in transportViewModel.Transport.Attachments)
                        {
                            var attachment = new VehicleAttchmentsDto();
                            attachment.Url = await AzureBlobHandler.UploadAttachments(item);
                            transportViewModel.Transport.vehicleAttchments.Add(attachment);
                        }

                    }
                    
                    var transport = _TransportEmsService.AddTransport(transportViewModel.Transport);

                    transportViewModel.DriverDto.TransportId = transport.Result.Data.TransportId;
                    await _TransportEmsService.DriveUpdate(transportViewModel.DriverDto, language);
                }
                else
                {
                    if(transportViewModel.DriverDto.TransportId is null)
                    {
                        transportViewModel.DriverDto.TransportId = transportViewModel.DriverDto.TransportIdHidden;
                    }
                    
                   
                    if ((bool)TempData["IsOwn"])
                    {
                        var oldVehicle = (int)TempData["OldVehicleId"];
                        if (transportViewModel.DriverDto.TransportId != oldVehicle)
                        {
                            var vehicleID = oldVehicle;
                            _TransportEmsService.Delete(oldVehicle);
                        }
                    }
                    await _TransportEmsService.DriveUpdate(transportViewModel.DriverDto, language);
                }

            }
            else
            {
                var SignaturePath = "";
                var PicturePath = "";
                if (!(Signature is null))
                {
                    SignaturePath = await AzureBlobHandler.UploadBase64(Signature);
                }
                if (profileImage == "/app-assets/images/user/male-user.png")
                {
                    transportViewModel.DriverDto.DriverImage = null;
                }
                else
                {
                    PicturePath = await AzureBlobHandler.UploadBase64(profileImage);

                    //PicturePath = profileImage.GetImageUrl("wwwroot\\Images");
                }
                transportViewModel.DriverDto.DriverSignature = SignaturePath;
                transportViewModel.DriverDto.DriverImage = PicturePath;
                transportViewModel.DriverDto.IsActive = true;
                if (transportViewModel.DriverDto.IsOwnVehicleHidden == true)
                {
                    var isExisitVehicle = await _TransportEmsService.VehicleNumberExist(transportViewModel.Transport.VehicleLicencePlateNo);
                    if (isExisitVehicle.Data)
                    {

                        var data = new { Error = isExisitVehicle.Message, IsError = true };
                        return Json(data);

                    }
                    
                    var VehicleImage = "";
                    if (transportImage == "/app-assets/images/user/male-user.png")
                    {
                        VehicleImage = null;
                    }
                    else
                    {
                        VehicleImage = await AzureBlobHandler.UploadBase64(transportImage);
                    }
                    if (transportViewModel.Transport.Attachments.Length > 0)
                    {
                        foreach (var item in transportViewModel.Transport.Attachments)
                        {
                            var attachment = new VehicleAttchmentsDto();
                            attachment.Url = await AzureBlobHandler.UploadAttachments(item);
                            transportViewModel.Transport.vehicleAttchments.Add(attachment);
                        }
                      
                    }
                    
                    transportViewModel.Transport.VehiclePhoto = VehicleImage;
                    var transport = _TransportEmsService.AddTransport(transportViewModel.Transport);
                   
                    transportViewModel.DriverDto.TransportId = transport.Result.Data.TransportId;
                    await _TransportEmsService.DriveCreate(transportViewModel.DriverDto, language);
                }
                else
                {
                    
                    var rec = await _TransportEmsService.DriveCreate(transportViewModel.DriverDto, language);
                }



            }

            var message = new { Success = "Successfully", IsError = false };
            return Json(message);
           

        }

        public async Task<IActionResult> ChangeDriverStatus(int Id, bool status)
        {
            var rec = _TransportEmsService.ChangeDriverStatus(Id,status);
            TransportViewModel transportViewModel = new TransportViewModel();
            var DriverList = await _TransportEmsService.GetDriverDetailList();
            transportViewModel.DriverList = DriverList.Data;
            return PartialView("~/Views/Transport/PartialViews/_DriverActiveInActive.cshtml", transportViewModel);
        }
        public IActionResult AmbulanceDelete(int Id)
        {
            var rec = _TransportEmsService.AmbulanceDelete(Id);
            return Json(rec);
        }
        public async Task<IActionResult> AddVehicleType(TransportViewModel viewModel)
        {
            var response = await _TransportEmsService.AddVehicleType(viewModel.VehicleType);
            var data = new { Data = response.Data };
            return Json(data);
        }

        public async Task<IActionResult> AddVehicleMake(TransportViewModel viewModel)
        {
            var response = await _TransportEmsService.AddVehicleMake(viewModel.VehicleMake);
            var data = new { Data = response.Data };
            return Json(data);
        }
        public async Task<IActionResult> AddVehicleModel(TransportViewModel viewModel)
        {
            var response = await _TransportEmsService.AddVehicleModel(viewModel.VehicleModel);
            var data = new { Data = response.Data };
            return Json(data);
        }
        public async Task<IActionResult> AssignDriverToLocation(int? Id)
        {
            TransportViewModel viewModel = new TransportViewModel();
            var AvailableDriver = await _TransportEmsService.AvailableDriverListForResptionisit();
            viewModel.DriverListForAssign = AvailableDriver.Data;
            var DriverListDrop = await _TransportEmsService.SelectDriversForDropDow();
            viewModel.DriversDropDownList = DriverListDrop.Data;
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AssignDriverToLocation(TransportViewModel viewModel)
        {
            await _TransportEmsService.AssignDriverToPickUpPoint(viewModel.driverJobRequestDto, _sessionManager.GetEmployeeName());
            var AvailableDriver = await _TransportEmsService.AvailableDriverListForResptionisit();
            viewModel.DriverListForAssign = AvailableDriver.Data;
            var DriverListDrop = await _TransportEmsService.SelectDriversForDropDow();
            viewModel.DriversDropDownList = DriverListDrop.Data;
            return PartialView("~/Views/Transport/PartialViews/_DriverAvailability.cshtml", viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> DriverJobCurrentStatus(int Id)
        {
            if (Id == 0)
            {
                return Json("Error");
            }
            else
            {
                var rec = await _driverService.GetDriverLatestJob(Id);
                if (!(rec.Data is null))
                {
                    return Json(rec.Data.CurrentStatus);

                }
                else
                {
                    return Json(rec.Data);
                }
            }
        
        }
        public IActionResult Test(int? Id)
        {
            if (Id > 0)
            {
                ViewBag.Action = "Update";
            }
            return View();
        }
        [HttpPost]
        public IActionResult Test(string PhotoPath)
        {

            return View();
        }

        public async Task<IActionResult> GetProfileById(int driverId)
        {
            TransportViewModel viewModel = new TransportViewModel();
            var data = await _TransportEmsService.GetDriverDetailById(driverId);
            viewModel.profileWithTransport = data.Data;
            return PartialView("~/Views/Transport/PartialViews/_DriverDetail.cshtml", viewModel);
        }

        public async Task<IActionResult> GetTransportById(int transportId)
        {
            TransportViewModel viewModel = new TransportViewModel();
            var data = await _TransportEmsService.GetTransportDetailsId(transportId);
            viewModel.VehicleDetailDto = data;
            return PartialView("~/Views/Transport/PartialViews/_VehicleDetail.cshtml", viewModel);
        }
        private string GetFullPath(string filename)
        {
            return this._webHostEnvironment.WebRootPath + "\\images\\" + filename;
        }
    }
}
