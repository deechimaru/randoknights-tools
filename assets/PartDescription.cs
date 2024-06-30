using Enums;

namespace Classes
{
    public class PartDescription
    {
        private int partIndex;
        private RarityEnum partRarity;
        private RarityEnum truePartRarity;
        private int partOption;
        private int partState;
        private bool excludeFromSet;
        
        public int PartIndex{
            get{
                return partIndex;
            }
        }

        public int PartState{
            get{
                return partState;
            }
        }

        public RarityEnum PartRarity{
            get{
                return partRarity;
            }
        }

        public RarityEnum TruePartRarity{
            get{
                return truePartRarity;
            }
        }

        public int PartOption{
            get{
                return partOption;
            }
        }

        public bool ExcludeFromSet{
            get{
                return excludeFromSet;
            }
        }
        
        public PartDescription(int index, RarityEnum rarity, int option = 0, bool exclude = false, int state = 0)
        {
            partIndex = index;
            partRarity = rarity;
            truePartRarity = partRarity;
            partOption = option;
            excludeFromSet = exclude;
            partState = state;
        }

        public PartDescription(int index, int rarity, int option = 0, bool exclude = false)
        {
            partIndex = index;
            partRarity = (RarityEnum)rarity;
            truePartRarity = partRarity;
            partOption = option;
            excludeFromSet = exclude;
        }

        public PartDescription(int index, RarityEnum rarity, bool exclude)
        {
            partIndex = index;
            partRarity = rarity;
            truePartRarity = partRarity;
            partOption = 0;
            excludeFromSet = exclude;
        }

        public PartDescription(int index, RarityEnum rarity, RarityEnum tRarity, int option = 0, int state = 0)
        {
            partIndex = index;
            partRarity = rarity;
            partOption = option;
            excludeFromSet = false;
            truePartRarity = tRarity;
            partState = state;
        }

        public PartDescription(int index, int rarity, bool exclude)
        {
            partIndex = index;
            partRarity = (RarityEnum)rarity;
            truePartRarity = partRarity;
            partOption = 0;
            excludeFromSet = exclude;
        }

        public bool IsSamePart(PartDescription other)
        {
            if(other.partIndex == partIndex && other.truePartRarity == truePartRarity && other.partOption == partOption && other.partState == partState)
                return true;
            return false;
        }

    }

}