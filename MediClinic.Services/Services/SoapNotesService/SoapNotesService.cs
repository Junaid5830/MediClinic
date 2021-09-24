using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.SoapNotesInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.SoapNotesService
{
    public  class SoapNotesService: ISoapNotesService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        public SoapNotesService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        public async Task<List<ICDDto>> ICDCodeList(bool withDetail)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ICDDto>(sql: "[GetAllICDCodes]",
                param: new { withDescription = withDetail },
                commandType: CommandType.StoredProcedure);
                var response = result.ToList();
                if (response.Any())
                {
                    return result.ToList();
                }
                else
                {
                    return new List<ICDDto>();
                }

            }
        }

        public async Task<ResponseDto<SoapNotesBasicDto>> SoapNotesById(int Id)
        {
            var oldEntity = await _context.SoapNotesSurvey.FirstOrDefaultAsync(x => x.SurveyNoteId == Id);
            var mapped = _mapper.Map<SoapNotesSurvey, SoapNotesBasicDto>(oldEntity);
            var response = new ResponseDto<SoapNotesBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> SoapNotesCreate(SoapNotesBasicDto soapNotesBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<SoapNotesBasicDto, SoapNotesSurvey>(soapNotesBasicDto);
            var data = await _context.SoapNotesSurvey.AddAsync(mapped);
            await _context.SaveChangesAsync();
            if (!(data is null))
            {
                result = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto<bool>> SoapNotesDeleteById(int Id)
        {
            long userId = 0;
            var oldEntity = await _context.SoapNotesSurvey.FirstOrDefaultAsync(x => x.SurveyNoteId == Id);
                        _context.Remove(oldEntity);
            _context.SaveChanges();

      

            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public List<SoapNotesSurvey> SoapNotesList()
        {
            return _context.SoapNotesSurvey.ToList();
        }

        public async Task<ResponseDto<bool>> SoapNotesUpdate(SoapNotesBasicDto soapNotesBasicDto)
        {
            var mapped = _mapper.Map<SoapNotesBasicDto, SoapNotesSurvey> (soapNotesBasicDto);
            var OldEntity = await _context.SoapNotesSurvey.FindAsync(mapped.SurveyNoteId);
            _context.Entry(OldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
    }
}
