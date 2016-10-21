using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebCrawler.Core.Interfaces;
using WebCrawler.Core.Models;
using HtmlAgilityPack;

namespace WebCrawler.Core.Services
{
    public class SimpleWebCrawler : ISimpleWebCrawler
    {
        private int MaxDepth { get; set; }

        public SimpleWebCrawler(int maxDepth)
        {
            this.MaxDepth = maxDepth;
        }


        public async Task<CrawlResult> PerformCrawlingAsync(string[] rootUrls)
        {
            CrawlResult result = new CrawlResult();
            foreach (var root in rootUrls)
            {
                result.Roots.Add(await Task.Factory.StartNew(() => CrawlUrl(root, 0).Result));
            }
            Task.WaitAll();
            return result;
        }

        private async Task<UrlModel> CrawlUrl(string url, int depth)
        {


            UrlModel result = new UrlModel();
            result.Url = url;
            result.Level = depth;
            
            if (depth < MaxDepth)
            {
                HtmlWeb hw = new HtmlWeb();

                HtmlDocument doc = await Task.Factory.StartNew(() => hw.Load(url));
                
                Console.WriteLine(url);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(depth + "\r\n");

                var nodes = doc.DocumentNode.SelectNodes("//a[@href]");
                IEnumerable<string> links = new List<string>();
                if (nodes != null)
                {
                    links = nodes.ToList().Where(x => x.Attributes.AttributesWithName("href").Any() && x.Attributes["href"].Value != null).Select(x => new Uri(new Uri(new Uri(url).GetLeftPart(UriPartial.Path)), x.Attributes["href"].Value)).Where(x => x.IsWellFormedOriginalString() && CheckUrlValid(x.AbsoluteUri)).Select(x => x.AbsoluteUri);
                }

                Parallel.ForEach(links, link =>
                {
                    try
                    {
                        result.InnerUrls.Add(CrawlUrl(link, depth + 1).Result);
                    }
                    catch
                    {
                        // ignored
                    }
                });

            }

            
            return result;
        }

        private bool CheckUrlValid(string source)
        {
            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        }

    }
}
