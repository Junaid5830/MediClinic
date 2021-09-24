using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.ClinicalReminderInterface;
using MediClinic.Services.Interfaces.DepartmentsInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Controllers
{
    public class ClinicalReminderController : Controller
    {
        private readonly ILogger<ClinicalReminderController> _logger;
        private ISessionManager _sessionManager;
        private IClinicalReminderService _clinicalReminderService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ClinicalReminderController(ILogger<ClinicalReminderController> logger,ISessionManager sessionManager, IClinicalReminderService clinicalReminderService,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _clinicalReminderService = clinicalReminderService;
            _webHostEnvironment = webHostEnvironment;
        }
        public ILogger<ClinicalReminderController> Logger => _logger;

        public async Task<IActionResult> Index(long? Id)
        {
            List<ClinicalReminderDto> list = new List<ClinicalReminderDto>();
            list = await _clinicalReminderService.ClinicalReminderListbyVists((long)Id);
            //list = _clinicalReminderService.getlist();
            return View(list);
        }
        public IActionResult Add(int id)
        {
            ClinicalReminderDto clinicalreminder = _clinicalReminderService.GetClinicalReminderById(id);
            return View(clinicalreminder);
        }
        [HttpPost]
        public IActionResult Add(ClinicalReminderDto Pobj)
        {
            var fileResult = UploadFile(Pobj.file, Path.Combine(_webHostEnvironment.WebRootPath, CommonMethod.ClinicalImg), CommonMethod.ClinicalImg);
            var VisitId = _sessionManager.GetVisitId();
            Pobj.Reminder_By = fileResult;
            Pobj.VisitId = VisitId;
            _clinicalReminderService.Add(Pobj);
            var PatientId = _sessionManager.GetPatientInfoId();
            return RedirectToAction("Index",new { Id = PatientId});
        }
        public IActionResult Delete(int clinicID)
        {
            var Id = _clinicalReminderService.Delete(clinicID);
            return Json(Id);
        }
        public IActionResult ClinicView(int id)
        {
            ClinicalReminderDto Clinic = _clinicalReminderService.GetClinicalReminderById(id);
            return View(Clinic);
        }
        
        public static string UploadFile(IFormFile file, string uploadsFolder, string folderpath)
        {
            string filePath = string.Empty;
            string imagePath = string.Empty;
            string datatime = DateTime.Now.ToString("MMddyyyyHHmmss");
            if (file != null)
            {
                filePath = Path.Combine(uploadsFolder, Path.GetFileNameWithoutExtension(file.FileName) + datatime + Path.GetExtension(file.FileName));
                if (!System.IO.File.Exists(filePath))
                {
                    file.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                imagePath = "/" + folderpath + "/" + Path.GetFileNameWithoutExtension(file.FileName) + datatime + Path.GetExtension(file.FileName);
            }
            return imagePath;
        }
    }
}
