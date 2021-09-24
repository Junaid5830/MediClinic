using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientIncidentRoleDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientIncidentRoleInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientIncidentRoleService
{
    public class PatientIncidentRoleService : IPatientIncidentRoleService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientIncidentRoleService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<PatientIncidentRoleBasicDto>>> PatientIncidentList()
        {
            var rec = await _context.PatientRoleIncident.ToListAsync();
            var response = new ResponseDto<List<PatientIncidentRoleBasicDto>>();
            response.Data = _mapper.Map<List<PatientRoleIncident>, List<PatientIncidentRoleBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<int>> patientIncidentRole(PatientIncidentRoleBasicDto patientIncidentRole)
        {
            if (!(patientIncidentRole.PatientRoleInIncident is null))
            {
                patientIncidentRole.PatientRoleInIncident = patientIncidentRole.PatientRoleInIncident.Trim();
            }
            var mapped = _mapper.Map<PatientIncidentRoleBasicDto, PatientRoleIncident>(patientIncidentRole);

            if (patientIncidentRole.PatientIncidentRoleId > 0)
            {
                var getData = _context.PatientRoleIncident.Where(x => x.PatientIncidentRoleId == patientIncidentRole.PatientIncidentRoleId).FirstOrDefault();
                getData.PatientRoleInIncident = patientIncidentRole.PatientRoleInIncident;
                _context.SaveChanges();
            }
            else
            {
                var data = await _context.PatientRoleIncident.AddAsync(mapped);
                _context.SaveChanges();
                
            }
            
            var response = new ResponseDto<int>();
            response.Data = mapped.PatientIncidentRoleId;
            return response;
        }

        public List<PatientRoleIncident> patientRoleIncidentList(string name)
        {
            var rec = _context.PatientRoleIncident.ToList();
            return rec;
        }

        public async Task<PatientRoleIncident> GetEditpatientRoleIncidentDetails(int patientIncidentRoleId)
        {
            var rec = await  _context.PatientRoleIncident.Where(x=>x.PatientIncidentRoleId == patientIncidentRoleId).FirstOrDefaultAsync();
            return rec;
        }

        public async Task<ResponseDto<bool>> DeletePatientIncident(int patientIncidentRoleId)
        {
            var result = false;
            var data = await _context.PatientRoleIncident.FirstOrDefaultAsync(x=>x.PatientIncidentRoleId == patientIncidentRoleId);

            if (!(data is null))
            {
                _context.PatientRoleIncident.Remove(data);
                var status = await _context.SaveChangesAsync();

                if (status > 0)
                {
                    result = true;
                }
            }

            return new ResponseDto<bool>()
            {
                Data = result
            };
        }

        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var value = await _context.PatientRoleIncident.Where(x => x.PatientRoleInIncident.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
    }
}
