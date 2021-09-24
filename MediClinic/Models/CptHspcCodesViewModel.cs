using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class CptHspcCodesViewModel
    {
        public CptHspcCodesViewModel()
        {
            CptHspcCodesList = new List<CptHspcCodesDto>();
            CptHspcCodesGroupList = new List<CptCodeGroupListDto>();
        }
        public CptHspcCodesDto CptHspcCodes { get; set; }
        public CptCodeGroupListDto CptCodeGroupListDto { get; set; }
        public List<CptHspcCodesDto> CptHspcCodesList { get; set; }
        public List<CptCodeGroupListDto> CptHspcCodesGroupList { get; set; }
    }
}
