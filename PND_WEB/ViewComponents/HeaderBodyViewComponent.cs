using Microsoft.AspNetCore.Mvc;

namespace PND_WEB.ViewComponents
{
    public class HeaderBodyViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string Title, string SubTitle)
        {
            (string Title, string SubTitle) data = (Title, SubTitle);
            return View(data);
        }
    }
}
