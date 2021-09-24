using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.DMESuppliesDto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.DMEInterface
{
    public interface IDMEService
    {



        #region DME
        public Task<bool> AddNewDME(DMESupplieDto dmeDto);
        public Task<bool> AddDME(DMEDto dmeDto);
        public bool DeleteDME(int DMEId);
        public DMEDto GetDMEById(int DMEId);
        public Task<List<DMEDto>> GetDME(); 
        #endregion

        #region DME Manufactures
        public Task<ResponseDto<DmeSuppliesManufacturesDto>> AddUpdateManufacture(DmeSuppliesManufacturesDto manufacture);
        public Task<ResponseDto<DmeSuppliesManufacturesDto>> GetByIdManufacture(int Id);
        public Task<ResponseDto<List<DmeSuppliesManufacturesDto>>> GetListManufactures();
        public Task<ResponseDto<bool>> DeleteManufacture(int Id);
        public Task<ResponseDto<bool>> IsExist(string manufactureName);
        #endregion

        #region DME Make Name Model
        public Task<ResponseDto<DmeMakeNameModelDto>> AddUpdateMakeNameModel(DmeMakeNameModelDto manufacture);
        public Task<ResponseDto<DmeMakeNameModelDto>> GetByIdMakeNameModel(int Id);
        public Task<ResponseDto<List<DmeMakeNameModelDto>>> GetListMakeNameModel();
        public Task<ResponseDto<bool>> DeleteMakeNameModel(int Id);
        #endregion

        #region DME Inventory
        public Task<ResponseDto<DmeInventoryDto>> AddUpdateDmeInventory(DmeInventoryDto manufacture);
        public Task<ResponseDto<DmeInventoryDto>> GetByIdDmeInventory(int Id);
        public Task<ResponseDto<DmeInventoryDto>> GetByCptCodeDmeInventory(int cptCode);
        public Task<ResponseDto<List<DmeInventoryDto>>> GetListDmeInventory();
        public Task<ResponseDto<bool>> DeleteDmeInventory(int Id);
        Task<ResponseDto<bool>> isExistInventory(int Id);
        #endregion

        #region Select List Items For Drop Downs
        public IEnumerable<SelectListItem> SelectListForManufacture(long? id);
        public IEnumerable<SelectListItem> SelectListForMakeNameModel(long? id); 
        #endregion

        #region DME Group Item
        Task<ResponseDto<DMEGroupDto>> CreateGroupName(DMEGroupDto dMEGroupDto);
        Task<ResponseDto<List<DMEGroupItemDto>>> CreateGroupItem(List<DMEGroupItemDto> dMEGroupItemDto);
        Task<ResponseDto<List<DMEGroupDto>>> GroupList();
        Task<ResponseDto<DMEGroupItemDto>> GetByGroupItemId(int ItemId);
        public IEnumerable<SelectListItem> GroupNameListForDMEInventory(long? id);
        public IEnumerable<SelectListItem> GroupItemNameListForDMEInventory(long? id);
        Task<ResponseDto<DMEGroupDto>> GroupNameBycptCodeSelet(int Id);
        public IEnumerable<SelectListItem> CptCodeByGroupNameSelect(int Id);
        Task<ResponseDto<List<DMEGroupItemDto>>> GroupItemList(int GroupId);
        Task<List<DMEGroupItemDto>> GroupItemListAll(int manufactureid,long? createdByid);
        Task<List<DMEGroupItemDto>> GroupItemListAll();
        #endregion

        #region Supplier Listing
        //GetListManufactures,GetListMakeNameModel,GetListDmeInventory,GroupList
        public Task<ResponseDto<List<DmeSuppliesManufacturesDto>>> GetListManufactures(long Id);
        public Task<ResponseDto<List<DmeMakeNameModelDto>>> GetListMakeNameModel(long Id);
        public Task<ResponseDto<List<DmeInventoryDto>>> GetListDmeInventory(long Id);
        Task<ResponseDto<List<DMEGroupDto>>> GroupList(long Id); 
        #endregion
    }
}
