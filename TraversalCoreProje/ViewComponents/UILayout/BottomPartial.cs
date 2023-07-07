using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.UILayout
{
    public class BottomPartial:ViewComponent
    {
        private readonly ISubAboutService _subAboutService;

        public BottomPartial(ISubAboutService subAboutService)
        {
            _subAboutService = subAboutService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _subAboutService.TGetList();
            return View(values);
        }
    }
}
