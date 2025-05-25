using Microsoft.AspNetCore.Mvc;

namespace PND_WEB.ViewComponents
{
    public class JobDetailsHeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string Title, string SubTitle, string Job_ID)
        {

            (string Title, string SubTitle, string Job_ID) data = (Title, SubTitle, Job_ID);
            return View(data);
        }
    }
}
