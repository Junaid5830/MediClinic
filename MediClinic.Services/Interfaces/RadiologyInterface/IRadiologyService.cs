using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.RadiologyInterface
{
        public interface IRadiologyService
    {
        public bool Add(RadiologyDto radiologyDto);
        public List<RadiologyDto> getlist();

        public bool Delete(int radiologyId);
        public RadiologyDto GetRadiolById(int radiolId);
    }
}
