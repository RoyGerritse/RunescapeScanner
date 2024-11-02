using HtmlAgilityPack;
using Scanner.Domain.Entities;
using Scanner.Infrastructure.WebCrawler.Interface;
using static System.String;

namespace Scanner.Infrastructure.WebCrawler;

public class WebCrawler : IWebCrawler
{
    private const string HiScoreCrawlerUrl = "https://secure.runescape.com/m=hiscore/ranking?category_type={0}&table={1}&page={2}";
    private readonly HtmlWeb _web = new();

    public async Task<IEnumerable<LogRecord>> Ranking(int page, string type, string table)
    {
        var list = new List<LogRecord>();
        var document = await _web.LoadFromWebAsync(Format(HiScoreCrawlerUrl, type, table, page));
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
            var user = new LogRecord
            {
                Id = Guid.NewGuid(),
                ChangeDate = DateTime.UtcNow,
                Page = page,
                Rank = rank,
                User = new User
                {
                    Id = default,
                    Name = name,
                },
                Total = total,
                Xp = xp
            };
            list.Add(user);
        }

        return list;
    }
}