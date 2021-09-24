using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs.PatientInfoListDto;
using MediClinic.Models.DTOs.PatientAppointmentsDto;
using MediClinic.Services.Interfaces.PatientAppointmentInterface;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.UserInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MedliClinic.Utilities.Utility;
using MediClinic.Services.Interfaces;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientPrescriptionInterface;
using MediClinic.Services.Interfaces.PatientVitalInterface;
using MediClinic.Services.Interfaces.ImmunizationInterface;
using MediClinic.Services.Interfaces.Template;
using MediClinic.Services.Interfaces.GrowthChartInterface;
using MediClinic.Services.Interfaces.LabInterface;
using MediClinic.Services.Interfaces.ImagingInterface;
using MediClinic.Services.Interfaces.InvoicesInterface;
using MediClinic.Services.Interfaces.TestsInterface;
using MediClinic.Services.Services.MessagesService;
using MediClinic.Services.Interfaces.AllergyInterface;
using MediClinic.Services.Interfaces.UserRolePageInterface;
using MediClinic.Services.Interfaces.UserEventInterface;

namespace MediClinic.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ILogger<AppointmentController> _logger;
        private ISessionManager _sessionManager;
        private IUserEvents _userEvents;
        private readonly IPatientInfoService _patientInfoService;
        private IProviderInfoService _providerInfoService;
        private IPatientAppointmentService _patientAppointmentService;
        private IUserService _userService;
        private readonly IProviderSettingsService _providerSettingsService;
        private IPatientPrescriptionService _patientPrescriptionService;
        private IPatientVitalService _patientVitalService;
        private IimmunizationService _immunizationService;
        private ITemplateService _templateService;
        private IGrowthChartService _growthChartService;
        private ILabService _labService;
        private IImagingService _imagingService;
        private IDMESuppliesService _dMESuppliesService;
        private IInvoicesService _invoiceService;
        private ITestsService _testsService;
        private IMessagesService _messagesService;
        private IAllergyService _allergyService;
        private readonly IUserRolePageService _userRolePageService;


        public AppointmentController(ILogger<AppointmentController> logger, ISessionManager sessionManager,
            IUserEvents userEvents,
            IPatientInfoService patientInfoService, IProviderInfoService providerInfoService,
            IPatientAppointmentService patientAppointmentService, IUserService userService, IProviderSettingsService providerSettingsService,
            IPatientPrescriptionService patientPrescriptionService, IPatientVitalService patientVitalService, IimmunizationService iimmunizationService,
            ITemplateService templateService, ILabService labService,
            IGrowthChartService growthChartService, IImagingService imagingService, IDMESuppliesService dMESuppliesService,
            IInvoicesService invoicesService, ITestsService testsService, IMessagesService messagesService,IAllergyService allergyService,
            IUserRolePageService userRolePageService)
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _userEvents = userEvents;
            _patientInfoService = patientInfoService;
            _providerInfoService = providerInfoService;
            _patientAppointmentService = patientAppointmentService;
            _userService = userService;
            _providerSettingsService = providerSettingsService;
            _patientPrescriptionService = patientPrescriptionService;
            _patientVitalService = patientVitalService;
            _immunizationService = iimmunizationService;
            _templateService = templateService;
            _growthChartService = growthChartService;
            _labService = labService;
            _imagingService = imagingService;
            _dMESuppliesService = dMESuppliesService;
            _invoiceService = invoicesService;
            _testsService = testsService;
            _messagesService = messagesService;
            _allergyService = allergyService;
            _userRolePageService = userRolePageService;
        }
        // #region patient appointment
        public IActionResult Index()
        {
            return View();
        }
        #region patient Appointment
        public async Task<IActionResult> PatientAppointment(int? Id)
        {
            try
            {
                ViewBag.Appointment = "nav-active";
                var patientId = _sessionManager.GetPatientInfoId();
                AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
                var AppointmentList = await _patientAppointmentService.AppointmentList((int)Id);
                appointmentViewModel.patientAppointmentBasicsList = AppointmentList;
                appointmentViewModel.ProviderList = await _providerInfoService.GetProviderList();
                appointmentViewModel.ProviderSessionTypeList = await _providerSettingsService.GetAllSessionSettings();
                appointmentViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();

                return View(appointmentViewModel);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            
        }
        public async Task<IActionResult> AppointmentGetById(int? appointId)
        {
            var rec = await _patientAppointmentService.AppointmentGetById((int)appointId);

            return Json(rec);
        }
        [HttpPost]
        public async Task<IActionResult> PatientAppointment(AppointmentViewModel appointmentViewModel)
        {
            var url = _sessionManager.GetPatientInfoId();
            if (appointmentViewModel.patientAppointmentBasicDto.AppointmentId > 0)
            {
                var rec = await _patientAppointmentService.AppointmentUpdate(appointmentViewModel.patientAppointmentBasicDto);
            }
            else
            {
                //string dt = String.Format("{0:HH:mm:ss}", appointmentViewModel.patientAppointmentBasicDto.ExactTime);
                //DateTime stime = DateTime.Parse(dt);
                //var ExistTime = await _patientAppointmentService.isExistorNot(appointmentViewModel.patientAppointmentBasicDto.ExactTime);
                //if (ExistTime.Data)
                //{
                //    var message = new { Success = ExistTime.Message, IsError = true };
                //    return Json("-2", message); 
                //}
                //appointmentViewModel.patientAppointmentBasicDto.ExactTime = stime;
                appointmentViewModel.patientAppointmentBasicDto.PatientInfoId = url;

                var rec = await _patientAppointmentService.AppointmentCreate(appointmentViewModel.patientAppointmentBasicDto);
            }
            var dataDoctor = _providerInfoService.GetProviderUserId(Convert.ToInt64(appointmentViewModel.patientAppointmentBasicDto.ProviderInfoId));
            return Json(dataDoctor);
        }

        [HttpPost]
        public async Task<IActionResult> RecurringAppointment(AppointmentViewModel appointmentViewModel)
        {
            var recurison_no = _patientAppointmentService.GetLatestRecursionNo();
            var patientId = _sessionManager.GetPatientInfoId();
            string dt = String.Format("{0:MM/dd/yyyy}", appointmentViewModel.RecurringAppoinmentDto.Date) + " " + appointmentViewModel.RecurringAppoinmentDto.StartTime;
            DateTime stime = DateTime.Parse(dt);
            dt = String.Format("{0:MM/dd/yyyy}", appointmentViewModel.RecurringAppoinmentDto.EndDate) + " " + appointmentViewModel.RecurringAppoinmentDto.EndTime;
            DateTime etime = DateTime.Parse(dt);
            //if (stime <= DateTime.UtcNow)
            //{
            //    return Json("-4", patientViewModel);
            //}

            if (stime > etime)
            {
                return Json("-2", appointmentViewModel);
            }
            var objRecurringApt = appointmentViewModel.RecurringAppoinmentDto;
            objRecurringApt.PatientInfoId = patientId;
            TimeSpan days = etime.Subtract(stime);
            for (int i = 0; i <= days.Days; i++)
            {
                bool CreateAppointment = false;
                var AptStartDate = objRecurringApt.Date;
                var AptEndDate = objRecurringApt.EndDate;
                var RecurringAptStartDate = objRecurringApt.Date.Value.AddDays(i);
                var RecurringAptEndDate = objRecurringApt.EndDate.Value.AddDays(i);
                var RecurringAptDayOfWeek = objRecurringApt.Date.Value.AddDays(i).DayOfWeek.ToString();
                if (objRecurringApt.IsSundayChecked && RecurringAptDayOfWeek.Equals("Sunday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsMondayChecked && RecurringAptDayOfWeek.Equals("Monday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsTuesdayChecked && RecurringAptDayOfWeek.Equals("Tuesday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsWednesdayChecked && RecurringAptDayOfWeek.Equals("Wednesday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsThursdayChecked && RecurringAptDayOfWeek.Equals("Thursday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsFridayChecked && RecurringAptDayOfWeek.Equals("Friday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsSaturdayChecked && RecurringAptDayOfWeek.Equals("Saturday"))
                {
                    CreateAppointment = true;
                }
                else
                {
                    CreateAppointment = false;
                }
                if (CreateAppointment)
                {
                    try
                    {
                        if (objRecurringApt.AppointmentId == 0)
                        {
                            if (!(objRecurringApt is null) && objRecurringApt.PatientInfoId > 0)
                            {

                                PatientAppointmentBasicDto patientAppointment = new PatientAppointmentBasicDto();
                                patientAppointment.ProviderInfoId = objRecurringApt.ProviderInfoId;
                                patientAppointment.AppointmentType = objRecurringApt.AppointmentType;
                                patientAppointment.Date = RecurringAptStartDate;
                                patientAppointment.EndDate = objRecurringApt.EndDate;
                                patientAppointment.StartTime = TimeSpan.Parse(objRecurringApt.StartTime);
                                patientAppointment.EndTime = TimeSpan.Parse(objRecurringApt.EndTime);
                                patientAppointment.PatientInfoId = objRecurringApt.PatientInfoId;
                                patientAppointment.RecursionNo = recurison_no;
                                await _patientAppointmentService.AppointmentCreate(patientAppointment);
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    if (RecurringAptStartDate == AptEndDate)
                    {
                        break;
                    }
                }
            }

            if (objRecurringApt.AppointmentId > 0)
            {
                PatientAppointmentBasicDto patientAppointment = new PatientAppointmentBasicDto();
                patientAppointment.ProviderInfoId = objRecurringApt.ProviderInfoId;
                patientAppointment.AppointmentType = objRecurringApt.AppointmentType;
                patientAppointment.Date = objRecurringApt.Date;
                patientAppointment.EndDate = objRecurringApt.EndDate;
                patientAppointment.StartTime = TimeSpan.Parse(objRecurringApt.StartTime);
                patientAppointment.EndTime = TimeSpan.Parse(objRecurringApt.EndTime);
                patientAppointment.PatientInfoId = objRecurringApt.PatientInfoId;
                patientAppointment.AppointmentId = objRecurringApt.AppointmentId;
                await _patientAppointmentService.AppointmentUpdate(patientAppointment);

            }
            return Json(appointmentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ExactRecurringAppointment(AppointmentViewModel appointmentViewModel)
        {
            var recurison_no = _patientAppointmentService.GetLatestRecursionNo();

            var patientId = _sessionManager.GetPatientInfoId();
            string dt = String.Format("{0:MM/dd/yyyy}", appointmentViewModel.RecurringAppoinmentDto.Date) + " " + appointmentViewModel.RecurringAppoinmentDto.ExactTime;
            DateTime stime = DateTime.Parse(dt);
            dt = String.Format("{0:MM/dd/yyyy}", appointmentViewModel.RecurringAppoinmentDto.EndDate) + " " + appointmentViewModel.RecurringAppoinmentDto.ExactTime;
            DateTime etime = DateTime.Parse(dt);
            //if (stime <= DateTime.UtcNow)
            //{
            //    return Json("-4", appointmentViewModel);
            //}

            if (stime > etime)
            {
                return Json("-2", appointmentViewModel);
            }
            var objRecurringApt = appointmentViewModel.RecurringAppoinmentDto;
            objRecurringApt.PatientInfoId = patientId;
            TimeSpan days = etime.Subtract(stime);
            for (int i = 0; i <= days.Days; i++)
            {
                bool CreateAppointment = false;
                var AptStartDate = objRecurringApt.Date;
                var AptEndDate = objRecurringApt.EndDate;
                var RecurringAptStartDate = objRecurringApt.Date.Value.AddDays(i);
                var RecurringAptEndDate = objRecurringApt.EndDate.Value.AddDays(i);
                var RecurringAptDayOfWeek = objRecurringApt.Date.Value.AddDays(i).DayOfWeek.ToString();
                if (objRecurringApt.IsSundayChecked && RecurringAptDayOfWeek.Equals("Sunday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsMondayChecked && RecurringAptDayOfWeek.Equals("Monday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsTuesdayChecked && RecurringAptDayOfWeek.Equals("Tuesday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsWednesdayChecked && RecurringAptDayOfWeek.Equals("Wednesday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsThursdayChecked && RecurringAptDayOfWeek.Equals("Thursday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsFridayChecked && RecurringAptDayOfWeek.Equals("Friday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsSaturdayChecked && RecurringAptDayOfWeek.Equals("Saturday"))
                {
                    CreateAppointment = true;
                }
                else
                {
                    CreateAppointment = false;
                }
                if (CreateAppointment)
                {
                    try
                    {
                        if (objRecurringApt.AppointmentId == 0)
                        {
                            if (!(objRecurringApt is null) && objRecurringApt.PatientInfoId > 0)
                            {

                                PatientAppointmentBasicDto patientAppointment = new PatientAppointmentBasicDto();
                                patientAppointment.ProviderInfoId = objRecurringApt.ProviderInfoId;
                                patientAppointment.AppointmentType = objRecurringApt.AppointmentType;
                                patientAppointment.Date = RecurringAptStartDate;
                                patientAppointment.EndDate = objRecurringApt.EndDate;
                                patientAppointment.ExactTime = Convert.ToDateTime(objRecurringApt.ExactTime);
                                patientAppointment.RecursionNo = recurison_no;

                                patientAppointment.PatientInfoId = objRecurringApt.PatientInfoId;
                                await _patientAppointmentService.AppointmentCreate(patientAppointment);
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    if (RecurringAptStartDate == AptEndDate)
                    {
                        break;
                    }
                }
            }


            return Json(appointmentViewModel);
        }
        public async Task<IActionResult> GetCalendarsList(int Id)
        {
            var result = await _patientAppointmentService.AppointmentList(Id);
            return Json(result);
        }
        public IActionResult DeleteAppointments(int Id)
        {
            var result = _patientAppointmentService.AppointmentDeleteById(Id);
            return Json(result);
        }

        public IActionResult DeleteRecuringAppointment(int Id)
        {
            var result = _patientAppointmentService.AppointmentDeleteByRecId(Id);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetProviderNameOnDate(DateTime dateTime)
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();

            DateTime SelectDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
            appointmentViewModel.ProviderList =  await _patientAppointmentService.AvailableProviderListOnDate(SelectDate);

            return PartialView("~/Views/Appointment/PartialViews/_DoctorNameOnDate.cshtml", appointmentViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> GetProviderAvailableSlots(DateTime dateTime,long ProviderId)
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
                var Slots = await _patientAppointmentService.AvailableSlots(dateTime, ProviderId);
                appointmentViewModel.SlotsList = Slots;
            return PartialView("~/Views/Appointment/PartialViews/_ProviderAvailableSlots.cshtml", appointmentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> GetProviderAvailableSlotsView(long ProviderId, DateTime SlotDate,string dpt)
        {
            ProviderViewModel appointmentViewModel = new ProviderViewModel();
            var Slots = await _patientAppointmentService.AvailableSlotsView(ProviderId, SlotDate, dpt);
            appointmentViewModel.SlotsList = Slots;
            return PartialView("~/Views/Appointment/PartialViews/_ProviderSlotsView.cshtml", appointmentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveAvailableSlots(long Id)
        {
            var PatientID = _sessionManager.GetPatientInfoId();
            PatientAppointments patientAppoinments =  _patientAppointmentService.GetSlotsDetailByIdAndAppointmentSave(Id,PatientID, "Patient");
            var patientInfos = await _patientInfoService.GetPatientSummaryDetails(PatientID);

            var rec = CommonMethod.SendVerificationCodeForAppointment(patientInfos.MobilePhone);
            VisitsDto visits = new VisitsDto()
            {
                AppoinmentId = patientAppoinments.AppointmentId,
                Status = "Open",
            };
            await _patientAppointmentService.AddVisits(visits);
            var data = new { Success = "Data Save successfully" };
            return Json(data);
        }

        public async Task<IActionResult> PatientVisits()
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            var PatientId = _sessionManager.GetPatientInfoId();
            var roleId = _sessionManager.GetRoleId();
            var providerId = _sessionManager.GetProviderInfoId();

            if (roleId == 1)
            {
                appointmentViewModel.visitsDtosList = await _patientAppointmentService.GetVisitsList(Convert.ToInt32(PatientId));
            }
            else if ( roleId == 2) 
            {
                if (PatientId == 0)
                {
                    appointmentViewModel.visitsDtosList = await _patientAppointmentService.GetVisitsList(Convert.ToInt32(providerId));
                }
                else
                {
                    appointmentViewModel.visitsDtosList = await _patientAppointmentService.GetVisitsList(Convert.ToInt32(PatientId));
                }
            }
            else 
            {
                if (PatientId == 0)
                {
                    appointmentViewModel.visitsDtosList = await _patientAppointmentService.GetVisitsList(Convert.ToInt32(roleId));

                }
                else
                {
                    appointmentViewModel.visitsDtosList = await _patientAppointmentService.GetVisitsList(Convert.ToInt32(PatientId));

                }
            }
            return View(appointmentViewModel);

        }
        //for visits button
        public  IActionResult VisitView(int visitid) 
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
             _sessionManager.SetVisitId(visitid);
            var rec =  _patientAppointmentService.getVisitDetail(visitid);
            //var patientInfos = await _patientInfoService.GetPatientSummaryDetails((long)rec);
            //appointmentViewModel.patientCompleteInfo = patientInfos;
            return RedirectToAction("PatientSummary2","PatientSideElite",new { Id= rec });
        }
       
        [HttpGet]
        public async Task<IActionResult> VisitsDetail(int Id , string IsForPrint)
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            var roleId = _sessionManager.GetRoleId();
            int Roleid = (int)((_sessionManager.GetUserId() == 0) ? 0 : _sessionManager.GetUserId());

            var prescriptionlist = await _patientPrescriptionService.prescriptionListForVisitsDetail(Id);
            appointmentViewModel.prescriptionBasicsList = prescriptionlist.Data;
            appointmentViewModel.Vitallist = _patientVitalService.GetAllVitalListForVIsits(Id);
            appointmentViewModel.Listimmunization = await _immunizationService.ImmunizationList(Id);
            appointmentViewModel.TemplateList = await _templateService.TemplateDetailForPatient(Id);
            appointmentViewModel.growthChartList = await _growthChartService.GetGrowthChartList(Id);
            ViewBag.VisitId = Id;
            if (IsForPrint == "print")
            {
                ViewBag.IsForPrint = "isForPrint";
            }
            else
            {
                ViewBag.IsForPrint = "";
            }
            appointmentViewModel.getLabList = await _labService.GetLabVisitList(Id);
            appointmentViewModel.getImagingDto = await _imagingService.ImagingVisitList(Id);
            appointmentViewModel.DMEVisitList = await _dMESuppliesService.GetDMESupplyVIsitList(Id);
            appointmentViewModel.invoicesList = await _invoiceService.GetInvoicesVisitList(Id);
            appointmentViewModel.TestsDtoList = _testsService.ProcedureVisitList(Id);
            appointmentViewModel.AlergyList = await _allergyService.GetAllergyList();
            appointmentViewModel.AlergyTypeList = await _allergyService.GetAllergyTypeListForVIsit(Id);
            var rec = _messagesService.GetReceiveMessageList(Roleid);
            if (!(rec is null))
            {
                appointmentViewModel.receiveMessages = rec.Where(x => x.VisitId == Id).ToList();
               
            }
            return PartialView("~/Views/Appointment/PartialViews/_VisitsDetail.cshtml",appointmentViewModel);
        }


        [HttpPost]

        public IActionResult PrintTables(int? Id, string data)
        {
            ViewBag.Data = data;
            //return View();
            return PartialView("~/Views/Appointment/PartialViews/_PrinTables.cshtml");

        }
        [HttpPost]
        public IActionResult RescheduleSlots(long SlotId, long AppId)
        {
            _patientAppointmentService.RescheduleAppointment(SlotId, AppId);
            var data = new { Success = "Data Save successfully" };
            return Json(data);
        }
        public async Task<IActionResult> PatientCalendar(int? Id)
        {
            ViewBag.Appointment = "nav-active";
            var patientId = _sessionManager.GetPatientInfoId();
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            appointmentViewModel.calendarSettingDto = _patientAppointmentService.GetCalendarViewSet();
            if (appointmentViewModel.calendarSettingDto.CalViewMonth is true)
            {
                ViewBag.CalendarDefault = "month";
            }
            else if (appointmentViewModel.calendarSettingDto.CalViewWeek is true)
            {
                ViewBag.CalendarDefault = "agendaWeek";
            }
            else if (appointmentViewModel.calendarSettingDto.CalViewDay is true)
            {
                ViewBag.CalendarDefault = "agendaDay";
            }
            var AppointmentList = await _patientAppointmentService.AppointmentList((int)Id);
            appointmentViewModel.patientAppointmentBasicsList = AppointmentList;
            appointmentViewModel.ProviderList = await _providerInfoService.GetProviderList();
            appointmentViewModel.ProviderSessionTypeList = await _providerSettingsService.GetAllSessionSettings();
            appointmentViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();
            if (TempData["AppointmentId"] == null)
            {
                TempData["AppointmentId"] = 0;
            }

            return View(appointmentViewModel);
        }

        #endregion patient Appointment

        #region Doctor Appointment calendar
        public async Task<IActionResult> ProviderCalendar(int? Id)
        {
            ViewBag.DoctorCalendar = "nav-active";
            var providerId = _sessionManager.GetProviderInfoId();
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();

            appointmentViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();

            //var PatientList = await _patientInfoService.patientInfo();
            //appointmentViewModel.PatientList = PatientList.Data;
            return View(appointmentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Reschedule(AppointmentViewModel appointmentViewModel)
        {
            var providerId = _sessionManager.GetProviderInfoId();

            if (appointmentViewModel.patientAppointmentBasicDto.AppointmentId > 0)
            {
                appointmentViewModel.patientAppointmentBasicDto.ModifyBy = Convert.ToInt32(providerId);
                var rec = await _patientAppointmentService.AppointmentUpdate(appointmentViewModel.patientAppointmentBasicDto);
                _patientAppointmentService.AppointmentStatus(rec.Data.AppointmentId, 6);

            }
            var patientData = _patientInfoService.GetPatientInfoById(Convert.ToInt64(appointmentViewModel.patientAppointmentBasicDto.PatientInfoId));

            DateTime today = DateTime.Today;
            appointmentViewModel.AppoinmentListforRecep = await _patientAppointmentService.AppointmentListForReceptionlist(today, providerId);

            return PartialView("~/Views/Appointment/PartialViews/_AppointmentsForReceptionList.cshtml", appointmentViewModel);
        }
        public async Task<IActionResult> ProviderGetCalendarsList(int Id)
        {
            var result = await _patientAppointmentService.AppointmentListByProviderId(Id);
            return Json(result);
        }
        public async Task<IActionResult> DocCalendar(int? Id)
        {
            ViewBag.DoctorCalendar = "nav-active";
            _sessionManager.SetProviderInfoId((long)Id);
            var providerId = _sessionManager.GetProviderInfoId();
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();

            appointmentViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();
            appointmentViewModel.calendarSettingDto = _patientAppointmentService.GetCalendarViewSet();
            if (appointmentViewModel.calendarSettingDto.CalViewMonth is true)
            {
                ViewBag.CalendarDefault = "month";
            }
            else if (appointmentViewModel.calendarSettingDto.CalViewWeek is true)
            {
                ViewBag.CalendarDefault = "agendaWeek";
            }
            else if (appointmentViewModel.calendarSettingDto.CalViewDay is true)
            {
                ViewBag.CalendarDefault = "agendaDay";
            }
            //var PatientList = await _patientInfoService.patientInfo();
            //appointmentViewModel.PatientList = PatientList.Data;
            if (TempData["AppointmentId"] == null)
            {
                TempData["AppointmentId"] = 0;
            }
            DateTime today = DateTime.Today;
            appointmentViewModel.AppoinmentListforRecep = await _patientAppointmentService.AppointmentListForReceptionlist(today, Id);

            return View(appointmentViewModel);
        }
         
      
        #endregion  Doctor Appointment calendar

        #region Filter Appointment
        public async Task<IActionResult> FilterByDocName(int DocId, int PatId)
        {
            var result = await _patientAppointmentService.AppointmentFilterByDocName(DocId, PatId);
            return Json(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> FilterCentralCalendarByPatient(ICollection<long?> PatId)
        {
            var result = await _patientAppointmentService.AppointmentCentralByPatient(PatId);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> FilterCentralCalendarByDoctor(ICollection<long?> DocId)
        {
            var result = await _patientAppointmentService.AppointmentCentralByDoctor(DocId);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> FilterCentralCalendarByDoctorPatient(ICollection<long?> PatId, ICollection<long?> DocId)
        {
            var result = await _patientAppointmentService.AppointmentCentralByDoctorPatient(PatId,DocId);
            return Json(result);
        }
        #endregion Filter Appointment

        #region Central Calendar
        public async Task<IActionResult> CentralCalendar(int? Id)
        {
            var providerId = _sessionManager.GetProviderInfoId();
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            appointmentViewModel.calendarSettingDto = _patientAppointmentService.GetCalendarViewSet();
            if (appointmentViewModel.calendarSettingDto.CalViewMonth is true)
            {
                ViewBag.CalendarDefault = "month";
            }
            else if (appointmentViewModel.calendarSettingDto.CalViewWeek is true)
            {
                ViewBag.CalendarDefault = "agendaWeek";
            }
            else if (appointmentViewModel.calendarSettingDto.CalViewDay is true)
            {
                ViewBag.CalendarDefault = "agendaDay";
            }
            appointmentViewModel.ProviderList = await _providerInfoService.GetProviderList();
            //var AppointmentList = await _patientAppointmentService.AppointmentListForCentral();
            //appointmentViewModel.patientAppointmentBasicsList = AppointmentList.Data;
            appointmentViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();

            return View(appointmentViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> CentralCalendarsList()
        {
            var result = await _patientAppointmentService.AppointmentListForCentral();
            return Json(result);
        }
        #endregion Central Calendar


        #region Appointment Queue Management
        public async Task<IActionResult> CurrentAppointments()
        {
            ViewBag.AppointmentQueue = "nav-active";
            AppointmentViewModel model = new AppointmentViewModel();
            model.AppointmentQueue = await GetAppointmentQueue();
            return View(model);
        }

        public async Task<IActionResult> CompleteAppointment(long Id)
        {
            AppointmentViewModel model = new AppointmentViewModel();
            var update = await _patientAppointmentService.CompleteAppointment(Id);
            model.AppointmentQueue = await GetAppointmentQueue();
            return PartialView("~/Views/Appointment/_AppointmentQueue.cshtml", model);
        }

        public async Task<List<AppointmentQueueDto>> GetAppointmentQueue()
        {
            long userId = _sessionManager.GetProviderInfoId();
            AppointmentViewModel model = new AppointmentViewModel();
            var RoleId = _sessionManager.GetRoleId();
            List<AppointmentQueueDto> appointmentQue = new List<AppointmentQueueDto>();

            if (RoleId == 2)
            {
                try
                {
                    var dateAndTime = DateTime.Now;
                    var date = dateAndTime.ToShortDateString();
                    appointmentQue = await _patientAppointmentService.AppointmentsForQueue(date, userId);
                }
                catch (Exception ex)
                {

                    throw;
                }
              
            }
            else
            {
                
                var dateAndTime = DateTime.Now;
                var date = dateAndTime.ToShortDateString();
                appointmentQue = await _patientAppointmentService.AppointmentsForQueue(date, null);

            }
            
            return appointmentQue;
        }

        public ActionResult PatientQueue()
        {
            return View();
        }

        #endregion

        #region batchAppointment
        public async Task<IActionResult> BatchAppointmentSave(AppointmentViewModel appointmentViewModel)
        {
            string[] data = appointmentViewModel.patientAppointmentBasicDto.SelectedData.Split(new string[] { "|-|" }, StringSplitOptions.None);
            PatientAppointmentBasicDto patientAppointmentBasicDto = new PatientAppointmentBasicDto();
            var count = 0;
            var durationCount = 0;
            double dobule = 0;
            foreach (var item in data)
            {
                if (count == 0)
                {
                    if (item != "")
                    {
                        string[] metadata = item.Split(new string[] { "_" }, StringSplitOptions.None);
                        patientAppointmentBasicDto.PatientInfoId = Convert.ToInt64(metadata[0]);
                        patientAppointmentBasicDto.ProviderInfoId = Convert.ToInt64(metadata[1]);
                        patientAppointmentBasicDto.AppointmentType = "Exact";
                        patientAppointmentBasicDto.Date = Convert.ToDateTime(metadata[3]).Date;

                        patientAppointmentBasicDto.ExactTime = Convert.ToDateTime(metadata[4]);
                        await _patientAppointmentService.AppointmentCreate(patientAppointmentBasicDto);

                    }

                }
                else
                {
                    if (item != "")
                    {
                        if (durationCount == 0)
                        {
                            string[] metadata = item.Split(new string[] { "_" }, StringSplitOptions.None);
                            dobule = Convert.ToDouble(metadata[2]);
                            patientAppointmentBasicDto.PatientInfoId = Convert.ToInt64(metadata[0]);
                            patientAppointmentBasicDto.ProviderInfoId = Convert.ToInt64(metadata[1]);
                            patientAppointmentBasicDto.AppointmentType = "Exact";
                            patientAppointmentBasicDto.Date = Convert.ToDateTime(metadata[3]);

                            patientAppointmentBasicDto.ExactTime = Convert.ToDateTime(metadata[4]).AddMinutes(dobule);
                            await _patientAppointmentService.AppointmentCreate(patientAppointmentBasicDto);
                            durationCount++;
                        }
                        else
                        {
                            string[] metadata = item.Split(new string[] { "_" }, StringSplitOptions.None);
                            //dobule = Convert.ToDouble(metadata[2]);
                            patientAppointmentBasicDto.PatientInfoId = Convert.ToInt64(metadata[0]);
                            patientAppointmentBasicDto.ProviderInfoId = Convert.ToInt64(metadata[1]);
                            patientAppointmentBasicDto.AppointmentType = "Exact";
                            patientAppointmentBasicDto.Date = Convert.ToDateTime(metadata[3]);
                            dobule = dobule * 2;
                            patientAppointmentBasicDto.ExactTime = Convert.ToDateTime(metadata[4]).AddMinutes(dobule);
                            await _patientAppointmentService.AppointmentCreate(patientAppointmentBasicDto);
                            durationCount++;
                        }

                    }

                }
                count++;
            }

            return Json("success");
        }
        #endregion batchAppointment

        #region bulkAppointment
        [HttpPost]
        public async Task<IActionResult> BulkExactAppointment(AppointmentViewModel appointmentViewModel)
        {

            long providerId;
            var objRecurringApt = appointmentViewModel.patientAppointmentBasicDto;
            var RoleId = _sessionManager.GetRoleId();
            if (RoleId == 5)
            {
                if (appointmentViewModel.patientAppointmentBasicDto.ProviderInfoId is null)
                {
                    providerId = _sessionManager.GetProviderInfoId();
                }
                else
                {
                    providerId = (long)appointmentViewModel.patientAppointmentBasicDto.ProviderInfoId;

                }
            }
            else
            {
                providerId = _sessionManager.GetProviderInfoId();
            }

            var exisit =await _patientAppointmentService.AppointmentCheck(appointmentViewModel.patientAppointmentBasicDto);
            if (exisit.Message == "1")
            {
                return Json(exisit.Data);
            }
            var count = 0;
            var durationCount = 0;
            var dobule = 0;
            foreach (var item in objRecurringApt.PatientId)
            {
                PatientAppointmentBasicDto patientAppointmentBasicDto = new PatientAppointmentBasicDto();
                if (count == 0)
                {
                    patientAppointmentBasicDto.PatientInfoId = Convert.ToInt64(item);
                    patientAppointmentBasicDto.AppointmentType = objRecurringApt.AppointmentType;
                    patientAppointmentBasicDto.ProviderInfoId = providerId;
                    patientAppointmentBasicDto.StartTime = objRecurringApt.StartTime;
                    patientAppointmentBasicDto.EndTime = patientAppointmentBasicDto.StartTime;
                    patientAppointmentBasicDto.Date = objRecurringApt.Date;
                    patientAppointmentBasicDto.DepartmentType = 1;
                    await _patientAppointmentService.AppointmentCreate(patientAppointmentBasicDto);
                }
                else
                {
                   
                    if (durationCount == 0)
                    {
                        dobule = objRecurringApt.Duration;
                        patientAppointmentBasicDto.PatientInfoId = Convert.ToInt64(item);
                        patientAppointmentBasicDto.AppointmentType = objRecurringApt.AppointmentType;
                        patientAppointmentBasicDto.ProviderInfoId = providerId;
                        //patientAppointmentBasicDto.ExactTime = Convert.ToDateTime(objRecurringApt.ExactTime).AddMinutes(dobule);
                        TimeSpan STime = new TimeSpan();
                        STime = (TimeSpan)objRecurringApt.StartTime;
                        TimeSpan newSpan = new TimeSpan(0, 0, dobule, 0);
                        patientAppointmentBasicDto.StartTime = STime.Add(newSpan);
                        patientAppointmentBasicDto.EndTime = patientAppointmentBasicDto.StartTime;
                        patientAppointmentBasicDto.DepartmentType = 1;

                        patientAppointmentBasicDto.Date = objRecurringApt.Date;
                        await _patientAppointmentService.AppointmentCreate(patientAppointmentBasicDto);
                        durationCount++;
                    }
                    else
                    {
                        //dobule = objRecurringApt.Duration;
                        patientAppointmentBasicDto.PatientInfoId = Convert.ToInt64(item);
                        patientAppointmentBasicDto.AppointmentType = objRecurringApt.AppointmentType;
                        patientAppointmentBasicDto.ProviderInfoId = providerId;
                        dobule = dobule * 2;
                        TimeSpan STime = new TimeSpan();
                        STime = (TimeSpan)objRecurringApt.StartTime;
                        TimeSpan newSpan = new TimeSpan(0, 0, dobule, 0);
                        patientAppointmentBasicDto.StartTime = STime.Add(newSpan);
                        patientAppointmentBasicDto.EndTime = patientAppointmentBasicDto.StartTime;
                        patientAppointmentBasicDto.DepartmentType = 1;

                        //patientAppointmentBasicDto.ExactTime = Convert.ToDateTime(objRecurringApt.ExactTime).AddMinutes(dobule);
                        patientAppointmentBasicDto.Date = objRecurringApt.Date;

                        await _patientAppointmentService.AppointmentCreate(patientAppointmentBasicDto);
                        durationCount++;
                    }
                   
                }
                count++;
            }
            

            return Json("success");
        }
        [HttpPost]
        public async Task<IActionResult> BulkExactRecAppointment(AppointmentViewModel appointmentViewModel)
        {
            var recurison_no = _patientAppointmentService.GetLatestRecursionNo();
            var count = 0;
            var durationCount = 0;
            var dobule = 0;
            var providerId = _sessionManager.GetProviderInfoId();
            string dt = String.Format("{0:MM/dd/yyyy}", appointmentViewModel.RecurringAppoinmentDto.Date) + " " + appointmentViewModel.RecurringAppoinmentDto.ExactTime;
            DateTime stime = DateTime.Parse(dt);
            dt = String.Format("{0:MM/dd/yyyy}", appointmentViewModel.RecurringAppoinmentDto.EndDate) + " " + appointmentViewModel.RecurringAppoinmentDto.ExactTime;
            DateTime etime = DateTime.Parse(dt);
            //if (stime <= DateTime.UtcNow)
            //{
            //    return Json("-4", appointmentViewModel);
            //}

            if (stime > etime)
            {
                return Json("-2", appointmentViewModel);
            }
            var objRecurringApt = appointmentViewModel.RecurringAppoinmentDto;
            objRecurringApt.ProviderInfoId = providerId;
            TimeSpan days = etime.Subtract(stime);
            for (int i = 0; i <= days.Days; i++)
            {
                bool CreateAppointment = false;
                var AptStartDate = objRecurringApt.Date;
                var AptEndDate = objRecurringApt.EndDate;
                var RecurringAptStartDate = objRecurringApt.Date.Value.AddDays(i);
                var RecurringAptEndDate = objRecurringApt.EndDate.Value.AddDays(i);
                var RecurringAptDayOfWeek = objRecurringApt.Date.Value.AddDays(i).DayOfWeek.ToString();
                if (objRecurringApt.IsSundayChecked && RecurringAptDayOfWeek.Equals("Sunday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsMondayChecked && RecurringAptDayOfWeek.Equals("Monday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsTuesdayChecked && RecurringAptDayOfWeek.Equals("Tuesday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsWednesdayChecked && RecurringAptDayOfWeek.Equals("Wednesday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsThursdayChecked && RecurringAptDayOfWeek.Equals("Thursday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsFridayChecked && RecurringAptDayOfWeek.Equals("Friday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsSaturdayChecked && RecurringAptDayOfWeek.Equals("Saturday"))
                {
                    CreateAppointment = true;
                }
                else
                {
                    CreateAppointment = false;
                }
                if (CreateAppointment)
                {
                    try
                    {
                       
                        if (!(objRecurringApt is null))
                        {
                            PatientAppointmentBasicDto patientAppointment = new PatientAppointmentBasicDto();

                            foreach (var item in objRecurringApt.PatientId)
                            {
                                if (count == 0)
                                {
                                    patientAppointment.PatientInfoId =Convert.ToInt64(item);
                                    patientAppointment.AppointmentType = objRecurringApt.AppointmentType;
                                    patientAppointment.Date = RecurringAptStartDate;
                                    patientAppointment.EndDate = objRecurringApt.EndDate;
                                    patientAppointment.ExactTime = Convert.ToDateTime(objRecurringApt.ExactTime);
                                    patientAppointment.RecursionNo = recurison_no;

                                    patientAppointment.ProviderInfoId = objRecurringApt.ProviderInfoId;
                                    await _patientAppointmentService.AppointmentCreate(patientAppointment);
                                }
                                else
                                {
                                    if (durationCount == 0)
                                    {
                                        dobule = objRecurringApt.Duration;
                                        patientAppointment.PatientInfoId = item;
                                        patientAppointment.AppointmentType = objRecurringApt.AppointmentType;
                                        patientAppointment.Date = RecurringAptStartDate;
                                        patientAppointment.EndDate = objRecurringApt.EndDate;
                                        patientAppointment.ExactTime = Convert.ToDateTime(objRecurringApt.ExactTime).AddMinutes(dobule);
                                        patientAppointment.RecursionNo = recurison_no;

                                        patientAppointment.ProviderInfoId = objRecurringApt.ProviderInfoId;
                                        await _patientAppointmentService.AppointmentCreate(patientAppointment);
                                        durationCount++;
                                    }
                                    else
                                    {
                                        //dobule = objRecurringApt.Duration;
                                        patientAppointment.PatientInfoId = item;
                                        patientAppointment.AppointmentType = objRecurringApt.AppointmentType;
                                        patientAppointment.Date = RecurringAptStartDate;
                                        patientAppointment.EndDate = objRecurringApt.EndDate;
                                        dobule = dobule * 2;
                                        patientAppointment.ExactTime = Convert.ToDateTime(objRecurringApt.ExactTime).AddMinutes(dobule);
                                        patientAppointment.RecursionNo = recurison_no;

                                        patientAppointment.ProviderInfoId = objRecurringApt.ProviderInfoId;
                                        await _patientAppointmentService.AppointmentCreate(patientAppointment);
                                        durationCount++;
                                    }
                                }
                                count++;
                            }


                        }

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    if (RecurringAptStartDate == AptEndDate)
                    {
                        break;
                    }
                }
            }


            return Json(appointmentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> BulkBtwAppointment(AppointmentViewModel appointmentViewModel)
        {

            long providerId;
            var objRecurringApt = appointmentViewModel.patientAppointmentBasicDto;
            var RoleId = _sessionManager.GetRoleId();
            if (RoleId == 5)
            {
                if (appointmentViewModel.patientAppointmentBasicDto.ProviderInfoId is null)
                {
                    providerId = _sessionManager.GetProviderInfoId();
                }
                else
                {
                    providerId = (long)appointmentViewModel.patientAppointmentBasicDto.ProviderInfoId;

                }
            }
            else
            {
                providerId = _sessionManager.GetProviderInfoId();
            }
            var exisit = await _patientAppointmentService.AppointmentCheck(appointmentViewModel.patientAppointmentBasicDto);
            if (exisit.Message == "1")
            {
                return Json(exisit.Data);
            }
            var count = 0;
            var durationCount = 0;
            var dobule = 0;
            foreach (var item in objRecurringApt.PatientId)
            {
                PatientAppointmentBasicDto patientAppointmentBasicDto = new PatientAppointmentBasicDto();
                if (count == 0)
                {
                    patientAppointmentBasicDto.PatientInfoId = Convert.ToInt64(item);
                    patientAppointmentBasicDto.AppointmentType = objRecurringApt.AppointmentType;
                    patientAppointmentBasicDto.ProviderInfoId = providerId;
                    patientAppointmentBasicDto.StartTime = objRecurringApt.StartTime;
                    patientAppointmentBasicDto.EndTime = objRecurringApt.EndTime;
                    patientAppointmentBasicDto.Date = objRecurringApt.Date;
                    patientAppointmentBasicDto.DepartmentType = 1;
                    await _patientAppointmentService.AppointmentCreate(patientAppointmentBasicDto);
                }
                else
                {
                    if (durationCount == 0)
                    {
                        dobule = objRecurringApt.Duration;
                        patientAppointmentBasicDto.PatientInfoId = Convert.ToInt64(item);
                        patientAppointmentBasicDto.AppointmentType = objRecurringApt.AppointmentType;
                        patientAppointmentBasicDto.ProviderInfoId = providerId;
                        //patientAppointmentBasicDto.StartTime = TimeSpan.Parse(objRecurringApt.StartTime).AddMinutes(dobule);
                        //patientAppointmentBasicDto.EndTime = TimeSpan.Parse(objRecurringApt.EndTime).AddMinutes(dobule);
                        TimeSpan STime = new TimeSpan();
                        TimeSpan ETime = new TimeSpan();
                        STime = (TimeSpan)objRecurringApt.StartTime;
                        ETime = (TimeSpan)objRecurringApt.EndTime;
                        TimeSpan newSpan = new TimeSpan(0, 0, dobule, 0);
                        patientAppointmentBasicDto.StartTime = STime.Add(newSpan);
                        patientAppointmentBasicDto.EndTime = ETime.Add(newSpan);
                        patientAppointmentBasicDto.Date = objRecurringApt.Date;
                        patientAppointmentBasicDto.DepartmentType = 1;

                        await _patientAppointmentService.AppointmentCreate(patientAppointmentBasicDto);
                        durationCount++;
                    }
                    else
                    {
                        //dobule = objRecurringApt.Duration;
                        patientAppointmentBasicDto.PatientInfoId = Convert.ToInt64(item);
                        patientAppointmentBasicDto.AppointmentType = objRecurringApt.AppointmentType;
                        patientAppointmentBasicDto.ProviderInfoId = providerId;
                        dobule = dobule * 2;
                        //patientAppointmentBasicDto.StartTime = Convert.ToDateTime(objRecurringApt.StartTime).AddMinutes(dobule);
                        //patientAppointmentBasicDto.EndTime = Convert.ToDateTime(objRecurringApt.EndTime).AddMinutes(dobule);
                        TimeSpan STime = new TimeSpan();
                        TimeSpan ETime = new TimeSpan();
                        STime = (TimeSpan)objRecurringApt.StartTime;
                        ETime = (TimeSpan)objRecurringApt.EndTime;
                        TimeSpan newSpan = new TimeSpan(0, 0, dobule, 0);
                        patientAppointmentBasicDto.StartTime = STime.Add(newSpan);
                        patientAppointmentBasicDto.EndTime = ETime.Add(newSpan);
                        patientAppointmentBasicDto.Date = objRecurringApt.Date;
                        patientAppointmentBasicDto.DepartmentType = 1;
                        await _patientAppointmentService.AppointmentCreate(patientAppointmentBasicDto);
                        durationCount++;
                    }

                }
                count++;
            }


            return Json("success");
        }
        [HttpPost]
        public async Task<IActionResult> BulkBtwRecAppointment(AppointmentViewModel appointmentViewModel)
        {
            var recurison_no = _patientAppointmentService.GetLatestRecursionNo();
            var count = 0;
            var durationCount = 0;
            var dobule = 0;
            var providerId = _sessionManager.GetProviderInfoId();
            string dt = String.Format("{0:MM/dd/yyyy}", appointmentViewModel.RecurringAppoinmentDto.Date) + " " + appointmentViewModel.RecurringAppoinmentDto.ExactTime;
            DateTime stime = DateTime.Parse(dt);
            dt = String.Format("{0:MM/dd/yyyy}", appointmentViewModel.RecurringAppoinmentDto.EndDate) + " " + appointmentViewModel.RecurringAppoinmentDto.ExactTime;
            DateTime etime = DateTime.Parse(dt);
            //if (stime <= DateTime.UtcNow)
            //{
            //    return Json("-4", appointmentViewModel);
            //}

            if (stime > etime)
            {
                return Json("-2", appointmentViewModel);
            }
            var objRecurringApt = appointmentViewModel.RecurringAppoinmentDto;
            objRecurringApt.ProviderInfoId = providerId;
            TimeSpan days = etime.Subtract(stime);
            for (int i = 0; i <= days.Days; i++)
            {
                bool CreateAppointment = false;
                var AptStartDate = objRecurringApt.Date;
                var AptEndDate = objRecurringApt.EndDate;
                var RecurringAptStartDate = objRecurringApt.Date.Value.AddDays(i);
                var RecurringAptEndDate = objRecurringApt.EndDate.Value.AddDays(i);
                var RecurringAptDayOfWeek = objRecurringApt.Date.Value.AddDays(i).DayOfWeek.ToString();
                if (objRecurringApt.IsSundayChecked && RecurringAptDayOfWeek.Equals("Sunday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsMondayChecked && RecurringAptDayOfWeek.Equals("Monday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsTuesdayChecked && RecurringAptDayOfWeek.Equals("Tuesday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsWednesdayChecked && RecurringAptDayOfWeek.Equals("Wednesday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsThursdayChecked && RecurringAptDayOfWeek.Equals("Thursday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsFridayChecked && RecurringAptDayOfWeek.Equals("Friday"))
                {
                    CreateAppointment = true;
                }
                else if (objRecurringApt.IsSaturdayChecked && RecurringAptDayOfWeek.Equals("Saturday"))
                {
                    CreateAppointment = true;
                }
                else
                {
                    CreateAppointment = false;
                }
                if (CreateAppointment)
                {
                    try
                    {

                        if (!(objRecurringApt is null))
                        {
                            PatientAppointmentBasicDto patientAppointment = new PatientAppointmentBasicDto();

                            foreach (var item in objRecurringApt.PatientId)
                            {
                                if (count == 0)
                                {
                                    patientAppointment.PatientInfoId = Convert.ToInt64(item);
                                    patientAppointment.AppointmentType = objRecurringApt.AppointmentType;
                                    patientAppointment.Date = RecurringAptStartDate;
                                    patientAppointment.EndDate = objRecurringApt.EndDate;
                                    patientAppointment.StartTime = TimeSpan.Parse(objRecurringApt.StartTime);
                                    patientAppointment.EndTime = TimeSpan.Parse(objRecurringApt.EndTime);
                                    patientAppointment.RecursionNo = recurison_no;

                                    patientAppointment.ProviderInfoId = objRecurringApt.ProviderInfoId;
                                    await _patientAppointmentService.AppointmentCreate(patientAppointment);
                                }
                                else
                                {
                                    if (durationCount == 0)
                                    {
                                        dobule = objRecurringApt.Duration;
                                        patientAppointment.PatientInfoId = item;
                                        patientAppointment.AppointmentType = objRecurringApt.AppointmentType;
                                        patientAppointment.Date = RecurringAptStartDate;
                                        patientAppointment.EndDate = objRecurringApt.EndDate;
                                        //patientAppointment.StartTime = TimeSpan.Parse(objRecurringApt.StartTime).AddMinutes(dobule);
                                        //patientAppointment.EndTime = TimeSpan.Parse(objRecurringApt.EndTime).AddMinutes(dobule);
                                        patientAppointment.RecursionNo = recurison_no;

                                        patientAppointment.ProviderInfoId = objRecurringApt.ProviderInfoId;
                                        await _patientAppointmentService.AppointmentCreate(patientAppointment);
                                        durationCount++;
                                    }
                                    else
                                    {
                                        //dobule = objRecurringApt.Duration;
                                        patientAppointment.PatientInfoId = item;
                                        patientAppointment.AppointmentType = objRecurringApt.AppointmentType;
                                        patientAppointment.Date = RecurringAptStartDate;
                                        patientAppointment.EndDate = objRecurringApt.EndDate;
                                        dobule = dobule * 2;
                                        //patientAppointment.StartTime = TimeSpan.Parse(objRecurringApt.StartTime).AddMinutes(dobule);
                                        //patientAppointment.EndTime = TimeSpan.Parse(objRecurringApt.EndTime).AddMinutes(dobule);
                                        patientAppointment.RecursionNo = recurison_no;

                                        patientAppointment.ProviderInfoId = objRecurringApt.ProviderInfoId;
                                        await _patientAppointmentService.AppointmentCreate(patientAppointment);
                                        durationCount++;
                                    }
                                }
                                count++;
                            }


                        }

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    if (RecurringAptStartDate == AptEndDate)
                    {
                        break;
                    }
                }
            }


            return Json(appointmentViewModel);
        }

        #endregion bulkAppointment

        public IActionResult GetAppointmentId(int? appointId)
        {
           
            string action = "";
            if (appointId != 0)
            {
                TempData["AppointmentId"] = appointId;
            }
            else
            {
                TempData["AppointmentId"] = 0;
            }
            if (_sessionManager.GetRoleId() == 2)
            {
                action = "DocCalendar";

            }
            if (_sessionManager.GetRoleId() == 1)
            {
                action = "PatientCalendar";
                var PatientID = _sessionManager.GetPatientInfoId();
                return RedirectToAction("PatientCalendar", "Appointment", new { Id = PatientID });


            }
            return RedirectToAction(action);
        }

        public async Task<IActionResult> GetAppointmentDetailById(int Id)
        {
            var data = await _patientAppointmentService.AppointmentDetails(Id);
            return Json(data);
        }


        #region Receptionist
        public async Task<IActionResult> DocCurrentAppointment(long Id)
        {
            AppointmentViewModel model = new AppointmentViewModel();
            ViewBag.AppointmentQueue = "nav-active";
           
            var roleId = _sessionManager.GetRoleId();
            if (roleId == 2)
            {
                var provider = await _providerInfoService.GetProviderSummaryDetails(Id);
                _sessionManager.SetPatientInfoId(0);
                _sessionManager.SetProviderName(provider.FullName);
                _sessionManager.SetProviderInfoId(Id);
                var PermisionPageList = await _userRolePageService.GetSideBarList((int)roleId);
                _sessionManager.SetPermisionPage(PermisionPageList);
                model.AppointmentQueue = await GetAppointmentQueue();
            }
            else
            {
                model.AppointmentQueue = await GetAppointmentQueue();
            }
            
            return View(model);
        }
      
        public async Task<IActionResult> AppointmentListForReceptionist(int? Id)
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            DateTime today = DateTime.Today;
            appointmentViewModel.ProviderList = await _providerInfoService.GetProviderList();
            appointmentViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();
            appointmentViewModel.patientAppointmentBasicsList = await _patientAppointmentService.AppointmentListForCentral();
            appointmentViewModel.AppoinmentListforRecep = await _patientAppointmentService.AppointmentListForReceptionlist(today,null);
            appointmentViewModel.patientAppointmentBasicsList = await _patientAppointmentService.OTAndOPDListForReceptionist(today);
            appointmentViewModel.calendarSettingDto = _patientAppointmentService.GetCalendarViewSet();
            if (appointmentViewModel.calendarSettingDto.CalViewMonth is true)
            {
                ViewBag.CalendarDefault = "month";
            }
            else if (appointmentViewModel.calendarSettingDto.CalViewWeek is true)
            {
                ViewBag.CalendarDefault = "agendaWeek";
            }
            else if (appointmentViewModel.calendarSettingDto.CalViewDay is true)
            {
                ViewBag.CalendarDefault = "agendaDay";
            }
            return View(appointmentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AppointmentListForReceptionist(DateTime dateTime)
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
     
            appointmentViewModel.AppoinmentListforRecep = await _patientAppointmentService.AppointmentListForReceptionlist(dateTime,null);
            return PartialView("~/Views/Appointment/PartialViews/_AppointmentsForReceptionList.cshtml", appointmentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AppointmentListForDoctorCalendar(DateTime dateTime, long Id)
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();

            appointmentViewModel.AppoinmentListforRecep = await _patientAppointmentService.AppointmentListForReceptionlist(dateTime, Id);
            return PartialView("~/Views/Appointment/PartialViews/_AppointmentsForReceptionList.cshtml", appointmentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveSlotsbyReceptionist(long SlotId,long PatId)
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            DateTime today = DateTime.Today;

            _patientAppointmentService.GetSlotsDetailByIdAndAppointmentSave(SlotId, PatId,"Receptionist");
            appointmentViewModel.ProviderList = await _providerInfoService.GetProviderList();
            appointmentViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();
            
            appointmentViewModel.AppoinmentListforRecep = await _patientAppointmentService.AppointmentListForReceptionlist(today,null);
            var patientInfos = await _patientInfoService.GetPatientSummaryDetails(PatId);

            var rec = CommonMethod.SendVerificationCodeForAppointment(patientInfos.MobilePhone);
            return PartialView("~/Views/Appointment/PartialViews/_AppointmentsForReceptionList.cshtml", appointmentViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> AppointmentStatusChange(long AppId,int Id)
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            DateTime today = DateTime.Today;
            _patientAppointmentService.AppointmentStatus(AppId, Id);
            appointmentViewModel.AppoinmentListforRecep = await _patientAppointmentService.AppointmentListForReceptionlist(today,null);

            return PartialView("~/Views/Appointment/PartialViews/_AppointmentsForReceptionList.cshtml", appointmentViewModel);
            
        }
        [HttpPost]
        public async Task<IActionResult> AppointmentStatusChangeDoctor(long AppId, int Id)
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            DateTime today = DateTime.Today;
            _patientAppointmentService.AppointmentStatus(AppId, Id);
            var providerId = _sessionManager.GetProviderInfoId();
            appointmentViewModel.AppoinmentListforRecep = await _patientAppointmentService.AppointmentListForReceptionlist(today, providerId);

            return PartialView("~/Views/Appointment/PartialViews/_AppointmentsForReceptionList.cshtml", appointmentViewModel);

        }
        public async Task<IActionResult> DoctorScheduleList(int? Id)
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            appointmentViewModel.ScheduleList = await _providerInfoService.AllScheduleList();
            return View(appointmentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSchedule(int Id)
        {
            var result = await _providerInfoService.DeleteScheduleByProviderId(Id);
            var data = new { Result = result };
            return Json(data);
        }





        #endregion Receptionist


        #region OT Appointment
        [HttpPost]
        public async Task<IActionResult> OTAppointmentAdd(AppointmentViewModel appointmentViewModel)
        {
            if (appointmentViewModel.patientAppointmentBasicDto.DepartmentType == 2)
            {
               appointmentViewModel.patientAppointmentBasicDto.AppointmentType = "OT";
            }
            else if (appointmentViewModel.patientAppointmentBasicDto.DepartmentType == 3)
            {
               appointmentViewModel.patientAppointmentBasicDto.AppointmentType = "OPD";

            }
            await _patientAppointmentService.AppointmentCreate(appointmentViewModel.patientAppointmentBasicDto);
            DateTime today = DateTime.Today;
            appointmentViewModel.patientAppointmentBasicsList = await _patientAppointmentService.OTAndOPDListForReceptionist(today);
            return PartialView("~/Views/Appointment/PartialViews/_OTAndOPDList.cshtml", appointmentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> OTAndOPDForReceptionist(DateTime dateTime)
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();

            appointmentViewModel.patientAppointmentBasicsList = await _patientAppointmentService.OTAndOPDListForReceptionist(dateTime);
            return PartialView("~/Views/Appointment/PartialViews/_OTAndOPDList.cshtml", appointmentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> OTAppointmentStatusChange(long AppId, int Id)
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            DateTime today = DateTime.Today;
            _patientAppointmentService.AppointmentStatus(AppId, Id);
            appointmentViewModel.patientAppointmentBasicsList = await _patientAppointmentService.OTAndOPDListForReceptionist(today);

            return PartialView("~/Views/Appointment/PartialViews/_OTAndOPDList.cshtml", appointmentViewModel);

        }
        public async Task<IActionResult> ProviderGetOTCalendarsList(int Id)
        {
            var result = await _patientAppointmentService.OTAppointmentListByProviderId(Id);
            return Json(result);
        }
        public async Task<IActionResult> ProviderGetOPDCalendarsList(int Id)
        {
            var result = await _patientAppointmentService.OPDAppointmentListByProviderId(Id);
            return Json(result);
        }
        #endregion OT Appointment






        #region Events
        public async Task<IActionResult> UserEvents(long? userId)
        {
            var providerId = _sessionManager.GetProviderInfoId();
            var response = await _userEvents.GetEventsistByUserId((long)providerId);
            return Json(response.Data);
        } 
        [HttpPost]
        public async Task<IActionResult> CreateEvent(AppointmentViewModel viewModel)
        {
            var response = await _userEvents.CreateUpdateEvent(viewModel.UserEvents);
            var data = new { Result = true };
            return Json(data);
        }
        public async Task<IActionResult> GetEventById(int eventId)
        {
            var response = await _userEvents.GetEventsistById(eventId);
            return Json(response.Data);
        }

        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            var response = await _userEvents.DeleteEvent(eventId);
            return Json(response.Data);
        }


        #endregion
    }
}