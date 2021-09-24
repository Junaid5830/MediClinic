using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.DTOs.PMHistory;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Services.Patient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.Patient
{
    public interface IPatientService
    {
       
        #region SocialHistory
        public int SaveMHSocialHistory(MHSocialHistory MHSocialHistory);

        public int SaveMHPregnenciesHistory(MHPregnanciesHistory mHPregnanciesHistory);

        public Task<ResponseDto<MHSocialHistoryDTO>> GetMHSocialHistory(long PatientId);
        //public MHSocialHistory GetMHSocialHistory(long PatientId);
        #endregion

        #region Recreational-History
        public int SaveMHRecreationalDrugsHistory(MHRecreationalDrugsHistory MHRecreationalDrugsHistory);
        public MHRecreationalDrugsHistory EditMHRecreationalDrugsHistory(long Id);
        public List<MHRecreationalDrugsHistory> GetMHRecreationalDrugsHistory(long PatientId);
        public bool DeleteMHRecreationalDrugsHistory(long Id);
        public List<MHPastDiseaseHistory> GetMHPastDiseaseHistory(long PatientId);
        #endregion

        #region Physian
        public Task<ResponseDto<MHMyPhysicianDTO>> SaveMHMyPhysicians(MHMyPhysicianDTO MHMyPhysicianDTO);

        public Task<ResponseDto<bool>> UpdateMyPhysicians(MHMyPhysicianDTO mHMyPhysicianDTO);
        public List<MHMyPhysicians> GetMHMyPhysiciany(long PatientId);
        public MHMyPhysicians EditMHMyPhysician(long Id);
        public bool DeleteMHMyPhysician(int Id);

        public Task<ResponseDto<bool>> isPhyscianHistoryExistorNot(string Name, string Location, string Hospital, string PhoneNo, string Notes, string Specialty, int patientd);
        #endregion

        #region Surgical Strike history
        public int SaveMHSurgicalHistory(MHSurgicalHistory MHSurgicalHistory);
        public List<MHSurgicalHistory> GetMHSurgicalHistory(long PatientId);
        public bool DeleteMHSurgicalHistory(long Id);
        public MHSurgicalHistory EditMHSurgicalHistory(long Id);
        #endregion

        #region Hospitalization
        public int SaveMHHospitalizationsInfo(MHHospitalizationsInfo MHHospitalizationsInfo);
        public List<vw_GetMHHospitalizationsInfo> GetMHHospitalizationsInfo(long PatientId);
        public MHHospitalizationsInfo EditMHHospitalizationsInfo(long Id);
        public bool DeleteMHHospitalizationsInfo(long Id);
        #endregion

        #region pharmacy-info
        public Task<ResponseDto<MHPharmacyInfoDTO>> mHPharmacyInfoHistoryCreate(MHPharmacyInfoDTO mHPharmacyInfoDTO);
        public Task<List<MHPharmacyInfo>> GetMHPharmacyInfoHistory(int patientId);
        public Task<ResponseDto<bool>> mHharmacyInfoHistoryUpdate(MHPharmacyInfoDTO mHPharmacyInfoDTO);
        public Task<ResponseDto<MHPharmacyInfoDTO>> mHPharmacyInfoHistoryGetId(int Id);
        public bool mHPharmacyInfoHistoryDeleteById(int Id);

        public Task<ResponseDto<bool>> isPharmacyHistoryExistorNot(MHPharmacyInfoDTO mHPharmacy, int patientd);
        #endregion

        #region MHPastDieaseHistory
        public Task<List<MHPastDiseaseHistory>> GetMHPastDiseaseHistory(int patientId);
        public Task<ResponseDto<MHPastDiseaseHistoryDTO>> mHPastDiseaseHistoryCreate(MHPastDiseaseHistoryDTO mHPastDiseaseHistoryDTO);
        public Task<ResponseDto<bool>> mHPastDiseaseHistoryUpdate(MHPastDiseaseHistoryDTO patientInfoBasicDto);

        public Task<ResponseDto<MHPastDiseaseHistoryDTO>> mHPastDiseaseHistoryGetId(int Id);
        public bool mHPastDiseaseHistoryDeleteById(int Id);
        public Task<ResponseDto<bool>> isExistorNot(string Name,string Notes, int patientd);

        #endregion

        #region MHExerciseHistory
        public Task<List<MHExerciseHistory>> GetMHExerciseHistoryList(int patientId);
        public Task<ResponseDto<MHExerciseHistoryDTO>> mHExerciseHistoryCreate(MHExerciseHistoryDTO mHExerciseHistoryDTO);
        public Task<ResponseDto<bool>> mHExerciseHistoryUpdate(MHExerciseHistoryDTO mHExerciseHistoryDTO);

        public Task<ResponseDto<MHExerciseHistoryDTO>> mHExerciseHistoryGetId(int Id);
        public bool mHExerciseHistoryDeleteById(int Id);
        public Task<ResponseDto<bool>> isExerciseHistoryExistorNot(string Name, string type, string notes, string DaysPerWeek, int patientd);

        #endregion

        #region MHFamilyHistory
        public Task<List<MHFamilyHistory>> GetMHFamilyHistory(int patientId);
        public Task<ResponseDto<MHFamilyHistoryDTO>> mHFamilyHistoryCreate(MHFamilyHistoryDTO mHFamilyHistoryDTO);
        public Task<ResponseDto<bool>> mHFamilyHistoryUpdate(MHFamilyHistoryDTO mHFamilyHistoryDTO);

        public Task<ResponseDto<MHFamilyHistoryDTO>> mHFamilyHistoryGetId(int Id);
        public bool mHFamilyHistoryDeleteById(int Id);
        public Task<ResponseDto<bool>> isFamilyHistoryExistorNot(string Relation, string DeceasedOrDeathAge, string Notes, string MedicalConditionsOrCauseDeath, int patientd);

        #endregion

        #region MHAllergiesHistory
        public Task<List<MHAllergiesHistory>> GetMHAllergiesHistory(int patientId);
        public Task<ResponseDto<MHAllergiesHistoryDTO>> mHAllergiesHistoryCreate(MHAllergiesHistoryDTO mHAllergiesHistoryDTO);
        public Task<ResponseDto<bool>> mHAllergiesHistoryUpdate(MHAllergiesHistoryDTO mHAllergiesHistoryDTO);

        public Task<ResponseDto<MHAllergiesHistoryDTO>> mHAllergiesHistoryGetId(int Id);
        public bool mHAllergiesHistoryDeleteById(int Id);
        public Task<ResponseDto<bool>> isAllergiesHistoryExistorNot(MHAllergiesHistoryDTO allergiesHistoryDTO, int patientd);

        #endregion

        #region MHPregnanciesHistory
        public Task<ResponseDto<MHPregnanciesHistoryDTO>> GetMHPregnanciesHistory(long PatientId);
        public Task<ResponseDto<MHPregnanciesHistoryDTO>> mHPregnanciesHistoryCreate(MHPregnanciesHistoryDTO mHPregnanciesHistoryDTO);
        public Task<ResponseDto<bool>> mHPregnanciesHistoryUpdate(MHPregnanciesHistoryDTO mHPregnanciesHistoryDTO);

        public Task<ResponseDto<MHPregnanciesHistoryDTO>> mHPregnanciesHistoryGetId(int Id);
        public bool mHPregnanciesHistoryDeleteById(int Id);

        #endregion

        #region MHDetailPregnanciesHistory
        public Task<List<MHDetailPregnanciesHistory>> GetMHDetailPregnanciesHistory(int patientId);
        public Task<ResponseDto<MHDetailPregnanciesHistoryDTO>> mHDetailPregnanciesHistoryCreate(MHDetailPregnanciesHistoryDTO mHDetailPregnanciesHistoryDTO);
        public Task<ResponseDto<bool>> mHDetailPregnanciesHistoryUpdate(MHDetailPregnanciesHistoryDTO mHDetailPregnanciesHistoryDTO);

        public Task<ResponseDto<MHDetailPregnanciesHistoryDTO>> mHDetailPregnanciesHistoryGetId(int Id);
        public bool mHDetailPregnanciesHistoryDeleteById(int Id);

        #endregion


        #region MHHobbiesHistory
        public Task<List<MHHobbiesHistory>> GetMHHobbiesHistory(int patientId);
        public Task<ResponseDto<MHHobbiesHistoryDTO>> mHobbiesHistoryCreate(MHHobbiesHistoryDTO mHHobbiesHistoryDTO);
        public Task<ResponseDto<bool>> mHHobbiesHistoryUpdate(MHHobbiesHistoryDTO mHHobbiesHistoryDTO);

        public Task<ResponseDto<MHHobbiesHistoryDTO>> mHHobbiesHistoryGetId(int Id);
        public bool mHHobbiesHistoryDeleteById(int Id);
        public Task<ResponseDto<bool>> isHobbiesExistorNot(string title, int patientd);
        #endregion

        #region Medication history
        public int SaveMHPastMedicationHistory(MHPastMedicationHistory MHPastMedicationHistory);
        public List<MHPastMedicationHistory> GetMHPastMedicationHistory(long PatientId);
        public MHPastMedicationHistory EditMHPastMedicationHistory(long Id);
        public bool DeleteMHPastMedicationHistory(long Id);
        #endregion

        public DashboardCountDto GetProvidertinfo();
        public ClinicViewDto GetClinicView();
    }
}
