using AutoMapper;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediClinic.Services.Services
{
    public class CommonService:ICommonService
    {
        private MediClinicContext _db;
        private IMapper _mapper;

        public CommonService(MediClinicContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        public SelectList CountryList()
        {
            var ContryList = _db.Countries.ToList();
            List<SelectListItem> Countries = new List<SelectListItem>();
            foreach (var item in ContryList)
            {
                Countries.Add(new SelectListItem { Selected = false, Text = item.CountryName, Value = item.id.ToString() });
            }                
            return new SelectList(Countries, "Value", "Text", null);
        }

        public SelectList StateListByCountryId(int countryId)
        {
            var StateList = _db.States.Where(x => x.CountryId.Value == countryId).ToList();
            List<SelectListItem> States = new List<SelectListItem>();
            foreach (var item in StateList)
            {
                States.Add(new SelectListItem { Selected = false, Text = item.StateName, Value = item.Id.ToString() });
            }               
            return new SelectList(States, "Value", "Text", null);
        }

        public SelectList CityListByStateId(int stateId)
        {
            var CityList = _db.Cities.Where(x => x.StateId.Value == stateId).ToList();

            List<SelectListItem> Cities = new List<SelectListItem>();
            foreach (var item in CityList)
            {
                Cities.Add(new SelectListItem { Selected = false, Text = item.CityName, Value = item.Id.ToString() });
            }
            return new SelectList(Cities, "Value", "Text", null);
        }
        public SelectList CityList()
        {
            var CityList = _db.Cities.ToList();

            List<SelectListItem> Cities = new List<SelectListItem>();
            foreach (var item in CityList)
            {
                Cities.Add(new SelectListItem { Selected = false, Text = item.CityName, Value = item.Id.ToString() });
            }
            return new SelectList(Cities, "Value", "Text", null);
        }

    }
}
