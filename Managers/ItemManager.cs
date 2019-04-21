using HtmlAgilityPack;
using LoveAnim.Models;
using LoveAnim.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveAnim.Managers
{
    public class ItemManager
    {
        private static readonly string BASE_URL = "http://kisssub.org/{0}.html";

        private static readonly string BASE_SEARCH_URL = "http://kisssub.org/search.php?keyword={0}&page={1}";

        public static async Task<List<Item>> GetItemsAsync(int page = 1)
        {
            string url = String.Format(BASE_URL, page);
            if (page == 1)
            {
                url = url.Replace("/1.html","");
            }

            string html = await HttpUtil.GetHttpStringAsync(url);

            List<Item> items = HtmlToItems(html);

            return items;
        }

        private static List<Item> HtmlToItems(string html)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            List<Item> items = new List<Item>();
            HtmlNode dataList = htmlDocument.DocumentNode.SelectSingleNode("//tbody[@id='data_list']");
            if(dataList == null)
            {
                return items;
            }
            HtmlNodeCollection trs = dataList?.SelectNodes("tr");
            if (dataList == null && trs.Count == 0)
            {
                return items;
            }

            foreach (HtmlNode tr in trs)
            {
                HtmlNodeCollection tds = tr.SelectNodes("td");
                if(tds.Count <= 1)
                {
                    break;
                }
                Item item = new Item
                {
                    PublishTime = tds[0].InnerText.Trim(),
                    Type = tds[1].InnerText,
                    Title = tds[2].SelectSingleNode("a").InnerText.Trim(),
                    URL = tds[2].SelectSingleNode("a").GetAttributeValue("href", ""),
                    FileSize = tds[3].InnerText,
                    SeedCount = int.Parse(tds[4].InnerText),
                    DownlandCount = int.Parse(tds[5].InnerText),
                    DoneCount = int.Parse(tds[6].InnerText),
                    PublishUP = tds[7].InnerText
                };
                items.Add(item);
            }

            return items;
        }

        public static async Task<string> GetDetailViewHtmlAsync(string url)
        {
            string html = await HttpUtil.GetHttpStringAsync(url);

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='intro']");
            HtmlNodeCollection nodes = htmlNode.SelectNodes("//img");
            if (nodes != null)
                foreach (HtmlNode node in nodes)
                {
                    node.SetAttributeValue("style", "max-width:100%");
                }
            return htmlNode.InnerHtml;
        }

        public static async Task<string> GetDetailFileHtmlAsync(string url)
        {
            string html = await HttpUtil.GetHttpStringAsync(url);

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='torrent_files']");
            HtmlNodeCollection nodes = htmlNode.SelectNodes("//img");
            if (nodes != null)
                foreach (HtmlNode node in nodes)
                {
                    node.SetAttributeValue("src", $"http://kisssub.org/{node.GetAttributeValue("src", "images/icons/folder.gif")}");
                }
            return htmlNode.InnerHtml;
        }

        public static async Task<List<Item>> GetSearchByQueryAsync(string query = "柯南",int page = 1)
        {
            string url = String.Format(BASE_SEARCH_URL, query, page);

            if(page == 1)
            {
                url = url.Replace("&page=1","");
            }

            string html = await HttpUtil.GetHttpStringAsync(url);

            List<Item> results = HtmlToItems(html);

            return results;
        }
    }
}
