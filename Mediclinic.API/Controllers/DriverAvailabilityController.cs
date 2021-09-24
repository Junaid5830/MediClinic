using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mediclinic.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DriverAvailabilityController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverAvailabilityController(IDriverService driverService)
        {
            _driverService = driverService;
        }
        [HttpPost]
        public async Task<IActionResult> Availablility(DriverAvailabilityDto driverAvailabilityDto)
        {
            var rec = await _driverService.driverAvailability(driverAvailabilityDto);
            return Ok(rec);
        }

        [HttpPost]
        public async Task<IActionResult> DriverCurrentLocation(DriverCurrentLocationDto driverCurrentLocationDto)
        {
            var rec = await _driverService.DriverCurrentLocation(driverCurrentLocationDto);
            return Ok(rec);
        }

        [HttpGet]
        public async Task<IActionResult> GetDriverActiveStatus(int requestId)
        {
            var rec = await _driverService.GetDriverActiveStatus(requestId);
            return Ok(rec);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateJobRequestStatus(DriverJobRequestStatusDto driverStatusDto)
        {
            var rec = await _driverService.UpdateDriverJobRequestStatus(driverStatusDto);
            return Ok(rec);
        }

        [HttpGet]
        public async Task<IActionResult> GetDriverLatestJobRequest(int driverId)
        {
            var rec = await _driverService.GetDriverLatestJob(driverId);
            return Ok(rec);
        }
        [HttpGet]
        public async Task<IActionResult> DriverAttendanceStatus(int driverId)
        {
            var rec = await _driverService.DriverAttendanceStatus(driverId);
            return Ok(rec);
        }
    }
}
