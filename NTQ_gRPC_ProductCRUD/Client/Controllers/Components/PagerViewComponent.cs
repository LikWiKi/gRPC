using Microsoft.AspNetCore.Mvc;
using Service;

namespace Client.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PageResult result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
