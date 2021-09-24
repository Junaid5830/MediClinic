using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediClinic.Models.EntityModels;
using MediClinic.Services.AutoMapper;
using MediClinic.Services.Interfaces.AuthInterface;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.PatientArbitrationAttorneyInterface;
using MediClinic.Services.Interfaces.PatientClaimInfoInterface;
using MediClinic.Services.Interfaces.PatientEmergencyContactInterface;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using MediClinic.Services.Interfaces.PatientPersonalInjuryInterface;
using MediClinic.Services.Interfaces.PatientPhoneNumberInterface;
using MediClinic.Services.Interfaces.PatientSecondaryInsuranceInterface;
using MediClinic.Services.Interfaces.PatientTertiaryInsuranceInterface;
using MediClinic.Services.Interfaces.PatientVehicleInterface;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces.ProviderTemplateInterface;
using MediClinic.Services.Interfaces.RelatedFacilityInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.UserInRolesInterface;
using MediClinic.Services.Services.AuthServices;
using MediClinic.Services.Services.LookupServices;
using MediClinic.Services.Services.PatientArbitrationAttorneyService;
using MediClinic.Services.Services.PatientClaimInfoService;
using MediClinic.Services.Services.PatientEmergencyContactService;
using MediClinic.Services.Services.PatientInfoService;
using MediClinic.Services.Services.PatientPersonalInjuryService;
using MediClinic.Services.Services.PatientPhoneNumberService;
using MediClinic.Services.Services.PatientSecondaryInsuranceService;
using MediClinic.Services.Services.PatientTertiaryInsuranceService;
using MediClinic.Services.Services.ProviderInfoService;
using MediClinic.Services.Services.SubContractorInfoService;
using MediClinic.Services.Services.ProviderTemplateService;
using MediClinic.Services.Services.RelatedFacilityService;
using MediClinic.Services.Services.PatientVehicleService;
using MediClinic.Services.Services.SessionManager;
using MediClinic.Services.Services.UserInRolesService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediClinic.Services.Interfaces.PatientIdandSignatureInterface;
using MediClinic.Services.Services.PatientIdandSignatureService;
using MediClinic.Services.Interfaces.PatientTreatmentStatusInterface;
using MediClinic.Services.Services.PatientTreatmentStatusService;
using MediClinic.Services.Interfaces.PatientLegalStatusInterface;
using MediClinic.Services.Services.PatientLegalStatusService;
using MediClinic.Services.Interfaces.ClaimStatusInterface;
using MediClinic.Services.Services.ClaimStatusService;
using MediClinic.Services.Interfaces.IncidentReportStatusInterface;
using MediClinic.Services.Services.IncidentReportStatusService;
using MediClinic.Services.Interfaces.Nf2StatusInterface;
using MediClinic.Services.Services.Nf2StatusService;
using MediClinic.Services.Interfaces.PatientIncidentRoleInterface;
using MediClinic.Services.Services.PatientIncidentRoleService;
using MediClinic.Services.Interfaces.UserInterface;
using MediClinic.Services.Services.UserService;
using MediClinic.Services.Interfaces.ProviderSpecialityInterface;
using MediClinic.Services.Interfaces.ProviderTermInterface;
using MediClinic.Services.Services.ProviderSpecialityService;
using MediClinic.Services.Services.ProviderTermService;
using MediClinic.Services.Interfaces.ProviderUidTypeInterface;
using MediClinic.Services.Services.ProviderUidTypeService;
using MediClinic.Services.Interfaces.PatientCaseTypeInterface;
using MediClinic.Services.Services.PatientCaseTypeService;
using MediClinic.Services.Interfaces.SubProviderInterface;
using MediClinic.Services.Services.SubProviderService;
using MediClinic.Services.Interfaces.LegalInfoLegalInterface;
using MediClinic.Services.Services.LegalInfoLegalService;
using MediClinic.Services.Interfaces.AddNewCaseTypeInterface;
using MediClinic.Services.Services.AddNewCaseTypeService;
using MediClinic.Services.Interfaces.PatientRelationshipInterface;
using MediClinic.Services.Services.PatientRelationshipService;
using MediClinic.Services.Interfaces.EmploymentStatusInterface;
using MediClinic.Services.Services.EmploymentStatusService;
using MediClinic.Services.Interfaces.EmploymentTitleInterface;
using MediClinic.Services.Services.EmploymentTitleService;
using MediClinic.Services.Interfaces.PatientSignatureIdTypeInterface;
using MediClinic.Services.Services.PatientSignatureIdTypeService;
using MediClinic.Services.Interfaces.InsuranceProviderNameInterface;
using MediClinic.Services.Services.InsuranceProviderService;
using MediClinic.Services.Interfaces.InsuranceGroupNumberInterface;
using MediClinic.Services.Services.InsuranceGroupNumberService;
using MediClinic.Services.Interfaces.LeagalInfoFirmNameInterface;
using MediClinic.Services.Services.LegalInfoFirmNameService;
using MediClinic.Services.Interfaces.LegalInfoAttorneyNameInterface;
using MediClinic.Services.Services.LegalInfoAttorneyNameService;
using MediClinic.Services.Interfaces.LegalInfoLeadingAttorney;
using MediClinic.Services.Services.LegalInfoLeadingAttorneyService;
using MediClinic.Services.Interfaces.LegalInfoLeadingParalegalInterface;
using MediClinic.Services.Services.LegalInfoLeadingParalegalService;
using MedliClinic.Utilities.Utility.Enum;
using Microsoft.EntityFrameworkCore;
using MediClinic.Services.Interfaces.PatientLanguageInterface;
using MediClinic.Services.Services.PatientLanguageService;
using MediClinic.Services.Interfaces;
using MediClinic.Services.Services.PatientExamService;
using MediClinic.Services.Interfaces.PatientVitalInterface;
using MediClinic.Services.Services.PatientVitalService;
using MediClinic.Services.Interfaces.MedicalDiseaseTypeInterface;
using MediClinic.Services.Services.MedicalDiseaseTypeService;
using MediClinic.Services.Interfaces.PatientMedicalProblemInterface;
using MediClinic.Services.Services.PatientMedicalProblemService;
using MediClinic.Services.Interfaces.PatientMissingInterface;
using MediClinic.Services.Services.PatientMissingService;
using MediClinic.Services.Interfaces.PatientMedicalHistoryInterface;
using MediClinic.Services.Services.PatientMedicalHistoryService;
using MediClinic.Services.Interfaces.Doctor;
using MediClinic.Services.Services.Doctor;
using MediClinic.Services.Interfaces.Patient;
using MediClinic.Services.Services.Patient;
using MediClinic.Services.Services;
using MediClinic.Services.Interfaces.PatientSettings;
using MediClinic.Services.Services.PatientSettings;
using MediClinic.Services.Interfaces.PatientPrescriptionInterface;
using MediClinic.Services.Services.PatientPrescriptionService;
using MediClinic.Services.Interfaces.PatientAppointmentInterface;
using MediClinic.Services.Services.PatientAppointmentService;
using MediClinic.Services.Interfaces.ClinicalNotesInterface;
using MediClinic.Services.Services.ClinicalNotesService;
using MediClinic.Services.Interfaces.PrescriptionTemplateService;
using MediClinic.Services.Services.PrescriptionTemplateService;
using MediClinic.Services.Services.DMESuppliesService;
using MediClinic.SignalRHub;
using MediClinic.Services.Interfaces.Notification;
using MediClinic.Services.Services.Notification;
using MediClinic.Services.Services.SettingsService;
using MediClinic.Services.Interfaces.EmployeeInterface;
using MediClinic.Services.Services.EmployeeService;
using MediClinic.Services.Interfaces.SoapNotesInterface;
using MediClinic.Services.Services.SoapNotesService;
using MediClinic.Services.Services.DMEService;
using MediClinic.Services.Interfaces.DMEInterface;
using MediClinic.Services.Interfaces.ImmunizationInterface;
using MediClinic.Services.Services.ImmunizationService;
using MediClinic.Services.Interfaces.UserRolePageInterface;
using MediClinic.Services.Services.UserRolePageService;
using MediClinic.Services.Interfaces.EUOInterface;
using MediClinic.Services.Services.EUOService;

using MediClinic.Services.Services.SurgeryCenterService;
using MediClinic.Services.Interfaces.SurgeryCenterInterface;
using MediClinic.Services.Interfaces.SubContractorInfoInterface;
using MediClinic.Services.Interfaces.ClaimInterface;
using MediClinic.Services.Services.ClaimService;
using MediClinic.Services.Interfaces.TestsInterface;
using MediClinic.Services.Services.TestsService;
using MediClinic.Services.Interfaces.CPTCodesInterface;
using MediClinic.Services.Services.CPTCodesService;
using MediClinic.Services.Interfaces.DoctorsInfoInterface;
using MediClinic.Services.Services.DoctorsInfoService;
using MediClinic.Services.Interfaces.ICDCodesInterface;
using MediClinic.Services.Services.ICDCodesService;
using MediClinic.Services.Interfaces.Assistant;
using MediClinic.Services.Services.AssistantInfoService;
using MediClinic.Services.Services.AllergyService;
using MediClinic.Services.Interfaces.AllergyInterface;
using MediClinic.Services.Interfaces.PharmacyInterface;
using MediClinic.Services.Services.PharmacyService;
using MediClinic.Controllers;
using MediClinic.Services.Services.MessagesService;
using MediClinic.Services.Interfaces.InvoicesInterface;
using MediClinic.Services.Services.InvoicesService;
using MediClinic.Services.Interfaces.DoucmentRepertInterface;
using MediClinic.Services.Services.DocumentReportService;
using MediClinic.Services.Services.SubscriptionPackageService;
using MediClinic.Services.Interfaces.SubscriptionPackageInterface;
using static MediClinic.Services.Services.SubscriptionPackageService.SubscriptionPackageService;
using MediClinic.Services.Interfaces.Template;
using MediClinic.Services.Services.Template;
using MediClinic.Services.Interfaces.ImagingInterface;
using MediClinic.Services.Services.ImagingService;
using MediClinic.Services.Services.GrowthChartService;
using MediClinic.Services.Interfaces.GrowthChartInterface;
using MediClinic.Services.Interfaces.LabInterface;
using MediClinic.Services.Services.LabServices;
using MediClinic.Services.Interfaces.RadiologyInterface;
using MediClinic.Services.Interfaces.TransportEmsInterface;
using MediClinic.Services.Services.TransportEmsService;
using MediClinic.Services.Interfaces.DepartmentsInterface;
using MediClinic.Services.Services.DepartmentsService;
using MediClinic.Services.Interfaces.ReportInterface;
using MediClinic.Services.Services.ReportService;
using MediClinic.Services.Services.FacilityLocation;
using MediClinic.Services.Interfaces.FacilityLocation;
using MediClinic.Services.Services.ClinicalReminderService;
using MediClinic.Services.Interfaces.ClinicalReminderInterface;
using MediClinic.Services.Interfaces.IMEInterface;
using MediClinic.Services.Services.IMEService;
using MediClinic.Services.Interfaces.SeetingAttorney;
using MediClinic.Services.Services.SettingAttorney;
using MediClinic.Services.Interfaces.CompanyBillsInterface;
using MediClinic.Services.Services.CompanyBillsServices;
using MediClinic.Services.Interfaces.LegalInfoInterface;
using MediClinic.Services.Services.LegalInfoService;
using MediClinic.Services.Interfaces.PatientsDmePrescription;
using MediClinic.Services.Services.PatientsDmePrescriptions;
using MediClinic.Services.Interfaces.InsuranceCompaniesInterface;
using MediClinic.Services.Services.InsuranceCompaniesServices;
using MediClinic.Services.Services.CptHspcCodesService;
using MediClinic.Services.Interfaces.CptHspcCodesInterface;
using MediClinic.Services.Interfaces.UserEventInterface;
using MediClinic.Services.Services.UserEventsService;
using Hangfire;

namespace MediClinic
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(x => x.UseSqlServerStorage(ConnectionString_Stagging.MediClinicApp));
            services.AddHangfireServer();

            services.AddControllersWithViews();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserInRolesService, UserInRolesService>();
            services.AddScoped<IPatientInfoService, PatientInfoService>();
            services.AddScoped<IPatientPhoneNumberService, PatientPhoneNumberService>();
            services.AddScoped<ISessionManager, SessionManager>();
            services.AddScoped<IPatientEmergencyContactService, PatientEmergencyContactService>();
            services.AddScoped<IPatientSecondaryInsuranceService, PatientSecondaryInsuranceService>();
            services.AddScoped<IPatientTertiaryInsuranceService, PatientTertiaryInsuranceService>();
            services.AddScoped<IPatientArbitrationAttorneyService, PatientArbitrationAttorneyService>();
            services.AddScoped<IPatientPersonalInjuryService, PatientPersonalInjuryService>();
            services.AddScoped<IPatientClaimInfoService, PatientClaimInfoService>();
            services.AddScoped<IPatientVehicleService, PatientVehicleService>();
            services.AddScoped<ILookupService, LookupService>();
            services.AddScoped<IProviderInfoService, ProviderInfoService>();
            services.AddScoped<ISubContractorInfoService, SubContractorInfoService>();
            services.AddScoped<IProviderTemplateService, ProviderTemplateService>();
            services.AddScoped<IRelatedFacilityService, RelatedFacilityService>();
            services.AddScoped<IPatientTreatmentStatusService, PatientTreatmentStatusService>();
            services.AddScoped<IPatientLegalStatusService, PatientLegalStatusService>();
            services.AddScoped<IClaimStatusService, ClaimStatusService>();
            services.AddScoped<IIncidentReportStatusService, IncidentReportStatusService>();
            services.AddScoped<INf2StatusService, Nf2StatusService>();
            services.AddScoped<IPatientIncidentRoleService, PatientIncidentRoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProviderSpecialityService, ProviderSpecialityService>();
            services.AddScoped<IProviderTermService, ProviderTermService>();
            services.AddScoped<IProviderUidTypeService, ProviderUidTypeService>();
            services.AddScoped<IPatientCaseTypeService, PatientCaseTypeService>();
            services.AddScoped<ILegalInfolegalService, LegalInfoLegalService>();
            services.AddScoped<ISubProviderService, SubProviderService>();
            services.AddScoped<IPatientRelationshipService, PatientRelationshipService>();
            services.AddScoped<IAddNewCaseTypeService, AddNewCaseTypeService>();
            services.AddScoped<IEmploymentStatusService, EmploymentStatusService>();
            services.AddScoped<IEmploymentTitleService, EmploymentTitleService>();
            services.AddScoped<IPatientSignatureIdTypeService, PatientSignatureIdTypeService>();
            services.AddScoped<IInsuranceProviderNameService, InsuranceProviderNameService>();
            services.AddScoped<IInsuranceGroupNumberService, InsuranceGroupNumberService>();
            services.AddScoped<ILegalInfoFirmNameService, LegalInfoFirmNameService>();
            services.AddScoped<ILegalInfoAttorneyNameService, LegalInfoAttorneyNameService>();
            services.AddScoped<ILegalInfoLeadingAttorneyService, LegalInfoLeadingAttorneyService>();
            services.AddScoped<ILegalInfoLeadingParalegal, LegalInfoLeadingParalegalService>();
            services.AddScoped<IPatientLanguageService, PatientLanguageService>();
            services.AddScoped<IPatientIdandSignatureService, PatientIdandSignatureService>();
            services.AddScoped<IPatientVehicleService, PatientVehicleService>();
            services.AddScoped<IPatientExamService, PatientExamService>();
            services.AddScoped<IPatientVitalService, PatientVitalService>();
            services.AddScoped<IMedicalDiseaseTypeService, MedicalDiseaseTypeService>();
            services.AddScoped<IPatientMedicalProblemService, PatientMedicalProblemService>();
            services.AddScoped<IPatientMissingService, PatientMissingService>();
            services.AddScoped<IPatientMedicalHistoryService, PatientMedicalHistoryService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorsInfoService, DoctorsInfoService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IPatientSettings, PatientSetting>();
            services.AddScoped<IPatientPrescriptionService, PatientPrescriptionService>();
            services.AddScoped<IPatientAppointmentService, PatientAppointmentService>();
            services.AddScoped<IClinicalNoteInterface, ClinicalNoteService>();
            services.AddScoped<IMediTemplateService, MediTemplateService>();
            services.AddScoped<IDMESuppliesService, DMESupplieService>();
            services.AddScoped<INotificationsService, NotificationsService>();
            services.AddScoped<IProviderSettingsService, ProviderSettingsService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ISoapNotesService, SoapNotesService>();
            services.AddScoped<IDMEService, DMEService>();
            services.AddScoped<IimmunizationService, ImmunizationService>();
            services.AddScoped<IUserRolePageService, UserRolePageService>();
            services.AddScoped<IEUOService, EUOService>();
            services.AddScoped<ISurgeryCenterService, SurgeryCenterService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ITestsService, TestsService>();
            services.AddScoped<ICPTCodesService, CPTCodesService>();
            services.AddScoped<IICDCodesService, ICDCodesService>();

            services.AddScoped<IAssistantService, AssistantInfoService>();
            services.AddScoped<IDMEService, DMEService>();
            services.AddScoped<IimmunizationService, ImmunizationService>();
            services.AddScoped<IUserRolePageService, UserRolePageService>();
            services.AddScoped<IEUOService, EUOService>();
            services.AddScoped<IRadiologyService, RadiologyService>();
            services.AddScoped<ITransportEmsService, TransportEmsService>();
            services.AddScoped<IDepartmentsService, DepartmentsService>();
            services.AddScoped<IClinicalReminderService, ClinicalReminderService>();

            services.AddScoped<ISurgeryCenterService, SurgeryCenterService>();
            services.AddScoped<IAllergyService, AllergyService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ITestsService, TestsService>();
            services.AddScoped<ICPTCodesService, CPTCodesService>();
            services.AddScoped<IPharmacyService, PharmacyService>();
            services.AddScoped<IGrowthChartService, GrowthChartService>();
            services.AddScoped<IImagingService, ImagingService>();
            services.AddScoped<IMessagesService, MessagesService>();
            services.AddScoped<IInvoicesService, InvoicesService>();
            services.AddScoped<IDocumentReportService, DocumentReportService>();
            services.AddScoped<ISubscriptionPackageService, SubscriptionPackageService>();
            services.AddScoped<ILabService, LabService>();
            services.AddScoped<IAdministrativeService, AdministrativeService>();
            services.AddScoped<IimeInterface, imeService>();
            services.AddScoped<ISettingAttorney, SettingAttorneyService>();
            services.AddScoped<ICompanyBillsServices, CompanyBillsService>();
            services.AddScoped<ILegalInfoService, LegalInfoService>();
            services.AddScoped<IPushNotificationService, PushNotificationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IPatientsDmePrescriptions, PatientsDmePrescriptionsService>();
            services.AddScoped<IInsuranceCompanies, InsuranceCompaniesService>();
            services.AddScoped<IUserEvents, UserEventsService>();
          
            services.AddScoped<ICptHspcCodes, CptHspcCodesService>();
            services.Configure<PayPalAuthOptions>(Configuration);
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IFacilityLocation, FacilityLocationService>();
            services.AddDbContext<MediClinicContext>((serviceProvider, options) =>
            {
                var connection = serviceProvider.GetService<ISessionManager>().GetMediClinicConnectionString();
                options.UseSqlServer(connection);
            }, ServiceLifetime.Transient);

            //services.AddDbContext<MediClinicContext>((serviceProvider, options) =>
            //{
            //    options.UseSqlServer(ConnectionString_Stagging.MediClinicApp);
            //}, ServiceLifetime.Transient);

            var mvcBuilder = services.AddControllersWithViews();
            mvcBuilder.AddRazorRuntimeCompilation();
            //services.AddTransient<MediClinicContext>();

            var mappingConfig = new MapperConfiguration(mc =>
            {   
                mc.AddProfile(new AutoMapping());
            });
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSession(options =>
            {
                options.Cookie.Name = ".MediClinic.Session";
                options.IdleTimeout = TimeSpan.FromDays(10);
                options.Cookie.IsEssential = true;
                options.Cookie.MaxAge = TimeSpan.FromDays(10);
            });
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env 
            //IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager
            //, IPushNotificationService pushNotification
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseHangfireDashboard();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=AuthUser}/{id?}");
                endpoints.MapHub<NotificationsHub>("/NotificationHub");
            });

            /////recurringJobManager.AddOrUpdate("Driver Attendance Alert", () => pushNotification.GetDriversForAttendanceNotification(), "*/5 * * * *");
        }
    }
}
