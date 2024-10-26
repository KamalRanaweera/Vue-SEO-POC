using System.ComponentModel.DataAnnotations;
using POC.VueSEO.Api.Models;

namespace POC.VueSEO.Api.Mock
{
    public class MockPageData
    {
        [Key]
        public string Key { get; set; } = string.Empty;
        public string[]? Head { get; set; }
        public string[]? Body { get; set; }

        public PageData ToPageData() => new()
        {
            Key = Key,
            Head = Head == null ? null : string.Join("\n", Head),
            Body = Body == null ? null : string.Join("\n", Body),
        };
    }
}
