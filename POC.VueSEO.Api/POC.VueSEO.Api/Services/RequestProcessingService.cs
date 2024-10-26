using POC.VueSEO.Api.Interfaces;
using POC.VueSEO.Api.Mockups;

namespace POC.VueSEO.Api.Services
{
    public class RequestProcessingService : IRequestProcessingService
    {
        private readonly IPageDataService _pageDataService;
        private readonly string _vueAppRoot;
        public RequestProcessingService(IPageDataService pageDataService, IConfiguration configuration)
        {
            _pageDataService = pageDataService;
            _vueAppRoot = configuration.GetSection("VueAppPublishRoot").Value!;
        }

        public async Task<string> ProcessIndex(string? path, HttpContext context)
        {
            var fileContent = await File.ReadAllTextAsync($"{_vueAppRoot}\\index.html");

            bool should_prerender = ShouldPrerender(context);

            //CAUTION: forcing to pre-render always for testing it interractively.
            should_prerender = true; 

            if (should_prerender)
            {
                /**
                 * CAUSION:
                 * This method assumes that the "pageData" retrieved below consists of 
                 * the following structure
                 *      - Head: contains the additional elements that needs to be inserted into the head section of the output HTML file.
                 *      - Body: contains the content of the HTML body element that needs to be rendered in the body of the output HTML file.
                 *      
                 * If these assumptions are not valid, this code segment should be updated accordingly.
                 */

                var pageData = _pageDataService.GetPageData(string.IsNullOrEmpty(path) ? "home" : path);
                if (pageData != null)
                {
                    if (pageData.Head != null)
                    {
                        var index = fileContent.IndexOf("</head>");
                        var part1 = fileContent.Substring(0, index);
                        var part2 = fileContent.Substring(index);
                        fileContent = $"{part1}\n{pageData.Head}\n{part2}";
                    }

                    if (pageData.Body != null)
                    {
                        var index = fileContent.IndexOf("<body>");
                        var part1 = fileContent.Substring(0, index + 6);
                        fileContent = $"{part1}\n{pageData.Body}\n</body?</html>";
                    }
                    return fileContent;
                }
            }
            return fileContent;
        }

        private static bool ShouldPrerender(HttpContext context)
        {
            string userAgent = context.Request.Headers.UserAgent.ToString().ToLower();

            if (userAgent.Contains("googlebot") ||
                userAgent.Contains("facebookexternalhit") || userAgent.Contains("facebot") ||
                userAgent.Contains("bingbot")
                //TODO: Recognize any other SEO bots here ...
                )
                return true;
            else
                return false;
        }
    }
}
