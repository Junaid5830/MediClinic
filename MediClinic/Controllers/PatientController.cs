using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Services.Interfaces.PatientAppointmentInterface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    public class PatientController : Controller
    {
        [Obsolete]
        private readonly IHostingEnvironment _environment;
        private IPatientAppointmentService _appointmentService;

        [Obsolete]
        public PatientController(IHostingEnvironment environment, IPatientAppointmentService appointmentService)
        {
            _environment = environment;
            _appointmentService = appointmentService;
        }

    
      
      
      
        

       
     
   
      


     
        
       

      
     
    
       
        public IActionResult NewExam()
        {
            return View();
        }

        /// <summary>
        /// Saving captured image into Folder.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        //private void StoreInFolder(IFormFile file, string fileName)
        //{
        //    using (FileStream fs = System.IO.File.Create(fileName))
        //    {
        //        file.CopyTo(fs);
        //        fs.Flush();
        //    }
        //}

        /// <summary>
        /// Saving captured image into database.
        /// </summary>
        /// <param name="imageBytes"></param>
        //private void StoreInDatabase(byte[] imageBytes)
        //{
        //    try
        //    {
        //        if (imageBytes != null)
        //        {
        //            string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
        //            string imageUrl = string.Concat("data:image/jpg;base64,", base64String);

        //            ImageStore imageStore = new ImageStore()
        //            {
        //                CreateDate = DateTime.Now,
        //                ImageBase64String = imageUrl,
        //                ImageId = 0
        //            };

        //            _context.ImageStore.Add(imageStore);
        //            _context.SaveChanges();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public IActionResult PatientMedicalHistory()
        {
            return View();
        }
        public async Task<IActionResult> ManagePatientAppointment(int? Id)
        {
            Id = 27;
             AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
                appointmentViewModel.patientAppointmentBasicsList = await _appointmentService.AppointmentList(Id);
                return View(appointmentViewModel);
        }

    }
}