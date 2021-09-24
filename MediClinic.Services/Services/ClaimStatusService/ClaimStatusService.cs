using AutoMapper;
using MediClinic.Models.DTOs.ClaimStatus;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ClaimStatusInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.ClaimStatusService
{
    public class ClaimStatusService : IClaimStatusService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public ClaimStatusService(MediClinicContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ClaimStatus> claimStatuelist(string name)
        {
           var rec = _context.ClaimStatus.ToList();
            return rec;
        }

        public async Task<ResponseDto<int>> claimStatus(ClaimStatusBasicDto claimStatusBasicDto)
        {
            try
            {
                if (!(claimStatusBasicDto.ClaimStatus1 is null))
                {
                    claimStatusBasicDto.ClaimStatus1 = claimStatusBasicDto.ClaimStatus1.Trim();
                }
                var mapped = _mapper.Map<ClaimStatusBasicDto, ClaimStatus>(claimStatusBasicDto);
                var data = await _context.ClaimStatus.AddAsync(mapped);
                _context.SaveChanges();

                var response = new ResponseDto<int>();
                response.Data = mapped.ClaimStatusId;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
        }

        public async Task<ResponseDto<ClaimStatusBasicDto>> ClaimStatusGetId(int Id)
        {
            var OldEntity = await _context.ClaimStatus.FirstOrDefaultAsync(x => x.ClaimStatusId == Id);
            var mapped = _mapper.Map<ClaimStatus, ClaimStatusBasicDto>(OldEntity);
            var response = new ResponseDto<ClaimStatusBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> ClaimStatusUpdate(ClaimStatusBasicDto claimStatusBasicDto)
        {
            var mapped = _mapper.Map<ClaimStatusBasicDto, ClaimStatus>(claimStatusBasicDto);
            var oldEntity = await _context.ClaimStatus.FindAsync(mapped.ClaimStatusId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<bool>> ClaimStatusDeleteId(int Id)
        {
            var OldEntity = await _context.ClaimStatus.FirstOrDefaultAsync(x => x.ClaimStatusId == Id);
            _context.Remove(OldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<List<ClaimStatusBasicDto>>> PatientClaimStatusList()
        {
            var rec = await _context.ClaimStatus.ToListAsync();
            var response = new ResponseDto<List<ClaimStatusBasicDto>>();
            response.Data = _mapper.Map<List<ClaimStatus>, List<ClaimStatusBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var value = await _context.ClaimStatus.Where(x => x.ClaimStatus1.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
    }
}
