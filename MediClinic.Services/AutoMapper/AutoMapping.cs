using AutoMapper;
using MediClinic.Models.DTOs.UserInRolesDto;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Models.EntityModels;
using MediClinic.Models.DTOs.PatientInfoDto;

using System;
using System.Collections.Generic;
using System.Text;
using MediClinic.Models.DTOs.PatientPhoneNumberDto;
using MediClinic.Models.DTOs.PatientEmergencyContactDto;
using MediClinic.Models.DTOs.LookupDto;
using MediClinic.Models.DTOs.PatientSecondaryInsuranceDto;
using MediClinic.Models.DTOs.PatientTertiaryInsuranceDto;
using MediClinic.Models.DTOs.PatientArbitrationAttorneyDto;
using MediClinic.Models.DTOs.PatientPIPersonalInjury;
using MediClinic.Models.DTOs.PatientClaimInfo;
using MediClinic.Models.DTOs.PatientVehiclesDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Models.DTOs.ProviderTemplateDto;
using MediClinic.Models.DTOs.RelatedFacilityDto;
using MediClinic.Models.DTOs.PatientIdandSignatureDto;
using MediClinic.Models.DTOs.PatientTreatmentStatusDto;
using MediClinic.Models.DTOs.PatientLegalStatusDto;
using MediClinic.Models.DTOs.ClaimStatus;
using MediClinic.Models.DTOs.IncidentReportStatusDto;
using MediClinic.Models.DTOs.Nf2StatusDto;
using MediClinic.Models.DTOs.PatientIncidentRoleDto;
using MediClinic.Models.DTOs.ProviderSpecialityDto;
using MediClinic.Models.DTOs.ProviderTermDto;
using MediClinic.Models.DTOs.ProviderUidTypeDto;
using MediClinic.Models.DTOs.PatientCaseTypeDto;
using MediClinic.Models.DTOs.SubProviderDto;
using MediClinic.Models.DTOs.LegalInfolegealStatusDto;
using MediClinic.Models.DTOs.AddNewCaseTypeDto;
using MediClinic.Models.DTOs.PatientRelationshipDto;
using MediClinic.Models.DTOs.EmploymentStatusDto;
using MediClinic.Models.DTOs.EmploymentTitleDto;
using MediClinic.Models.DTOs.PatientSignatureIdTypeBasicDto;
using MediClinic.Models.DTOs.InsuranceGroupNumberBasicDto;
using MediClinic.Models.DTOs.LegalInfoFirmNameDto;
using MediClinic.Models.DTOs.LegalInfoAttorneyNameDto;
using MediClinic.Models.DTOs.InsuranceProviderNameBasicDto;
using MediClinic.Models.DTOs.LegalInfoLeadingAttorneyDto;
using MediClinic.Models.DTOs.LegalInfoLeadingParalegalDto;
using MediClinic.Models.DTOs.PatientLanguageDto;
using MediClinic.Models.DTOs.MedicalDiseaseTypeDto;
using MediClinic.Models.DTOs.PatientMedicalProblemDto;
using MediClinic.Models.DTOs.PatientExamDto;
using MediClinic.Models.DTOs.VitalBasicDto;
using MediClinic.Models.DTOs.PatientMedicalHistoryDto;
using MediClinic.Models.DTOs.PMHistory;
using MediClinic.Models.DTOs.PatientSettingsDto;
using MediClinic.Models.DTOs.PrescriptionDto;
using MediClinic.Models.DTOs.PatientAppointmentsDto;
using MediClinic.Models.DTOs.ClinicalNotesDto;
using MediClinic.Models.DTOs.TemplateDto;
using MediClinic.Models.DTOs.DMESuppliesDto;

using MediClinic.Models.DTOs;
using MediClinic.Models.ApiDtos;

namespace MediClinic.Services.AutoMapper
{
    public class AutoMapping :Profile
    {
        public AutoMapping()
        {
            CreateMap<Users, UsersBasicDto>().ReverseMap();
            CreateMap<UserInRoles, UserInRolesBasicDto>().ReverseMap();
            CreateMap<PatientInfo, PatientInfoBasicDto>().ReverseMap();
            CreateMap<PatientPhoneNumber, PatientPhoneNumberBasicDto>().ReverseMap();
            CreateMap<PatientEmergencyContact, PatientEmergencyContactBasicDto>().ReverseMap();
            CreateMap<Lookups, LookupBasicDto>().ReverseMap();
            CreateMap<ProviderInfo, ProviderInfoBasicDto>().ReverseMap();
            CreateMap<ProviderTemplates, ProviderTemplateBasicDto>().ReverseMap();
            CreateMap<SecondaryInsurenceProvider, PatientSecondaryInsuranceBasicDto>().ReverseMap();
            CreateMap<TertiaryInsurenceProvider, PatientTertiaryInsuranceBasicDto>().ReverseMap();
            CreateMap<PatientArbitrationAttorney, PatientArbitrationAttorneyBasicDto>().ReverseMap();
            CreateMap<RelatedFacilities, RelatedFacilityBasicDto>().ReverseMap();
            CreateMap<PatientPersonalInjury, PatientPersonalInjuryBasicDto>().ReverseMap();
            CreateMap<PatientsClaimInfo, PatientClaimInfoBasicDto>().ReverseMap();
            CreateMap<VehicalsOrEntityInvolved, PatientVehiclesBasicDto>().ReverseMap();
            CreateMap<PatientIdAndSignature, PatientIdandSignatureBasicDto>().ReverseMap();
            CreateMap<PatientTreatmentStatus, PatientTreatmentStatusBasicDto>().ReverseMap();
            CreateMap<PatientLegalStatus, PatientLegalStatusBasicDto>().ReverseMap();
            CreateMap<ClaimStatus, ClaimStatusBasicDto>().ReverseMap();
            CreateMap<IncidentReportStatus, IncidentReportStatusBasicDto>().ReverseMap();
            CreateMap<Nf2Status, Nf2StatusBasicDto>().ReverseMap();
            CreateMap<PatientRoleIncident, PatientIncidentRoleBasicDto>().ReverseMap();
            CreateMap<ProviderSpecialities, ProviderSpecialityBasicDto>().ReverseMap();
            CreateMap<ProviderTerms, ProviderTermBasicDto>().ReverseMap();
            CreateMap<ProviderUIDTypes, ProviderUidTypeBasicDto>().ReverseMap();
            CreateMap<PatientCaseType, PatientCaseTypeBasicDto>().ReverseMap();
            CreateMap<LegalInfoLegalStatus, legalInfoLegalBasicDto>().ReverseMap();
            CreateMap<Users, UsersBasicDto>().ReverseMap();
            CreateMap<SubProviders, SubProviderBasicDto>().ReverseMap();
            CreateMap<PatientNewCaseType,AddNewCaseTypeBasicDto>().ReverseMap();
            CreateMap<PatientRelationship, PatientRelationshipBasicDto>().ReverseMap();
            CreateMap<EmploymentStatus, EmploymentStatusBasicDto>().ReverseMap();
            CreateMap<EmploymentTitle, EmploymentTitleBasicDto>().ReverseMap();
            CreateMap<PatientSignatureIdType, PatientSignatureIdTypeDto>().ReverseMap();
            CreateMap<InsuranceProviderName, InsuranceProviderNameBasicDto>().ReverseMap();
            CreateMap<InsuranceGroupNumber, InsuranceGroupNumberBasicDto>().ReverseMap();
            CreateMap<LegalInfoFirmName, LegalInfoFirmNameBasicDto>().ReverseMap();
            CreateMap<LegalInfoAttorneyName, LegalInfoAttorneyNameBasicDto>().ReverseMap();
            CreateMap<LegalInfoLeadingAttorney, LegalInfoLeadingAttorneyBasicDto>().ReverseMap();
            CreateMap<LegalInfoLeadingParalegal, LegalInfoLeadingParalegalBasicDto>().ReverseMap();
            CreateMap<PatientLanguage, PatientLanguageBasicDto>().ReverseMap();
            CreateMap<PatientVitals, VitalDto>().ReverseMap();
            CreateMap<ExamType, PatientExamTypeDto>().ReverseMap();
            CreateMap<ExamReason, PatientExamReasonDto>().ReverseMap();
            CreateMap<MedicalDiseaseType, MedicalDiseaseTypeBasicDto>().ReverseMap();
            CreateMap<PatientMedicalProblem, PatientMedicalProblemBasicDto>().ReverseMap();
            CreateMap<PatientMedicalHistory, PatientMedicalHistoryBasicDto>().ReverseMap();
            CreateMap<MHPastDiseaseHistory, MHPastDiseaseHistoryDTO>().ReverseMap();
            CreateMap<MHFamilyHistory, MHFamilyHistoryDTO>().ReverseMap();
            CreateMap<MHExerciseHistory, MHExerciseHistoryDTO>().ReverseMap();
            CreateMap<MHAllergiesHistory, MHAllergiesHistoryDTO>().ReverseMap();
            CreateMap<MHPregnanciesHistory, MHPregnanciesHistoryDTO>().ReverseMap();
            CreateMap<MHDetailPregnanciesHistory, MHDetailPregnanciesHistoryDTO>().ReverseMap();
            CreateMap<MHHobbiesHistory, MHHobbiesHistoryDTO>().ReverseMap();
            CreateMap<MHPharmacyInfo, MHPharmacyInfoDTO>().ReverseMap();
            CreateMap<MHMyPhysicians, MHMyPhysicianDTO>().ReverseMap();
            CreateMap<MHSocialHistory, MHSocialHistoryDTO>().ReverseMap();
            CreateMap<PatientDisplaySetting, PatientSettingDto>().ReverseMap();
            CreateMap<PatientPrintSetting, PatientPrintSettingDto>().ReverseMap();
            CreateMap<PatientListDisplaySetting, PatientListSettingDto>().ReverseMap();
            CreateMap<PatientRequireFieldsSetting, PatientRequireFieldSettingDto>().ReverseMap();
            CreateMap<PatientPrescriptions, PrescriptionBasicDto>().ReverseMap();
            CreateMap<PatientAppointments, PatientAppointmentBasicDto>().ReverseMap();
            CreateMap<PatientClinicalNotes, ClinicalNoteDto>().ReverseMap();
            CreateMap<PatientMedicationsTemplate, PrescriptionTemplateDto>().ReverseMap();
            CreateMap<PrescriptionTemplates, TemplateBasicDto>().ReverseMap();
            CreateMap<ICDCodes, Models.DTOs.ICDDto>().ReverseMap();
            CreateMap<CPTCodes, Models.DTOs.DMESuppliesDto.CPTCodeDto>().ReverseMap();
            CreateMap<DMESupplyEquipment, DMESupplieDto>().ReverseMap();
            CreateMap<DMESupEquipItems, DMESupEquipItemsDto>().ReverseMap();
            CreateMap<ProviderListSettingss, ProviderListSettingDto>().ReverseMap();
            CreateMap<ProviderSessions, ProviderWorkHrsDto>().ReverseMap();
            CreateMap<ProviderSessionTypes, ProviderSessionTypeDto>().ReverseMap();
            CreateMap<Employee, EmployeeBasicDto>().ReverseMap();
            CreateMap<SoapNotesSurvey, SoapNotesBasicDto>().ReverseMap();
            CreateMap<DMESupplyEquipment, DMESupplieDto>().ReverseMap();
            CreateMap<Tests, TestsDto>().ReverseMap();
            CreateMap<DoctorsInfo, DoctorsInfoDto>().ReverseMap();
            CreateMap<ICDCodes, ICDCodesDto>().ReverseMap();
            CreateMap<CPTCodes, CPTCodesDto>().ReverseMap();
            CreateMap<Immunization, ImmunizationBasicDto>().ReverseMap();
            CreateMap<MainMenuPages, UserRolePagesBasicDto>().ReverseMap();
            CreateMap<EUO, EUODto>().ReverseMap();
            CreateMap<DME, DMEDto>().ReverseMap();
            CreateMap<SurgeryCenter, SurgeryCenterDto>().ReverseMap();
            CreateMap<SubContractorInfo, SubContractorInfoDto>().ReverseMap();
            CreateMap<Claims, ClaimBasicDto>().ReverseMap();
            CreateMap<AssistanInfo, AssistantInfoDto>().ReverseMap();
            CreateMap<AssistanInfo, AssistantSettingDto>().ReverseMap();
            CreateMap<DoctorsInfo, DoctorsInfoDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<AssistantWorkingSchedule, AssistantWorkingScheduleDto>().ReverseMap();
            CreateMap<DMESupplyEquipment, DMESupplieDto>().ReverseMap();
            CreateMap<DoctorsInfo, DoctorInfoDto>().ReverseMap();
            CreateMap<ICDCodes, ICDCodesDto>().ReverseMap();
            CreateMap<CPTCodes, Models.DTOs.CPTCodeDto>().ReverseMap();
            CreateMap<Immunization, ImmunizationBasicDto>().ReverseMap();
            CreateMap<MainMenuPages, UserRolePagesBasicDto>().ReverseMap();
            CreateMap<EUO, EUODto>().ReverseMap();
            CreateMap<SurgeryCenter, SurgeryCenterDto>().ReverseMap();
            CreateMap<SubContractorInfo, SubContractorInfoDto>().ReverseMap();
            CreateMap<Allergies, AllergyDto>().ReverseMap();
            CreateMap<AllergyTypes, AllergyTypeDto>().ReverseMap();
            CreateMap<Claims, ClaimBasicDto>().ReverseMap();
            CreateMap<Pharmacy, PharmacyDto>().ReverseMap();
            CreateMap<Messages, MessagesDto>().ReverseMap();
            CreateMap<Invoices, InvoicesDto>().ReverseMap();
            CreateMap<InvoiceCharges, InvoiceChargesDto>().ReverseMap();
            CreateMap<Visits, VisitsDto>().ReverseMap();
            CreateMap<Imaging, ImagingDto>().ReverseMap();
            CreateMap<GrowthChart, GrowthChartDto>().ReverseMap();
            CreateMap<Lab, LabDto>().ReverseMap();
            CreateMap<Radiology, RadiologyDto>().ReverseMap();
            CreateMap<ClaimEmail, ClaimEmailDto>().ReverseMap();
            CreateMap<ClinicalReminder, ClinicalReminderDto>().ReverseMap();
            CreateMap<CompanyBills, CompanyBillsDto>().ReverseMap();
            CreateMap<LegalInfo, LegalInfoDto>().ReverseMap();

            CreateMap<TransportEms, TransportEmsDTO>().ReverseMap();
            CreateMap<Immunization, ImmunizationBasicDto>().ReverseMap();
            CreateMap<MainMenuPages, UserRolePagesBasicDto>().ReverseMap();
            CreateMap<DocumentReports, DocumentReportBasicDto>().ReverseMap();
            CreateMap<SubscriptionPackages, SubsriptionPackageDto>().ReverseMap();
            CreateMap<Template, TemplateDTO>().ReverseMap();
            CreateMap<TemplateComponent, TemplateComponentDTO>().ReverseMap();
            CreateMap<DoctorTemplate, DoctorTemplateDTO>().ReverseMap();
            CreateMap<DoctorPatientTemplate, DoctorPatientTemplateDTO>().ReverseMap();
            CreateMap<TemplateComponentDetail, TemplateComponentDetailDTO>().ReverseMap();
            CreateMap<Procedures, ProceduresDto>().ReverseMap();
            CreateMap<Departments, DepartmentsDto>().ReverseMap();
            CreateMap<ReportEmployeeInfo, ReportEmployeeDto>().ReverseMap();
            CreateMap<ReportPatientInformation, ReportPatientDto>().ReverseMap();
            CreateMap<ReportDoctorInformation, ReportDoctorInfoDto>().ReverseMap();
            CreateMap<ReportHistory, ReportHistoryDto>().ReverseMap();
            CreateMap<ReportExamInformation, ReportExamInfromationDto>().ReverseMap();
            CreateMap<ReportDoctorOpinion, ReportDoctorOpinionDto>().ReverseMap();
            CreateMap<ReportPlanCare, ReportPlanCareDto>().ReverseMap();
            CreateMap<ReportWorkStatus, ReportWorkStatusDto>().ReverseMap();

            CreateMap<ReportBillingInformation, ReportBillingInfoDto>().ReverseMap();
            CreateMap<ReportBillingCode, ReportBillingCodeDto>().ReverseMap();
            CreateMap<ReportBillingInvoice, ReportBillingInvoiceDto>().ReverseMap();
            CreateMap<NF2AOBClaim, NF2AobDto>().ReverseMap();
            CreateMap<IncomeExpenceCategory, IncomeExpenceCategoryDto>().ReverseMap();
            CreateMap<ReportIncome, ReportIncomeDto>().ReverseMap();
            CreateMap<ReportExpence, ReportExpenceDto>().ReverseMap();
            CreateMap<CheckInOut, CheckInOutDto>().ReverseMap();
            CreateMap<CurrentLocationFacility, CurrentLocationFacilityDto>().ReverseMap();

            CreateMap<Administrative, AdministrativeDto>().ReverseMap();

            CreateMap<IME, ImeDto>().ReverseMap();
            CreateMap<CalendarSetting, CalendarSettingDto>().ReverseMap();
            CreateMap<SettingAttorney, SettingAttorneyDto>().ReverseMap();
            CreateMap<AmbulanceAssignDriver, AmbulanceAssignDriverDto>().ReverseMap();
            CreateMap<DriverJobRequest, DriverJobRequestDto>().ReverseMap();
            CreateMap<DriverProfile, DriverProfileDto>().ReverseMap();
            CreateMap<JobNotificationThread, JobNotificationThreadDto>().ReverseMap();

            #region For Api
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<DriverProfile, DriverProfileApiDto>().ReverseMap();
            CreateMap<DriverProfile, DriverProfileUpdateDto>().ReverseMap();
            CreateMap<TransportEms, DriverVehicleDetailDto>().ReverseMap();
            CreateMap<DriverAvailability, DriverAvailabilityDto>().ReverseMap();
            CreateMap<DriverCurrentLocation, DriverCurrentLocationDto>().ReverseMap();

            #endregion  
           



            CreateMap<VehicleMake, VehicleMakeDto>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeDto>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelDto>().ReverseMap();
            CreateMap<TransportEms, TransportDetailsDto>().ReverseMap();
          



            CreateMap<UserDevices, DriverAuthDto>().ReverseMap();
          


            CreateMap<DmeSuppliesManufactures, DmeSuppliesManufacturesDto>().ReverseMap();
            CreateMap<DmeMakeNameModel, DmeMakeNameModelDto>().ReverseMap();
            CreateMap<DmeInventory, DmeInventoryDto>().ReverseMap();
            CreateMap<DMEGroup, DMEGroupDto>().ReverseMap();
            CreateMap<DMEGroupItem, DMEGroupItemDto>().ReverseMap();
            CreateMap<DriverJobRequestStatus, DriverJobRequestStatusDto>().ReverseMap();
            CreateMap<DmePatientsPrescription, DmePatientsPrescriptionDto>().ReverseMap();
            CreateMap<DmeRentalForm, DmeRentalFormDto>().ReverseMap();

            CreateMap<TransportBaseEmsDto, TransportEmsDTO>().ReverseMap();



            CreateMap<ProviderSummarySettingsDto, ProviderSummarySettings>().ReverseMap();
            CreateMap<UserEventsDto, UserEvents>().ReverseMap();
            



            CreateMap<InsuranceCompanies, InsuranceCompaniesDto>().ReverseMap();
            CreateMap<CptHspcCode, CptHspcCodesDto>().ReverseMap();

            CreateMap<DriverAttendance, AttendanceDto>().ReverseMap();
            
        }
    }
}
