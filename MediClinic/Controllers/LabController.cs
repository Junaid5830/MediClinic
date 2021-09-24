using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.LabInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediClinic.Controllers
{
    public class LabController : Controller
    {
        private readonly ILogger<ImagingController> _logger;
        private ISessionManager _sessionManager;
        private ILabService _labService;
        private LabViewModel labViewModel;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly MediClinicContext _context;

        public LabController(
            ILogger<ImagingController> logger,
            ISessionManager sessionManager, ILabService labService, MediClinicContext context,
            IHttpContextAccessor contextAccessor
            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _labService = labService;
            labViewModel = new LabViewModel();
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public async Task<IActionResult> LabList(long? Id)
        {
            var roleId = _sessionManager.GetRoleId();
            var PatientId = _sessionManager.GetPatientInfoId();
            if (roleId == 1)
            {
                labViewModel.getLabList = await _labService.GetLabListByVisits(PatientId);

            }
            else
            {
                if (PatientId == 0)
                {
                    labViewModel.getLabList = await _labService.GetLabList();

                }
                else
                {
                    labViewModel.getLabList = await _labService.GetLabListByVisits(PatientId);

                }
            }
            return View(labViewModel);
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            labViewModel.labDto = _labService.GetLabById(id);
            return View(labViewModel);
        }
        [HttpPost]
        public IActionResult Add(LabViewModel labViewModel)
        {
            var VisitID = _sessionManager.GetVisitId();
            labViewModel.labDto.VisitId = VisitID;
            _labService.Add (labViewModel.labDto);
            var PatientId = _sessionManager.GetPatientInfoId();
            return RedirectToAction("LabList", "Lab",new { Id = PatientId });
        }
        public IActionResult Delete(int LabId)
        {
            var Id = _labService.Delete(LabId);
            var PatientId = _sessionManager.GetPatientInfoId();
            return RedirectToAction("LabList", "Lab", new { Id = PatientId });
        }
    }
}
