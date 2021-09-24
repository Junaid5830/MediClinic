using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.SubContractorInfoInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.SubContractorInfoService
{
	public class SubContractorInfoService : ISubContractorInfoService
	{
		private MediClinicContext _context;
		private IMapper _mapper;

		public SubContractorInfoService(MediClinicContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<List<SubContractorInfoDto>> subContractorInfo(int? userid)
		{

			using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
			{
				try
				{
					var result = await conn.QueryAsync<SubContractorInfoDto>(sql: "[sp_GetSubContractorList]", param: new { UserID = userid },
				 commandType: CommandType.StoredProcedure);
					return result.ToList();

				}
				catch(Exception ex)
				{
					throw ex;
				}
				
			}
		}

		public async Task<ResponseDto<SubContractorInfoDto>> subContractorInfoCreate(SubContractorInfoDto SubContractorInfoDto)
		{
			try
			{
				var mapped = _mapper.Map<SubContractorInfoDto, SubContractorInfo>(SubContractorInfoDto);
		
				var data = await _context.SubContractorInfo.AddAsync(mapped);
				_context.SaveChanges();
				var entity = _mapper.Map<SubContractorInfo, SubContractorInfoDto>(mapped);
				var response = new ResponseDto<SubContractorInfoDto>();
				response.Data = entity;
				return response;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<ResponseDto<bool>> subContractorInfoDeleteById(int Id)
		{
			var oldEntity = await _context.SubContractorInfo.FirstOrDefaultAsync(x => x.SubContractorId == Id);
			_context.Remove(oldEntity);
			_context.SaveChanges();
			var response = new ResponseDto<bool>();
			response.Data = true;
			return response;
		}

		public async Task<ResponseDto<SubContractorInfoDto>> subContractorInfoGetId(int Id)
		{
			var oldEntity = await _context.SubContractorInfo.Where(x=>x.SubContractorId==Id).FirstOrDefaultAsync();
			var mapped = _mapper.Map<SubContractorInfo, SubContractorInfoDto>(oldEntity);
			var response = new ResponseDto<SubContractorInfoDto>();
			response.Data = mapped;
			return response;
		}

		public SubContractorInfo GetSubContractorUserId(long Id)
		{
			SubContractorInfo data = _context.SubContractorInfo.Where(x => x.SubContractorId == Id).FirstOrDefault();
			return data;
		}
		public async Task<ResponseDto<SubContractorInfoDto>> subContractorInfoGetLastAdded()
		{
			var oldEntity = await _context.SubContractorInfo.OrderByDescending(x => x.SubContractorId).FirstOrDefaultAsync();
			var mapped = _mapper.Map<SubContractorInfo, SubContractorInfoDto>(oldEntity);
			var response = new ResponseDto<SubContractorInfoDto>();
			response.Data = mapped;
			return response;
		}

		public async Task<ResponseDto<bool>> subContractorInfoUpdate(SubContractorInfoDto SubContractorInfoDto)
		{
			try
			{
				var mapped = _mapper.Map<SubContractorInfoDto, SubContractorInfo>(SubContractorInfoDto);
				var oldEntity = await _context.SubContractorInfo.FindAsync(mapped.SubContractorId);
			
				_context.Entry(oldEntity).CurrentValues.SetValues(mapped);
				await _context.SaveChangesAsync();
				var response = new ResponseDto<bool>();
				response.Data = true;
				return response;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<ResponseDto<bool>> CheckEmailExistOrNot(string email, long? userId)
		{
			bool isExist = false;
			if (userId == null)
			{
				var record = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
				if (!(record is null))
				{
					isExist = true;
				}
			}
			else
			{
				var record = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
				if (!(record is null))
				{
					if (record.UserId != userId)
					{
						isExist = true;
					}
				}
			}

			return new ResponseDto<bool>()
			{
				Data = isExist,
				Message = "Email is already exist"
			};
		}


		//public async Task<List<SubContractorInfoDto>> GetProviderList()
		//{
		//	using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
		//	{
		//		var result = await conn.QueryAsync<SubContractorInfoDto>(sql: "[spGetProviderList]",
		//		commandType: CommandType.StoredProcedure);

		//		return result.ToList();
		//	}
		//}
	}
}
