using Scanner.Infrastructure.Database;
using Scanner.Infrastructure.Database.Interface;
using Scanner.Infrastructure.HiScoreClient;
using Scanner.Infrastructure.HiScoreClient.Interface;

namespace Scanner.Application.Interactor;

public class RegularHiScoreInteractor
{
    private readonly IHiScoreClient _hiScoreClient = new HiScoreClient();
    private readonly IRunescapeContext _db = new RunescapeContext();

    public async Task Execute()
    {
        var gameVersion = _db.GameVersion.Single(a => a.Name == RunescapeVersion.Regular);
        foreach (var user in _db.Player.Where(a => a.GameVersionId == gameVersion.Id))
        {
            var stats = await _hiScoreClient.IndexLite(user);
            Console.WriteLine("User {0} Rank {1}", stats.Player.Name, stats.Overall.Rank);
        }
    }
}