using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientIdandSignatureDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientIdandSignatureInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientIdandSignatureService
{
    public class PatientIdandSignatureService : IPatientIdandSignatureService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        public PatientIdandSignatureService(MediClinicContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResponseDto<bool> patientIdandSignature(PatientIdandSignatureBasicDto patientIdandSignatureBasicDto)
        {
            var result = false;
            try
            {
                var mapped = _mapper.Map<PatientIdandSignatureBasicDto, PatientIdAndSignature>(patientIdandSignatureBasicDto);
                var data = _context.PatientIdAndSignature.Add(mapped);
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

        public ResponseDto<bool> patientIdandSignatureUpdate(PatientIdandSignatureBasicDto patientIdandSignatureBasicDto)
        {
            try
            {
                var mapped = _mapper.Map<PatientIdandSignatureBasicDto, PatientIdAndSignature>(patientIdandSignatureBasicDto);
                var oldEntity =  _context.PatientIdAndSignature.Find(mapped.PatientSignatureId);
                //if (mapped.PaitentImage is null)
                //{
                //    mapped.PaitentImage = oldEntity.PaitentImage;
                //}
                _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
                _context.SaveChanges();
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
