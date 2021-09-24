using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.LegalInfoLeadingAttorneyDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.LegalInfoLeadingAttorney;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.LegalInfoLeadingAttorneyService
{
 public	class LegalInfoLeadingAttorneyService:ILegalInfoLeadingAttorneyService
	{
		private MediClinicContext _context;
		private IMapper _mapper;
		public LegalInfoLeadingAttorneyService(MediClinicContext context,IMapper mapper)
		{
			_context = context;
			_mapper = mapper;

		}
		public async Task<ResponseDto<int>> LegalInfoAttorneyName(LegalInfoLeadingAttorneyBasicDto legalInfoLeadingAttorneyBasicDto) 
		{
			if (!(legalInfoLeadingAttorneyBasicDto.LeadingAttorneyName is null))
			{
				legalInfoLeadingAttorneyBasicDto.LeadingAttorneyName = legalInfoLeadingAttorneyBasicDto.LeadingAttorneyName.Trim();
			}
			var mapped = _mapper.Map<LegalInfoLeadingAttorneyBasicDto, LegalInfoLeadingAttorney>(legalInfoLeadingAttorneyBasicDto);
			var data = await _context.LegalInfoLeadingAttorney.AddAsync(mapped);
			_context.SaveChanges();
			
			var response = new ResponseDto<int>();
			response.Data = mapped.LeadingAttorneyId;
			return response;
		}
		public Task<ResponseDto<bool>> LegalInfoAttorneyNameUpdte(LegalInfoLeadingAttorneyBasicDto legalInfoLeadingAttorneyBasicDto)
		{ 

			throw new NotImplementedException();
		}
		public async Task<ResponseDto<List<LegalInfoLeadingAttorneyBasicDto>>> LegalInfoAttorneyNameList()
		{
			var rec = await _context.LegalInfoLeadingAttorney.ToListAsync();
			var response = new ResponseDto<List<LegalInfoLeadingAttorneyBasicDto>>();
			response.Data = _mapper.Map<List<LegalInfoLeadingAttorney>, List<LegalInfoLeadingAttorneyBasicDto>>(rec);
			return response;
		}
		public Task<ResponseDto<LegalInfoLeadingAttorneyBasicDto>> LegalInfoFAttorneyNameId(int Id)
		{

			throw new NotImplementedException();
		}

		public async Task<ResponseDto<bool>> isExistorNot(string Name)
		{
			var isExist = false;
			var Value = await _context.LegalInfoLeadingAttorney.Where(x => x.LeadingAttorneyName.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
			if (!(Value is null))
			{
				isExist = true;
			}
			var response = new ResponseDto<bool>();
			response.Data = isExist;
			return response;
		}
	}
}
