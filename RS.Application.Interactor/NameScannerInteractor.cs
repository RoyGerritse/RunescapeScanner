using Scanner.Domain.Entities;
using Scanner.Infrastructure.Database;
using Scanner.Infrastructure.Database.Interface;
using Scanner.Infrastructure.WebCrawler;
using Scanner.Infrastructure.WebCrawler.Interface;

namespace Scanner.Application.Interactor;

public class NameScannerInteractor
{
    private readonly IWebCrawler _hiScoreCrawler = new WebCrawler();
    private readonly IRunescapeContext _db = new RunescapeContext();

    public async Task Execute()
    {
        await using (_db)
        {
            var max = 0;
            if (_db.LogRecord.Any())
            {
                max = _db.LogRecord.Max(a => a.Page);
            }

            for (var page = max + 1; page <= 80000; page++)
            {
                var list = await _hiScoreCrawler.Ranking(page, "0", "0");
                foreach (var crawl in list.OrderBy(a => a.Rank))
                {
                    var user = _db.User.SingleOrDefault(a => a.Name == crawl.UserName) ?? new User
                    {
                        Id = Guid.NewGuid(),
                        Name = crawl.UserName
                    };
                    _db.LogRecord.Add(new LogRecord
                    {
                        Id = Guid.NewGuid(),
                        Total = crawl.Total,
                        Xp = crawl.Xp,
                        ChangeDate = crawl.ChangeDate,
                        Rank = crawl.Rank,
                        Page = crawl.Page,
                        User = user
                    });
                    Console.WriteLine("Page: {0,-5} Rank: {1,-6} Total: {2,-4} XP: {3,-6} Name: {4,-12}", 
                        crawl.Page, crawl.Rank, crawl.Total, crawl.Xp, crawl.UserName);
                }
                await _db.SaveChangesAsync(CancellationToken.None);

                Thread.Sleep(5005);
            }
        }
    }
}