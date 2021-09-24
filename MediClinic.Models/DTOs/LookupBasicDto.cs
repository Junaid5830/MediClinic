using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.LookupDto
{
    public class LookupBasicDto
    {
        public int LookupId { get; set; }
        [Required(ErrorMessage ="Value is required.")]
        public string LookupValue { get; set; }
        public string LookupType { get; set; }
        public int SortOrder { get; set; }
    }
}
