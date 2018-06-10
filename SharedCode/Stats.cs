using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SharedCode
{
    public class Stats
    {
        Random random = new Random();
        public double strength { get; set; }
        public double wisdom { get; set; }
        public double intelligence { get; set; }
        public double constitution { get; set; }
        public double charisma { get; set; }
        public double attack { get; set; }
        public double armorClass { get; set; }

        public void getStats()
        {
            strength = random.Next(19);
            wisdom = random.Next(19);
            intelligence = random.Next(19);
            constitution = random.Next(19);
            charisma = random.Next(19);
        }
        public void increaseStat(double stat, int amount = 1)
        {
            stat = stat + amount;
        }

        public Dictionary<string, int> getRandomStat(ItemEnums.Rarity rarity)
        {
            Type t = GetType();
            PropertyInfo[] props = t.GetProperties();
            List<string> listOfStats = new List<string>();
            string randomStat = "";
            int randomStatIncrease;
            Dictionary<string, int> bonus = new Dictionary<string, int>();
            foreach (var prop in props)
            {
                if (prop.GetIndexParameters().Length == 0
                    && prop.PropertyType == typeof(double)
                    && prop.Name != "hitPoints"
                    && prop.Name != "armorClass"
                    && prop.Name != "attack")
                {
                    listOfStats.Add(prop.Name);
                }
            }
            randomStat = listOfStats[random.Next(listOfStats.Count())];
            if (rarity == ItemEnums.Rarity.Normal)
            {
                randomStatIncrease = random.Next(1,3);
            }else if (rarity == ItemEnums.Rarity.Special)
            {
                randomStatIncrease = random.Next(2,4);
            }
            else if(rarity == ItemEnums.Rarity.Rare)
            {
                randomStatIncrease = random.Next(3, 5);
            }
            else
            {
                randomStatIncrease = 0;
                return bonus;
            }
            t.GetProperty(randomStat).SetValue(this, randomStatIncrease);
            bonus.Add(randomStat, randomStatIncrease);
            return bonus;
        }

        public void decreaseStat(double stat, int amount = 1)
        {
            stat = stat - amount;
        }
    }
}
