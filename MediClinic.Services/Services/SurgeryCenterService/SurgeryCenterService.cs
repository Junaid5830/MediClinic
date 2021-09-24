using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.SurgeryCenterInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.SurgeryCenterService
{
    public class SurgeryCenterService : ISurgeryCenterService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public SurgeryCenterService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;

        }
        public async Task<bool> Add(SurgeryCenterDto surgeryCenterDto)
        {

            var mapped = _mapper.Map<SurgeryCenterDto, SurgeryCenter>(surgeryCenterDto);
          
            if (surgeryCenterDto.SurgeryCenterId == 0)
            {
                mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                surgeryCenterDto.CreatedBy = mapped.CreatedBy;
                mapped.CreatedDate = DateTime.UtcNow;
                surgeryCenterDto.CreatedDate = mapped.CreatedDate;
                await _context.SurgeryCenter.AddAsync(mapped);
            }

            else
            {
                mapped.ModifiedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.ModifiedDate = DateTime.UtcNow;
                _context.SurgeryCenter.Update(mapped);
            }
            _context.SaveChanges();
            return false;

        }
        public bool Delete(int SurgeryCenterId)
        {
            SurgeryCenter surgeryCenter = _context.SurgeryCenter.Where(a => a.SurgeryCenterId == SurgeryCenterId).FirstOrDefault();
            if (surgeryCenter != null)
            {
                _context.SurgeryCenter.Remove(surgeryCenter);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public SurgeryCenterDto GetSurgeryCenterById(int SurgeryCenterId)
        {
            SurgeryCenter SurgeryCenter = _context.SurgeryCenter.Where(a => a.SurgeryCenterId == SurgeryCenterId).FirstOrDefault();
            SurgeryCenterDto SurgeryCenterDto = _mapper.Map<SurgeryCenter, SurgeryCenterDto>(SurgeryCenter);
            return SurgeryCenterDto;
        }
        public List<SurgeryCenterDto> GetSurgeryCenter()
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = conn.Query<SurgeryCenterDto>(sql: "[spGetSurgeryCenters]",
                commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            //List<SurgeryCenter> SurgeryCenterList = _context.SurgeryCenter.ToList();
            //List<SurgeryCenterDto> SurgeryCenterDtoList = _mapper.Map<List<SurgeryCenter>, List<SurgeryCenterDto>>(SurgeryCenterList);
            //return SurgeryCenterDtoList;
        }

        public List<SurgeryCenterDto> GetSurgeryCenterWithProImag()
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = conn.Query<SurgeryCenterDto>(sql: "[_spGetSurgeryCenterList]",
                commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
