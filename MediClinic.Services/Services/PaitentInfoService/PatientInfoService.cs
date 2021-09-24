using AutoMapper;
using Dapper;
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
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediClinic.Models.DTOs.PatientRelationshipDto;
using MediClinic.Models.DTOs.PatientLanguageDto;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.SessionManager;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediClinic.Services.Services.PatientInfoService
{
    public class PatientInfoService : IPatientInfoService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public PatientInfoService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public async Task<ResponseDto<List<PatientInfoBasicDto>>> patientInfo()
        {
            var rec = await _context.PatientInfo.OrderByDescending(x => x.PatientInfoId).ToListAsync();
            var response = new ResponseDto<List<PatientInfoBasicDto>>();
            response.Data = _mapper.Map<List<PatientInfo>, List<PatientInfoBasicDto>>(rec);
            return response;
        }


        public async Task<ResponseDto<PatientInfoBasicDto>> patientInfoCreate(PatientInfoBasicDto patientInfoBasicDto, string[] languages)
        {
            try
            {
                var PatLanguages = string.Empty;
                if (!(patientInfoBasicDto.PatientLanguages is null))
                {
                    PatLanguages = string.Join(",", patientInfoBasicDto.PatientLanguages);
                    patientInfoBasicDto.PatientLanguage = PatLanguages;
                }

                var mapped = _mapper.Map<PatientInfoBasicDto, PatientInfo>(patientInfoBasicDto);
                mapped.CreatedDate = DateTime.UtcNow;
                if (mapped.PatientColor == "#000000")
                {
                    mapped.PatientColor = "#fff";
                }

                if (mapped.GenderId == 0)
                {
                    mapped.GenderId = null;
                }
                mapped.IsActive = true;
                var data = await _context.PatientInfo.AddAsync(mapped);

                _context.SaveChanges();

                var userLanguageList = new List<UserLanguage>();
                var userId = mapped.UserId;
                if (!(languages is null))
                {
                    foreach (var item in languages)
                    {
                        var userlanguageObj = new UserLanguage();

                        userlanguageObj.UserId = userId;
                        userlanguageObj.LanguageId = Convert.ToInt32(item);
                        userLanguageList.Add(userlanguageObj);
                    }
                    _context.UserLanguage.AddRange(userLanguageList);
                    _context.SaveChanges();
                }

                var entity = _mapper.Map<PatientInfo, PatientInfoBasicDto>(mapped);
                var response = new ResponseDto<PatientInfoBasicDto>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {


                throw ex;
            }

        }

        public async Task<ResponseDto<bool>> patientInfoDeleteById(int Id)
        {
            try
            {
                long userId = 0;
                var oldEntity = await _context.PatientInfo.FirstOrDefaultAsync(x => x.PatientInfoId == Id);
                userId = (long)oldEntity.UserId;
                oldEntity.IsActive = false;
                _context.SaveChanges();

                var userOldEntity = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
                userOldEntity.IsActive = false;
                _context.SaveChanges();

                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<ResponseDto<PatientInfoBasicDto>> patientInfoGetId(int Id)
        {
            var oldEntity = await _context.PatientInfo.FirstOrDefaultAsync(x => x.PatientInfoId == Id);
            var mapped = _mapper.Map<PatientInfo, PatientInfoBasicDto>(oldEntity);
            var response = new ResponseDto<PatientInfoBasicDto>();
            response.Data = mapped;
            return response;
        }
        public PatientInfo GetPatientInfoById(long Id)
        {
            return _context.PatientInfo.Where(x => x.PatientInfoId == Id).FirstOrDefault();
        }
        public async Task<PatientInfoBasicDto> GetPatientDetailInfo(long patientInfoId)
        {

            var oldEntity = await
                _context.PatientInfo.Include(p => p.Gender)
                .Include(p => p.EmploymentStatus)
                .Include(p => p.EmploymentTitle)
                .Include(p => p.PatientLegal)
                .Include(p => p.PatientTreatment)
                .Include(p => p.User)
                .FirstOrDefaultAsync(x => x.PatientInfoId == patientInfoId);

            var mapped = _mapper.Map<PatientInfo, PatientInfoBasicDto>(oldEntity);
            var userDetails = await GetUserDetail(mapped.UserId);

            foreach (var item in userDetails.PatientPhoneNumber)
            {
                mapped.PatientPhoneNumber = item;
            }

            foreach (var item in userDetails.PatientCaseType)
            {
                mapped.PatientCaseType = item;
            }

            foreach (var item in userDetails.PatientsClaimInfo)
            {
                mapped.PatientsClaimInfo = item;
            }

            foreach (var item in userDetails.PatientEmergencyContact)
            {
                mapped.PatientEmergencyContact = item;
            }

            foreach (var item in userDetails.PatientIdAndSignature)
            {
                mapped.PatientIdAndSignature = item;
            }

            foreach (var item in userDetails.VehicalsOrEntityInvolved)
            {
                mapped.VehicalsOrEntityInvolved = item;
            }

            foreach (var item in userDetails.SecondaryInsurenceProvider)
            {
                mapped.SecondaryInsurenceProvider = item;
            }

            foreach (var item in userDetails.TertiaryInsurenceProvider)
            {
                mapped.TertiaryInsurenceProvider = item;
            }

            foreach (var item in userDetails.PatientPersonalInjury)
            {
                mapped.PatientPersonal = item;
            }
            foreach (var item in userDetails.PatientArbitrationAttorney)
            {
                mapped.PatientArbitrationAttorney = item;
            }


            return mapped;

        }

        public async Task<Users> GetUserDetail(long userId)
        {

            var Entity = await
                _context.Users.Include(p => p.PatientPhoneNumber)
                .Include(p => p.PatientCaseType)
                .Include(p => p.PatientsClaimInfo)
                .Include(p => p.PatientEmergencyContact)
                .Include(p => p.PatientIdAndSignature)
                .Include(p => p.VehicalsOrEntityInvolved)
                .Include(p => p.SecondaryInsurenceProvider)
                .Include(p => p.TertiaryInsurenceProvider)
                .Include(p => p.PatientPersonalInjury)
                .Include(p => p.PatientArbitrationAttorney)

                .FirstOrDefaultAsync(x => x.UserId == userId);

            //var response = new ResponseDto<PatientInfoBasicDto>();
            //response.Data = mapped;
            return Entity;

        }

        public PatientPhoneNumberBasicDto mappedPhoneNumber(PatientPhoneNumber phoneNumber)
        {
            var mapped = _mapper.Map<PatientPhoneNumberBasicDto>(phoneNumber);
            return mapped;
        }

        public PatientEmergencyContactBasicDto mappedEmergencyNumber(PatientEmergencyContact contactBasicDto)
        {
            var mapped = _mapper.Map<PatientEmergencyContactBasicDto>(contactBasicDto);
            return mapped;
        }

        public PatientIdandSignatureBasicDto mappedPatientIdSignature(PatientIdAndSignature idAndSignature)
        {
            var mapped = _mapper.Map<PatientIdandSignatureBasicDto>(idAndSignature);
            return mapped;
        }

        public PatientCaseTypeBasicDto mappedCaseType(PatientCaseType caseType)
        {
            var mapped = _mapper.Map<PatientCaseTypeBasicDto>(caseType);
            return mapped;
        }

        public PatientClaimInfoBasicDto mappedClaimInfo(PatientsClaimInfo claimInfo)
        {
            var mapped = _mapper.Map<PatientClaimInfoBasicDto>(claimInfo);
            return mapped;
        }

        public PatientVehiclesBasicDto mappedVehicles(VehicalsOrEntityInvolved vehicalsOrEntity)
        {
            var mapped = _mapper.Map<PatientVehiclesBasicDto>(vehicalsOrEntity);
            return mapped;
        }

        public PatientSecondaryInsuranceBasicDto mappedSecondaryInsurance(SecondaryInsurenceProvider insurenceProvider)
        {
            var mapped = _mapper.Map<PatientSecondaryInsuranceBasicDto>(insurenceProvider);
            return mapped;
        }

        public PatientTertiaryInsuranceBasicDto mappedTertiaryInsurance(TertiaryInsurenceProvider insurenceProvider)
        {
            var mapped = _mapper.Map<PatientTertiaryInsuranceBasicDto>(insurenceProvider);
            return mapped;
        }

        public PatientPersonalInjuryBasicDto mappedPersonalInjury(PatientPersonalInjury patientPersonal)
        {
            var mapped = _mapper.Map<PatientPersonalInjuryBasicDto>(patientPersonal);
            return mapped;
        }

        public PatientArbitrationAttorneyBasicDto mappedArbitrationAttorney(PatientArbitrationAttorney insurenceProvider)
        {
            var mapped = _mapper.Map<PatientArbitrationAttorneyBasicDto>(insurenceProvider);
            return mapped;
        }
        public PatientRelationshipBasicDto mappedPatientRelationShip(PatientRelationship patientRelationship)
        {
            var mapped = _mapper.Map<PatientRelationshipBasicDto>(patientRelationship);
            return mapped;
        }
        //public async Task<List<PatientInfoBasicDto>> GetAllLabCostByPackageId(int packaageId)
        //{
        //    var PackageId = new SqlParameter("@PackageId", packaageId as object ?? DBNull.Value);

        //    var result = await _context.Database.SqlQuery<PatientInfoBasicDto>("exec spGetLabCostByPackageId @PackageId", PackageId).ToListAsync();

        //    return result;
        //}

        public async Task<ResponseDto<bool>> patientInfoUpdate(PatientInfoBasicDto patientInfoBasicDto, string[] languages)
        {
            try
            {
                var PatLanguages = string.Empty;
                if (!(patientInfoBasicDto.PatientLanguages is null))
                {
                    PatLanguages = string.Join(",", patientInfoBasicDto.PatientLanguages);
                    patientInfoBasicDto.PatientLanguage = PatLanguages;
                }
                var oldEntity = await _context.PatientInfo.FindAsync(patientInfoBasicDto.PatientInfoId);
                var mapped = _mapper.Map<PatientInfoBasicDto, PatientInfo>(patientInfoBasicDto, oldEntity);
                if (oldEntity.PatientColor == "#000000")
                {
                    oldEntity.PatientColor = "#fff";
                }

                oldEntity.CreatedDate = DateTime.Now;
                oldEntity.IsActive = true;

                //_context.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _context.SaveChangesAsync();


                var userId = oldEntity.UserId;
                var previousUserLanguages = _context.UserLanguage.Where(x => x.UserId == userId).ToList();
                if (!(previousUserLanguages is null))
                {
                    _context.UserLanguage.RemoveRange(previousUserLanguages);
                    await _context.SaveChangesAsync();
                }

                var userLanguageList = new List<UserLanguage>();
                foreach (var item in languages)
                {
                    var userlanguageObj = new UserLanguage();

                    userlanguageObj.UserId = userId;
                    userlanguageObj.LanguageId = Convert.ToInt32(item);
                    userLanguageList.Add(userlanguageObj);
                }
                _context.UserLanguage.AddRange(userLanguageList);
                _context.SaveChanges();


                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<List<PatientLanguageBasicDto>> GetPatientLanguages(long UserId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<PatientLanguageBasicDto>(sql: "[spGetPatientLanguagesList]", param: new { userId = UserId },
                commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public async Task<ResponseDto<PatientInfoBasicDto>> patientInfoGetLastAdded()
        {
            var oldEntity = await _context.PatientInfo.OrderByDescending(x => x.PatientInfoId).FirstOrDefaultAsync();
            var mapped = _mapper.Map<PatientInfo, PatientInfoBasicDto>(oldEntity);
            var response = new ResponseDto<PatientInfoBasicDto>();
            response.Data = mapped;
            return response;
        }



        public async Task<PatientInfoListDto> GetPatientSummaryDetails(long patientInfoId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<PatientInfoListDto>(sql: "[spGetPatientInfoDetailsById]", param: new { patientId = patientInfoId },
                commandType: CommandType.StoredProcedure);
                var data = result.FirstOrDefault();

                //For languages
                var languages = await GetPatientLanguages(data.UserId);
                if (!(languages is null))
                {
                    var names = languages.Select(x => x.LanguageName).ToList();
                    data.LanguageName = string.Join(',', names);
                    if (names.Count == 0)
                    {
                        data.LanguageName = "N/A";
                    }
                }

                return data;

            }
        }

        public async Task<List<PatientInfoListDto>> GetPatientListWithDetails()
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<PatientInfoListDto>(sql: "[spGetPatientListDetails]",
                commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public IEnumerable<SelectListItem> DropDownListInsuranceCompanies()
        {
            return _context.InsuranceCompanies.Select(x => new SelectListItem()
            {
                Text = x.InsuranceCompanyName,
                Value = x.ComapnyID.ToString()
            });
        }
        public async Task<PatientInfoBasicDto> GetPatientDetailForUpdate(int patientInfoId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<string>(sql: "[spGetPatientDetailsForUpdate]", param: new { patientId = patientInfoId },
                commandType: CommandType.StoredProcedure);
                var builder = new StringBuilder();
                foreach (var r in result)
                {
                    builder.Append(r);
                }

                var response = JsonConvert.DeserializeObject<PatientInfoBasicDto>(builder.ToString());

                return response;
            }
        }

        public async Task<PatientVMDto> GetPatientDropDownData()
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<string>(sql: "[spGetPatientDropDownData]",
                commandType: CommandType.StoredProcedure);
                var builder = new StringBuilder();
                foreach (var r in result)
                {
                    builder.Append(r);
                }

                var response = JsonConvert.DeserializeObject<PatientVMDto>(builder.ToString());

                return response;
            }
        }


        public async Task<List<PatientInfoListDto>> GetRelevantPatientDetails(string phoneNumber, string address, string emergencyphoneNumber, string emergencyPerson, string adjustorName)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<PatientInfoListDto>(sql: "[spGetSimilarPatients]", param: new { phoneNumber = phoneNumber, address = address, emergencyphoneNumber = emergencyphoneNumber, emergencyPerson = emergencyPerson, adjustorName = adjustorName },
                commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public PatientInfoBasicDto GetPatientName(long PatientInfoId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = conn.Query<PatientInfoBasicDto>(sql: "[GetPatientNameByPatientId]", param: new { patientId = PatientInfoId },
                commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }

        public async Task<PatientInfoBasicDto> GetPatientInfoData(long userId)
        {
            var entity = await _context.PatientInfo.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientInfoBasicDto>(entity);
                return mappedData;
            }
            else
            {
                return new PatientInfoBasicDto();
            }
        }

        public async Task<PatientPhoneNumberBasicDto> GetPatientPhoneNumberData(long userId)
        {
            var entity = await _context.PatientPhoneNumber.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientPhoneNumberBasicDto>(entity);
                return mappedData;
            }
            else
            {
                return new PatientPhoneNumberBasicDto();
            }
        }

        public async Task<PatientEmergencyContactBasicDto> GetPatientEmergencyData(long userId)
        {
            var entity = await _context.PatientEmergencyContact.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientEmergencyContactBasicDto>(entity);
                return mappedData;
            }
            else
            {
                return new PatientEmergencyContactBasicDto();
            }
        }

        public async Task<PatientIdandSignatureBasicDto> GetPatientSignatureFormData(long userId)
        {
            var entity = await _context.PatientIdAndSignature.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientIdandSignatureBasicDto>(entity);
                return mappedData;
            }
            else
            {
                return new PatientIdandSignatureBasicDto();
            }
        }


        public async Task<PatientClaimInfoBasicDto> GetPatientClaimInfoData(long userId)
        {
            var entity = await _context.PatientsClaimInfo.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientClaimInfoBasicDto>(entity);
                return mappedData;
            }
            else
            {
                return new PatientClaimInfoBasicDto();
            }
        }
        public async Task<List<PatientVehiclesBasicDto>> GetPatientVehicleData(long userId)
        {
            var entity = await _context.VehicalsOrEntityInvolved.Where(x => x.UserId == userId).ToListAsync();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<List<PatientVehiclesBasicDto>>(entity);
                return mappedData;
            }
            else
            {
                return new List<PatientVehiclesBasicDto>();
            }
        }

        public async Task<PatientSecondaryInsuranceBasicDto> GetPatientSecondaryData(long userId)
        {
            var entity = await _context.SecondaryInsurenceProvider.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientSecondaryInsuranceBasicDto>(entity);
                return mappedData;
            }
            else
            {
                return new PatientSecondaryInsuranceBasicDto();
            }
        }

        public async Task<PatientTertiaryInsuranceBasicDto> GetPatientTertiaryData(long userId)
        {
            var entity = await _context.TertiaryInsurenceProvider.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientTertiaryInsuranceBasicDto>(entity);
                return mappedData;
            }
            else
            {
                return new PatientTertiaryInsuranceBasicDto();
            }
        }

        public async Task<PatientPersonalInjuryBasicDto> GetPatientPIData(long userId)
        {
            var entity = await _context.PatientPersonalInjury.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientPersonalInjuryBasicDto>(entity);
                return mappedData;
            }
            else
            {
                return new PatientPersonalInjuryBasicDto();
            }
        }

        public async Task<PatientArbitrationAttorneyBasicDto> GetPatientCollectionData(long userId)
        {
            var entity = await _context.PatientArbitrationAttorney.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientArbitrationAttorneyBasicDto>(entity);
                return mappedData;
            }
            else
            {
                return new PatientArbitrationAttorneyBasicDto();
            }
        }

        public async Task<long> GetUserIdFromPatientId(long patientinfoId)
        {
            var userId = await _context.PatientInfo.Where(x => x.PatientInfoId == patientinfoId).Select(x => x.UserId).FirstOrDefaultAsync();
            return (long)userId;
        }

        public long GetMaxPatientId()
        {
            var patientId = _context.PatientInfo.Max(x => x.PatientInfoId);
            var nextId = patientId + 1;
            return nextId;
        }
        public async Task<List<VisitsDto>> GetVisitsList(int PatientId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<VisitsDto>(sql: "[sp_GetVisitIdByPatientId]",
                param: new { patientId = PatientId },
                commandType: CommandType.StoredProcedure);
                List<VisitsDto> visit = result.ToList();
                return visit;
            }
        }

        public async Task<bool> AddEmail(ClaimEmailDto claimEmailDto)
        {
            var mapped = _mapper.Map<ClaimEmail>(claimEmailDto);
            MediClinicContext context = new MediClinicContext();
            mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
            mapped.CreatedDate = DateTime.UtcNow;
            context.ClaimEmail.Add(mapped);
            await context.SaveChangesAsync();
            return true;
        }

        public bool EmployeeVerificationEmail(string email, string Subject, string message)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage
            {
                From = new System.Net.Mail.MailAddress("info@imedhealth.us")
            };
            System.Net.Mail.SmtpClient client;
            System.Net.NetworkCredential credentials;
            credentials = new System.Net.NetworkCredential();
            credentials = new System.Net.NetworkCredential("info@imedhealth.us", "infoimedtracker");

            client = new System.Net.Mail.SmtpClient
            {
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587
            };
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            if (email is null)
            {
                return false;
            }

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            mail.To.Add(new System.Net.Mail.MailAddress(email));

            mail.Subject = Subject;
            mail.IsBodyHtml = true;
            mail.Body = message;
            client.Send(mail);


            return true;
        }

        public Task<List<VisitsDto>> GetVisitsListByPatient(int PatientId)
        {
            throw new NotImplementedException();
        }

        public int? GetLatestVisitIDAgainstPatient(long Id)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = conn.Query<int?>(sql: "[spGetLatestVisitIDByPatientId]",
                param: new { patientId = Id },
                commandType: CommandType.StoredProcedure);
                var visitId = result.FirstOrDefault();

                if (!(visitId is null))
                {
                    _sessionManager.SetVisitId(visitId.Value);
                }
                
                return visitId;
            }
        }

        public async Task<List<PatientInfoBasicDto>> GetInActivePatientList()
        {
            var data = await _context.PatientInfo.Include(x=>x.EmploymentStatus).Include(x=>x.EmploymentTitle).Include(x=>x.Gender).Include(x=>x.LanguageNavigation).Include(x=>x.User).Where(x=>x.IsActive==false).ToListAsync();
            var mapper = _mapper.Map<List<PatientInfoBasicDto>>(data);
            return mapper;
        }

        public async Task<QuickRegisterPatientDto> QuickRegisterPatient(QuickRegisterPatientDto quickRegister)
        {
            try
            {
                var QuickRegister = new QuickRegisterPatientDto();
                var newUser = new Users();
                var newPatient = new PatientInfo();
                var newPhoneNumber = new PatientPhoneNumber();

                newUser.IsActive = true;
                newUser.CreatedById = (int?)_sessionManager.GetUserId();
                newUser.CreatedDate = DateTime.UtcNow;

                newPatient.IsActive = true;
                newPatient.CreatedById= (int?)_sessionManager.GetUserId();
                newPatient.CreatedDate = DateTime.UtcNow;

                newPhoneNumber.IsActive = true;
                newPhoneNumber.CreatedById = (int?)_sessionManager.GetUserId();
                newPhoneNumber.CreatedDate = DateTime.UtcNow;

                var user = await _context.Users.AddAsync(newUser);
                 await _context.SaveChangesAsync();

                newPatient.FirstName = quickRegister.FirstName;
                newPatient.LastName = quickRegister.LastName;
                newPatient.UserId = user.Entity.UserId;
                newPatient.AddressLine1 = quickRegister.Address;
                var patient =  _context.PatientInfo.Add(newPatient);
                _context.SaveChanges();
                newPhoneNumber.UserId = user.Entity.UserId;
                newPhoneNumber.MobilePhone = quickRegister.PhoneNumber;
                newPhoneNumber.IsActive = true;
                var phonenNUmber = _context.PatientPhoneNumber.Add(newPhoneNumber);
                _context.SaveChanges();

                quickRegister.Id = patient.Entity.PatientInfoId;
               

                return quickRegister;
            }
            catch (Exception ex)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public async Task<PatientInfoListDto> PatientDetails(long patientInfoId)
        {
            var joinData = await (from P in _context.PatientInfo.Where(x => x.PatientInfoId == patientInfoId)
                                  join N in _context.PatientPhoneNumber
                                  on P.UserId equals N.UserId



                                  select new PatientInfoListDto
                                  {
                                      FullName = P.FirstName + P.LastName,
                                      AddressLine1 = P.AddressLine1,
                                      AddressLine2 = P.AddressLine2,
                                      AddressLine3 = P.AddressLine3,
                                      MobilePhone = N.MobilePhone

                                  }).FirstOrDefaultAsync();

            return joinData;
        }

        public async Task<string> GetPatientLatestVisitDate(long PaatientId)
        {
            try
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = await conn.QueryAsync<string>(sql: "[spPatientLatestVisitDate]", param: new { PatientId = PaatientId },
                    commandType: CommandType.StoredProcedure);

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> GetPatientLatestExamDate(long PatientId)
        {
            var rec =await _context.ReportExamInformation.Where(x => x.PatientId == PatientId).OrderByDescending(x => x.ExamInformationId).FirstOrDefaultAsync();
            if (!(rec is null))
            {
                return rec.DateOfExam.ToString("MM/dd/yyyy");

            }
            else
            {
                return "N/A";
            }
        }

        public async Task<ResponseDto<bool>> patientActiveById(long Id)
        {
            try
            {
                long userId = 0;
                var oldEntity = await _context.PatientInfo.FirstOrDefaultAsync(x => x.PatientInfoId == Id);
                userId = (long)oldEntity.UserId;
                oldEntity.IsActive = true;
                _context.SaveChanges();

                var userOldEntity = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
                userOldEntity.IsActive = true;
                _context.SaveChanges();

                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}