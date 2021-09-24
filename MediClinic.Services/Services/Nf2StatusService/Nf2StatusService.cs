using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.Nf2StatusDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.Nf2StatusInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.Nf2StatusService
{
    public class Nf2StatusService : INf2StatusService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public Nf2StatusService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Nf2Status> nf2StatusList()
        {
            var rec = _context.Nf2Status.ToList();
            return rec;
        }
        public async Task<ResponseDto<List<Nf2StatusBasicDto>>> nf2Status()
        {
            var rec = await _context.Nf2Status.ToListAsync();
            var response = new ResponseDto<List<Nf2StatusBasicDto>>();
            response.Data = _mapper.Map<List<Nf2Status>, List<Nf2StatusBasicDto>>(rec);
            return response;
        }
        public async Task<ResponseDto<int>> nf2StatusCreate(Nf2StatusBasicDto nf2StatusBasicDto)
        {
            if (!(nf2StatusBasicDto.Nf2Status1 is null))
            {
                nf2StatusBasicDto.Nf2Status1 = nf2StatusBasicDto.Nf2Status1.Trim();
            }
            var mapped = _mapper.Map<Nf2StatusBasicDto, Nf2Status>(nf2StatusBasicDto);
            var data = await _context.Nf2Status.AddAsync(mapped);
            _context.SaveChanges();
           
            var response = new ResponseDto<int>();
            response.Data = mapped.Nf2Id;
            return response;
        }
        public async Task<ResponseDto<bool>> nf2StatusDeleteById(int Id)
        {
            var oldEntity = await _context.Nf2Status.FirstOrDefaultAsync(x => x.Nf2Id == Id);
            _context.Remove(oldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<Nf2StatusBasicDto>> nf2StatusGetId(int Id)
        {
            var oldEntity = await _context.Nf2Status.FirstOrDefaultAsync(x => x.Nf2Id == Id);
            var mapped = _mapper.Map<Nf2Status, Nf2StatusBasicDto>(oldEntity);
            var response = new ResponseDto<Nf2StatusBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> nf2StatusUpdate(Nf2StatusBasicDto nf2StatusBasicDto)
        {
            var mapped = _mapper.Map<Nf2StatusBasicDto, Nf2Status>(nf2StatusBasicDto);
            var oldEntity = await _context.Nf2Status.FindAsync(mapped.Nf2Id);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var Value = await _context.Nf2Status.Where(x => x.Nf2Status1.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(Value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
    }
}
