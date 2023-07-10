using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TraversalCoreProje.Areas.Admin.Data;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(cities);
            return Json(jsonCity);
        }
        public static List<CityClass> cities = new List<CityClass>
        {
            new CityClass
            {
                CityCountry="Makedonya",
                CityID=1,
                CityName="Üsküp"
            },
              new CityClass
            {
                CityCountry="İtalya",
                CityID=2,
                CityName="Roma"
            },
                new CityClass
            {
                CityCountry="İngiltere",
                CityID=3,
                CityName="Londra"
            }
        };
    }
}
