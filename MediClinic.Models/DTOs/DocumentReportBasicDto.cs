using MediClinic.Models.DTOs.CommonDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Models.DTOs
{
    public class DocumentReportBasicDto
    {
        public int DocumentId { get; set; }
        public string Scannedby { get; set; }
        public DateTime? ScannedDate { get; set; }
        public TimeSpan? ScannedTime { get; set; }
        public string SourceOfDocument { get; set; }
        public bool DocumentInitalReport { get; set; }
        public bool DocumentDMEPrescription { get; set; }
        public bool DocumentDeclofenac { get; set; }
        public bool DocumentDriverLiecense { get; set; }

        public string DocumentName { get; set; }
        public IFormFile File { get; set; }

        public static implicit operator DocumentReportBasicDto(Task<ResponseDto<DocumentReportBasicDto>> v)
        {
            throw new NotImplementedException();
        }
    }
}
