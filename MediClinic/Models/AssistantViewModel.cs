using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.LookupDto;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Models.EntityModels;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class AssistantViewModel
    {
        public AssistantViewModel()
        {
            Assistant = new AssistantInfoDto();
        }

        public AssistantSettingDto assistantSettingDto { get; set; }
        public AssistantInfoDto Assistant { get; set;}
        public List<AssistantWorkingScheduleDto> WorkingSchedule { get; set; }
        public List<AssistantInfoDto> AssistantList { get; set; }
        public AssistantWorkingScheduleDto AssistantSchedule { get; set; }
        public List<DoctorsInfoDto> Doctor { get; set; }
        public List<DepartmentDto> Department { get; set; }
        public List<LookupBasicDto> AssistantTitleList { get; set; }
        public List<LookupBasicDto> AssistantSuffixList { get; set; }
        public List<LookupBasicDto> AssistantRentTypeList { get; set; }
        public List<LookupBasicDto> AssistantScannedDocumentsList { get; set; }
        public List<LookupBasicDto> AssistantSpeciality { get; set; }
        public List<LookupBasicDto> AssistantStatuslist { get; set; }
        public UsersBasicDto User { get; set; }
        [Required]
        [Display(Name = "Password")]
        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
