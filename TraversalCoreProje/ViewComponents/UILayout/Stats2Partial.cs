using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.UILayout
{
    public class Stats2Partial:ViewComponent
    {
        private readonly IFeatureService _featureService;

        public Stats2Partial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _featureService.TGetList();
            return View();
        }
    }
}
