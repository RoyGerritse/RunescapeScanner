using Scanner.Domain.Entities;
using Scanner.Infrastructure.HiScoreClient.Models;

namespace Scanner.Infrastructure.HiScoreClient;

public interface IHiScoreClient
{
    Task<StatOverview> IndexLite(User user);
}