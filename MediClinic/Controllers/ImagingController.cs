using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ImagingInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediClinic.Controllers
{
    public class ImagingController : Controller
    {
        private readonly ILogger<ImagingController> _logger;
        private ISessionManager _sessionManager;
        private IImagingService _imagingService;
        private ImagingViewModel imagingViewModel;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly MediClinicContext _context;

        public ImagingController(
            ILogger<ImagingController> logger,
            ISessionManager sessionManager, IImagingService imagingService, MediClinicContext context,
            IHttpContextAccessor contextAccessor
            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _imagingService = imagingService;
            imagingViewModel = new ImagingViewModel();
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public async Task<IActionResult> Index(long? Id)
        {
            //imagingViewModel.getImagingDto = await _imagingService.GetImagingList();
            imagingViewModel.getImagingDto = await _imagingService.GetImagingListByVisits((long)Id);
            return View(imagingViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            imagingViewModel.imagingDto = _imagingService.GetImagingById(id);
            imagingViewModel.patientInfoBasicDto = await _imagingService.GetlistofPatients();
            return View(imagingViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ImagingViewModel imagingViewModel) 
        {
            var VisitId = _sessionManager.GetVisitId();
            imagingViewModel.imagingDto.VisitId = VisitId;
            await _imagingService.Add(imagingViewModel.imagingDto);
            var PatientId = _sessionManager.GetPatientInfoId();
            return RedirectToAction("Index","Imaging",new {Id = PatientId});
        }

        public IActionResult Delete(int imgId)
        {
            var Id = _imagingService.Delete(imgId);
            var PatientId = _sessionManager.GetPatientInfoId();
            return RedirectToAction("Index", "Imaging", new { Id = PatientId });
        }
    }
}
