using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.LookupDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class EUOViewModel
    {
        public EUODto EUODto { get; set; }
        public List<EUODto> EUODtoList { get; set; }
        public List<LookupBasicDto> PlaceList { get; set; }
        public List<LookupBasicDto> RepresentedByList { get; set; }
        public List<LookupBasicDto> StatusList { get; set; }
        public List<LookupBasicDto> ReasonList { get; set; }
        public List<LookupBasicDto> TranscriptsList { get; set; }

    }
}
