
using MediClinic.Models.DTOs.AddNewCaseTypeDto;
using MediClinic.Models.DTOs.ClaimStatus;
using MediClinic.Models.DTOs.EmploymentStatusDto;
using MediClinic.Models.DTOs.EmploymentTitleDto;
using MediClinic.Models.DTOs.IncidentReportStatusDto;
using MediClinic.Models.DTOs.InsuranceGroupNumberBasicDto;
using MediClinic.Models.DTOs.InsuranceProviderNameBasicDto;
using MediClinic.Models.DTOs.LegalInfoAttorneyNameDto;
using MediClinic.Models.DTOs.LegalInfoFirmNameDto;
using MediClinic.Models.DTOs.LegalInfoLeadingAttorneyDto;
using MediClinic.Models.DTOs.LegalInfoLeadingParalegalDto;
using MediClinic.Models.DTOs.LegalInfolegealStatusDto;
using MediClinic.Models.DTOs.LookupDto;
using MediClinic.Models.DTOs.Nf2StatusDto;
using MediClinic.Models.DTOs.PatientArbitrationAttorneyDto;
using MediClinic.Models.DTOs.PatientCaseTypeDto;
using MediClinic.Models.DTOs.PatientClaimInfo;
using MediClinic.Models.DTOs.PatientEmergencyContactDto;
using MediClinic.Models.DTOs.PatientIdandSignatureDto;
using MediClinic.Models.DTOs.PatientIncidentRoleDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.DTOs.PatientInfoListDto;
using MediClinic.Models.DTOs.PatientLegalStatusDto;
using MediClinic.Models.DTOs.PatientPIPersonalInjury;
using MediClinic.Models.DTOs.PatientPhoneNumberDto;
using MediClinic.Models.DTOs.PatientSecondaryInsuranceDto;
using MediClinic.Models.DTOs.PatientSignatureIdTypeBasicDto;
using MediClinic.Models.DTOs.PatientTertiaryInsuranceDto;
using MediClinic.Models.DTOs.PatientTreatmentStatusDto;
using MediClinic.Models.DTOs.PatientVehiclesDto;
using MediClinic.Models.DTOs.UsersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models.DTOs.PatientRelationshipDto;
using MediClinic.Models.DTOs.PatientLanguageDto;
using MediClinic.Models.DTOs.MedicalDiseaseTypeDto;
using MediClinic.Models.DTOs.PatientMedicalProblemDto;
using MediClinic.Models.DTOs.VitalBasicDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Models.DTOs.PatientExamDto;
using MediClinic.Models.DTOs.PatientMedicalHistoryDto;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediClinic.Models.EntityModels;
using MediClinic.Models.DTOs.PMHistory;
using MediClinic.Models.DTOs.EmailDto;
using MediClinic.Models.DTOs.SMSDto;
using MediClinic.Models.DTOs.ProviderSpecialityDto;
using MediClinic.Models.DTOs.PatientMissingDto;
using MediClinic.Models.DTOs.PatientSettingsDto;
using MediClinic.Models.DTOs.PrescriptionDto;
using MediClinic.Models.DTOs.PatientAppointmentsDto;
using MediClinic.Models.DTOs.TemplateDto;
using MediClinic.Models.DTOs.NotificationDto;
using MediClinic.Models.DTOs.DMESuppliesDto;
using MediClinic.Models.DTOs;

namespace MediClinic.Models
{
    public class PatientViewModel
    {
        public PatientViewModel()
        {
            patientInfoList = new List<PatientInfoBasicDto>();
            patientListWithUsers = new List<PatientInfoListDto>();
            patientLegalStatusBasicDtoslist = new List<PatientLegalStatusBasicDto>();
            patientTreatmentStatuslist = new List<PatientTreatmentStatusBasicDto>();
            patientVehiclesBasiclist = new List<PatientVehiclesBasicDto>();
            patientTreatmentStatuslist = new List<PatientTreatmentStatusBasicDto>();
            GetMHSurgicalHistory = new List<MHSurgicalHistory>();
            IncomeExpenceCategory = new IncomeExpenceCategoryDto();
            ReportIncome = new ReportIncomeDto();
            ReportExpence = new ReportExpenceDto();


        }
        public UsersBasicDto User { get; set; }

        public PatientInfoBasicDto patientInfoBasicDto { get; set; }
        public PatientInfoListDto patientCompleteInfo { get; set; }
        public IncomeExpenceCategoryDto IncomeExpenceCategory { get; set; }
        public ReportIncomeDto ReportIncome { get; set; }
        public List<ReportIncomeDto> ReportIncomeList { get; set; }
        public ReportExpenceDto ReportExpence { get; set; }
        public List<ReportExpenceDto> ReportExpenceList { get; set; }
        public List<PatientInfoBasicDto> patientInfoList { get; set; }
        public List<PatientInfoListDto> patientListWithUsers { get; set; }
        public DMESupplieDto dMEDto { get; set; }
        public List<DMESupplieDto> dMEDtoList { get; set; }
        public DMESupEquipItemsDto dMeSupply { get; set; }
        public PatientPhoneNumberBasicDto patientPhoneNumber { get; set; }
        public PatientEmergencyContactBasicDto patientEmergencyContact { get; set; }
        public PatientIdandSignatureBasicDto patientIdandSignature { get; set; }
        public PatientClaimInfoBasicDto patientClaimInfo { get; set; }
        public List<PatientClaimInfoBasicDto> patientClaimInfoList { get; set; }

        public PatientSecondaryInsuranceBasicDto patientSecondaryInsurance { get; set; }
        public PatientLegalStatusBasicDto patientLegalStatusBasicDto { get; set; }
        public List<PatientLegalStatusBasicDto> patientLegalStatusBasicDtoslist { get; set; }
        public PatientTreatmentStatusBasicDto patientTreatmentStatusBasicDto { get; set; }
        public List<PatientTreatmentStatusBasicDto> patientTreatmentStatuslist { get; set; }

        public PatientTertiaryInsuranceBasicDto PatientTertiaryInsuranceBasicDto { get; set; }

        public PatientPersonalInjuryBasicDto patientPersonalInjury { get; set; }
        public PatientArbitrationAttorneyBasicDto patientArbitrationAttorney { get; set; }
        public PatientVehiclesBasicDto patientVehiclesBasic { get; set; }
        public List<PatientVehiclesBasicDto> patientVehiclesBasiclist { get; set; }
        public ClaimStatusBasicDto claimStatusBasicDto { get; set; }
        public List<ClaimStatusBasicDto> ClaimStatusList { get; set; }
        public IncidentReportStatusBasicDto IncidentReportStatusBasicDto { get; set; }
        public List<IncidentReportStatusBasicDto> IncidentReportStatusList { get; set; }
        public Nf2StatusBasicDto nf2Status { get; set; }

        public List<Nf2StatusBasicDto> Nf2list { get; set; }
        public PatientIncidentRoleBasicDto patientIncidentRole { get; set; }
        public List<PatientIncidentRoleBasicDto> IncidentList { get; set; }
        public List<LookupBasicDto> prefixs { get; set; }
        public List<LookupBasicDto> suffix { get; set; }
        public List<LookupBasicDto> gender { get; set; }

        public List<LookupBasicDto> maritalStatus { get; set; }

        public List<LookupBasicDto> RaceEthnicity { get; set; }

        public List<LookupBasicDto> RelationShip { get; set; }
        public string Success { get; set; }

        public PatientCaseTypeBasicDto patientCaseTypeBasicDto { get; set; }

        public legalInfoLegalBasicDto LegalInfoLegalStatus { get; set; }

        public List<legalInfoLegalBasicDto> legalInfoLegalStatusList { get; set; }
        public AddNewCaseTypeBasicDto addNewCaseTypeBasicDto { get; set; }
        public List<AddNewCaseTypeBasicDto> addNewCaseTypeList { get; set; }

        public EmploymentStatusBasicDto EmploymentStatusBasicDto { get; set; }

        public List<EmploymentStatusBasicDto> EmploymentStatuslist { get; set; }

        public EmploymentTitleBasicDto EmploymentTitleBasicDto { get; set; }

        public List<EmploymentTitleBasicDto> EmploymentTitleList { get; set; }

        public PatientSignatureIdTypeDto PatientSignatureIdTypeBasicDto { get; set; }
        public List<PatientSignatureIdTypeDto> PatientSignatureIdTypeList { get; set; }

        public InsuranceProviderNameBasicDto InsuranceProviderNameBasicDto { get; set; }
        public List<InsuranceProviderNameBasicDto> InsuranceProviderNamesList { get; set; }

        public InsuranceGroupNumberBasicDto InsuranceGroupNumberBasicDto { get; set; }

        public List<InsuranceGroupNumberBasicDto> InsuranceGroupNumbersList { get; set; }

        public LegalInfoFirmNameBasicDto LegalInfoFirmNameBasicDto { get; set; }

        public List<LegalInfoFirmNameBasicDto> legalInfoFirmNameList { get; set; }

        public LegalInfoAttorneyNameBasicDto LegalInfoAttorneyNameBasicDto { get; set; }
        public List<LegalInfoAttorneyNameBasicDto> legalInfoAttorneyNameList { get; set; }
        public LegalInfoLeadingAttorneyBasicDto legalInfoLeadingAttorneyBasicDto { get; set; }

        public List<LegalInfoLeadingAttorneyBasicDto> legalInfoLeadingAttorneysList { get; set; }

        public LegalInfoLeadingParalegalBasicDto LegalInfoLeadingParalegalBasicDto { get; set; }

        public List<LegalInfoLeadingParalegalBasicDto> LegalInfoLeadingParalegallist { get; set; }

        public PatientRelationshipBasicDto PatientRelationship { get; set; }

        public List<PatientRelationshipBasicDto> PatientRelationshipList { get; set; }

        public PatientLanguageBasicDto patientLanguage { get; set; }

        public List<PatientLanguageBasicDto> patientLanguageList { get; set; }
        public VitalDto VitalDto { get; set; }
        public List<VitalDto> Vitallist { get; set; }
      
        public List<ProviderInfoBasicDto> ProviderList { get; set; }
        public List<ProviderSessionTypeDto> ProviderSessionTypeList { get; set; }

        public PatientExamTypeDto PatientExamTypeDto { get; set; }
        public PatientExamReasonDto PatientExamReasonDto { get; set; }

        public List<PatientExamTypeDto> patientExamTypeList { get; set; }
        public List<PatientExamReasonDto> PatientExamReasonList { get; set; }

        public MedicalDiseaseTypeBasicDto medicalDiseaseTypeBasicDto { get; set; }

        public List<MedicalDiseaseTypeBasicDto> medicalDiseaseTypeList { get; set; }

        public PatientMedicalProblemBasicDto patientMedicalProblemBasicDto { get; set; }

        public List<PatientMedicalProblemBasicDto> patientMedicalProblemsList { get; set; }

        public PatientMedicalHistoryBasicDto patientMedicalHistoryBasicDto { get; set; }
        public MHAllergiesHistoryDTO MHAllergiesHistory { get; set; }
        public MHSocialHistoryDTO MHSocialHistory { get; set; }
        public MHDetailPregnanciesHistoryDTO MHDetailPregnanciesHistory { get; set; }
        public MHExerciseHistoryDTO MHExerciseHistory { get; set; }
        public MHFamilyHistoryDTO MHFamilyHistory { get; set; }
        public MHHobbiesHistoryDTO MHHobbiesHistory { get; set; }
        public MHMyPhysicianDTO MHMyPhysician { get; set; }
        public MHPastDiseaseHistoryDTO MHPastDiseaseHistory { get; set; }
        public MHPharmacyInfoDTO MHPharmacyInfo { get; set; }
        public MHPastMedicationHistoryDTO MHPastMedicationHistory { get; set; }
        public MHPregnanciesHistoryDTO MHPregnanciesHistory { get; set; }
        public MHSurgicalHistoryDTO MHSurgicalHistory { get; set; }
        public MHRecreationalDrugsHistoryDTO MHRecreationalDrugsHistory { get; set; }
        public MHHospitalizationsInfoDTO MHHospitalizationsInfo { get; set; }
        public List<PatientMedicalHistoryBasicDto> patientMedicalHistoryList { get; set; }
        public MHSocialHistory GetMHSocialHistory { set; get; }

        public IEnumerable<SelectListItem> MedicineList { set; get; }
        public IEnumerable<SelectListItem> IncomeCategoryList { set; get; }
        public Medicines MedicineName { set; get; }
        public IEnumerable<SelectListItem> DiseaseList { set; get; }
        public List<MHRecreationalDrugsHistory> MHRecreationalDrugsHistoryList { get; set; }
        public List<MHMyPhysicians> GetMHMyPhysician { set; get; }
        public List<MHSurgicalHistory> GetMHSurgicalHistory { set; get; }
        public List<vw_GetMHHospitalizationsInfo> GetMHHospitalizationsInfo { set; get; }
        public List<MHPharmacyInfo> GetMHPharmacyInfo { set; get; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
        public IEnumerable<SelectListItem> SpecialityList { get; set; }

        public IEnumerable<SelectListItem> StateList { get; set; }
        public IEnumerable<SelectListItem> CityList { get; set; }
        public IEnumerable<SelectListItem> GetDoctorSpecialityList { get; set; }
        public List<MHPastDiseaseHistory> GetMHPastDiseaseHistory { set; get; }
        public List<MHExerciseHistory> GetMHExerciseHistory { set; get; }

        public List<MHFamilyHistory> GetMHFamilyHistory { set; get; }
        public List<MHAllergiesHistory> GetMHAllergiesHistory { set; get; }
        public MHPregnanciesHistory GetMHPregnancyHistory { set; get; }

        public List<MHDetailPregnanciesHistory> GetMHDetailPregnancyHistory { set; get; }
        public List<MHHobbiesHistory> GetMHHobbiesHistory { set; get; }

        //public List<PatientMedicalHistoryBasicDto> patientMedicalHistoryList { get; set; }

        public EmailBasicDto EmailBasicDto { get; set; }
        public SmsDto SmsDto { get; set; }
        public MHPregnanciesHistory PregnanciesHistory { get; set; }

        public MHSocialHistory MHSocialHistoryModel { get; set; }
        public List<MHPastMedicationHistory> GetMHPastMedicationHistory { set; get; }

        public List<ProviderSpecialityBasicDto> PhysicianSpecialityList { get; set; }
        public List<PatientMissingsDto> PatientMissingsListDto { get; set; }
        public PatientSettingDto PatientSettingDto { get; set; }
        public PatientPrintSettingDto PatientPrintSettingDto { get; set; }
        public PatientListSettingDto PatientListSettingDto { get; set; }
        public PatientRequireFieldSettingDto PatientInfoFormRequireSettingsDto { get; set; }

        public PrescriptionBasicDto prescriptionBasicDto { get; set; }

        public List<PrescriptionBasicDto> prescriptionBasicsList { get; set; }

        public PatientAppointmentBasicDto patientAppointmentBasicDto { get; set; }
        public List<PatientAppointmentBasicDto> patientAppointmentBasicsList { get; set; }

        public RecurringAppoinmentDto RecurringAppoinmentDto { get; set; }
        public List<RecurringAppoinmentDto> RecurringList { get; set; }
        public TemplateBasicDto TemplateBasic { get; set; }
        public List<TemplateBasicDto> TemplateBasicList { get; set; }

        public PrescriptionTemplateDto PrescriptionTemplateDto { get; set; }

        public List<PrescriptionTemplateDto> PrescriptionTemplateList { get; set; }

        public NotificationDto NotificationDto { get; set; }

        public string StartDate { get; set; }
        public string SelectedData { get; set; }
        public string EndDate { get; set; }
        public long PatientInfoIdForDisplay { get; set; }

        public List<AllergyDto> AlergyList { get; set; }
        public List<AllergyTypeDto> AlergyTypeList { get; set; }
        public List<VisitsDto> GetVisitsListDto { get; set; }
        public ClaimEmailDto ClaimEmailDto { get; set; }
        public NF2AobDto nF2AobDto { get; set; }
        public ReportPatientDto reportPatientDto { get; set; }

    }
}
