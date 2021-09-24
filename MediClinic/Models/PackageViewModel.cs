using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class PackageViewModel
    {
        public SubsriptionPackageDto subsriptionPackageDto { get; set; }
        public List<SubsriptionPackageDto> subsriptionPackagesList { get; set; }
    }
}
