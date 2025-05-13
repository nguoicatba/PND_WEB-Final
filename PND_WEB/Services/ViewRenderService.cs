using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using PND_WEB.Services;

public class ViewRenderService : IViewRenderService
{
    private readonly ICompositeViewEngine _viewEngine;
    private readonly ITempDataProvider _tempDataProvider;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ViewRenderService(
        ICompositeViewEngine viewEngine,
        ITempDataProvider tempDataProvider,
        IHttpContextAccessor httpContextAccessor)
    {
        _viewEngine = viewEngine;
        _tempDataProvider = tempDataProvider;
        _httpContextAccessor = httpContextAccessor;
    }

    private async Task<string> RenderViewToStringAsync(string viewName, object model)
    {
        var controllerContext = new ControllerContext()
        {
            HttpContext = _httpContextAccessor.HttpContext,
            RouteData = _httpContextAccessor.HttpContext?.GetRouteData(),
            ActionDescriptor = new ControllerActionDescriptor()
        };

        using var sw = new StringWriter();
        var viewResult = _viewEngine.FindView(controllerContext, viewName, false);

        if (viewResult.View == null)
        {
            throw new ArgumentNullException($"{viewName} not found");
        }

        var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
        {
            Model = model
        };

        var tempData = new TempDataDictionary(_httpContextAccessor.HttpContext, _tempDataProvider);
        var viewContext = new ViewContext(
            controllerContext,
            viewResult.View,
            viewDictionary,
            tempData,
            sw,
            new HtmlHelperOptions()
        );

        await viewResult.View.RenderAsync(viewContext);
        return sw.ToString();
    }

    Task<string> IViewRenderService.RenderViewToStringAsync(string viewName, object model)
    {
        return RenderViewToStringAsync(viewName, model);
    }
}
