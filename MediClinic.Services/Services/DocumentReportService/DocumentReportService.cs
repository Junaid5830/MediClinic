using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.DoucmentRepertInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.DocumentReportService
{
    public class DocumentReportService: IDocumentReportService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        public DocumentReportService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<bool>> CreateDocument(DocumentReportBasicDto documentReportBasicDto)
        {
            try
            {
                var result = false;
                var mapper = _mapper.Map<DocumentReportBasicDto, DocumentReports>(documentReportBasicDto);
                mapper.IsActive = true;
                mapper.CreatedDate = DateTime.Now;
                var data = await _context.DocumentReports.AddAsync(mapper);
                if (!(data is null))
                {
                    await _context.SaveChangesAsync();
                    result = true;
                }
                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ResponseDto<DocumentReportBasicDto>> DocumentById(int Id)
        {
            var OldEntity = await _context.DocumentReports.FirstOrDefaultAsync(x => x.DocumentId == Id);
            var mapped = _mapper.Map<DocumentReports, DocumentReportBasicDto>(OldEntity);
            var response = new ResponseDto<DocumentReportBasicDto>();
            response.Data = mapped;
            return response;
        }

        public bool DocumentDelete(int Id)
        {
            var rec = _context.DocumentReports.FirstOrDefault(x => x.DocumentId == Id);
            if (!(rec is null))
            {
                rec.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<DocumentReportBasicDto>> DocumentList()
        {
            var Data = await(from PA in _context.DocumentReports.Where(x => x.IsActive == true)

                             select new DocumentReportBasicDto
                             {
                                 DocumentId = PA.DocumentId,
                                 Scannedby = PA.Scannedby,
                                 ScannedDate = PA.ScannedDate,
                                 ScannedTime = PA.ScannedTime,
                                 SourceOfDocument = PA.SourceOfDocument,
                                 DocumentInitalReport = PA.DocumentInitalReport,
                                 DocumentDMEPrescription = PA.DocumentDMEPrescription,
                                 DocumentDeclofenac = PA.DocumentDeclofenac,
                                 DocumentDriverLiecense = PA.DocumentDriverLiecense


                             }).ToListAsync();
            return Data;
        }

        

    }
}
