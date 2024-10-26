using POC.VueSEO.Api.Models;

namespace POC.VueSEO.Api.Interfaces
{
    public interface IPageDataService
    {
        public PageData? GetPageData(string key);
    }
}
