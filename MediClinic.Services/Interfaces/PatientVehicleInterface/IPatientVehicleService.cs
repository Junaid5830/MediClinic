using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientVehiclesDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientVehicleInterface
{
    public interface IPatientVehicleService
    {
        public ResponseDto<bool> patientVehicle(List<PatientVehiclesBasicDto> patientVehiclesBasicDto);

        public Task<ResponseDto<PatientVehiclesBasicDto>> patientVehicleGetId(int Id);

        public Task<ResponseDto<bool>> patientVehicleUpdate(List<PatientVehiclesBasicDto> patientVehiclesBasicDto);
        public List<PatientVehiclesBasicDto> getVehicleListByUserId(long userId);

        public ResponseDto<bool> deleteVehicleById(long vehicleId);
    }
}
