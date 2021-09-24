using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.LegalInfoLeadingParalegalDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.LegalInfoLeadingParalegalInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.LegalInfoLeadingParalegalService
{
	public class LegalInfoLeadingParalegalService : ILegalInfoLeadingParalegal
	{
		private MediClinicContext _context;
		private IMapper _mapper;

		public LegalInfoLeadingParalegalService(MediClinicContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<ResponseDto<bool>> isExistorNot(string Name)
		{
			var isExist = false;
			var Value = await _context.LegalInfoLeadingParalegal.Where(x => x.LeadingParalegalName.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
			if (!(Value is null))
			{
				isExist = true;
			}
			var response = new ResponseDto<bool>();
			response.Data = isExist;
			return response;
		}

		public async Task<ResponseDto<int>> LeadingParaLegalName(LegalInfoLeadingParalegalBasicDto legalInfoLeadingParalegalBasicDto)
		{
			if (!(legalInfoLeadingParalegalBasicDto.LeadingParalegalName is null))
			{
				legalInfoLeadingParalegalBasicDto.LeadingParalegalName = legalInfoLeadingParalegalBasicDto.LeadingParalegalName.Trim();
			}
			var mapped = _mapper.Map<LegalInfoLeadingParalegalBasicDto, LegalInfoLeadingParalegal>(legalInfoLeadingParalegalBasicDto);
			var data = await _context.LegalInfoLeadingParalegal.AddAsync(mapped);
			_context.SaveChanges();
			
			var response = new ResponseDto<int>();
			response.Data = mapped.LeadingParalegalId;
			return response;
		}

		public Task<ResponseDto<LegalInfoLeadingParalegalBasicDto>> LeadingParaLegalNameId(int Id)
		{
			throw new NotImplementedException();
		}

		public async Task<ResponseDto<List<LegalInfoLeadingParalegalBasicDto>>> LeadingParaLegalNameList()
		{
			var rec = await _context.LegalInfoLeadingParalegal.ToListAsync();
			var response = new ResponseDto<List<LegalInfoLeadingParalegalBasicDto>>();
			response.Data = _mapper.Map<List<LegalInfoLeadingParalegal>, List<LegalInfoLeadingParalegalBasicDto>>(rec);
			return response;
		}

		public Task<ResponseDto<bool>> LeadingParaLegalNameUpdte(LegalInfoLeadingParalegalBasicDto legalInfoLeadingParalegalBasicDto)
		{
			throw new NotImplementedException();
		}
	}
}
