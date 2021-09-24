using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class IMEViewModel
    {
        public ImeDto imeDto { get; set; }
        public List<ImeDto> getimeList { get; set; }
    }
}
