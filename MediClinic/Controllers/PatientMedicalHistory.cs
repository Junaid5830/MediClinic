using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.Doctor;
using MediClinic.Services.Interfaces.MedicalDiseaseTypeInterface;
using MediClinic.Services.Interfaces.Patient;
using MediClinic.Services.Interfaces.PatientMedicalProblemInterface;
using MediClinic.Services.Interfaces.ProviderSpecialityInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    public class PatientMedicalHistory : Controller
    {
        private ISessionManager _sessionManager;
        private IPatientService _PatientService;
        private IMedicalDiseaseTypeService _medicalDiseaseTypeService;
        private IDoctorService _DoctorService;
        private IProviderSpecialityService _providerSpecialityService;
        private IPatientMedicalProblemService _patientMedicalProblemService;


        public PatientMedicalHistory(ISessionManager sessionManager, IPatientService patientService, 
            IMedicalDiseaseTypeService medicalDiseaseTypeService, IDoctorService doctorService,
            IProviderSpecialityService providerSpecialityService, IPatientMedicalProblemService patientMedicalProblemService)
        {
            _sessionManager = sessionManager;
            _PatientService = patientService;
            _medicalDiseaseTypeService = medicalDiseaseTypeService;
            _DoctorService = doctorService;
            _providerSpecialityService = providerSpecialityService;
            _patientMedicalProblemService = patientMedicalProblemService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> MedicalHistoryAndProblem()
        {
            ViewBag.MedicalHistory = "nav-active";
            var patientId = _sessionManager.GetPatientInfoId();
            PatientViewModel model = new PatientViewModel();
            model.GetMHMyPhysician = _PatientService.GetMHMyPhysiciany(patientId);
            model.GetMHMyPhysician = _PatientService.GetMHMyPhysiciany(patientId);
            model.MHRecreationalDrugsHistoryList = _PatientService.GetMHRecreationalDrugsHistory(patientId);
            model.GetMHHospitalizationsInfo = _PatientService.GetMHHospitalizationsInfo(patientId);
            var socialData = await _PatientService.GetMHSocialHistory(patientId);
            model.MHSocialHistory = socialData.Data;
            var list = await _medicalDiseaseTypeService.MedicalDiseaseList();
            model.medicalDiseaseTypeList = list.Data;
            model.DiseaseList = _DoctorService.GetDisease().Take(50);
            model.MedicineList = _DoctorService.GetMedicine().Take(50);
            model.GetDoctorSpecialityList = _DoctorService.GetMedicine().Take(50);
            model.GetMHPastDiseaseHistory = await _PatientService.GetMHPastDiseaseHistory(Convert.ToInt32(patientId));
            model.GetMHFamilyHistory = await _PatientService.GetMHFamilyHistory(Convert.ToInt32(patientId));
            model.GetMHExerciseHistory = await _PatientService.GetMHExerciseHistoryList(Convert.ToInt32(patientId));
            model.GetMHAllergiesHistory = await _PatientService.GetMHAllergiesHistory(Convert.ToInt32(patientId));
            var pregnanciesData = await _PatientService.GetMHPregnanciesHistory(patientId);
            model.MHPregnanciesHistory = pregnanciesData.Data;
            model.GetMHPastMedicationHistory = _PatientService.GetMHPastMedicationHistory(patientId);
            model.GetMHDetailPregnancyHistory = await _PatientService.GetMHDetailPregnanciesHistory(Convert.ToInt32(patientId));
            model.GetMHHobbiesHistory = await _PatientService.GetMHHobbiesHistory(Convert.ToInt32(patientId));
            model.GetMHPharmacyInfo = await _PatientService.GetMHPharmacyInfoHistory(Convert.ToInt32(patientId));
            var infoSpecList = await _providerSpecialityService.providerSpeciality();
            model.PhysicianSpecialityList = infoSpecList.Data;
            model.GetMHSurgicalHistory = _PatientService.GetMHSurgicalHistory(patientId);
            var dieaselist = await _medicalDiseaseTypeService.MedicalDiseaseList();
            model.medicalDiseaseTypeList = dieaselist.Data;
            var MedicalProblemList = await _patientMedicalProblemService.MedicalProblemList(patientId);
            model.patientMedicalProblemsList = MedicalProblemList.Data;
            return View(model);
        }

        #region MHFamilyHistory
        [HttpPost]
        public async Task<IActionResult> SaveMHFamilyHistory(PatientViewModel model)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var ExistName = await _PatientService.isFamilyHistoryExistorNot(model.MHFamilyHistory.Relation, model.MHFamilyHistory.DeceasedOrDeathAge, model.MHFamilyHistory.Notes, model.MHFamilyHistory.MedicalConditionsOrCauseDeath, Convert.ToInt32(patientId));
            if (ExistName.Data)
            {
                return Json("exist");
            }

            model.MHFamilyHistory.PatientId = Convert.ToInt32(patientId);
            if (model.MHFamilyHistory.Id == 0)
            {
                var create = await _PatientService.mHFamilyHistoryCreate(model.MHFamilyHistory);

            }
            else
            {
                var update = await _PatientService.mHFamilyHistoryUpdate(model.MHFamilyHistory);

            }
            model.GetMHFamilyHistory = await _PatientService.GetMHFamilyHistory(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHFamilyHistory.cshtml", model);
        }
        public async Task<IActionResult> DeleteMHFamilyHistory(int Id)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            PatientViewModel model = new PatientViewModel();
            var result = _PatientService.mHFamilyHistoryDeleteById(Id);
            model.GetMHFamilyHistory = await _PatientService.GetMHFamilyHistory(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHFamilyHistory.cshtml", model);
        }
        public async Task<IActionResult> EditMHFamilyHistory(int Id)
        {
            var result = await _PatientService.mHFamilyHistoryGetId(Id);
            return Json(result);

        }
        #endregion
        #region MHPastDieaseHistory
        [HttpPost]
        public async Task<IActionResult> SavePMHPastDiease(PatientViewModel model)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var ExistName = await _PatientService.isExistorNot(model.MHPastDiseaseHistory.Name, model.MHPastDiseaseHistory.Notes, Convert.ToInt32(patientId));
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }

            model.MHPastDiseaseHistory.PatientId = Convert.ToInt32(patientId);

            if (model.MHPastDiseaseHistory.Id == 0)
            {

                var create = await _PatientService.mHPastDiseaseHistoryCreate(model.MHPastDiseaseHistory);

            }
            else
            {
                var update = await _PatientService.mHPastDiseaseHistoryUpdate(model.MHPastDiseaseHistory);

            }
            model.GetMHPastDiseaseHistory = await _PatientService.GetMHPastDiseaseHistory(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHPastDiseaseHistory.cshtml", model);
        }
        public async Task<IActionResult> DeletePMHPastDiease(int Id)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            PatientViewModel model = new PatientViewModel();
            var result = _PatientService.mHPastDiseaseHistoryDeleteById(Id);
            model.GetMHPastDiseaseHistory = await _PatientService.GetMHPastDiseaseHistory(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHPastDiseaseHistory.cshtml", model);
        }
        public async Task<IActionResult> EditMHPastDiseaseHistory(int Id)
        {
            var result = await _PatientService.mHPastDiseaseHistoryGetId(Id);
            return Json(result);

        }
        #endregion

        #region Medication 
        [HttpPost]
        public ActionResult SaveMHPastMedicationHistory(MHPastMedicationHistory MHPastMedicationHistory)
        {
            int status = 0;
            PatientViewModel vm = new PatientViewModel();
            var PatientId = _sessionManager.GetPatientInfoId();
            MHPastMedicationHistory.PatientId = Convert.ToInt32(PatientId);
            status = _PatientService.SaveMHPastMedicationHistory(MHPastMedicationHistory);
            if (status == -1)
            {
                return Json("exist");
            }
            else
            {
                vm.GetMHPastMedicationHistory = _PatientService.GetMHPastMedicationHistory(PatientId);
                return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHPastMedicationHistory.cshtml", vm);
            }
        }
        [HttpGet]
        public ActionResult EditMHPastMedicationHistory(int Id)
        {
            var result = _PatientService.EditMHPastMedicationHistory(Id);
            return Json(result);
        }
        public ActionResult DeleteMHPastMedicationHistory(int Id)
        {
            PatientViewModel vm = new PatientViewModel();
            var PatientId = _sessionManager.GetPatientInfoId();
            var status = _PatientService.DeleteMHPastMedicationHistory(Id);
            vm.GetMHPastMedicationHistory = _PatientService.GetMHPastMedicationHistory(PatientId);
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHPastMedicationHistory.cshtml", vm);
        }
        #endregion
        #region RecretionalDrugs
        [HttpPost]
        public ActionResult SaveMHRecreationalDrugsHistory(MHRecreationalDrugsHistory MHRecreationalDrugsHistory)
        {
            int status = 0;
            PatientViewModel vm = new PatientViewModel();
            var PatientId = _sessionManager.GetPatientInfoId();
            MHRecreationalDrugsHistory.PatientId = Convert.ToInt32(PatientId);
            status = _PatientService.SaveMHRecreationalDrugsHistory(MHRecreationalDrugsHistory);
            if (status == -1)
            {
                return Json("exist");
            }
            else
            {
                vm.MHRecreationalDrugsHistoryList = _PatientService.GetMHRecreationalDrugsHistory(PatientId);
                return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHRecreationalDrugsHistory.cshtml", vm);
            }
        }
        [HttpGet]
        public ActionResult EditMHRecreationalDrugHistory(int Id)
        {

            var result = _PatientService.EditMHRecreationalDrugsHistory(Id);
            return Json(result);
        }
        public ActionResult DeleteMHRecreationalDrugsHistory(int Id)
        {

            bool status = false;
            PatientViewModel vm = new PatientViewModel();
            var PatientId = _sessionManager.GetPatientInfoId();

            status = _PatientService.DeleteMHRecreationalDrugsHistory(Id);
            vm.GetMHPastDiseaseHistory = _PatientService.GetMHPastDiseaseHistory(PatientId);

            vm.MHRecreationalDrugsHistoryList = _PatientService.GetMHRecreationalDrugsHistory(PatientId);
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHRecreationalDrugsHistory.cshtml", vm);
        }
        #endregion

        #region MHExerciseHistory
        [HttpPost]
        public async Task<IActionResult> SavePMHExerciseHistory(PatientViewModel model)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var ExistName = await _PatientService.isExerciseHistoryExistorNot(model.MHExerciseHistory.ExerciseType, model.MHExerciseHistory.ExerciseType, model.MHExerciseHistory.HobbiesOrLeisureActivities, model.MHExerciseHistory.ExerciseNoOfDaysPerWeek, Convert.ToInt32(patientId));
            if (ExistName.Data)
            {

                return Json("exist");
            }

            model.MHExerciseHistory.PatientId = Convert.ToInt32(patientId);
            if (model.MHExerciseHistory.Id == 0)
            {
                var create = await _PatientService.mHExerciseHistoryCreate(model.MHExerciseHistory);

            }
            else
            {
                var update = await _PatientService.mHExerciseHistoryUpdate(model.MHExerciseHistory);

            }
            model.GetMHExerciseHistory = await _PatientService.GetMHExerciseHistoryList(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHExerciseHistory.cshtml", model);
        }
        public async Task<IActionResult> DeleteMHExerciseHistory(int Id)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            PatientViewModel model = new PatientViewModel();
            var result = _PatientService.mHExerciseHistoryDeleteById(Id);
            model.GetMHExerciseHistory = await _PatientService.GetMHExerciseHistoryList(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHExerciseHistory.cshtml", model);
        }
        public async Task<IActionResult> EditMHExerciseHistory(int Id)
        {
            var result = await _PatientService.mHExerciseHistoryGetId(Id);
            return Json(result);

        }
        #endregion

        #region MHPhysician
        [HttpPost]

        public async Task<IActionResult> SaveMHMyPhysicians(PatientViewModel model)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var ExistName = await _PatientService.isPhyscianHistoryExistorNot(model.MHMyPhysician.Name, model.MHMyPhysician.Location, model.MHMyPhysician.Hospital, model.MHMyPhysician.PhoneNo, model.MHMyPhysician.Notes, model.MHMyPhysician.Specialty, Convert.ToInt32(patientId));
            if (ExistName.Data)
            {

                return Json("exist");
            }

            model.MHMyPhysician.PatientId = Convert.ToInt32(patientId);
            if (model.MHMyPhysician.Id == 0)
            {
                var create = await _PatientService.SaveMHMyPhysicians(model.MHMyPhysician);

            }
            else
            {
                var update = await _PatientService.UpdateMyPhysicians(model.MHMyPhysician);

            }
            model.GetMHMyPhysician = _PatientService.GetMHMyPhysiciany(patientId);
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHMyPhysician.cshtml", model);
        }
        [HttpGet]
        public ActionResult EditMHMyPhysician(int Id)
        {
            var result = _PatientService.EditMHMyPhysician(Id);
            return Json(result);
        }
        public ActionResult DeleteMHMyPhysician(int Id)
        {
            PatientViewModel vm = new PatientViewModel();
            var PatientId = _sessionManager.GetPatientInfoId();
            var status = _PatientService.DeleteMHMyPhysician(Id);
            vm.GetMHMyPhysician = _PatientService.GetMHMyPhysiciany(PatientId);
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHMyPhysician.cshtml", vm);
        }
        #endregion

        #region surgical History
        [HttpPost]
        public ActionResult SaveMHSurgicalHistory(MHSurgicalHistory MHSurgicalHistory)
        {

            int status = 0;
            PatientViewModel vm = new PatientViewModel();
            var PatientId = _sessionManager.GetPatientInfoId();
            MHSurgicalHistory.PatientId = Convert.ToInt32(PatientId);
            status = _PatientService.SaveMHSurgicalHistory(MHSurgicalHistory);
            if (status == -1)
            {
                return Json("exist");
            }
            else
            {
                vm.GetMHSurgicalHistory = _PatientService.GetMHSurgicalHistory(PatientId);
                return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHSurgicalHistory.cshtml", vm);
            }

        }
        [HttpGet]
        public ActionResult EditMHSurgicalHistory(int Id)
        {

            var result = _PatientService.EditMHSurgicalHistory(Id);
            return Json(result);
        }
        public ActionResult DeleteMHSurgicalHistory(int Id)
        {
            PatientViewModel vm = new PatientViewModel();
            var PatientId = _sessionManager.GetPatientInfoId();
            var status = _PatientService.DeleteMHSurgicalHistory(Id);
            vm.GetMHSurgicalHistory = _PatientService.GetMHSurgicalHistory(PatientId);
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHSurgicalHistory.cshtml", vm);
        }
        #endregion

        #region MHPregnancyHistory
        public async Task<ActionResult> SaveMHPregnanciesHistory(MHPregnanciesHistory mHPregnanciesHistory)
        {
            int status = 0;
            PatientViewModel vm = new PatientViewModel();
            var patientId = _sessionManager.GetPatientInfoId();
            mHPregnanciesHistory.PatientId = Convert.ToInt32(patientId);
            status = _PatientService.SaveMHPregnenciesHistory(mHPregnanciesHistory);
            return Json("success");
        }

        public async Task<IActionResult> EditMHPregnacyHistory(int Id)
        {
            var result = await _PatientService.mHPregnanciesHistoryGetId(Id);
            return Json(result);

        }
        #endregion

        #region MHDetailPregnancyHistory
        [HttpPost]
        public async Task<IActionResult> SaveMHDetailPregnanciesHistory(PatientViewModel model)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            //var ExistName = await _PatientService.ispr(model.MHPregnanciesHistory.AllergyTo, Convert.ToInt32(patientId));
            //if (ExistName.Data)
            //{
            //    var message = new { Success = ExistName.Message, IsError = true };
            //    return Json(message);
            //}

            model.MHDetailPregnanciesHistory.PatientId = Convert.ToInt32(patientId);
            if (model.MHDetailPregnanciesHistory.Id == 0)
            {
                var create = await _PatientService.mHDetailPregnanciesHistoryCreate(model.MHDetailPregnanciesHistory);

            }
            else
            {
                var update = await _PatientService.mHDetailPregnanciesHistoryUpdate(model.MHDetailPregnanciesHistory);

            }
            model.GetMHDetailPregnancyHistory = await _PatientService.GetMHDetailPregnanciesHistory(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHDetailPregnanciesHistory.cshtml", model);
        }
        public async Task<IActionResult> DeleteMHDetailPregnancyHistory(int Id)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            PatientViewModel model = new PatientViewModel();
            var result = _PatientService.mHDetailPregnanciesHistoryDeleteById(Id);
            model.GetMHDetailPregnancyHistory = await _PatientService.GetMHDetailPregnanciesHistory(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHDetailPregnanciesHistory.cshtml", model);
        }
        public async Task<IActionResult> EditMHDetailPregnacyHistory(int Id)
        {
            var result = await _PatientService.mHDetailPregnanciesHistoryGetId(Id);
            return Json(result);

        }
        #endregion

        #region MHAllergiesHistory
        [HttpPost]
        public async Task<IActionResult> SaveMHAllergiesHistory(PatientViewModel model)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var ExistName = await _PatientService.isAllergiesHistoryExistorNot(model.MHAllergiesHistory, Convert.ToInt32(patientId));
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }

            model.MHAllergiesHistory.PatientId = Convert.ToInt32(patientId);
            if (model.MHAllergiesHistory.Id == 0)
            {
                var create = await _PatientService.mHAllergiesHistoryCreate(model.MHAllergiesHistory);

            }
            else
            {
                var update = await _PatientService.mHAllergiesHistoryUpdate(model.MHAllergiesHistory);

            }
            model.GetMHAllergiesHistory = await _PatientService.GetMHAllergiesHistory(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHAllergiesHistory.cshtml", model);
        }
        public async Task<IActionResult> DeleteMHAllergiesHistory(int Id)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            PatientViewModel model = new PatientViewModel();
            var result = _PatientService.mHAllergiesHistoryDeleteById(Id);
            model.GetMHAllergiesHistory = await _PatientService.GetMHAllergiesHistory(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHAllergiesHistory.cshtml", model);
        }
        public async Task<IActionResult> EditMHAllergiesHistory(int Id)
        {
            var result = await _PatientService.mHAllergiesHistoryGetId(Id);
            return Json(result);

        }
        #endregion

        #region MHPharmacyInfo
        public async Task<IActionResult> SaveMHPharmacyInfo(PatientViewModel model)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var ExistName = await _PatientService.isPharmacyHistoryExistorNot(model.MHPharmacyInfo, Convert.ToInt32(patientId));
            if (ExistName.Data)
            {
                return Json("exist");
            }

            model.MHPharmacyInfo.PatientId = Convert.ToInt32(patientId);
            if (model.MHPharmacyInfo.Id == 0)
            {
                var create = await _PatientService.mHPharmacyInfoHistoryCreate(model.MHPharmacyInfo);

            }
            else
            {
                var update = await _PatientService.mHharmacyInfoHistoryUpdate(model.MHPharmacyInfo);

            }
            model.GetMHPharmacyInfo = await _PatientService.GetMHPharmacyInfoHistory(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHPharmacyInfo.cshtml", model);
        }
        public async Task<IActionResult> DeleteMHPharmacyInfoHistory(int Id)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            PatientViewModel model = new PatientViewModel();
            var result = _PatientService.mHPharmacyInfoHistoryDeleteById(Id);
            model.GetMHPharmacyInfo = await _PatientService.GetMHPharmacyInfoHistory(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHPharmacyInfo.cshtml", model);
        }
        public async Task<IActionResult> EditMHPharmacyInfo(int Id)
        {
            var result = await _PatientService.mHPharmacyInfoHistoryGetId(Id);
            return Json(result);

        }
        #endregion

        #region Hospitalize 
        public ActionResult SaveMHHospitalizationsInfo(MHHospitalizationsInfo MHHospitalizationsInfo)
        {
            int status = 0;
            PatientViewModel vm = new PatientViewModel();
            var PatientId = _sessionManager.GetPatientInfoId();
            MHHospitalizationsInfo.PatientId = Convert.ToInt32(PatientId);
            status = _PatientService.SaveMHHospitalizationsInfo(MHHospitalizationsInfo);
            if (status == -1)
            {
                return Json("exist");
            }
            else
            {
                vm.GetMHHospitalizationsInfo = _PatientService.GetMHHospitalizationsInfo(PatientId);
                return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHHospitalizationsInfo.cshtml", vm);
            }

        }
        [HttpGet]
        public ActionResult EditMHHospitalizationsInfo(long Id)
        {
            var result = _PatientService.EditMHHospitalizationsInfo(Id);
            return Json(result);

        }
        [HttpGet]
        public ActionResult DeleteMHHospitalizationsInfo(int Id)
        {

            PatientViewModel vm = new PatientViewModel();
            var PatientId = _sessionManager.GetPatientInfoId();
            bool status = false;
            status = _PatientService.DeleteMHHospitalizationsInfo(Id);
            vm.GetMHHospitalizationsInfo = _PatientService.GetMHHospitalizationsInfo(PatientId);
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHHospitalizationsInfo.cshtml", vm);

        }
        #endregion

        #region MHHobbiesHistory
        [HttpPost]
        public async Task<IActionResult> SaveMHHobbiesHistory(PatientViewModel model)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var ExistName = await _PatientService.isHobbiesExistorNot(model.MHHobbiesHistory.Hobbies, Convert.ToInt32(patientId));
            if (ExistName.Data)
            {
                return Json("exist");
            }

            model.MHHobbiesHistory.PatientId = Convert.ToInt32(patientId);
            if (model.MHHobbiesHistory.Id == 0)
            {
                var create = await _PatientService.mHobbiesHistoryCreate(model.MHHobbiesHistory);

            }
            else
            {
                var update = await _PatientService.mHHobbiesHistoryUpdate(model.MHHobbiesHistory);

            }
            model.GetMHHobbiesHistory = await _PatientService.GetMHHobbiesHistory(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHHobbiesHistory.cshtml", model);
        }
        public async Task<IActionResult> DeleteMHHobbiesHistory(int Id)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            PatientViewModel model = new PatientViewModel();
            var result = _PatientService.mHHobbiesHistoryDeleteById(Id);
            model.GetMHHobbiesHistory = await _PatientService.GetMHHobbiesHistory(Convert.ToInt32(patientId));
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMHHobbiesHistory.cshtml", model);
        }
        public async Task<IActionResult> EditMHHobbiesHistory(int Id)
        {
            var result = await _PatientService.mHHobbiesHistoryGetId(Id);
            return Json(result);

        }
        #endregion

        #region Medical Problem
        [HttpPost]
        public async Task<IActionResult> SaveMedicalProblems(PatientViewModel patientViewModel)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            patientViewModel.patientMedicalProblemBasicDto.PatientId = patientId;

            if (patientViewModel.patientMedicalProblemBasicDto.MedicalProblemId > 0)
            {
                await _patientMedicalProblemService.MedicalProblemUpdate(patientViewModel.patientMedicalProblemBasicDto);
            }
            else
            {
                await _patientMedicalProblemService.MedicalProblemCreate(patientViewModel.patientMedicalProblemBasicDto);
            }
            var MedicalProblemList = await _patientMedicalProblemService.MedicalProblemList(patientId);
            patientViewModel.patientMedicalProblemsList = MedicalProblemList.Data;
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMedicalProblems.cshtml", patientViewModel);
        }
        public async Task<IActionResult> DeleteMedicalProblem(int Id)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            PatientViewModel patientViewModel = new PatientViewModel();
            var result = _patientMedicalProblemService.MedicalProblemDeleteById(Id);
            var MedicalProblemList = await _patientMedicalProblemService.MedicalProblemList(patientId);
            patientViewModel.patientMedicalProblemsList = MedicalProblemList.Data;
            return PartialView("~/Views/PatientSideElite/_MedicalHistoryPartial/_ManageMedicalProblems.cshtml", patientViewModel);
        }
        public async Task<IActionResult> EditMedicalProblemHistory(int Id)
        {
            var result = await _patientMedicalProblemService.medicalProblemHistoryGetId(Id);
            return Json(result);

        }
        #endregion

        #region Social
        public async Task<ActionResult> SaveMHSocialHistory(MHSocialHistory MHSocialHistory)
        {
            int status = 0;
            PatientViewModel vm = new PatientViewModel();
            var PatientId = _sessionManager.GetPatientInfoId();
            MHSocialHistory.PatientId = Convert.ToInt32(PatientId);
            status = _PatientService.SaveMHSocialHistory(MHSocialHistory);
            return Json("success");
        }
        #endregion
    }
}
