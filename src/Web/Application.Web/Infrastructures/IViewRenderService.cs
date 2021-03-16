namespace Application.Web.Infrastructure
{
    using System.Threading.Tasks;

    public interface IViewRenderService
    {
        public Task<string> RenderToStringAsync(string viewName, object model);
    }
}
