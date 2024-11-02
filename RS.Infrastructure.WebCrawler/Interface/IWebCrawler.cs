using Scanner.Domain.Entities;

namespace Scanner.Infrastructure.WebCrawler.Interface;

public interface IWebCrawler
{
    Task<IEnumerable<LogRecord>> Ranking(int page, string type, string table);
}