using MediClinic.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class DmeInvetoryViewModel
    {
        public DmeMakeNameModelDto MakeNameModel { get; set; }
        public DmeSuppliesManufacturesDto SuppliesManufacture { get; set; }
        public DmeInventoryDto DmeInventory { get; set; }
        public List<DmeMakeNameModelDto> MakeNameModelList { get; set; }
        public List<DmeSuppliesManufacturesDto> DmeManufacturesList { get; set; }
        public List<DmeInventoryDto> DmeInventoryList { get; set; }

        public IEnumerable<SelectListItem> InvertoryDMEGroupList { get; set; }
        public IEnumerable<SelectListItem> InvertoryDMEGroupItemList { get; set; }



        public IEnumerable<SelectListItem> SelectListItemForManufacture { get; set; }
        public IEnumerable<SelectListItem> SelectListItemsForMakeNameModel { get; set; }



        public List<DMEGroupDto> dMEGroupitemList { get; set; }

        public List<DMEGroupItemDto> groupItemList { get; set; }


    }
}
