using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.IMEInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.IMEService
{
    public class imeService : IimeInterface
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public imeService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;

        }

        public async Task<bool> Add(ImeDto ImeDto)
        {
            var mapped = _mapper.Map<IME>(ImeDto);
            if (ImeDto.ID == 0)
            {
                MediClinicContext context = new MediClinicContext();
                mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.CreatedDate = DateTime.UtcNow;
                context.IME.Add(mapped);

                await context.SaveChangesAsync();
            }
            else
            {
                var oldEntity = _context.IME.FirstOrDefault(x => x.ID == ImeDto.ID);
                oldEntity.ID = ImeDto.ID;
                oldEntity.Date = ImeDto.Date;
                oldEntity.Time = ImeDto.Time;
                oldEntity.IME_Place = ImeDto.IME_Place;
                oldEntity.IME_Status = ImeDto.IME_Status;
                oldEntity.Reason = ImeDto.Reason;
                oldEntity.Represented_By = ImeDto.Represented_By;
                mapped.ModifiedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.ModifiedDate = DateTime.UtcNow;
                _context.SaveChanges();
            }
            return true;
        }

        public bool Delete(int imeId)
        {
            var imgId = _context.IME.Where(a => a.ID == imeId).FirstOrDefault();
            _context.IME.Remove(imgId);
            _context.SaveChanges();
            return true;
        }

        public ImeDto GetIMEById(int imeId)
        {
            var id = _context.IME.Where(a => a.ID == imeId).FirstOrDefault();
            var mapped = _mapper.Map<IME, ImeDto>(id);
            return mapped;
        }

        public async Task<ResponseDto<List<ImeDto>>> GetImeList()
        {
            var rec = await _context.IME.ToListAsync();
            var response = new ResponseDto<List<ImeDto>>();
            response.Data = _mapper.Map<List<IME>, List<ImeDto>>(rec);
            return response;
        }

        public async Task<List<ImeDto>> GetIMEListByVisits(long Id)
        {
            var joinData = await(from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                 join V in _context.Visits
                                 on P.AppointmentId equals V.AppoinmentId

                                 join I in _context.IME
                                 on V.VisitId equals I.VisitId

                                 select new ImeDto
                                 {
                                     ID = I.ID,
                                     Date = I.Date,
                                     Time = I.Time,
                                     IME_Place = I.IME_Place,
                                     IME_Status = I.IME_Status,
                                     Reason = I.Reason,
                                     Represented_By = I.Represented_By,
                                     Transcripts = I.Transcripts,
                                     VisitId = I.VisitId
                                     
                                 }).ToListAsync();

            return joinData;
        }

        public Task<List<ImeDto>> ImagingVisitList(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
