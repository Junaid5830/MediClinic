using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class LabViewModel
    {
        public LabDto labDto { get; set; }
        public List<LabDto> getLabList { get; set; }

        public List<ProceduresDto> ProceduresList { get; set; }

        public ProceduresDto ProcedureDto { get; set; }
    }
}
