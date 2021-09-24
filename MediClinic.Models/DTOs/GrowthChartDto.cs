using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class GrowthChartDto
    {

        public int GrowthId { get; set; }
        public DateTime? TodayDate { get; set; }
        public DateTime? DOB { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public decimal? Length { get; set; }
        public decimal? HeadDiameter { get; set; }
        public decimal? NeckDiameter { get; set; }
        public decimal? WaistDiameter { get; set; }
        public decimal? ShoulderWidth { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public int? VisitId { get; set; }
    }
}
