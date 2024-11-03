using Scanner.Domain.Entities;
using Scanner.Infrastructure.Database;
using Scanner.Infrastructure.Database.Interface;
using Scanner.Infrastructure.WebCrawler;
using Scanner.Infrastructure.WebCrawler.Interface;

namespace Scanner.Application.Interactor;

public class PlayerNameScannerInteractor
{
    private const string SessionName = "PlayerNameScanner";
    private readonly IWebCrawler _hiScoreCrawler = new WebCrawler();
    private readonly IRunescapeContext _db = new RunescapeContext();

    public async Task Execute()
    {
        await using (_db)
        {
            var session = await GetOrCreateSession();
            var current = int.Parse(session.Setting["Page"]);
            for (var page = current + 1; page <= 80000; page++)
            {
                var list = await _hiScoreCrawler.Ranking(page, "0", "0");
                foreach (var crawl in list.OrderBy(a => a.Rank))
                {
                    var player = _db.Player.SingleOrDefault(a => a.Name == crawl.UserName) ?? new Player
                    {
                        Id = Guid.NewGuid(),
                        Name = crawl.UserName,
                        AccountType = AccountType.Unknown
                    };
                    _db.Player.Add(player);
                    Console.WriteLine("Page: {0} Rank: {1} Total: {2} XP: {3} Name: {4}", crawl.Page,
                        crawl.Rank,
                        crawl.Total, crawl.Xp, crawl.UserName);
                }

                session.Setting["Page"] = page.ToString();
                _db.CurrentSession.Update(session);
                await _db.SaveChangesAsync(CancellationToken.None);
                Thread.Sleep(5005);
            }
        }
    }

    private async Task<CurrentSession> GetOrCreateSession()
    {
        var session = _db.CurrentSession.SingleOrDefault(a => a.SessionName == SessionName && a.Active);
        if (session != null) return session;
        session = new CurrentSession
        {
            Id = Guid.NewGuid(),
            SessionName = SessionName,
            Active = true,
            Setting = new Dictionary<string, string>
            {
                { "Page", "0" }
            },
        };
        _db.CurrentSession.Add(session);
        await _db.SaveChangesAsync(CancellationToken.None);
        return session;
    }
}