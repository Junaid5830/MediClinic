using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientVehiclesDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientVehicleInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientVehicleService
{
    public class PatientVehicleService : IPatientVehicleService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;
        public PatientVehicleService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public ResponseDto<bool> patientVehicle(List<PatientVehiclesBasicDto> patientVehiclesBasicDto)
        {
            try
            {              
                var mapped = _mapper.Map<List<PatientVehiclesBasicDto>, List<VehicalsOrEntityInvolved>>(patientVehiclesBasicDto);
                foreach (var item in mapped)
                {
                    if (!item.VehicleInfo.Equals("thisOneIsDeletedRecordFromFrontEnd"))
                    {
                        _context.VehicalsOrEntityInvolved.Add(item);
                        _context.SaveChanges();
                    }
                }
                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<ResponseDto<PatientVehiclesBasicDto>> patientVehicleGetId(int Id)
        {
            var oldEntity = await _context.VehicalsOrEntityInvolved.FirstOrDefaultAsync(x => x.PatientVehicleID == Id);
            var mapped = _mapper.Map<VehicalsOrEntityInvolved, PatientVehiclesBasicDto>(oldEntity);
            var response = new ResponseDto<PatientVehiclesBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> patientVehicleUpdate(List<PatientVehiclesBasicDto> patientVehiclesBasicDto)
        {
            var mapped = _mapper.Map<List<PatientVehiclesBasicDto>, List<VehicalsOrEntityInvolved>>(patientVehiclesBasicDto);
            foreach (var item in mapped)
            {
                if (!(item.IsDelete == true))
                {
                    var oldEntity = await _context.VehicalsOrEntityInvolved.FindAsync(item.PatientVehicleID);
                    _context.Entry(oldEntity).CurrentValues.SetValues(item);
                    await _context.SaveChangesAsync();
                }
            }

            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public List<PatientVehiclesBasicDto> getVehicleListByUserId(long userId)
        {
            var vehicleList = _context.VehicalsOrEntityInvolved.Where(x => x.UserId == userId).ToList();
            var mapped = _mapper.Map<List<PatientVehiclesBasicDto>>(vehicleList);

            return mapped;
        }

        public ResponseDto<bool> deleteVehicleById(long vehicleId)
        {
            var response = false;
            var data = _context.VehicalsOrEntityInvolved.FirstOrDefault(x => x.PatientVehicleID == vehicleId);
            if (!(data is null))
            {
                response = true;
                _context.Remove(data);
                 _context.SaveChanges();
            }

            return new ResponseDto<bool>() {
              Data = response
            };
        }
    }
}
