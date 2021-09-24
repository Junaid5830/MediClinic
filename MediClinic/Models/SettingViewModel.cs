using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.Nf2StatusDto;
using MediClinic.Models.DTOs.PatientLegalStatusDto;
using MediClinic.Models.DTOs.PatientRelationshipDto;
using MediClinic.Models.DTOs.PatientSettingsDto;
using MediClinic.Models.DTOs.PatientTreatmentStatusDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class SettingViewModel
    {
        public PatientTreatmentStatusBasicDto PatientTreatmentStatus { get; set; }
        public List<PatientTreatmentStatusBasicDto> PatientTreatmentStatusList { get; set; }
        public PatientLegalStatusBasicDto PatientLegalStatus { get; set; }
        public List<PatientLegalStatusBasicDto> PatientLegalStatusList { get; set; }
        public Nf2StatusBasicDto NF2Status { get; set; }
        public List<Nf2StatusBasicDto> NF2StatusList { get; set; }
        public PatientRelationshipBasicDto PatientRelationship { get; set; }
        public List<PatientRelationshipBasicDto> PatientRelationshipList { get; set; }
        public PatientSettingDto PatientSettingDto { get; set; }
        public PatientPrintSettingDto PatientPrintSettingDto { get; set; }
        public PatientListSettingDto PatientListSettingDto { get; set; }
        public PatientRequireFieldSettingDto  PatientRequireFieldSettingDto { get; set; }

        public ProviderListSettingDto  ProviderListSettingDto { get; set; }

        public CalendarSettingDto calendarSettingDto { get; set; }
        public List<CalendarSettingDto> calendarSettinglist { get; set; }
        public SettingAttorneyDto SettingAttorneyDto { get; set; }
    }
}
