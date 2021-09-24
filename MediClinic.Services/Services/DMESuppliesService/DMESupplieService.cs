using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs.DMESuppliesDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Drawing;

namespace MediClinic.Services.Services.DMESuppliesService
{
    public class DMESupplieService : IDMESuppliesService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private IPatientInfoService _patientInfoService;
        public DMESupplieService(MediClinicContext context, IMapper mapper, IPatientInfoService patientInfoService)
        {
            _context = context;
            _mapper = mapper;
            _patientInfoService = patientInfoService;
        }

        #region For ICD & CPT Scrapper
        public async Task<bool> SaveICDCode(string ICDName)
        {
            var getData = await GetData(ICDName);
            if (!(getData is null))
            {
                var mappedData = _mapper.Map<ICDCodes>(getData);
                _context.ICDCodes.Add(mappedData);
                _context.SaveChanges();
            }
            return true;
        }

        public bool SaveCPTCodes(CommonFieldsDMECodesDto dMECodesDto)
        {
            try
            {
                var listData = _mapper.Map<List<CPTCodes>>(dMECodesDto.CPTList);
                _context.CPTCodes.AddRange(listData);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<ICDDto> GetData(string ICDName)
        {
            try
            {
                //var tokenEndpoint = "http://icd10api.com/?s=" + ICDName + "&desc=short&r=json";
                var tokenEndpoint = "http://icd10api.com/?code=" + ICDName + "&desc=short&r=json";
                var client = new HttpClient();

                var request = new HttpRequestMessage(HttpMethod.Get, tokenEndpoint);

                //call the API
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    //var prettyJson = JValue.Parse(content).ToString(Formatting.Indented);
                    var dtoData = JsonConvert.DeserializeObject<ICDDto>(content);
                    return dtoData;
                }
                else
                {
                    return new ICDDto();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion



        #region DME Form CRUD & Dropdown Methods
        public bool SaveDMESupplyEquipment(DMESupplieDto dMESupplieDto)
        {
            var mappedData = _mapper.Map<DMESupplyEquipment>(dMESupplieDto);
            _context.DMESupplyEquipment.Add(mappedData);
            _context.SaveChanges();
            return true;
        }
        
        public string  SaveImage(string img)
        {
            var qrImageFile = "";
            string image = img;
            try
            {
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(image)))
                {
                    using (Bitmap bm2 = new Bitmap(ms))
                    {
                        qrImageFile = DateTime.UtcNow.ToString("ddMMyyyyhhmmss") + ".png";
                        var ProfileImageFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\DmeQRImages", qrImageFile);
                        bm2.Save(ProfileImageFilePath);
                    }
                    return "/DmeQRImages/" + qrImageFile;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool UpdateDMESupplyEquipment(DMESupplieDto dMESupplieDto)
        {
            try
            {
                var oldEntity = _context.DMESupplyEquipment.Find(dMESupplieDto.DMEEquipSupId);
                var mappedData = _mapper.Map<DMESupplyEquipment>(dMESupplieDto);
                _context.Entry(oldEntity).CurrentValues.SetValues(mappedData);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteDMESupplyEquipment(int dMESupplyId)
        {
            var oldEntity = _context.DMESupplyEquipment.Where(x => x.DMEEquipSupId == dMESupplyId).FirstOrDefault();
            if (oldEntity != null)
            {
                oldEntity.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<DMESupplieDto> GetDMESupplyById(int? dMEId)
        {
            var entity = await _context.DMESupplyEquipment.Where(x => x.DMEEquipSupId == dMEId).FirstOrDefaultAsync();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<DMESupplieDto>(entity);
                return mappedData;
            }
            else
            {
                return new DMESupplieDto();
            }
        }

        public async Task<List<DMESupplyEquipment>> GetDMESupplyListByPatientId(long patientId)
        {
            var dataList = await _context.DMESupplyEquipment.Include(x => x.Prescriber).Include(x => x.Patient).Include(x => x.CPTCode).Include(x => x.ICDCode)
                 .Include(x => x.Item).Where(x => x.PatientId == patientId && x.IsActive == true).ToListAsync();
            if (!(dataList is null) && dataList.Count > 0)
            {
                return dataList;
            }
            else
            {
                return new List<DMESupplyEquipment>();
            }
        }

        public async Task<DMESupplyEquipment> GetDMESupplyItemById(int dMEId)
        {
            var entity = await _context.DMESupplyEquipment.Include(x => x.Item).Where(x => x.DMEEquipSupId == dMEId).FirstOrDefaultAsync();
            if (!(entity is null))
            {
                return entity;
            }
            else
            {
                return new DMESupplyEquipment();
            }
        }

        public async Task<List<ICDDto>> GetAllICDCodes(bool withDetail)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ICDDto>(sql: "[GetAllICDCodes]",
                param: new { withDescription = withDetail },
                commandType: CommandType.StoredProcedure);

                var response = result.ToList();
                if (response.Any())
                {
                    return result.ToList();
                }
                else
                {
                    return new List<ICDDto>();
                }

            }
        }

        public async Task<List<CPTCodeDto>> GetAllCPTCodes()
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<CPTCodeDto>(sql: "[GetAllCPTCodes]",
                commandType: CommandType.StoredProcedure);
                var response = result.ToList();
                if (response.Any())
                {
                    return result.ToList();
                }
                else
                {
                    return new List<CPTCodeDto>();
                }
            }
        }

        public async Task<List<DMESupEquipItemsDto>> GetAllItemsGroup()
        {
            var itemList = await _context.DMESupEquipItems.ToListAsync();
            if (itemList.Any())
            {
                var mappedData = _mapper.Map<List<DMESupEquipItemsDto>>(itemList);
                return mappedData;
            }
            else
            {
                return new List<DMESupEquipItemsDto>();
            }
        }
        #endregion



        #region DME Referal Methods
        public async Task<DMEReferalTemplateDto> GetReferalTemplateData(long PatientId, long ProviderId, int? DMEId)
        {

            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<DMEReferalTemplateDto>(sql: "[spGetReferalTemplateData]", param: new { patientId = PatientId, providerId = ProviderId },
                commandType: CommandType.StoredProcedure);
                var returnResponse = result.FirstOrDefault();

                if (DMEId != null)
                {
                    var DmeData = await GetDMESupplyItemById(DMEId.Value);
                    returnResponse.ItemId = DmeData.ItemId;
                    returnResponse.ItemName = DmeData.Item.ItemOrGroupName;
                }

                return returnResponse;
            }
        }

        public async Task<DMEReferalTemplateDto> GetReferalTemplateBatchData(long PatientId, long ProviderId, string[] DMEIds)
        {

            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<DMEReferalTemplateDto>(sql: "[spGetReferalTemplateData]", param: new { patientId = PatientId, providerId = ProviderId },
                commandType: CommandType.StoredProcedure);
                var returnResponse = result.FirstOrDefault();

                if (DMEIds.Length > 0)
                {
                    returnResponse.ItemsNames = new List<string>();
                    for (int i = 0; i < DMEIds.Length; i++)
                    {
                        var DmeData = await GetDMESupplyItemById(Convert.ToInt32(DMEIds[i]));
                        var value = DmeData.Item.ItemOrGroupName;
                        returnResponse.ItemsNames.Add(value);
                    }
                }

                return returnResponse;
            }
        }

        #endregion


        public async Task<DMEDeliveryTemplateDto> GetDMEDeliveryTemplateData(long PatientId,long ProviderId)
        {
           var details = await _patientInfoService.patientInfoGetId(Convert.ToInt32(PatientId));
            DMEDeliveryTemplateDto dMEDelivery = new DMEDeliveryTemplateDto
            {
                Address = details.Data.AddressLine1 + " " + details.Data.AddressLine2 == null ? "" : details.Data.AddressLine2 + " " + details.Data.AddressLine3 == null ? "" : details.Data.AddressLine3,
                PatientName = details.Data.FirstName + " " + details.Data.LastName
            };

            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<DMEDeliveryTemplateDto>(sql: "[spGetDMEDeliveryTemplateData]", param: new { userId = details.Data.UserId, providerId = ProviderId },
                commandType: CommandType.StoredProcedure);
                var entity = result.FirstOrDefault();
                entity.PatientName = dMEDelivery.PatientName;
                entity.Address = dMEDelivery.Address;
                return entity;
            }
        }

        public async Task<DMEAOBDeliveryTemplateDto> GetDMEAOBTemplateData(long PatientId, long ProviderId, int? DMEId)
        {
            var patientUserId = await _patientInfoService.GetUserIdFromPatientId(PatientId);
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<DMEAOBDeliveryTemplateDto>(sql: "[spGetDMEAobTemplateData]", param: new { userID = patientUserId, providerId = ProviderId },
                commandType: CommandType.StoredProcedure);
                var returnResponse = result.FirstOrDefault();

                if (!(DMEId is null))
                {
                    var DmeData = await GetDMESupplyItemById(DMEId.Value);
                    returnResponse.ItemName = DmeData.Item.ItemOrGroupName;
                }

                return returnResponse;
            }
        }


        public async Task<DMEAOBDeliveryTemplateDto> GetDMEAOBBatchData(long PatientId, long ProviderId, string[] DMEIds)
        {
            var patientUserId = await _patientInfoService.GetUserIdFromPatientId(PatientId);
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<DMEAOBDeliveryTemplateDto>(sql: "[spGetDMEAobTemplateData]", param: new { userID = patientUserId, providerId = ProviderId },
                commandType: CommandType.StoredProcedure);
                var returnResponse = result.FirstOrDefault();

                if (!(DMEIds is null))
                {
                    returnResponse.ItemsNames = new List<string>();
                    for (int i = 0; i < DMEIds.Length; i++)
                    {
                        var DmeData = await GetDMESupplyItemById(Convert.ToInt32(DMEIds[i]));
                        returnResponse.ItemsNames.Add(DmeData.Item.ItemOrGroupName);
                    }
                }

                return returnResponse;
            }
        }

        #region DME RxOrder Methods
        public async Task<DMERxOrderTemplateDto> GetRXOrderTemplateData(long patientId, int? DMEId)
        {
            DMERxOrderTemplateDto dMERxOrder = new DMERxOrderTemplateDto();

            var patientData = await _patientInfoService.patientInfoGetId(Convert.ToInt32(patientId));
            if (!(DMEId is null))
            {
                var DmeData = await GetDMESupplyItemById(DMEId.Value);
                dMERxOrder.ItemName = DmeData.Item.ItemOrGroupName;
                dMERxOrder.PatientName = patientData.Data.FirstName + " " + patientData.Data.LastName;
            }
            return dMERxOrder;
        }

        public async Task<DMERxOrderTemplateDto> GetRXOrderBatchData(long patientId, string[] DMEIds)
        {
            DMERxOrderTemplateDto dMERxOrder = new DMERxOrderTemplateDto();

            var patientData = await _patientInfoService.patientInfoGetId(Convert.ToInt32(patientId));
            if (!(DMEIds is null))
            {
                dMERxOrder.ItemsNames = new List<string>();
                for (int i = 0; i < DMEIds.Length; i++)
                {
                    var DmeData = await GetDMESupplyItemById(Convert.ToInt32(DMEIds[i]));

                    dMERxOrder.ItemsNames.Add(DmeData.Item.ItemOrGroupName);
                }
                dMERxOrder.PatientName = patientData.Data.FirstName + " " + patientData.Data.LastName;
            }
            return dMERxOrder;
        }
        #endregion



        public async Task<DMESupplyReturnTemplateDto> GetSupplyReturnTemplateData(long patientId, int? DMEId)
        {
            var joinData = await (from PInfo in _context.PatientInfo.Where(x => x.PatientInfoId == patientId)
                                  join PIAS in _context.PatientIdAndSignature
                                  on PInfo.UserId equals PIAS.UserId

                                  select new DMESupplyReturnTemplateDto
                                  {
                                      PatientName = PInfo.FirstName + ' ' + PInfo.LastName,
                                      PatientSignature = PIAS.WriteSignature
                                  }).FirstOrDefaultAsync();

            if (!(DMEId is null))
            {
                var DmeData = await GetDMESupplyItemById(DMEId.Value);
                joinData.ItemName = DmeData.Item.ItemOrGroupName;
            }
            return joinData;
        }

        public async Task<DMESupplyReturnTemplateDto> GetSupplyReturnBatchData(long patientId, string[] DMEIds)
        {
            var joinData = await (from PInfo in _context.PatientInfo.Where(x => x.PatientInfoId == patientId)
                                  join PIAS in _context.PatientIdAndSignature
                                  on PInfo.UserId equals PIAS.UserId

                                  select new DMESupplyReturnTemplateDto
                                  {
                                      PatientName = PInfo.FirstName + ' ' + PInfo.LastName,
                                      PatientSignature = PIAS.WriteSignature
                                  }).FirstOrDefaultAsync();

            if (!(DMEIds is null))
            {
                joinData.ItemsNames = new List<string>();
                for (int i = 0; i < DMEIds.Length; i++)
                {
                    var DmeData = await GetDMESupplyItemById(Convert.ToInt32(DMEIds[i]));
                    joinData.ItemsNames.Add(DmeData.Item.ItemOrGroupName);
                }
            }

            return joinData;
        }

        public async Task<List<DMESupplyEquipment>> GetAllDMESupplyList()
        {
            var dataList = await _context.DMESupplyEquipment.Include(x => x.Prescriber).Include(x => x.Patient).Include(x => x.CPTCode).Include(x => x.ICDCode)
                 .Include(x => x.Item).Where(x =>  x.IsActive == true).ToListAsync();
            if (!(dataList is null) && dataList.Count > 0)
            {
                return dataList;
            }
            else
            {
                return new List<DMESupplyEquipment>();
            }
        }

        public async Task<List<DMESupplyEquipment>> GetDMESupplyVIsitList(int Id)
        {
            var dataList = await _context.DMESupplyEquipment.Include(x => x.Prescriber).Include(x => x.Patient).Include(x => x.CPTCode).Include(x => x.ICDCode)
                .Include(x => x.Item).Where(x => x.VisitId == Id && x.IsActive == true).ToListAsync();
            if (!(dataList is null) && dataList.Count > 0)
            {
                return dataList;
            }
            else
            {
                return new List<DMESupplyEquipment>();
            }
        }
    }
}
