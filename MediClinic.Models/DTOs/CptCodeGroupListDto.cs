using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class CptCodeGroupListDto
    {
        public CptCodeGroupListDto()
        {
            ListCPTCodes = new List<CptHspcCodesDto>();
        }
        public int CptCodeGroupId { get; set; }
        public string CptCodeGroupName { get; set; }
        public string CptCodes { get; set; }
        public int? TotalFee { get; set; }
        public string[] CptCodesLArray { get; set; }
        public List<CptHspcCodesDto> ListCPTCodes { get; set; }
    }
}
