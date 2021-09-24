using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientMedicalHistoryDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientMedicalHistoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientMedicalHistoryService
{
    public class PatientMedicalHistoryService : IPatientMedicalHistoryService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientMedicalHistoryService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<PatientMedicalHistoryBasicDto>> GetPatientMedicalHistoryById(int Id)
        {
            var oldEntity = await _context.PatientMedicalHistory.FirstOrDefaultAsync(x => x.MedicalHistryId == Id);
            var mapped = _mapper.Map<PatientMedicalHistory, PatientMedicalHistoryBasicDto>(oldEntity);
            var response = new ResponseDto<PatientMedicalHistoryBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<PatientMedicalHistoryBasicDto>> PatientMedicalHistoryCreate(PatientMedicalHistoryBasicDto patientMedicalHistoryBasicDto)
        {
            try
            {
                var mapped = _mapper.Map<PatientMedicalHistoryBasicDto, PatientMedicalHistory>(patientMedicalHistoryBasicDto);
                var data = await _context.PatientMedicalHistory.AddAsync(mapped);

                _context.SaveChanges();
                var entity = _mapper.Map<PatientMedicalHistory, PatientMedicalHistoryBasicDto>(mapped);
                var response = new ResponseDto<PatientMedicalHistoryBasicDto>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool PatientMedicalHistoryDeleteById(int Id)
        {
            var record = _context.PatientMedicalProblem.FirstOrDefault(x => x.MedicalProblemId == Id);
            if (record != null)
            {
                _context.Remove(record);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ResponseDto<List<PatientMedicalHistoryBasicDto>>> PatientMedicalHistoryList(long Id)
        {
            var rec = await _context.PatientMedicalHistory.Include(p => p.DiseaseType).Where(x => x.PatientId == Id).OrderByDescending(x => x.MedicalHistryId).ToListAsync();
            var response = new ResponseDto<List<PatientMedicalHistoryBasicDto>>();
            response.Data = _mapper.Map<List<PatientMedicalHistory>, List<PatientMedicalHistoryBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<List<PatientMedicalHistoryBasicDto>>> PatientMedicalHistoryListbyHistoryId(int Id)
        {
            var rec = await _context.PatientMedicalHistory.Include(p => p.DiseaseType).OrderByDescending(x => x.MedicalHistryId).ToListAsync();
            var response = new ResponseDto<List<PatientMedicalHistoryBasicDto>>();
            response.Data = _mapper.Map<List<PatientMedicalHistory>, List<PatientMedicalHistoryBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<bool>> PatientMedicalHistoryUpdate(PatientMedicalHistoryBasicDto patientMedicalHistoryBasicDto)
        {
            try
            {
                var mapped = _mapper.Map<PatientMedicalHistoryBasicDto, PatientMedicalHistory>(patientMedicalHistoryBasicDto);
                var oldEntity = await _context.PatientMedicalProblem.FindAsync(mapped.MedicalHistryId);

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
