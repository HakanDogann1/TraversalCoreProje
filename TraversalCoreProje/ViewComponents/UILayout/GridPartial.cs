using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.UILayout
{
    public class GridPartial:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public GridPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }
    }
}
