using MediClinic.Models.ApiDtos;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces
{
    public interface IDriverService
    {
        Task<ResponseDto<bool>> UpdateDriverAvailability(DriverAvailabilityDto dtoModel, string status);
        Task<ResponseDto<DriverAvailabilityDto>> driverAvailability(DriverAvailabilityDto driverAvailabilityDto);

        Task<ResponseDto<DriverCurrentLocationDto>> DriverCurrentLocation(DriverCurrentLocationDto driverCurrentLocationDto);
        Task<ResponseDto<bool>> GetDriverActiveStatus(int driverId);
        Task<ResponseDto<bool>> UpdateDriverActiveStatus(DriverAvailabilityDto availabilityDto);

        List<UserDevices> GetUserDevices(int driverId);
        Task<ResponseDto<bool>> UpdateDriverJobRequestStatus(DriverJobRequestStatusDto dtoModel);
        Task<ResponseDto<LatestJobDto>> GetDriverLatestJob(int driverId);

        Task<ResponseDto<bool>> DriverProfileUpdateApi(DriverProfileUpdateDto driverProfileUpdateDto);
        Task<ResponseDto<bool>> CreateDriverAttendance(AttendanceDto attendanceDto);

        Task<ResponseDto<bool>> DriverAttendanceStatus(int driverId);
    }
}
