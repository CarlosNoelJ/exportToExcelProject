using library.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace library.IService
{
    public interface IDocumentsService
    {
        Task<ExcelReport> GenerateExcelWithActionResult();
    }
}
