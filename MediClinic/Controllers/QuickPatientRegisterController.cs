using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using MediClinic.Services.Interfaces.PatientPhoneNumberInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Controllers
{
    public class QuickPatientRegisterController : Controller
    {
        private readonly ILogger<QuickPatientRegisterController> _logger;
        private readonly IPatientInfoService _patientInfoService;
        private IPatientPhoneNumberService _patientPhoneNumberService;
        public QuickPatientRegisterController(ILogger<QuickPatientRegisterController> logger,IPatientInfoService patientInfoService, IPatientPhoneNumberService patientPhoneNumberService)
        {
            _logger = logger;
            _patientInfoService = patientInfoService;
            _patientPhoneNumberService = patientPhoneNumberService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> QuickRegister(QuickRegisterPatientDto quickRegister)
        {
            bool isErorr = false;
            var rec = await _patientInfoService.QuickRegisterPatient(quickRegister);
            if (rec.Id == 0)
            {
                isErorr = true;
            }
            var data = new { Data = rec, isError= isErorr };
            return Json(data);
        }


    }
}
