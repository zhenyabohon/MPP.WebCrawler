using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Core.Models
{
    public class CrawlResult
    {
        public ConcurrentBag<UrlModel> Roots { get; set; }

        public CrawlResult()
        {
            Roots = new ConcurrentBag<UrlModel>();
        }
    }
}
