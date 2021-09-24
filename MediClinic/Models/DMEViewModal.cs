using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.LookupDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class DMEViewModal
    {
        public DMEDto DMEDto { get; set; }
        
        public List<DMEDto> DMEDtoList { get; set; }
        public List<LookupBasicDto> ItemGroupName { get; set; }
        public List<LookupBasicDto> CTP { get; set; }
        public List<LookupBasicDto> ICD { get; set; }
        public List<LookupBasicDto> Prescriber { get; set; }
        public List<LookupBasicDto> RefNo { get; set; }
        public List<LookupBasicDto> Status { get; set; }
        
    }
}
