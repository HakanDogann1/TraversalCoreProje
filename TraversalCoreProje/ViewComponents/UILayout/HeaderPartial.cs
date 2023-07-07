using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.UILayout
{
    public class HeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
