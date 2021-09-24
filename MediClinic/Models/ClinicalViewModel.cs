using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.ClinicalNotesDto;
using MediClinic.Models.DTOs.LookupDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class ClinicalViewModel
    {
        public ClinicalNoteDto ClinicalNoteDto { get; set; }
        public List<LookupBasicDto> NoteTypes { get; set; }
        public List<ClinicalNoteDto> ClinicalNotesList { get; set; }
        public ClinicViewDto Clinicviewcount { get; set; }
        public List<ICDDto> ICDList { get; set; }

        public List<DriverCurrentLocationBasicDto> DriverCurrentLocationListForMap { get; set; }
        public ClincalROSDto ClincalROSDto { get; set; }
        public HistoryOfillnessDto HistoryOfillnessDto { get; set; }
    }
}
