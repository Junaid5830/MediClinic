using MediClinic.Models;
using MediClinic.Services.Interfaces.DMEInterface;
using MediClinic.Services.Interfaces.InsuranceCompaniesInterface;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.PatientAppointmentInterface;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using MediClinic.Services.Interfaces.PatientsDmePrescription;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Controllers
{
    public class PatientsDmePrescriptionsController : Controller
    {
        private readonly ILogger<PatientsDmePrescriptionsController> _logger;
        private ISessionManager _sessionManager;
        private IDMEService _DMEService;
        private ILookupService _lookupService;
        private IPatientsDmePrescriptions _patientsDmeService;
        private IProviderInfoService _providerInfoService;
        private IPatientInfoService _patientInfoService;
        private IPatientAppointmentService _patientAppointmentService;
        private IInsuranceCompanies _insurenceCompanies;
        public PatientsDmePrescriptionsController(
            ILogger<PatientsDmePrescriptionsController> logger,
            ISessionManager sessionManager,
            IDMEService DMEService,
            ILookupService lookupService,
            IPatientsDmePrescriptions PrescriptionService,
            IPatientInfoService patientInfoService,
            IProviderInfoService providerInfoService,
            IPatientAppointmentService patientAppointmentService,
            IInsuranceCompanies insurenceCompanies
            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _DMEService = DMEService;
            _lookupService = lookupService;
            _patientsDmeService = PrescriptionService;
            _patientInfoService = patientInfoService;
            _providerInfoService = providerInfoService;
            _patientAppointmentService = patientAppointmentService;
            _insurenceCompanies = insurenceCompanies;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> ListDMEPrescription()
        {
            PatientsDmePrescriptionsViewModel viewMOdel = new PatientsDmePrescriptionsViewModel();
            var response = await _patientsDmeService.GetGeneralList();
            var lookups =  _lookupService.lookupByTypeBasicDto("DmePrescription");
            viewMOdel.LookupsList = lookups.Data;
            if (response.Data != null)
            {
                viewMOdel.DMEPrescriptionList = response.Data;
            }
            
            return View(viewMOdel);
        }
        public async Task<IActionResult> ListAssignedDme()
        {
            PatientsDmePrescriptionsViewModel viewMOdel = new PatientsDmePrescriptionsViewModel();
            var patientInfoId = _sessionManager.GetPatientInfoId();
            if(patientInfoId>0)
            {
                var response= await _patientsDmeService.GetLsitByPatientId(patientInfoId);
                var lookups = _lookupService.lookupByTypeBasicDto("DmePrescription");
                viewMOdel.LookupsList = lookups.Data;
                if (response.Data != null)
                {
                    viewMOdel.DMEPrescriptionList = response.Data;
                }
            }
            
            return View(viewMOdel);
        }
        public async Task<IActionResult> AddDMEPrrescriptions(int? Id)
        {
            var viewModel = new PatientsDmePrescriptionsViewModel();
            var PatientId = _sessionManager.GetPatientInfoId();
            var VisitId = (Int32)_sessionManager.GetVisitId();
            var RoleId = _sessionManager.GetRoleId();
            var UserId = _sessionManager.GetProviderInfoId();
            var DoctorName = _sessionManager.GetUserName();
            if (RoleId == 2)
            {
               
                ViewBag.DoctorName = DoctorName;
                ViewBag.DoctorId = UserId;
            }
            else
            {
               
                ViewBag.DoctorName = "";
                ViewBag.DoctorId = "";
            }
            ViewBag.VisitId = VisitId;
            ViewBag.PatentId = PatientId;
            //var rec = await _DMEService.GroupItemListAll();
            //viewModel.ItemGroupCptCodeList = rec;
            var patientInfoLst =await _patientInfoService.GetPatientListWithDetails();
            var providerInfoList =await _providerInfoService.GetProviderList();
            var manufactures = await _DMEService.GetListManufactures();
            viewModel.Patients = patientInfoLst;
            viewModel.Prescribers = providerInfoList;
            viewModel.DmeSuppliesManufacturesList = manufactures.Data;
            var insurenceCompanies = await _insurenceCompanies.GetListOfCompanies();
            viewModel.InsurenceCompanies = insurenceCompanies.Data;
            return View(viewModel);
        }



        [HttpPost]
        public async Task<IActionResult> AddDMEPrrescriptions(PatientsDmePrescriptionsViewModel viewModel,List<BarCode> barCodeImages)
        {
            var visitId = 0;
            if (viewModel.DMEPrescriptionList[0].VisitId==0)
            {
                visitId =await _patientAppointmentService.GetPatientLatestVisitId((long)viewModel.DMEPrescriptionList[0].PatientId);
                if (!(visitId>0))
                {
                    var data = new { Error = true };
                    return Json(data);
                }
                
            }
            else
            {
                visitId = (int)viewModel.DMEPrescriptionList[0].VisitId;
            }
            int i = 0;
            foreach (var item in barCodeImages)
            {
                viewModel.DMEPrescriptionList[i].VisitId = visitId;
                //Initial Status is Awaiting For Approval that has Id in Lookups is 174
                viewModel.DMEPrescriptionList[i].StatusId = 174;
                viewModel.DMEPrescriptionList[i].BarCodeImgUrl = barCodeImages[i].ImageUrl.BarCode("wwwroot/BarCodes", viewModel.DMEPrescriptionList[i].BarCodeNumber);
                i++;
            }
            await _patientsDmeService.AddListDmePrescription(viewModel.DMEPrescriptionList);

            var result = new { Error = false };
            return Json(result);
        }

        public async Task<IActionResult> DmeGroupDescription(int Id)
        {
            var man = await _DMEService.GetByCptCodeDmeInventory(Id);
            var dmeGroup = await _DMEService.GetByGroupItemId(Id);
            var data = new { Manufactures = man.Data,DMEGroupItem=dmeGroup.Data, IsExisit = true };
            var error = new { IsExisit = false };
            if (man.Data.ExistingQuantity > 0)
            {
                return Json(data);
            }
            else
            {
                return Json(error);
            }
           
        }
        public async Task<IActionResult> CptCodesByManufactures(int Id)
        {
            var rec = await _DMEService.GroupItemListAll(Id,null);
            if (rec.Count > 0)
            {
                var data = new { Items = rec, IsExisit=true };
                return Json(data);
            }
            else
            {
                var data = new { IsExisit = false };
                return Json(data);
            }
            

        }


        public async Task<IActionResult> DropDownList()
        {
            var rec = await _DMEService.GroupItemListAll();
            return Json(rec);
        }

        public async Task<IActionResult> DmeStatusChange(int ItemId,int statusId)
        {
            var rec = await _patientsDmeService.StatusChange(ItemId, statusId);

            var Result = new { Data = rec.Data };
            return Json(Result);
        }


        public async Task<IActionResult> SupplierAssignedDme()
        {
            PatientsDmePrescriptionsViewModel viewMOdel = new PatientsDmePrescriptionsViewModel();
            var roleId = _sessionManager.GetRoleId();
            var userId = _sessionManager.GetUserId();
            if (roleId == 22)
            {
                var supplierList = await _patientsDmeService.SuuplierAssignedDme(userId);
                viewMOdel.SupplierList = supplierList.Data;
            }
            return View(viewMOdel);
        }


        public async Task<IActionResult> PatientAndPrescriberDetails(long patId,long providerId)
        {
            var patientRecord = await _patientInfoService.GetPatientSummaryDetails(patId);
            var providerRecord = await _providerInfoService.GetProviderSummaryDetails(providerId);
            var data = new { Patient = patientRecord, Provider = providerRecord };
            return Json(data);
        }



        [HttpPost]
        public async Task<IActionResult> CreateDmeRentalForm(PatientsDmePrescriptionsViewModel patientsDmePrescriptionsViewModel)
        {
            var response = await _patientsDmeService.DmeRentalFormCreate(patientsDmePrescriptionsViewModel.DmeRentalFormDto);
            var result = new { IsError = false, RentalFormId= response.Data.RentalFormId };
            return Json(result);
        }
    }
}
