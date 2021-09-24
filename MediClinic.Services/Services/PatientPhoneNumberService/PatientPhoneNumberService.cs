using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientPhoneNumberDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientPhoneNumberInterface;
using MediClinic.Services.Interfaces.SessionManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientPhoneNumberService
{
    public class PatientPhoneNumberService : IPatientPhoneNumberService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;
        public PatientPhoneNumberService(MediClinicContext context , IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public async Task<ResponseDto<bool>> CreatePatientPhoneNumber(PatientPhoneNumberBasicDto patientPhoneNumberBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<PatientPhoneNumberBasicDto, PatientPhoneNumber>(patientPhoneNumberBasicDto);
            mapped.CreatedDate = DateTime.UtcNow;
            mapped.ModifiedDate = DateTime.UtcNow;

            mapped.CreatedById = Convert.ToInt32(_sessionManager.GetUserId());

            var data = await _context.PatientPhoneNumber.AddAsync(mapped);
            _context.SaveChanges();
            if (!(data is null))
            {
                result = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;

        }

        public async Task<ResponseDto<bool>> CreatePatientPhoneUpdate(PatientPhoneNumberBasicDto patientPhoneNumberBasicDto)
        {
            var mapped = _mapper.Map<PatientPhoneNumberBasicDto, PatientPhoneNumber>(patientPhoneNumberBasicDto);
            var oldEntity = await _context.PatientPhoneNumber.FindAsync(mapped.PhoneNumberId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
    }
}
