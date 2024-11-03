using Scanner.Domain.Entities;
using Scanner.Infrastructure.WebCrawler.Model;

namespace Scanner.Infrastructure.WebCrawler.Interface;

public interface IWebCrawler
{
    Task<IEnumerable<CrawlModel>> RegularRanking(int page, string type, string table);
}