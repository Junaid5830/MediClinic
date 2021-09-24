using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class LegalInfoViewModel
    {
        public LegalInfoDto legalInfoDto { get; set; }
        public List<LegalInfoDto> getLegalInfoList { get; set; }
    }
}
