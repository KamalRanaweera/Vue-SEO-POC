using POC.VueSEO.Api.Interfaces;
using POC.VueSEO.Api.Mock;
using POC.VueSEO.Api.Models;
using System.Text.Json;

namespace POC.VueSEO.Api.Mockups
{
    public class MockPageDataService : IPageDataService
    {
        private readonly MockPageData[] _mockData;

        public MockPageDataService()
        {
            _mockData = JsonSerializer.Deserialize<MockPageData[]>(File.ReadAllText("Mockups\\MockPageData.json"), new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })!;
        }

        public PageData? GetPageData(string key)
        {
            return _mockData.FirstOrDefault(x => x.Key == key)?.ToPageData();
        }
    }
}
