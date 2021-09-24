using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientArbitrationAttorneyDto;
using MediClinic.Models.DTOs.PatientCaseTypeDto;
using MediClinic.Models.DTOs.PatientClaimInfo;
using MediClinic.Models.DTOs.PatientEmergencyContactDto;
using MediClinic.Models.DTOs.PatientIdandSignatureDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.DTOs.PatientInfoListDto;
using MediClinic.Models.DTOs.PatientPIPersonalInjury;
using MediClinic.Models.DTOs.PatientPhoneNumberDto;
using MediClinic.Models.DTOs.PatientSecondaryInsuranceDto;
using MediClinic.Models.DTOs.PatientTertiaryInsuranceDto;
using MediClinic.Models.DTOs.PatientVehiclesDto;
using MediClinic.Models.DTOs.PatientVMDto;
using MediClinic.Models.EntityModels;
using MediClinic.Models.DTOs.PatientRelationshipDto;
using MediClinic.Models.DTOs.PatientLanguageDto;
using MediClinic.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediClinic.Services.Interfaces.PatientInfoInterface
{
    public interface IPatientInfoService
    {
        public Task<ResponseDto<List<PatientInfoBasicDto>>> patientInfo();
        public Task<ResponseDto<PatientInfoBasicDto>> patientInfoCreate(PatientInfoBasicDto patientInfoBasicDto,string[] languages);

        public Task<ResponseDto<bool>> patientInfoUpdate(PatientInfoBasicDto patientInfoBasicDto, string[] languages);

        public Task<ResponseDto<PatientInfoBasicDto>> patientInfoGetId(int Id);
        public Task<PatientInfoBasicDto> GetPatientDetailInfo(long patientInfoId);
        public Task<ResponseDto<bool>> patientInfoDeleteById(int Id);
        public Task<ResponseDto<bool>> patientActiveById(long Id);
        public Task<ResponseDto<PatientInfoBasicDto>> patientInfoGetLastAdded();
        public Task<PatientVMDto> GetPatientDropDownData();

        public Task<List<PatientInfoListDto>> GetRelevantPatientDetails(string phoneNumber, string address, string emergencyphoneNumber, string emergencyPerson, string adjustorName);
        public PatientPhoneNumberBasicDto mappedPhoneNumber(PatientPhoneNumber phoneNumber);
        public Task<QuickRegisterPatientDto> QuickRegisterPatient(QuickRegisterPatientDto quickRegister);


        public PatientEmergencyContactBasicDto mappedEmergencyNumber(PatientEmergencyContact contactBasicDto);
        public PatientIdandSignatureBasicDto mappedPatientIdSignature(PatientIdAndSignature idAndSignature);
        public PatientCaseTypeBasicDto mappedCaseType(PatientCaseType caseType);
        public PatientClaimInfoBasicDto mappedClaimInfo(PatientsClaimInfo claimInfo);
        public PatientVehiclesBasicDto mappedVehicles(VehicalsOrEntityInvolved vehicalsOrEntity);
        public PatientSecondaryInsuranceBasicDto mappedSecondaryInsurance(SecondaryInsurenceProvider insurenceProvider);
        public PatientTertiaryInsuranceBasicDto mappedTertiaryInsurance(TertiaryInsurenceProvider insurenceProvider);
        public PatientPersonalInjuryBasicDto mappedPersonalInjury(PatientPersonalInjury patientPersonal);
        public PatientArbitrationAttorneyBasicDto mappedArbitrationAttorney(PatientArbitrationAttorney insurenceProvider);

        public PatientRelationshipBasicDto mappedPatientRelationShip(PatientRelationship patientRelationship);
        public Task<PatientInfoListDto> GetPatientSummaryDetails(long patientInfoId);
        public Task<PatientInfoListDto> PatientDetails(long patientInfoId);
        public Task<List<PatientInfoListDto>> GetPatientListWithDetails();
        public Task<List<PatientInfoBasicDto>> GetInActivePatientList();
        public Task<List<PatientLanguageBasicDto>> GetPatientLanguages(long UserId);
        
        
        public PatientInfoBasicDto GetPatientName(long PatientInfoId);

        public Task<PatientInfoBasicDto> GetPatientInfoData(long userId);
        public Task<PatientPhoneNumberBasicDto> GetPatientPhoneNumberData(long userId);
        public Task<PatientEmergencyContactBasicDto> GetPatientEmergencyData(long userId);
        public Task<PatientClaimInfoBasicDto> GetPatientClaimInfoData(long userId);
        public Task<List<PatientVehiclesBasicDto>> GetPatientVehicleData(long userId);
        public Task<PatientSecondaryInsuranceBasicDto> GetPatientSecondaryData(long userId);
        public Task<PatientTertiaryInsuranceBasicDto> GetPatientTertiaryData(long userId);
        public Task<PatientPersonalInjuryBasicDto> GetPatientPIData(long userId);
        public Task<PatientArbitrationAttorneyBasicDto> GetPatientCollectionData(long userId);
        public Task<PatientIdandSignatureBasicDto> GetPatientSignatureFormData(long userId);
        public Task<long> GetUserIdFromPatientId(long patientinfoId);
        public PatientInfo GetPatientInfoById(long Id);
        public long GetMaxPatientId();
        public  Task<List<VisitsDto>> GetVisitsList(int PatientId);
        public  Task<List<VisitsDto>> GetVisitsListByPatient(int PatientId);
        public Task<bool> AddEmail(ClaimEmailDto claimEmailDto);
        public bool EmployeeVerificationEmail(string email, string Subject, string message);
        public int? GetLatestVisitIDAgainstPatient(long Id);


        public Task<string> GetPatientLatestVisitDate(long PatientId);
        public Task<string> GetPatientLatestExamDate(long PatientId);

        public IEnumerable<SelectListItem> DropDownListInsuranceCompanies();
    }
}
