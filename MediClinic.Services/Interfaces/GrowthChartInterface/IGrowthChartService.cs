using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.GrowthChartInterface
{
    public interface IGrowthChartService
    {
        public bool Add(GrowthChartDto growthChartDto);
        public Task<List<GrowthChartDto>> GetGrowthChartList(int? Id = null);

        public Task<List<GrowthChartDto>> GetGrowthChartListByVisits(long Id);

        public bool Delete(int growthChartId);
        public GrowthChartDto GetImagingById(int gId);
    }
}
