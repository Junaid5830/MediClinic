using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.DMESuppliesDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.DMEInterface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.DMEService
{
    public class DMEService : IDMEService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        public DMEService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #region DME
        public async Task<bool> AddNewDME(DMESupplieDto dmeDto)
        {
            var mapped = _mapper.Map<DMESupplieDto, DMESupplyEquipment>(dmeDto);
            await _context.DMESupplyEquipment.AddAsync(mapped);
            _context.SaveChanges();
            return false;
        }
        public async Task<bool> AddDME(DMEDto dmeDto)
        {
            var mapped = _mapper.Map<DMEDto, DME>(dmeDto);
            if (dmeDto.DMEId == 0)
            {
                await _context.DME.AddAsync(mapped);
            }
            else
            {
                _context.DME.Update(mapped);
            }
            _context.SaveChanges();
            return false;
        }
        public bool DeleteDME(int DMEId)
        {
            DME DME = _context.DME.Where(a => a.DMEId == DMEId).FirstOrDefault();
            if (DME != null)
            {
                _context.DME.Remove(DME);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public DMEDto GetDMEById(int DMEId)
        {
            DME DME = _context.DME.Where(a => a.DMEId == DMEId).FirstOrDefault();
            DMEDto DMEDto = _mapper.Map<DME, DMEDto>(DME);
            return DMEDto;
        }
        public async Task<List<DMEDto>> GetDME()
        {
            var rec = await _context.DME.ToListAsync();
            var response = new List<DMEDto>();
            return _mapper.Map<List<DME>, List<DMEDto>>(rec);

        } 
        #endregion


        #region DME Manufactures
        public async Task<ResponseDto<DmeSuppliesManufacturesDto>> AddUpdateManufacture(DmeSuppliesManufacturesDto manufacture)
        {
            try
            {
                var mapped = _mapper.Map<DmeSuppliesManufacturesDto, DmeSuppliesManufactures>(manufacture);
                var response = new ResponseDto<DmeSuppliesManufacturesDto>();

                if (manufacture.Id > 0)
                {
                    var OldEntity = await  _context.DmeSuppliesManufactures.FindAsync(manufacture.Id);
                    mapped.ModifiedDate = DateTime.Now;
                    mapped.IsActive = true;
                    mapped.CreatedDate = OldEntity.CreatedDate;
                    mapped.CreatedBy = OldEntity.CreatedBy;
                    _context.Entry(OldEntity).CurrentValues.SetValues(mapped);
                    var rec = await _context.SaveChangesAsync();
                    var Entity = _mapper.Map<DmeSuppliesManufactures, DmeSuppliesManufacturesDto>(mapped);
                    response.Data = Entity;

                }
                else
                {
                    mapped.IsActive = true;
                    mapped.CreatedDate = DateTime.Now;
                    _context.DmeSuppliesManufactures.Add(mapped);
                    _context.SaveChanges();
                    var data = _mapper.Map<DmeSuppliesManufactures, DmeSuppliesManufacturesDto>(mapped);
                    response.Data = data;
                }
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<DmeSuppliesManufacturesDto>> GetByIdManufacture(int Id)
        {
            try
            {
                var response = new ResponseDto<DmeSuppliesManufacturesDto>();
                var data = await _context.DmeSuppliesManufactures.Where(x=>x.Id==Id).FirstOrDefaultAsync();
                var mapper = _mapper.Map<DmeSuppliesManufactures, DmeSuppliesManufacturesDto>(data);
                response.Data = mapper;
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<List<DmeSuppliesManufacturesDto>>> GetListManufactures()
        {
            try
            {
                var response = new ResponseDto<List<DmeSuppliesManufacturesDto>>();
                var list = await _context.DmeSuppliesManufactures.Where(x => x.IsActive == true).ToListAsync();
                var mapper = _mapper.Map<List<DmeSuppliesManufactures>, List<DmeSuppliesManufacturesDto>>(list);
                response.Data = mapper;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<bool>> DeleteManufacture(int Id)
        {
            try
            {
                var response = new ResponseDto<bool>();
                response.Data = false;
                var OldEntity = await _context.DmeSuppliesManufactures.FindAsync(Id);
                if(!(OldEntity is null))
                {
                    OldEntity.IsActive = false;
                    response.Data = true;
                }
                
                await _context.SaveChangesAsync();
                return response;
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<bool>> IsExist(string manufactureName)
        {
            try
            {
                var result = false;
                var response = new ResponseDto<bool>();
                var data = await _context.DmeSuppliesManufactures.Where(x => x.Manufactures == manufactureName).FirstOrDefaultAsync();
                if(!(data is null))
                {
                    result = true;
                }
                response.Data = result;
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion



        #region DME Make Name Model
        public async Task<ResponseDto<DmeMakeNameModelDto>> AddUpdateMakeNameModel(DmeMakeNameModelDto manufacture)
        {
            try
            {
                var mapped = _mapper.Map<DmeMakeNameModelDto, DmeMakeNameModel>(manufacture);
                var response = new ResponseDto<DmeMakeNameModelDto>();

                if (manufacture.Id > 0)
                {
                    var OldEntity = await  _context.DmeMakeNameModel.FindAsync(manufacture.Id);
                    mapped.ModifiedDate = DateTime.UtcNow;
                    mapped.IsActive = true;
                    mapped.CreatedDate = OldEntity.CreatedDate;
                    mapped.CreatedBy = OldEntity.CreatedBy;
                    _context.Entry(OldEntity).CurrentValues.SetValues(mapped);
                    var rec = await _context.SaveChangesAsync();
                    var Entity = _mapper.Map<DmeMakeNameModel, DmeMakeNameModelDto>(mapped);
                    response.Data = Entity;

                }
                else
                {
                    mapped.IsActive = true;
                    mapped.CreatedDate = DateTime.Now;
                    _context.DmeMakeNameModel.Add(mapped);
                    _context.SaveChanges();
                    var data = _mapper.Map<DmeMakeNameModel, DmeMakeNameModelDto>(mapped);
                    response.Data = data;
                }
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<DmeMakeNameModelDto>> GetByIdMakeNameModel(int Id)
        {
            try
            {
                var response = new ResponseDto<DmeMakeNameModelDto>();
                var data = await _context.DmeMakeNameModel.Where(x => x.Id == Id).FirstOrDefaultAsync();
                var mapper = _mapper.Map<DmeMakeNameModel, DmeMakeNameModelDto>(data);
                response.Data = mapper;
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<List<DmeMakeNameModelDto>>> GetListMakeNameModel()
        {
            try
            {
                var response = new ResponseDto<List<DmeMakeNameModelDto>>();
                var list = await _context.DmeMakeNameModel.Where(x => x.IsActive == true).ToListAsync();
                var mapper = _mapper.Map<List<DmeMakeNameModel>, List<DmeMakeNameModelDto>>(list);
                response.Data = mapper;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<bool>> DeleteMakeNameModel(int Id)
        {
            try
            {
                var response = new ResponseDto<bool>();
                response.Data = false;
                var OldEntity = await _context.DmeMakeNameModel.FindAsync(Id);
                if (!(OldEntity is null))
                {
                    OldEntity.IsActive = false;
                    response.Data = true;
                }

                await _context.SaveChangesAsync();
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        #endregion


        #region DME Inventory
        public async Task<ResponseDto<DmeInventoryDto>> AddUpdateDmeInventory(DmeInventoryDto inventory)
        {
            try
            {
                var mapped = _mapper.Map<DmeInventoryDto, DmeInventory>(inventory);
                var response = new ResponseDto<DmeInventoryDto>();

                if (inventory.Id > 0)
                {
                    var OldEntity = await _context.DmeInventory.FindAsync(inventory.Id);
                    mapped.ModifiedDate = DateTime.UtcNow;
                    mapped.IsActive = true;
                    mapped.CreatedDate = OldEntity.CreatedDate;
                    mapped.CreatedBy = OldEntity.CreatedBy;
                    _context.Entry(OldEntity).CurrentValues.SetValues(mapped);
                    var rec = await _context.SaveChangesAsync();
                    var Entity = _mapper.Map<DmeInventory, DmeInventoryDto>(mapped);
                    response.Data = Entity;

                }
                else
                {
                    mapped.IsActive = true;
                    mapped.CreatedDate = DateTime.Now;
                    _context.DmeInventory.Add(mapped);
                    _context.SaveChanges();
                    var data = _mapper.Map<DmeInventory, DmeInventoryDto>(mapped);
                    response.Data = data;
                }
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<DmeInventoryDto>> GetByIdDmeInventory(int Id)
        {
            try
            {
                var response = new ResponseDto<DmeInventoryDto>();
                var data = await _context.DmeInventory.Where(x => x.Id == Id).FirstOrDefaultAsync();
                var mapper = _mapper.Map<DmeInventory, DmeInventoryDto>(data);
                response.Data = mapper;
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<ResponseDto<DmeInventoryDto>> GetByCptCodeDmeInventory(int cptCode)
        {
            try
            {
                var response = new ResponseDto<DmeInventoryDto>();
                var data = await _context.DmeInventory.Where(x => x.CPTCode == cptCode).FirstOrDefaultAsync();
                var mapper = _mapper.Map<DmeInventory, DmeInventoryDto>(data);
                response.Data = mapper;
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<List<DmeInventoryDto>>> GetListDmeInventory()
        {
            try
            {
                var response = new ResponseDto<List<DmeInventoryDto>>();
                var list = await _context.DmeInventory.Include(x=>x.CPTCodeNavigation).Include(x=>x.SubGroupOfNavigation).Include(x=>x.Manufacture).Include(x=>x.MakeNameModel).Where(x => x.IsActive == true).ToListAsync();
                var mapper = _mapper.Map<List<DmeInventory>, List<DmeInventoryDto>>(list);
                response.Data = mapper;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<bool>> DeleteDmeInventory(int Id)
        {
            try
            {
                var response = new ResponseDto<bool>();
                response.Data = false;
                var OldEntity = await _context.DmeInventory.FindAsync(Id);
                if (!(OldEntity is null))
                {
                    OldEntity.IsActive = false;
                    response.Data = true;
                }

                await _context.SaveChangesAsync();
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<ResponseDto<bool>> isExistInventory(int Id)
        {
            var isExist = false;
            var Value = await _context.DmeInventory.Where(x => x.CPTCode == Id).FirstOrDefaultAsync();
            if (!(Value is null))
            {
                isExist = true;
            }
            return new ResponseDto<bool>()
            {
                Data = isExist,
                Message = "CPT Code Inventory Already Exist"
            };
        }




        #endregion

        #region DME item Group
        public async Task<ResponseDto<DMEGroupDto>> CreateGroupName(DMEGroupDto dMEGroupDto)
        {
            try
            {
                var Mapped = _mapper.Map<DMEGroupDto, DMEGroup>(dMEGroupDto);
                Mapped.isActive = true;
                Mapped.CreatedDate = DateTime.Now;
                await _context.DMEGroup.AddAsync(Mapped);
                await _context.SaveChangesAsync();
                var entity = _mapper.Map<DMEGroupDto>(Mapped);
                return new ResponseDto<DMEGroupDto>()
                {
                    Data = entity
                };
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<ResponseDto<List<DMEGroupItemDto>>> CreateGroupItem(List<DMEGroupItemDto> dMEGroupItemDto)
        {
            try
            {
                List<DMEGroupItem> mapped = _mapper.Map<List<DMEGroupItemDto>, List<DMEGroupItem>>(dMEGroupItemDto);
                mapped.ForEach(x => x.isActive = true);
                mapped.ForEach(x => x.CreatedDate = DateTime.Now);
                await _context.DMEGroupItem.AddRangeAsync(mapped);
                await _context.SaveChangesAsync();
                var Entity = _mapper.Map<List<DMEGroupItemDto>>(mapped);
                return new ResponseDto<List<DMEGroupItemDto>>()
                {
                    Data = Entity
                };
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }

        public async Task<ResponseDto<List<DMEGroupDto>>> GroupList()
        {
            var rec = await _context.DMEGroup.Where(x => x.isActive == true).ToListAsync();
            var Entity = _mapper.Map<List<DMEGroupDto>>(rec);
            return new ResponseDto<List<DMEGroupDto>>()
            {
                Data = Entity
            };
        }

        public async Task<ResponseDto<List<DMEGroupItemDto>>> GroupItemList(int GroupId)
        {
            var rec = await _context.DMEGroupItem.Where(x => x.isActive == true && x.DMEGroupId == GroupId).ToListAsync();
            var Entity = _mapper.Map<List<DMEGroupItemDto>>(rec);
            return new ResponseDto<List<DMEGroupItemDto>>()
            {
                Data = Entity
            };
        }


        public async Task<List<DMEGroupItemDto>> GroupItemListAll(int manufactureId,long? id)
        {
           
            try
            {

                if (id is null)
                {
                    var joinData = await (from DI in _context.DMEGroupItem
                                          join D in _context.DmeInventory.Where(x => x.ManufactureId == manufactureId)
                                          on DI.DMEGroupItemId equals D.CPTCode
                                          where D.ExistingQuantity > 0
                                          select new DMEGroupItemDto
                                          {
                                              DMEGroupItemId = DI.DMEGroupItemId,
                                              CPTCode = DI.CPTCode,
                                              Description = DI.Description
                                          }).ToListAsync();

                    return joinData;
                }
                else
                {
                    var joinData = await (from DI in _context.DMEGroupItem.Where(x => x.CreatedId == id)
                                          join D in _context.DmeInventory.Where(x => x.ManufactureId == manufactureId)
                                          on DI.DMEGroupItemId equals D.CPTCode
                                          where D.ExistingQuantity > 0

                                          select new DMEGroupItemDto
                                          {
                                              DMEGroupItemId = DI.DMEGroupItemId,
                                              CPTCode = DI.CPTCode
                                          }).ToListAsync();

                    return joinData;
                }

               

                //var rec = await _context.DMEGroupItem.Where(x => x.isActive == true).ToListAsync();
                //var Entity = _mapper.Map<List<DMEGroupItemDto>>(rec);
                //return new ResponseDto<List<DMEGroupItemDto>>()
                //{
                //    Data = Entity
                //};
               
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        public async Task<List<DMEGroupItemDto>> GroupItemListAll()
        {

            try
            {

               
                    var joinData = await (from DI in _context.DMEGroupItem
                                          join D in _context.DmeInventory
                                          on DI.DMEGroupItemId equals D.CPTCode
                                          where D.ExistingQuantity > 0

                                          select new DMEGroupItemDto
                                          {
                                              DMEGroupItemId = DI.DMEGroupItemId,
                                              CPTCode = DI.CPTCode,
                                              Description =DI.Description
                                          }).ToListAsync();

                    return joinData;
                



                //var rec = await _context.DMEGroupItem.Where(x => x.isActive == true).ToListAsync();
                //var Entity = _mapper.Map<List<DMEGroupItemDto>>(rec);
                //return new ResponseDto<List<DMEGroupItemDto>>()
                //{
                //    Data = Entity
                //};

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<ResponseDto<DMEGroupItemDto>> GetByGroupItemId(int ItemId)
        {
            try
            {
                var rec = await _context.DMEGroupItem.Where(x => x.isActive == true && x.DMEGroupItemId == ItemId).FirstOrDefaultAsync();
                
                var Entity = _mapper.Map<DMEGroupItemDto>(rec);
                return new ResponseDto<DMEGroupItemDto>()
                {
                    Data = Entity
                };
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public IEnumerable<SelectListItem> GroupNameListForDMEInventory(long? id)
        {
            if(id is null)
            {
                return _context.DMEGroup.Select(x => new SelectListItem()
                {
                    Text = x.GroupName,
                    Value = x.DMEGroupId.ToString()
                });
            }
            else
            {
                return _context.DMEGroup.Where(x=>x.CreatedId==id).Select(x => new SelectListItem()
                {
                    Text = x.GroupName,
                    Value = x.DMEGroupId.ToString()
                });
            }
           
        }
        public IEnumerable<SelectListItem> GroupItemNameListForDMEInventory(long? id)
        {
            if(id is null)
            {
                return _context.DMEGroupItem.Select(x => new SelectListItem()
                {
                    Text = x.CPTCode,
                    Value = x.DMEGroupItemId.ToString()
                });
            }
            else
            {
                return _context.DMEGroupItem.Where(x=>x.CreatedId==id).Select(x => new SelectListItem()
                {
                    Text = x.CPTCode,
                    Value = x.DMEGroupItemId.ToString()
                });
            }
           
        }
        public IEnumerable<SelectListItem> CptCodeByGroupNameSelect(int Id)
        {
            return _context.DMEGroupItem.Where(x=>x.DMEGroupId == Id).Select(x => new SelectListItem()
            {
                Text = x.CPTCode,
                Value = x.DMEGroupItemId.ToString()
            });
        }
        public async Task<ResponseDto<DMEGroupDto>> GroupNameBycptCodeSelet(int Id)
        {
            var join = await (from PA in _context.DMEGroupItem.Where(x => x.DMEGroupItemId == Id)
                                  join G in _context.DMEGroup
                                  on PA.DMEGroupId equals G.DMEGroupId

                                  select new DMEGroupDto
                                  {
                                      DMEGroupId = G.DMEGroupId,
                                      GroupName = G.GroupName

                                  }).FirstOrDefaultAsync();
            return new ResponseDto<DMEGroupDto>()
            {
                Data = join
            };
        }


        #endregion



        #region Select List Items For Drop Downs
        public IEnumerable<SelectListItem> SelectListForManufacture(long? id)
        {
            if(id is null)
            {
                return _context.DmeSuppliesManufactures.Select(x => new SelectListItem()
                {
                    Text = x.Manufactures,
                    Value = x.Id.ToString()
                });
            }
            else
            {
                return _context.DmeSuppliesManufactures.Where(x=>x.CreatedBy==id).Select(x => new SelectListItem()
                {
                    Text = x.Manufactures,
                    Value = x.Id.ToString()
                });
            }
            
        }

        public IEnumerable<SelectListItem> SelectListForMakeNameModel(long? id)
        {
            if(id is null)
            {
                return _context.DmeMakeNameModel.Select(x => new SelectListItem()
                {

                    Text = x.Make + x.Name,
                    Value = x.Id.ToString()
                }); 
            }
            else
            {
                return _context.DmeMakeNameModel.Where(x=>x.CreatedBy==id).Select(x => new SelectListItem()
                {

                    Text = x.Make + x.Name,
                    Value = x.Id.ToString()
                });
            }
          
        }



        #endregion



        #region Supplier Listing
        public async Task<ResponseDto<List<DmeSuppliesManufacturesDto>>> GetListManufactures(long Id)
        {
            try
            {
                var response = new ResponseDto<List<DmeSuppliesManufacturesDto>>();
                var list = await _context.DmeSuppliesManufactures.Where(x => x.IsActive == true && x.CreatedBy==Id).ToListAsync();
                var mapper = _mapper.Map<List<DmeSuppliesManufactures>, List<DmeSuppliesManufacturesDto>>(list);
                response.Data = mapper;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<List<DmeMakeNameModelDto>>> GetListMakeNameModel(long Id)
        {
            try
            {
                var response = new ResponseDto<List<DmeMakeNameModelDto>>();
                var list = await _context.DmeMakeNameModel.Where(x => x.IsActive == true && x.CreatedBy==Id).ToListAsync();
                var mapper = _mapper.Map<List<DmeMakeNameModel>, List<DmeMakeNameModelDto>>(list);
                response.Data = mapper;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<List<DmeInventoryDto>>> GetListDmeInventory(long Id)
        {
            try
            {
                var response = new ResponseDto<List<DmeInventoryDto>>();
                var list = await _context.DmeInventory.Include(x => x.CPTCodeNavigation).Include(x => x.SubGroupOfNavigation).Include(x => x.Manufacture).Include(x => x.MakeNameModel).Where(x => x.IsActive == true && x.CreatedBy==Id).ToListAsync();
                var mapper = _mapper.Map<List<DmeInventory>, List<DmeInventoryDto>>(list);
                response.Data = mapper;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<List<DMEGroupDto>>> GroupList(long Id)
        {
            var rec = await _context.DMEGroup.Where(x => x.isActive == true && x.CreatedId==Id).ToListAsync();
            var Entity = _mapper.Map<List<DMEGroupDto>>(rec);
            return new ResponseDto<List<DMEGroupDto>>()
            {
                Data = Entity
            };
        }

       
        #endregion
    }
}
