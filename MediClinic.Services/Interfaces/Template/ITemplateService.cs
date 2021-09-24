using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.Template
{
    public interface ITemplateService
    {
        public Task<bool> Add(TemplateDTO TemplateDTO);
        public Task<List<TemplateDTO>> getlist();
        public Task<TemplateDTO> GetTemplate(int Id);
        public Task<Error> DeleteTemplate(int Id);

        public Task<bool> CreateComponent(TemplateComponentDTO TemplateComponentDTO, List<TemplateComponentDetailDTO> TemplateComponentDetailDTO);
        public Task<List<TemplateComponentDTO>> GetComponentList(int templateId);
        public Task<TemplateComponentDTO> GetComponent(int Id);

        public Task<bool> DoctorTemplate(DoctorTemplateDTO DoctorTemplateDTO);
        public Task<List<spGetDoctorTemplateDTO>> GetDoctorTemplateList(int DoctorId);
        public Task<Error> DeleteControl(int Id);

        public Task<bool> DoctorPatientTemplate(List<DoctorPatientTemplateDTO> DoctorPatientTemplateDTO, int PatientId, int VisitId);
        public Task<List<spGetDoctorPatientTemplateDTO>> GetDoctorPatientTemplate(int TemplateId, int DoctorId, int PatientId, int VisitId);

        public  Task<List<PatientInfoBasicDto>> GetlistofPatients();
        public Task<List<PatientInfoBasicDto>> GetlistofVisitCreatedPatients();
        public Task<VisitsDto> GetVisitByPatientId(int PatientId);

        public Task<List<TemplateForPatientViewDto>> TemplateDetailForPatient(int Id);
        //public Task<List<VisitsDto>> GetVisitsList(int id);

        public Task<List<TemplateDTO>> TemplateListForPatient(long Id);
        Task<List<ICDDto>> GetAllICDCodes(bool withDetail);

        public Task<ResponseDto<bool>> CheckICD10Exist(int Id);
    }
}
