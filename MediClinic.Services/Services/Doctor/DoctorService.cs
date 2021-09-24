using AutoMapper;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.Doctor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediClinic.Services.Services.Doctor
{
    public class DoctorService: IDoctorService
    {

        private MediClinicContext _context;
        private IMapper _mapper;

        public DoctorService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public SelectList GetMedicine()
        {
            var Medicines = _context.Medicines.ToList();
            List<SelectListItem> MedicineList = new List<SelectListItem>();
            foreach (var item in Medicines)
            {
                MedicineList.Add(new SelectListItem { Selected = false, Text = item.Name, Value = item.Name.ToString() });
            }
            return new SelectList(MedicineList, "Value", "Text", null);
        }
        public SelectList GetMedicinesForTemplate()
        {
            var Medicines = _context.Medicines.ToList();
            List<SelectListItem> MedicineList = new List<SelectListItem>();
            foreach (var item in Medicines)
            {
                MedicineList.Add(new SelectListItem { Selected = false, Text = item.Name, Value = item.Id.ToString() });
            }
            return new SelectList(MedicineList, "Value", "Text", null);
        }
        public SelectList GetDisease()
        {
            var Diseases = _context.Disease.ToList();
            List<SelectListItem> DiseaseList = new List<SelectListItem>();
            foreach (var item in Diseases)
            {
               
                DiseaseList.Add(new SelectListItem { Selected = false, Text = item.Name, Value = item.Name.ToString() });
            }
            return new SelectList(DiseaseList, "Value", "Text", null);
        }
        public SelectList GetDoctorSepcialtyList()
        {
            var Speciality = _context.DoctorSpecialityLookup.ToList();
            List<SelectListItem> SpecialityList = new List<SelectListItem>();
            foreach (var item in Speciality)
            {

                SpecialityList.Add(new SelectListItem { Selected = false, Text = item.SpecialityName, Value = item.SpecialityName.ToString() });
            }
            return new SelectList(SpecialityList, "Value", "Text", null);
        }
    }
}
