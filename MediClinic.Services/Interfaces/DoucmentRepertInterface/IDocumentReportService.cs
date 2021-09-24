using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.DoucmentRepertInterface
{
    public interface IDocumentReportService
    {
        public Task<ResponseDto<bool>> CreateDocument(DocumentReportBasicDto documentReportBasicDto);
        public Task<List<DocumentReportBasicDto>> DocumentList();
        public Task<ResponseDto<DocumentReportBasicDto>> DocumentById(int Id);

        public bool DocumentDelete(int Id);
    }
}
