using AutoMapper;
using MediClinic.Models.ApiDtos;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.SMSDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces;
using MedliClinic.Utilities.Utility;
using MedliClinic.Utilities.Utility.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services
{
    public class DriverService : IDriverService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public DriverService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ResponseDto<DriverAvailabilityDto>> driverAvailability(DriverAvailabilityDto driverAvailabilityDto)
        {
            var mapped = _mapper.Map<DriverAvailability>(driverAvailabilityDto);
            var Availablity = await _context.DriverAvailability.FirstOrDefaultAsync(x => x.DriverId == driverAvailabilityDto.DriverId);
            if (!(Availablity is null))
            {
                if (driverAvailabilityDto.DriverId > 0)
                {
                    Availablity.StatusId = driverAvailabilityDto.StatusId;
                    Availablity.CreatedDate = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                mapped.CreatedDate = DateTime.UtcNow;
                await _context.DriverAvailability.AddAsync(mapped);
                await _context.SaveChangesAsync();
            }
            return new ResponseDto<DriverAvailabilityDto>()
            {
                Message = "success",
                Status = 1,
                Data = null
            };
        }

        public async Task<ResponseDto<DriverCurrentLocationDto>> DriverCurrentLocation(DriverCurrentLocationDto driverCurrentLocationDto)
        {
            var mapped = _mapper.Map<DriverCurrentLocation>(driverCurrentLocationDto);
            var Availablity = await _context.DriverCurrentLocation.FirstOrDefaultAsync(x => x.DriverId == driverCurrentLocationDto.DriverId 
             && x.CreatedDate.Value.Date == DateTime.UtcNow.Date);

            if (!(Availablity is null))
            {
                Availablity.Driverlat = driverCurrentLocationDto.Driverlat;
                Availablity.Driverlng = driverCurrentLocationDto.Driverlng;
                await _context.SaveChangesAsync();
            }
            else
            {
                mapped.CreatedDate = DateTime.UtcNow;
                await _context.DriverCurrentLocation.AddAsync(mapped);
                await _context.SaveChangesAsync();
            }
            return new ResponseDto<DriverCurrentLocationDto>()
            {
                Message = "Successfull"
            };
        }

        public async Task<ResponseDto<bool>> UpdateDriverAvailability(DriverAvailabilityDto dtoModel, string status)
        {
            try
            {
                var mappedData = _mapper.Map<DriverAvailability>(dtoModel);
                mappedData.CreatedDate = DateTime.UtcNow;

                if (status.Equals(DriverStatuses.Active))
                {
                    mappedData.StatusId = true;
                }
                else if (status.Equals(DriverStatuses.Offline))
                {
                    mappedData.StatusId = false;
                }

                
                var oldEntity = _context.DriverAvailability.Find(dtoModel.DriverId);
                if (oldEntity is null)
                {
                    _context.DriverAvailability.Add(mappedData);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Entry(oldEntity).CurrentValues.SetValues(mappedData);
                    _context.SaveChanges();
                }
               
                return new ResponseDto<bool>();
            }
            catch (Exception ex)
            {

                return new ResponseDto<bool>() { Data = false, Status = 0 };
            }
        }


        public async Task<ResponseDto<bool>> GetDriverActiveStatus(int driverId)
        {
            var entity = await _context.DriverAvailability.FirstOrDefaultAsync(x => x.DriverId == driverId);
            if (entity is null || entity.StatusId.Equals(false))
            {
                return new ResponseDto<bool>() { Data = false, Status = 1, Message = "success" };
            }
            return new ResponseDto<bool>() { Data = true, Status = 1, Message = "success" };
        }

        public async Task<ResponseDto<bool>> UpdateDriverActiveStatus(DriverAvailabilityDto availabilityDto)
        {

            var entity = await _context.DriverAvailability.FirstOrDefaultAsync(x => x.DriverId == availabilityDto.DriverId);
            if (entity is null || entity.StatusId.Equals(false))
            {
                return new ResponseDto<bool>() { Data = false, Status = 1, Message = "success" };
            }
            return new ResponseDto<bool>() { Data = true, Status = 1, Message = "success" };
        }


        public List<UserDevices> GetUserDevices(int driverId)
        {
            var entity = _context.UserDevices.OrderByDescending(x => x.UserDeviceId).Where(x => x.UserId == driverId).ToList();
            return entity;
        }




        public async Task<ResponseDto<bool>> UpdateDriverJobRequestStatus(DriverJobRequestStatusDto dtoModel)
        {
            try
            {
                var mappedData = _mapper.Map<DriverJobRequestStatus>(dtoModel);
                mappedData.CreatedDate = DateTime.UtcNow;
                mappedData.RequestId = dtoModel.RequestId;

                if (dtoModel.StatusId.ToString().Equals(DriverRequestStatus.PickingUp))
                {
                    mappedData.StatusId = Convert.ToInt32(DriverRequestStatusKeys.PickingUp);
                }
                else if (dtoModel.StatusId.ToString().Equals(DriverRequestStatus.Arrived))
                {
                    mappedData.StatusId = Convert.ToInt32(DriverRequestStatusKeys.Arrived);
                    var requestData = await GetPatientJobRequestById(dtoModel.RequestId);
                    if (string.IsNullOrEmpty(requestData.CallerName))
                    {
                        requestData.CallerName = "Caller";
                    }
                    var smsObj = new SmsDto { PhoneNo = requestData.CallerPhoneNo, TextMsg = string.Format(NotificationTitle.ArrivalMessage,requestData.CallerName, requestData.Driver.FirstName + ' ' + requestData.Driver.LastName, requestData.CallerPhoneNo) };
                    var status = CommonMethod.SendSms(smsObj);
                }
                else if (dtoModel.StatusId.ToString().Equals(DriverRequestStatus.OnTheWay))
                {
                    mappedData.StatusId = Convert.ToInt32(DriverRequestStatusKeys.OnTheWay);
                }
                else if (dtoModel.StatusId.ToString().Equals(DriverRequestStatus.Finished))
                {
                    mappedData.StatusId = Convert.ToInt32(DriverRequestStatusKeys.Finished);
                } 


                var oldEntity = _context.DriverJobRequestStatus.FirstOrDefault(x => x.RequestId == dtoModel.RequestId);
                if (!(oldEntity is null))
                {
                    oldEntity.StatusId = mappedData.StatusId;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.DriverJobRequestStatus.Add(mappedData);
                    await _context.SaveChangesAsync();
                }

                return new ResponseDto<bool>() { Data = true, Status = 1, Message = "Success" };
            }
            catch (Exception ex)
            {

                return new ResponseDto<bool>() { Data = false, Status = 0 };
            }
        }

        public async Task<ResponseDto<LatestJobDto>> GetDriverLatestJob(int driverId)
        {
            try
            {
                var response = await (from Dj in _context.DriverJobRequest.OrderByDescending(x => x.CurrentRequestID).Where(x => x.DriverId == driverId)

                                      join DjS in _context.DriverJobRequestStatus
                                      on Dj.CurrentRequestID equals DjS.RequestId

                                      join L in _context.Lookups
                                      on DjS.StatusId equals L.LookupId

                                      select new LatestJobDto
                                      {
                                          CallerName = Dj.CallerName,
                                          CallerPhoneNo = Dj.CallerPhoneNo,
                                          PickUpLatitude = Dj.Latitude,
                                          PickUpLongitutde = Dj.Longitude,
                                          PickUpAddress = Dj.Address,

                                          DestinationLatitude = Dj.DLatitude,
                                          DestinationLongitutde = Dj.DLongitude,
                                          DestinationAddress = Dj.DAddress,

                                          RequestId = DjS.RequestId.Value,
                                          CurrentStatus = L.LookupValue,
                                          DriverId = Dj.DriverId.Value,
                                          CreatedDate = Dj.CreatedDate.Value
                                      }

                      ).FirstOrDefaultAsync();
                if ((response is null))
                {
                    return new ResponseDto<LatestJobDto>() { Data = null, Status = 1, Message = "success" };
                }

                return new ResponseDto<LatestJobDto>() { Data = response, Status = 1, Message = "success" };
            }
            catch (Exception ex)
            {

                throw;
            }

        }



        //To update driver profile
        public async Task<ResponseDto<bool>> DriverProfileUpdateApi(DriverProfileUpdateDto driverProfileUpdateDto)
        {
            try
            {
                _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                var oldEntity = await _context.DriverProfile.FindAsync(driverProfileUpdateDto.DriverId);

                var profile = new DriverProfile();
                if (!(oldEntity is null))
                {
                    if (!string.IsNullOrEmpty(driverProfileUpdateDto.Gender))
                    {
                        if (driverProfileUpdateDto.Gender.ToLower().Equals("male"))
                        {
                            oldEntity.GenderId = Convert.ToInt32(GenderKeys.Male);
                        }
                        else if (driverProfileUpdateDto.Gender.ToLower().Equals("female"))
                        {
                            oldEntity.GenderId = Convert.ToInt32(GenderKeys.Female);
                        }
                        else
                        {
                            oldEntity.GenderId = Convert.ToInt32(GenderKeys.Other);
                        }
                    }
                    profile = mappedObj(driverProfileUpdateDto, oldEntity);
                }

                profile.isActive = true;
                _context.Entry(profile).State = EntityState.Modified;
                var result = await _context.SaveChangesAsync();




                var previousDriverLanguages = _context.DriverLanguages.Where(x => x.DriverId == oldEntity.DriverId).ToList();
                if (!(previousDriverLanguages is null))
                {
                    _context.DriverLanguages.RemoveRange(previousDriverLanguages);
                    await _context.SaveChangesAsync();
                }

                var userLanguageList = new List<DriverLanguages>();

                if (!(driverProfileUpdateDto.Languages is null))
                {
                    var langList = driverProfileUpdateDto.Languages.Split(',').ToList();
                    langList = langList.Select(x => x.Trim()).ToList();

                    var allLanguages = await _context.PatientLanguage.Where(x => langList.Contains(x.LanguageName)).ToListAsync();
                    if (allLanguages.Count > 0)
                    {
                        foreach (var item in allLanguages)
                        {
                            var userlanguageObj = new DriverLanguages();

                            userlanguageObj.DriverId = oldEntity.DriverId;
                            userlanguageObj.LangaugeId = Convert.ToInt32(item.LanguageId);
                            userLanguageList.Add(userlanguageObj);
                        }
                    }

                    _context.DriverLanguages.AddRange(userLanguageList);
                    _context.SaveChanges();
                }

                return new ResponseDto<bool>() { Data = true, Status = 1, Message = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseDto<bool>() { Data = false, Status = 1, Message = "failure" };
            }
        }


        public DriverProfile mappedObj(DriverProfileUpdateDto sourceProfile, DriverProfile profile)
        {
            profile.DriverId = sourceProfile.DriverId;
            profile.FirstName = sourceProfile.FirstName == null ? profile.FirstName : sourceProfile.FirstName;
            profile.MiddleName = sourceProfile.MiddleName == null ? profile.MiddleName : sourceProfile.MiddleName;
            profile.LastName = sourceProfile.LastName == null ? profile.LastName : sourceProfile.LastName;
            profile.Address = sourceProfile.Address == null ? profile.Address : sourceProfile.Address;
            profile.AddressLine2 = sourceProfile.AddressLine2 == null ? profile.AddressLine2 : sourceProfile.AddressLine2;
            profile.AddressLine3 = sourceProfile.AddressLine3 == null ? profile.AddressLine3 : sourceProfile.AddressLine3;
            profile.ZipCode = sourceProfile.ZipCode == null ? profile.ZipCode : sourceProfile.ZipCode;
            profile.City = sourceProfile.City == null ? profile.City : sourceProfile.City;
            profile.State = sourceProfile.State == null ? profile.State : sourceProfile.State;
            profile.MobilePhone = sourceProfile.MobilePhone == null ? profile.MobilePhone : sourceProfile.MobilePhone;
            profile.HomePhone = sourceProfile.HomePhone == null ? profile.HomePhone : sourceProfile.HomePhone;
            profile.EmergencyPhone = sourceProfile.EmergencyPhone == null ? profile.EmergencyPhone : sourceProfile.EmergencyPhone;
            profile.OtherPhone = sourceProfile.OtherPhone == null ? profile.OtherPhone : sourceProfile.OtherPhone;
            profile.Email = sourceProfile.Email == null ? profile.Email : sourceProfile.Email;
            profile.DOB = sourceProfile.DOB == null ? profile.DOB : sourceProfile.DOB;
            profile.SSNNumber = sourceProfile.SSNNumber == null ? profile.SSNNumber : sourceProfile.SSNNumber;
            profile.DriverLicence = sourceProfile.DriverLicence == null ? profile.DriverLicence : sourceProfile.DriverLicence;

            profile.LicenseState = sourceProfile.LicenseState == null ? profile.LicenseState : sourceProfile.LicenseState;
            profile.LicenseClass = sourceProfile.LicenseClass == null ? profile.LicenseClass : sourceProfile.LicenseClass;
            profile.DriverImage = sourceProfile.DriverImage == null ? profile.DriverImage : sourceProfile.DriverImage;


            profile.DriverSignature = sourceProfile.DriverSignature == null ? profile.DriverSignature : sourceProfile.DriverSignature;
            profile.Password = sourceProfile.Password == null ? profile.Password : sourceProfile.Password;

            return profile;
        }


        public async Task<ResponseDto<bool>> CreateDriverAttendance(AttendanceDto attendanceDto)
        {
            try
            {
                var updateAttendance = await _context.DriverAttendance.FirstOrDefaultAsync(x => x.CreatedDate.Value.Date == DateTime.UtcNow.Date && x.DriverId == attendanceDto.DriverId);

                if (updateAttendance == null && attendanceDto.AttendanceStatus == Convert.ToInt32(AttendanceStatus.CheckIn))
                {
                    var attendance = new DriverAttendance
                    {
                        CreatedDate = DateTime.UtcNow,
                        DriverId = Convert.ToInt32(attendanceDto.DriverId),
                        AttendanceTypeId = Convert.ToInt32(AttendanceKeys.CheckIn),
                        CheckIn = DateTime.UtcNow.TimeOfDay
                    };

                    _context.DriverAttendance.Add(attendance);
                    var resultStatus = await _context.SaveChangesAsync();
                    return resultStatus > 0 ? new ResponseDto<bool>() { Data = true, Status = 1, Message = "Checked In Successfully!" } : new ResponseDto<bool>() { Data = false, Status = 0 };
                }

                else if (updateAttendance != null && updateAttendance.AttendanceTypeId == Convert.ToInt32(AttendanceKeys.CheckOut))
                {
                    return new ResponseDto<bool>() { Data = true, Status = 1, Message = "You are already checked out" };
                }

                else if (updateAttendance != null && attendanceDto.AttendanceStatus == Convert.ToInt32(AttendanceStatus.CheckIn))
                {
                    return new ResponseDto<bool>() { Data = true, Status = 1, Message = "You are already checked in" };
                }

                else if (!(updateAttendance is null) && attendanceDto.AttendanceStatus == Convert.ToInt32(AttendanceStatus.CheckOut))
                {
                    updateAttendance.AttendanceTypeId = Convert.ToInt32(AttendanceKeys.CheckOut);
                    updateAttendance.CheckOut = DateTime.UtcNow.TimeOfDay;
                    await _context.SaveChangesAsync();
                    return new ResponseDto<bool>() { Data = true, Status = 1, Message = "Checkout successfully!" };
                }
                else if ((updateAttendance is null) && attendanceDto.AttendanceStatus == Convert.ToInt32(AttendanceStatus.CheckOut))
                {
                    return new ResponseDto<bool>() { Data = true, Status = 1, Message = "Please check in first" };
                }

                return new ResponseDto<bool>() { Data = false, Status = 0, Message = "Failed" };
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<ResponseDto<bool>> DriverAttendanceStatus(int driverId)
        {
            var rec = await _context.DriverAttendance.FirstOrDefaultAsync(x => x.CreatedDate.Value.Date == DateTime.UtcNow.Date && x.DriverId == driverId );
            if (!(rec is null))
            {
                if (rec.AttendanceTypeId == Convert.ToInt32(AttendanceKeys.CheckIn))
                {
                    return new ResponseDto<bool>() { Data = true, Status = 1, Message = "Checked In" };
                }
                else
                {
                    return new ResponseDto<bool>() { Data = false, Status = 1, Message = "Checked Out" };
                }
            }
            else
            {
                return new ResponseDto<bool>() { Data = false, Status = 1, Message = "None status" };
            }
        }


        public async Task<DriverJobRequest> GetPatientJobRequestById(long requestId)
        {
            var data = await _context.DriverJobRequest.Include(x=>x.Driver).FirstOrDefaultAsync(x => x.CurrentRequestID == requestId);
            return data;
        }
    }
}
