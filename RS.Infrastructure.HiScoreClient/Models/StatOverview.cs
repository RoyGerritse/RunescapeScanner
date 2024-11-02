using Scanner.Domain.Entities;

namespace Scanner.Infrastructure.HiScoreClient.Models;

public class StatOverview
{
    private readonly Dictionary<int, IStat> _statsDictionary = new();

    public StatOverview(User user, string content)
    {
        User = user;
        var lines = content.Split('\n');
        foreach (var line in lines.Select((value, i) => new { i, value }))
        {
            var split = line.value.Split(',');
            if (split.Length == 0 || split[0] == string.Empty) continue;
            if (line.i < 30)
            {
                _statsDictionary.Add(line.i, split[0] != "-1" ? new SkillStat(split) : new SkillStat());
            }
            else
            {
                _statsDictionary.Add(line.i, split[0] != "-1" ? new ActivityStat(split) : new ActivityStat());
            }
        }
    }

    private IList<IStat> Stats => _statsDictionary.Select(a => a.Value).ToList();
    public User User { get; set; }
    public SkillStat Overall => (SkillStat)Stats[0];
    public SkillStat Attack => (SkillStat)Stats[1];
    public SkillStat Defence => (SkillStat)Stats[2];
    public SkillStat Strength => (SkillStat)Stats[3];
    public SkillStat Constitution => (SkillStat)Stats[4];
    public SkillStat Ranged => (SkillStat)Stats[5];
    public SkillStat Prayer => (SkillStat)Stats[6];
    public SkillStat Magic => (SkillStat)Stats[7];
    public SkillStat Cooking => (SkillStat)Stats[8];
    public SkillStat Woodcutting => (SkillStat)Stats[9];
    public SkillStat Fletching => (SkillStat)Stats[10];
    public SkillStat Fishing => (SkillStat)Stats[11];
    public SkillStat Firemaking => (SkillStat)Stats[12];
    public SkillStat Crafting => (SkillStat)Stats[13];
    public SkillStat Smithing => (SkillStat)Stats[14];
    public SkillStat Mining => (SkillStat)Stats[15];
    public SkillStat Herblore => (SkillStat)Stats[16];
    public SkillStat Agility => (SkillStat)Stats[17];
    public SkillStat Thieving => (SkillStat)Stats[18];
    public SkillStat Slayer => (SkillStat)Stats[19];
    public SkillStat Farming => (SkillStat)Stats[20];
    public SkillStat Runecrafting => (SkillStat)Stats[21];
    public SkillStat Hunter => (SkillStat)Stats[22];
    public SkillStat Construction => (SkillStat)Stats[23];
    public SkillStat Summoning => (SkillStat)Stats[24];
    public SkillStat Dungeoneering => (SkillStat)Stats[25];
    public SkillStat Divination => (SkillStat)Stats[26];
    public SkillStat Invention => (SkillStat)Stats[27];
    public SkillStat Archaeology => (SkillStat)Stats[28];
    public SkillStat Necromancy => (SkillStat)Stats[29];
    
    public ActivityStat BountyHunter => (ActivityStat)Stats[30];
    public ActivityStat BhRogues => (ActivityStat)Stats[31];
    public ActivityStat DominionTower => (ActivityStat)Stats[32];
    public ActivityStat TheCrucible => (ActivityStat)Stats[33];
    public ActivityStat CastleWarsgames => (ActivityStat)Stats[34];
    public ActivityStat BaAttackers => (ActivityStat)Stats[35];
    public ActivityStat BaDefenders => (ActivityStat)Stats[36];
    public ActivityStat BaCollectors => (ActivityStat)Stats[37];
    public ActivityStat BaHealers => (ActivityStat)Stats[38];
    public ActivityStat DuelTournament => (ActivityStat)Stats[39];
    public ActivityStat MobilisingArmies => (ActivityStat)Stats[40];
    public ActivityStat Conquest => (ActivityStat)Stats[41];
    public ActivityStat FistOfGuthix => (ActivityStat)Stats[42];
    public ActivityStat GgAthletics => (ActivityStat)Stats[43];
    public ActivityStat GgResourceRace => (ActivityStat)Stats[44];
    public ActivityStat WeArmadylLifetimeContribution => (ActivityStat)Stats[45];
    public ActivityStat WeBandosLifetimeContribution => (ActivityStat)Stats[46];
    public ActivityStat WeArmadylPvPkills => (ActivityStat)Stats[47];
    public ActivityStat WeBandosPvPkills => (ActivityStat)Stats[48];
    public ActivityStat HeistGuardLevel => (ActivityStat)Stats[49];
    public ActivityStat HeistRobberLevel => (ActivityStat)Stats[50];
    public ActivityStat Fp5GameAverage => (ActivityStat)Stats[51];
    public ActivityStat Af15CowTipping => (ActivityStat)Stats[52];
    public ActivityStat RatsKilledAfterTheMiniquest => (ActivityStat)Stats[53];
    public ActivityStat RuneScore => (ActivityStat)Stats[54];
    public ActivityStat ClueScrollsEasy => (ActivityStat)Stats[55];
    public ActivityStat ClueScrollsMedium => (ActivityStat)Stats[56];
    public ActivityStat ClueScrollsHard => (ActivityStat)Stats[57];
    public ActivityStat ClueScrollsElite => (ActivityStat)Stats[58];
    public ActivityStat ClueScrollsMaster => (ActivityStat)Stats[59];
}