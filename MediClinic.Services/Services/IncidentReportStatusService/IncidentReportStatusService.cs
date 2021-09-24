using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.IncidentReportStatusDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.IncidentReportStatusInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.IncidentReportStatusService
{
    public class IncidentReportStatusService : IIncidentReportStatusService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public IncidentReportStatusService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<bool>> IncidentReportDeleteId(int Id)
        {
            var oldEntity = await _context.IncidentReportStatus.FirstOrDefaultAsync(x => x.IncidentReportId == Id);
            _context.Remove(oldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<IncidentReportStatusBasicDto>> IncidentReportId(int Id)
        {
            var oldEntity = await _context.IncidentReportStatus.FirstOrDefaultAsync(x => x.IncidentReportId == Id);
            var mapped = _mapper.Map<IncidentReportStatus, IncidentReportStatusBasicDto>(oldEntity);
            var response = new ResponseDto<IncidentReportStatusBasicDto>();
            response.Data = mapped;
            return response;
        }

        public List<IncidentReportStatus> incidentReportStatuses(string name)
        {
            var rec = _context.IncidentReportStatus.ToList();
            return rec;
        }

        public async Task<ResponseDto<int>> IncidentRepotStatus(IncidentReportStatusBasicDto incidentReportStatusBasicDto)
        {
            if (!(incidentReportStatusBasicDto.IncidentReportStatus1 is null))
            {
                incidentReportStatusBasicDto.IncidentReportStatus1 = incidentReportStatusBasicDto.IncidentReportStatus1.Trim();
            }
            var mapped = _mapper.Map<IncidentReportStatusBasicDto, IncidentReportStatus>(incidentReportStatusBasicDto);
            var data = await _context.IncidentReportStatus.AddAsync(mapped);
            _context.SaveChanges();
            
            var response = new ResponseDto<int>();
            response.Data = mapped.IncidentReportId;
            return response;
        }

        public async  Task<ResponseDto<bool>> IncidentRepotStatusUpdate(IncidentReportStatusBasicDto incidentReportStatusBasicDto)
        {
            var mapped = _mapper.Map<IncidentReportStatusBasicDto, IncidentReportStatus>(incidentReportStatusBasicDto);
            var oldEntity = await _context.IncidentReportStatus.FindAsync(mapped.IncidentReportId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var value = await _context.IncidentReportStatus.Where(x => x.IncidentReportStatus1.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }

        public async Task<ResponseDto<List<IncidentReportStatusBasicDto>>> PatientIncidentReport()
        {
            var rec = await _context.IncidentReportStatus.ToListAsync();
            var response = new ResponseDto<List<IncidentReportStatusBasicDto>>();
            response.Data = _mapper.Map<List<IncidentReportStatus>, List<IncidentReportStatusBasicDto>>(rec);
            return response;
        }
    }
}
