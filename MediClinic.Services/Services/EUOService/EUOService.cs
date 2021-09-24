using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.EUOInterface;
using MediClinic.Services.Interfaces.SessionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedliClinic.Utilities.Utility;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Dapper;

namespace MediClinic.Services.Services.EUOService
{
    public class EUOService : IEUOService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public EUOService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;

        }
        public async Task<bool> Add(EUODto euoDto)
        {

            var mapped = _mapper.Map<EUODto, EUO>(euoDto);
            await _context.EUO.AddAsync(mapped);

            if (euoDto.EUOId == 0)
            {
                mapped.VisitId = _sessionManager.GetVisitId();
                mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                euoDto.CreatedBy = mapped.CreatedBy;
                mapped.CreatedDate = DateTime.UtcNow;
                euoDto.CreatedDate = mapped.CreatedDate;
                await _context.EUO.AddAsync(mapped);
            }

            else
            {
                mapped.ModifiedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.ModifiedDate = DateTime.UtcNow;
                _context.EUO.Update(mapped);
            }
            _context.SaveChanges();
            return false;

        }
        public bool Delete(int EUOId)
        {
            EUO euo = _context.EUO.Where(a => a.EUOId == EUOId).FirstOrDefault();
            if (euo != null)
            {
                _context.EUO.Remove(euo);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public EUODto GetEUOById(int EUOId)
        {
            EUO EUO = _context.EUO.Where(a => a.EUOId == EUOId).FirstOrDefault();
            EUODto EUODto = _mapper.Map<EUO, EUODto>(EUO);
            return EUODto;
        }
        public List<EUODto> GetEUO()
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = conn.Query<EUODto>(sql: "[spGetEUO]",
                commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<EUODto>> GetEUOByPatientId(long? Id)
        {
            var joinData = await(from A in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                 join V in _context.Visits
                                 on A.AppointmentId equals V.AppoinmentId

                                 join E in _context.EUO
                                 on V.VisitId equals E.VisitId

                                 join P in _context.Lookups
                                 on E.Place equals P.LookupId


                                 join r in _context.Lookups
                                 on E.RepresentedBy equals r.LookupId

                                 join s in _context.Lookups
                                 on E.Status equals s.LookupId

                                 join re in _context.Lookups
                                on E.Reason equals re.LookupId

                                 join t in _context.Lookups
                                 on E.Transcripts equals t.LookupId

                                 select new EUODto
                                 {
                                   
                                     EUOId=E.EUOId,
                                     VisitId=E.VisitId,
                                     Date=E.Date,
                                     Time=E.Time,
                                     PlaceEUO = P.LookupValue,
                                     StatusEUO = s.LookupValue,
                                     RepresentedByEUO = r.LookupValue,
                                     ReasonEUO= r.LookupValue,
                                     TranscriptsEUO=t.LookupValue

                                 }).ToListAsync();

            return joinData;
        }
    }
}
