using AutoMapper;
using MediClinic.Models.DTOs.AddNewCaseTypeDto;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.AddNewCaseTypeInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.AddNewCaseTypeService
{
	public class AddNewCaseTypeService:IAddNewCaseTypeService
	{
		private MediClinicContext _context;
		private IMapper _mapper;
		public AddNewCaseTypeService(MediClinicContext context, IMapper mapper) 
		{
			_context = context;
			_mapper = mapper;
		} 
		public async Task<ResponseDto<bool>> AddNewCaseType(AddNewCaseTypeBasicDto addNewCaseTypeBasicDto) 
		{
			var result = false;
			var mapped = _mapper.Map<AddNewCaseTypeBasicDto, PatientNewCaseType>(addNewCaseTypeBasicDto);
			var data = await _context.PatientNewCaseType.AddAsync(mapped);
			_context.SaveChanges();
			if(!(data is null)) 
			{
				result = true;
			}
			var response = new ResponseDto<bool>();
			response.Data = result;
			return response;
		}
		public async Task<ResponseDto<List<AddNewCaseTypeBasicDto>>> NewCaseList() 
		{
			var rec = await _context.PatientNewCaseType.ToListAsync();
			var response = new ResponseDto<List<AddNewCaseTypeBasicDto>>();
			response.Data = _mapper.Map<List<PatientNewCaseType>, List<AddNewCaseTypeBasicDto>>(rec);
			return response;
		}




	}
}
