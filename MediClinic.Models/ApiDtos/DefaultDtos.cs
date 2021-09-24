using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.ApiDtos
{
    public class DefaultDtos
    {
        public class DefaultRequestDto<T>
        {
            public T RequestId { get; set; }
        }

        public class TwoPropModel
        {
            public int RequestId { get; set; }
            public string RequestValue { get; set; }
        }
    }
}
