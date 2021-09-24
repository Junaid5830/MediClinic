using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.SMSDto
{
    public class SmsDto
    {
        [Required(ErrorMessage ="Phone no is required")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage ="Text message is required")]
        public string TextMsg { get; set; }
    }
}
