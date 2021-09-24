using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.DoctorsInfoInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.DoctorsInfoService
{
    public class DoctorsInfoService : IDoctorsInfoService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public DoctorsInfoService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DoctorsInfoDto>> GetAllDoctorsInfoNames()
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<DoctorsInfoDto>(sql: "[GetAllDoctorsNames]",
                commandType: CommandType.StoredProcedure);
                var response = result.ToList();
                if (response.Any())
                {
                    return result.ToList();
                }
                else
                {
                    return new List<DoctorsInfoDto>();
                }
            }
        }
    }
}
