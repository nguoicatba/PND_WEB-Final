using Microsoft.AspNetCore.Mvc;

namespace PND_WEB.ViewComponents
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<BreadcrumbItem> items)
        {
            return View(items);
        }

        public class BreadcrumbItem
        {
            public string Title { get; set; }
            public string Controller { get; set; }

            public string Action { get; set; }

            public string Parameter { get; set; }
            public bool IsActive => string.IsNullOrEmpty(Controller);
        }
    }
}
