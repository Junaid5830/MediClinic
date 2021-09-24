using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Utility;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    public class AdministrativeSettingsController : Controller
    {
        private readonly ISessionManager _sessionManager;
        private readonly IAdministrativeService _administrativeService;

        public AdministrativeSettingsController(ISessionManager sessionManager, IAdministrativeService administrativeService)
        {
            _sessionManager = sessionManager;
            _administrativeService = administrativeService;
        }
        public async Task<IActionResult> Index()
        {
           var list = await _administrativeService.AdministrativeList();
            return View(list);
        }

        public async Task<IActionResult> AddAdministrative(int? Id)
        {
            AdministrativeDto administrativeDto = new AdministrativeDto();
            if (!(Id is null))
            {
                ViewBag.Action = "Update";
                administrativeDto = await _administrativeService.GetAdministrativeById((int)Id);
                if (administrativeDto.Signature is null)
                {
                    ViewBag.WriteSignature = string.Empty;

                }
                else
                {
                    ViewBag.WriteSignature = administrativeDto.Signature;

                }
                if (administrativeDto.Photo is null)
                {
                    ViewBag.PatientImage = string.Empty;

                }
                else
                {
                    TempData["ProfileImage"] = administrativeDto.Photo;

                    ViewBag.PatientImage = administrativeDto.Photo;

                }
            }
           
            return View(administrativeDto);
        }
        [HttpPost]
        public IActionResult AddAdministrative(AdministrativeDto administrativeDto, string Signature, string profileImage)
        {
            if (administrativeDto.AdministrativeID > 0)
            {
                var PhotoPath = TempData["ProfileImage"];
                if (profileImage == "/images/" + PhotoPath)
                {
                    administrativeDto.Photo = profileImage;
                }
                else if (profileImage == "/app-assets/images/user/male-user.png")
                {
                    administrativeDto.Photo = null;
                }
                else
                {
                    administrativeDto.Photo = profileImage.GetImageUrl("wwwroot\\Images");
                }
                if (Signature is null)
                {
                    administrativeDto.Signature = administrativeDto.HiddenSign;
                }
                else
                {
                    administrativeDto.Signature = Signature.GetImageUrl("wwwroot\\SignatureImages");
                }
                var update = _administrativeService.AddAdministrative(administrativeDto);
            }
            else
            {
                var SignaturePath = "";
                var PicturePath = "";
                if (!(Signature is null))
                {
                    SignaturePath = Signature.GetImageUrl("wwwroot\\SignatureImages");
                }
                if (!(profileImage is null))
                {
                    PicturePath = profileImage.GetImageUrl("wwwroot\\Images");
                }
                administrativeDto.Signature = SignaturePath;
                administrativeDto.Photo = PicturePath;
                var rec = _administrativeService.AddAdministrative(administrativeDto);
                
            }
            var message = new { Success = true};
            return Json(message);
        }
        public async Task<IActionResult> PatientInfoDelete(int Id)
        {
            var PatById = await _administrativeService.DeleteAdministrative(Id);
            //return RedirectToAction("PatientList", "PatientSide");
            return Json(PatById);
        }
    }
}