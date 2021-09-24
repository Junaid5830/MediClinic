using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class DMEGroupItemViewModel
    {
        public DMEGroupDto dMEGroupDto { get; set; }

        public List<DMEGroupItemDto> groupItemList { get; set; }
    }
}
