using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.DTOs.PMHistory;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.Patient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.Patient
{
    public class PatientService : IPatientService
    {
        private MediClinicContext _db;
        private IMapper _mapper;

        public PatientService(MediClinicContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        //public List<PatientInfoBasicDto> GetPatientinfo()
        //{
        //    var list = _db.PatientInfo.ToList();
        //    var mapped = _mapper.Map<List<PatientInfoBasicDto>>(list);
        //    return mapped;
        //}
        public DashboardCountDto GetProvidertinfo()
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = conn.Query<DashboardCountDto>(sql: "[spPatientInfoListCount]",
                commandType: CommandType.StoredProcedure);

                var response = result.ToList();
                return result.FirstOrDefault();
            }

        }

        public ClinicViewDto GetClinicView()
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = conn.Query<ClinicViewDto>(sql: "[spGetClinicOverviewlists]",
                commandType: CommandType.StoredProcedure);

                var response = result.ToList();
                return result.FirstOrDefault();
            }

            }

        #region SocialHistory
        public int SaveMHSocialHistory(MHSocialHistory MHSocialHistory)
        {
            int status = 0;
            if (MHSocialHistory.Id == 0)
            {
                MHSocialHistory.DateCreated = DateTime.UtcNow;
                _db.MHSocialHistory.Add(MHSocialHistory);
                _db.SaveChanges();
            }
            else
            {

                var EditMHSocialHistory = _db.MHSocialHistory.Where(a => a.Id == MHSocialHistory.Id).FirstOrDefault();
                EditMHSocialHistory.ModifiedDate = DateTime.UtcNow;
                EditMHSocialHistory.Smoking = MHSocialHistory.Smoking;
                EditMHSocialHistory.Drugs = MHSocialHistory.Drugs;
                EditMHSocialHistory.Alcohol = MHSocialHistory.Alcohol;
                EditMHSocialHistory.AlcoholDrinks = MHSocialHistory.AlcoholDrinks;
                EditMHSocialHistory.AlcoholPreferredDrink = MHSocialHistory.AlcoholPreferredDrink;
                EditMHSocialHistory.AlcoholYearQuit = MHSocialHistory.AlcoholYearQuit;
                EditMHSocialHistory.Caffeine = MHSocialHistory.Caffeine;
                EditMHSocialHistory.CaffeineNotes = MHSocialHistory.CaffeineNotes;
                EditMHSocialHistory.CaffeineDrinks = MHSocialHistory.CaffeineDrinks;
                EditMHSocialHistory.Tobacco = MHSocialHistory.Tobacco;
                EditMHSocialHistory.TobaccoAmountPerDay = MHSocialHistory.TobaccoAmountPerDay;
                EditMHSocialHistory.TobaccoType = MHSocialHistory.TobaccoType;
                EditMHSocialHistory.TobaccoUsedYear = MHSocialHistory.TobaccoUsedYear;
                EditMHSocialHistory.TobaccoYearQuit = MHSocialHistory.TobaccoYearQuit;
                EditMHSocialHistory.RecreationalDrugs = MHSocialHistory.RecreationalDrugs;
                EditMHSocialHistory.RecreationalDrugsAmountPerWeek = MHSocialHistory.RecreationalDrugsAmountPerWeek;
                EditMHSocialHistory.RecreationalDrugsLastUsed = MHSocialHistory.RecreationalDrugsLastUsed;
                EditMHSocialHistory.RecreationalDrugsType = MHSocialHistory.RecreationalDrugsType;
                EditMHSocialHistory.Exercise = MHSocialHistory.Exercise;
                EditMHSocialHistory.ExerciseNoOfDaysPerWeek = MHSocialHistory.ExerciseNoOfDaysPerWeek;
                EditMHSocialHistory.ExerciseType = MHSocialHistory.ExerciseType;
                EditMHSocialHistory.HobbiesORLeisureActivities = MHSocialHistory.HobbiesORLeisureActivities;
                EditMHSocialHistory.LastMonthFeeling = MHSocialHistory.LastMonthFeeling;
                EditMHSocialHistory.LastMonthPleasure = MHSocialHistory.LastMonthPleasure;

                _db.SaveChanges();
            }
            status = MHSocialHistory.Id;
            return status;
        }
        public int SaveMHPregnenciesHistory(MHPregnanciesHistory mHPregnanciesHistory)
        {
            int status = 0;
            if (mHPregnanciesHistory.Id == 0)
            {
                mHPregnanciesHistory.DateCreated = DateTime.UtcNow;
                _db.MHPregnanciesHistory.Add(mHPregnanciesHistory);
                _db.SaveChanges();
            }
            else
            {

                var result = _db.MHPregnanciesHistory.Where(a => a.Id == mHPregnanciesHistory.Id).FirstOrDefault();
                result.ModifiedDate = DateTime.UtcNow;
                result.Mammogram = mHPregnanciesHistory.Mammogram;
                result.BreastExam = mHPregnanciesHistory.BreastExam;
                result.PapSmear = mHPregnanciesHistory.PapSmear;
                result.Contraception = mHPregnanciesHistory.Contraception;
                result.ContraceptionDetail = mHPregnanciesHistory.ContraceptionDetail;
                result.FirstMensesAge = mHPregnanciesHistory.FirstMensesAge;
                result.MenstrualPeriods = mHPregnanciesHistory.MenstrualPeriods;
                result.MenopauseAge = mHPregnanciesHistory.MenopauseAge;
                result.HotFlashesOrOther = mHPregnanciesHistory.HotFlashesOrOther;
                result.GynecologicalConditions = mHPregnanciesHistory.GynecologicalConditions;
                result.Notes = mHPregnanciesHistory.Notes;
                _db.SaveChanges();
            }
            status = mHPregnanciesHistory.Id;
            return status;
        }

        public async Task<ResponseDto<MHSocialHistoryDTO>> GetMHSocialHistory(long PatientId)
        {
            var oldEntity = await _db.MHSocialHistory.FirstOrDefaultAsync(x => x.PatientId == PatientId);
            var mapped = _mapper.Map<MHSocialHistory, MHSocialHistoryDTO>(oldEntity);
            var response = new ResponseDto<MHSocialHistoryDTO>();
            response.Data = mapped;
            return response;
        }
        //public MHSocialHistory GetMHSocialHistory(long PatientId)
        //{
        // return _db.MHSocialHistory.Where(a => a.PatientId == PatientId).FirstOrDefault();           
        //}
        #endregion

        #region Recreational-History
        public int SaveMHRecreationalDrugsHistory(MHRecreationalDrugsHistory MHRecreationalDrugsHistory)
        {
            int status = 0;
            MHRecreationalDrugsHistory AlreadyExist = new MHRecreationalDrugsHistory();
            if (MHRecreationalDrugsHistory.Id == 0)
            {
                AlreadyExist = _db.MHRecreationalDrugsHistory.Where(a => a.Drugs == MHRecreationalDrugsHistory.Drugs && a.RecreationalDugsType == MHRecreationalDrugsHistory.RecreationalDugsType && a.PatientId == MHRecreationalDrugsHistory.PatientId).FirstOrDefault();

            }
            else
            {
                AlreadyExist = _db.MHRecreationalDrugsHistory.Where(a => a.Id != MHRecreationalDrugsHistory.Id && a.Drugs == MHRecreationalDrugsHistory.Drugs && a.RecreationalDugsType == MHRecreationalDrugsHistory.RecreationalDugsType && a.PatientId == MHRecreationalDrugsHistory.PatientId).FirstOrDefault();

            }
            if (MHRecreationalDrugsHistory.Id == 0)
            {
                if (AlreadyExist == null)
                {
                    MHRecreationalDrugsHistory.DateCreated = DateTime.Now;
                    _db.MHRecreationalDrugsHistory.Add(MHRecreationalDrugsHistory);
                    _db.SaveChanges();
                    status = MHRecreationalDrugsHistory.Id;
                }
                else
                {
                    status = -1;
                }
            }
            else
            {
                if (AlreadyExist == null)
                {
                    MHRecreationalDrugsHistory EditMHRecreationalDrugsHistory = new MHRecreationalDrugsHistory();
                    EditMHRecreationalDrugsHistory = _db.MHRecreationalDrugsHistory.Where(a => a.Id == MHRecreationalDrugsHistory.Id).FirstOrDefault();

                    EditMHRecreationalDrugsHistory.ModifiedDate = DateTime.Now;
                    EditMHRecreationalDrugsHistory.RecreationalDugsType = MHRecreationalDrugsHistory.RecreationalDugsType;
                    EditMHRecreationalDrugsHistory.RecreationDrugsNotes = MHRecreationalDrugsHistory.RecreationDrugsNotes;

                    _db.SaveChanges();
                    status = MHRecreationalDrugsHistory.Id;
                }
                else if (AlreadyExist != null && AlreadyExist.Id == MHRecreationalDrugsHistory.Id)
                {
                    MHRecreationalDrugsHistory EditMHRecreationalDrugsHistory = new MHRecreationalDrugsHistory();
                    EditMHRecreationalDrugsHistory = _db.MHRecreationalDrugsHistory.Where(a => a.Id == MHRecreationalDrugsHistory.Id).FirstOrDefault();

                    EditMHRecreationalDrugsHistory.ModifiedDate = DateTime.UtcNow;
                    EditMHRecreationalDrugsHistory.RecreationalDugsType = MHRecreationalDrugsHistory.RecreationalDugsType;
                    EditMHRecreationalDrugsHistory.RecreationDrugsNotes = MHRecreationalDrugsHistory.RecreationDrugsNotes;
                    EditMHRecreationalDrugsHistory.RecreationalDrugsLastUsed = MHRecreationalDrugsHistory.RecreationalDrugsLastUsed;
                    EditMHRecreationalDrugsHistory.RecreationDrugsAmount = MHRecreationalDrugsHistory.RecreationDrugsAmount;
                    EditMHRecreationalDrugsHistory.Id = MHRecreationalDrugsHistory.Id;
                    EditMHRecreationalDrugsHistory.Drugs = MHRecreationalDrugsHistory.Drugs;

                    _db.SaveChanges();
                    status = MHRecreationalDrugsHistory.Id;
                }
                else
                {
                    status = -1;
                }
            }

            return status;


        }
        public MHRecreationalDrugsHistory EditMHRecreationalDrugsHistory(long Id)
        {
            return _db.MHRecreationalDrugsHistory.Where(a => a.Id == Id).FirstOrDefault();
        }
        public List<MHRecreationalDrugsHistory> GetMHRecreationalDrugsHistory(long PatientId)
        {
            return _db.MHRecreationalDrugsHistory.Where(a => a.PatientId == PatientId).ToList();
        }
        public bool DeleteMHRecreationalDrugsHistory(long Id)
        {
            bool status = false;
            MHRecreationalDrugsHistory Del = new MHRecreationalDrugsHistory();

            Del = _db.MHRecreationalDrugsHistory.Where(a => a.Id == Id).FirstOrDefault();

            if (Del != null)
            {
                _db.MHRecreationalDrugsHistory.Remove(Del);

                _db.SaveChanges();
                status = true;
            }
            return status;
        }
        public List<MHPastDiseaseHistory> GetMHPastDiseaseHistory(long PatientId)
        {
            return _db.MHPastDiseaseHistory.Where(a => a.PatientId == PatientId).ToList();
        }

        #endregion

        #region My-Physician

        public async Task<ResponseDto<MHMyPhysicianDTO>> SaveMHMyPhysicians(MHMyPhysicianDTO MHMyPhysicianDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHMyPhysicianDTO, MHMyPhysicians>(MHMyPhysicianDTO);
                mapped.DateCreated = DateTime.UtcNow;
                var data = await _db.MHMyPhysicians.AddAsync(mapped);
                _db.SaveChanges();
                var entity = _mapper.Map<MHMyPhysicians, MHMyPhysicianDTO>(mapped);
                var response = new ResponseDto<MHMyPhysicianDTO>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ResponseDto<bool>> UpdateMyPhysicians(MHMyPhysicianDTO mHMyPhysicianDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHMyPhysicianDTO, MHMyPhysicians>(mHMyPhysicianDTO);

                var oldEntity = await _db.MHMyPhysicians.FindAsync(mapped.Id);
                mapped.ModifiedDate = DateTime.UtcNow;

                _db.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _db.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<MHMyPhysicians> GetMHMyPhysiciany(long PatientId)
        {
            return _db.MHMyPhysicians.Where(a => a.PatientId == PatientId).ToList();
        }
        public MHMyPhysicians EditMHMyPhysician(long Id)
        {
            return _db.MHMyPhysicians.Where(a => a.Id == Id).FirstOrDefault();
        }
        public bool DeleteMHMyPhysician(int Id)
        {
            var record = _db.MHMyPhysicians.FirstOrDefault(x => x.Id == Id);
            if (record != null)
            {
                _db.Remove(record);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ResponseDto<bool>> isPhyscianHistoryExistorNot(string Name, string Location, string Hospital, string PhoneNo, string Notes, string Specialty, int patientd)
        {
            var isExist = false;
            var value = await _db.MHMyPhysicians.Where(x => x.Name == Name && x.Location == Location && x.Hospital == Location && x.PhoneNo == PhoneNo && x.Notes == Notes && x.Specialty == Specialty && x.PatientId == patientd).FirstOrDefaultAsync();

            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
        #endregion

        #region Surgical history
        public int SaveMHSurgicalHistory(MHSurgicalHistory MHSurgicalHistory)
        {
            int status = 0;
            MHSurgicalHistory AlreadyExist = new MHSurgicalHistory();
            if (MHSurgicalHistory.Id == 0)
            {
                AlreadyExist = _db.MHSurgicalHistory.Where(a => a.SurgeryType == MHSurgicalHistory.SurgeryType && a.SurgeonName == MHSurgicalHistory.SurgeonName && a.Year == MHSurgicalHistory.Year && a.Notes == MHSurgicalHistory.Notes && a.PatientId == MHSurgicalHistory.PatientId).FirstOrDefault();

            }
            else
            {
                AlreadyExist = _db.MHSurgicalHistory.Where(a => a.Id != MHSurgicalHistory.Id && a.SurgeryType == MHSurgicalHistory.SurgeryType && a.SurgeonName == MHSurgicalHistory.SurgeonName && a.Year == MHSurgicalHistory.Year && a.Notes == MHSurgicalHistory.Notes && a.PatientId == MHSurgicalHistory.PatientId).FirstOrDefault();

            }
            if (MHSurgicalHistory.Id == 0)
            {
                if (AlreadyExist == null)
                {
                    MHSurgicalHistory.DateCreated = DateTime.UtcNow;
                    _db.MHSurgicalHistory.Add(MHSurgicalHistory);
                    _db.SaveChanges();
                    status = MHSurgicalHistory.Id;
                }
                else
                {
                    status = -1;
                }
            }
            else
            {
                if (AlreadyExist == null)
                {
                    MHSurgicalHistory EditMHSurgicalHistory = new MHSurgicalHistory();
                    EditMHSurgicalHistory = _db.MHSurgicalHistory.Where(a => a.Id == MHSurgicalHistory.Id).FirstOrDefault();
                    EditMHSurgicalHistory.ModifiedDate = DateTime.UtcNow;
                    EditMHSurgicalHistory.Disease = MHSurgicalHistory.Disease;
                    EditMHSurgicalHistory.SurgeryType = MHSurgicalHistory.SurgeryType;
                    EditMHSurgicalHistory.Year = MHSurgicalHistory.Year;
                    EditMHSurgicalHistory.Notes = MHSurgicalHistory.Notes;
                    EditMHSurgicalHistory.SurgeonName = MHSurgicalHistory.SurgeonName;
                    _db.SaveChanges();
                    status = MHSurgicalHistory.Id;
                }
                else if (AlreadyExist != null && AlreadyExist.Id == MHSurgicalHistory.Id)
                {
                    MHSurgicalHistory EditMHSurgicalHistory = new MHSurgicalHistory();
                    EditMHSurgicalHistory = _db.MHSurgicalHistory.Where(a => a.Id == MHSurgicalHistory.Id).FirstOrDefault();
                    EditMHSurgicalHistory.ModifiedDate = DateTime.UtcNow;
                    EditMHSurgicalHistory.Disease = MHSurgicalHistory.Disease;
                    EditMHSurgicalHistory.SurgeryType = MHSurgicalHistory.SurgeryType;
                    EditMHSurgicalHistory.Year = MHSurgicalHistory.Year;
                    EditMHSurgicalHistory.Notes = MHSurgicalHistory.Notes;
                    EditMHSurgicalHistory.SurgeonName = MHSurgicalHistory.SurgeonName;
                    _db.SaveChanges();
                    status = MHSurgicalHistory.Id;
                }
                else
                {
                    status = -1;
                }
            }

            return status;

        }
        public List<MHSurgicalHistory> GetMHSurgicalHistory(long PatientId)
        {
            return _db.MHSurgicalHistory.Where(a => a.PatientId == PatientId).ToList();
        }
        public MHSurgicalHistory EditMHSurgicalHistory(long Id)
        {
            return _db.MHSurgicalHistory.Where(a => a.Id == Id).FirstOrDefault();

        }
        public bool DeleteMHSurgicalHistory(long Id)
        {
            bool status = false;
            MHSurgicalHistory Del = new MHSurgicalHistory();
            Del = _db.MHSurgicalHistory.Where(a => a.Id == Id).FirstOrDefault();
            if (Del != null)
            {
                _db.MHSurgicalHistory.Remove(Del);
                _db.SaveChanges();
                status = true;
            }
            return status;
        }
        #endregion

        #region Hospitalization-History
        public int SaveMHHospitalizationsInfo(MHHospitalizationsInfo MHHospitalizationsInfo)
        {
            int status = 0;
            MHHospitalizationsInfo AlreadyExist = new MHHospitalizationsInfo();
            if(MHHospitalizationsInfo.Id == 0)
            {
                AlreadyExist = _db.MHHospitalizationsInfo.Where(a => a.HospitalName == MHHospitalizationsInfo.HospitalName && a.PatientId == MHHospitalizationsInfo.PatientId).FirstOrDefault();

            }
            else
            {
                AlreadyExist = _db.MHHospitalizationsInfo.Where(a =>a.Id != MHHospitalizationsInfo.Id && a.HospitalName == MHHospitalizationsInfo.HospitalName && a.PatientId == MHHospitalizationsInfo.PatientId).FirstOrDefault();

            }
            if (MHHospitalizationsInfo.Id == 0)
            {
                if (AlreadyExist == null)
                {
                    MHHospitalizationsInfo.DateCreated = DateTime.UtcNow;
                    _db.MHHospitalizationsInfo.Add(MHHospitalizationsInfo);
                    _db.SaveChanges();
                    status = MHHospitalizationsInfo.Id;
                }
                else
                {
                    status = -1;
                }
            }
            else
            {
                if (AlreadyExist == null)
                {
                    MHHospitalizationsInfo EditMHHospitalizationsInfo = new MHHospitalizationsInfo();
                    EditMHHospitalizationsInfo = _db.MHHospitalizationsInfo.Where(a => a.Id == MHHospitalizationsInfo.Id).FirstOrDefault();
                    EditMHHospitalizationsInfo.ModifiedDate = DateTime.UtcNow;
                    EditMHHospitalizationsInfo.HospitalName = MHHospitalizationsInfo.HospitalName;
                    EditMHHospitalizationsInfo.CountryId = MHHospitalizationsInfo.CountryId;
                    EditMHHospitalizationsInfo.StateId = MHHospitalizationsInfo.StateId;
                    EditMHHospitalizationsInfo.CityId = MHHospitalizationsInfo.CityId;
                    EditMHHospitalizationsInfo.PhoneNo = MHHospitalizationsInfo.PhoneNo;
                    EditMHHospitalizationsInfo.Year = MHHospitalizationsInfo.Year;
                    EditMHHospitalizationsInfo.illnessORinjury = MHHospitalizationsInfo.illnessORinjury;
                    EditMHHospitalizationsInfo.Notes = MHHospitalizationsInfo.Notes;
                    EditMHHospitalizationsInfo.Address = MHHospitalizationsInfo.Address;
                    _db.SaveChanges();
                    status = MHHospitalizationsInfo.Id;
                }
                else if (AlreadyExist != null && AlreadyExist.Id == MHHospitalizationsInfo.Id)
                {
                    MHHospitalizationsInfo EditMHHospitalizationsInfo = new MHHospitalizationsInfo();
                    EditMHHospitalizationsInfo = _db.MHHospitalizationsInfo.Where(a => a.Id == MHHospitalizationsInfo.Id).FirstOrDefault();
                    EditMHHospitalizationsInfo.ModifiedDate = DateTime.UtcNow;
                    EditMHHospitalizationsInfo.HospitalName = MHHospitalizationsInfo.HospitalName;
                    EditMHHospitalizationsInfo.CountryId = MHHospitalizationsInfo.CountryId;
                    EditMHHospitalizationsInfo.StateId = MHHospitalizationsInfo.StateId;
                    EditMHHospitalizationsInfo.CityId = MHHospitalizationsInfo.CityId;
                    EditMHHospitalizationsInfo.PhoneNo = MHHospitalizationsInfo.PhoneNo;
                    EditMHHospitalizationsInfo.Year = MHHospitalizationsInfo.Year;
                    EditMHHospitalizationsInfo.illnessORinjury = MHHospitalizationsInfo.illnessORinjury;
                    EditMHHospitalizationsInfo.Notes = MHHospitalizationsInfo.Notes;
                    EditMHHospitalizationsInfo.Address = MHHospitalizationsInfo.Address;
                    _db.SaveChanges();
                    status = MHHospitalizationsInfo.Id;
                }
                else
                {
                    status = -1;
                }
            }

            return status;

        }
        public List<vw_GetMHHospitalizationsInfo> GetMHHospitalizationsInfo(long PatientId)
        {

            return _db.vw_GetMHHospitalizationsInfo.Where(a => a.PatientId == PatientId).ToList();
        }
        public MHHospitalizationsInfo EditMHHospitalizationsInfo(long Id)
        {
            return _db.MHHospitalizationsInfo.Where(a => a.Id == Id).FirstOrDefault();
        }
        public bool DeleteMHHospitalizationsInfo(long Id)
        {

            bool status = false;
            MHHospitalizationsInfo Del = new MHHospitalizationsInfo();
            Del = _db.MHHospitalizationsInfo.Where(a => a.Id == Id).FirstOrDefault();
            if (Del != null)
            {
                _db.MHHospitalizationsInfo.Remove(Del);
                _db.SaveChanges();
                status = true;
            }
            return status;
        }

        #endregion

        #region MHPastDieaseHistory 
        public async Task<List<MHPastDiseaseHistory>> GetMHPastDiseaseHistory(int patientId)
        {
            return await _db.MHPastDiseaseHistory.Where(a => a.PatientId == patientId).ToListAsync();

        }

        public async Task<ResponseDto<MHPastDiseaseHistoryDTO>> mHPastDiseaseHistoryCreate(MHPastDiseaseHistoryDTO mHPastDiseaseHistoryDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHPastDiseaseHistoryDTO, MHPastDiseaseHistory>(mHPastDiseaseHistoryDTO);
                mapped.DateCreated = DateTime.UtcNow;
                var data = await _db.MHPastDiseaseHistory.AddAsync(mapped);
                _db.SaveChanges();
                var entity = _mapper.Map<MHPastDiseaseHistory, MHPastDiseaseHistoryDTO>(mapped);
                var response = new ResponseDto<MHPastDiseaseHistoryDTO>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool mHPastDiseaseHistoryDeleteById(int Id)
        {
            var record = _db.MHPastDiseaseHistory.FirstOrDefault(x => x.Id == Id);
            if (record != null)
            {
                _db.Remove(record);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ResponseDto<MHPastDiseaseHistoryDTO>> mHPastDiseaseHistoryGetId(int Id)
        {
            var oldEntity = await _db.MHPastDiseaseHistory.FirstOrDefaultAsync(x => x.Id == Id);
            var mapped = _mapper.Map<MHPastDiseaseHistory, MHPastDiseaseHistoryDTO>(oldEntity);
            var response = new ResponseDto<MHPastDiseaseHistoryDTO>();
            response.Data = mapped;
            return response;
        }
        public async Task<ResponseDto<bool>> mHPastDiseaseHistoryUpdate(MHPastDiseaseHistoryDTO mHPastDiseaseHistoryDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHPastDiseaseHistoryDTO, MHPastDiseaseHistory>(mHPastDiseaseHistoryDTO);

                var oldEntity = await _db.MHPastDiseaseHistory.FindAsync(mapped.Id);
                mapped.ModifiedDate = DateTime.UtcNow;

                _db.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _db.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<ResponseDto<bool>> isExistorNot(string Name, string Notes, int patientd)
        {
            var isExist = false;
            var value = await _db.MHPastDiseaseHistory.Where(x => x.Name.ToLower() == Name.ToLower() && x.Notes == Notes && x.PatientId == patientd).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
        #endregion

        #region MHExerciseHistory 
        public async Task<List<MHExerciseHistory>> GetMHExerciseHistoryList(int patientId)
        {
            return await _db.MHExerciseHistory.Where(a => a.PatientId == patientId).ToListAsync();

        }

        public async Task<ResponseDto<MHExerciseHistoryDTO>> mHExerciseHistoryCreate(MHExerciseHistoryDTO mHExerciseHistoryDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHExerciseHistoryDTO, MHExerciseHistory>(mHExerciseHistoryDTO);
                mapped.DateCreated = DateTime.UtcNow;
                var data = await _db.MHExerciseHistory.AddAsync(mapped);
                _db.SaveChanges();
                var entity = _mapper.Map<MHExerciseHistory, MHExerciseHistoryDTO>(mapped);
                var response = new ResponseDto<MHExerciseHistoryDTO>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool mHExerciseHistoryDeleteById(int Id)
        {
            var record = _db.MHExerciseHistory.FirstOrDefault(x => x.Id == Id);
            if (record != null)
            {
                _db.Remove(record);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ResponseDto<MHExerciseHistoryDTO>> mHExerciseHistoryGetId(int Id)
        {
            var oldEntity = await _db.MHExerciseHistory.FirstOrDefaultAsync(x => x.Id == Id);
            var mapped = _mapper.Map<MHExerciseHistory, MHExerciseHistoryDTO>(oldEntity);
            var response = new ResponseDto<MHExerciseHistoryDTO>();
            response.Data = mapped;
            return response;
        }
        public async Task<ResponseDto<bool>> mHExerciseHistoryUpdate(MHExerciseHistoryDTO mHExerciseHistoryDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHExerciseHistoryDTO, MHExerciseHistory>(mHExerciseHistoryDTO);

                var oldEntity = await _db.MHExerciseHistory.FindAsync(mapped.Id);
                mapped.ModifiedDate = DateTime.UtcNow;

                _db.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _db.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<ResponseDto<bool>> isExerciseHistoryExistorNot(string Name, string type, string notes, string DaysPerWeek, int patientd)
        {
            var isExist = false;
            var value = await _db.MHExerciseHistory.Where(x => x.ExerciseType == Name && x.ExerciseType == type && x.HobbiesOrLeisureActivities == notes && x.ExerciseNoOfDaysPerWeek == DaysPerWeek && x.PatientId == patientd).FirstOrDefaultAsync();

            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
        #endregion

        #region MHFamilyHistory 
        public async Task<List<MHFamilyHistory>> GetMHFamilyHistory(int patientId)
        {
            return await _db.MHFamilyHistory.Where(a => a.PatientId == patientId).ToListAsync();

        }

        public async Task<ResponseDto<MHFamilyHistoryDTO>> mHFamilyHistoryCreate(MHFamilyHistoryDTO mHFamilyHistoryDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHFamilyHistoryDTO, MHFamilyHistory>(mHFamilyHistoryDTO);
                mapped.DateCreated = DateTime.UtcNow;
                var data = await _db.MHFamilyHistory.AddAsync(mapped);
                _db.SaveChanges();
                var entity = _mapper.Map<MHFamilyHistory, MHFamilyHistoryDTO>(mapped);
                var response = new ResponseDto<MHFamilyHistoryDTO>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool mHFamilyHistoryDeleteById(int Id)
        {
            var record = _db.MHFamilyHistory.FirstOrDefault(x => x.Id == Id);
            if (record != null)
            {
                _db.Remove(record);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ResponseDto<MHFamilyHistoryDTO>> mHFamilyHistoryGetId(int Id)
        {
            var oldEntity = await _db.MHFamilyHistory.FirstOrDefaultAsync(x => x.Id == Id);
            var mapped = _mapper.Map<MHFamilyHistory, MHFamilyHistoryDTO>(oldEntity);
            var response = new ResponseDto<MHFamilyHistoryDTO>();
            response.Data = mapped;
            return response;
        }
        public async Task<ResponseDto<bool>> mHFamilyHistoryUpdate(MHFamilyHistoryDTO mHFamilyHistoryDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHFamilyHistoryDTO, MHFamilyHistory>(mHFamilyHistoryDTO);

                var oldEntity = await _db.MHFamilyHistory.FindAsync(mapped.Id);
                mapped.ModifiedDate = DateTime.UtcNow;

                _db.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _db.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<ResponseDto<bool>> isFamilyHistoryExistorNot(string Relation, string DeceasedOrDeathAge, string Notes, string MedicalConditionsOrCauseDeath, int patientd)
        {
            var isExist = false;
            var value = await _db.MHFamilyHistory.Where(x => x.Relation == Relation && x.DeceasedOrDeathAge == DeceasedOrDeathAge && x.Notes == Notes && x.MedicalConditionsOrCauseDeath == MedicalConditionsOrCauseDeath && x.PatientId == patientd).FirstOrDefaultAsync();

            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
        #endregion

        #region MHAllergiesHistory 
        public async Task<List<MHAllergiesHistory>> GetMHAllergiesHistory(int patientId)
        {
            return await _db.MHAllergiesHistory.Where(a => a.PatientId == patientId).ToListAsync();

        }

        public async Task<ResponseDto<MHAllergiesHistoryDTO>> mHAllergiesHistoryCreate(MHAllergiesHistoryDTO mHAllergiesHistory)
        {
            try
            {
                var mapped = _mapper.Map<MHAllergiesHistoryDTO, MHAllergiesHistory>(mHAllergiesHistory);
                mapped.DateCreated = DateTime.UtcNow;
                var data = await _db.MHAllergiesHistory.AddAsync(mapped);
                _db.SaveChanges();
                var entity = _mapper.Map<MHAllergiesHistory, MHAllergiesHistoryDTO>(mapped);
                var response = new ResponseDto<MHAllergiesHistoryDTO>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool mHAllergiesHistoryDeleteById(int Id)
        {
            var record = _db.MHAllergiesHistory.FirstOrDefault(x => x.Id == Id);
            if (record != null)
            {
                _db.Remove(record);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ResponseDto<MHAllergiesHistoryDTO>> mHAllergiesHistoryGetId(int Id)
        {
            var oldEntity = await _db.MHAllergiesHistory.FirstOrDefaultAsync(x => x.Id == Id);
            var mapped = _mapper.Map<MHAllergiesHistory, MHAllergiesHistoryDTO>(oldEntity);
            var response = new ResponseDto<MHAllergiesHistoryDTO>();
            response.Data = mapped;
            return response;
        }
        public async Task<ResponseDto<bool>> mHAllergiesHistoryUpdate(MHAllergiesHistoryDTO mHAllergiesHistoryDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHAllergiesHistoryDTO, MHAllergiesHistory>(mHAllergiesHistoryDTO);

                var oldEntity = await _db.MHAllergiesHistory.FindAsync(mapped.Id);
                mapped.ModifiedDate = DateTime.UtcNow;

                _db.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _db.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<ResponseDto<bool>> isAllergiesHistoryExistorNot(MHAllergiesHistoryDTO allergiesHistoryDTO, int patientd)
        {
            var isExist = false;
            var value = await _db.MHAllergiesHistory.Where(x => x.AllergyTo == allergiesHistoryDTO.AllergyTo && x.Recation == allergiesHistoryDTO.Recation && x.Notes == allergiesHistoryDTO.Notes && x.PatientId == patientd).FirstOrDefaultAsync();

            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
        #endregion

        #region MHPregnanciesHistory 

        public async Task<ResponseDto<MHPregnanciesHistoryDTO>> GetMHPregnanciesHistory(long PatientId)
        {
            var oldEntity = await _db.MHPregnanciesHistory.FirstOrDefaultAsync(x => x.PatientId == PatientId);
            var mapped = _mapper.Map<MHPregnanciesHistory, MHPregnanciesHistoryDTO>(oldEntity);
            var response = new ResponseDto<MHPregnanciesHistoryDTO>();
            response.Data = mapped;
            return response;
        }
        public async Task<ResponseDto<MHPregnanciesHistoryDTO>> mHPregnanciesHistoryCreate(MHPregnanciesHistoryDTO mHPregnanciesHistoryDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHPregnanciesHistoryDTO, MHPregnanciesHistory>(mHPregnanciesHistoryDTO);
                mapped.DateCreated = DateTime.UtcNow;
                var data = await _db.MHPregnanciesHistory.AddAsync(mapped);
                _db.SaveChanges();
                var entity = _mapper.Map<MHPregnanciesHistory, MHPregnanciesHistoryDTO>(mapped);
                var response = new ResponseDto<MHPregnanciesHistoryDTO>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool mHPregnanciesHistoryDeleteById(int Id)
        {
            var record = _db.MHPregnanciesHistory.FirstOrDefault(x => x.Id == Id);
            if (record != null)
            {
                _db.Remove(record);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ResponseDto<MHPregnanciesHistoryDTO>> mHPregnanciesHistoryGetId(int Id)
        {
            var oldEntity = await _db.MHPregnanciesHistory.FirstOrDefaultAsync(x => x.Id == Id);
            var mapped = _mapper.Map<MHPregnanciesHistory, MHPregnanciesHistoryDTO>(oldEntity);
            var response = new ResponseDto<MHPregnanciesHistoryDTO>();
            response.Data = mapped;
            return response;
        }
        public async Task<ResponseDto<bool>> mHPregnanciesHistoryUpdate(MHPregnanciesHistoryDTO mHPregnanciesHistoryDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHPregnanciesHistoryDTO, MHPregnanciesHistory>(mHPregnanciesHistoryDTO);

                var oldEntity = await _db.MHPregnanciesHistory.FindAsync(mapped.Id);
                mapped.ModifiedDate = DateTime.UtcNow;

                _db.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _db.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region MHDetailPregnanciesHistory 
        public async Task<List<MHDetailPregnanciesHistory>> GetMHDetailPregnanciesHistory(int patientId)
        {
            return await _db.MHDetailPregnanciesHistory.Where(a => a.PatientId == patientId).ToListAsync();

        }

        public async Task<ResponseDto<MHDetailPregnanciesHistoryDTO>> mHDetailPregnanciesHistoryCreate(MHDetailPregnanciesHistoryDTO mHDetailPregnanciesHistoryDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHDetailPregnanciesHistoryDTO, MHDetailPregnanciesHistory>(mHDetailPregnanciesHistoryDTO);
                mapped.DateCreated = DateTime.UtcNow;
                var data = await _db.MHDetailPregnanciesHistory.AddAsync(mapped);
                _db.SaveChanges();
                var entity = _mapper.Map<MHDetailPregnanciesHistory, MHDetailPregnanciesHistoryDTO>(mapped);
                var response = new ResponseDto<MHDetailPregnanciesHistoryDTO>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool mHDetailPregnanciesHistoryDeleteById(int Id)
        {
            var record = _db.MHDetailPregnanciesHistory.FirstOrDefault(x => x.Id == Id);
            if (record != null)
            {
                _db.Remove(record);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ResponseDto<MHDetailPregnanciesHistoryDTO>> mHDetailPregnanciesHistoryGetId(int Id)
        {
            var oldEntity = await _db.MHDetailPregnanciesHistory.FirstOrDefaultAsync(x => x.Id == Id);
            var mapped = _mapper.Map<MHDetailPregnanciesHistory, MHDetailPregnanciesHistoryDTO>(oldEntity);
            var response = new ResponseDto<MHDetailPregnanciesHistoryDTO>();
            response.Data = mapped;
            return response;
        }
        public async Task<ResponseDto<bool>> mHDetailPregnanciesHistoryUpdate(MHDetailPregnanciesHistoryDTO mHDetailPregnanciesHistoryDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHDetailPregnanciesHistoryDTO, MHDetailPregnanciesHistory>(mHDetailPregnanciesHistoryDTO);

                var oldEntity = await _db.MHDetailPregnanciesHistory.FindAsync(mapped.Id);
                mapped.ModifiedDate = DateTime.UtcNow;

                _db.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _db.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region MHHobbiesHistory 
        public async Task<List<MHHobbiesHistory>> GetMHHobbiesHistory(int patientId)
        {
            return await _db.MHHobbiesHistory.Where(a => a.PatientId == patientId).ToListAsync();

        }

        public async Task<ResponseDto<MHHobbiesHistoryDTO>> mHobbiesHistoryCreate(MHHobbiesHistoryDTO mHHobbiesHistoryDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHHobbiesHistoryDTO, MHHobbiesHistory>(mHHobbiesHistoryDTO);
                mapped.DateCreated = DateTime.UtcNow;
                var data = await _db.MHHobbiesHistory.AddAsync(mapped);
                _db.SaveChanges();
                var entity = _mapper.Map<MHHobbiesHistory, MHHobbiesHistoryDTO>(mapped);
                var response = new ResponseDto<MHHobbiesHistoryDTO>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool mHHobbiesHistoryDeleteById(int Id)
        {
            var record = _db.MHHobbiesHistory.FirstOrDefault(x => x.Id == Id);
            if (record != null)
            {
                _db.Remove(record);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ResponseDto<MHHobbiesHistoryDTO>> mHHobbiesHistoryGetId(int Id)
        {
            var oldEntity = await _db.MHHobbiesHistory.FirstOrDefaultAsync(x => x.Id == Id);
            var mapped = _mapper.Map<MHHobbiesHistory, MHHobbiesHistoryDTO>(oldEntity);
            var response = new ResponseDto<MHHobbiesHistoryDTO>();
            response.Data = mapped;
            return response;
        }
        public async Task<ResponseDto<bool>> mHHobbiesHistoryUpdate(MHHobbiesHistoryDTO mHHobbiesHistoryDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHHobbiesHistoryDTO, MHHobbiesHistory>(mHHobbiesHistoryDTO);

                var oldEntity = await _db.MHHobbiesHistory.FindAsync(mapped.Id);
                mapped.ModifiedDate = DateTime.UtcNow;

                _db.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _db.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ResponseDto<bool>> isHobbiesExistorNot(string title, int patientd)
        {
            var isExist = false;
            var value = await _db.MHHobbiesHistory.Where(x => x.Hobbies.ToLower() == title.ToLower() && x.PatientId == patientd).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
        #endregion

        #region MHPharmacyInfoHistory 
        public async Task<List<MHPharmacyInfo>> GetMHPharmacyInfoHistory(int patientId)
        {
            return await _db.MHPharmacyInfo.Where(a => a.PatientId == patientId).ToListAsync();

        }

        public async Task<ResponseDto<MHPharmacyInfoDTO>> mHPharmacyInfoHistoryCreate(MHPharmacyInfoDTO mHPharmacyInfoDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHPharmacyInfoDTO, MHPharmacyInfo>(mHPharmacyInfoDTO);
                mapped.DateCreated = DateTime.UtcNow;
                var data = await _db.MHPharmacyInfo.AddAsync(mapped);
                _db.SaveChanges();
                var entity = _mapper.Map<MHPharmacyInfo, MHPharmacyInfoDTO>(mapped);
                var response = new ResponseDto<MHPharmacyInfoDTO>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool mHPharmacyInfoHistoryDeleteById(int Id)
        {
            var record = _db.MHPharmacyInfo.FirstOrDefault(x => x.Id == Id);
            if (record != null)
            {
                _db.Remove(record);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ResponseDto<MHPharmacyInfoDTO>> mHPharmacyInfoHistoryGetId(int Id)
        {
            var oldEntity = await _db.MHPharmacyInfo.FirstOrDefaultAsync(x => x.Id == Id);
            var mapped = _mapper.Map<MHPharmacyInfo, MHPharmacyInfoDTO>(oldEntity);
            var response = new ResponseDto<MHPharmacyInfoDTO>();
            response.Data = mapped;
            return response;
        }
        public async Task<ResponseDto<bool>> mHharmacyInfoHistoryUpdate(MHPharmacyInfoDTO mHPharmacyInfoDTO)
        {
            try
            {
                var mapped = _mapper.Map<MHPharmacyInfoDTO, MHPharmacyInfo>(mHPharmacyInfoDTO);

                var oldEntity = await _db.MHPharmacyInfo.FindAsync(mapped.Id);
                mapped.ModifiedDate = DateTime.UtcNow;

                _db.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _db.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<ResponseDto<bool>> isPharmacyHistoryExistorNot(MHPharmacyInfoDTO mHPharmacy, int patientd)
        {
            var isExist = false;
            var value = await _db.MHPharmacyInfo.Where(x => x.Name.ToLower() == mHPharmacy.Name.ToLower() && x.Address == mHPharmacy.Address && x.PhoneNo == mHPharmacy.PhoneNo && x.ZipCode == mHPharmacy.ZipCode && x.City == mHPharmacy.City && x.State == mHPharmacy.State && x.FaxNo == mHPharmacy.FaxNo && x.PatientId == patientd).FirstOrDefaultAsync();

            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
        #endregion

        #region Current Medication
        public int SaveMHPastMedicationHistory(MHPastMedicationHistory MHPastMedicationHistory)
        {

            MHPastMedicationHistory AlreadyExist = new MHPastMedicationHistory();
            if (MHPastMedicationHistory.Id == 0)
            {
                AlreadyExist = _db.MHPastMedicationHistory.Where(a => a.Name == MHPastMedicationHistory.Name && a.PatientId == MHPastMedicationHistory.PatientId).FirstOrDefault();

            }
            else
            {
                AlreadyExist = _db.MHPastMedicationHistory.Where(a => a.Id !=MHPastMedicationHistory.Id && a.Name == MHPastMedicationHistory.Name && a.PatientId == MHPastMedicationHistory.PatientId).FirstOrDefault();

            }
            int status = 0;
            if (MHPastMedicationHistory.Id == 0)
            {
                if (AlreadyExist == null)
                {
                    MHPastMedicationHistory.DateCreated = DateTime.UtcNow;
                    _db.MHPastMedicationHistory.Add(MHPastMedicationHistory);
                    _db.SaveChanges();
                    status = MHPastMedicationHistory.Id;
                }
                else
                {
                    status = -1;
                }
            }
            else
            {
                if (AlreadyExist == null)
                {
                    MHPastMedicationHistory EditMHPastMedicationHistory = new MHPastMedicationHistory();
                    EditMHPastMedicationHistory = _db.MHPastMedicationHistory.Where(a => a.Id == MHPastMedicationHistory.Id).FirstOrDefault();
                    EditMHPastMedicationHistory.ModifiedDate = DateTime.UtcNow;
                    EditMHPastMedicationHistory.Name = MHPastMedicationHistory.Name;
                    EditMHPastMedicationHistory.ReasonForMedicine = MHPastMedicationHistory.ReasonForMedicine;
                    EditMHPastMedicationHistory.DocName = MHPastMedicationHistory.DocName;
                    EditMHPastMedicationHistory.DocNumber = MHPastMedicationHistory.DocNumber;
                    EditMHPastMedicationHistory.PharName = MHPastMedicationHistory.PharName;
                    EditMHPastMedicationHistory.PharNumber = MHPastMedicationHistory.PharNumber;
                    EditMHPastMedicationHistory.Dose = MHPastMedicationHistory.Dose;
                    EditMHPastMedicationHistory.DoseFrequency = MHPastMedicationHistory.DoseFrequency;
                    EditMHPastMedicationHistory.AsNeeded = MHPastMedicationHistory.AsNeeded;
                    EditMHPastMedicationHistory.Notes = MHPastMedicationHistory.Notes;
                    _db.SaveChanges();
                    status = MHPastMedicationHistory.Id;
                }
                else if (AlreadyExist != null && AlreadyExist.Id == MHPastMedicationHistory.Id)
                {
                    MHPastMedicationHistory EditMHPastMedicationHistory = new MHPastMedicationHistory();
                    EditMHPastMedicationHistory = _db.MHPastMedicationHistory.Where(a => a.Id == MHPastMedicationHistory.Id).FirstOrDefault();
                    EditMHPastMedicationHistory.ModifiedDate = DateTime.UtcNow;
                    EditMHPastMedicationHistory.Name = MHPastMedicationHistory.Name;
                    EditMHPastMedicationHistory.ReasonForMedicine = MHPastMedicationHistory.ReasonForMedicine;
                    EditMHPastMedicationHistory.DocName = MHPastMedicationHistory.DocName;
                    EditMHPastMedicationHistory.DocNumber = MHPastMedicationHistory.DocNumber;
                    EditMHPastMedicationHistory.PharName = MHPastMedicationHistory.PharName;
                    EditMHPastMedicationHistory.PharNumber = MHPastMedicationHistory.PharNumber;
                    EditMHPastMedicationHistory.Dose = MHPastMedicationHistory.Dose;
                    EditMHPastMedicationHistory.DoseFrequency = MHPastMedicationHistory.DoseFrequency;
                    EditMHPastMedicationHistory.AsNeeded = MHPastMedicationHistory.AsNeeded;
                    EditMHPastMedicationHistory.Notes = MHPastMedicationHistory.Notes;
                    _db.SaveChanges();
                    status = MHPastMedicationHistory.Id;
                }
                else
                {
                    status = -1;
                }
            }

            return status;

        }
        public List<MHPastMedicationHistory> GetMHPastMedicationHistory(long PatientId)
        {

            return _db.MHPastMedicationHistory.Where(a => a.PatientId == PatientId).ToList();

        }
        public MHPastMedicationHistory EditMHPastMedicationHistory(long Id)
        {

            return _db.MHPastMedicationHistory.Where(a => a.Id == Id).FirstOrDefault();

        }
        public bool DeleteMHPastMedicationHistory(long Id)
        {

            bool status = false;
            MHPastMedicationHistory Del = new MHPastMedicationHistory();
            Del = _db.MHPastMedicationHistory.Where(a => a.Id == Id).FirstOrDefault();
            if (Del != null)
            {
                _db.MHPastMedicationHistory.Remove(Del);
                _db.SaveChanges();
                status = true;
            }
            return status;

        }
       
        #endregion
    }

}
