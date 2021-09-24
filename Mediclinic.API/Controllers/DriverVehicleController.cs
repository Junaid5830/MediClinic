using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using MediClinic.Models.ApiDtos;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Services.Interfaces;
using MediClinic.Services.Interfaces.TransportEmsInterface;
using Microsoft.AspNetCore.Mvc;
using static MediClinic.Models.ApiDtos.DefaultDtos;

namespace Mediclinic.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DriverVehicleController : ControllerBase
    {
        private readonly ITransportEmsService _transportEms;
        private IMapper _mapper;
        private readonly IPushNotificationService _pushNotification;

        public DriverVehicleController(ITransportEmsService transportEms, IMapper mapper, IPushNotificationService pushNotification)
        {
            _transportEms = transportEms;
            _mapper = mapper;
            _pushNotification = pushNotification;
        }
        [HttpPost]
        public async Task<IActionResult> GetDriverVehicle(DefaultRequestDto<int> requestDto)
        {
            var rec = await _transportEms.DriverVehicleDetail(requestDto.RequestId);
            return Ok(rec);
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicleTypes()
        {
            return Ok(await _transportEms.GetVehicleTypes());
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicleMakers()
        {
            return Ok(await _transportEms.GetVehicleMakers());
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicleModels()
        {
            return Ok(await _transportEms.GetVehicleModels());
        }


        [HttpPost]
        public async Task<IActionResult> CreateVehicleModel(TwoPropModel model)
        {
            var data = await _transportEms.AddVehicleModel(new VehicleModelDto { VehicleModel1 = model.RequestValue });
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleMaker(TwoPropModel model)
        {
            var data = await _transportEms.AddVehicleMake(new VehicleMakeDto { VehicleMake1 = model.RequestValue });
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleType(TwoPropModel model)
        {
            var data = await _transportEms.AddVehicleType(new VehicleTypeDto { VehicleType1 = model.RequestValue });
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateDriverVehicle(UpdateTransportApiDto vehicleDto)
        {
            var data = await _transportEms.UpdateTransportForAPI(vehicleDto);
            return Ok(data);
        }


        [HttpPost]
        public IActionResult TestAPI()
        {
            _pushNotification.GetDriversForAttendanceNotification();
            return Ok(true);
        }
    }
}