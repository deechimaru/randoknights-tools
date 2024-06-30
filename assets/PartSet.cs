using Enums;
using Utils;
using System.Collections.Generic;
namespace Classes
{
    public class PartSet
    {
        private Dictionary<KnightPartEnum,List<PartDescription>> parts;

        public Dictionary<KnightPartEnum,List<PartDescription>> Parts
        {
            get{
                return parts;
            }
        }
        private double setBonus;


        public double Bonus{
            get{
                return setBonus;
            }
        }
        public PartSet(double bonus, Dictionary<KnightPartEnum,List<PartDescription>> partsList)
        {
            setBonus = bonus;
            parts = partsList;
        }

        public bool HasSet(KnightData knightToCheck)
        {
            bool foundPart;
            foreach (KeyValuePair<KnightPartEnum,List<PartDescription>>  partPair in parts)
            {
                foundPart = false;
                foreach (PartDescription partType in partPair.Value)
                {
                    if(knightToCheck.PossessPart(partPair.Key, partType))
                        foundPart = true;
                }
                if(!foundPart)
                    return false;
            }
            return true;
        }

        public double GetSetBonus(KnightData knightToCheck)
        {
            int partcount = 0;
            foreach (KeyValuePair<KnightPartEnum,List<PartDescription>>  partPair in parts)
            {
                foreach (PartDescription partType in partPair.Value)
                {
                    if(knightToCheck.PossessPart(partPair.Key, partType))
                    {
                        partcount++;
                        break;
                    }
                }
            }
            if(partcount > 1)
            {
                int index = parts.Count - 2;
                if(index < 0 || index >= KnightSets.setBonusRepartition.GetLength(0))
                    return 0;
                
                return setBonus/100.0*KnightSets.setBonusRepartition[index,partcount-1];
            }
            else
                return 0;
        }

        public bool HasPartOfSet(Knight knightToCheck)
        {
            foreach (KeyValuePair<KnightPartEnum,List<PartDescription>>  partPair in parts)
            {
                foreach (PartDescription partType in partPair.Value)
                {
                    if(!partType.ExcludeFromSet && knightToCheck.PossessPart(partPair.Key, partType))
                        return true;
                }
            }
            return false;
        }

        public bool NeedPremium()
        {
            if(parts.ContainsKey(KnightPartEnum.PET))
                return true;
            return false;
        }

        public SetInformation GetSetInformation(Knight knightToCheck)
        {
            int maxPart = 0;
            int currentPart = 0;
            int excludedParts = 0;
            foreach (KeyValuePair<KnightPartEnum,List<PartDescription>>  partPair in parts)
            {
                maxPart++;
                foreach (PartDescription partType in partPair.Value)
                {
                    if(knightToCheck.PossessPart(partPair.Key, partType))
                    {
                        if(partType.ExcludeFromSet)
                            excludedParts++;
                        currentPart++;
                        break;
                    }
                }
            }
            if(currentPart > 0 && currentPart > excludedParts)
            {
                return new SetInformation(currentPart, maxPart);
            }
            return null;
        }
    }


}