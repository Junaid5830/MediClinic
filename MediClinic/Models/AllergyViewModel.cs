using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.UsersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
	public class AllergyViewModel
	{
		public AllergyDto Allergy { get; set; }
		public AllergyTypeDto AlergyType { get; set; }
		public UsersBasicDto User { get; set; }
		public List<AllergyDto> AlergyList { get; set; }
		public List<AllergyTypeDto> AlergyTypeList { get; set; }
		public AllergiesDto Allergies { get; set; }
	}
}
