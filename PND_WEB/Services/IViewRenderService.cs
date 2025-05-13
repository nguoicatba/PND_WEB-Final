namespace PND_WEB.Services
{
    public interface IViewRenderService
    {
        Task<string> RenderViewToStringAsync(string viewName, object model);
    }
}