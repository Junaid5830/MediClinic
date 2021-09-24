using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.SettingsService
{
    public class ProviderSettingsService : IProviderSettingsService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public ProviderSettingsService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public bool SaveProviderListSettings(ProviderListSettingDto  providerListSettingDto)
        {
            var entity = _context.ProviderListSettingss.FirstOrDefault();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<ProviderListSettingss>(providerListSettingDto);
                mappedData.ProviderListId = entity.ProviderListId;
                _context.Entry(entity).CurrentValues.SetValues(mappedData);
                _context.SaveChanges();
                return true;
            }
            else
            {
                var mappedData = _mapper.Map<ProviderListSettingss>(providerListSettingDto);
                mappedData.ProviderListId = entity.ProviderListId;
                _context.Add(mappedData);
                _context.SaveChanges();
                return true;
            }
        }

        public ProviderListSettingDto getProviderListSettingsById(int userId)
        {
            var entity = _context.ProviderListSettingss.FirstOrDefault();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<ProviderListSettingDto>(entity);
                return mappedData;
            }
            else
            {
                var entityData = new ProviderListSettingss
                {
                    ProviderIdDisplay = true,
                    Name = true,
                    EntityName = true,
                    Address = true,
                    Email = true,
                    LicenseNo = true,
                    NpiNumber = false,
                    AssignRoomNo = false,
                    PhoneNo = true,
                    MobileNo = false,
                    FaxNo = true,
                    TaxId = false,
                    FirstName = true,
                    LastName = true

                };
                entityData.UserId = userId;
                _context.ProviderListSettingss.Add(entityData);
                _context.SaveChanges();
                var mappedData = _mapper.Map<ProviderListSettingDto>(entityData);
                return mappedData;
            }
        }



        public bool AddProviderSessionSettings(ProviderSessionTypeDto dto, long userId)
        {
            
            if (dto.ProviderSessionTypeId > 0)
            {
                var oldEntity = _context.ProviderSessionTypes.Where(x => x.ProviderSessionTypeId == dto.ProviderSessionTypeId).FirstOrDefault();
                var mappedData = _mapper.Map<ProviderSessionTypes>(dto);
                    mappedData.ModifiedById = userId;
                    mappedData.ModifiedDate = DateTime.UtcNow;
                _context.Entry(oldEntity).CurrentValues.SetValues(mappedData);
                _context.SaveChanges();
                return true;
            }
            else
            {
                var mappedData = _mapper.Map<ProviderSessionTypes>(dto);
                mappedData.CreatedById = userId;
                mappedData.ModifiedById = userId;
                mappedData.CreatedDate = DateTime.UtcNow;
                mappedData.ModifiedDate = DateTime.UtcNow;

                _context.Add(mappedData);
                _context.SaveChanges();
                return true;
            }
        }

        public async Task<List<ProviderSessionTypeDto>> GetAllSessionSettings()
        {
            var list = await _context.ProviderSessionTypes.ToListAsync();
            var mappedData =_mapper.Map<List<ProviderSessionTypeDto>>(list);
            if (!(mappedData is null) && mappedData.Count > 0)
            {
                return mappedData;
            }
            else
            {
                return new List<ProviderSessionTypeDto>();
            }
        }

        public async Task<bool> DeleteSessionSettings(long providerSessionTypeId)
        {
            try
            {
                var entity = await _context.ProviderSessionTypes.Where(x => x.ProviderSessionTypeId == providerSessionTypeId).FirstOrDefaultAsync();
                ////var childEntities = entity.ProviderSessions.ToList();
                
                //if (childEntities != null && childEntities.Count > 0)
                //{
                //    _context.RemoveRange(childEntities);
                //    _context.SaveChanges();
                //}
                _context.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }

        public bool SaveProviderSummarySettings(ProviderSummarySettingsDto providerSummarySettingDto)
        {
            var entity = _context.ProviderSummarySettings.FirstOrDefault();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<ProviderSummarySettings>(providerSummarySettingDto);
                mappedData.ProviderPrintId = entity.ProviderPrintId;
                _context.Entry(entity).CurrentValues.SetValues(mappedData);
                _context.SaveChanges();
                return true;
            }
            else
            {
                var mappedData = _mapper.Map<ProviderSummarySettings>(providerSummarySettingDto);
                
                _context.Add(mappedData);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
