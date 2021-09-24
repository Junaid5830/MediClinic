using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.CPTCodesInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.CPTCodesService
{
    public class CPTCodesService : ICPTCodesService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public CPTCodesService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public ResponseDto<List<CPTCodesDto>> CPTByIdDto(long id)
        {
            var rec = _context.CPTCodes.Where(x => x.CPTCodeId == id).ToList();
            var response = new ResponseDto<List<CPTCodesDto>>();
            response.Data = _mapper.Map<List<CPTCodes>, List<CPTCodesDto>>(rec);
            return response;
        }
        public async Task<List<CPTCodesDto>> GetAllCPTCodes()
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<CPTCodesDto>(sql: "[GetAllCPTCodes]",
                commandType: CommandType.StoredProcedure);
                var response = result.ToList();
                if (response.Any())
                {
                    return result.ToList();
                }
                else
                {
                    return new List<CPTCodesDto>();
                }
            }
        }

        public List<CPTCodesDto> cptCodesDtoList(long id, string name)
        {
            //using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            //{
            //    var result = await conn.QueryAsync<CPTCodesDto>(sql: "[GetAllCPTCodes]",
            //    commandType: CommandType.StoredProcedure);
            //    var response = result.ToList();
            //    if (response.Any())
            //    {
            //        return result.ToList();
            //    }
            //    else
            //    {
            //        return new List<CPTCodesDto>();
            //    }
            //}
            dynamic rec = null;
            if (name != null)
            {
                rec = _context.CPTCodes.Where(x => x.CPTCodeId == id && x.Name.Contains(name)).ToList();
            }
            else
            {
                rec = _context.CPTCodes.Where(x => x.CPTCodeId == id).ToList();
            }
            return rec;

        }

        public async Task<ResponseDto<List<CPTCodesDto>>> CPTCodesDtolist(long id)
        {
            var rec = await _context.CPTCodes.Where(x => x.CPTCodeId == id).ToListAsync();
            var response = new ResponseDto<List<CPTCodesDto>>();
            response.Data = _mapper.Map<List<CPTCodes>, List<CPTCodesDto>>(rec);
            return response;
        }

}
}
