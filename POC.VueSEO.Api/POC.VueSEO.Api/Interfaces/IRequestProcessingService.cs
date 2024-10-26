namespace POC.VueSEO.Api.Interfaces
{
    public interface IRequestProcessingService
    {
        public Task<string> ProcessIndex(string? path, HttpContext context);
    }
}
