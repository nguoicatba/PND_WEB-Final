using Microsoft.AspNetCore.Mvc;

namespace PND_WEB.ViewComponents
{
    public class HblNavTabViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string HBL_ID,bool isLGT)
        {
            (string HBL_ID, bool isLGT) data = (HBL_ID, isLGT);
            return View(data);
        }
    }
    
}
