using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Filters;
using MediClinic.Models;
using MediClinic.Services.Interfaces.AllergyInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MedliClinic.Utilities.Utility.Enum;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediClinic.Controllers
{
	public class AllergyController : Controller
	{
		private readonly ILogger<AllergyController> _logger;
		private IAllergyService _allergyService;
		private ISessionManager _sessionManager;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public AllergyController(ILogger<AllergyController> logger,IAllergyService allergyService,ISessionManager sessionManager)
		{
			_logger = logger;
			_allergyService = allergyService;
			_sessionManager = sessionManager;
		}
		[HttpGet]
		public async Task<IActionResult> Add(long? Id)
		{
			var PatientId = _sessionManager.GetPatientInfoId();
			AllergyViewModel allergyViewModel = new AllergyViewModel();
			allergyViewModel.AlergyTypeList = await _allergyService.AllergyListByVisits((long)PatientId);
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AllergyType(AllergyViewModel allergyViewModel)
		{
			try
			{
				var VisitId = _sessionManager.GetVisitId();
				var UserId = Convert.ToInt32(_sessionManager.GetUserId());
				allergyViewModel.AlergyType = new Models.DTOs.AllergyTypeDto();
				allergyViewModel.AlergyType.Name = allergyViewModel.Allergies.Name;

				allergyViewModel.AlergyType.VisitId = VisitId;
				allergyViewModel.AlergyType.CreatedBy = UserId;
				allergyViewModel.AlergyType.CreatedOn = DateTime.Now;

				var allergyAdded = await _allergyService.allergyTypeCreate(allergyViewModel.AlergyType);
				var AllergyTypeId = allergyAdded.Data.AllergyTypeId;
				var data = new { AllergyTypeId = AllergyTypeId, Success = "Data saved successfully" };
				return Json(data);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		[HttpPost]
		public async Task<IActionResult> Add(AllergyViewModel allergyViewModel)
		{
			try
			{
				
				allergyViewModel.Allergy = new Models.DTOs.AllergyDto();
				allergyViewModel.Allergy.Name = allergyViewModel.Allergies.Name;
				allergyViewModel.Allergy.AllergyTypeId = allergyViewModel.Allergies.ForiegnId;
				allergyViewModel.Allergy.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
				allergyViewModel.Allergy.CreatedOn = DateTime.Now;
				
				var allergyAdded = await _allergyService.allergyCreate(allergyViewModel.Allergy);
				
				var data = new { Success = "Data saved successfully" };
				return Json(data);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<IActionResult> List(long? Id)
		{
			AllergyViewModel allergyViewModel = new AllergyViewModel();
			var RoleId = _sessionManager.GetRoleId();
			var PatientId = _sessionManager.GetPatientInfoId();
			//         if (RoleId == 5 || RoleId == 2)
			//         {
			//	allergyViewModel.AlergyList = await _allergyService.GetAllergyList();
			//	allergyViewModel.AlergyTypeList = await _allergyService.GetAllergyTypeListForVIsit((int)Id);
			//}
			//         else
			//         {
			//	allergyViewModel.AlergyList = await _allergyService.GetAllergyList();
			//	allergyViewModel.AlergyTypeList = await _allergyService.GetAllergyTypeList();
			//}
			allergyViewModel.AlergyTypeList = await _allergyService.AllergyListByVisits(PatientId);
			return Json(allergyViewModel);
		}

		public async Task<IActionResult> DeleteAllergy(int Id)
		{
			var ProviderById = await _allergyService.DeleteAllergy(Id);
			var data = new { Success = "Data saved successfully" };
			return Json(data);
		}
	}
}

