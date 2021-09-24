using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class GrowthChartViewModel
    {
        public GrowthChartDto growthChardto { get; set; }
        public List<GrowthChartDto> growthChartList { get; set; }
    }
}
