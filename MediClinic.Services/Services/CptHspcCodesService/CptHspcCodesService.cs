using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.CptHspcCodesInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.CptHspcCodesService
{
    public class CptHspcCodesService : ICptHspcCodes
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public CptHspcCodesService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<CptCodeGroupListDto>> AddUpdateCptCodeGroup(CptCodeGroupListDto cptCodesGroupDto)
        {
            try
            {
                var mapper = _mapper.Map<CptCodeGroupListDto, CptCodeGroupList>(cptCodesGroupDto);
                var response = new ResponseDto<CptCodeGroupListDto>();
                if (mapper.CptCodeGroupId > 0)
                {
                    var data = _context.CptCodeGroupList.Update(mapper);
                    await _context.SaveChangesAsync();
                    var mapped = _mapper.Map<CptCodeGroupList, CptCodeGroupListDto>(mapper);
                    response.Data = mapped;
                }
                else
                {
                    var rec = await _context.CptCodeGroupList.AddAsync(mapper);
                    await _context.SaveChangesAsync();
                    var mapped = _mapper.Map<CptCodeGroupList, CptCodeGroupListDto>(rec.Entity);
                    response.Data = mapped;
                }
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<CptHspcCodesDto>> AddUpdateCptHspcCode(CptHspcCodesDto cptHspcCodesDto)
        {
            try
            {
                var mapper =  _mapper.Map<CptHspcCodesDto, CptHspcCode>(cptHspcCodesDto);
                var response = new ResponseDto<CptHspcCodesDto>();
                if (mapper.CptCodeId > 0)
                {
                   var data =  _context.CptHspcCode.Update(mapper);
                   await _context.SaveChangesAsync();
                    var mapped = _mapper.Map<CptHspcCode, CptHspcCodesDto>(mapper);
                   response.Data = mapped;
                }
                else
                {
                    var rec = await _context.CptHspcCode.AddAsync(mapper);
                    await _context.SaveChangesAsync();
                    var mapped = _mapper.Map<CptHspcCode, CptHspcCodesDto>(rec.Entity);
                    response.Data = mapped;
                }
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
         

        }

        public Task<ResponseDto<bool>> DeleteCptCodeGroup(int? Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> DeleteCptHspcCode(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<List<CptCodeGroupListDto>>> ListCptCodeGroup()
        {
            try
            {
                var response = new ResponseDto<List<CptCodeGroupListDto>>();
                var CodesList = new List<CptHspcCodesDto>();
                var DataList = await _context.CptCodeGroupList.ToListAsync();
                var mapper = _mapper.Map<List<CptCodeGroupList>, List<CptCodeGroupListDto>>(DataList);
                if (!(mapper is null))
                {
                    foreach (var item in mapper)
                    {
                        string[] split = item.CptCodes.Split(',');

                        foreach (string codeID in split)
                        {
                            var cptCode = _context.CptHspcCode.Where(x => x.CptCodeId == Convert.ToInt32(codeID)).FirstOrDefault();
                            var mapped = _mapper.Map<CptHspcCode, CptHspcCodesDto>(cptCode);
                            item.ListCPTCodes.Add(mapped);
                        }

                    }
                }


                //response.Data = mapper;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<List<CptHspcCodesDto>>> ListCptHspcCode()
        {
            try
            {
                var response = new ResponseDto<List<CptHspcCodesDto>>();
                ////var DataList = await _context.CptHspcCodes.ToListAsync();
                ////var mapper = _mapper.Map<List<CptHspcCodes>, List<CptHspcCodesDto>>(DataList);
                ////response.Data = mapper;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
