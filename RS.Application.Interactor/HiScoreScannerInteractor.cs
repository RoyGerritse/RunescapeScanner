using Scanner.Infrastructure.Database;
using Scanner.Infrastructure.Database.Interface;
using Scanner.Infrastructure.HiScoreClient;

namespace Scanner.Application.Interactor;

public class HiScoreScannerInteractor
{
    private readonly IHiScoreClient _hiScoreClient = new HiScoreClient();
    private readonly IRunescapeContext _db = new RunescapeContext();

    public async Task Execute()
    {
        foreach (var user in _db.User)
        {
            var stats = await _hiScoreClient.IndexLite(user);
            Console.WriteLine("User {0} Rank {1}", stats.User.Name, stats.Overall.Rank);
        }
    }
}