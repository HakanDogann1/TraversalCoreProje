using BusinessLayer.Abstract;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ExcelReportsController : Controller
    {
        private readonly IDestinationService _destinationService;

        public ExcelReportsController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Müşteri Listesi");
            var values = _destinationService.TGetList();
            worksheet.Cell(1, 1).Value = "Id";
            worksheet.Cell(1, 2).Value = "Şehir";
            worksheet.Cell(1, 3).Value = "Tatil Süresi";
            worksheet.Cell(1, 4).Value = "Resim";
            worksheet.Cell(1, 5).Value = "İçerik";
            worksheet.Cell(1, 6).Value = "Kapasite";
            int i= 2;
            foreach (var value in values)
            {
                worksheet.Cell(i, 1).Value = value.DestinationID;
                worksheet.Cell(i, 2).Value = value.City;
                worksheet.Cell(i, 3).Value = value.DayNight;
                worksheet.Cell(i, 4).Value = value.Image;
                worksheet.Cell(i, 5).Value = value.Description;
                worksheet.Cell(i, 6).Value = value.Capasity;
                i++;
            }
            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();
            Random rastgele = new Random();
            string harfler = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZabcçdefgğhıijklmnoöprsştuüvyz";
            string uret = "";
            for (int j = 0; j < 6; j++)
            {
                uret += harfler[rastgele.Next(harfler.Length)];
            }
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",uret+ ".xlsx");
        }
    }
}
