using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebCrawler.Core.Interfaces;
using WebCrawler.Core.Models;
using WebCrawler.Core.Services;

namespace WebCrawler.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ISimpleWebCrawler crawler = new SimpleWebCrawler(2);
            CrawlResult res = crawler.PerformCrawlingAsync(new []{ "http://knockoutjs.com/" }).Result;
            res = res;
            Thread.Sleep(20000);
            res = res;

        }
    }
}
