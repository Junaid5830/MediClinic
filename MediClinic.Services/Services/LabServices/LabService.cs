using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.LabInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.LabServices
{
    public class LabService : ILabService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;
        public LabService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public bool Add(LabDto labDto)
        {
            var mapped = _mapper.Map<Lab>(labDto);
            if (labDto.LabId == 0)
            {
                MediClinicContext context = new MediClinicContext();
                mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.CreatedDate = DateTime.UtcNow;
                context.Lab.Add(mapped);
                context.SaveChangesAsync();
            }
            else
            {
                var oldEntity = _context.Lab.FirstOrDefault(x => x.LabId == labDto.LabId);
                oldEntity.DateTime = labDto.DateTime;
                oldEntity.ReasonForExam = labDto.ReasonForExam;
                oldEntity.Examiner = labDto.Examiner;
                oldEntity.Results = labDto.Results;
                oldEntity.Report = labDto.Report;
                mapped.UpdateBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.UpdatedDate = DateTime.UtcNow;
                _context.SaveChanges();
            }
            return true;
        }
        public LabDto GetLabById(int labId)
        {
            var id = _context.Lab.Where(a => a.LabId == labId).FirstOrDefault();
            var mapped = _mapper.Map<Lab, LabDto>(id);
            return mapped;
        }
        public async Task<List<LabDto>> GetLabList()
        {

            var list = await _context.Lab.Where( x => x.VisitId != null).ToListAsync();
            var mapped = _mapper.Map<List<Lab>, List<LabDto>>(list);
            return mapped;
        }
        public bool Delete(int Labid)
        {
            var labid = _context.Lab.Where(a => a.LabId == Labid).FirstOrDefault();
            _context.Lab.Remove(labid);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<LabDto>> GetLabListByVisitId(int Id)
        {
            var list = await _context.Lab.Where(x => x.VisitId == Id).ToListAsync();
            var mapped = _mapper.Map<List<Lab>, List<LabDto>>(list);
            return mapped;
        }

        public async Task<List<LabDto>> GetLabVisitList(int Id)
        {
            var list = await _context.Lab.Where(x => x.VisitId == Id).ToListAsync();
            var mapped = _mapper.Map<List<Lab>, List<LabDto>>(list);
            return mapped;
        }

        public async Task<List<LabDto>> GetLabListByVisits(long Id)
        {
            var joinData = await (from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                  join V in _context.Visits
                                  on P.AppointmentId equals V.AppoinmentId



                                  join L in _context.Lab
                                  on V.VisitId equals L.VisitId



                                  select new LabDto
                                  {
                                     LabId = L.LabId,
                                     VisitId = L.VisitId,
                                      DateTime = L.DateTime,
                                      Examiner = L.Examiner,
                                      TypeOfExam = L.TypeOfExam,
                                      ReasonForExam=L.ReasonForExam,
                                      Results = L.Results,
                                      Report = L.Report
                                  }).ToListAsync();

            return joinData;
        }


    }
}
