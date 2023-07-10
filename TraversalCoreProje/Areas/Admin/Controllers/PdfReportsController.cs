using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using DataAccessLayer.Concrete;
using System.Linq;
using DocumentFormat.OpenXml.Spreadsheet;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class PdfReportsController : Controller
    {
        private readonly IDestinationService _destinationService;

        public PdfReportsController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "pdfFile.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            PdfPTable pdfPTable = new PdfPTable(6);
            pdfPTable.AddCell("Id");
            pdfPTable.AddCell("Şehir");
            pdfPTable.AddCell("Tatil Süresi");
            pdfPTable.AddCell("Resim");
            pdfPTable.AddCell("İçerik");
            pdfPTable.AddCell("Kapasite");

            foreach (var item in values)
            {
                pdfPTable.AddCell(item.DestinationID.ToString());
                pdfPTable.AddCell(item.City.ToString());
                pdfPTable.AddCell(item.DayNight.ToString());
                pdfPTable.AddCell(item.Image.ToString());
                pdfPTable.AddCell(item.Description.ToString());
                pdfPTable.AddCell(item.Capasity.ToString());
            }
            document.Add(pdfPTable);
            document.Close();

            return File("/pdfreports/pdfFile.pdf", "application/pdf", "pdfFile.pdf");
        }
    }
}
