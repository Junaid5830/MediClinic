using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ClinicalReminderInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.ClinicalReminderService
{
    public class ClinicalReminderService : IClinicalReminderService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;
        public ClinicalReminderService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public List<ClinicalReminderDto> getlist()
        {
            var list = _context.ClinicalReminder.ToList();
            var mapped = _mapper.Map<List<ClinicalReminder>, List<ClinicalReminderDto>>(list);
            return mapped;
        }
        public ClinicalReminderDto GetClinicalReminderById(int id)
        {
            var Clinic = _context.ClinicalReminder.Where(a => a.CRId == id).FirstOrDefault();
            var mapped = _mapper.Map<ClinicalReminder, ClinicalReminderDto>(Clinic);
            return mapped;
        }
        public bool Add(ClinicalReminderDto clinicalReminderDto)
        {
            var mapped = _mapper.Map<ClinicalReminderDto, ClinicalReminder>(clinicalReminderDto);
            if (clinicalReminderDto.CRId == 0)
            {
                mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.CreatedDate = DateTime.UtcNow;
                _context.ClinicalReminder.Add(mapped);
                _context.SaveChanges();
                return true;
            }
            else
            {
                mapped.ModifiedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.ModifiedDate = DateTime.UtcNow;
                _context.ClinicalReminder.Update(mapped);
                _context.SaveChanges();
                return true;
            }
               

        }
        public bool Delete(int Id)
        {
            ClinicalReminder clinical = _context.ClinicalReminder.Where(a => a.CRId == Id).FirstOrDefault();
            if (clinical != null)
            {
                _context.ClinicalReminder.Remove(clinical);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<ClinicalReminderDto>> ClinicalReminderListbyVists(long Id)
        {
            var joinData = await(from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                 join V in _context.Visits
                                 on P.AppointmentId equals V.AppoinmentId



                                 join CR in _context.ClinicalReminder
                                 on V.VisitId equals CR.VisitId

                                 
                                 select new ClinicalReminderDto
                                 {
                                     ReminderDate = CR.ReminderDate,
                                     ReminderType = CR.ReminderType,
                                     ReminderBy = CR.ReminderBy,
                                     Reminders = CR.Reminders,
                                     DueDate = CR.DueDate,
                                     CRId = CR.CRId
                                     

                                 }).ToListAsync();

            return joinData;
        }
    }
}
