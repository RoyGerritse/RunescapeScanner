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
                foreach (var arr in list.OrderBy(a => a.Rank))
                {
                    {
                        arr.User = _db.User.SingleOrDefault(a => a.Name == arr.User.Name) ?? arr.User;
                        _db.LogRecord.Add(arr);
                        Console.WriteLine("Page: {0} Rank: {1} Total: {2} XP: {3} Name: {4}", arr.Page,
                            arr.Rank,
                            arr.Total, arr.Xp, arr.User.Name);
                    }

                    await _db.SaveChangesAsync(CancellationToken.None);
                }

                Thread.Sleep(5005);
            }
        }
    }
}