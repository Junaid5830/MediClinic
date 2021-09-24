using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class DMEGroupItemDto
    {
        public int DMEGroupItemId { get; set; }
        public string CPTCode { get; set; }
        public string Description { get; set; }
        public string Fee { get; set; }
        public int? DMEGroupId { get; set; }

    }
}
