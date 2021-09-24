using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.CommonDto
{
    public class ResponseDto<T>
    {
        public int Status { get; set; } = 1;
        public string Message { get; set; } = "";
        public T Data { get; set; }

    }
}
