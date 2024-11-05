using Microsoft.EntityFrameworkCore;
using Scanner.Domain.Entities;
using Scanner.Infrastructure.Database;
using Scanner.Infrastructure.Database.Interface;
using Scanner.Infrastructure.HiScoreClient;
using Scanner.Infrastructure.HiScoreClient.Interface;
using Scanner.Infrastructure.HiScoreClient.Models;

namespace Scanner.Application.Interactor;

public class RegularHiScoreInteractor
{
    private readonly IHiScoreClient _hiScoreClient = new HiScoreClient();
    private readonly IRunescapeContext _db = new RunescapeContext();

    public async Task Execute()
    {
        var activities = await GetOrCreateActivities();
        var skills = await GetOrCreateSkills();
        var gameVersion = _db.GameVersion.Single(a => a.Name == RunescapeVersion.Regular);
        var users = _db.Player.Where(a => a.GameVersionId == gameVersion.Id).Take(100).ToList();
        foreach (var user in users)
        {
            var statOverview = await _hiScoreClient.IndexLite(user);
            Console.WriteLine("User {0} Rank {1}", statOverview.Player.Name, statOverview.Overall.Rank);
            var currentSkills = _db.SkillStat.Where(a => a.PlayerId == user.Id && a.GameVersionId == gameVersion.Id)
                .ToList();
            var currentActivities = _db.ActivityStat.Where(a => a.PlayerId == user.Id && a.GameVersionId == gameVersion.Id)
                .ToList();

            foreach (var stat in statOverview.Stats)
            {
                var lastUpdated = DateTime.Now;
                if (stat is ActivityStatus activityStatus)
                {
                    var activity = activities.Single(a => a.Name == activityStatus.Activity.ToString());
                    var currentActivityStat = currentActivities.SingleOrDefault(a => a.Activity.Id == activity.Id);
                    if (currentActivityStat == null)
                    {
                        var activityStat = new ActivityStat
                        {

                            Id = Guid.NewGuid(),
                            Player = user,
                            Activity = activity,
                            GameVersion = gameVersion,
                            LastUpdated = lastUpdated,
                            Score = activityStatus.Score,
                            Rank = activityStatus.Rank
                        };
                        _db.ActivityStat.Add(activityStat);
                    }
                    else
                    {
                        _db.ActivityStatHistory.Add(new ActivityStatHistory
                        {
                            Id = Guid.NewGuid(),
                            Player = user,
                            GameVersion = gameVersion,
                            Activity = currentActivityStat.Activity,
                            Rank = currentActivityStat.Rank,
                            Score = currentActivityStat.Score,
                            RecordedAt = currentActivityStat.LastUpdated
                        });
                        currentActivityStat.LastUpdated = lastUpdated;
                        currentActivityStat.Score = activityStatus.Score;
                        currentActivityStat.Rank = activityStatus.Rank;
                        _db.Update(currentActivityStat);
                    }
                }

                if (stat is SkillStatus skillStatus)
                {
                    var skill = skills.Single(a => a.Name == skillStatus.Skill.ToString());
                    var currentSkillStat = currentSkills.SingleOrDefault(a => a.Skill.Id == skill.Id);
                    if (currentSkillStat == null)
                    {
                        var skillStat = new SkillStat
                        {

                            Id = Guid.NewGuid(),
                            Player = user,
                            Skill = skill,
                            GameVersion = gameVersion,
                            LastUpdated = lastUpdated,
                            Experience = skillStatus.Experience,
                            Level = skillStatus.Level,
                            Rank = skillStatus.Rank
                        };
                        _db.SkillStat.Add(skillStat);
                    }
                    else
                    {
                        _db.SkillStatHistory.Add(new SkillStatHistory
                        {
                            Id = Guid.NewGuid(),
                            Player = user,
                            GameVersion = gameVersion,
                            Skill = currentSkillStat.Skill,
                            Rank = currentSkillStat.Rank,
                            Experience = currentSkillStat.Experience,
                            Level = currentSkillStat.Level,
                            RecordedAt = currentSkillStat.LastUpdated
                        });
                        currentSkillStat.LastUpdated = lastUpdated;
                        currentSkillStat.Experience = skillStatus.Experience;
                        currentSkillStat.Level = skillStatus.Level;
                        currentSkillStat.Rank = skillStatus.Rank;
                        _db.Update(currentSkillStat);
                    }
                }
            }
            await _db.SaveChangesAsync(CancellationToken.None);
        }
    }

    private async Task<List<Activity>> GetOrCreateActivities()
    {
        var activities = await _db.Activity.ToListAsync();
        foreach (var name in Enum.GetNames(typeof(HiScoreIndex.Skill)))
        {
            if (activities.Any(x => x.Name == name)) continue;
            var activity = new Activity
            {
                Id = Guid.NewGuid(),
                Name = name
            };
            _db.Activity.Add(activity);
            activities.Add(activity);
        }

        await _db.SaveChangesAsync(CancellationToken.None);
        return activities;
    }

    private async Task<List<Skill>> GetOrCreateSkills()
    {
        var skills = await _db.Skill.ToListAsync();
        foreach (var name in Enum.GetNames(typeof(HiScoreIndex.Skill)))
        {
            if (skills.Any(x => x.Name == name)) continue;
            var skill = new Skill
            {
                Id = Guid.NewGuid(),
                Name = name
            };
            _db.Skill.Add(skill);
            skills.Add(skill);
        }

        await _db.SaveChangesAsync(CancellationToken.None);
        return skills;
    }
}