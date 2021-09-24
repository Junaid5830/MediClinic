using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientMedicalProblemDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientMedicalProblemInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientMedicalProblemService
{
    public class PatientMedicalProblemService : IPatientMedicalProblemService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientMedicalProblemService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<PatientMedicalProblemBasicDto>> GetMedicalProblemById(int Id)
        {
            var oldEntity = await _context.PatientMedicalProblem.FirstOrDefaultAsync(x => x.MedicalProblemId == Id);
            var mapped = _mapper.Map<PatientMedicalProblem, PatientMedicalProblemBasicDto>(oldEntity);
            var response = new ResponseDto<PatientMedicalProblemBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<PatientMedicalProblemBasicDto>> GetMedicalProblemByMedicalHistoryId(int medicalProblemId)
        {
            var entity = await _context.PatientMedicalProblem.FirstOrDefaultAsync(x => x.MedicalProblemId == medicalProblemId);
            if (!(entity is null))
            {
                var mapped = _mapper.Map<PatientMedicalProblem, PatientMedicalProblemBasicDto>(entity);
                var response = new ResponseDto<PatientMedicalProblemBasicDto>();
                response.Data = mapped;
                return response;
            }
            else
            {
                return new ResponseDto<PatientMedicalProblemBasicDto>();
            }
        }

        public async Task<ResponseDto<PatientMedicalProblemBasicDto>> MedicalProblemCreate(PatientMedicalProblemBasicDto patientMedicalProblemBasicDto)
        {
            try
            {
                var mapped = _mapper.Map<PatientMedicalProblemBasicDto, PatientMedicalProblem>(patientMedicalProblemBasicDto);
                var data = await _context.PatientMedicalProblem.AddAsync(mapped);

                _context.SaveChanges();
                var entity = _mapper.Map<PatientMedicalProblem, PatientMedicalProblemBasicDto>(mapped);
                var response = new ResponseDto<PatientMedicalProblemBasicDto>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool MedicalProblemDeleteById(int Id)
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

        public async Task<ResponseDto<List<PatientMedicalProblemBasicDto>>> MedicalProblemList(long Id)
        {
            List<PatientMedicalProblemBasicDto> MedicalProblemBasicDto = new List<PatientMedicalProblemBasicDto>();
            MedicalProblemBasicDto = await (from p in _context.PatientMedicalProblem.Where(x => x.PatientId == Id)
                                            join d in _context.MedicalDiseaseType on p.DiseaseTypeId equals d.DiseaseTypeId

                                            select new PatientMedicalProblemBasicDto
                                            {
                                                MedicalProblemId = p.MedicalProblemId,
                                                DieaseName = d.DiseaseTypeName,
                                                DiseaseTypeId = d.DiseaseTypeId,
                                                PatientId = p.PatientId,
                                                ExaminerId = p.ExaminerId,
                                                CurrentStatus = p.CurrentStatus,
                                                DateYear = p.DateYear,
                                                DocumentReport = p.DocumentReport,

                                            }).Where(x => x.PatientId == Id).OrderByDescending(x => x.MedicalProblemId).ToListAsync();

            var response = new ResponseDto<List<PatientMedicalProblemBasicDto>>();
            response.Data = MedicalProblemBasicDto;
            return response;
        }

        public async Task<ResponseDto<List<PatientMedicalProblemBasicDto>>> MedicalProblemListProblemId(int Id)
        {
            var rec = await _context.PatientMedicalProblem.Include(p => p.DiseaseType).OrderByDescending(x => x.MedicalProblemId).ToListAsync();
            var response = new ResponseDto<List<PatientMedicalProblemBasicDto>>();
            response.Data = _mapper.Map<List<PatientMedicalProblem>, List<PatientMedicalProblemBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<PatientMedicalProblemBasicDto>> medicalProblemHistoryGetId(int Id)
        {
            PatientMedicalProblemBasicDto problem = new PatientMedicalProblemBasicDto();
            problem = await (from p in _context.PatientMedicalProblem
                             join d in _context.MedicalDiseaseType on p.DiseaseTypeId equals d.DiseaseTypeId

                             select new PatientMedicalProblemBasicDto
                             {
                                 MedicalProblemId = p.MedicalProblemId,
                                 DieaseName = d.DiseaseTypeName,
                                 DiseaseTypeId = d.DiseaseTypeId,
                                 PatientId = p.PatientId,
                                 ExaminerId = p.ExaminerId,
                                 CurrentStatus = p.CurrentStatus,
                                 DateYear = p.DateYear,
                                 DocumentReport = p.DocumentReport,

                             }).FirstOrDefaultAsync(x => x.MedicalProblemId == Id);
            var response = new ResponseDto<PatientMedicalProblemBasicDto>();
            response.Data = problem;
            return response;
        }

        public async Task<ResponseDto<bool>> MedicalProblemUpdate(PatientMedicalProblemBasicDto patientMedicalProblemBasicDto)
        {
            try
            {
                var mapped = _mapper.Map<PatientMedicalProblemBasicDto, PatientMedicalProblem>(patientMedicalProblemBasicDto);
                var oldEntity = await _context.PatientMedicalProblem.FindAsync(mapped.MedicalProblemId);

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
