using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.TransportEmsInterface;
using MedliClinic.Utilities.Utility.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MediClinic.Models.ApiDtos;
using MediClinic.Services.Interfaces;
using MedliClinic.Utilities.Utility;
using MediClinic.Services.Interfaces.UserInterface;

namespace MediClinic.Services.Services.TransportEmsService
{
    public class TransportEmsService : ITransportEmsService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private IPushNotificationService _notificationService;
        private IDriverService _driverService;
        public TransportEmsService(MediClinicContext context, IMapper mapper, IPushNotificationService notificationService, IDriverService driverService)
        {
            _context = context;
            _mapper = mapper;
            _notificationService = notificationService;
            _driverService = driverService;
        }
        public List<TransportEmsDTO> getlist()
        {
            var list = _context.TransportEms.Include(x => x.VehicleType).Include(x => x.VehicleModel).Include(x => x.VehicleMake).Where(x => x.IsActive == true).ToList();
            var descendingOrder = list.OrderByDescending(x=>x.TransportId).ToList();
            var mapped = _mapper.Map<List<TransportEms>, List<TransportEmsDTO>>(descendingOrder);
            return mapped;
        }
        public async Task<TransportEmsDTO> GetTransportById(int transportId)
        {
            try
            {
                var trans = await _context.TransportEms.Where(a => a.TransportId == transportId).FirstOrDefaultAsync();
                var mapped = _mapper.Map<TransportEms, TransportEmsDTO>(trans);
                return mapped;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
        public bool Delete(int transportId)
        {
            
            TransportEms transport = _context.TransportEms.Where(a => a.TransportId == transportId).FirstOrDefault();
            if (transport != null)
            {
                transport.IsActive = false;
                transport.IsAssigned = false;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<ResponseDto<List<DriverProfileDto>>> SelectDriversForDropDow()
        {
            var joinData = await(from P in _context.DriverProfile


                                 join T in _context.TransportEms
                                 on P.TransportId equals T.TransportId

                                 join DA in _context.DriverAttendance.Where(x => x.AttendanceTypeId == Convert.ToInt32(AttendanceKeys.CheckIn) && x.CreatedDate.Value.Date == DateTime.UtcNow.Date)
                                 on P.DriverId equals DA.DriverId
                                 select new DriverProfileDto
                                 {
                                     
                                     DriverId = P.DriverId,
                                     FullName = P.FirstName + " " + P.LastName,

                                 }).ToListAsync();
            return new ResponseDto<List<DriverProfileDto>>()
            {
                Data = joinData
            };
        }

        public IEnumerable<SelectListItem> SelectAmbulacesForDropDow()
        {
            return _context.TransportEms.Where(x => x.IsActive == false).Select(x => new SelectListItem()
            {
                Text = x.VehicleLicencePlateNo,
                Value = x.TransportId.ToString()
            });
        }

        public async Task<ResponseDto<AmbulanceAssignDriverDto>> AssignAmbulanceToDriver(AmbulanceAssignDriverDto ambulanceAssignDriver)
        {
            try
            {
                var response = new ResponseDto<AmbulanceAssignDriverDto>();
                if (ambulanceAssignDriver.Id > 0)
                {
                    var result = false;
                    var mapper = _mapper.Map<AmbulanceAssignDriverDto, AmbulanceAssignDriver>(ambulanceAssignDriver);
                    var OldEntity = _context.AmbulanceAssignDriver.Where(x => x.Id == ambulanceAssignDriver.Id).FirstOrDefault();
                    if (mapper.TransportId == OldEntity.TransportId)
                    {
                        result = IsExisit((int?)mapper.DriverId, null);
                        if (result)
                        {
                            response.Message = "Driver Already Assigned";
                            return response;
                        }
                    }
                    else if (mapper.TransportId != OldEntity.TransportId)
                    {
                        var oldAmbulanceIfChanged = _context.TransportEms.Where(a => a.TransportId == OldEntity.TransportId).FirstOrDefault();
                        oldAmbulanceIfChanged.IsActive = false;
                        await _context.SaveChangesAsync();

                    }
                    //else if (mapper.DriverId == OldEntity.Result.DriverId)
                    //{
                    //    result = IsExisit(null, mapper.AmbulanceId);
                    //    if (result)
                    //    {
                    //        response.Message = "Ambulance Already Assigned";
                    //        return response;
                    //    }

                    //}
                    mapper.CreatedDate = DateTime.UtcNow;
                    _context.Entry(OldEntity).CurrentValues.SetValues(mapper);
                    _context.SaveChanges();
                    response.Message = "Ambulance Succefully Assigned";

                    var trans = _context.TransportEms.Where(a => a.TransportId == mapper.TransportId).FirstOrDefault();
                    trans.IsActive = true;
                    await _context.SaveChangesAsync();

                }
                else
                {
                    var mapper = _mapper.Map<AmbulanceAssignDriverDto, AmbulanceAssignDriver>(ambulanceAssignDriver);
                    mapper.CreatedDate = DateTime.UtcNow;
                    _context.AmbulanceAssignDriver.Add(mapper);
                    await _context.SaveChangesAsync();

                    var trans = _context.TransportEms.Where(a => a.TransportId == mapper.TransportId).FirstOrDefault();
                    trans.IsActive = true;
                    await _context.SaveChangesAsync();

                    response.Message = "Ambulance Succefully Assigned";
                }


                response.Data = ambulanceAssignDriver;


                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<bool>> AlreadyAssignedAmbulanceDriver(AmbulanceAssignDriverDto ambulanceAssignDriver)
        {
            try
            {
                var response = new ResponseDto<bool>();
                var DriverExisit = await _context.AmbulanceAssignDriver.Where(x => x.DriverId == ambulanceAssignDriver.DriverId).FirstOrDefaultAsync();
                var AmbulanceExisit = await _context.AmbulanceAssignDriver.Where(x => x.TransportId == ambulanceAssignDriver.TransportId).FirstOrDefaultAsync();
                if (DriverExisit != null || AmbulanceExisit != null)
                {
                    if (DriverExisit != null && AmbulanceExisit == null)
                    {
                        response.Message = "Driver Already Have an Ambulance";
                    }
                    else if (AmbulanceExisit != null && DriverExisit == null)
                    {
                        response.Message = "Ambulance Already Assigned to Any Driver";
                    }
                    else
                    {
                        response.Message = "Ambulance/Driver Both Already Assigned";
                    }
                    response.Data = true;
                }
                else
                {
                    response.Data = false;
                }
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<AmbulanceAssignDriverDto>> GetListOfDriverWithAssignedAmbulance()
        {
            try
            {
                var joinData = await (from A in _context.AmbulanceAssignDriver

                                      join E in _context.Employee
                                      on A.DriverId equals E.Employee_id

                                      join T in _context.TransportEms
                                      on A.TransportId equals T.TransportId



                                      select new AmbulanceAssignDriverDto
                                      {
                                          Id = A.Id,
                                          TransportId = (int)T.TransportId,

                                          DriverId = E.Employee_id,
                                          DriverName = E.FirstName + E.LastName

                                      }).ToListAsync();

                return joinData;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<AmbulanceAssignDriverDto>> GetByIdAssignedAmbulance(int Id)
        {
            var data = await _context.AmbulanceAssignDriver.Where(x => x.Id == Id).FirstOrDefaultAsync();
            var mapper = _mapper.Map<AmbulanceAssignDriver, AmbulanceAssignDriverDto>(data);
            var response = new ResponseDto<AmbulanceAssignDriverDto>();
            response.Data = mapper;
            return response;
        }


        public bool IsExisit(int? driverId, int? AmbulanceId)
        {
            var result = false;
            if (driverId != null)
            {
                var DriverExisit = _context.AmbulanceAssignDriver.Where(x => x.DriverId == driverId).FirstOrDefaultAsync();
                if (DriverExisit.Result != null)
                {
                    result = true;
                }
            }
            else if (AmbulanceId != null)
            {
                var AmbulanceExisit = _context.AmbulanceAssignDriver.Where(x => x.TransportId == AmbulanceId).FirstOrDefaultAsync();
                if (AmbulanceExisit.Result != null)
                {
                    result = true;
                }
            }


            return result;
        }

        public async Task<ResponseDto<bool>> DeleteAssignedAmbulance(int Id)
        {
            try
            {
                var result = false;
                var response = new ResponseDto<bool>();
                var entity = _context.AmbulanceAssignDriver.Where(x => x.Id == Id).FirstOrDefault();
                var transport = _context.TransportEms.Where(x => x.TransportId == entity.TransportId).FirstOrDefault();
                transport.IsActive = false;
                await _context.SaveChangesAsync();

                _context.Remove(entity);
                _context.SaveChanges();
                response.Data = result;

                return response;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public Task<List<AmbulanceWithDriver>> AvailabeAmbulance()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<DriverJobRequestDto>> AssignDriverToPickUpPoint(DriverJobRequestDto driverJobRequestDto, string senderName)
        {
            var mapped = _mapper.Map<DriverJobRequest>(driverJobRequestDto);
            mapped.CreatedDate = DateTime.UtcNow;

            await _context.DriverJobRequest.AddAsync(mapped);
            await _context.SaveChangesAsync();


            #region Push Notification & it's thread
            var userDevices = _driverService.GetUserDevices(Convert.ToInt32(driverJobRequestDto.DriverId));
            if (!(userDevices is null) && userDevices.Count > 0)
            {
                PushNotification.SendToMultiple(userDevices.Select(x=>x.DeviceToken).ToList(), NotificationTitle.Title, NotificationTitle.PatientRequest, Convert.ToInt32(NotificationType.DriverJob), senderName);

                var threadList = new List<JobNotificationThreadDto>();

                foreach (var item in userDevices)
                {
                    var threadDto = new JobNotificationThreadDto()
                    {
                        CreatedDate = DateTime.UtcNow,
                        DestinationAddress = driverJobRequestDto.Address,
                        RequestLatitude = driverJobRequestDto.Latitude,
                        RequestLongitude = driverJobRequestDto.Longitude,
                        DriverId = Convert.ToInt32(driverJobRequestDto.DriverId),
                        NotificationTitle = NotificationTitle.PatientRequest,
                        DeviceToken = item.DeviceToken,
                        DeviceTypeId = item.DeviceTypeId.Value
                    };
                    threadList.Add(threadDto);
                }
               

                _notificationService.SaveDriverJobNotifictionThread(threadList);
            }
            #endregion


            #region To update job status
            var requestStatus = new DriverJobRequestStatus()
            {
                CreatedDate = DateTime.UtcNow,
                RequestId = mapped.CurrentRequestID,
                StatusId = Convert.ToInt32(DriverRequestStatusKeys.PickingUp)
            };
            await _context.DriverJobRequestStatus.AddAsync(requestStatus);
            await _context.SaveChangesAsync();
            #endregion

            var entity = _mapper.Map<DriverJobRequestDto>(mapped);
            return new ResponseDto<DriverJobRequestDto>()
            {
                Data = entity
            };
        }

        public IEnumerable<SelectListItem> SelectSelectListForVehicleMake()
        {
            return _context.VehicleMake.Select(x => new SelectListItem()
            {
                Text = x.VehicleMake1,
                Value = x.VehicleMakeId.ToString()
            });
        }

        public IEnumerable<SelectListItem> SelectListForVehicleModel()
        {
            return _context.VehicleModel.Select(x => new SelectListItem()
            {
                Text = x.VehicleModel1,
                Value = x.VehicleModelId.ToString()
            });
        }

        public IEnumerable<SelectListItem> SelectListForVehicleType()
        {
            return _context.VehicleType.Select(x => new SelectListItem()
            {
                Text = x.VehicleType1,
                Value = x.VehicleTypeId.ToString()
            });
        }

        public async Task<ResponseDto<VehicleTypeDto>> AddVehicleType(VehicleTypeDto vehicleType)
        {
            try
            {
                var mapper = _mapper.Map<VehicleTypeDto, VehicleType>(vehicleType);
                var data = await _context.VehicleType.AddAsync(mapper);
                var rec = await _context.SaveChangesAsync();
                var Entity = _mapper.Map<VehicleType, VehicleTypeDto>(mapper);
                return new ResponseDto<VehicleTypeDto>() { Data = Entity, Status = 1, Message = "Success"};
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<VehicleMakeDto>> AddVehicleMake(VehicleMakeDto vehicleMake)
        {
            try
            {
                var mapper = _mapper.Map<VehicleMakeDto, VehicleMake>(vehicleMake);
                var data = await _context.VehicleMake.AddAsync(mapper);
                var rec = await _context.SaveChangesAsync();
                var Entity = _mapper.Map<VehicleMake, VehicleMakeDto>(mapper);
                return new ResponseDto<VehicleMakeDto>() { Data = Entity, Status = 1, Message = "Success" };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<VehicleModelDto>> AddVehicleModel(VehicleModelDto vehicleModel)
        {
            try
            {
                var mapper = _mapper.Map<VehicleModelDto, VehicleModel>(vehicleModel);
                var data = await _context.VehicleModel.AddAsync(mapper);
                var rec = await _context.SaveChangesAsync();
                var Entity = _mapper.Map<VehicleModel, VehicleModelDto>(mapper);
                return new ResponseDto<VehicleModelDto>() { Data = Entity, Status = 1, Message = "Success" };

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<ResponseDto<DriverProfileDto>> DriveCreate(DriverProfileDto driverProfileDto, string[] languages)
        {
            try
            {
                var PatLanguages = string.Empty;

                if (!(languages is null))
                {
                    PatLanguages = string.Join(",", languages);
                    driverProfileDto.Languages = PatLanguages;
                }
                var mapped = _mapper.Map<DriverProfile>(driverProfileDto);

                if (driverProfileDto.WorkingStartTime != null)
                {
                    var startTime = DateFormattor.LocalTimeToUTCTime(driverProfileDto.WorkingStartTime.Value);
                    mapped.WorkingStartTime = startTime;
                }
                if (driverProfileDto.WorkingEndTime != null)
                {
                    var endTime = DateFormattor.LocalTimeToUTCTime(driverProfileDto.WorkingEndTime.Value);
                    mapped.WorkingEndTime = endTime;
                }


                mapped.isActive = true;
                var rec = await _context.DriverProfile.AddAsync(mapped);
                if (!(rec is null))
                {
                    var data = await _context.SaveChangesAsync();
                }
                var userLanguageList = new List<DriverLanguages>();
                var DId = mapped.DriverId;
                if (!(languages is null))
                {
                    foreach (var item in languages)
                    {
                        var userlanguageObj = new DriverLanguages();

                        userlanguageObj.DriverId = DId;
                        userlanguageObj.LangaugeId = Convert.ToInt32(item);
                        userLanguageList.Add(userlanguageObj);
                    }
                    _context.DriverLanguages.AddRange(userLanguageList);
                    _context.SaveChanges();
                }

                var Transport = await _context.TransportEms.FindAsync(mapped.TransportId);
                if (!(Transport is null))
                {
                    Transport.IsAssigned = true;
                    await _context.SaveChangesAsync();

                }

                var entity = _mapper.Map<DriverProfile, DriverProfileDto>(mapped);
                var response = new ResponseDto<DriverProfileDto>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<DriverProfileDto> GetDriveById(int Id)
        {
            var entity = await _context.DriverProfile.Where(x => x.DriverId == Id).FirstOrDefaultAsync();
            var mappedData = _mapper.Map<DriverProfileDto>(entity);
            return mappedData;
        }

        public async Task<ResponseDto<List<DriverProfileDto>>> DriverList()
        {
            //var rec = await _context.DriverProfile.Include(x=>x.Gender).Where(p=>p.isActive == true).ToListAsync();
            var response = new ResponseDto<List<DriverProfileDto>>();
            //response.Data = _mapper.Map<List<DriverProfile>, List<DriverProfileDto>>(rec);
            return response;
        }

        public IEnumerable<SelectListItem> SelectListForLangauges()
        {
            return _context.PatientLanguage.Select(x => new SelectListItem()
            {
                Text = x.LanguageName,
                Value = x.LanguageId.ToString()
            });
        }

        public async Task<ResponseDto<bool>> DriveUpdate(DriverProfileDto driverProfileDto, string[] languages)
        {
            try
            {
                var PatLanguages = string.Empty;

                if (!(languages is null))
                {
                    PatLanguages = string.Join(",", languages);
                    driverProfileDto.Languages = PatLanguages;
                }
                var mapped = _mapper.Map<DriverProfileDto, DriverProfile>(driverProfileDto);
                mapped.isActive = true;

                if (driverProfileDto.WorkingStartTime != null)
                {
                    var startTime = DateFormattor.LocalTimeToUTCTime(driverProfileDto.WorkingStartTime.Value);
                    mapped.WorkingStartTime = startTime;
                }
                if (driverProfileDto.WorkingEndTime != null)
                {
                    var endTime = DateFormattor.LocalTimeToUTCTime(driverProfileDto.WorkingEndTime.Value);
                    mapped.WorkingEndTime = endTime;
                }

                var OldEntity = await _context.DriverProfile.FindAsync(mapped.DriverId);
                var userId = OldEntity.DriverId;
                var previousUserLanguages = _context.DriverLanguages.Where(x => x.DriverId == userId).ToList();
                if (!(previousUserLanguages is null))
                {
                    _context.DriverLanguages.RemoveRange(previousUserLanguages);
                    await _context.SaveChangesAsync();
                }
                _context.Entry(OldEntity).CurrentValues.SetValues(mapped);
                await _context.SaveChangesAsync();
                var userLanguageList = new List<DriverLanguages>();
                var DId = mapped.DriverId;
                if (!(languages is null))
                {
                    foreach (var item in languages)
                    {
                        var userlanguageObj = new DriverLanguages();

                        userlanguageObj.DriverId = DId;
                        userlanguageObj.LangaugeId = Convert.ToInt32(item);
                        userLanguageList.Add(userlanguageObj);
                    }
                    _context.DriverLanguages.AddRange(userLanguageList);
                    _context.SaveChanges();
                }
                var Entity = _mapper.Map<DriverProfile, DriverProfileDto>(mapped);

                if (mapped.TransportId != null)
                {
                    var Transport = await _context.TransportEms.FindAsync(mapped.TransportId);
                    Transport.IsAssigned = true;
                    await _context.SaveChangesAsync();
                }
               



                var response = new ResponseDto<DriverProfileDto>();
                response.Data = Entity;
                return new ResponseDto<bool>() { Data = true, Status = 1, Message = "Success" };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DriveDelete(int Id)
        {
            var rec = _context.DriverProfile.Where(a => a.DriverId == Id).FirstOrDefault();
            if (rec != null)
            {
                rec.isActive = false;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool ChangeDriverStatus(int Id,bool status)
        {
            var rec = _context.DriverProfile.Where(a => a.DriverId == Id).FirstOrDefault();
            var trsportId = rec.TransportId;
            if (rec != null)
            {
                if (!status)
                {
                    if ((bool)rec.IsOwnVehicle)
                    {
                        rec.isActive = status;
                        _context.SaveChanges();
                        var transport = _context.TransportEms.Where(a => a.TransportId == rec.TransportId).FirstOrDefault();
                        transport.IsActive = status;
                        _context.SaveChanges();
                    }
                    else
                    {
                        rec.isActive = status;
                        rec.TransportId = null;
                        _context.SaveChanges();
                        var transport = _context.TransportEms.Where(a => a.TransportId == trsportId).FirstOrDefault();
                        transport.IsAssigned = status;
                        _context.SaveChanges();
                    }
                }
                else
                {
                    if ((bool)rec.IsOwnVehicle)
                    {
                        rec.isActive = status;
                        _context.SaveChanges();
                        var transport = _context.TransportEms.Where(a => a.TransportId == trsportId).FirstOrDefault();
                        transport.IsActive = status;
                        _context.SaveChanges();
                    }
                    else
                    {
                        rec.isActive = status;
                        _context.SaveChanges();
                    }
                }
                
                return true;
            }
            return false;
        }

        public async Task<ResponseDto<TransportEmsDTO>> AddTransport(TransportEmsDTO transportEmsDTO)
        {
            var mapped = _mapper.Map<TransportEmsDTO, TransportEms>(transportEmsDTO);
            //var response = new ResponseDto<TransportEmsDTO>();
            if (transportEmsDTO.TransportId == 0)
            {
                mapped.CreatedDate = DateTime.UtcNow;
                mapped.IsActive = true;
                mapped.IsAssigned = false;
                var dara = await _context.TransportEms.AddAsync(mapped);
                var rec = await _context.SaveChangesAsync();
                var Entity = _mapper.Map<TransportEms, TransportEmsDTO>(mapped);
                //response.Data = Entity;
                if (transportEmsDTO.vehicleAttchments != null && transportEmsDTO.vehicleAttchments.Count > 0)
                {
                    foreach (var item in transportEmsDTO.vehicleAttchments)
                    {
                        var attachments = new TransportAttachments();
                        attachments.AttachmentUrl = item.Url;
                        attachments.IsActive = true;
                        attachments.CreatedDate = DateTime.UtcNow;
                        attachments.TransportId = Entity.TransportId;

                        await _context.AddAsync(attachments);
                        await _context.SaveChangesAsync();
                    }
                }
                return new ResponseDto<TransportEmsDTO>() { Data = Entity, Status = 1 , Message = "Success"};
            }
            else
            {
               
                mapped.ModifiedDate = DateTime.UtcNow;
                mapped.IsActive = true;
                var data = _context.TransportEms.Update(mapped);
                var rec = await _context.SaveChangesAsync();
                var Entity = _mapper.Map<TransportEms, TransportEmsDTO>(mapped);
               
                if (transportEmsDTO.vehicleAttchments != null && transportEmsDTO.vehicleAttchments.Count > 0)
                {
                    var previousList = await _context.TransportAttachments.Where(x => x.TransportId == transportEmsDTO.TransportId).ToListAsync();
                    _context.RemoveRange(previousList);
                    await _context.SaveChangesAsync();
                    foreach (var item in transportEmsDTO.vehicleAttchments)
                    {
                        var attachments = new TransportAttachments();
                        attachments.AttachmentUrl = item.Url;
                        attachments.IsActive = true;
                        attachments.CreatedDate = DateTime.UtcNow;
                        attachments.TransportId = transportEmsDTO.TransportId;

                        await _context.AddAsync(attachments);
                        await _context.SaveChangesAsync();
                    }
                }
               
                //response.Data = Entity;
                return new ResponseDto<TransportEmsDTO>() { Data = Entity, Status = 1, Message = "Success"};
            }
        }

        public bool AmbulanceDelete(int Id)
        {
            var rec = _context.TransportEms.Where(a => a.TransportId == Id).FirstOrDefault();
            if (rec != null)
            {
                rec.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<ResponseDto<DriverProfileDto>> AddUpdateDriverWithOwnVehicle(DriverProfileDto driverProfile, TransportEmsDTO OwnVehicle)
        {

            try
            {
                var response = new ResponseDto<DriverProfileDto>();
                var tranportMapper = _mapper.Map<TransportEmsDTO, TransportEms>(OwnVehicle);
                var driverProfileMapper = _mapper.Map<DriverProfileDto, DriverProfile>(driverProfile);
                if (driverProfile.DriverId > 0)
                {
                    //tranportMapper.ModifiedBy = _sessionManager.GetUserId();
                    tranportMapper.ModifiedDate = DateTime.UtcNow;
                    tranportMapper.IsActive = true;
                    var data = _context.TransportEms.Update(tranportMapper);
                    var rec = await _context.SaveChangesAsync();
                    var Entity = _mapper.Map<TransportEms, TransportEmsDTO>(tranportMapper);




                    driverProfileMapper.isActive = true;
                    driverProfileMapper.IsOwnVehicle = true;
                    driverProfile.TransportId = Entity.TransportId;
                    var OldEntity = await _context.DriverProfile.FindAsync(driverProfileMapper.DriverId);

                    _context.Entry(OldEntity).CurrentValues.SetValues(driverProfileMapper);
                    await _context.SaveChangesAsync();
                    var DriverEntity = _mapper.Map<DriverProfile, DriverProfileDto>(driverProfileMapper);


                }
                else
                {
                    //tranportMapper.CreatedBy = _sessionManager.GetUserId();
                    tranportMapper.CreatedDate = DateTime.UtcNow;
                    tranportMapper.IsActive = true;
                    tranportMapper.IsAssigned = false;
                    var dara = await _context.TransportEms.AddAsync(tranportMapper);
                    var rec = await _context.SaveChangesAsync();
                    var Entity = _mapper.Map<TransportEms, TransportEmsDTO>(tranportMapper);

                    driverProfileMapper.IsOwnVehicle = true;
                    driverProfile.TransportId = Entity.TransportId;

                }

                return response;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public IEnumerable<SelectListItem> VehiclesListForDropDown()
        {
            return _context.TransportEms.Where(x => x.IsAssigned == false && x.IsActive == true).Select(x => new SelectListItem()
            {
                Text = Convert.ToString(x.TransportId),
                Value = x.TransportId.ToString()
            });
        }

        public async Task<ResponseDto<List<DriverProfileDto>>> GetDriverDetailList(int? Id = null)
        {
            await using var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);
            var result = await conn.QueryAsync<string>(sql: "[dbo].[spGetDriverList]",
                param: new { driverId = Id },
            commandType: CommandType.StoredProcedure);
            var builder = new StringBuilder();
            foreach (var r in result)
            {
                builder.Append(r);
            }
            var response = JsonConvert.DeserializeObject<List<DriverProfileDto>>(builder.ToString());
            return new ResponseDto<List<DriverProfileDto>>()
            {
                Data = response,
                Status = 1,
                Message = "Success"
            };
        }

        public async Task<ResponseDto<TransportEmsDTO>> GetTransportRecordByDriverId(int Id)
        {
            var DriverRec = await _context.DriverProfile.FirstOrDefaultAsync(x => x.DriverId == Id);
            var TransportRec = await _context.TransportEms.FirstOrDefaultAsync(x => x.TransportId == DriverRec.TransportId);
            var Entity = _mapper.Map<TransportEms, TransportEmsDTO>(TransportRec);
            var response = new ResponseDto<TransportEmsDTO>();
            response.Data = Entity;
            return new ResponseDto<TransportEmsDTO>() { Data = response.Data, Status = 1, Message = "Success" };
        }

        public async Task<ResponseDto<bool>> EmailisExistorNot(string email)
        {
            bool isExist = false;


            var empRecord = await _context.DriverProfile.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if (!(empRecord is null))
            {
                isExist = true;
            }

            return new ResponseDto<bool>()
            {
                Data = isExist,
                Message = "Email is already exist",
                Status = 3
            };
        }

        public async Task<ResponseDto<DriverProfileApiDto>> GetDriverDetailById(int? Id = null)
        {
            await using var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);
            var result = await conn.QueryAsync<string>(sql: "[dbo].[spGetDriverList]",
                param: new { driverId = Id },
            commandType: CommandType.StoredProcedure);
            var builder = new StringBuilder();
            foreach (var r in result)
            {
                builder.Append(r);
            }
            var response = JsonConvert.DeserializeObject<DriverProfileApiDto>(builder.ToString());

            //if (rec.WorkingStartTime != null)
            //{
            //    profileMapped.StartTime = rec.WorkingStartTime.ToString();
            //    var index = profileMapped.StartTime.LastIndexOf(":");
            //    profileMapped.StartTime = profileMapped.StartTime.Substring(0, index);
            //}
            //if (rec.WorkingEndTime != null)
            //{
            //    profileMapped.EndTime = rec.WorkingEndTime.ToString();
            //    var index = profileMapped.EndTime.LastIndexOf(":");
            //    profileMapped.EndTime = profileMapped.EndTime.Substring(0, index);
            //}

            return new ResponseDto<DriverProfileApiDto>()
            {
                Data = response,
                Status = 1,
                Message = "Success"
            };
        }

        public async Task<ResponseDto<DriverVehicleDetailDto>> DriverVehicleDetail(int Id)
        {
            var response = new ResponseDto<DriverVehicleDetailDto>();
            int? VehicleId = null;
            var DriverRec = await _context.DriverProfile.FirstOrDefaultAsync(x => x.DriverId == Id);
            if (!(DriverRec is null))
            {
                VehicleId = DriverRec.TransportId;
            }
            var joinData = await (from P in _context.TransportEms.Where(x => x.TransportId == VehicleId)


                                  join VM in _context.VehicleMake
                                  on P.VehicleMakeId equals VM.VehicleMakeId

                                  join VModel in _context.VehicleModel
                                  on P.VehicleModelId equals VModel.VehicleModelId

                                  join VType in _context.VehicleType
                                  on P.VehicleTypeId equals VType.VehicleTypeId


                                  select new DriverVehicleDetailDto
                                  {
                                      TransportId = P.TransportId,
                                      VehicleType = VType.VehicleType1,
                                      VehicleMake = VM.VehicleMake1,
                                      VehicleModel = VModel.VehicleModel1,
                                      VehicleCapacity = P.VehicleCapacity,
                                      VehicleLicencePlateNo = P.VehicleLicencePlateNo,
                                      VehicleRegistrationState = P.VehicleRegistrationState,
                                      VehicleVINNo = P.VehicleVINNo,
                                      VehicleColor = P.VehicleColor,
                                      VehiclePhoto = P.VehiclePhoto,
                                      VehicleMakeId = P.VehicleMakeId.Value,
                                      VehicleModelId = P.VehicleModelId.Value,
                                      VehicleTypeId = P.VehicleTypeId.Value,
                                      LicenseIssueDate = P.LicenseIssueDate,
                                      LicenseExpireDate = P.LicenseExpireDate,
                                      vehicleAttchments = P.TransportAttachments.Select(x => x.AttachmentUrl)
                                  }).FirstOrDefaultAsync();
            var mapped = joinData;
            if (!(mapped is null))
            {
                return new ResponseDto<DriverVehicleDetailDto>()
                {
                    Data = mapped,
                    Message = "Success"
                };
            }
            else
            {
                return new ResponseDto<DriverVehicleDetailDto>()
                {
                    Data = mapped,
                    Message = "Invalid driver Id"
                };
            }

        }

        public async Task<ResponseDto<List<Models.ApiDtos.Langauges>>> LanguageList()
        {
            var joinData = await (from P in _context.PatientLanguage

                                  select new Models.ApiDtos.Langauges
                                  {
                                      LanguageId = P.LanguageId,
                                      LanguageName = P.LanguageName
                                  }).ToListAsync();
            return new ResponseDto<List<Models.ApiDtos.Langauges>>()
            {
                Data = joinData,
                Message = "SucessFull"
            };
        }

        public async Task<ResponseDto<bool>> VehicleNumberExist(string vehicleNumber)
        {
            bool isExist = false;


            var empRecord = await _context.TransportEms.FirstOrDefaultAsync(x => x.VehicleLicencePlateNo.ToLower() == vehicleNumber.ToLower());
            if (!(empRecord is null))
            {
                isExist = true;
            }

            return new ResponseDto<bool>()
            {
                Data = isExist,
                Message = "Vehicle Number is already exist",
                Status = 3
            };
        }

        public async Task<ResponseDto<DriverProfileUpdateDto>> DriverProfileUpdateApi(DriverProfileUpdateDto driverProfileUpdateDto)
        {
            try
            {

                var mapped = _mapper.Map<DriverProfileUpdateDto, DriverProfile>(driverProfileUpdateDto);
                if (driverProfileUpdateDto.Gender == "Male" || driverProfileUpdateDto.Gender == "male")
                {
                    mapped.GenderId = 34;
                }
                else if (driverProfileUpdateDto.Gender == "Female" || driverProfileUpdateDto.Gender == "female")
                {
                    mapped.GenderId = 35;
                }
                else
                {
                    mapped.GenderId = 36;
                }
                mapped.isActive = true;
                var OldEntity = await _context.DriverProfile.FindAsync(mapped.DriverId);
                driverProfileUpdateDto.Email = OldEntity.Email;
                driverProfileUpdateDto.Password = OldEntity.Password;
                _context.Entry(OldEntity).CurrentValues.SetValues(mapped);
                var userId = OldEntity.DriverId;
                var previousUserLanguages = _context.DriverLanguages.Where(x => x.DriverId == userId).ToList();
                if (!(previousUserLanguages is null))
                {
                    _context.DriverLanguages.RemoveRange(previousUserLanguages);
                    await _context.SaveChangesAsync();
                }
                await _context.SaveChangesAsync();
                var userLanguageList = new List<DriverLanguages>();
                var DId = mapped.DriverId;
                if (!(mapped.Languages is null))
                {
                    foreach (var item in mapped.Languages)
                    {
                        var userlanguageObj = new DriverLanguages();

                        userlanguageObj.DriverId = DId;
                        userlanguageObj.LangaugeId = Convert.ToInt32(item);
                        userLanguageList.Add(userlanguageObj);
                    }
                    _context.DriverLanguages.AddRange(userLanguageList);
                    _context.SaveChanges();
                }
                var Entity = _mapper.Map<DriverProfile, DriverProfileUpdateDto>(mapped);
                return new ResponseDto<DriverProfileUpdateDto>() { Data = Entity, Status = 1, Message = "Success" };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<List<DriverProfileDto>>> AvailableDriverListForResptionisit()
        {
            var joinData = await (from P in _context.DriverProfile


                                  join T in _context.TransportEms
                                  on P.TransportId equals T.TransportId

                                  //join DA in _context.DriverAvailability.Where(x => x.StatusId == true)
                                  //on P.DriverId equals DA.DriverId

                                  join DT in _context.DriverAttendance.Where(x=>x.AttendanceTypeId == Convert.ToInt32(AttendanceKeys.CheckIn) && x.CreatedDate.Value.Date == DateTime.UtcNow.Date)
                                  on P.DriverId equals DT.DriverId

                                  select new DriverProfileDto
                                  {
                                      TransportId = P.TransportId,
                                      DriverId = P.DriverId,
                                      FullName = P.FirstName + " " + P.LastName,
                                  }).ToListAsync();
            return new ResponseDto<List<DriverProfileDto>>()
            {
                Data = joinData
            };
        }

        public async Task<ResponseDto<List<DriverCurrentLocationBasicDto>>> DriverCurrentLocationForMap(long? Id)
        {
            await using var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);
            var result = await conn.QueryAsync<DriverCurrentLocationBasicDto>(sql: "[dbo].[spGetDriverCurrentLocation]",
               param: new { driverId = Id },

            commandType: CommandType.StoredProcedure);
            var response = result.ToList();
            return new ResponseDto<List<DriverCurrentLocationBasicDto>>()
            {
                Data = response,
                Status = 1,
                Message = "Success"
            };
        }

        public async Task<ResponseDto<List<DriverProfileDto>>> AvailableDriverJobStatus()
        {

            var joinData = await(from P in _context.DriverProfile


                                 join T in _context.TransportEms
                                 on P.TransportId equals T.TransportId

                                 join DA in _context.DriverAttendance.Where(x => x.AttendanceTypeId == Convert.ToInt32(AttendanceKeys.CheckIn) && x.CreatedDate.Value.Date == DateTime.UtcNow.Date)
                                 on P.DriverId equals DA.DriverId

                                 join DJ in _context.DriverJobRequest.Where(x=>x.CreatedDate.Value.Date == DateTime.UtcNow.Date).OrderByDescending(x => x.CurrentRequestID)
                                 on P.DriverId equals DJ.DriverId

                                 join DJS in _context.DriverJobRequestStatus
                                 on DJ.CurrentRequestID equals DJS.RequestId

                                 join L in _context.Lookups
                                 on DJS.StatusId equals L.LookupId

                                 select new DriverProfileDto
                                 {
                                     TransportId = P.TransportId,
                                     DriverId = P.DriverId,
                                     FullName = P.FirstName + " " + P.LastName,
                                     DriverCurrentJobStatus = L.LookupValue,
                                     PickUpLocation = DJ.Address,
                                     DestinationLocation = DJ.DAddress
                                 }).ToListAsync();
            return new ResponseDto<List<DriverProfileDto>>()
            {
                Data = joinData
            };
        }

        public async Task<ResponseDto<List<DriverDirectionForMap>>> DriverDirectionForMap(long? DriverId)
        {
            if (!(DriverId is null))
            {
                var joinData = await (from DJ in _context.DriverJobRequest.Where(x=>x.DriverId == DriverId)


                                      join DJS in _context.DriverJobRequestStatus
                                      on DJ.CurrentRequestID equals DJS.RequestId

                                      join DC in _context.DriverCurrentLocation
                                      on DJ.DriverId equals DC.DriverId

                                      join D in _context.DriverProfile
                                      on DJ.DriverId equals D.DriverId

                                      join DA in _context.DriverAttendance.Where(x => x.AttendanceTypeId == 172 && x.CreatedDate.Value.Date == DateTime.UtcNow.Date)
                                      on D.DriverId equals DA.DriverId

                                      join L in _context.Lookups
                                      on DJS.StatusId equals L.LookupId

                                      select new DriverDirectionForMap
                                      {

                                          DriverId = DJ.DriverId,
                                          FullName = D.FirstName + " " + D.LastName,
                                          PLat = DJ.Latitude,
                                          PLng = DJ.Longitude,
                                          DLat = DJ.DLatitude,
                                          DLng = DJ.DLongitude,
                                          CLat = DC.Driverlat,
                                          CLng = DC.Driverlng,
                                          Status = L.LookupValue,
                                          StatusId = DJS.StatusId,
                                          PickUpLocation = DJ.Address,
                                          DestinationLocation = DJ.DAddress
                                      }).ToListAsync();
                return new ResponseDto<List<DriverDirectionForMap>>()
                {
                    Data = joinData
                };
            }
            else
            {
                var joinData = await (from DJ in _context.DriverJobRequest


                                      join DJS in _context.DriverJobRequestStatus
                                      on DJ.CurrentRequestID equals DJS.RequestId

                                      join DC in _context.DriverCurrentLocation
                                      on DJ.DriverId equals DC.DriverId

                                      join D in _context.DriverProfile
                                      on DJ.DriverId equals D.DriverId

                                      join DA in _context.DriverAttendance.Where(x => x.AttendanceTypeId == 172 && x.CreatedDate.Value.Date == DateTime.UtcNow.Date)
                                      on D.DriverId equals DA.DriverId

                                      join L in _context.Lookups
                                      on DJS.StatusId equals L.LookupId

                                      select new DriverDirectionForMap
                                      {

                                          DriverId = DJ.DriverId,
                                          FullName = D.FirstName + " " + D.LastName,
                                          PLat = DJ.Latitude,
                                          PLng = DJ.Longitude,
                                          DLat = DJ.DLatitude,
                                          DLng = DJ.DLongitude,
                                          CLat = DC.Driverlat,
                                          CLng = DC.Driverlng,
                                          Status = L.LookupValue,
                                          StatusId = DJS.StatusId,
                                          PickUpLocation = DJ.Address,
                                          DestinationLocation = DJ.DAddress
                                      }).ToListAsync();
                return new ResponseDto<List<DriverDirectionForMap>>()
                {
                    Data = joinData
                };
            }
            
        }



        #region For API
        public async Task<ResponseDto<List<VehicleMake>>> GetVehicleMakers()
        {
           var list = await _context.VehicleMake.ToListAsync();
            return new ResponseDto<List<VehicleMake>>() { Data = list, Message = "Success", Status = 1 };
        }

        public async Task<ResponseDto<List<VehicleModel>>> GetVehicleModels()
        {
            var list = await _context.VehicleModel.ToListAsync();
            return new ResponseDto<List<VehicleModel>>() { Data = list, Message = "Success", Status = 1 };
        }

        public async Task<ResponseDto<List<VehicleType>>> GetVehicleTypes()
        {
            var list = await _context.VehicleType.ToListAsync();
            return new ResponseDto<List<VehicleType>>() { Data = list, Message = "Success", Status = 1 };
        }


        public async Task<ResponseDto<bool>> UpdateTransportForAPI(UpdateTransportApiDto transportEmsDTO)
        {
            try
            {
                _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                var oldEntity = await _context.TransportEms.FindAsync(transportEmsDTO.TransportId);
                var transport = new TransportEms();

                if (!(oldEntity is null))
                {
                    transport = mappedObj(transportEmsDTO, oldEntity);
                }
                _context.Entry(transport).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var previousList = await _context.TransportAttachments.Where(x => x.TransportId == transportEmsDTO.TransportId).ToListAsync();
                _context.RemoveRange(previousList);
                await _context.SaveChangesAsync();


                if (transportEmsDTO.vehicleAttchments != null)
                {
                    foreach (var item in transportEmsDTO.vehicleAttchments)
                    {
                        var attachments = new TransportAttachments();
                        attachments.AttachmentUrl = item;
                        attachments.IsActive = true;
                        attachments.CreatedDate = DateTime.UtcNow;
                        attachments.TransportId = transportEmsDTO.TransportId;

                        await _context.AddAsync(attachments);
                        await _context.SaveChangesAsync();
                    }
                }

                var entity = _mapper.Map<TransportEms, TransportEmsDTO>(transport);
            }
            catch (Exception ex)
            {

                return new ResponseDto<bool>() { Data = false, Status = 1, Message = "Failure" };
            }
            
            return new ResponseDto<bool>() { Data = true, Status = 1, Message = "Success" };
        }


        public TransportEms mappedObj(UpdateTransportApiDto sourceTransport, TransportEms transportEms)
        {
            transportEms.TransportId = sourceTransport.TransportId;

            transportEms.VehicleTypeId = sourceTransport.VehicleTypeId == null ? transportEms.VehicleTypeId : sourceTransport.VehicleTypeId;
            transportEms.VehicleMakeId = sourceTransport.VehicleMakeId == null ? transportEms.VehicleMakeId : sourceTransport.VehicleMakeId;
            transportEms.VehicleModelId = sourceTransport.VehicleModelId == null ? transportEms.VehicleModelId : sourceTransport.VehicleModelId;

            transportEms.VehicleCapacity = sourceTransport.VehicleCapacity == null ? transportEms.VehicleCapacity : sourceTransport.VehicleCapacity;
            transportEms.VehicleLicencePlateNo = sourceTransport.VehicleLicencePlateNo == null ? transportEms.VehicleLicencePlateNo : sourceTransport.VehicleLicencePlateNo;
            transportEms.VehicleRegistrationState = sourceTransport.VehicleRegistrationState == null ? transportEms.VehicleRegistrationState : sourceTransport.VehicleRegistrationState;
            transportEms.VehicleVINNo = sourceTransport.VehicleVINNo == null ? transportEms.VehicleVINNo : sourceTransport.VehicleVINNo;

            transportEms.VehicleColor = sourceTransport.VehicleColor == null ? transportEms.VehicleColor : sourceTransport.VehicleColor;
            transportEms.VehiclePhoto = sourceTransport.VehiclePhoto == null ? transportEms.VehiclePhoto : sourceTransport.VehiclePhoto;

            transportEms.IsAssigned = sourceTransport.IsAssigned == null ? transportEms.IsAssigned : sourceTransport.IsAssigned;
            transportEms.CreatedDate = sourceTransport.CreatedDate == null ? transportEms.CreatedDate : sourceTransport.CreatedDate;
            transportEms.IsActive = sourceTransport.IsActive == null ? transportEms.IsActive : sourceTransport.IsActive;

            transportEms.ModifiedDate = DateTime.UtcNow;
            transportEms.ModifiedBy = sourceTransport.ModifiedBy == null ? transportEms.ModifiedBy : sourceTransport.ModifiedBy;

            transportEms.LicenseIssueDate = sourceTransport.LicenseIssueDate == null ? transportEms.LicenseIssueDate : sourceTransport.LicenseIssueDate;
            transportEms.LicenseExpireDate = sourceTransport.LicenseExpireDate == null ? transportEms.LicenseExpireDate : sourceTransport.LicenseExpireDate;
         

            return transportEms;
        }

        public int GetMaxLatestVehicle()
        {
            var patientId = _context.TransportEms.Max(x => x.TransportId);
            var nextId = patientId + 1;
            return nextId;
        }

        public List<Models.DTOs.VehicleAttchmentsDto> GetVehicleAttachmentsById(int transportId)
        {
            try
            {
                var count = 0;
                var urlList = new List<Models.DTOs.VehicleAttchmentsDto>();
                var attachmentsList = _context.TransportAttachments.Where(x => x.TransportId == transportId).ToList();
                if (attachmentsList.Count > 0)
                {
                    foreach (var item in attachmentsList)
                    {

                        var attachment = new Models.DTOs.VehicleAttchmentsDto();
                        attachment.Url= item.AttachmentUrl;
                        urlList.Add(attachment);
                    }
                }
                return urlList;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TransportDetailsDto> GetTransportDetailsId(int transportId)
        {
            try
            {
                var trans = await _context.TransportEms.Include(x=>x.VehicleMake).Include(x=>x.VehicleModel).Include(x=>x.VehicleType).Where(a => a.TransportId == transportId).FirstOrDefaultAsync();
                var mapped = _mapper.Map<TransportEms, TransportDetailsDto>(trans);
                return mapped;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<List<DriverProfileDto>>> DriverJobRequestStatus()
        {
            var joinData = await(from P in _context.DriverProfile


                                 join T in _context.TransportEms
                                 on P.TransportId equals T.TransportId

                                 join DJ in _context.DriverJobRequest.Where(x => x.CreatedDate.Value.Date == DateTime.UtcNow.Date).OrderByDescending(x => x.CurrentRequestID)
                                 on P.DriverId equals DJ.DriverId

                                 join DJS in _context.DriverJobRequestStatus
                                 on DJ.CurrentRequestID equals DJS.RequestId

                                 join L in _context.Lookups
                                 on DJS.StatusId equals L.LookupId

                                 select new DriverProfileDto
                                 {
                                     TransportId = P.TransportId,
                                     DriverId = P.DriverId,
                                     FullName = P.FirstName + " " + P.LastName,
                                     DriverCurrentJobStatus = L.LookupValue,
                                     PickUpLocation = DJ.Address,
                                     DestinationLocation = DJ.DAddress,
                                     JobRequestId = (int)DJ.CurrentRequestID
                                 }).ToListAsync();
            return new ResponseDto<List<DriverProfileDto>>()
            {
                Data = joinData
            };
        }


        #endregion
    }
}
