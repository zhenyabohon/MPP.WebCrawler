using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Core.Models
{
    public class UrlModel
    {
        public int Level { get; set; }

        public string Url { get; set; }

        public ConcurrentBag<UrlModel> InnerUrls { get; set; }

        public UrlModel()
        {
            InnerUrls = new ConcurrentBag<UrlModel>();
        }


    }
}
