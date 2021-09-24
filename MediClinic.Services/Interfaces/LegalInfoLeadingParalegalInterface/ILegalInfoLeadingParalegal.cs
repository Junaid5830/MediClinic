using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.LegalInfoLeadingParalegalDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.LegalInfoLeadingParalegalInterface
{
	public interface ILegalInfoLeadingParalegal
	{
		public Task<ResponseDto<int>> LeadingParaLegalName(LegalInfoLeadingParalegalBasicDto legalInfoLeadingParalegalBasicDto);

		public Task<ResponseDto<bool>> LeadingParaLegalNameUpdte(LegalInfoLeadingParalegalBasicDto legalInfoLeadingParalegalBasicDto);
		public Task<ResponseDto<List<LegalInfoLeadingParalegalBasicDto>>> LeadingParaLegalNameList();

		public Task<ResponseDto<LegalInfoLeadingParalegalBasicDto>> LeadingParaLegalNameId(int Id);

		public Task<ResponseDto<bool>> isExistorNot(string Name);
	}
}
