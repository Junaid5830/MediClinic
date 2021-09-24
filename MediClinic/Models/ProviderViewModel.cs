using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.EmailDto;
using MediClinic.Models.DTOs.LookupDto;
using MediClinic.Models.DTOs.PatientAppointmentsDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.DTOs.PatientSettingsDto;
using MediClinic.Models.DTOs.ProviderBasicSummaryDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Models.DTOs.ProviderSpecialityDto;
using MediClinic.Models.DTOs.ProviderTemplateDto;
using MediClinic.Models.DTOs.ProviderTermDto;
using MediClinic.Models.DTOs.ProviderUidTypeDto;
using MediClinic.Models.DTOs.RelatedFacilityDto;
using MediClinic.Models.DTOs.SMSDto;
using MediClinic.Models.DTOs.SubProviderDto;
using MediClinic.Models.DTOs.TemplateDto;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Models.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class ProviderViewModel
    {
        public ProviderViewModel()
        {
            PatientSettingDto = new PatientSettingDto();
            ProviderPrintSettingDto = new PatientPrintSettingDto();
        }
        public ProviderInfoBasicDto Provider { get; set; }
        public ProviderDetails ProviderDetails { get; set; }
        public ProviderSummaryDto ProviderSummary { get; set; }
        public SubProviderBasicDto SubProvider { get; set; }
        public ProviderSpecialityBasicDto ProviderSpeciality { get; set; }
        public ProviderTermBasicDto ProviderTerm { get; set; }
        public ProviderUidTypeBasicDto ProviderUidType { get; set; }
        public List<ProviderSpecialityBasicDto> ProviderSpecialityDetail { get; set; }
        public List<ProviderTermBasicDto> ProviderTermDetail { get; set; }
        public List<ProviderUidTypeBasicDto> ProviderUidTypeDetail { get; set; }
        public List<SubProviderBasicDto> SubProviderList { get; set; }
        public List<ProviderInfoBasicDto> ProviderList { get; set; }
        public ProviderJsonConversionClass ProviderJsonConverted { get; set; }
        public UsersBasicDto User { get; set; }
        public EmailBasicDto EmailBasicDto { get; set; }
        public SmsDto SmsDto { get; set; }
        public PrescriptionTemplateDto PrescriptionTemplateDto { get; set; }
        public PatientPrintSettingDto ProviderPrintSettingDto { get; set; }
        public List<PrescriptionTemplateDto> PrescriptionTemplateList { get; set; }
        public TemplateBasicDto TemplateBasicDto { get; set; }
        public LookupBasicDto lookupBasicDto { get; set; }
        public List<TemplateBasicDto> TemplateBasicList { get; set; }
        public IEnumerable<SelectListItem> MedicineList { set; get; }
        public PatientAppointmentBasicDto patientAppointmentBasicDto { get; set; }
        public List<PatientAppointmentBasicDto> patientAppointmentBasicsList { get; set; }
        public List<PatientInfoBasicDto> ProviderPatientsLists { get; set; }
        public List<PatientAppointmentBasicDto> BookedAppointment { get; set; }
        public string SelectedData { get; set; }

        [Required(ErrorMessage ="Password is required.")]
        [Display(Name = "Password")]
        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirmation password is required.")]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public ProviderTemplateBasicDto ProviderTemplate { get; set; }
        public List<ProviderTemplateBasicDto> ProviderTemplateList { get; set; }
        public string Success { get; set; }

        public RelatedFacilityBasicDto RelatedFacilitiy { get; set; }
        public List<RelatedFacilityBasicDto> RelatedFacilitiyList { get; set; }

        public List<ProviderSpecialityBasicDto> ProviderSpecialityList { get; set; }
        public List<LookupBasicDto> ProviderTitleList { get; set; }
        public List<LookupBasicDto> ProviderSuffixList { get; set; }
        public List<LookupBasicDto> ProviderRentTypeList { get; set; }

        public List<LookupBasicDto> ProviderScannedDocumentsList { get; set; }
        public List<RelatedFacilityBasicDto> ProviderRelatedFacilityList { get; set; }
        public List<ProviderUIDTypes> ProviderUidTypeList { get; set; }
        public List<ProviderTermBasicDto> ProviderTermList { get; set; }
        public List<LookupBasicDto> ProviderStatusList { get; set; }
        public string[] PermissionArray { get; set; }
        public ProviderListSettingDto ProviderListSettingDto { get; set; }
        public ProviderSummarySettingsDto ProviderSummarySettingDto { get; set; }
        public PrescriptionTemplateDto medicationsTemplate { get; set; }
        public PatientSettingDto PatientSettingDto { get; set; }

        public List<ProviderSessions> ProviderSessions { get; set; }

        public List<ProviderSessionTypeDto> ProviderSessionTypeList { get; set; }
        public List<ProviderSlotsDto> SlotsList { get; set; }
        public PatientPrintSettingDto PatientPrintSettingDto { get; set; }

        public List<ProviderWorkHrsDto> ScheduleList { get; set; }
        [Required(ErrorMessage = "Start Date is required")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public string EndDate { get; set; }
    }
}
