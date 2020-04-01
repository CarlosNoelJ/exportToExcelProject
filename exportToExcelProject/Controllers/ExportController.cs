using library.Model;
using library.Service;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace exportToExcelProject.Controllers
{
    [Route("api/document")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly DocumentService _documentService;

        public ExportController(DocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            var report = await _documentService.GenerateExcelWithActionResult();

            return File(report.memoryStream, "application/octet-stream", report.fileName);
        }
    }
}