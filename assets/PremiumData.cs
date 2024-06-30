namespace Constants
{
    public static class PremiumData{


        public static readonly int[] maximumAds = { 1, 1, 1, 1};
        public static readonly int[] timeRefreshAds = { 4, 8, 12, 20}; //in hours
        public static readonly double[] tokenAdsPrices = {10, 20, 40, -1};
        public static readonly double[] adsData = {4, 1, 1, 20};
        public static readonly int[] premiumBoost = {4, 3, 3, 2};
        public const int minAdsWaitTime = 150;

        public static readonly int[] falsePremiumCost = {20, 100};
        public static readonly int[] falsePremiumTime = {60, 360};
        public static readonly int[,] ticketShopData = {
            {5, 40, 20},
            {4, 20, 100},
            {3, 4, 200},
            {2, 1, 400},
            {3, 4, 2000},
        };

        public const int maxFreeFilterNumber = 5;
        public const int maxFilterNumber = 20;

        public const double collectionMuseumFreeDivider = 3;

        public const string premiumPurchaseId = "premium_mode";

        public static readonly string[] tokenPurchaseIds = 
        {
            "basic_token_pack", 
            "medium_token_pack", 
            "big_token_pack", 
            "giga_token_pack"
        };

    }
}