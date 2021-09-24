using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class ClaimViewModal
    {
        public ClaimBasicDto claim { get; set; }
        public List<ClaimBasicDto> Claimlist { get; set; }

        public List<ICDDto> ICDList { get; set; }
        public List<CPTCodeDto> CPTList { get; set; }
    }
   
}
