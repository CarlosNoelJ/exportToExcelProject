using library.IService;
using library.Model;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace library.Service
{
    public class DocumentService : IDocumentsService
    {
        public async Task<ExcelReport> GenerateExcelWithActionResult()
        {
            await Task.Yield();

            var list = new List<ProvisionalReportClass>()
            {
                new ProvisionalReportClass { reportId = 1 , dataName = "DataName1", dataLastName = "DataName1" },
                new ProvisionalReportClass { reportId = 1 , dataName = "DataName2", dataLastName = "DataName2" },
                new ProvisionalReportClass { reportId = 1 , dataName = "DataName3", dataLastName = "DataName3" }
            };

            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                package.Save();
            }

            stream.Position = 0;
            string excelName = "report.xlsx";

            var excelReport = new ExcelReport()
            {
                memoryStream = stream,
                fileName = excelName
            };

            return excelReport;
        }
    }
}
