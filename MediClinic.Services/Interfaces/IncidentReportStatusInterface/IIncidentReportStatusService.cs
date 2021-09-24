using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.IncidentReportStatusDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.IncidentReportStatusInterface
{
    public interface IIncidentReportStatusService
    {
        public Task<ResponseDto<int>> IncidentRepotStatus(IncidentReportStatusBasicDto incidentReportStatusBasicDto);
        public Task<ResponseDto<bool>> IncidentRepotStatusUpdate(IncidentReportStatusBasicDto incidentReportStatusBasicDto);

        public List<IncidentReportStatus> incidentReportStatuses(string name);

        public Task<ResponseDto<IncidentReportStatusBasicDto>> IncidentReportId(int id);
        public Task<ResponseDto<bool>> IncidentReportDeleteId(int Id);
        public Task<ResponseDto<List<IncidentReportStatusBasicDto>>> PatientIncidentReport();

        public Task<ResponseDto<bool>> isExistorNot(string Name);
    }
}
