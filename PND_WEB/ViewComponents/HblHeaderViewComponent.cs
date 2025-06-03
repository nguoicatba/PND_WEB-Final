using Microsoft.AspNetCore.Mvc;

namespace PND_WEB.ViewComponents
{
    public class HblHeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string Title, string SubTitle, string Hbl_ID, string Job_ID)
        {
            ViewBag.Job_ID = Job_ID;
            (string Title, string SubTitle, string Hbl_ID) data = (Title, SubTitle, Hbl_ID);
            return View(data);
        }
    }
}
