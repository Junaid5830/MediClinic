using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.LookupDto;
using MediClinic.Models.DTOs.UsersDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
	public class SubContractorViewModel
	{
		public SubContractorInfoDto SubContractor { get; set; }
		public UsersBasicDto User { get; set; }
		public List<SubContractorInfoDto> SubContractorList { get; set; }
		//public SubContractorListSettingDto SubContractorListSettingDto { get; set; }


		[Required]
		[Display(Name = "Password")]
		[RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]
		public string Password { get; set; }

		[Required]
		[Display(Name = "Confirm Password")]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }

		public List<LookupBasicDto> SubContractorTitleList { get; set; }
		public List<LookupBasicDto> SubContractorSuffixList { get; set; }
		public List<LookupBasicDto> SubContractorRentTypeList { get; set; }
		public List<LookupBasicDto> SubContractorStatusList { get; set; }
		public List<LookupBasicDto> SubContractorSpecialityList { get; set; }
		public List<LookupBasicDto> SubContractorScannedDocumentsList { get; set; }
	}
}
