using AutoMapper;
using MediClinic.Models.DTOs.PatientSettingsDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientSettings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientSettings
{
    public class PatientSetting :IPatientSettings
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientSetting(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region For Patient Summary Settings
        public bool SavePatientSummaryDisplaySettings(PatientSettingDto patientSettingDto)
        {
            if (patientSettingDto.UserId > 0)
            {
                var oldEntity = _context.PatientDisplaySetting.FirstOrDefault();
                if (!(oldEntity is null))
                {
                    var mappedData = _mapper.Map<PatientDisplaySetting>(patientSettingDto);
                    mappedData.DisplayId = oldEntity.DisplayId;
                    mappedData.Print_ = patientSettingDto.Print;
                    mappedData.PatientId = null;
                    _context.Entry(oldEntity).CurrentValues.SetValues(mappedData);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    var mappedData = _mapper.Map<PatientDisplaySetting>(patientSettingDto);
                    mappedData.Print_ = patientSettingDto.Print;
                    mappedData.PatientId = null;
                    _context.PatientDisplaySetting.Add(mappedData);
                    _context.SaveChanges();
                    return true;
                }
            }
            return true;
        }

        public PatientSettingDto getPatientSettingsById(int userId)
        {
            var entity = _context.PatientDisplaySetting.FirstOrDefault();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientSettingDto>(entity);
                mappedData.Print = (bool)entity.Print_;
                return mappedData;
            }
            else
            {
                var entityData = new PatientDisplaySetting
                {
                    UserId = userId,
                    Phone = true,
                    Sms = true,
                    Email = true,
                    Fax = true,
                    Print_ = true,
                    LastName = true,
                    FirstName = true,
                    DOB = true,
                    Age = true,
                    Address = true,
                    Gender = true,
                    MobilePhone = true,
                    HomePhone = true,
                    EmergencyPhone = true,
                    Languages = true,
                    CaseType = true,
                    ClaimNumber = false,
                    PolicyNumber = false,
                    InsuranceNumber = true,
                    FullClaimInfo = true,
                    DateCreated = true,
                    PrimaryDr = false,
                    Dispatch = true,
                    AssignTransport = true,
                    RouteOptions = true,
                    FirstVisit = true,
                    LastVisit = false,
                    LastExam = false,
                    Vitals = false,
                    BodyStatus = false,
                    Tests = false,
                    Reminders = true,
                    Missing = false,
                    PIAttorney = true,
                    Paralegal = false,
                    CollectionAttorney = false,
                    ReferralName = false,
                    CurrentLocationInFacility = false,
                    LastIME = false,
                    LastEUO = false,
                    AllVisit = false,
                    NumberOfVisits = false,
                    RelatedPatientList = false
                };

                _context.PatientDisplaySetting.Add(entityData);
                _context.SaveChanges();
                var mappedData = _mapper.Map<PatientSettingDto>(entityData);
                mappedData.Print = (bool)entityData.Print_;
                return mappedData;
            }
        }
        #endregion



        #region For Print Settings
        public bool SavePatientPrintSettings(PatientPrintSettingDto patientSettingDto)
        {
            if (patientSettingDto.UserId > 0)
            {
                var oldEntity = _context.PatientPrintSetting.FirstOrDefault();
                if (!(oldEntity is null))
                {
                    var mappedData = _mapper.Map<PatientPrintSettingDto>(patientSettingDto);
                    mappedData.PrintId = oldEntity.PrintId;
                    //mappedData.lan = patientSettingDto.Languages;
                    mappedData.PatientId = null;
                    _context.Entry(oldEntity).CurrentValues.SetValues(mappedData);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    var mappedData = _mapper.Map<PatientPrintSetting>(patientSettingDto);
                    mappedData.PatientId = null;
                    _context.PatientPrintSetting.Add(mappedData);
                    _context.SaveChanges();
                    return true;
                }
            }
            return true;
        }

        public PatientPrintSettingDto getPatientPrintSettingsById(int userId)
        {
            var entity = _context.PatientPrintSetting.FirstOrDefault();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientPrintSettingDto>(entity);
                return mappedData;
            }
            else
            {
                var entityData = new PatientPrintSetting
                {
                    UserId = userId,
                    DOB = true,
                    Age = false,
                    Address = true,
                    Gender = true,
                    MobilePhone = true,
                    HomePhone = true,
                    EmergencyPhone = false,
                    CaseType = true,
                    ClaimNumber = true,
                    PolicyNumber = true,
                    FullClaimInfo = false,
                    DateCreated = true,
                    PrimaryDr = true,
                    FirstVisit = true,
                    LastVisit = true,
                    Vitals = true,
                    BodyStatus = true,
                    Tests = true,
                    Missing = true,
                    Paralegal = true,
                    CollectionAttorney = true,
                    ReferralName = true,
                    CurrentLocationInFacility = true,
                    LastIME = true,
                    NumberOfVisits = true,
                    RelatedPatientList = true,
                    AllVisits = true,
                    CarrierCaseNumber = false,
                    DOA = true,
                    EmployerInfo = true,
                    FIrstName = true,
                    FullInsuranceInfo = false,
                    FullPIAttorneyinfo = true,
                    languages = false,
                    LastEUO = true,
                    LastName = true,
                    MaritalStatus = true,
                    Nf2fillingDate = true,
                    PlaceTimeOfAccident = true,
                    PolicyHolderName = false,
                    Reminder = false,
                    SSNumber = true,
                    WCBNumber = false,
                    PatientId = userId
                };

                _context.PatientPrintSetting.Add(entityData);
                _context.SaveChanges();
                var mappedData = _mapper.Map<PatientPrintSettingDto>(entityData);
                return mappedData;
            }
        }
        #endregion


        #region For Patient List Settings
        public bool SavePatientListDispalySettings(PatientListSettingDto patientListSettingDto)
        {
            var entity = _context.PatientListDisplaySetting.FirstOrDefault();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientListDisplaySetting>(patientListSettingDto);
                mappedData.PatientListDisplayId = entity.PatientListDisplayId;
                _context.Entry(entity).CurrentValues.SetValues(mappedData);
                _context.SaveChanges();
                return true;
            }
            else
            {
                var mappedData = _mapper.Map<PatientListDisplaySetting>(patientListSettingDto);
                mappedData.PatientListDisplayId = entity.PatientListDisplayId;
                _context.Add(mappedData);
                _context.SaveChanges();
                return true;
            }
        }


        public PatientListSettingDto getPatientListSettingsById(int userId)
        {
            var entity = _context.PatientListDisplaySetting.FirstOrDefault();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientListSettingDto>(entity);
                return mappedData;
            }
            else
            {
                var entityData = new PatientListDisplaySetting
                {
                    PatientId = true,
                    Name = true,
                    HomePhone = true,
                    MobilePhone = true,
                    Address = true,
                    DOB = true,
                    Attorney = true,
                    Paralegal = true,
                    REFERRALNAME = true,
                    Dispatch = false,
                    AssignTransport = false,
                    Route = false,
                    BarcodeNumber = false,
                    Gender = false,
                    MartialStatus = false,
                    HighRisk = false,
                    Pregnent = false,
                    FirstName = false,
                    LastName = true

                };
                entityData.UserId = userId;
                _context.PatientListDisplaySetting.Add(entityData);
                _context.SaveChanges();
                var mappedData = _mapper.Map<PatientListSettingDto>(entityData);
                return mappedData;
            }
        }
        #endregion


        #region For Patient Require Field Settings i.e. for PatientInfo Form
        public bool SavePatientRequireSettings(PatientRequireFieldSettingDto patientRequireFieldSettingDto)
        {
            var entity = _context.PatientRequireFieldsSetting.FirstOrDefault();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientRequireFieldSettingDto>(patientRequireFieldSettingDto);
                mappedData.PatientRequiredFieldsId = entity.PatientRequiredFieldsId;
                _context.Entry(entity).CurrentValues.SetValues(mappedData);
                _context.SaveChanges();
                return true;
            }
            else
            {
                var mappedData = _mapper.Map<PatientRequireFieldsSetting>(patientRequireFieldSettingDto);
                mappedData.PatientRequiredFieldsId = entity.PatientRequiredFieldsId;
                _context.Add(mappedData);
                _context.SaveChanges();
                return true;
            }
        }

        public PatientRequireFieldSettingDto GetPatientRequireFieldSettingsById()
        {
            var entity = _context.PatientRequireFieldsSetting.FirstOrDefault();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<PatientRequireFieldSettingDto>(entity);
                return mappedData;
            }
            else
            {
                var entityData = new PatientRequireFieldsSetting
                {
                    FirstName = true,
                    LastName = true,
                    Gender = true,
                    DOB = true,
                    SSNumber = true,
                    MaritalStatus = true,
                    Address = true,
                    UserName = true,
                    Email = true,
                    Password = true,
                    ZipCode = true,
                    PatientColorStatus = false,
                    Languages = false,
                    EmployementStatus = false,
                    EmploymentTitle = false,
                    ReferralName = false,
                    PatientTreatmentStatus = false,
                    PatientLegalStatus = false,
                    PhoneNumber = true,
                    MobileNumber = true,
                    WorkNumber = false,
                    EmergencyNumber = false
                };
                //entityData.UserId = userId;
                _context.PatientRequireFieldsSetting.Add(entityData);
                _context.SaveChanges();
                var mappedData = _mapper.Map<PatientRequireFieldSettingDto>(entityData);
                return mappedData;
            }
        }
        #endregion

    }
}
