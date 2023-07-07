using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.UILayout
{
    public class TestimonialPartial:ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _testimonialService.TGetList();
            return View(values);
        }
    }
}
