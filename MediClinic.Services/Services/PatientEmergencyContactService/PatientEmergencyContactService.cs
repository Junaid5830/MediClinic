using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientEmergencyContactDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientEmergencyContactInterface;
using MediClinic.Services.Interfaces.SessionManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientEmergencyContactService
{
    public class PatientEmergencyContactService : IPatientEmergencyContactService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public PatientEmergencyContactService(MediClinicContext context,IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public async Task<ResponseDto<PatientEmergencyContactBasicDto>> PatientEmergencyContact(PatientEmergencyContactBasicDto patientEmergencyContactBasicDto)
        {
            var mapped = _mapper.Map<PatientEmergencyContactBasicDto, PatientEmergencyContact>(patientEmergencyContactBasicDto);
            mapped.CreatedDate = DateTime.UtcNow;
            mapped.ModifiedDate = DateTime.UtcNow;
            mapped.CreatedById = Convert.ToInt32(_sessionManager.GetUserId());

            var data = await _context.PatientEmergencyContact.AddAsync(mapped);
            _context.SaveChanges();
            var entity = _mapper.Map<PatientEmergencyContact, PatientEmergencyContactBasicDto>(mapped);
            var response = new ResponseDto<PatientEmergencyContactBasicDto>();
            response.Data = entity;
            return response;
        }

        public async Task<ResponseDto<bool>> PatientEmergencyContactUpdate(PatientEmergencyContactBasicDto patientEmergencyContactBasicDto)
        {
            var mapped = _mapper.Map<PatientEmergencyContactBasicDto, PatientEmergencyContact>(patientEmergencyContactBasicDto);
            var oldEntity = await _context.PatientEmergencyContact.FindAsync(mapped.EmergencyContactID);

            mapped.CreatedDate = oldEntity.CreatedDate;
            mapped.ModifiedDate = DateTime.UtcNow;
            mapped.ModifiedById = Convert.ToInt32(_sessionManager.GetUserId());


            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
    }
}
