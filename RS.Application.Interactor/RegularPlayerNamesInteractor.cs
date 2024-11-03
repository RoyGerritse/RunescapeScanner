using Scanner.Domain.Entities;
using Scanner.Infrastructure.Database;
using Scanner.Infrastructure.Database.Interface;
using Scanner.Infrastructure.WebCrawler;
using Scanner.Infrastructure.WebCrawler.Interface;

namespace Scanner.Application.Interactor;

public class RegularPlayerNamesInteractor
{
    private const string SessionName = "RegularPlayerNames";

    private readonly IWebCrawler _hiScoreCrawler = new WebCrawler();
    private readonly IRunescapeContext _db = new RunescapeContext();

    public async Task<bool> Execute()
    {
        await using (_db)
        {
            var session = await GetOrCreateSession();
            var gameVersion = await GetOrCreateGameVersion();
            var current = int.Parse(session.Setting["Page"]);
            for (var page = current + 1; page <= 80000; page++)
            {
                var list = await _hiScoreCrawler.RegularRanking(page, "0", "0");
                var crawlModels = list.ToList();
                if (page > 100 && crawlModels.First().Rank < 100)
                {
                    session.Active = false;
                    _db.CurrentSession.Update(session);
                    break;
                }
                foreach (var crawl in crawlModels.OrderBy(a => a.Rank))
                {
                    
                    var player = _db.Player.SingleOrDefault(a => a.Name == crawl.UserName);
                    var exist = true;
                    if (player == null)
                    {
                        player = new Player
                        {
                            Id = Guid.NewGuid(),
                            Name = crawl.UserName,
                            AccountType = AccountType.Unknown,
                            GameVersion = gameVersion
                        };
                        _db.Player.Add(player);
                        exist = false;
                    }

                    Console.WriteLine("Exist: {0,4} Page: {1,5} Rank: {2,6} Total: {3,4} XP: {4,6} Name: {5,12}",
                        exist, crawl.Page, crawl.Rank, crawl.Total, crawl.Xp, crawl.UserName);
                }

                session.Setting["Page"] = page.ToString();
                _db.CurrentSession.Update(session);
                await _db.SaveChangesAsync(CancellationToken.None);
                Thread.Sleep(6155);
            }
        }

        return false;
    }

    private async Task<GameVersion> GetOrCreateGameVersion()
    {
        var gameVersion = _db.GameVersion.SingleOrDefault(a => a.Name == RunescapeVersion.Regular);
        if (gameVersion != null) return gameVersion;
        gameVersion = new GameVersion
        {
            Id = Guid.NewGuid(),
            Name = RunescapeVersion.Regular
        };
        _db.GameVersion.Add(gameVersion);
        await _db.SaveChangesAsync(CancellationToken.None);
        return gameVersion;
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
            }
        };
        _db.CurrentSession.Add(session);
        await _db.SaveChangesAsync(CancellationToken.None);
        return session;
    }
}