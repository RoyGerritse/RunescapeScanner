using System.Collections.Immutable;
using Scanner.Domain.Entities;
using Scanner.Infrastructure.HiScoreClient.Interface;

namespace Scanner.Infrastructure.HiScoreClient.Models;

public class StatOverview
{
    private readonly Dictionary<int, IStatus> _statsDictionary = new();

    public StatOverview(Player player, string content)
    {
        Player = player;
        var lines = content.Split('\n');
        foreach (var line in lines.Select((value, i) => new { i, value }))
        {
            var split = line.value.Split(',');
            if (split.Length == 0 || split[0] == string.Empty) continue;
            if (line.i < 30)
            {
                var skill = (HiScoreIndex.Skill)line.i;
                _statsDictionary.Add(line.i, split[0] != "-1" ? new SkillStatus(split, skill) : new SkillStatus(skill));
            }
            else
            {
                var activity = (HiScoreIndex.Activity)line.i;
                _statsDictionary.Add(line.i, split[0] != "-1" ? new ActivityStatus(split, activity) : new ActivityStatus(activity));
            }
        }
    }

    public ImmutableArray<IStatus> Stats => [.._statsDictionary.Select(a => a.Value)];
    public Player Player { get; set; }
    
    public SkillStatus Overall => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Overall];
    public SkillStatus Attack => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Attack];
    public SkillStatus Defence => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Defence];
    public SkillStatus Strength => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Strength];
    public SkillStatus Constitution => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Constitution];
    public SkillStatus Ranged => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Ranged];
    public SkillStatus Prayer => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Prayer];
    public SkillStatus Magic => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Magic];
    public SkillStatus Cooking => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Cooking];
    public SkillStatus Woodcutting => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Woodcutting];
    public SkillStatus Fletching => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Fletching];
    public SkillStatus Fishing => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Fishing];
    public SkillStatus Firemaking => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Firemaking];
    public SkillStatus Crafting => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Crafting];
    public SkillStatus Smithing => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Smithing];
    public SkillStatus Mining => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Mining];
    public SkillStatus Herblore => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Herblore];
    public SkillStatus Agility => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Agility];
    public SkillStatus Thieving => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Thieving];
    public SkillStatus Slayer => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Slayer];
    public SkillStatus Farming => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Farming];
    public SkillStatus Runecrafting => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Runecrafting];
    public SkillStatus Hunter => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Hunter];
    public SkillStatus Construction => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Constitution];
    public SkillStatus Summoning => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Summoning];
    public SkillStatus Dungeoneering => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Dungeoneering];
    public SkillStatus Divination => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Divination];
    public SkillStatus Invention => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Invention];
    public SkillStatus Archaeology => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Archaeology];
    public SkillStatus Necromancy => (SkillStatus)Stats[(int)HiScoreIndex.Skill.Necromancy];
    
    public ActivityStatus BountyHunter => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.BountyHunter];
    public ActivityStatus BhRogues => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.BhRogues];
    public ActivityStatus DominionTower => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.DominionTower];
    public ActivityStatus TheCrucible => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.TheCrucible];
    public ActivityStatus CastleWarsGames => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.CastleWarsGames];
    public ActivityStatus BaAttackers => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.BaAttackers];
    public ActivityStatus BaDefenders => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.BaDefenders];
    public ActivityStatus BaCollectors => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.BaCollectors];
    public ActivityStatus BaHealers => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.BaHealers];
    public ActivityStatus DuelTournament => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.DuelTournament];
    public ActivityStatus MobilisingArmies => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.MobilisingArmies];
    public ActivityStatus Conquest => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.Conquest];
    public ActivityStatus FistOfGuthix => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.FistOfGuthix];
    public ActivityStatus GgAthletics => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.GgAthletics];
    public ActivityStatus GgResourceRace => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.GgResourceRace];
    public ActivityStatus WeArmadylLifetimeContribution => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.WeArmadylLifetimeContribution];
    public ActivityStatus WeBandosLifetimeContribution => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.WeBandosLifetimeContribution];
    public ActivityStatus WeArmadylPvPkills => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.WeArmadylPvPkills];
    public ActivityStatus WeBandosPvPkills => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.WeBandosPvPkills];
    public ActivityStatus HeistGuardLevel => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.HeistGuardLevel];
    public ActivityStatus HeistRobberLevel => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.HeistRobberLevel];
    public ActivityStatus Fp5GameAverage => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.Fp5GameAverage];
    public ActivityStatus Af15CowTipping => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.Af15CowTipping];
    public ActivityStatus RatsKilledAfterTheMiniquest => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.RatsKilledAfterTheMiniquest];
    public ActivityStatus RuneScore => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.RuneScore];
    public ActivityStatus ClueScrollsEasy => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.ClueScrollsEasy];
    public ActivityStatus ClueScrollsMedium => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.ClueScrollsMedium];
    public ActivityStatus ClueScrollsHard => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.ClueScrollsHard];
    public ActivityStatus ClueScrollsElite => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.ClueScrollsElite];
    public ActivityStatus ClueScrollsMaster => (ActivityStatus)Stats[(int)HiScoreIndex.Activity.ClueScrollsMaster];
}