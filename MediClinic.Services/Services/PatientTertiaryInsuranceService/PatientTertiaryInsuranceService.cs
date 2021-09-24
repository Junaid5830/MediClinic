using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientTertiaryInsuranceDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientTertiaryInsuranceInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientTertiaryInsuranceService
{
    public class PatientTertiaryInsuranceService : IPatientTertiaryInsuranceService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        public PatientTertiaryInsuranceService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<bool>> patientTertiaryInsurance(PatientTertiaryInsuranceBasicDto patientTertiaryInsuranceBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<PatientTertiaryInsuranceBasicDto, TertiaryInsurenceProvider>(patientTertiaryInsuranceBasicDto);
            var data = await _context.TertiaryInsurenceProvider.AddAsync(mapped);
            _context.SaveChanges();
            if (!(data is null))
            {
                result = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto<bool>> patientTertiaryInsuranceUpdate(PatientTertiaryInsuranceBasicDto patientTertiaryInsuranceBasicDto)
        {
            var mapped = _mapper.Map<PatientTertiaryInsuranceBasicDto, TertiaryInsurenceProvider>(patientTertiaryInsuranceBasicDto);
            var oldEntity =await  _context.TertiaryInsurenceProvider.FindAsync(mapped.TertiaryInsurenceProviderID);
            mapped.CreatedDate = oldEntity.CreatedDate;
            mapped.ModifiedDate = DateTime.UtcNow;
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
    }
}
