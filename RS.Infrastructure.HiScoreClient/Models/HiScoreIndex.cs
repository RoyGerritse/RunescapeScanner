namespace Scanner.Infrastructure.HiScoreClient.Models;

public static class HiScoreIndex
{
    public enum Skill
    {
        Overall = 0,
        Attack = 1,
        Defence = 2,
        Strength = 3,
        Constitution = 4,
        Ranged = 5,
        Prayer = 6,
        Magic = 7,
        Cooking = 8,
        Woodcutting = 9,
        Fletching = 10,
        Fishing = 11,
        Firemaking = 12,
        Crafting = 13,
        Smithing = 14,
        Mining = 15,
        Herblore = 16,
        Agility = 17,
        Thieving = 18,
        Slayer = 19,
        Farming = 20,
        Runecrafting = 21,
        Hunter = 22,
        Construction = 23,
        Summoning = 24,
        Dungeoneering = 25,
        Divination = 26,
        Invention = 27,
        Archaeology = 28,
        Necromancy = 29
    }

    public enum Activity
    {
        BountyHunter = 30,
        BhRogues = 31,
        DominionTower = 32,
        TheCrucible = 33,
        CastleWarsGames = 34,
        BaAttackers = 35,
        BaDefenders = 36,
        BaCollectors = 37,
        BaHealers = 38,
        DuelTournament = 39,
        MobilisingArmies = 40,
        Conquest = 41,
        FistOfGuthix = 42,
        GgAthletics = 43,
        GgResourceRace = 44,
        WeArmadylLifetimeContribution = 45,
        WeBandosLifetimeContribution = 46,
        WeArmadylPvPkills = 47,
        WeBandosPvPkills = 48,
        HeistGuardLevel = 49,
        HeistRobberLevel = 50,
        Fp5GameAverage = 51,
        Af15CowTipping = 52,
        RatsKilledAfterTheMiniquest = 53,
        RuneScore = 54,
        ClueScrollsEasy = 55,
        ClueScrollsMedium = 56,
        ClueScrollsHard = 57,
        ClueScrollsElite = 58,
        ClueScrollsMaster = 59
    }
}