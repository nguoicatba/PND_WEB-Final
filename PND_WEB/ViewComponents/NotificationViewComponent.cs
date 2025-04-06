using Microsoft.AspNetCore.Mvc;

namespace PND_WEB.ViewComponents
{
    public class NotificationViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string Title,bool status)
        {
            (string Title, bool status) data = (Title, status);

            return View(data);
        }
    }
}
