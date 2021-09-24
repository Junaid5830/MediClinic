using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ProviderWorkHrsDto
    {
        public long ProviderSessionId { get; set; }
        public int WeekDayId { get; set; }
        public int ProviderSessionTypeId { get; set; }
        public long ProviderInfoId { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        public string DepartmentName { get; set; }

        public string Days { get; set; }
        public string SessionTypeName { get; set; }
        public string WeekDayName { get; set; }

        public string DoctorName { get; set; }
        public TimeSpan STime { get; set; }
        public TimeSpan ETime { get; set; }
        public DateTime? WeekDate { get; set; }

    }

    public class WeekDayWithSessionTypeDto
    {
        public int WeekDayId { get; set; }
        public int ProviderSessionTypeId { get; set; }
        public string SessionTypeName { get; set; }
        public string WeekDayName { get; set; }
        public long ProviderInfoId { get; set; }

        public int[] ProviderSessionTypeArray { get; set; }
    }

    public class ProviderSessionTypeDto
    {
        public int ProviderSessionTypeId { get; set; }
        [Required(ErrorMessage ="Session type name is required")]
        public string ProviderSessionType { get; set; }
        [Required(ErrorMessage ="Start time is required")]
        public TimeSpan StartTime { get; set; }
        [Required(ErrorMessage = "End time is required")]
        public TimeSpan EndTime { get; set; }

        public List<ProviderSessionTypeDto>  providerSessionTypeList { get; set; }
    }
}
