using System;
using Utils;
using Constants;
using Enums;
using Godot;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Classes
{
    public class KnightDescriptor
    {
        public int BoxIndex;
        public int BoxPosition;
        public double MoneyValue;

        public KnightDescriptor(int index, int position, double value)
        {
            BoxIndex = index;
            BoxPosition = position;
            MoneyValue = value;
        }
    }
    public class CompareKnightByLuckDesc : IComparer<Knight>{

        public int Compare(Knight knight1, Knight knight2)
        {
            if(knight1 == knight2)
                return 0;
            else if(knight1 == null)
                return 1;
            else if(knight2 == null)
                return -1;
            else if(knight1.LuckValue > knight2.LuckValue)
                return -1;
            else if(knight2.LuckValue > knight1.LuckValue)
                return 1;
            else   
                return 0;
        }
    }

    public class CompareKnightByLuckAsc : IComparer<Knight>{

        public int Compare(Knight knight1, Knight knight2)
        {
            if(knight1 == knight2)
                return 0;
            else if(knight1 == null)
                return -1;
            else if(knight2 == null)
                return 1;
            else if(knight1.LuckValue > knight2.LuckValue)
                return 1;
            else if(knight2.LuckValue > knight1.LuckValue)
                return -1;
            else   
                return 0;
        }
    }

    public class CompareKnightByPriceDesc : IComparer<Knight>{

        public int Compare(Knight knight1, Knight knight2)
        {
            if(knight1 == knight2)
                return 0;
            else if(knight1 == null)
                return 1;
            else if(knight2 == null)
                return -1;
            else if(knight1.MoneyValue > knight2.MoneyValue)
                return -1;
            else if(knight2.MoneyValue > knight1.MoneyValue)
                return 1;
            else   
                return 0;
        }
    }

    public class CompareKnightByPriceAsc : IComparer<Knight>{

        public int Compare(Knight knight1, Knight knight2)
        {
            if(knight1 == knight2)
                return 0;
            else if(knight1 == null)
                return -1;
            else if(knight2 == null)
                return 1;
            else if(knight1.MoneyValue > knight2.MoneyValue)
                return 1;
            else if(knight2.MoneyValue > knight1.MoneyValue)
                return -1;
            else   
                return 0;
        }
    }

    [Serializable]
    public class Knight
    {
        [JsonProperty]
        private KnightData data;
        [JsonProperty]
        private FilterMarkEnum currentMark;

        [JsonIgnore]
        public bool LeftHanded {
            get{
                return data.LeftHanded;
            }
        }
        [JsonIgnore]
        public CapsuleTypes CapsuleType {
            get{
                return data.CapsuleType;
            }
        }

        [JsonIgnore]
        public bool Upgraded {
            get{
                return data.Upgraded;
            }
            set{
                data.Upgraded = value;
            }
        }

        [JsonIgnore]
        public bool Authentic {
            get{
                return data.Authentic;
            }
        }

        [JsonIgnore]
        private int capsuleColorIndex = 0;

        [JsonIgnore]
        public int CapsuleColorIndex {
            get{
                return capsuleColorIndex;
            }
            set{
                capsuleColorIndex = value;
            }
        }

        [JsonIgnore]
        public bool HasCape {
            get{
                return data.HasCape;
            }
        }

        [JsonIgnore]
        public bool HasPet {
            get{
                return data.HasPet;
            }
        }

        [JsonIgnore]
        public bool IsPetShiny {
            get{
                return data.IsPetShiny;
            }
        }
        [JsonIgnore]
        public bool HasMainEnchant {
            get{
                return data.HasMainEnchant;
            }
        }
        [JsonIgnore]
        public bool HasOffEnchant {
            get{
                return data.HasOffEnchant;
            }
        }

        [JsonIgnore]
        public bool IsFullInverted {
            get{
                return data.IsFullInverted;
            }
        }

        [JsonIgnore]
        public int EnchantNumber {
            get{
                int count = 0;
                if(data.HasOffEnchant)
                    count++;
                if(data.HasMainEnchant)
                    count++;
                return count;
            }
        }

        [JsonIgnore]
        public bool HasAnyShine {
            get{
                if((int)CapsuleType > 0)
                    return true;
                return false;
            }
        }

        [JsonIgnore]
        public bool SameTierName {
            get{
                return data.SameTierNames;
            }
        }

        [JsonIgnore]
        public bool SameTierPhysical {
            get{
                return data.SameTierPhysical;
            }
        }

        [JsonIgnore]
        public bool SameTierEnchants {
            get{
                return data.SameTierEnchants;
            }
        }

        [JsonIgnore]
        public bool SameTierEquipments {
            get{
                return data.SameTierEquipments;
            }
        }

        [JsonIgnore]
        public bool SameSetArmor {
            get{
                return data.HasSetArmor;
            }
        }

        [JsonIgnore]
        public int EquipmentSetId {
            get{
                return data.EquipmentSetId;
            }
        }

        [JsonIgnore]
        public int EquipmentSetRarity {
            get{
                return data.EquipmentSetRarity;
            }
        }

        [JsonIgnore]
        public double LuckValue{
            get{
                return data.LuckValue;
            }
        }

        [JsonIgnore]
        public List<int> SetIndexes{
            get{
                return data.SetIndexes;
            }
        }

        [JsonIgnore]
        public string LuckValueText{
            get{
                return BigNumbers.GetText(data.LuckValue);
            }
        }


        [JsonIgnore]
        public string ProbaValueText{
            get{
                return BigNumbers.GetText(ProbaValue);
            }
        }

        [JsonIgnore]
        public double ProbaValue{
            get{
                if(!data.Authentic)
                    return 0;
                double baseValue = 1;
                int curRarity;
                KnightPartEnum curPart;
                Dictionary<RarityEnum, int> rarityCount = new Dictionary<RarityEnum, int>();
                int partNumber = 0;
                for(int i = 0 ; i <= (int)KnightPartEnum.TITLE ; i++)
                {
                    curPart = (KnightPartEnum)i;
                    curRarity = 0;
                    switch(curPart)
                    {
                        case KnightPartEnum.ARMOR:
                        case KnightPartEnum.HELMET:
                        case KnightPartEnum.MAIN_HAND:
                        case KnightPartEnum.OFF_HAND:
                            curRarity = data.GetPartGlobalRarityIndex(curPart);
                            baseValue*=Probability.rarityProbabilities[curRarity];
                            if(IsRarePart(curPart))
                            {
                                baseValue*=Probability.equipmentProbabilities[1];
                            }
                            else if(IsSpecialPart(curPart))
                            {
                                baseValue*=Probability.equipmentProbabilities[2];
                            }
                            else
                            {
                                baseValue*=Probability.equipmentProbabilities[0];
                            }
                            if(rarityCount.ContainsKey((RarityEnum)curRarity))
                                rarityCount[(RarityEnum)curRarity]++;
                            else
                                rarityCount.Add((RarityEnum)curRarity, 1);
                            partNumber++;
                            break;
                        case KnightPartEnum.CAPE:
                            if(data.HasCape)
                            {
                                baseValue*=Probability.probabilityCape;
                                curRarity = data.GetPartRarityIndex(curPart);
                                baseValue*=Probability.rarityProbabilities[curRarity];

                                if(rarityCount.ContainsKey((RarityEnum)curRarity))
                                    rarityCount[(RarityEnum)curRarity]++;
                                else
                                    rarityCount.Add((RarityEnum)curRarity, 1);

                                curRarity = GetCapeColorRarityIndex();
                                baseValue*=Probability.rarityProbabilities[curRarity];

                                
                                partNumber++;
                            }
                            else
                            {
                                baseValue*=Probability.probabilityNoCape;
                            }
                            break;
                        case KnightPartEnum.MAIN_ENCHANT:
                            if(HasMainEnchant)
                            {
                                baseValue*=Probability.probabilityEnchant;
                                curRarity = data.GetPartRarityIndex(curPart);
                                baseValue*=Probability.rarityProbabilities[curRarity];
                                if(IsRarePart(curPart))
                                {
                                    baseValue*=Probability.enchantProbabilities[1];
                                }
                                else
                                {
                                    baseValue*=Probability.enchantProbabilities[0];
                                }
                                partNumber++;
                                if(rarityCount.ContainsKey((RarityEnum)curRarity))
                                    rarityCount[(RarityEnum)curRarity]++;
                                else
                                    rarityCount.Add((RarityEnum)curRarity, 1);
                            }
                            else
                            {
                                baseValue*=Probability.probabilityNoEnchant;
                            }
                            break;
                        case KnightPartEnum.OFF_ENCHANT:
                            if(HasOffEnchant)
                            {
                                baseValue*=Probability.probabilityEnchant;
                                curRarity = data.GetPartRarityIndex(curPart);
                                baseValue*=Probability.rarityProbabilities[curRarity];
                                if(IsRarePart(curPart))
                                {
                                    baseValue*=Probability.enchantProbabilities[1];
                                }
                                else
                                {
                                    baseValue*=Probability.enchantProbabilities[0];
                                }
                                partNumber++;
                                if(rarityCount.ContainsKey((RarityEnum)curRarity))
                                    rarityCount[(RarityEnum)curRarity]++;
                                else
                                    rarityCount.Add((RarityEnum)curRarity, 1);
                            }
                            else
                            {
                                baseValue*=Probability.probabilityNoEnchant;
                            }
                            break;
                        default:
                            curRarity = data.GetPartRarityIndex(curPart);
                            baseValue*=Probability.rarityProbabilities[curRarity];
                            partNumber++;
                            if(rarityCount.ContainsKey((RarityEnum)curRarity))
                                rarityCount[(RarityEnum)curRarity]++;
                            else
                                rarityCount.Add((RarityEnum)curRarity, 1);
                            break;
                    }
                }
                
                if(HasPet)
                {
                    baseValue*=Probability.probabilityFamiliar;
                    curRarity = data.GetPartRarityIndex(KnightPartEnum.PET);
                    baseValue*=Probability.rarityProbabilities[curRarity];
                    if(IsPetShiny)
                        baseValue*=Probability.probabilityShiny;
                    else
                        baseValue*=Probability.probabilityNoShiny;
                    partNumber++;
                    if(rarityCount.ContainsKey((RarityEnum)curRarity))
                        rarityCount[(RarityEnum)curRarity]++;
                    else
                        rarityCount.Add((RarityEnum)curRarity, 1);
                }
                else
                {
                    baseValue*=Probability.probabilityNoFamiliar;
                }

                if(LeftHanded)
                    baseValue*=Probability.probabilityLeftHanded;
                else
                    baseValue*=Probability.probabilityRightHanded;
                
                baseValue*= Probability.shineProbabilities[(int)data.CapsuleType];

                baseValue*= data.GetInvertedProbas();

                double factorial = 1;
                if(rarityCount.Count > 1)
                {
                    factorial = BigNumbers.Factorial(partNumber);
                    foreach(RarityEnum key in rarityCount.Keys)
                    {
                        factorial /= BigNumbers.Factorial(rarityCount[key]);
                    }
                }

                return baseValue/(Probability.firstProbability*factorial);

            }
        }

        [JsonIgnore]
        public string MoneyValueText{
            get{
                return BigNumbers.GetText(MoneyValue);
            }
        }

        [JsonIgnore]
        public double MoneyValue{
            get{
                double upgradeFactor = 1;
                if(Upgraded)
                    upgradeFactor = GameData.upgradeKnightFactor;
                return LuckValue/GameData.knightSellFactor*GameData.knightCapsuleSellFactor[(int)CapsuleType]*upgradeFactor;
            }
        }

        [JsonIgnore]
        public double MuseumValue{
            get{

                return MoneyValue/GameData.knightMuseumFactor;
            }
        }

        [JsonIgnore]
        public double DailyTokenValue{
            get{
                int rankIndex = data.GetPartRarityIndex(KnightPartEnum.PEDESTAL);
               
                if(rankIndex <= 0)
                    return 0;
                double baseValue = GameData.rankTokenValues[rankIndex];
                
                if(Authentic)
                    baseValue*= GameData.authenticTokenMultiplier;
                if(Upgraded)
                    baseValue*= GameData.ritualTokenMultiplier;
                baseValue *= GameData.shinyTokenValues[(int)CapsuleType];
                return baseValue;
            }
        }

        [JsonIgnore]
        private bool selected = false;
        [JsonIgnore]
        public bool Selected{
            get{
                return selected;
            }
            set{
                selected = value;
            }
        }

        [JsonIgnore]
        private bool sellMarked = false;
        [JsonIgnore]
        public bool SellMarked{
            get{
                return sellMarked;
            }
            set{
                sellMarked = value;
            }
        }

        private bool filtered = false;
        public bool Filtered{
            get{
                return filtered;
            }
            set{
                filtered = value;
            }
        }

        [JsonIgnore]
        public FilterMarkEnum Mark{
            get{
                return currentMark;
            }
            set{
                currentMark = value;
            }
        }
        [JsonIgnore]
        public int UrgentCounter = 0;
        [JsonIgnore]
        public int CollectionCounter = 0;

        public Godot.Collections.Dictionary<string, object> SaveData
        {
            get{
                Godot.Collections.Dictionary<string, object> knightData = data.SaveData;
                knightData.Add("filter", (int)currentMark);
                return knightData;
            }
        }

        public Knight(Godot.Collections.Dictionary<string, object> saveData)
        {
            currentMark = DictionaryHelper.GetKnightMarkEntry(saveData, "filter");
            data = new KnightData(saveData);
        }

        public Knight(int shinyLuckValue, int specialBoost, int rarityBoost = 1, bool isFamiliarInstant = false, int familiarBoost = 1, bool isAllReverse = false)
        {
            data = new KnightData(shinyLuckValue, specialBoost, rarityBoost, isFamiliarInstant, familiarBoost, isAllReverse);
            capsuleColorIndex = 0;
            switch (data.CapsuleType)
            {
                case CapsuleTypes.SILVER:
                    capsuleColorIndex = -1;
                    //UpgradeToRank(KnightRankEnum.SILVER);
                    break;
                case CapsuleTypes.GOLD:
                    capsuleColorIndex = -2;
                    //UpgradeToRank(KnightRankEnum.AMBER);
                    break;
                case CapsuleTypes.RED:
                    capsuleColorIndex = -3;
                    //UpgradeToRank(KnightRankEnum.RUBY);
                    break;
                case CapsuleTypes.BLACK:
                    capsuleColorIndex = -4;
                    //UpgradeToRank(KnightRankEnum.TANZANITE);
                    break;
                default:
                    int colorProba = Randomizer.Range(Probability.maxProba);
                    capsuleColorIndex = Probability.capsuleColorProbabilities.Length - 1;
                    while(colorProba > Probability.capsuleColorProbabilities[capsuleColorIndex])
                    {
                        capsuleColorIndex --;
                    }
                    break;
            }
            currentMark = FilterMarkEnum.NONE;
        }

        public Knight()
        {

        }

        public Knight(KnightData kData)
        {
            currentMark = FilterMarkEnum.NONE;
            capsuleColorIndex = 0;
            data = new KnightData(kData);
        }
        
        public Knight(bool generateData)
        {
            if(generateData)
            {
                data = new KnightData(true);
                capsuleColorIndex = 0;
                switch (data.CapsuleType)
                {
                    case CapsuleTypes.SILVER:
                        capsuleColorIndex = -1;
                        //UpgradeToRank(KnightRankEnum.SILVER);
                        break;
                    case CapsuleTypes.GOLD:
                        capsuleColorIndex = -2;
                        //UpgradeToRank(KnightRankEnum.AMBER);
                        break;
                    case CapsuleTypes.RED:
                        capsuleColorIndex = -3;
                        //UpgradeToRank(KnightRankEnum.RUBY);
                        break;
                    case CapsuleTypes.BLACK:
                        capsuleColorIndex = -4;
                        //UpgradeToRank(KnightRankEnum.TANZANITE);
                        break;
                    default:
                        int colorProba = Randomizer.Range(Probability.maxProba);
                        capsuleColorIndex = Probability.capsuleColorProbabilities.Length - 1;
                        while(colorProba > Probability.capsuleColorProbabilities[capsuleColorIndex])
                        {
                            capsuleColorIndex --;
                        }
                        break;
                }
                currentMark = FilterMarkEnum.NONE;
            }
            
        }

        public Knight Clone()
        {
            return new Knight(data);
        }

        public ushort GetPartState(KnightPartEnum part)
        {
            return data.GetPartState(part);
        }

        public bool PossessCombo(PartComboType combo, RarityEnum minRarity)
        {
            return data.HasComboOrBetter(combo, minRarity);
        }

        public int GetMaxInvertedRarity()
        {
            int maxRarity = -1;
            int currentRarity = -1;
            for(int i = 0 ; i < (int)KnightPartEnum.NAME ; i++)
            {
                if(data.IsInvertedPart((KnightPartEnum)i))
                {
                    currentRarity = data.GetPartGlobalRarityIndex((KnightPartEnum)i);
                    if(currentRarity > maxRarity)
                        maxRarity = currentRarity;
                }
            }
            if(data.IsInvertedPart(KnightPartEnum.PET))
            {
                currentRarity = data.GetPartGlobalRarityIndex(KnightPartEnum.PET);
                if(currentRarity > maxRarity)
                    maxRarity = currentRarity;
            }
            return maxRarity;
        }

        public bool IsInvertedPart(KnightPartEnum part)
        {
            return data.IsInvertedPart(part);
        }

        public int GetInvertedCount(){
            return data.GetInvertedCount();
        }

        public bool ClearUrgentObjective(QuestObjective objective)
        {
            switch (objective.Type)
            {
                case ObjectiveType.KNIGHT_RANK:
                    if(GetPartRarityIndex(KnightPartEnum.PEDESTAL) >= objective.Index)
                        return true;
                    break;
                case ObjectiveType.KNIGHT_SET:
                    if(SetIndexes.Contains(objective.Index))
                        return true;
                    break;
                case ObjectiveType.SPECIFIC_AUTHENTIC_PART:
                    if(!Authentic)
                        return false;
                    if(PossessPart(objective.PartType, new PartDescription(objective.Index, objective.Rarity, objective.Option)))
                        return true;
                    break;
                case ObjectiveType.SPECIFIC_PART:
                    if(PossessPart(objective.PartType, new PartDescription(objective.Index, objective.Rarity, objective.Option)))
                        return true;
                    break;
                case ObjectiveType.SPECIFIC_RARITY:
                    if(data.HasSameRarityOrBetter(objective.Rarity))
                        return true;
                    break;
                case ObjectiveType.AUTHENTIC_PART_COMBO:
                    if(Authentic && data.HasComboOrBetter(objective.ComboType, objective.Rarity))
                        return true;
                    break;
                case ObjectiveType.PART_COMBO:
                    if(data.HasComboOrBetter(objective.ComboType, objective.Rarity))
                        return true;
                    break;
                case ObjectiveType.SPECIFIC_AUTHENTIC_SHINY:
                    if(Authentic && (int)CapsuleType >= (int)objective.Rarity)
                        return true;
                    break;
                case ObjectiveType.SPECIFIC_SHINY:
                    if((int)CapsuleType >= (int)objective.Rarity)
                        return true;
                    break;
                case ObjectiveType.ARMOR_SET:
                    if(objective.Index == EquipmentSetId && (int)objective.Rarity == EquipmentSetRarity)
                        return true;
                    break;
                default:
                    break;
            }
            return false;
        }

        public bool ClearObjective(QuestObjective objective)
        {
            switch (objective.Type)
            {
                case ObjectiveType.KNIGHT_RANK:
                    if(GetPartRarityIndex(KnightPartEnum.PEDESTAL) == objective.Index)
                        return true;
                    break;
                case ObjectiveType.KNIGHT_SET:
                    if(SetIndexes.Contains(objective.Index))
                        return true;
                    break;
                case ObjectiveType.SPECIFIC_AUTHENTIC_PART:
                    if(!Authentic)
                        return false;
                    if(PossessPart(objective.PartType, new PartDescription(objective.Index, objective.Rarity, objective.Option)))
                        return true;
                    break;
                case ObjectiveType.SPECIFIC_PART:
                    if(PossessPart(objective.PartType, new PartDescription(objective.Index, objective.Rarity, objective.Option)))
                        return true;
                    break;
                case ObjectiveType.SPECIFIC_RARITY:
                    if(data.HasSameRarity(objective.Rarity))
                        return true;
                    break;
                case ObjectiveType.AUTHENTIC_PART_COMBO:
                    if(Authentic && data.HasSpecificCombo(objective.ComboType, objective.Rarity))
                        return true;
                    break;
                case ObjectiveType.PART_COMBO:
                    if(data.HasSpecificCombo(objective.ComboType, objective.Rarity))
                        return true;
                    break;
                case ObjectiveType.SPECIFIC_AUTHENTIC_SHINY:
                    if(Authentic && (int)CapsuleType == (int)objective.Rarity)
                        return true;
                    break;
                case ObjectiveType.SPECIFIC_SHINY:
                    if((int)CapsuleType == (int)objective.Rarity)
                        return true;
                    break;
                case ObjectiveType.ARMOR_SET:
                    if(objective.Index == EquipmentSetId && (int)objective.Rarity == EquipmentSetRarity)
                        return true;
                    break;
                default:
                    break;
            }
            return false;
        }

        public bool PossessPart(KnightPartEnum partType, PartDescription part)
        {
            return data.PossessPart(partType, part);
        }
        

        /*private void UpgradeToRank(KnightRankEnum rank)
        {
            while(GetPartRarityIndex(KnightPartEnum.PEDESTAL) < (int)rank)
            {
                data.RankUpgrade(1);
            }
        }*/

        public void LegacyUpdate()
        {
            data.LegacyUpdate();
        }

        public void UpdateData()
        {
            data.UpdateData();
        }

        public bool CanCompleteCountedQuest(QuestFilterType questFilter)
        {
            switch (questFilter)
            {
                case QuestFilterType.URGENT:
                    if(UrgentCounter > 0)
                        return true;
                    return false;
                case QuestFilterType.COLLECTION:
                    if(CollectionCounter > 0)
                        return true;
                    return false;
                case QuestFilterType.BOTH:
                    if(UrgentCounter > 0 || CollectionCounter > 0)
                        return true;
                    return false;
                default:
                    return false;
            }
        }

        public void UpgradeTitle(KnightPartEnum part)
        {
            data.UpgradeTitle(part);
            data.UpdateData();
        }

        public void RerollPart(KnightPartEnum part, int rerollBonus)
        {
            data.RerollPart(part, rerollBonus);
            data.UpdateData();
        }

        public void SetPart(KnightPartEnum part, int index, RarityEnum rarity, int option = 0, ushort state = 255)
        {
            data.SetPart(part, index, rarity, option, state);
            data.UpdateData();
        }

        public void RedrawPart(KnightPartEnum part, int rarityBonus, int probaBoost)
        {
            data.RedrawPart(part, rarityBonus, probaBoost);
            data.UpdateData();
        }

        public RarityEnum GetMaxRarityPart()
        {
            return data.GetMaxGlobalRarityPart();
        }
        
        public RarityEnum GetMaxSpecialRarity()
        {
            return data.GetMaxSpecialRarityPart();
        }

        public RarityEnum GetMaxRareEquipmentRarity()
        {
            return data.GetMaxRareEquipmentRarity();
        }

        public RarityEnum GetMaxRareEnchantmentRarity()
        {
            return data.GetMaxRareEnchantmentRarity();
        }

        public KnightRankEnum GetRank()
        {
            return (KnightRankEnum)data.GetPartRarityIndex(KnightPartEnum.PEDESTAL);
        }
        
        public RarityEnum GetPartRarity(KnightPartEnum partType)
        {
            return data.GetPartRarity(partType);
        }

        public int GetCapeColorRarityIndex()
        {
            int capeIndex = data.GetPartIndex(KnightPartEnum.CAPE);
            if(capeIndex >= 0)
                return KnightData.GetCapeColorRarityIndex(capeIndex);
            return -1;
        }

        public int GetPartRarityIndex(KnightPartEnum partType)
        {
            return data.GetPartRarityIndex(partType);
        }

        public PartDescription GetPartDescription(KnightPartEnum partType)
        {
            RarityEnum partRarity = GetPartRarity(partType);
            
            if(partRarity != RarityEnum.NONE)
            {
                RarityEnum truePartRarity = partRarity;
                int option = 0;
                int partState = data.GetPartState(partType);
                switch (partType)
                {
                    case KnightPartEnum.PET:
                        if(IsPetShiny)
                            option = 1;
                        break;
                    case KnightPartEnum.SHINYNESS:
                    case KnightPartEnum.COLOR:
                    case KnightPartEnum.PEDESTAL:
                    case KnightPartEnum.SPECIAL:
                    case KnightPartEnum.BOTH_ENCHANT:
                        break;
                    case KnightPartEnum.NAME:
                    case KnightPartEnum.TRAIT:
                    case KnightPartEnum.TITLE:
                        truePartRarity = data.GetRawPartGlobalRarity(partType);
                        break;
                    default:
                        if(IsRarePart(partType))
                            option = 1;
                        break;
                }
                int partIndex = GetPartIndex(partType);
                if(truePartRarity != partRarity)
                    return new PartDescription(partIndex, partRarity, truePartRarity, option, partState);
                else
                    return new PartDescription(partIndex, partRarity, option, false, partState);
            }
            return null;
        }

        public int GetGlobalPartRarityIndex(KnightPartEnum partType)
        {
            return data.GetPartGlobalRarityIndex(partType);
        }

        public int GetRawGlobalPartRarityIndex(KnightPartEnum partType)
        {
            return data.GetRawPartGlobalRarityIndex(partType);
        }

        public int GetPartIndex(KnightPartEnum partType)
        {
            return data.GetPartIndex(partType);
        }

        public void UpgradePartRarity(KnightPartEnum partType, int increase, PartDescription desc, ushort commonState)
        {
            data.UpgradePartRarity(partType, increase, desc, commonState);
        }

        public bool IsSpecialPart(KnightPartEnum part)
        {
            return data.IsSpecialPart(part);
        }

        public static bool IsRarePart(KnightPartEnum part, RarityEnum rarity, int index)
        {
            if((int)rarity >= (int)RarityEnum.SPECIAL_COMMON)
                return false;
            switch (part)
            {
                case KnightPartEnum.ARMOR:
                    if(GameData.rareArmorIndexes[(int)rarity].Contains((ushort)index))
                        return true;
                    break;
                case KnightPartEnum.HELMET:
                    if(GameData.rareHelmetIndexes[(int)rarity].Contains((ushort)index))
                        return true;
                    break;
                case KnightPartEnum.MAIN_HAND:
                    if(GameData.rareMainWeaponIndexes[(int)rarity].Contains((ushort)index))
                        return true;
                    break;
                case KnightPartEnum.OFF_HAND:
                    if(GameData.rareOffWeaponIndexes[(int)rarity].Contains((ushort)index))
                        return true;
                    break;
                case KnightPartEnum.OFF_ENCHANT:
                case KnightPartEnum.MAIN_ENCHANT:
                case KnightPartEnum.BOTH_ENCHANT:
                    if(GameData.rareEnchantIndexes[(int)rarity].Contains((ushort)index))
                        return true;
                    break;
                default:
                    break;
            }
            return false;
        }

        public bool IsRarePart(KnightPartEnum part)
        {
            return data.IsRarePart(part);
        }

        public void Upgrade(CapsuleBoosts upgradeType)
        {
            
            int amount = 0;
            switch (upgradeType)
            {
                case CapsuleBoosts.RARITY_0:
                    amount = 1;
                    break;
                case CapsuleBoosts.RARITY_1:
                    amount = 2;
                    break;
                case CapsuleBoosts.RARITY_2:
                    amount = 3;
                    break;
                case CapsuleBoosts.RARITY_3:
                    amount = 4;
                    break;
                default:
                    break;
            }
            if(amount >= 0)
            {
                data.RandomRarityUpgrade(false, amount, true);
            }
        }

        public string GetNameString(KnightPartEnum namePart)
        {
            string endString = GetRawGlobalPartRarityIndex(namePart) + "_" + GetPartIndex(namePart);
            string name = "KNIGHT_";
            if(GetPartRarityIndex(namePart) >= (int)RarityEnum.SPECIAL_COMMON)
                name += "SPECIAL_";
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
                    if(HasCape)
                    {
                        string secondPart = name + "CAPE_COLOR_" + GetPartIndex(namePart);
                        return secondPart;
                    }    
                    else
                        return "GENERAL_NO_CAPE";
                case KnightPartEnum.MAIN_HAND:
                    return name + "MAIN_" + endString;
                case KnightPartEnum.OFF_HAND:
                    return name + "OFF_" + endString;
                case KnightPartEnum.MAIN_ENCHANT:
                    if(HasMainEnchant)
                        return name + "ENCHANT_" + endString;
                    else
                        return "GENERAL_NO_ENCHANT";
                case KnightPartEnum.OFF_ENCHANT:
                    if(HasOffEnchant)
                        return name + "ENCHANT_" + endString;
                    else
                        return "GENERAL_NO_ENCHANT";
                case KnightPartEnum.NAME:
                    return name + "NAMES_" + endString;
                case KnightPartEnum.TITLE:
                    return name + "TITLES_" + endString;
                case KnightPartEnum.TRAIT:
                    return name + endString;
                default:
                    return "";
            }
        }

        public Godot.Color GetPartColor(KnightSpriteEnum spritePart)
        {
            KnightPartEnum trueKnightPart = KnightPartEnum.ARMOR;
            int partRarity = 0, partIndex = 0;
            switch(spritePart)
            {
                case KnightSpriteEnum.CAPE_COLOR_TOP:
                case KnightSpriteEnum.CAPE_COLOR_BOTTOM:
                    trueKnightPart = KnightPartEnum.CAPE;
                    break;
                case KnightSpriteEnum.RIGHT_HAND_ENCHANT:
                    if(!LeftHanded)
                        trueKnightPart = KnightPartEnum.MAIN_ENCHANT;
                    else
                        trueKnightPart = KnightPartEnum.OFF_ENCHANT;
                    break;
                case KnightSpriteEnum.LEFT_HAND_ENCHANT:
                    if(LeftHanded)
                        trueKnightPart = KnightPartEnum.MAIN_ENCHANT;
                    else
                        trueKnightPart = KnightPartEnum.OFF_ENCHANT;
                    break;
            }
            if(trueKnightPart == KnightPartEnum.ARMOR)  
                return Colors.White;
            
            partIndex = data.GetPartIndex(trueKnightPart);
            if(partIndex < 0)
                return Colors.White;
            partRarity = data.GetPartRarityIndex(trueKnightPart);
            if(partRarity < 0)
                return Colors.White;
            switch(trueKnightPart)
            {
                case KnightPartEnum.CAPE:
                    Godot.Color col = ColorData.capeColors[partIndex];
                    if(data.IsInvertedPart(KnightPartEnum.CAPE))
                        col = new Godot.Color(1 - col.r, 1 - col.g, 1 - col.b, col.a);
                    return col;
                case KnightPartEnum.MAIN_ENCHANT:
                case KnightPartEnum.OFF_ENCHANT:
                    return ColorData.enchantColors[partRarity, partIndex];
            }
            return Colors.White;
        }

        private string GenerateTexturePath(KnightPartEnum part)
        {
            int rarityIndex = data.GetPartRarityIndex(part);
            string path = ResourcePaths.texturePartPaths[(int)part];
            if(rarityIndex >= (int)RarityEnum.SPECIAL_COMMON)
                path+= "Special/";
            path += data.GetPartGlobalRarityIndex(part) + "_" + data.GetPartIndex(part) + ".png";
            return path;
        }

        private string GenerateEnchantMaterialPath(KnightPartEnum part)
        {
            string path = "";
            if(part == KnightPartEnum.OFF_ENCHANT || part == KnightPartEnum.MAIN_ENCHANT)
            {
                int rarityIndex = data.GetPartRarityIndex(part);
                if(data.IsInvertedPart(part))
                    path = ResourcePaths.invertedEnchantMaterialPath;
                else
                    path = ResourcePaths.enchantMaterialPath;
                path += data.GetPartGlobalRarityIndex(part) + "_" + data.GetPartIndex(part) + ".tres";
            }
            return path;
        }

        private string GenerateFamiliarTexturePath()
        {
            int rarityIndex = data.GetPartRarityIndex(KnightPartEnum.PET);
            string path = "res://Sprites/Knight/Familiar/";
            if(IsPetShiny)
                path+= "Shiny/";
            path += rarityIndex + "_" + data.GetPartIndex(KnightPartEnum.PET) + ".png";
            return path;
        }

        private string GenerateEnchantTexturePath(KnightPartEnum part)
        {
            string path = ResourcePaths.texturePartPaths[(int)part];
            switch (part)
            {
                case KnightPartEnum.OFF_HAND:
                case KnightPartEnum.MAIN_HAND:
                    if(data.GetPartRarityIndex(part) >= (int)RarityEnum.SPECIAL_COMMON)
                        path += "Special/Enchants/";
                    else
                        path += "Enchants/";
                    path += data.GetPartGlobalRarityIndex(part) + "_" + data.GetPartIndex(part) + ".png";
                    return path;
                default:
                    return "";
            }
        }

        public string GetMaterialPath(KnightSpriteEnum spritePart)
        {
            string path = "";
            switch (spritePart)
            {
                case KnightSpriteEnum.BODY:
                    if(data.IsInvertedPart(KnightPartEnum.BODY))
                        return ResourcePaths.invertedMaterialPath;
                    return "";
                case KnightSpriteEnum.FACE:
                    if(data.IsInvertedPart(KnightPartEnum.FACE))
                        return ResourcePaths.invertedMaterialPath;
                    return "";
                case KnightSpriteEnum.ARMOR:
                    if(data.IsInvertedPart(KnightPartEnum.ARMOR))
                        return ResourcePaths.invertedMaterialPath;
                    return "";
                case KnightSpriteEnum.CAPE:
                    if(data.IsInvertedPart(KnightPartEnum.CAPE))
                        return ResourcePaths.invertedMaterialPath;
                    return "";
                case KnightSpriteEnum.CAPE_COLOR_TOP:
                case KnightSpriteEnum.CAPE_COLOR_BOTTOM:
                    return "";
                case KnightSpriteEnum.HELMET:
                    if(data.IsInvertedPart(KnightPartEnum.HELMET))
                        return ResourcePaths.invertedMaterialPath;
                    return "";
                case KnightSpriteEnum.PET:
                    if(data.IsInvertedPart(KnightPartEnum.PET))
                        return ResourcePaths.invertedMaterialPath;
                    return "";
                case KnightSpriteEnum.RIGHT_HAND:
                    if (LeftHanded)
                    {
                        if(data.IsInvertedPart(KnightPartEnum.OFF_HAND))
                            return ResourcePaths.invertedMaterialPath; 
                    }
                    else
                    {
                        if(data.IsInvertedPart(KnightPartEnum.MAIN_HAND))
                            return ResourcePaths.invertedMaterialPath; 
                    }
                    return "";
                case KnightSpriteEnum.LEFT_HAND:
                    if (!LeftHanded)
                    {
                        if(data.IsInvertedPart(KnightPartEnum.OFF_HAND))
                            return ResourcePaths.invertedMaterialPath; 
                    }
                    else
                    {
                        if(data.IsInvertedPart(KnightPartEnum.MAIN_HAND))
                            return ResourcePaths.invertedMaterialPath; 
                    }
                    return "";
                case KnightSpriteEnum.RIGHT_HAND_ENCHANT:
                    if (LeftHanded)
                    {
                        if (!HasOffEnchant)
                            return "";
                        return GenerateEnchantMaterialPath(KnightPartEnum.OFF_ENCHANT);
                    }
                    else
                    {
                        if (!HasMainEnchant)
                            return "";
                        return GenerateEnchantMaterialPath(KnightPartEnum.MAIN_ENCHANT);
                    }
                case KnightSpriteEnum.LEFT_HAND_ENCHANT:
                    if (!LeftHanded)
                    {
                        if (!HasOffEnchant)
                            return "";
                        return GenerateEnchantMaterialPath(KnightPartEnum.OFF_ENCHANT);    
                    }
                    else
                    {
                        if (!HasMainEnchant)
                            return "";
                        return GenerateEnchantMaterialPath(KnightPartEnum.MAIN_ENCHANT);
                    }
                default:
                    break;
            }

            return path;
        }

        public string GetTexturePath(KnightSpriteEnum spritePart)
        {
            string path = "";
            switch (spritePart)
            {
                case KnightSpriteEnum.BASE:
                    path = ResourcePaths.knightPedestalsPath;
                    path += data.GetPartRarityIndex(KnightPartEnum.PEDESTAL) + "_" + data.GetPartIndex(KnightPartEnum.PEDESTAL) + ".png";
                    break;
                case KnightSpriteEnum.BODY:
                    return GenerateTexturePath(KnightPartEnum.BODY);
                case KnightSpriteEnum.FACE:
                    return GenerateTexturePath(KnightPartEnum.FACE);
                case KnightSpriteEnum.ARMOR:
                    return GenerateTexturePath(KnightPartEnum.ARMOR);
                case KnightSpriteEnum.CAPE:
                    if (!HasCape)
                        return "";
                    path = ResourcePaths.knightCapesPath + data.GetPartRarityIndex(KnightPartEnum.CAPE) + "/";
                    if(data.GetPartRarityIndex(KnightPartEnum.ARMOR) >= (int)RarityEnum.SPECIAL_COMMON)
                        path += SpriteData.specialCapeTopData[data.GetPartIndex(KnightPartEnum.ARMOR)][data.GetPartGlobalRarityIndex(KnightPartEnum.ARMOR)].ToString() + "_l.png";
                    else
                        path += SpriteData.capeTopData[data.GetPartIndex(KnightPartEnum.ARMOR)][data.GetPartGlobalRarityIndex(KnightPartEnum.ARMOR)].ToString() + "_l.png";
                    break;
                case KnightSpriteEnum.CAPE_COLOR_TOP:
                    if (!HasCape)
                        return "";
                    path = ResourcePaths.knightCapesPath + data.GetPartRarityIndex(KnightPartEnum.CAPE) + "/";
                    if(data.GetPartRarityIndex(KnightPartEnum.ARMOR) >= (int)RarityEnum.SPECIAL_COMMON)
                        path += SpriteData.specialCapeTopData[data.GetPartIndex(KnightPartEnum.ARMOR)][data.GetPartGlobalRarityIndex(KnightPartEnum.ARMOR)].ToString() + "_t.png";
                    else
                        path += SpriteData.capeTopData[data.GetPartIndex(KnightPartEnum.ARMOR)][data.GetPartGlobalRarityIndex(KnightPartEnum.ARMOR)].ToString() + "_t.png";
                    break;
                case KnightSpriteEnum.CAPE_COLOR_BOTTOM:
                    if (!HasCape)
                        return "";
                    path = ResourcePaths.knightCapesPath + data.GetPartRarityIndex(KnightPartEnum.CAPE) + "/";
                    if(data.GetPartRarityIndex(KnightPartEnum.ARMOR) >= (int)RarityEnum.SPECIAL_COMMON)
                        path += SpriteData.specialCapeBottomData[data.GetPartIndex(KnightPartEnum.ARMOR)][data.GetPartGlobalRarityIndex(KnightPartEnum.ARMOR)].ToString() + "_b.png";
                    else
                        path += SpriteData.capeBottomData[data.GetPartIndex(KnightPartEnum.ARMOR)][data.GetPartGlobalRarityIndex(KnightPartEnum.ARMOR)].ToString() + "_b.png";
                    break;
                case KnightSpriteEnum.HELMET:
                    return GenerateTexturePath(KnightPartEnum.HELMET);
                case KnightSpriteEnum.RIGHT_HAND:
                    if(LeftHanded)
                    {
                        return GenerateTexturePath(KnightPartEnum.OFF_HAND);
                    }
                    else
                    {
                        return GenerateTexturePath(KnightPartEnum.MAIN_HAND);
                    }
                case KnightSpriteEnum.RIGHT_HAND_ENCHANT:
                    if (LeftHanded)
                    {
                        if (!HasOffEnchant)
                            return "";
                        return GenerateEnchantTexturePath(KnightPartEnum.OFF_HAND);
                    }
                    else
                    {
                        if (!HasMainEnchant)
                            return "";
                        return GenerateEnchantTexturePath(KnightPartEnum.MAIN_HAND);
                    }
                case KnightSpriteEnum.LEFT_HAND:
                    if(!LeftHanded)
                    {
                        return GenerateTexturePath(KnightPartEnum.OFF_HAND);
                    }
                    else
                    {
                        return GenerateTexturePath(KnightPartEnum.MAIN_HAND);
                    }
                case KnightSpriteEnum.LEFT_HAND_ENCHANT:
                    if (!LeftHanded)
                    {
                        if (!HasOffEnchant)
                            return "";
                        return GenerateEnchantTexturePath(KnightPartEnum.OFF_HAND);    
                    }
                    else
                    {
                        if (!HasMainEnchant)
                            return "";
                        return GenerateEnchantTexturePath(KnightPartEnum.MAIN_HAND);
                    }
                case KnightSpriteEnum.PET:
                    if(HasPet)
                    {
                        return GenerateFamiliarTexturePath();
                    }
                    return "";
                default:
                    break;
            }

            return path;
        }
    }

    public class KnightData{
        [JsonProperty]
        public UInt16[,] parts;

        [JsonProperty]
        public UInt16[] titleUpgrades;

        [JsonProperty]
        public UInt16[] partStates;

        [JsonProperty]
        public UInt16[,] pet;
	
	    [JsonIgnore]
        public UInt16[] pet2;

        [JsonProperty]
        private bool leftHanded;
        [JsonProperty]
        private bool upgraded;

        [JsonProperty]
        private bool authentic = false;

        [JsonProperty]
        private UInt16 capsuleType;

        [JsonIgnore]
        private bool hasCape;
        [JsonIgnore]
        private bool hasPet;
        [JsonIgnore]
        private bool isPetShiny;
        [JsonIgnore]
        private bool hasOffEnchant;
        [JsonIgnore]
        private bool hasMainEnchant;
        [JsonIgnore]
        private bool sameTierNames;
        [JsonIgnore]
        private bool sameTierPhysical;
        [JsonIgnore]
        private bool sameTierEquipments;
        [JsonIgnore]
        private bool sameTierRareEquipments;
        [JsonIgnore]
        private bool sameTierEnchants;
        [JsonIgnore]
        private bool hasSetArmor;
        [JsonIgnore]
        private bool hasRareSetArmor;
        [JsonIgnore]
        private int equipmentSetId;
        [JsonIgnore]
        private int equipmentSetRarity;
        [JsonIgnore]
        private bool isFullInverted;
        [JsonIgnore]
        private int invertedPartCount;
        [JsonIgnore]
        private List<int> setIndexes;
        [JsonIgnore]
        private double luckValue;
        [JsonIgnore]
        public bool HasCape{
            get{
                return hasCape;
            }
        }
        [JsonIgnore]
        public bool HasPet{
            get{
                return hasPet;
            }
        }
        [JsonIgnore]
        public bool IsPetShiny{
            get{
                return isPetShiny;
            }
        }
        [JsonIgnore]
        public bool HasOffEnchant{
            get{
                return hasOffEnchant;
            }
        }
        [JsonIgnore]
        public bool HasMainEnchant{
            get{
                return hasMainEnchant;
            }
        }
        
        [JsonIgnore]
        public bool IsFullInverted{
            get{
                return isFullInverted;
            }
        }
        [JsonIgnore]
        public bool LeftHanded{
            get{
                return leftHanded;
            }
        }
        [JsonIgnore]
        public bool SameTierNames
        {
            get{
                return sameTierNames;
            }
        }
        [JsonIgnore]
        public bool SameTierPhysical
        {
            get{
                return sameTierPhysical;
            }
        }
        [JsonIgnore]
        public bool SameTierEquipments
        {
            get{
                return sameTierEquipments || sameTierRareEquipments;
            }
        }
        [JsonIgnore]
        public bool SameTierEnchants
        {
            get{
                return sameTierEnchants;
            }
        }
        [JsonIgnore]
        public bool HasSetArmor
        {
            get{
                return hasSetArmor || hasRareSetArmor;
            }
        }
        [JsonIgnore]
        public int EquipmentSetId{
            get{
                return equipmentSetId;
            }
        }
        [JsonIgnore]
        public int EquipmentSetRarity{
            get{
                return equipmentSetRarity;
            }
        }

        [JsonIgnore]
        public CapsuleTypes CapsuleType
        {
            get{
                return (CapsuleTypes)capsuleType;
            }
        }
        [JsonIgnore]
        public double LuckValue{
            get{
                return luckValue;
            }
        }

        [JsonIgnore]
        public List<int> SetIndexes{
            get{
                return setIndexes;
            }
        }

        [JsonIgnore]
        public bool Upgraded{
            get{
                return upgraded;
            }
            set{
                upgraded = value;
                if(upgraded && authentic)
                    authentic = false;
            }
        }

        [JsonIgnore]
        public bool Authentic{
            get{
                return authentic;
            }
        }

        [JsonIgnore]
        public bool CanBeUpgraded{
            get{
                for(int i = 0 ; i < (int)KnightPartEnum.NAME ; i++)
                    if(CanUpgradePart((KnightPartEnum)i))
                        return true;

                return false;
            }
        }

        public Godot.Collections.Dictionary<string, object> SaveData
        {
            get{
                Godot.Collections.Dictionary<string, object> knightData = new Godot.Collections.Dictionary<string, object>();
                for(int i = 0 ; i < parts.GetLength(1) ; i++)
                {
                    if(parts[0, i] != UInt16.MaxValue)
                    {
                        int data = parts[0,i] + (parts[1,i]<<16);
                        knightData.Add("part_" + i, data);
                    }
                }
                for(int i = 0 ; i < titleUpgrades.Length ; i++)
                {
                    knightData.Add("title_" + i, titleUpgrades[i]);
                }
                for(int i = 0 ; i < partStates.Length ; i++)
                {
                    knightData.Add("inverted_" + i, partStates[i]);
                }
                if(pet2 != null)
                {   
                    for(int i = 0 ; i < pet2.Length ; i++)
                    {
                        knightData.Add("pet_" + i, pet2[i]);
                    }
                }
                knightData.Add("hand", leftHanded);
                knightData.Add("upgrade", upgraded);
                knightData.Add("capsule", capsuleType);
                knightData.Add("authentic", authentic);
                return knightData;
            }
        }
        
        [JsonIgnore]
        private static Dictionary<KnightPartEnum, List<int>[]> seasonalParts;
        [JsonIgnore]
        private static Dictionary<KnightPartEnum, List<int>[]> specialSeasonalParts;
        [JsonIgnore]
        private static bool seasonalInit = false;
        [JsonIgnore]
        private static bool isPremium = false;

        public KnightData()
        {
        }

        public KnightData(Godot.Collections.Dictionary<string, object> saveData)
        {
            capsuleType = DictionaryHelper.GetUIntEntry(saveData, "capsule");
            upgraded = DictionaryHelper.GetBoolEntry(saveData, "upgrade");
            leftHanded = DictionaryHelper.GetBoolEntry(saveData, "hand");
            authentic = DictionaryHelper.GetBoolEntry(saveData, "authentic");
            if(saveData.ContainsKey("pet_0"))
            {
                pet2 = new UInt16[3];
                for(int i = 0; i < 3; i++)
                {
                    pet2[i] = DictionaryHelper.GetUIntEntry(saveData, "pet_" + i);
                }
            }
            titleUpgrades = new UInt16[3];
            for(int i = 0; i < 3; i++)
            {
                titleUpgrades[i] = DictionaryHelper.GetUIntEntry(saveData, "title_" + i);
            }
            partStates = new UInt16[(int)InvertableFigurineParts.MAX];
            for(int i = 0; i < (int)InvertableFigurineParts.MAX; i++)
            {
                partStates[i] = DictionaryHelper.GetUIntEntry(saveData, "inverted_" + i);
            }
            parts = new UInt16[2, (int)KnightPartEnum.PART_COUNT];
            for(int i = 0; i < (int)KnightPartEnum.PART_COUNT ; i++)
            {
                if(saveData.ContainsKey("part_" + i))
                {
                    int data = (int)(float)saveData["part_" + i];
                    int data2 = data&UInt16.MaxValue;
                    data = (data - data2)>>16;
                    parts[0, i] = (UInt16)data2;
                    parts[1, i] = (UInt16)data;
                }
                else
                {
                    parts[0, i] = UInt16.MaxValue;
                    parts[1, i] = UInt16.MaxValue;
                }
            }

            UpdateData();
        }

        public KnightData(KnightData copyFrom)
        {
            capsuleType = copyFrom.capsuleType;
            leftHanded = copyFrom.leftHanded;
            upgraded = copyFrom.upgraded;
            if(copyFrom.pet2 != null)
            {
                pet2 = new ushort[3];
                copyFrom.pet2.CopyTo(pet2, 0);
            }
                
            parts = (ushort[,])copyFrom.parts.Clone();
            if(copyFrom.titleUpgrades != null)
            {
                titleUpgrades = (ushort[])copyFrom.titleUpgrades.Clone();
            } 

            partStates = (ushort[])copyFrom.partStates.Clone();
                
            UpdateData();
        }

        public KnightData(bool generate = false, CapsuleTypes capType = CapsuleTypes.NORMAL)
        {
            capsuleType = (UInt16)capType;
            if(generate)
                GenerateKnightData(1, 1);
        }

        public KnightData(int shinyLuckBoost, int specialBoost, int rarityBoost = 1, bool instantFamiliar = false, int familiarBoost = 1, bool isAllReverse = false)
        {
            capsuleType = (UInt16)CapsuleTypes.NORMAL;
            GenerateKnightData(shinyLuckBoost, specialBoost, rarityBoost, instantFamiliar, familiarBoost, isAllReverse);
        }

        public void LegacyUpdate()
        {
            pet2 = new UInt16[3];
            if(pet != null)
            {
                for(int i = 0 ; i < pet.GetLength(0); i++)
                {
                    pet2[i] = pet[i, 0];
                }
            }
            else
            {
                for(int i = 0 ; i < pet2.Length; i++)
                {
                    pet2[i] = UInt16.MaxValue;
                }
            }
            UpdateData();
        }

        public void UpdateData()
        {
            if(titleUpgrades == null)
            {
                titleUpgrades = new UInt16[3];
                for(int i = 0; i < 3 ; i++)
                {
                    titleUpgrades[i] = parts[ResourcePaths.KNIGHT_DATA_RARITY, i+(int)KnightPartEnum.NAME];
                }
            }
            if(partStates == null)
            {   
                partStates = new UInt16[(int)InvertableFigurineParts.MAX];
                for(int i = 0; i < (int)InvertableFigurineParts.MAX; i++)
                {
                    partStates[i] = 0;
                }
            }
            

            
            UpdateRaritySpecifics();
            CheckGlobalStates();
            CalculateLuckValue();
            CalculatePedestalValue();
        }

        public void CalculateLuckValue()
        {
            luckValue = 1;
            int luckMultiplier = 1;
            int individualValue = 1;
            for(int i = 0 ; i < (int)KnightPartEnum.NAME ; i++)
            {
                if(parts[ResourcePaths.KNIGHT_DATA_INDEX, i] != UInt16.MaxValue)
                {
                    
                    if(parts[ResourcePaths.KNIGHT_DATA_RARITY, i] != UInt16.MaxValue)
                    {
                        luckMultiplier = 1;
                        int partRarity = parts[ResourcePaths.KNIGHT_DATA_RARITY, i];
                        if(partRarity < (int)RarityEnum.SPECIAL_COMMON)
                            individualValue = GameData.rarityValue[partRarity];
                        else
                            individualValue = GameData.specialRarityValue[partRarity - (int)RarityEnum.SPECIAL_COMMON];

                        switch((KnightPartEnum)i)
                        {
                            case KnightPartEnum.ARMOR:
                            case KnightPartEnum.HELMET:
                            case KnightPartEnum.MAIN_HAND:
                            case KnightPartEnum.OFF_HAND:
                                if(IsRarePart((KnightPartEnum)i))
                                    luckMultiplier = GameData.rareRarityValue[partRarity];
                                break;
                            case KnightPartEnum.MAIN_ENCHANT:
                            case KnightPartEnum.OFF_ENCHANT:
                                luckMultiplier = GameData.enchantMultiplier;
                                if(IsRarePart((KnightPartEnum)i))
                                    luckMultiplier *= GameData.rareEnchantMultiplier;
                                break;
                            case KnightPartEnum.CAPE:
                                luckMultiplier = GameData.capeMultiplier;
                                luckMultiplier*= GameData.rarityValue[GetCapeColorRarityIndex((int)parts[ResourcePaths.KNIGHT_DATA_INDEX, i])];
                                break;
                            default:
                                break;
                        }
                        luckValue*=luckMultiplier*individualValue;
                    }
                }
            }

            if(hasPet)
            {
                luckMultiplier = pet2[ResourcePaths.KNIGHT_DATA_RARITY];
                individualValue = GameData.rarityValue[luckMultiplier];
                luckValue*= individualValue * GameData.petMultiplier;
                if(isPetShiny)
                    luckValue*= GameData.shinyPetMultiplier;
            }

            for(int i = 0 ; i < 3 ; i++)
            {
                luckValue *= GameData.rarityValue[titleUpgrades[i]];
            }

            for(int i = 0 ; i < (int)InvertableFigurineParts.MAX ; i++)
            {
                if(partStates[i] == ResourcePaths.FIGURINE_PART_INVERTED)
                    luckValue *= GameData.invertedMultiplier;
            }
            if(invertedPartCount > 1)
            {
                luckValue *= Math.Pow(GameData.invertedBonusMultiplier, invertedPartCount-1);
            }
                
            if(sameTierPhysical)
                luckValue *= GameData.physicsTierMultiplier;
            if(sameTierNames)
                luckValue *= GameData.namesTierMultiplier;
            if(sameTierEnchants)
                luckValue *= GameData.enchantsTierMultiplier;
            if(hasSetArmor)
                luckValue *= GameData.armorSetMultiplier;
            if(hasRareSetArmor)
                luckValue*= GameData.rareArmorSetMultiplier;
            if(sameTierEquipments)
                luckValue*= GameData.equipmentsTierMultiplier;
            if(sameTierRareEquipments)
                luckValue*= GameData.rareEquipmentsTierMultiplier;
            if(leftHanded)
                luckValue*=GameData.leftHandedMultiplier;

            setIndexes = KnightSets.GetSetIndexes(this);

            luckValue *= KnightSets.GetSetBonuses(this);
        }
        public RarityEnum GetMaxGlobalRarityPart()
        {
            RarityEnum currentMaxRarity = RarityEnum.COMMON;
            for(int i = 0 ; i < (int)KnightPartEnum.PEDESTAL ; i++)
            {
                currentMaxRarity = GetMaxRarity(currentMaxRarity, GetPartGlobalRarityIndex((KnightPartEnum)i));
            }
            currentMaxRarity = GetMaxRarity(currentMaxRarity, GetPartGlobalRarityIndex(KnightPartEnum.PET));
            return currentMaxRarity;
        }

        public ushort GetPartState(KnightPartEnum part)
        {
            InvertableFigurineParts invertablePart = GetInvertedPart(part);
            if(invertablePart != InvertableFigurineParts.NONE)
            {
                return partStates[(int)invertablePart];
            }
            return 0;
        }

        private RarityEnum GetMaxRarity(RarityEnum currentMax, int newVal)
        {
            if(newVal < (int)RarityEnum.MAX)
            {
                if(newVal > (int)currentMax)
                    currentMax = (RarityEnum)newVal;
            }
            return currentMax;
        }

        private RarityEnum GetMaxRarity(RarityEnum currentMax, KnightPartEnum currentPart, bool excludeSpecial, bool isRare)
        {
            int newVal = GetPartRarityIndex(currentPart);
            if(excludeSpecial)
            {
                if(newVal < (int)RarityEnum.SPECIAL_COMMON)
                {
                    if( (isRare && IsRarePart(currentPart)) || !isRare)
                    {
                        if(newVal > (int)currentMax)
                            currentMax = (RarityEnum)newVal;
                    }
                }
            }
            else
            {
                if(newVal > (int)currentMax)
                    currentMax = (RarityEnum)newVal;
            }
            return currentMax;
        }

        public RarityEnum GetMaxRarityPart(bool excludeSpecial, bool isRare)
        {
            RarityEnum currentMaxRarity = RarityEnum.NONE;
            for(int i = 0 ; i < (int)KnightPartEnum.PEDESTAL ; i++)
            {
                currentMaxRarity = GetMaxRarity(currentMaxRarity, (KnightPartEnum)i, excludeSpecial, isRare);
            }
            currentMaxRarity = GetMaxRarity(currentMaxRarity, KnightPartEnum.PET, excludeSpecial, isRare);
            return currentMaxRarity;
        }

        public bool HasSameRarity(RarityEnum specificRarity)
        {
            bool isRare = false;
            if(specificRarity >= RarityEnum.RARE_COMMON)
            {
                specificRarity = (RarityEnum)((int)specificRarity - (int)RarityEnum.RARE_COMMON);
                isRare = true;
            }
            for(int i = 0 ; i < (int)KnightPartEnum.PEDESTAL ; i++)
            {
                int currentRarity = GetPartRarityIndex((KnightPartEnum)i);
                if(currentRarity == (int)specificRarity)
                {
                    if(isRare)
                    {
                        if(IsRarePart((KnightPartEnum)i))
                            return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasSameRarityOrBetter(RarityEnum specificRarity)
        {
            bool specialRarity = false;
            bool rareRarity = false;
            RarityEnum maxRarity = RarityEnum.COMMON;
            if(specificRarity >= RarityEnum.RARE_COMMON)
            {
                rareRarity = true;
                specificRarity = (RarityEnum)((int)specificRarity - (int)RarityEnum.RARE_COMMON);
            }
            else if(specificRarity >= RarityEnum.SPECIAL_COMMON)
                specialRarity = true;
            maxRarity = GetMaxRarityPart(!specialRarity, rareRarity);
            if(maxRarity >= specificRarity)
                return true;
            return false;
        }

        public bool HasComboOrBetter(PartComboType combo, RarityEnum rarity)
        {
            switch (combo)
            {
                case PartComboType.ARMOR_SET:
                    if(hasSetArmor && GetPartGlobalRarity(KnightPartEnum.ARMOR) >= rarity)
                        return true;
                    break;
                case PartComboType.RARE_ARMOR_SET:
                    if(hasRareSetArmor && GetPartGlobalRarity(KnightPartEnum.ARMOR) >= rarity)
                        return true;
                    break;
                case PartComboType.DUAL_ENCHANT:
                    if(sameTierEnchants && GetPartGlobalRarity(KnightPartEnum.MAIN_ENCHANT) >= rarity)
                        return true;
                    break;
                case PartComboType.EQUIPMENT_TIER:
                    if(sameTierEquipments && GetPartGlobalRarity(KnightPartEnum.ARMOR) >= rarity)
                        return true;
                    break;
                case PartComboType.RARE_EQUIPMENT_TIER:
                    if(sameTierRareEquipments && GetPartGlobalRarity(KnightPartEnum.ARMOR) >= rarity)
                        return true;
                    break;
                case PartComboType.SAME_NAME_TIER:
                    if(sameTierNames && GetPartGlobalRarity(KnightPartEnum.NAME) >= rarity)
                        return true;
                    break;
                case PartComboType.SAME_PHYSICAL_TIER:
                    if(sameTierPhysical && GetPartGlobalRarity(KnightPartEnum.FACE) >= rarity)
                        return true;
                    break;
                default:
                    return false;
            }
            return false;
        }

        public bool HasSpecificCombo(PartComboType combo, RarityEnum rarity)
        {
            switch (combo)
            {
                case PartComboType.ARMOR_SET:
                    if(hasSetArmor && GetPartGlobalRarity(KnightPartEnum.ARMOR) == rarity)
                        return true;
                    break;
                case PartComboType.RARE_ARMOR_SET:
                    if(hasRareSetArmor && GetPartGlobalRarity(KnightPartEnum.ARMOR) == rarity)
                        return true;
                    break;
                case PartComboType.DUAL_ENCHANT:
                    if(sameTierEnchants && GetPartGlobalRarity(KnightPartEnum.MAIN_ENCHANT) == rarity)
                        return true;
                    break;
                case PartComboType.EQUIPMENT_TIER:
                    if(sameTierEquipments && GetPartGlobalRarity(KnightPartEnum.ARMOR) == rarity)
                        return true;
                    break;
                case PartComboType.RARE_EQUIPMENT_TIER:
                    if(sameTierRareEquipments && GetPartGlobalRarity(KnightPartEnum.ARMOR) == rarity)
                        return true;
                    break;
                case PartComboType.SAME_NAME_TIER:
                    if(sameTierNames && GetPartGlobalRarity(KnightPartEnum.NAME) == rarity)
                        return true;
                    break;
                case PartComboType.SAME_PHYSICAL_TIER:
                    if(sameTierPhysical && GetPartGlobalRarity(KnightPartEnum.FACE) == rarity)
                        return true;
                    break;
                default:
                    return false;
            }
            return false;
        }

        public RarityEnum GetMaxSpecialRarityPart()
        {
            RarityEnum currentMaxRarity = RarityEnum.COMMON;
            for(int i = 0 ; i < (int)KnightPartEnum.PEDESTAL ; i++)
            {
                if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, i] <= (int)RarityEnum.SPECIAL_MYTHICAL)
                {
                    if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, i] > (int)currentMaxRarity)
                        currentMaxRarity = (RarityEnum)parts[ResourcePaths.KNIGHT_DATA_RARITY, i];
                }
            }
            return currentMaxRarity;
        }

        public RarityEnum GetMaxRareEnchantmentRarity()
        {
            RarityEnum currentMaxRarity = RarityEnum.NONE;
            int currentPart = 0;
            if(IsRarePart(KnightPartEnum.MAIN_ENCHANT))
            {
                currentPart = (int)KnightPartEnum.MAIN_ENCHANT;
                if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart] <= (int)RarityEnum.MYTHICAL)
                {
                    if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart] > (int)currentMaxRarity)
                        currentMaxRarity = (RarityEnum)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart];
                }
            }
            if(IsRarePart(KnightPartEnum.OFF_ENCHANT))
            {
                currentPart = (int)KnightPartEnum.OFF_ENCHANT;
                if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart] <= (int)RarityEnum.MYTHICAL)
                {
                    if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart] > (int)currentMaxRarity)
                        currentMaxRarity = (RarityEnum)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart];
                }
            }
            return currentMaxRarity;
        }

        public RarityEnum GetMaxRareEquipmentRarity()
        {
            RarityEnum currentMaxRarity = RarityEnum.NONE;
            int currentPart = 0;
            if(IsRarePart(KnightPartEnum.ARMOR))
            {
                currentPart = (int)KnightPartEnum.ARMOR;
                if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart] <= (int)RarityEnum.MYTHICAL)
                {
                    if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart] > (int)currentMaxRarity)
                        currentMaxRarity = (RarityEnum)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart];
                }
            }
            if(IsRarePart(KnightPartEnum.HELMET))
            {
                currentPart = (int)KnightPartEnum.HELMET;
                if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart] <= (int)RarityEnum.MYTHICAL)
                {
                    if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart] > (int)currentMaxRarity)
                        currentMaxRarity = (RarityEnum)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart];
                }
            }
            if(IsRarePart(KnightPartEnum.MAIN_HAND))
            {
                currentPart = (int)KnightPartEnum.MAIN_HAND;
                if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart] <= (int)RarityEnum.MYTHICAL)
                {
                    if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart] > (int)currentMaxRarity)
                        currentMaxRarity = (RarityEnum)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart];
                }
            }
            if(IsRarePart(KnightPartEnum.OFF_HAND))
            {
                currentPart = (int)KnightPartEnum.OFF_HAND;
                if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart] <= (int)RarityEnum.MYTHICAL)
                {
                    if((int)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart] > (int)currentMaxRarity)
                        currentMaxRarity = (RarityEnum)parts[ResourcePaths.KNIGHT_DATA_RARITY, currentPart];
                }
            }
            return currentMaxRarity;
        }

        public int GetPartIndex(KnightPartEnum part)
        {
            switch (part)
            {
                case KnightPartEnum.PET:
                    if(pet2!= null)
                        return pet2[ResourcePaths.KNIGHT_DATA_INDEX];
                    else
                        return -1;
                case KnightPartEnum.SHINYNESS:
                    return 0;
                default:
                    if(parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)part] == UInt16.MaxValue)
                        return -1;
                    else
                        return (int)parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)part];
            }
            
            
        }

        public RarityEnum GetPartRarity(KnightPartEnum part)
        {
            if((int)part < (int)KnightPartEnum.NAME)
            {
                if(parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part] == UInt16.MaxValue)
                    return RarityEnum.NONE;
                else
                    return (RarityEnum)parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part];
            }
            switch (part)
            {
                case KnightPartEnum.SHINYNESS:
                    return (RarityEnum)capsuleType;
                case KnightPartEnum.TITLE:
                case KnightPartEnum.TRAIT:
                case KnightPartEnum.NAME:
                    return (RarityEnum)titleUpgrades[(int)part - (int)KnightPartEnum.NAME];
                case KnightPartEnum.PET:
                    if(pet2 != null)
                        return (RarityEnum)pet2[ResourcePaths.KNIGHT_DATA_RARITY];
                    else
                        return RarityEnum.NONE;
                case KnightPartEnum.PEDESTAL:
                    if(parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part] == UInt16.MaxValue)
                        return RarityEnum.NONE;
                    else
                        return (RarityEnum)parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part];
                default:
                    return RarityEnum.NONE;
            }
        }

        public RarityEnum GetPartGlobalRarity(KnightPartEnum part)
        {
            switch (part)
            {
                case KnightPartEnum.SHINYNESS:
                    return (RarityEnum)capsuleType;
                case KnightPartEnum.TITLE:
                case KnightPartEnum.TRAIT:
                case KnightPartEnum.NAME:
                    return (RarityEnum)titleUpgrades[(int)part - (int)KnightPartEnum.NAME];
                case KnightPartEnum.PET:
                    if(pet2 != null)
                        return (RarityEnum)pet2[ResourcePaths.KNIGHT_DATA_RARITY];
                    else
                        return RarityEnum.NONE;
                case KnightPartEnum.BOTH_ENCHANT:
                    RarityEnum leftRarity = GetRawPartGlobalRarity(KnightPartEnum.OFF_ENCHANT);
                    RarityEnum rightRarity = GetRawPartGlobalRarity(KnightPartEnum.MAIN_ENCHANT);
                    if(leftRarity > rightRarity)
                        return leftRarity;
                    return rightRarity;
                default:
                    return GetRawPartGlobalRarity(part);
            }
            
        }

        public RarityEnum GetRawPartGlobalRarity(KnightPartEnum part)
        {
            if(parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part] == UInt16.MaxValue)
                return RarityEnum.NONE;
            else
            {
                int rarity = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part];
                if(rarity >= (int)RarityEnum.SPECIAL_COMMON)
                {
                    rarity -= (int)RarityEnum.SPECIAL_COMMON;
                }
                return (RarityEnum)rarity;
            }
        }
        public bool PossessPart(KnightPartEnum partType, PartDescription part)
        {
            switch (partType)
            {
                case KnightPartEnum.PET:
                    if(hasPet)
                    {
                        if(GetPartRarity(partType) == part.PartRarity)
                        {
                            if((part.PartIndex >= 0 && GetPartIndex(partType) == part.PartIndex) || part.PartIndex < 0)
                            {
                                if(part.PartOption == -1)
                                    return true;
                                else if(isPetShiny && part.PartOption == 1)
                                    return true;
                                else if(!isPetShiny && part.PartOption == 0)
                                    return true;
                            }
                        }
                    }
                    break;
                case KnightPartEnum.SPECIAL:
                    break;
                case KnightPartEnum.SHINYNESS:
                    if(capsuleType == (int)part.PartRarity)
                        return true;
                    break;
                case KnightPartEnum.BOTH_ENCHANT:
                    if(part.PartIndex >= 0)
                    {
                        if(GetPartRarity(KnightPartEnum.MAIN_ENCHANT) == part.PartRarity && GetPartIndex(KnightPartEnum.MAIN_ENCHANT) == part.PartIndex)
                            return true;
                        if(GetPartRarity(KnightPartEnum.OFF_ENCHANT) == part.PartRarity && GetPartIndex(KnightPartEnum.OFF_ENCHANT) == part.PartIndex)
                            return true;
                    }
                    else
                    {
                        if(GetPartRarity(KnightPartEnum.MAIN_ENCHANT) == part.PartRarity || GetPartRarity(KnightPartEnum.OFF_ENCHANT) == part.PartRarity)
                            return true;
                    }
                        
                    break;
                case KnightPartEnum.NAME:
                case KnightPartEnum.TITLE:
                case KnightPartEnum.TRAIT:
                    if(GetRawPartGlobalRarity(partType) == part.PartRarity && GetPartIndex(partType) == part.PartIndex)
                        return true;
                    break;
                default:
                    if(part.PartIndex >= 0)
                    {
                        if(GetPartRarity(partType) == part.PartRarity && GetPartIndex(partType) == part.PartIndex)
                            return true;
                    }
                    else if(part.PartRarity >= RarityEnum.COMMON)
                    {
                        if(GetPartRarity(partType) == part.PartRarity)
                            return true;
                    }
                    else if(GetPartGlobalRarityIndex(partType) >= 0)
                    {
                        return true;
                    }
                    
                    break;
            }
            return false;
        }

        public int GetPartGlobalRarityIndex(KnightPartEnum part)
        {
            if(part == KnightPartEnum.SHINYNESS)
            {
                return capsuleType;
            }
            else if(part == KnightPartEnum.PEDESTAL)
            {
                return parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part];
            }
            else
            {
                return (int)GetPartGlobalRarity(part);
            }
        }

        public int GetRawPartGlobalRarityIndex(KnightPartEnum part)
        {
            switch(part)
            {
                case KnightPartEnum.PET:
                    if(pet2 != null)
                        return pet2[ResourcePaths.KNIGHT_DATA_RARITY];
                    else
                        return -1;
                case KnightPartEnum.SHINYNESS:
                    return capsuleType;
                case KnightPartEnum.PEDESTAL:
                    return parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part];
                default:
                    return (int)GetRawPartGlobalRarity(part);
            }
        }

        public int GetPartRarityIndex(KnightPartEnum part)
        {
            if(part == KnightPartEnum.SHINYNESS)
            {
                return capsuleType;
            }
            else if(part == KnightPartEnum.PEDESTAL)
            {
                return parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part];
            }
            else
            {
                return (int)GetPartRarity(part);
            }
        }

        public bool IsInvertedPart(KnightPartEnum part)
        {
            InvertableFigurineParts truePart = GetInvertedPart(part);
            if(truePart != InvertableFigurineParts.NONE)
            {
                if(partStates[(int)truePart] == ResourcePaths.FIGURINE_PART_INVERTED)
                    return true;
            }
            return false;
        }

        public double GetInvertedProbas()
        {
            double probaValue = 1;
            for(int i = 0 ; i < (int)InvertableFigurineParts.MAX ; i++)
            {
                if(partStates[i] == ResourcePaths.FIGURINE_PART_INVERTED)
                    probaValue*=Probability.probabilityReverse;
                else
                    probaValue*=Probability.probabilityNoReverse;
            }
            return probaValue;
        }

        public int GetInvertedCount()
        {
            int count = 0;
            for(int i = 0 ; i < (int)InvertableFigurineParts.MAX ; i++)
            {
                if(partStates[i] == ResourcePaths.FIGURINE_PART_INVERTED)
                    count++;
            }
            return count;
        }

        private void CheckGlobalStates()
        {
            isFullInverted = true;
            invertedPartCount = 0;
            for(int i = 0 ; i < (int)InvertableFigurineParts.MAX ; i++)
            {
                switch ((InvertableFigurineParts)i)
                {
                    case InvertableFigurineParts.CAPE:
                        if(hasCape)
                        {
                            if(partStates[i] != ResourcePaths.FIGURINE_PART_INVERTED)
                                isFullInverted = false;
                            else
                                invertedPartCount++;
                        }
                        break;
                    case InvertableFigurineParts.MAIN_ENCHANT:
                        if(hasMainEnchant)
                        {
                            if(partStates[i] != ResourcePaths.FIGURINE_PART_INVERTED)
                                isFullInverted = false;
                            else
                                invertedPartCount++;
                        }
                        break;
                    case InvertableFigurineParts.OFF_ENCHANT:
                        if(hasOffEnchant)
                        {
                            if(partStates[i] != ResourcePaths.FIGURINE_PART_INVERTED)
                                isFullInverted = false;
                            else
                                invertedPartCount++;
                        }
                        break;
                    case InvertableFigurineParts.PET:
                        if(hasPet)
                        {
                            if(partStates[i] != ResourcePaths.FIGURINE_PART_INVERTED)
                                isFullInverted = false;
                            else
                                invertedPartCount++;
                        }
                        break;
                    case InvertableFigurineParts.SHINE:
                        if(partStates[i] == ResourcePaths.FIGURINE_PART_INVERTED)
                            invertedPartCount++;
                        break;
                    default:
                        if(partStates[i] != ResourcePaths.FIGURINE_PART_INVERTED)
                        {
                            isFullInverted = false;
                        }
                        else
                            invertedPartCount++;
                        break;
                }
                
            }
            isFullInverted = true;
        }

        public bool IsSpecialPart(KnightPartEnum part)
        {
            if(parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part] >= (int)RarityEnum.SPECIAL_COMMON)
                return true;
            return false;
        }

        public bool IsRarePart(KnightPartEnum part)
        {
            if(part == KnightPartEnum.PET)
                return false;
            if(parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part] >= (int)RarityEnum.SPECIAL_COMMON)
                return false;
            switch (part)
            {
                case KnightPartEnum.ARMOR:
                    int armorRarity = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.ARMOR];
                    ushort armorIndex = parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)KnightPartEnum.ARMOR];
                    if(GameData.rareArmorIndexes[armorRarity].Contains(armorIndex))
                        return true;
                    break;
                case KnightPartEnum.HELMET:
                    int helmetRarity = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.HELMET];
                    ushort helmetIndex = parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)KnightPartEnum.HELMET];
                    if(GameData.rareHelmetIndexes[helmetRarity].Contains(helmetIndex))
                        return true;
                    break;
                case KnightPartEnum.MAIN_HAND:
                    int mainRarity = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.MAIN_HAND];
                    ushort mainIndex = parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)KnightPartEnum.MAIN_HAND];
                    if(GameData.rareMainWeaponIndexes[mainRarity].Contains(mainIndex))
                        return true;
                    break;
                case KnightPartEnum.OFF_HAND:
                    int offRarity = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.OFF_HAND];
                    ushort offIndex= parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)KnightPartEnum.OFF_HAND];
                    if(GameData.rareOffWeaponIndexes[offRarity].Contains(offIndex))
                        return true;
                    break;
                case KnightPartEnum.OFF_ENCHANT:
                case KnightPartEnum.MAIN_ENCHANT:
                    int enchantRarity = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part];
                    ushort enchantIndex= parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)part];
                    if(GameData.rareEnchantIndexes[enchantRarity].Contains(enchantIndex))
                        return true;
                    break;
                default:
                    break;
            }
            return false;
        }

        public void RerollPart(KnightPartEnum part, int rerollBonus)
        {
            authentic = false;
            ushort rarity = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part];
            switch (part)
            {
                case KnightPartEnum.TITLE:
                case KnightPartEnum.NAME:
                case KnightPartEnum.TRAIT:
                    rarity = titleUpgrades[(int)part - (int)KnightPartEnum.NAME];
                    parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)part] = GetRandomIndex(part, rarity, 1);
                    parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part] = rarity;
                    break;
                case KnightPartEnum.FACE:
                case KnightPartEnum.BODY:
                    parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)part] = GetRandomIndex(part, rarity, 1);
                    break;
                case KnightPartEnum.ARMOR:
                case KnightPartEnum.HELMET:
                case KnightPartEnum.MAIN_HAND:
                case KnightPartEnum.OFF_HAND:
                    if(rarity >= (int)RarityEnum.SPECIAL_COMMON)
                        rarity -= (UInt16)RarityEnum.SPECIAL_COMMON;
                    rarity = SpecialTransform(rarity, rerollBonus);
                    parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part] = rarity;
                    parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)part] = GetRandomIndex(part, rarity, rerollBonus);
                    break;
                case KnightPartEnum.MAIN_ENCHANT:
                case KnightPartEnum.OFF_ENCHANT:
                    rarity = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part];
                    parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)part] = GetRandomIndex(part, rarity, rerollBonus);
                    break;
                case KnightPartEnum.CAPE:
                    parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)part] = GetRandomIndex(part, rarity, 1, rerollBonus);
                    break;
                default:
                    break;
            }
            
        }

        public void UpgradeTitle(KnightPartEnum part)
        {
            authentic = false;
            switch (part)
            {
                case KnightPartEnum.TITLE:
                case KnightPartEnum.NAME:
                case KnightPartEnum.TRAIT:
                    if(titleUpgrades[(int)part - (int)KnightPartEnum.NAME] < (int)RarityEnum.MYTHICAL)
                    {
                        titleUpgrades[(int)part - (int)KnightPartEnum.NAME]++;
                    }
                    break;
                default:
                    break;
            }
        }

        public void SetPart(KnightPartEnum part, int index, RarityEnum rarity, int option = 0, ushort state = 255)
        {
            authentic = false;
            if(part == KnightPartEnum.PET)
            {
                if(pet2 == null)
                    pet2 = new ushort[3];
                if(index < 0)
                {
                    pet2[ResourcePaths.KNIGHT_DATA_RARITY] = UInt16.MaxValue;
                    pet2[ResourcePaths.KNIGHT_DATA_INDEX] = UInt16.MaxValue;
                }
                else
                {
                    pet2[ResourcePaths.KNIGHT_DATA_RARITY] = (UInt16)rarity;
                    pet2[ResourcePaths.KNIGHT_DATA_INDEX] = (UInt16)index;
                    pet2[ResourcePaths.KNIGHT_DATA_SPECIAL] = (UInt16)option;
                }
            }
            else if(part  == KnightPartEnum.SHINYNESS)
            {
                if(index <= 0)
                    capsuleType = 0;
                else
                {
                    capsuleType = (UInt16)rarity;
                }
            }
            else
            {
                if(index < 0)
                {
                    parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)part] = UInt16.MaxValue;
                    parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part] = UInt16.MaxValue;
                }
                else
                {
                    parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)part] = (UInt16)index;
                    parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part] = (UInt16)rarity;
                }
                

                switch (part)
                {
                    case KnightPartEnum.TRAIT:
                    case KnightPartEnum.TITLE:
                    case KnightPartEnum.NAME:
                        titleUpgrades[(int)part - (int)KnightPartEnum.NAME] = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)part];
                        break;
                    default:
                        break;
                }
            }
            if(state != 255)
            {
                GeneratePartState(part, state);
            }
        }

        public void RedrawPart(KnightPartEnum part, int rarityBonus, int probaBoost)
        {
            authentic = false;
            GenerateKnightPart(part, 1, rarityBonus, probaBoost);
        }

        private void GenerateKnightData(int shinyLuckBoost, int specialBoost, int rarityBoost = 1, bool instantFamiliar = false, int familiarBoost = 1, bool isAllReverse = false)
        {
            hasCape = false;
            hasMainEnchant = false;
            hasOffEnchant = false;
            parts = new UInt16[2, (int)KnightPartEnum.PART_COUNT];
            titleUpgrades = new UInt16[3];
            partStates = new UInt16[(int)InvertableFigurineParts.MAX];
            int probabilityValue = 0;

            if(capsuleType == (UInt16)CapsuleTypes.NORMAL)
            {
                //GenerateCapsuleType
                probabilityValue = Randomizer.Range(Probability.maxProba);
                if(probabilityValue < Probability.probaGoldCapsule * shinyLuckBoost)
                {
                    if(shinyLuckBoost > 1)
                    {
                        shinyLuckBoost = (int)((1 - (float)probabilityValue/(float)shinyLuckBoost)*(float)shinyLuckBoost/10);
                        if(shinyLuckBoost < 1)
                            shinyLuckBoost = 1;
                    }
                        
                    probabilityValue = Randomizer.Range(Probability.maxProba);
                    if(probabilityValue < Probability.probaBlackCapsule * shinyLuckBoost)
                        capsuleType = (UInt16)CapsuleTypes.BLACK;
                    else if(probabilityValue < Probability.probaRedCapsule * shinyLuckBoost)
                        capsuleType = (UInt16)CapsuleTypes.RED;
                    else
                        capsuleType = (UInt16)CapsuleTypes.GOLD;
                    
                }
                else if(probabilityValue < Probability.probaSilverCapsule * shinyLuckBoost)
                    capsuleType = (UInt16)CapsuleTypes.SILVER;
                else
                    capsuleType = (UInt16)CapsuleTypes.NORMAL;
            }
            if(isPremium || instantFamiliar || familiarBoost > 1)
            {
                probabilityValue = Randomizer.Range(Probability.maxProba);
                int oddsBoost = 1;
                if(!instantFamiliar && familiarBoost > 1)
                {
                    oddsBoost = familiarBoost;
                    familiarBoost = 1;
                }
                    
                if(instantFamiliar || probabilityValue < Probability.probaFamiliar * oddsBoost)
                {
                    pet2 = new UInt16[3];
                    UInt16 rarity;
                    if(rarityBoost > familiarBoost)
                        rarity = GetRarity(false, 1, rarityBoost);
                    else
                        rarity = GetRarity(false, 1, familiarBoost);
                    
                    pet2[ResourcePaths.KNIGHT_DATA_RARITY] = rarity;
                    pet2[ResourcePaths.KNIGHT_DATA_INDEX] = GetRandomIndex(KnightPartEnum.PET, rarity, 1);

                    probabilityValue = Randomizer.Range(Probability.maxProba);
                    if(familiarBoost > 1)
                        familiarBoost *= 2;
                    if(probabilityValue < Probability.probaShiny * familiarBoost)
                        pet2[ResourcePaths.KNIGHT_DATA_SPECIAL] = 1;
                    else
                        pet2[ResourcePaths.KNIGHT_DATA_SPECIAL] = 0;
                        
                    if(isAllReverse)
                        GeneratePartState(KnightPartEnum.PET, ResourcePaths.FIGURINE_PART_INVERTED);
                    else
                        GeneratePartState(KnightPartEnum.PET);
                }
            }
            
            for(int i = 0 ; i < (int)KnightPartEnum.PEDESTAL ; i++)
            {
                GenerateKnightPart((KnightPartEnum)i, specialBoost, rarityBoost, 1, isAllReverse);
            }

            probabilityValue = Randomizer.Range(Probability.maxProba);
            if(probabilityValue < Probability.probaLeftHanded)
                leftHanded = true;
            
            if(shinyLuckBoost > 1 || specialBoost > 1 || rarityBoost > 1 || instantFamiliar || familiarBoost > 1 || isAllReverse)
            {
                authentic = false;
            }
            else
            {
                authentic = true;
            }
            UpdateData();
        }

        private void CalculatePedestalValue()
        {
            UInt16 pedestalRarity = 0;
            int rankIndex = GameData.rankThresholds.Length - 1;
            while(rankIndex > 0 && luckValue < GameData.rankThresholds[rankIndex])
            {
                rankIndex--;
            }
            pedestalRarity = (UInt16)rankIndex;
                
            parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)KnightPartEnum.PEDESTAL] = 0;
            parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.PEDESTAL] = pedestalRarity;
        }

        private void UpdateRaritySpecifics()
        {
            hasCape = false;
            hasPet = false;
            isPetShiny = false;
            hasMainEnchant = false;
            hasOffEnchant = false;
            sameTierEnchants = false;
            sameTierPhysical = false;
            sameTierNames = false;
            sameTierEquipments = false;
            sameTierRareEquipments = false;
            hasSetArmor = false;
            hasRareSetArmor = false;
            equipmentSetId = -1;
            equipmentSetRarity = -1;
            
            if(pet2 != null)
            {
                if(pet2[ResourcePaths.KNIGHT_DATA_RARITY] != ushort.MaxValue)
                {
                    hasPet = true;
                    if(pet2[ResourcePaths.KNIGHT_DATA_SPECIAL] == 1)
                        isPetShiny = true;
                }
            }

            if(parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.CAPE] != UInt16.MaxValue)
                hasCape = true;
            if(parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.MAIN_ENCHANT] != UInt16.MaxValue)
                hasMainEnchant = true;
            if(parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.OFF_ENCHANT] != UInt16.MaxValue)
                hasOffEnchant = true;
            

            if((titleUpgrades[0] == titleUpgrades[1]) && (titleUpgrades[2] == titleUpgrades[1]) && (titleUpgrades[2] > 0))
                sameTierNames = true;

            if((parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.MAIN_ENCHANT] == parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.OFF_ENCHANT]) &&
                (parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)KnightPartEnum.MAIN_ENCHANT] == parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)KnightPartEnum.OFF_ENCHANT]) &&
                (parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.MAIN_ENCHANT] != UInt16.MaxValue))
                sameTierEnchants = true;

            if(parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.FACE] == parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.BODY] &&
                (parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.FACE] > 0))
                sameTierPhysical = true;
            
            int helmetRarity = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.HELMET];
            int armorRarity = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.ARMOR];
            int mainRarity = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.MAIN_HAND];
            int offRarity = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)KnightPartEnum.OFF_HAND];
            bool helmetIsSpecial = false, armorIsSpecial = false, mainIsSpecial = false, offIsSpecial = false;
            bool helmetIsRare = false, armorIsRare = false, mainIsRare = false, offIsRare = false;

            int helmetIndex = parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)KnightPartEnum.HELMET];
            int armorIndex = parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)KnightPartEnum.ARMOR];

            if(helmetRarity >= (int)RarityEnum.SPECIAL_COMMON)
            {
                helmetRarity -= (int)RarityEnum.SPECIAL_COMMON;
                helmetIsSpecial = true;
            }
            else if(IsRarePart(KnightPartEnum.HELMET))
            {
                helmetIsRare = true;
            }
            if(armorRarity >= (int)RarityEnum.SPECIAL_COMMON)
            {
                armorRarity -= (int)RarityEnum.SPECIAL_COMMON;
                armorIsSpecial = true;
            }
            else if(IsRarePart(KnightPartEnum.ARMOR))
            {
                armorIsRare = true;
            }

            if(mainRarity >= (int)RarityEnum.SPECIAL_COMMON)
            {
                mainRarity -= (int)RarityEnum.SPECIAL_COMMON;
                mainIsSpecial = true;
            }
            else if(IsRarePart(KnightPartEnum.MAIN_HAND))
            {
                mainIsRare = true;
            }
            if(offRarity >= (int)RarityEnum.SPECIAL_COMMON)
            {
                offRarity -= (int)RarityEnum.SPECIAL_COMMON;
                offIsSpecial = true;
            }
            else if(IsRarePart(KnightPartEnum.OFF_HAND))
            {
                offIsRare = true;
            }

            if(armorRarity == helmetRarity && !armorIsSpecial && !helmetIsSpecial && armorIndex == helmetIndex)
            {
                if(armorIsRare)
                    hasRareSetArmor = true;
                else
                    hasSetArmor = true;
            }

            if(armorRarity == helmetRarity && armorRarity == mainRarity && armorRarity == offRarity)
            {
                if((armorIsSpecial || armorIsRare) && (helmetIsSpecial || helmetIsRare)
                && (mainIsSpecial || mainIsRare) && (offIsSpecial || offIsRare))
                {
                    sameTierRareEquipments = true;
                }
                else if(armorRarity > 0)
                    sameTierEquipments = true;

                if(!mainIsSpecial && !offIsSpecial)
                {
                    if(hasSetArmor && !mainIsRare && !offIsRare)
                    {
                        equipmentSetRarity = armorRarity;
                        equipmentSetId = armorIndex;
                    }
                    else if(hasRareSetArmor && mainIsRare && offIsRare)
                    {
                        equipmentSetRarity = armorRarity;
                        equipmentSetId = armorIndex;
                    }
                }
            }
               
        }

        private bool IsInCombo(KnightPartEnum part)
        {
            switch (part)
            {
                case KnightPartEnum.BODY:
                case KnightPartEnum.FACE:
                    if(sameTierPhysical)
                        return true;
                    break;
                case KnightPartEnum.MAIN_ENCHANT:
                case KnightPartEnum.OFF_ENCHANT:
                    if(sameTierEnchants)
                        return true;
                    break;
                case KnightPartEnum.ARMOR:
                case KnightPartEnum.HELMET:
                case KnightPartEnum.MAIN_HAND:
                case KnightPartEnum.OFF_HAND:
                    if((part == KnightPartEnum.ARMOR || part == KnightPartEnum.HELMET) && hasSetArmor)
                        return true;
                    if(sameTierEquipments)
                        return true;
                    break;
                case KnightPartEnum.NAME:
                case KnightPartEnum.TRAIT:
                case KnightPartEnum.TITLE:
                    if(sameTierNames)
                        return true;
                    break;
                default:
                    break;
            }
            return false;
        }

        private void GenerateKnightPart(KnightPartEnum currentPart, int specialBoost = 1, int rarityBoost = 1, int probaBoost = 1, bool isAllReverse = false)
        {
            UInt16 partRarity = 0;
            UInt16 partIndex = 0;
            int dropProbability = 0;
            switch (currentPart)
            {
                case KnightPartEnum.CAPE:
                    dropProbability = Probability.probaCape;
                    break;
                case KnightPartEnum.MAIN_ENCHANT:
                case KnightPartEnum.OFF_ENCHANT:
                    dropProbability = Probability.probaEnchant;
                    break;
                case KnightPartEnum.PET:
                    dropProbability = Probability.probaFamiliar;
                    break;
                case KnightPartEnum.PEDESTAL:
                    //Do pedestal stuff later
                    return;
                    
                default:
                    break;
            }

            if(dropProbability > 0)
            {
                float probaValue = Randomizer.Range(Probability.maxProba);
                if (probaValue < dropProbability * probaBoost)
                {
                    if(probaBoost > 1)
                    {
                        double impactedBoost = (double)rarityBoost * (dropProbability * 5 + 2500) / 10000;
                        partRarity = GetRarity(false, 1, (int)impactedBoost);
                    }
                    else
                    {
                        partRarity = GetRarity(false, 1, rarityBoost);
                    }
                    
                    
                    
                    partIndex = GetRandomIndex(currentPart, partRarity, specialBoost);

                    switch (currentPart)
                    {
                        case KnightPartEnum.CAPE:
                            hasCape = true;
                            break;
                        case KnightPartEnum.MAIN_ENCHANT:
                            hasMainEnchant = true;
                            break;
                        case KnightPartEnum.OFF_ENCHANT:
                            hasOffEnchant = true;
                            break;
                        case KnightPartEnum.PET:
                            hasPet = true;
                            pet2 = new ushort[3];
                            
                            pet2[ResourcePaths.KNIGHT_DATA_RARITY] = partRarity;
                            pet2[ResourcePaths.KNIGHT_DATA_INDEX] = partIndex;

                            probaValue = Randomizer.Range(Probability.maxProba);
                            if(probaValue < Probability.probaShiny)
                            {
                                pet2[ResourcePaths.KNIGHT_DATA_SPECIAL] = 1;
                                isPetShiny = true;
                            }
                            else
                            {
                                pet2[ResourcePaths.KNIGHT_DATA_SPECIAL] = 0;
                                isPetShiny = false;
                            }
                                
                            return;
                        default:
                            break;
                    }
                }
                else
                {
                    partIndex = UInt16.MaxValue;
                    switch (currentPart)
                    {
                        case KnightPartEnum.CAPE:
                            hasCape = false;
                            break;
                        case KnightPartEnum.MAIN_ENCHANT:
                            hasMainEnchant = false;
                            break;
                        case KnightPartEnum.OFF_ENCHANT:
                            hasOffEnchant = false;
                            break;
                        case KnightPartEnum.PET:
                            if(pet2 == null)
                                pet2= new ushort[3];
                            pet2[ResourcePaths.KNIGHT_DATA_INDEX] = partIndex;
                            pet2[ResourcePaths.KNIGHT_DATA_RARITY] = partIndex;
                            hasPet = false;
                            return;
                        default:
                            break;
                    }
                    
                }
            }
            else
            {
                switch (currentPart)
                {
                    case KnightPartEnum.ARMOR:
                    case KnightPartEnum.HELMET:
                    case KnightPartEnum.MAIN_HAND:
                    case KnightPartEnum.OFF_HAND:
                        partRarity = GetRarity(true, specialBoost, rarityBoost);
                        break;
                    default:
                        partRarity = GetRarity(false, 1, rarityBoost);
                        break;
                }
                partIndex = GetRandomIndex(currentPart, partRarity, specialBoost);
            }
            
            if (partIndex == UInt16.MaxValue)
            {
                partRarity = partIndex;
                GeneratePartState(currentPart, 0);
            }
            else
            {
                ushort defaultState = 255;
                if(isAllReverse)
                    defaultState = ResourcePaths.FIGURINE_PART_INVERTED;
                GeneratePartState(currentPart, defaultState);
            }
            parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)currentPart] = partIndex;
            parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)currentPart] = partRarity;
            switch (currentPart)
            {
                case KnightPartEnum.TRAIT:
                case KnightPartEnum.TITLE:
                case KnightPartEnum.NAME:
                    titleUpgrades[(int)currentPart - (int)KnightPartEnum.NAME] = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)currentPart];
                    break;
                default:
                    break;
            }
        }

        private void GeneratePartState(KnightPartEnum part, ushort partState = 255)
        {
            InvertableFigurineParts invertedPart = GetInvertedPart(part);
            if(invertedPart != InvertableFigurineParts.NONE)
            {
                if(partState >= 0 && partState < 255)
                {
                    partStates[(int)invertedPart] = partState;
                }
                else if(partState >= 255)
                {
                    float probaValue = Randomizer.Range(Probability.maxProba);
                    if (probaValue < Probability.probaReverse)
                    {
                        partStates[(int)invertedPart] = ResourcePaths.FIGURINE_PART_INVERTED;
                    }
                    else
                    {
                        partStates[(int)invertedPart] = 0;
                    }
                }
                
            }
        }

        private UInt16 GetRarity(bool specialEnabled = false, int specialBoost = 1, int rarityBoost = 1)
        {
            int currentProba = Randomizer.Range(Probability.maxProba);
            UInt16 rarityIndex = (int)RarityEnum.MAX - 1;
            while(rarityIndex > 0 && currentProba > Probability.partProbabilities[capsuleType, rarityIndex]*rarityBoost)
            {
                rarityIndex--;
            }
            if(specialEnabled)
            {
                rarityIndex = SpecialTransform(rarityIndex, specialBoost);
            }
            return rarityIndex;
        }

        private UInt16 SpecialTransform(UInt16 currentRarity, int specialBoost)
        {
            int currentProba = Randomizer.Range(Probability.maxProba);
            if(currentProba < Probability.probaSpecialPart*specialBoost)
            {
                currentRarity += (UInt16)RarityEnum.SPECIAL_COMMON;
            }
            return currentRarity;
        }

        private bool IsRarePart(int specialBoost, bool enchant = false)
        {
            int currentProba = Randomizer.Range(Probability.maxProba);
            if(enchant && (currentProba < Probability.probaRareEnchantPart*specialBoost))
                return true;
            else if(currentProba < Probability.probaRareEquipPart*specialBoost)
                return true;
            
            return false;
        }

        private bool CanUpgradePart(KnightPartEnum part)
        {
            if(parts[ResourcePaths.KNIGHT_DATA_RARITY, (UInt16)part] == UInt16.MaxValue || (int)GetPartGlobalRarity(part) < (int)RarityEnum.MAX - 1)
                return true;
            return false;
        }



        /*public void RankUpgrade(int amount = 1)
        {
            UInt16 startRank = parts[ResourcePaths.KNIGHT_DATA_RARITY, (UInt16)KnightPartEnum.PEDESTAL];
            UInt16 newRank = 0;
            while((startRank + amount) > newRank)
            {
                RandomRarityUpgrade(true);
                newRank = parts[ResourcePaths.KNIGHT_DATA_RARITY, (UInt16)KnightPartEnum.PEDESTAL];
            }
        }*/

        public void RandomRarityUpgrade(bool tryKeepCombos, int upgradeCount = 1, bool keepState = false )
        {
            authentic = false;
            double currentLuckValue = luckValue;
            
            while(upgradeCount > 0 && CanBeUpgraded)
            {
                int partIndex = Randomizer.Range((int)KnightPartEnum.TITLE);
                if(tryKeepCombos && IsInCombo((KnightPartEnum)partIndex))
                {
                    int partFindTry = 0;
                    bool partFound = false;

                    while(partFindTry < 20 && !partFound)
                    {
                        partFindTry++;
                        partIndex = Randomizer.Range((int)KnightPartEnum.TITLE);
                        if(!IsInCombo((KnightPartEnum)partIndex))
                            partFound = true;
                    }
                }
                ushort defaultState = 255;
                if(keepState)
                {
                    defaultState = GetPartState((KnightPartEnum)partIndex);
                }
                if(UpgradePartRarity((KnightPartEnum)partIndex, 1, null, defaultState))
                {
                    if(currentLuckValue < luckValue)
                        upgradeCount--;
                }
            }
        }

        public bool UpgradePartRarity(KnightPartEnum partType, int increment, PartDescription desc, ushort forcedState = 255)
        {
            authentic = false;
            int partRarity = (int)GetPartGlobalRarity(partType);
            if(partType == KnightPartEnum.SHINYNESS)
            {
                if(((int)capsuleType + increment) >= 1 && (((int)capsuleType + increment) <= (int)CapsuleTypes.BLACK))
                {
                    capsuleType = (ushort)((int)capsuleType + increment);
                    return true;
                }
            }
            else if(((partRarity + increment) >= 0) && ((partRarity + increment) <= (int)RarityEnum.MAX - 1))
            {
                if(desc != null)
                {
                    parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)partType] = (UInt16)desc.TruePartRarity;
                    parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)partType]= (UInt16)desc.PartIndex;
                    GeneratePartState(partType, (ushort)desc.PartState);
                }
                else
                {
                    UInt16 newRarity = (UInt16)(partRarity + increment);
                    switch (partType)
                    {
                        case KnightPartEnum.ARMOR:
                        case KnightPartEnum.HELMET:
                        case KnightPartEnum.MAIN_HAND:
                        case KnightPartEnum.OFF_HAND:
                            newRarity = SpecialTransform(newRarity, 1);
                            break;
                        default:
                            break;
                    }
                    parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)partType] = newRarity;
                    parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)partType]= GetRandomIndex(partType, newRarity, 1);
                    GeneratePartState(partType, forcedState);
                }
                switch (partType)
                {
                    case KnightPartEnum.TRAIT:
                    case KnightPartEnum.TITLE:
                    case KnightPartEnum.NAME:
                        titleUpgrades[(int)partType - (int)KnightPartEnum.NAME] = parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)partType];
                        break;
                    default:
                        break;
                }
                
                UpdateData();
                return true;
            }
            else if(parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)partType] == UInt16.MaxValue && increment > 0)
            {
                parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)partType] = 0;
                if(desc != null)
                {
                    parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)partType]= (UInt16)desc.PartIndex;
                    GeneratePartState(partType, (ushort)desc.PartState);
                }
                else
                {
                    parts[ResourcePaths.KNIGHT_DATA_INDEX, (int)partType]= GetRandomIndex(partType, parts[ResourcePaths.KNIGHT_DATA_RARITY, (int)partType], 1);
                    GeneratePartState(partType, forcedState);
                }
                    
                UpdateData();
                return true;
            }
            return false;
        }

        private UInt16 GetRandomIndex(KnightPartEnum currentPart, ushort currentRarity, int specialBoost, int rarityBoost = 1)
        {
            int maxIndex = 0;
            int minIndex = 0;
            List<ushort> indexes = null;

            int seasonPartIndex = GetRandomSeasonIndex(currentPart, currentRarity);
            if(seasonPartIndex >= 0)
                return (ushort)seasonPartIndex;

            if(currentRarity >= (UInt16)RarityEnum.SPECIAL_COMMON)
            {
                currentRarity -= (UInt16)RarityEnum.SPECIAL_COMMON;
                switch (currentPart)
                {
                    case KnightPartEnum.ARMOR:
                        maxIndex = GameData.specialArmorNumbers[(int)currentRarity];
                        break;
                    case KnightPartEnum.HELMET:
                        maxIndex = GameData.specialHelmetNumbers[(int)currentRarity];
                        break;
                    case KnightPartEnum.MAIN_HAND:
                        maxIndex = GameData.specialMainhandNumbers[(int)currentRarity];
                        break;
                    case KnightPartEnum.OFF_HAND:
                        maxIndex = GameData.specialOffHandNumbers[(int)currentRarity];
                        break;
                    default:
                        return UInt16.MaxValue;
                }
            }
            else
            {
                switch (currentPart)
                {
                    case KnightPartEnum.BODY:
                        maxIndex = GameData.bodyNumbers[(int)currentRarity];
                        break;
                    case KnightPartEnum.FACE:
                        maxIndex = GameData.faceNumbers[(int)currentRarity];
                        break;
                    case KnightPartEnum.ARMOR:
                        if(IsRarePart(specialBoost))
                        {
                            indexes = GameData.rareArmorIndexes[currentRarity];
                        }
                        else
                        {
                            indexes = GameData.normalArmorIndexes[currentRarity];
                        }
                        break;
                    case KnightPartEnum.CAPE:
                        UInt16 colorRarity;
                        if(specialBoost > 1)
                        {
                            specialBoost=specialBoost/2;
                            if(specialBoost < 1)
                                specialBoost = 1;
                        }
                        if(specialBoost > rarityBoost)
                            colorRarity = GetRarity(false, 1, specialBoost);
                        else
                            colorRarity = GetRarity(false, 1, rarityBoost);
                        maxIndex = GameData.capeMaxIndex[(int)colorRarity];
                        if(colorRarity > 0)
                            minIndex = GameData.capeMaxIndex[(int)colorRarity-1];
                        break;
                    case KnightPartEnum.HELMET:
                        if(IsRarePart(specialBoost))
                        {
                            indexes = GameData.rareHelmetIndexes[currentRarity];
                        }
                        else
                        {
                            indexes = GameData.normalHelmetIndexes[currentRarity];
                        }
                        break;
                    case KnightPartEnum.MAIN_HAND:
                        if(IsRarePart(specialBoost))
                        {
                            indexes = GameData.rareMainWeaponIndexes[currentRarity];
                        }
                        else
                        {
                            indexes = GameData.normalMainWeaponIndexes[currentRarity];
                        }
                        break;
                    case KnightPartEnum.OFF_HAND:
                        if(IsRarePart(specialBoost))
                        {
                            indexes = GameData.rareOffWeaponIndexes[currentRarity];
                        }
                        else
                        {
                            indexes = GameData.normalOffWeaponIndexes[currentRarity];
                        }
                        break;
                    case KnightPartEnum.MAIN_ENCHANT:
                    case KnightPartEnum.OFF_ENCHANT:
                        if(IsRarePart(specialBoost, true))
                        {
                            indexes = GameData.rareEnchantIndexes[currentRarity];
                        }
                        else
                        {
                            indexes = GameData.normalEnchantIndexes[currentRarity];
                        }
                        break;
                    case KnightPartEnum.NAME:
                        maxIndex = GameData.nameNumbers[(int)currentRarity];
                        break;
                    case KnightPartEnum.TRAIT:
                        maxIndex = GameData.traitNumbers[(int)currentRarity];
                        break;
                    case KnightPartEnum.TITLE:
                        maxIndex = GameData.titleNumbers[(int)currentRarity];
                        break;
                    case KnightPartEnum.PET:
                        maxIndex = GameData.petNumbers[(int)currentRarity];
                        break;
                    default:
                    return ushort.MaxValue;
                }
            }
            if(indexes != null)
            {
                return indexes[Randomizer.Range(indexes.Count - 1)];
            }
            return (ushort)Randomizer.Range(maxIndex-1, minIndex);
        }

        public static int GetCapeColorRarityIndex(int index)
        {
            int rarityIndex = 0;
            while(index >= GameData.capeMaxIndex[rarityIndex])
            {
                rarityIndex++;
            }
            return rarityIndex;
        }

        public static InvertableFigurineParts GetInvertedPart(KnightPartEnum part)
        {
            switch (part)
            {
                case KnightPartEnum.BODY:
                case KnightPartEnum.FACE:
                case KnightPartEnum.HELMET:
                case KnightPartEnum.CAPE:
                case KnightPartEnum.ARMOR:
                case KnightPartEnum.MAIN_HAND:
                case KnightPartEnum.OFF_HAND:
                case KnightPartEnum.MAIN_ENCHANT:
                case KnightPartEnum.OFF_ENCHANT:
                    return (InvertableFigurineParts)part;
                case KnightPartEnum.PET:
                    return InvertableFigurineParts.PET;
                default:
                    return InvertableFigurineParts.NONE;
            }
        }

        public static void InitSeasonalParts()
        {
            seasonalParts = new Dictionary<KnightPartEnum, List<int>[]>();
            specialSeasonalParts = new Dictionary<KnightPartEnum, List<int>[]>();
            for(int i = 0 ; i < (int)KnightPartEnum.PEDESTAL ; i++)
            {
                seasonalParts.Add((KnightPartEnum)i, new List<int>[] { new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>()});
                specialSeasonalParts.Add((KnightPartEnum)i, new List<int>[] { new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>()});
            }
            seasonalParts.Add(KnightPartEnum.PET, new List<int>[] { new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>()});
            specialSeasonalParts.Add(KnightPartEnum.PET, new List<int>[] { new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>()});
            seasonalInit = true;
        }

        public static void LoadSeasonalParts()
        {
            InitSeasonalParts();
            Godot.Collections.Dictionary dateTime = Time.GetDatetimeDictFromSystem(false);
            int currentMonth = (int)dateTime["month"];
            int rarity;
            foreach(SeasonParts seasonPart in SeasonalParts.seasonParts)
            {
                if(SeasonalParts.IsSeasonal(currentMonth, seasonPart.StartMonth, seasonPart.EndMonth))
                {
                    foreach(KeyValuePair<KnightPartEnum,List<PartDescription>> pair in seasonPart.Parts)
                    {
                        foreach(PartDescription desc in pair.Value)
                        {
                            if((int)desc.PartRarity >= (int)RarityEnum.SPECIAL_COMMON)
                            {
                                rarity = (int)desc.PartRarity - (int)RarityEnum.SPECIAL_COMMON;
                                specialSeasonalParts[pair.Key][rarity].Add(desc.PartIndex);
                            }
                            else
                            {
                                rarity = (int)desc.PartRarity;
                                seasonalParts[pair.Key][rarity].Add(desc.PartIndex);
                            }
                        }
                    }
                }
            }
        }

        public static void PremiumUpdate(bool premium)
        {
            isPremium = premium;
        }

        public static List<int> GetAvailableIndexes(KnightPartEnum part, int rarity)
        {
            List<int> indexes = new List<int>();
            if(!seasonalInit)
                return indexes;
            
            if(rarity >= (int)RarityEnum.SPECIAL_COMMON)
            {
                rarity = rarity - (int)RarityEnum.SPECIAL_COMMON;
                return specialSeasonalParts[part][rarity];
            }
            else
            {
                return seasonalParts[part][rarity];
            }
        }

        public static int GetRandomSeasonIndex(KnightPartEnum part, ushort rarity)
        {
            if(!seasonalInit)
                return -1;
            int proba = Randomizer.Range(Probability.maxProba);

            int rarityVal = 0;
            if(rarity >= (int)RarityEnum.SPECIAL_COMMON || part == KnightPartEnum.PET)
            {
                if(proba <= Probability.specialSeasonPartDrop)
                {
                    if(rarity >= (int)RarityEnum.SPECIAL_COMMON)
                    {
                        rarityVal = (int)rarity - (int)RarityEnum.SPECIAL_COMMON;
                        return RandomizeSeasonIndex(specialSeasonalParts, part, rarityVal);
                    }
                    else
                    {
                        rarityVal = (int)rarity;
                        return RandomizeSeasonIndex(seasonalParts, part, rarityVal);
                    }
                        
                }
            }
            else if(proba <= Probability.seasonPartDrop)
            {
                rarityVal = (int)rarity;
                return RandomizeSeasonIndex(seasonalParts, part, rarityVal);
            }
            return -1;
        }
        private static int RandomizeSeasonIndex(Dictionary<KnightPartEnum, List<int>[]> parts, KnightPartEnum part, int rarity)
        {
            int count = parts[part][rarity].Count;
            if(count > 1)
            {
                int index = Randomizer.Range(count - 1);
                return parts[part][rarity][index];
            }
            else if(count > 0)
            {
                return parts[part][rarity][0];
            }
            else
                return -1;
        }
    }
}
