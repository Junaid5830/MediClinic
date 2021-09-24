using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientArbitrationAttorneyDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientArbitrationAttorneyInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientArbitrationAttorneyService
{
    public class PatientArbitrationAttorneyService : IPatientArbitrationAttorneyService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientArbitrationAttorneyService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<bool>> patientArbitrationAttorney(PatientArbitrationAttorneyBasicDto patientArbitrationAttorneyBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<PatientArbitrationAttorneyBasicDto, PatientArbitrationAttorney>(patientArbitrationAttorneyBasicDto);
            var data = await _context.PatientArbitrationAttorney.AddAsync(mapped);
            _context.SaveChanges();
            if (!(data is null))
            {
                result = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;


        }

        public async Task<ResponseDto<PatientArbitrationAttorneyBasicDto>> patientArbitrationAttorneyId(int Id)
        {
            var oldEntity = await _context.PatientArbitrationAttorney.FirstOrDefaultAsync(x => x.ArbitrationAttorneyID == Id);
            var mapped = _mapper.Map<PatientArbitrationAttorney, PatientArbitrationAttorneyBasicDto>(oldEntity);
            var response = new ResponseDto<PatientArbitrationAttorneyBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> patientArbitrationAttorneyUpdate(PatientArbitrationAttorneyBasicDto patientArbitrationAttorneyBasicDto)
        {
            try
            {
            var mapped = _mapper.Map<PatientArbitrationAttorneyBasicDto, PatientArbitrationAttorney>(patientArbitrationAttorneyBasicDto);
            var oldEntity = await _context.PatientArbitrationAttorney.FindAsync(mapped.ArbitrationAttorneyID);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }
    }
}
