namespace Constants{
    public static class Probability
    {
        #region Knight Probabilities

        public const int maxProba = 9999;

        public static readonly double[] rarityProbabilities = new double[]
        {
            1000f/689f,       //Common
            4,              //Uncommon
            20,             //Epic
            100,            //Legendary
            1000            //Mythical
        };

        public static readonly double[] equipmentProbabilities = new double[]
        {
            1000f/945f,           //Normal
            20,              //Rare
            200,             //Special
        };

        public static readonly double[] enchantProbabilities = new double[]
        {
            100f/99f,           //Normal
            100,              //Rare
        };

        public const double firstProbability = 11.6714291612699;
        public const double probabilityEnchant = 20;
        public const double probabilityNoEnchant = 20f/19f;
        public const double probabilityCape = 10;
        public const double probabilityNoCape = 10f/9f;
        public const double probabilityFamiliar = 1000;
        public const double probabilityNoFamiliar = 1000f/999f;
        public const double probabilityShiny = 5000;
        public const double probabilityNoShiny = 5000f/4999f;
        public const double probabilityReverse = 500;
        public const double probabilityNoReverse = 500/499f;

        public const double probabilityLeftHanded = 5;
        public const double probabilityRightHanded = 5f/4f;

        //shine
        public static readonly double[] shineProbabilities = new double[]
        {
            100000000f/99789899f,
            500,
            10000,
            1000000,
            100000000
        };

        public static readonly int[,] partProbabilities = new int[,]{
            {
                10000,      //Common
                3110,    //Uncommon
                610,     //Epic
                110,     //Legendary
                10       //Mythical
            },
            {
                10000,      //Common
                6220,    //Uncommon
                1220,     //Epic
                220,     //Legendary
                20       //Mythical
            },
            {
                10000,      //Common
                10000,    //Uncommon
                2440,     //Epic
                440,     //Legendary
                40       //Mythical
            },
            {
                10000,      //Common
                10000,    //Uncommon
                4880,     //Epic
                880,     //Legendary
                80       //Mythical
            },
            {
                10000,      //Common
                10000,    //Uncommon
                9760,     //Epic
                1760,     //Legendary
                160       //Mythical
            },
        };

        public const int probaEnchant = 500;
        public const int probaCape = 1000;
        public const int probaFamiliar = 10;
        public const int probaShiny = 2;

        public const int probaReverse = 20;

        public const int probaLeftHanded = 2000;

        public const int probaSpecialPart = 50;
        public const int probaRareEquipPart = 500;
        public const int probaRareEnchantPart = 100;

        public const int seasonPartDrop = 100;
        public const int specialSeasonPartDrop = 500;
        #endregion

        #region Capsule Probability

        public const int probaSilverCapsule = 21;
        public const int probaGoldCapsule = 1;

        public const int probaRedCapsule = 101;
        public const int probaBlackCapsule = 1;


        public static readonly int[] capsuleColorProbabilities = new int[]{
            10000,
            7750,
            5500,
            3250,
            1000, //2000
        };

        #endregion

        #region Ticket probabilities

        public static readonly int[,] ticketCouchDropMinMaxProbabilities = new int[,]{
            {0, 0, 10},
            {1, 1, 10},
            {1, 1, 12},
            {1, 2, 12},
            {1, 2, 14},
            {1, 3, 14},
            {1, 3, 16},
            {2, 3, 16},
            {2, 3, 18},
            {2, 4, 20},
            {3, 4, 20},
        };

        public static readonly int[,] ticketDispenserMaxNumber = new int[,]{
            {1, 1},
            {1, 2},
            {1, 3},
            {1, 4},
            {2, 4},
            {2, 5},
            {3, 5},
            {3, 6},
            {4, 6},
            {5, 7},
        };

        #endregion

        #region Coin probabilities

        public static readonly int[] coinDropProbabilities = new int[]{
            5000,
            6000,
            7000,
            8000,
            9000,
            10000,
            11000,
            12000,
            13000,
            14000,
            15000   
        };
        public static readonly int[,] coinProbabilities = new int[,]{
            {
                10000,
                2888,//0.05
                888, //0.2
                388, //0.5
                188, //1
                88,   //2
                38,   //5
                18,    //10
                8,    //20
                3,    //50
                1,    //100
                0,    //200
                0,    //500
            },
            {
                10000,
                4331,//0.05
                1331, //0.2
                581, //0.5
                281, //1
                131,   //2
                56,   //5
                26,    //10
                11,    //20
                4,    //50
                1,    //100
                0,    //200
                0,    //500
            },
            {
                10000,
                5777,//0.05
                1777, //0.2
                777, //0.5
                377, //1
                177,   //2
                77,   //5
                37,    //10
                17,    //20
                7,    //50
                3,    //100
                1,    //200
                0,    //500
            },
            {
                10000,
                7554,//0.05
                3554, //0.2
                1554, //0.5
                754, //1
                354,   //2
                154,   //5
                74,    //10
                34,    //20
                14,    //50
                6,    //100
                2,    //200
                0,    //500
            },
            {
                10000,
                10000,//0.05
                7109, //0.2
                3109, //0.5
                1509, //1
                709,   //2
                309,   //5
                149,    //10
                69,    //20
                29,    //50
                13,    //100
                5,    //200
                1,    //500
            },
            {
                10000,
                10000,//0.05
                7887, //0.2
                2887, //0.5
                1887, //1
                887,   //2
                387,   //5
                187,    //10
                87,    //20
                37,    //50
                17,    //100
                7,    //200
                2,    //500
            },
            {
                10000,
                10000,//0.05
                10000, //0.2
                5442, //0.5
                2642, //1
                1242,   //2
                542,   //5
                262,    //10
                122,    //20
                52,    //50
                24,    //100
                10,    //200
                3,    //500
            },
            {
                10000,
                10000,//0.05
                10000, //0.2
                7774, //0.5
                3774, //1
                1774,   //2
                774,   //5
                374,    //10
                174,    //20
                74,    //50
                34,    //100
                14,    //200
                4,    //500
            },
            {
                10000,
                10000,//0.05
                10000, //0.2
                10000, //0.5
                5661, //1
                2661,   //2
                1161,   //5
                561,    //10
                261,    //20
                111,    //50
                51,    //100
                21,    //200
                6,    //500
            },
            {
                10000,
                10000,//0.05
                10000, //0.2
                10000, //0.5
                7548, //1
                3548,   //2
                1548,   //5
                748,    //10
                348,    //20
                148,    //50
                68,    //100
                28,    //200
                8,    //500
            },
            {
                10000,
                10000,//0.05
                10000, //0.2
                10000, //0.5
                10000, //1
                4435,   //2
                1935,   //5
                935,    //10
                435,    //20
                185,    //50
                85,    //100
                35,    //200
                10,    //500
            }
        };

        #endregion

        #region Bingo Upgrade Probabilities

         public static readonly int[,] upgradesProbabilities = new int[,]{
            {
                10000,  //Rarity 0
                300,   //Rarity 1
                100,    //Rarity 2
                0,     //Rarity 3
            },
            {
                10000,  //Rarity 0
                650,   //Rarity 1
                250,    //Rarity 2
                50,     //Rarity 3
            },
            {
                10000,  //Rarity 0
                1300,   //Rarity 1
                500,    //Rarity 2
                100,     //Rarity 3
            },
            {
                10000,  //Rarity 0
                2600,   //Rarity 1
                1000,    //Rarity 2
                200,     //Rarity 3
            },
            {
                10000,  //Rarity 0
                5200,   //Rarity 1
                2000,    //Rarity 2
                400,     //Rarity 3
            },
            {
                10000,  //Rarity 0
                10000,   //Rarity 1
                4000,    //Rarity 2
                800,     //Rarity 3
            },
            {
                10000,  //Rarity 0
                10000,   //Rarity 1
                8000,    //Rarity 2
                1600,     //Rarity 3
            },
            {
                10000,  //Rarity 0
                10000,   //Rarity 1
                10000,    //Rarity 2
                3200,     //Rarity 3
            },
            {
                10000,  //Rarity 0
                10000,   //Rarity 1
                10000,    //Rarity 2
                6400,     //Rarity 3
            },
            {
                10000,  //Rarity 0
                10000,   //Rarity 1
                10000,    //Rarity 2
                10000,     //Rarity 3
            },
        };

        #endregion
    }
}
