using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientSecondaryInsuranceDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientSecondaryInsuranceInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientSecondaryInsuranceService
{
    public class PatientSecondaryInsuranceService : IPatientSecondaryInsuranceService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientSecondaryInsuranceService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<bool>> patientSecondaryInsurance(PatientSecondaryInsuranceBasicDto patientSecondaryInsuranceBasicDto)
        {
            try
            {
                var result = false;
                var mapped = _mapper.Map<PatientSecondaryInsuranceBasicDto, SecondaryInsurenceProvider>(patientSecondaryInsuranceBasicDto);
                mapped.CreatedDate = DateTime.UtcNow;
                var data = await _context.SecondaryInsurenceProvider.AddAsync(mapped);
                _context.SaveChanges();
                if (!(data is null))
                {
                    result = true;
                }
                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ResponseDto<bool>> patientSecondaryInsuranceUpdate(PatientSecondaryInsuranceBasicDto patientSecondaryInsuranceBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<PatientSecondaryInsuranceBasicDto, SecondaryInsurenceProvider>(patientSecondaryInsuranceBasicDto);
            var oldEntity = await _context.SecondaryInsurenceProvider.FindAsync(mapped.SecondaryInsuranceProviderID);

            mapped.CreatedDate = oldEntity.CreatedDate;
            mapped.ModifiedDate = DateTime.UtcNow;

            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();

            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }
    }
}
