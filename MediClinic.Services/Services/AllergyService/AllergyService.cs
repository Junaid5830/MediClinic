using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.AllergyInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.AllergyService
{
	public class AllergyService : IAllergyService
	{
		private MediClinicContext _context;
		private IMapper _mapper;

		public AllergyService(MediClinicContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<ResponseDto<AllergyTypeDto>> allergyTypeCreate(AllergyTypeDto allergyTypeDto)
		{
			try
			{
				var mapped = _mapper.Map<AllergyTypeDto, AllergyTypes>(allergyTypeDto);

				var data = await _context.AllergyTypes.AddAsync(mapped);
				_context.SaveChanges();
				var entity = _mapper.Map<AllergyTypes, AllergyTypeDto>(mapped);
				var response = new ResponseDto<AllergyTypeDto>();
				response.Data = entity;
				return response;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<ResponseDto<AllergyDto>> allergyCreate(AllergyDto allergyDto)
		{
			try
			{
				var mapped = _mapper.Map<AllergyDto, Allergies>(allergyDto);

				var data = await _context.Allergies.AddAsync(mapped);
				_context.SaveChanges();
				var entity = _mapper.Map<Allergies, AllergyDto>(mapped);
				var response = new ResponseDto<AllergyDto>();
				response.Data = entity;
				return response;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<List<AllergyTypeDto>> GetAllergyTypeList()
		{
			List<AllergyTypes> AllergyTypeList = _context.AllergyTypes.ToList();
			List<AllergyTypeDto> AllergyTypeDtoList = _mapper.Map<List<AllergyTypes>, List<AllergyTypeDto>>(AllergyTypeList);
			return AllergyTypeDtoList;
		}

		public async Task<List<AllergyDto>> GetAllergyList()
		{
			List<Allergies> AllergyList =  _context.Allergies.ToList();
			List<AllergyDto> AllergyDtoList = _mapper.Map<List<Allergies>, List<AllergyDto>>(AllergyList);
			return AllergyDtoList;
		}

		public async Task<ResponseDto<bool>> DeleteAllergy(int Id)
		{
			var oldEntity = await _context.Allergies.FirstOrDefaultAsync(x => x.AllergyId == Id);
			_context.Remove(oldEntity);
			_context.SaveChanges();
			var response = new ResponseDto<bool>();
			response.Data = true;
			return response;
		}

        public async Task<List<AllergyTypeDto>> GetAllergyTypeListForVIsit(int Id)
        {
			List<AllergyTypes> AllergyTypeList = _context.AllergyTypes.Where(x=>x.VisitId == Id).ToList();
			List<AllergyTypeDto> AllergyTypeDtoList = _mapper.Map<List<AllergyTypes>, List<AllergyTypeDto>>(AllergyTypeList);
			return AllergyTypeDtoList;
		}

        public async Task<List<AllergyTypeDto>> AllergyListByVisits(long Id)
        {
			var joinData = await (from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
								  join V in _context.Visits
								  on P.AppointmentId equals V.AppoinmentId

								  join AT in _context.AllergyTypes
								  on V.VisitId equals AT.VisitId

								  join A in _context.Allergies
								  on AT.AllergyTypeId equals A.AllergyTypeId into g
								  from A in g.DefaultIfEmpty()

								  select new AllergyTypeDto
								  {
									  AllergyTypeId = AT.AllergyTypeId,
									  Name = AT.Name,
									  allergies = new List<Allergies>() { new Allergies { Name = A.Name, AllergyTypeId = A.AllergyTypeId ,AllergyId = A.AllergyId} }
								  }).ToListAsync();

			return joinData;
		}
    }
}
