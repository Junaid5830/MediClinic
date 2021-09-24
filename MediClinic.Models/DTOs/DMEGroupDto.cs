using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class DMEGroupDto
    {
        public int DMEGroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedId { get; set; }
    }
}
