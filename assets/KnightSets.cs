using System.Collections.Generic;
using Classes;
using Enums;
using Godot;

namespace Utils{
    
    public class KnightSets{

        public static int Length{
            get{
                return sets.Count;
            }
        }

        public static readonly double[,] setBonusRepartition = new double[,]
        {
            {0, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
            {0, 30, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
            {0, 20, 50, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
            {0, 10, 30, 60, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
            {0, 5, 15, 35, 65, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
            {0, 5, 15, 30, 50, 75, 100, 100, 100, 100, 100, 100, 100, 100, 100},
            {0, 3, 9, 18, 30, 50, 70, 100, 100, 100, 100, 100, 100, 100, 100},
            {0, 0, 5, 10, 20, 30, 40, 50, 70, 100, 100, 100, 100, 100, 100},
            {0, 5, 10, 20, 30, 40, 50, 60, 70, 80, 100, 100, 100, 100, 100},
            {0, 0, 5, 10, 20, 30, 40, 50, 60, 70, 80, 100, 100, 100, 100},
            {0, 0, 0, 5, 10, 20, 30, 40, 50, 60, 70, 80, 100, 100, 100},
            {0, 0, 0, 0, 5, 10, 20, 30, 40, 50, 60, 70, 80, 100, 100},
            {0, 0, 0, 0, 0, 5, 10, 20, 30, 40, 50, 60, 70, 80, 100},
        };

        private static Dictionary<int, PartSet> sets = new Dictionary<int, PartSet>()
        {
            [0] = new PartSet(170, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Baker
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.TITLE] = new List<PartDescription>(){
                    new PartDescription(26, RarityEnum.COMMON)
                },
            }),
            [1] = new PartSet(367, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Joker
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_UNCOMMON)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_UNCOMMON)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_UNCOMMON)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_UNCOMMON)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.EPIC)
                },
                [KnightPartEnum.TITLE] = new List<PartDescription>(){
                    new PartDescription(26, RarityEnum.UNCOMMON)
                },
            }),
            [2] = new PartSet(1837, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Medium
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.LEGENDARY)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(95, RarityEnum.EPIC)
                },
            }),
            [3] = new PartSet(9430, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //robot
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_LEGENDARY)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_LEGENDARY)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_LEGENDARY)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_LEGENDARY)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(3, RarityEnum.LEGENDARY)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(3, RarityEnum.LEGENDARY)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(30, RarityEnum.LEGENDARY)
                },
            }),
            [4] = new PartSet(89650, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //ange
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(14, RarityEnum.MYTHICAL)
                },
            }),
            [5] = new PartSet(89650, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //demon
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(15, RarityEnum.MYTHICAL)
                },
            }),
            [6] = new PartSet(480, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //chat
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(4, RarityEnum.LEGENDARY)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(6, RarityEnum.EPIC)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(69, RarityEnum.EPIC)
                },
            }),
            [7] = new PartSet(424, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //chien
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(13, RarityEnum.EPIC)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(3, RarityEnum.EPIC)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(128, RarityEnum.UNCOMMON)
                },
            }),
            [8] = new PartSet(2064, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //loup
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_LEGENDARY)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(8, RarityEnum.EPIC)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(4, RarityEnum.LEGENDARY)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(126, RarityEnum.UNCOMMON)
                },
            }),
            [9] = new PartSet(424, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //lezard
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(3, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.EPIC)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.EPIC)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(131, RarityEnum.UNCOMMON)
                },
            }),
            [10] = new PartSet(472, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //orc
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(4, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.LEGENDARY)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(10, RarityEnum.UNCOMMON, true)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(74, RarityEnum.EPIC)
                },
            }),
            [11] = new PartSet(55055, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //roi
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.LEGENDARY, true),
                    new PartDescription(1, RarityEnum.LEGENDARY, true),
                },
                [KnightPartEnum.CAPE] = new List<PartDescription>(){
                    new PartDescription(12, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.TITLE] = new List<PartDescription>(){
                    new PartDescription(9, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_LEGENDARY)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_LEGENDARY)
                },
            }),
            [12] = new PartSet(99002, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //momochang
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(3, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.UNCOMMON, true)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(3, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.NAME] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(8, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_MYTHICAL)
                },
            }),
            [13] = new PartSet(170, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Forgeron
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.TITLE] = new List<PartDescription>(){
                    new PartDescription(27, RarityEnum.COMMON)
                },
            }),
            [14] = new PartSet(389, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Sorcier
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_UNCOMMON)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_UNCOMMON)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_UNCOMMON)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_UNCOMMON)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(3, RarityEnum.EPIC)
                },
                [KnightPartEnum.TITLE] = new List<PartDescription>(){
                    new PartDescription(6, RarityEnum.UNCOMMON)
                },
                [KnightPartEnum.NAME] = new List<PartDescription>(){
                    new PartDescription(22, RarityEnum.UNCOMMON)
                },
            }),
            [15] = new PartSet(1695, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Frog
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(14, RarityEnum.EPIC)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(7, RarityEnum.EPIC)
                },
                [KnightPartEnum.TITLE] = new List<PartDescription>(){
                    new PartDescription(22, RarityEnum.UNCOMMON)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(96, RarityEnum.EPIC)
                },
                [KnightPartEnum.NAME] = new List<PartDescription>(){
                    new PartDescription(21, RarityEnum.EPIC)
                },
                [KnightPartEnum.CAPE] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.UNCOMMON)
                },
            }),
            [16] = new PartSet(1773030, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Midas
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.LEGENDARY, true),
                    new PartDescription(1, RarityEnum.LEGENDARY, true)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.LEGENDARY, true),
                    new PartDescription(1, RarityEnum.LEGENDARY, true)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.LEGENDARY, true),
                    new PartDescription(1, RarityEnum.LEGENDARY, true),
                    new PartDescription(2, RarityEnum.LEGENDARY, true)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.LEGENDARY, true),
                    new PartDescription(1, RarityEnum.LEGENDARY, true),
                    new PartDescription(2, RarityEnum.LEGENDARY, true)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.LEGENDARY)
                },
                [KnightPartEnum.TITLE] = new List<PartDescription>(){
                    new PartDescription(9, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.LEGENDARY)
                },
                [KnightPartEnum.NAME] = new List<PartDescription>(){
                    new PartDescription(12, RarityEnum.LEGENDARY)
                },
                [KnightPartEnum.MAIN_ENCHANT] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.OFF_ENCHANT] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.CAPE] = new List<PartDescription>(){
                    new PartDescription(22, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.SHINYNESS] = new List<PartDescription>(){
                    new PartDescription(0, RarityEnum.EPIC)
                },
            }),
            [17] = new PartSet(186374, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Batman
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_LEGENDARY)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(1, RarityEnum.SPECIAL_LEGENDARY)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_LEGENDARY)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_LEGENDARY)
                },
                [KnightPartEnum.TITLE] = new List<PartDescription>(){
                    new PartDescription(22, RarityEnum.UNCOMMON)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(24, RarityEnum.EPIC)
                },
                [KnightPartEnum.NAME] = new List<PartDescription>(){
                    new PartDescription(13, RarityEnum.LEGENDARY)
                },
                [KnightPartEnum.CAPE] = new List<PartDescription>(){
                    new PartDescription(21, RarityEnum.LEGENDARY)
                },
            }),
            [18] = new PartSet(235, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Snowman
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.EPIC)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.COMMON)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.EPIC)
                },
                [KnightPartEnum.CAPE] = new List<PartDescription>(){
                    new PartDescription(-1, RarityEnum.NONE, true)
                },
            }),
            [19] = new PartSet(840, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Zombie
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(7, RarityEnum.EPIC)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(15, RarityEnum.EPIC)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(8, RarityEnum.EPIC)
                },
                [KnightPartEnum.PET] = new List<PartDescription>(){
                    new PartDescription(3, RarityEnum.COMMON, -1)
                },
            }),
            [20] = new PartSet(1969, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Elfe de noel
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.LEGENDARY)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.EPIC)
                },
                [KnightPartEnum.BODY] = new List<PartDescription>(){
                    new PartDescription(5, RarityEnum.UNCOMMON, true)
                },
            }),
            [21] = new PartSet(105000, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Santa
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.NAME] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.PET] = new List<PartDescription>(){
                    new PartDescription(1000, RarityEnum.EPIC, -1)
                },
            }),
            [22] = new PartSet(1525, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Pirate
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_UNCOMMON)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_UNCOMMON)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_UNCOMMON)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_UNCOMMON)
                },
                [KnightPartEnum.TITLE] = new List<PartDescription>(){
                    new PartDescription(27, RarityEnum.UNCOMMON)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(20, RarityEnum.UNCOMMON)
                },
                [KnightPartEnum.PET] = new List<PartDescription>(){
                    new PartDescription(3, RarityEnum.UNCOMMON, -1)
                },
            }),
            [23] = new PartSet(61968, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //bouftou
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(5, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.TITLE] = new List<PartDescription>(){
                    new PartDescription(23, RarityEnum.EPIC)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(97, RarityEnum.EPIC)
                },
                [KnightPartEnum.CAPE] = new List<PartDescription>(){
                    new PartDescription(20, RarityEnum.EPIC)
                },
                [KnightPartEnum.PET] = new List<PartDescription>(){
                    new PartDescription(2, RarityEnum.LEGENDARY, -1)
                },
            }),
            [24] = new PartSet(234, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Hippie
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.SPECIAL_COMMON)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.EPIC)
                },
                [KnightPartEnum.NAME] = new List<PartDescription>(){
                    new PartDescription(25, RarityEnum.UNCOMMON)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.COMMON)
                },
                [KnightPartEnum.CAPE] = new List<PartDescription>(){
                    new PartDescription(-1, RarityEnum.UNCOMMON, true)
                },
            }),
            [25] = new PartSet(33163, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Diver
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.SPECIAL_EPIC)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.LEGENDARY)
                },
                [KnightPartEnum.NAME] = new List<PartDescription>(){
                    new PartDescription(22, RarityEnum.EPIC)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.EPIC)
                },
                [KnightPartEnum.PET] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.UNCOMMON, -1)
                },
                [KnightPartEnum.CAPE] = new List<PartDescription>(){
                    new PartDescription(20, RarityEnum.EPIC)
                },
            }),
            [26] = new PartSet(1603800, new Dictionary<KnightPartEnum, List<PartDescription>>(){ //Mermaid
                [KnightPartEnum.HELMET] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.ARMOR] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.MAIN_HAND] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.OFF_HAND] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.SPECIAL_MYTHICAL)
                },
                [KnightPartEnum.TRAIT] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.FACE] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.MYTHICAL)
                },
                [KnightPartEnum.PET] = new List<PartDescription>(){
                    new PartDescription(1001, RarityEnum.EPIC, -1)
                },
                [KnightPartEnum.CAPE] = new List<PartDescription>(){
                    new PartDescription(22, RarityEnum.MYTHICAL, false)
                },
            }),
        };

        public static bool HasSetPart(Knight knightToCheck, int setIndex)
        {
            if(sets.ContainsKey(setIndex))
            {
                return sets[setIndex].HasPartOfSet(knightToCheck);
            }
            return false;
        }

        public static List<int> GetSetIndexes(KnightData knightToCheck)
        {
            List<int> indexes = new List<int>();
            foreach(KeyValuePair<int, PartSet> setPair in sets)
            {
                if(setPair.Value.HasSet(knightToCheck))
                    indexes.Add(setPair.Key);
            }
            return indexes;
        }

        public static double GetSetBonuses(KnightData knightToCheck)
        {
            double bonus = 1;
            foreach(KeyValuePair<int, PartSet> setPair in sets)
            {
                
                bonus+=setPair.Value.GetSetBonus(knightToCheck);
            }
            return bonus;
        }

        public static Dictionary<KnightPartEnum, List<PartDescription>> GetSetPartInfos(int setIndex)
        {
            if(sets.ContainsKey(setIndex))
            {
                return sets[setIndex].Parts;
            }
            return null;
        }


        public static List<SetInformation> GetSetInfos(Knight knightToCheck)
        {
            List<SetInformation> setsList = new List<SetInformation>();
            foreach(KeyValuePair<int, PartSet> setPair in sets)
            {
                SetInformation newSet = setPair.Value.GetSetInformation(knightToCheck);
                if(newSet != null)
                {
                    newSet.setIndex = setPair.Key;
                    setsList.Add(newSet);
                } 
            }
            setsList.Sort();
            return setsList;
        }

        public static bool SetNeedPremium(int setId)
        {
            if(sets.ContainsKey(setId))
            {
                return sets[setId].NeedPremium();
            }
            return false;
        }

        public static string GetAnyPartString(KnightPartEnum namePart)
        {
            switch(namePart)
            {
                case KnightPartEnum.BODY:
                case KnightPartEnum.FACE:
                case KnightPartEnum.ARMOR:
                case KnightPartEnum.HELMET:
                case KnightPartEnum.CAPE:
                case KnightPartEnum.MAIN_HAND:
                case KnightPartEnum.OFF_HAND:
                case KnightPartEnum.PET:
                    return "QUEST_ANY_" + namePart.ToString();
                case KnightPartEnum.MAIN_ENCHANT:
                case KnightPartEnum.OFF_ENCHANT:
                case KnightPartEnum.BOTH_ENCHANT:
                    return "QUEST_ANY_ENCHANT";
                default:
                    return "";
            }
        }

        public static string GetPartNameString(KnightPartEnum namePart, int partIndex, RarityEnum partRarity)
        {
            string endString = ((int)partRarity) + "_" + partIndex;
            string name = "KNIGHT_";
            if((int)partRarity >= (int)RarityEnum.SPECIAL_COMMON)
            {
                name += "SPECIAL_";
                endString = GD.Str((int)partRarity - (int)RarityEnum.SPECIAL_COMMON) + "_" + partIndex;
            }
            switch(namePart)
            {
                case KnightPartEnum.PET:
                    return name + "PET_" + endString;
                case KnightPartEnum.BODY:
                    return name + "BODY_" + endString;
                case KnightPartEnum.FACE:
                    return name + "FACE_" + endString;
                case KnightPartEnum.ARMOR:
                    return name + "ARMOR_" + endString;
                case KnightPartEnum.HELMET:
                    return name + "HELMET_" + endString;
                case KnightPartEnum.CAPE:
                        string secondPart = name + "CAPE_COLOR_" + partIndex;
                        return secondPart;
                case KnightPartEnum.MAIN_HAND:
                    return name + "MAIN_" + endString;
                case KnightPartEnum.OFF_HAND:
                    return name + "OFF_" + endString;
                case KnightPartEnum.MAIN_ENCHANT:
                case KnightPartEnum.OFF_ENCHANT:
                case KnightPartEnum.BOTH_ENCHANT:
                    return name + "ENCHANT_" + endString;
                case KnightPartEnum.NAME:
                    return name + "NAMES_" + endString;
                case KnightPartEnum.TITLE:
                    return name + "TITLES_" + endString;
                case KnightPartEnum.TRAIT:
                    return name + endString;
                case KnightPartEnum.SHINYNESS:
                    return "SHINY_" + GD.Str((int)partRarity);
                default:
                    return "";
            }
        }
    }
}