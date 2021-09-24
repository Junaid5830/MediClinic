using MediClinic.Models.DTOs.PatientSettingsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Services.Interfaces.PatientSettings
{
    public interface IPatientSettings
    {
        public bool SavePatientSummaryDisplaySettings(PatientSettingDto patientSettingDto);
        public PatientSettingDto getPatientSettingsById(int patientId);
        public bool SavePatientPrintSettings(PatientPrintSettingDto patientSettingDto);
        public PatientPrintSettingDto getPatientPrintSettingsById(int patientId);
        public bool SavePatientListDispalySettings(PatientListSettingDto patientListSettingDto);
        public PatientListSettingDto getPatientListSettingsById(int providerId);
        //public PatientRequireFieldSettingDto GetPatientRequireFieldSettingsById(int userId);
        public PatientRequireFieldSettingDto GetPatientRequireFieldSettingsById();
        public bool SavePatientRequireSettings(PatientRequireFieldSettingDto patientRequireFieldSettingDto);
    }
}
