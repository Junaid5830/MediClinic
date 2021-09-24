using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.Template;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.Template
{
    public class TemplateService : ITemplateService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;
        public TemplateService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;

        }

        public async Task<bool> Add(TemplateDTO TemplateDTO)
        {
            var mapped = _mapper.Map<TemplateDTO, MediClinic.Models.EntityModels.Template>(TemplateDTO);
            if (TemplateDTO.Id == 0)
            {
                await _context.Template.AddAsync(mapped);
            }
            else
            {
                _context.Update(mapped);
            }
            _context.SaveChanges();
            return true;
        }
        public async Task<List<TemplateDTO>> getlist()
        {
            var list = await _context.Template.ToListAsync();
            var mapped = _mapper.Map<List<MediClinic.Models.EntityModels.Template>, List<TemplateDTO>>(list);
            return mapped;
        }
        public async Task<Error> DeleteTemplate(int Id)
        {
            Error error = new Error();
            DoctorTemplate DoctorTemplate = _context.DoctorTemplate.Where(a => a.TemplateId == Id).FirstOrDefault();
            if (DoctorTemplate != null)
            {
                error.Status = true;
                error.Msg = "Template already assigned to doctor";
                return error;
            }
            var Template = await _context.Template.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (Template != null)
            {
                _context.Remove(Template);
                _context.SaveChanges();
                return error;
            }
            return error;
        }
        public async Task<TemplateDTO> GetTemplate(int Id)
        {
            var list = await _context.Template.Where(a => a.Id == Id).FirstOrDefaultAsync();
            var mapped = _mapper.Map<MediClinic.Models.EntityModels.Template, TemplateDTO>(list);
            return mapped;
        }
        public async Task<bool> CreateComponent(TemplateComponentDTO TemplateComponentDTO, List<TemplateComponentDetailDTO> TemplateComponentDetailDTO)
        {
            var mapped = _mapper.Map<TemplateComponentDTO, MediClinic.Models.EntityModels.TemplateComponent>(TemplateComponentDTO);
            if (TemplateComponentDTO.Id == 0)
            {
                await _context.TemplateComponent.AddAsync(mapped);
                _context.SaveChanges();
            }
            else
            {
                _context.TemplateComponent.Update(mapped);
                _context.SaveChanges();
                List<TemplateComponentDetail> AlreadyExist = await _context.TemplateComponentDetail.Where(a => a.TemplateComponentId == mapped.Id).ToListAsync();
                if (AlreadyExist != null && AlreadyExist.Count() > 0)
                {
                    _context.TemplateComponentDetail.RemoveRange(AlreadyExist);
                    _context.SaveChanges();
                }
            }
            if (TemplateComponentDetailDTO != null && TemplateComponentDetailDTO.Count > 0)
            {
                if (TemplateComponentDetailDTO[0].Text != null && TemplateComponentDetailDTO[0].Value != null)
                {
                    List<TemplateComponentDetailDTO> TemplateComponentDetailDTOAdd = new List<TemplateComponentDetailDTO>();
                    foreach (var loop in TemplateComponentDetailDTO)
                    {
                        if (loop.Text != null && loop.Value != null)
                        {
                            loop.TemplateComponentId = mapped.Id;
                            TemplateComponentDetailDTOAdd.Add(loop);
                        }                        
                    }

                    var mappedDetail = _mapper.Map<List<MediClinic.Models.EntityModels.TemplateComponentDetail>>(TemplateComponentDetailDTOAdd);
                    await _context.TemplateComponentDetail.AddRangeAsync(mappedDetail);
                    _context.SaveChanges();
                }
            }
            return true;
        }

        public async Task<List<TemplateComponentDTO>> GetComponentList(int templateId)
        {
            var list = await _context.TemplateComponent.Where(a => a.TemplateId == templateId).ToListAsync();
            List<TemplateComponentDTO> TemplateComponentDTOList = _mapper.Map<List<MediClinic.Models.EntityModels.TemplateComponent>, List<TemplateComponentDTO>>(list);
            foreach (var loop in TemplateComponentDTOList)
            {
                var Detaillist = await _context.TemplateComponentDetail.Where(a => a.TemplateComponentId == loop.Id).ToListAsync();
                List<TemplateComponentDetailDTO> RtnDetailList = _mapper.Map<List<TemplateComponentDetailDTO>>(Detaillist);
                if (RtnDetailList != null && RtnDetailList.Count() > 0)
                {
                    loop.TemplateComponentDetailDTO = new List<TemplateComponentDetailDTO>();
                    loop.TemplateComponentDetailDTO.AddRange(RtnDetailList);
                }
            }

            return TemplateComponentDTOList;
        }
        public async Task<TemplateComponentDTO> GetComponent(int Id)
        {
            var list = await _context.TemplateComponent.Where(a => a.Id == Id).FirstOrDefaultAsync();
            var mapped = _mapper.Map<MediClinic.Models.EntityModels.TemplateComponent, TemplateComponentDTO>(list);
            return mapped;
        }
        public async Task<bool> DoctorTemplate(DoctorTemplateDTO DoctorTemplateDTO)
        {
            var mapped = _mapper.Map<DoctorTemplateDTO, MediClinic.Models.EntityModels.DoctorTemplate>(DoctorTemplateDTO);
            await _context.DoctorTemplate.AddAsync(mapped);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<spGetDoctorTemplateDTO>> GetDoctorTemplateList(int DoctorId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<spGetDoctorTemplateDTO>(sql: "[spGetDoctorTemplate]", param: new { doctorId = DoctorId },
                commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<Error> DeleteControl(int Id)
        {
            Error error = new Error();
            DoctorPatientTemplate DoctorPatientTemplate = _context.DoctorPatientTemplate.Where(a => a.TemplateComponentId == Id).FirstOrDefault();
            if (DoctorPatientTemplate != null)
            {
                error.Status = true;
                error.Msg = "Control already assigned to Patient";
                return error;
            }
            var TemplateComponentDetail = await _context.TemplateComponentDetail.Where(a => a.TemplateComponentId == Id).ToListAsync();
            if (TemplateComponentDetail != null && TemplateComponentDetail.Count() > 0)
            {
                _context.RemoveRange(TemplateComponentDetail);
                _context.SaveChanges();
            }
            var TemplateComponent = await _context.TemplateComponent.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (TemplateComponent != null)
            {
                _context.Remove(TemplateComponent);
                _context.SaveChanges();
                return error;
            }
            return error;
        }
        public async Task<bool> DoctorPatientTemplate(List<DoctorPatientTemplateDTO> DoctorPatientTemplateDTO, int PatientId, int VisitId)
        {
            var mapped = _mapper.Map<List<MediClinic.Models.EntityModels.DoctorPatientTemplate>>(DoctorPatientTemplateDTO);
            
            foreach (var loop in mapped)
            {
                loop.PatientId = PatientId;
                loop.VisitId = VisitId;
                loop.CreatedDate = DateTime.UtcNow;
                //if (loop.Value == null)
                //{
                //    loop.Value = "NA";
                //}
                DoctorPatientTemplate DoctorPatientTemplateAlreadyExist = _context.DoctorPatientTemplate.Where(a => a.DoctorTemplateId == loop.DoctorTemplateId && a.TemplateComponentId == loop.TemplateComponentId && a.PatientId == PatientId && a.VisitId == VisitId).FirstOrDefault();
                if (DoctorPatientTemplateAlreadyExist != null)
                {
                    _context.DoctorPatientTemplate.Remove(DoctorPatientTemplateAlreadyExist);
                    _context.SaveChanges();
                }
            }
            await _context.DoctorPatientTemplate.AddRangeAsync(mapped);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<PatientInfoBasicDto>> GetlistofPatients()
        {
            var list = await _context.PatientInfo.ToListAsync();
            var mapped = _mapper.Map<List<PatientInfo>, List<PatientInfoBasicDto>>(list);
            return mapped;
        }
        public async Task<List<PatientInfoBasicDto>> GetlistofVisitCreatedPatients()
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<PatientInfoBasicDto>(sql: "[sp_GetVisitCreatedPatients]",
                commandType: CommandType.StoredProcedure);
                List<PatientInfoBasicDto> patients = result.ToList();
                return patients;
            }

            //var list = await _context.PatientInfo.ToListAsync();
            //var mapped = _mapper.Map<List<PatientInfo>, List<PatientInfoBasicDto>>(list);
            //return mapped;
        }
        public async Task<VisitsDto> GetVisitByPatientId(int PatientId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<VisitsDto>(sql: "[sp_GetVisitIdByPatientId]",
                param: new { patientId = PatientId },
                commandType: CommandType.StoredProcedure);
                VisitsDto visit = result.FirstOrDefault();
                return visit;
            }
        }
        //public Task<List<VisitsDto>> GetVisitsList(int patientId) 
        //{
        //    var list = await _context.Visits.Where(a=>a. == ).ToListAsync();
        //    var mapped = _mapper.Map<List<PatientInfo>, List<PatientInfoBasicDto>>(list);
        //    return mapped;
        //}


        public async Task<List<spGetDoctorPatientTemplateDTO>> GetDoctorPatientTemplate(int TemplateId, int DoctorId, int PatientId, int VisitId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<spGetDoctorPatientTemplateDTO>(sql: "[spGetDoctorPatientTemplate]",
                    param: new { templateId = TemplateId, doctorId = DoctorId, patientId = PatientId, visitId = VisitId },
                commandType: CommandType.StoredProcedure);
                List<spGetDoctorPatientTemplateDTO> TemplateComponentDTOList = result.ToList();
                //return result.ToList();
                foreach (var loop in TemplateComponentDTOList)
                {
                    var Detaillist = await _context.TemplateComponentDetail.Where(a => a.TemplateComponentId == loop.Id).ToListAsync();
                    List<TemplateComponentDetailDTO> RtnDetailList = _mapper.Map<List<TemplateComponentDetailDTO>>(Detaillist);
                    if (RtnDetailList != null && RtnDetailList.Count() > 0)
                    {
                        loop.TemplateComponentDetailDTO = new List<TemplateComponentDetailDTO>();
                        loop.TemplateComponentDetailDTO.AddRange(RtnDetailList);
                    }
                }
                return TemplateComponentDTOList;
            }
        }

        public async Task<List<TemplateForPatientViewDto>> TemplateDetailForPatient(int Id)
        {
            try
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = await conn.QueryAsync<TemplateForPatientViewDto>(sql: "[spTemplateListForPatient]", param: new { VisitId = Id },
                    commandType: CommandType.StoredProcedure);
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var rec in result)
                    {
                        if (!(rec.VisitDetail is null))
                        {
                            foreach (var item in rec.VisitDetail)
                            {
                                stringBuilder.Append(item);
                            }
                        }
                        else
                        {
                            string name = null;
                            stringBuilder.Append(name);

                        }
                        rec.VisitDetails = JsonConvert.DeserializeObject<List<VisitDetail>>(Convert.ToString(stringBuilder));
                        stringBuilder.Length = 0;
                        stringBuilder.Capacity = 0;

                    }


                    return result.ToList();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<TemplateDTO>> TemplateListForPatient(long Id)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<TemplateDTO>(sql: "[spGetTemplateListForPatient]", param: new { PatientId = Id },
                commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<ICDDto>> GetAllICDCodes(bool withDetail)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ICDDto>(sql: "[GetAllICDCodes]",
                param: new { withDescription = withDetail },
                commandType: CommandType.StoredProcedure);

                var response = result.ToList();
                if (response.Any())
                {
                    return result.ToList();
                }
                else
                {
                    return new List<ICDDto>();
                }

            }
        }

        public async Task<ResponseDto<bool>> CheckICD10Exist(int Id)
        {
            var isExist = false;
            var rec =await _context.TemplateComponent.FirstOrDefaultAsync(x => x.Id == Id && x.ComponentType == "ICD 10");
            if (!(rec is null))
            {
                isExist = true;
            }
      
            return new ResponseDto<bool>()
            {
                Data = isExist,
                Message = "ICD 10 is already exist"
            };
        }
    }
}
