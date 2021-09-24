using MediClinic.Models.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Services.Interfaces.Doctor
{
    public interface IDoctorService
    {
        public SelectList GetMedicine();
        public SelectList GetDisease();
        public SelectList GetDoctorSepcialtyList();
        public SelectList GetMedicinesForTemplate();
    }
}
