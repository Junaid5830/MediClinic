using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PharmacyInterface
{
    public interface IPharmacyService
    {
        public Task<bool> Add(PharmacyDto pharDto);

        public Task<List<PharmacyDto>> getlist();

        public bool Delete(int pharId);

        public PharmacyDto GetPharById(int pharId);
    }
}
