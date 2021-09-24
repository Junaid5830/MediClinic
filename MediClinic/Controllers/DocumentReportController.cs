using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Services.Interfaces.DoucmentRepertInterface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace MediClinic.Controllers
{
    public class DocumentReportController : Controller
    {
        private IDocumentReportService _DocumentReportService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DocumentReportController(IDocumentReportService documentReportService, IWebHostEnvironment webHostEnvironment)
        {
            _DocumentReportService = documentReportService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Document(int? Id)
        {
            DocumentViewModel documentViewModel = new DocumentViewModel();
            documentViewModel.DocumentList = await _DocumentReportService.DocumentList();
            return View(documentViewModel);
        }
        [HttpGet]
        public IActionResult DocumentAdd(int? Id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DocumentAdd(DocumentViewModel documentViewModel)
        {
            var fileName = "";
            if (documentViewModel.Document.File != null)
            {
                //upload files to wwwroot
                fileName = Path.GetFileName(documentViewModel.Document.File.FileName);
                //judge if it is pdf file
                string ext = Path.GetExtension(documentViewModel.Document.File.FileName);

                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Files", fileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await documentViewModel.Document.File.CopyToAsync(fileSteam);
                }
            }
            documentViewModel.Document.SourceOfDocument = fileName;
            if (documentViewModel.Document.DocumentName == "Initial Report")
            {
                documentViewModel.Document.DocumentInitalReport = true;
            }
            else if (documentViewModel.Document.DocumentName == "DME Prescription")
            {
                documentViewModel.Document.DocumentDMEPrescription = true;
            }
            else if (documentViewModel.Document.DocumentName == "Declofenac Prescription")
            {
                documentViewModel.Document.DocumentDeclofenac = true;
            }
            else
            {
                documentViewModel.Document.DocumentDriverLiecense = true;
            }
            await _DocumentReportService.CreateDocument(documentViewModel.Document);
            return RedirectToAction("Document", "DocumentReport");
        }
        private string GetFullPath(string filename)
        {
            return this._webHostEnvironment.WebRootPath + "\\Files\\" + filename;
        }
        [HttpGet]
        public async Task<FileResult> GetFile(int? Id)
        {
            DocumentViewModel documentViewModel = new DocumentViewModel();

            var GetRec = await _DocumentReportService.DocumentById((int)Id);
            documentViewModel.Document = GetRec.Data;
            string PDFpath = "wwwroot/Files/" + documentViewModel.Document.SourceOfDocument;
            byte[] abc = System.IO.File.ReadAllBytes(PDFpath);
            System.IO.File.WriteAllBytes(PDFpath, abc);
            MemoryStream ms = new MemoryStream(abc);
            return new FileStreamResult(ms, "application/pdf");
        }
        public async Task<IActionResult> Download(int Id)
        {
            DocumentViewModel documentViewModel = new DocumentViewModel();

            var GetRec = await _DocumentReportService.DocumentById((int)Id);
            documentViewModel.Document = GetRec.Data;
            if (documentViewModel.Document.SourceOfDocument == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot\\Files", documentViewModel.Document.SourceOfDocument);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        public IActionResult DeleteDocument(int Id)
        {
            var rec = _DocumentReportService.DocumentDelete(Id);
            var data = new { Success = "Data saved successfully" };
            return Json(data);
        }
    }
}
