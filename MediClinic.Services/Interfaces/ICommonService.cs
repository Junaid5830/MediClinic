using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Services.Interfaces
{
    public interface ICommonService
    {
        public SelectList CountryList();
        public SelectList StateListByCountryId(int countryId);
        public SelectList CityListByStateId(int stateId);
        public SelectList CityList();
    }
}
