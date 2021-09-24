using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ICDCodesInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.ICDCodesService
{
    public class ICDCodesService : IICDCodesService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public ICDCodesService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ICDCodesDto>> GetAllICDCodes(bool withDetail)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ICDCodesDto>(sql: "[GetAllICDCodes]",
                param: new { withDescription = withDetail },
                commandType: CommandType.StoredProcedure);

                var response = result.ToList();
                if (response.Any())
                {
                    return result.ToList();
                }
                else
                {
                    return new List<ICDCodesDto>();
                }

            }
        }
    }
}
