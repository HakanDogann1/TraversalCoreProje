using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.UILayout
{
    public class FooterPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
