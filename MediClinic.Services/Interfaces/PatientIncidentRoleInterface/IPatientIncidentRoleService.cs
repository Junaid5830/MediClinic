using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientIncidentRoleDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientIncidentRoleInterface
{
    public interface IPatientIncidentRoleService
    {
        public Task<ResponseDto<int>> patientIncidentRole(PatientIncidentRoleBasicDto patientIncidentRole);

        public List<PatientRoleIncident> patientRoleIncidentList(string name);

        public Task<ResponseDto<List<PatientIncidentRoleBasicDto>>> PatientIncidentList();

        public Task<PatientRoleIncident> GetEditpatientRoleIncidentDetails(int patientIncidentRoleId);

        public Task<ResponseDto<bool>> DeletePatientIncident(int PatientIncidentRoleId);

        public Task<ResponseDto<bool>> isExistorNot(string Name);
    }
}
