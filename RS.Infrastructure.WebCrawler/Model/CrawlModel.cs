namespace Scanner.Infrastructure.WebCrawler.Model;

public class CrawlModel
{
    public int Page { get; set; }
    public int Rank { get; set; }
    public required string Total { get; set; }
    public required long Xp { get; set; }
    public required string UserName { get; set; }
    public DateTime ChangeDate { get; set; }
}