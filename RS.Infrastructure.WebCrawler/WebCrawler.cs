﻿using HtmlAgilityPack;
using Scanner.Infrastructure.WebCrawler.Interface;
using Scanner.Infrastructure.WebCrawler.Model;
using static System.String;

namespace Scanner.Infrastructure.WebCrawler;

public class WebCrawler : IWebCrawler
{
    private const string RegularHiScoreCrawlerUrl = "https://secure.runescape.com/m=hiscore/ranking?category_type={0}&table={1}&page={2}";
    private const string OldschoolHiScoreCrawlerUrl = "https://secure.runescape.com/m=hiscore_oldschool/overall?table={0}&page={1}";
    private readonly HtmlWeb _web = new();

    public async Task<IEnumerable<CrawlModel>> RegularRanking(int page, string type, string table)
    {
        var list = new List<CrawlModel>();
        var document = await _web.LoadFromWebAsync(Format(RegularHiScoreCrawlerUrl, type, table, page));
        if (document == null)
        {
            throw new Exception("No document element found.");
        }

        var tableElement =
            document.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div/div/div[2]/div[5]/table[2]/tbody");
        if (tableElement == null)
        {
            throw new Exception("No table element found.");
        }

        var elements = tableElement.SelectNodes("tr");
        foreach (var element in elements)
        {
            var rank = int.Parse(element.SelectSingleNode("td[1]/a").InnerText.Replace("\n", Empty)
                .Replace(",", Empty));
            var name = element.SelectSingleNode("td[2]/a").InnerText.Replace("\n", Empty);
            var total = element.SelectSingleNode("td[3]/a").InnerText.Replace("\n", Empty)
                .Replace(",", Empty);
            var xp = long.Parse(element.SelectSingleNode("td[4]/a").InnerText.Replace("\n", Empty)
                .Replace(",", Empty));
            var crawl = new CrawlModel
            {
                ChangeDate = DateTime.UtcNow,
                Page = page,
                Rank = rank,
                UserName = name,
                Total = total,
                Xp = xp
            };
            list.Add(crawl);
        }

        return list;
    }
    
    
    public async Task<IEnumerable<CrawlModel>> OldschoolRanking(int page, string table)
    {
        var list = new List<CrawlModel>();
        var document = await _web.LoadFromWebAsync(Format(OldschoolHiScoreCrawlerUrl, table, page));
        if (document == null)
        {
            throw new Exception("No document element found.");
        }

        var tableElement =
            document.DocumentNode.SelectSingleNode("//table/tbody");
        if (tableElement == null)
        {
            throw new Exception("No table element found.");
        }

        var elements = tableElement.SelectNodes("tr");
        foreach (var element in elements.Skip(1))
        {
            var rank = int.Parse(element.SelectSingleNode("td[1]").InnerText.Replace("\n", Empty)
                .Replace(",", Empty));
            var name = element.SelectSingleNode("td[2]/a").InnerText.Replace("\n", Empty).Replace("\u00a0", " ");
            var total = element.SelectSingleNode("td[3]").InnerText.Replace("\n", Empty)
                .Replace(",", Empty);
            var xp = long.Parse(element.SelectSingleNode("td[4]").InnerText.Replace("\n", Empty)
                .Replace(",", Empty));
            var crawl = new CrawlModel
            {
                ChangeDate = DateTime.UtcNow,
                Page = page,
                Rank = rank,
                UserName = name,
                Total = total,
                Xp = xp
            };
            list.Add(crawl);
        }

        return list;
    }
}