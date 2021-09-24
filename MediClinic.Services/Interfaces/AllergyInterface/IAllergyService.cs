using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.AllergyInterface
{
	public interface IAllergyService
	{
		public Task<ResponseDto<AllergyTypeDto>> allergyTypeCreate(AllergyTypeDto allergyTypeDto);
		public Task<ResponseDto<AllergyDto>> allergyCreate(AllergyDto allergyDto);
		public Task<List<AllergyTypeDto>> AllergyListByVisits(long Id);
		public Task<List<AllergyTypeDto>> GetAllergyTypeList();
		public Task<List<AllergyTypeDto>> GetAllergyTypeListForVIsit(int Id);

		public Task<List<AllergyDto>> GetAllergyList();

		public Task<ResponseDto<bool>> DeleteAllergy(int Id);
	}
}
