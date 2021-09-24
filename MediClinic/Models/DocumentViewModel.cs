using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class DocumentViewModel
    {
        public DocumentReportBasicDto Document { get; set; }
        public List<DocumentReportBasicDto> DocumentList { get; set; }
    }
}
