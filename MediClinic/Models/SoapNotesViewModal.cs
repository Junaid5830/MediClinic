using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class SoapNotesViewModal
    {
        public SoapNotesViewModal()
        {
            soapNotesBasicDto = new SoapNotesBasicDto();
        }
        public SoapNotesBasicDto soapNotesBasicDto { get; set; }
        public List<SoapNotesSurvey> SoapNotsList { get; set; }

        public List<ICDDto> ICDList { get; set; }

        public List<string> ICDNameList { get; set; }

    }
}
