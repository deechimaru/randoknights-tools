using Classes;
using Godot;
using System;
using System.Collections.Generic;

namespace Constants{
    public static class GameData
    {

        #region Quest Data

        public const int refreshQuestTime = 8;

        #endregion

        #region FilterData
        
        public static readonly int[] setUnlockedAfter = new int[]{
            -1, //Baker
            0,  //Joker
            1,  //Medium
            2,  //Robot
            8,  //Angel
            8,  //Devil
            1,  //cat
            1,  //dog
            3,  //wolf
            1,  //lizard
            1,  //orc
            17,  //king
            7, //Momochang
            -1, //Blacksmith
            13,  //Wizard
            14, //Frog
            17, //Midas
            15, //Batman
            -2, //Snowman
            -1, //Zombie
            -2, //Lutin
            -2, //Pere noel
            18, //Pirate
            19, //Bouftou
            -2, //Hippie
            -2, //Diver
            -2, //Siren
        };

        public static readonly SeasonSet[] seasonSetsUnlockedAfter = new SeasonSet[]{
            new SeasonSet(11,2,18,-1),
            new SeasonSet(11,2,20, 0),
            new SeasonSet(11,2,21, 1),
            new SeasonSet(6,8,24,-1),
            new SeasonSet(6,8,25, 0),
            new SeasonSet(6,8,26, 1),
        };

        #endregion

        #region Ritual Data
        public const float ritualPriceFactor = 10f;

        public const float anvilPriceFactor = 1f;
        public const int ritualKnightSize = 4;

        public static readonly Vector2[] ritualKnightPositions = new Vector2[]{
            new Vector2(579, 815),
            new Vector2(761, 1252),
            new Vector2(250, 1172),
            new Vector2(513, 1088),
        };

        public static readonly float[] ritualKnightsRotations = new float[]{
            188,
            -61,
            75,
            0
        };
        #endregion

        #region Dispenser data
        public static readonly double[] dispenserPrices = new double[]{
            1,              //1
            7.5,            //5 *1.5
            20,             //10 * 2
            75,             //25 * 3
            200,            //50 * 4    
            500,            //100 * 5
            10000,          //1k * 10
            10000000,        //10k * 100
            10000000000,      //100k * 1000
            1000000000000      //1M * 10000
        };

        public static readonly int[] dispenserBuyTickets = new int[]{
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            4,
            5,
            6,
            7
        };

        public static readonly int[] dispenserTicketRewardCap = new int[]{
            3000,
            2900,
            2800,
            2600,
            2400,
            2100,
            1800,
            1400,
            1000,
            500
        };

        public const int maxDispenserQuantity = 100;

        #endregion

        #region General Data
        public const float upgradeKnightFactor = 0.025f;

        public const float knightSellFactor = 2000;
        public const float knightMuseumFactor = 1000;

        public static readonly float[] knightCapsuleSellFactor = new float[]{
            1,
            10,
            100,
            1000,
            10000
        };

        #endregion

        #region Max Part Numbers
        
        public static readonly int[] bodyNumbers = { 15, 11, 9, 5, 3 };
        public static readonly int[] faceNumbers = { 33, 21, 16, 6, 4 };
        public static readonly int[] capeMaxIndex = { 6, 11, 16, 20, 23 };

        public static readonly int[] specialHelmetNumbers = { 3, 3, 6, 3, 4 };
        public static readonly int[] specialArmorNumbers = { 3, 3, 3, 2, 3 };
        public static readonly int[] specialMainhandNumbers = { 3, 3, 3, 3, 3 };
        public static readonly int[] specialOffHandNumbers = { 3, 3, 3, 3, 3 };

        public static readonly int[] nameNumbers = {60, 26, 23, 20, 8};
        public static readonly int[] traitNumbers = {217, 144, 98, 34, 17};
        public static readonly int[] titleNumbers = {28, 28, 24, 14, 12};

        public static readonly int[] petNumbers = { 5, 5, 5, 5, 5 };

        public static readonly List<ushort>[] normalEnchantIndexes = {
            new List<ushort>{ 0, 1},
            new List<ushort>{ 0, 1},
            new List<ushort>{ 0, 1},
            new List<ushort>{ 0, 1},
            new List<ushort>{ 0, 1},
        };

        public static readonly List<ushort>[] rareEnchantIndexes = {
            new List<ushort>{ 2, 3, 4},
            new List<ushort>{ 2, 3, 4},
            new List<ushort>{ 2, 3, 4},
            new List<ushort>{ 2, 3, 4},
            new List<ushort>{ 2, 3, 4},
        };

        public static readonly List<ushort>[] normalMainWeaponIndexes = {
            new List<ushort>{ 0, 1, 2},
            new List<ushort>{ 0, 1, 2},
            new List<ushort>{ 0, 1, 2},
            new List<ushort>{ 0, 1, 2},
            new List<ushort>{ 0, 1, 2},
        };

        public static readonly List<ushort>[] rareMainWeaponIndexes = {
            new List<ushort>{ 3, 4, 5},
            new List<ushort>{ 3, 4, 5},
            new List<ushort>{ 3, 4, 5},
            new List<ushort>{ 3, 4, 5},
            new List<ushort>{ 3, 4, 5},
        };

        public static readonly List<ushort>[] normalOffWeaponIndexes = {
            new List<ushort>{ 0, 1, 2},
            new List<ushort>{ 0, 1, 2},
            new List<ushort>{ 0, 1, 2},
            new List<ushort>{ 0, 1, 2},
            new List<ushort>{ 0, 1, 2},
        };

        public static readonly List<ushort>[] rareOffWeaponIndexes = {
            new List<ushort>{ 3, 4, 5},
            new List<ushort>{ 3, 4, 5},
            new List<ushort>{ 3, 4, 5},
            new List<ushort>{ 3, 4, 5},
            new List<ushort>{ 3, 4, 5},
        };

        public static readonly List<ushort>[] normalArmorIndexes = {
            new List<ushort>{ 0, 1},
            new List<ushort>{ 0, 1},
            new List<ushort>{ 0, 1},
            new List<ushort>{ 0, 1},
            new List<ushort>{ 0, 1},
        };

        public static readonly List<ushort>[] rareArmorIndexes = {
            new List<ushort>{ 2, 3},
            new List<ushort>{ 2, 3},
            new List<ushort>{ 2, 3},
            new List<ushort>{ 2, 3},
            new List<ushort>{ 2, 3},
        };

        public static readonly List<ushort>[] normalHelmetIndexes = {
            new List<ushort>{ 0, 1},
            new List<ushort>{ 0, 1},
            new List<ushort>{ 0, 1},
            new List<ushort>{ 0, 1},
            new List<ushort>{ 0, 1},
        };

        public static readonly List<ushort>[] rareHelmetIndexes = {
            new List<ushort>{ 2, 3},
            new List<ushort>{ 2, 3},
            new List<ushort>{ 2, 3},
            new List<ushort>{ 2, 3},
            new List<ushort>{ 2, 3},
        };

        #endregion

        #region Rank Thresholds

        public static readonly double[] rankThresholds = {
            0,                      //wood
            50,                     //Tin
            300,                    //Copper
            1200,                   //Iron
            5000,                   //Bronze
            25000,                  //Silver
            100000,                 //Gold
            400000,                 //Platinum
            1200000,                //Mithril
            5000000,                //Orichalcum
            25000000,               //Obsidian
            100000000,              //Amber 
            400000000,              //Pearl 
            2000000000,             //Coral 
            8000000000,             //Jade
            40000000000,            //Amethyste
            100000000000,           //Diamond
            2000000000000,          //Ruby
            40000000000000,         //Sapphire
            800000000000000,        //Emerald
            16000000000000000,      //Garnet
            320000000000000000,     //Peridot
            6400000000000000000,    //Tanzanite
            1E+20,                  //Aquamarine
            1E+22,                  //Alexandrite
            1E+24,                  //Tourmaline
            1E+26,                  //Superist
            1E+29,                  //Wonderdot
            1E+32,                  //Hyperald
            1E+35,                  //Ultramire
            1E+39,                  //Megamond
            1E+43,                  //Masterite
            1E+50,                  //Perfectone
            1E+58                   //True Perfectone
        };

        public static readonly double[] invertedRankThresholds = {
            0,                      //wood
            1E+21,                  //Tin
            1E+23,                    //Copper
            1E+25,                   //Iron
            1E+27,                   //Bronze
            1E+29,                  //Silver
            1E+31,                 //Gold
            1E+33,                 //Platinum
            1E+35,                //Mithril
            1E+37,                //Orichalcum
            1E+39,               //Obsidian
            1E+41,              //Amber 
            1E+43,              //Pearl 
            1E+45,             //Coral 
            1E+47,             //Jade
            1E+49,            //Amethyste
            1E+51,           //Diamond
            1E+53,          //Ruby
            1E+55,         //Sapphire
            1E+57,        //Emerald
            1E+59,      //Garnet
            1E+62,     //Peridot
            1E+65,    //Tanzanite
            1E+68,                  //Aquamarine
            1E+71,                  //Alexandrite
            1E+74,                  //Tourmaline
            1E+77,                  //Superist
            1E+80,                  //Wonderdot
            1E+83,                  //Hyperald
            1E+86,                  //Ultramire
            1E+89,                  //Megamond
            1E+92,                  //Masterite
            1E+95,                  //Perfectone
            1E+98                   //True Perfectone
        };

        #endregion

        #region Token Generation values

        public static readonly double[] rankTokenValues = {
            0,                      //wood
            0.1,                      //Tin
            0.2,                    //Copper
            0.4,                   //Iron
            0.6,                   //Bronze
            0.8,                  //Silver
            1,                 //Gold
            1.5,                 //Platinum
            2,                //Mithril
            2.5,                //Orichalcum
            3,               //Obsidian
            3.5,              //Amber 
            4,              //Pearl 
            4.5,             //Coral 
            5,             //Jade
            6,            //Amethyste
            7,           //Diamond
            8,          //Ruby
            9,         //Sapphire
            10,        //Emerald
            11,      //Garnet
            12,     //Peridot
            13,    //Tanzanite
            14,                  //Aquamarine
            15,                  //Alexandrite
            16,                  //Tourmaline
            17,                  //Superist
            18,                  //Wonderdot
            19,                  //Hyperald
            20,                  //Ultramire
            22,                  //Megamond
            24,                  //Masterite
            26,                  //Perfectone
            30                   //True Perfectone
        };

        public static readonly double[] shinyTokenValues = {
            1,                      //Normal
            1.15,                      //Silver
            1.3,                    //Gold
            1.6,                   //Red
            2,                   //Black
        };

        public const double authenticTokenMultiplier = 3;
        public const double ritualTokenMultiplier = 0.5;
        #endregion

        #region Rarity Multipliers
        public const int capeMultiplier = 5;
        public const int enchantMultiplier = 10;
        public const int invertedMultiplier = 250;
        public const int invertedBonusMultiplier = 10;
        public const int petMultiplier = 500;
        public const int shinyPetMultiplier = 2500;
        public const int leftHandedMultiplier = 2;
        public const int armorSetMultiplier = 12;
        public const int rareArmorSetMultiplier = 120;
        public const int equipmentsTierMultiplier = 20;
        public const int rareEquipmentsTierMultiplier = 200;
        public const int namesTierMultiplier = 20;
        public const int physicsTierMultiplier = 10;
        public const int enchantsTierMultiplier = 30;
        public const int rareEnchantMultiplier = 50;

        public static readonly int[] rarityValue = new int[]{
            1,
            2,
            10,
            50,
            500
        };

        public static readonly int[] rareRarityValue = new int[]{
            10,
            10,
            10,
            10,
            10
        };

        public static readonly int[] specialRarityValue = new int[]{
            100,
            200,
            1000,
            5000,
            50000
        };

        #endregion

        #region Coin Values

        public static readonly float[] coinValues = new float[]{
            0.01f,
            0.05f,
            0.2f,
            0.5f,
            1f,
            2f,
            5f,
            10f,
            20f,
            50f,
            100f,
            200f,
            500f
        };
        #endregion

        #region Familiar Boosts

        public const double shinyFamiliarBoost = 3;
        public const double invertedFamiliarBoost = 1.5;

        public static readonly double[] familiarCouchBoost = {
            5, //Chat, chien, lapin
            10, //Escargot, slime
            25, //Goblin, Ghost
            45, //Tortue, flower
            75, //Golem, lizard
        };

        public static readonly double[] familiarDispenserBoost = {
            3, //Chat, chien, lapin
            6, //Escargot, slime
            15, //Goblin, Ghost
            30, //Tortue, flower
            60, //Golem, lizard
        };

        public static readonly double[] familiarMuseumBoost = {
            5, //Chat, chien, lapin
            10, //Escargot, slime
            25, //Goblin, Ghost
            45, //Tortue, flower
            75, //Golem, lizard
        };

        public static readonly double[] familiarCollectionMuseumBoost = {
            1, //Chat, chien, lapin
            2, //Escargot, slime
            4, //Goblin, Ghost
            7, //Tortue, flower
            10, //Golem, lizard
        };

        public static readonly double[] familiarAnvilBoost = {
            0.95, //Chat, chien, lapin
            0.9, //Escargot, slime
            0.8, //Goblin, Ghost
            0.65, //Tortue, flower
            0.4, //Golem, lizard
        };
        #endregion
    }
}

