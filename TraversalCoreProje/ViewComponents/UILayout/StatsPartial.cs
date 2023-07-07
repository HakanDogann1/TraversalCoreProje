using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProje.ViewComponents.UILayout
{
    public class StatsPartial:ViewComponent
    {
        private readonly IDestinationService _destinationService;

      
        public IViewComponentResult Invoke()
        {
            using var context = new Context();
            ViewBag.v1 = context.Destinations.Count();
            ViewBag.v2 = context.Guides.Count();
            ViewBag.v3 = "285";
           return View();
        }
    }
}
