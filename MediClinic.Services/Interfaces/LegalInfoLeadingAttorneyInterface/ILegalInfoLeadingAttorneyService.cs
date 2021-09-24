using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.LegalInfoLeadingAttorneyDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.LegalInfoLeadingAttorney
{
	public interface ILegalInfoLeadingAttorneyService
	{
		public Task<ResponseDto<int>> LegalInfoAttorneyName(LegalInfoLeadingAttorneyBasicDto legalInfoLeadingAttorneyBasicDto);

		public Task<ResponseDto<bool>> LegalInfoAttorneyNameUpdte(LegalInfoLeadingAttorneyBasicDto legalInfoLeadingAttorneyBasicDto);
		public Task<ResponseDto<List<LegalInfoLeadingAttorneyBasicDto>>> LegalInfoAttorneyNameList();

		public Task<ResponseDto<LegalInfoLeadingAttorneyBasicDto>> LegalInfoFAttorneyNameId(int Id);

		public Task<ResponseDto<bool>> isExistorNot(string Name);
	}
}
