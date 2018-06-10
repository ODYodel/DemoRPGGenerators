using SharedCode;
using System;
using System.Collections.Generic;

namespace Item_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.WriteLine("Item Generator");
            Armor armor;
            Weapon weapon;
            if (random.Next(100) > 50)
            {
                armor = new Armor();
                Console.WriteLine("{0}", armor.armorType);
                Console.WriteLine("{0}", armor.rarity);
                foreach (KeyValuePair<string, int> item in armor.bonus)
                {
                    Console.WriteLine("{0} : {1}", item.Key, item.Value);
                }
            }
            else
            {
                weapon = new Weapon();
                Console.WriteLine("{0}", weapon.weaponType);
                Console.WriteLine("{0}", weapon.rarity);
                foreach (KeyValuePair<string, int> item in weapon.bonus)
                {
                    Console.WriteLine("{0} : {1}", item.Key, item.Value);
                }
            }
            Console.ReadLine();
        }
    }
    class Weapon : Stats, IWeaponInterface
    {
        private Random random = new Random();
        public string name { get; set; }
        public ItemEnums.WeaponTypes weaponType { get; set; }
        public ItemEnums.Rarity rarity { get; set; }
        public Dictionary<string, int> bonus { get; set; }
        public Weapon()
        {
            getWeapon();
        }

        private void getBonuses()
        {
            bonus = getRandomStat(rarity);
        }

        private void getRarity()
        {
            int maxRandom = Enum.GetNames(typeof(ItemEnums.Rarity)).Length;
            int selectedNum = random.Next(maxRandom);
            rarity = ((ItemEnums.Rarity)selectedNum);
            getBonuses();
        }

        private void getWeapon()
        {
            int maxRandom = Enum.GetNames(typeof(ItemEnums.WeaponTypes)).Length;
            int selectedNum = random.Next(maxRandom);
            weaponType = ((ItemEnums.WeaponTypes)selectedNum);
            getRarity();
        }
    }
    public class Armor : Stats, IArmorInterface
    {
        private Random random = new Random();
        public string name { get; set; }
        public ItemEnums.ArmorTypes armorType { get; set; }
        public ItemEnums.Rarity rarity { get; set; }
        public Dictionary<string, int> bonus { get; set; }
        public Armor()
        {
            getArmor();
        }

        private void getBonuses()
        {
                bonus = getRandomStat(rarity);
        }

        private void getRarity()
        {
            int maxRandom = Enum.GetNames(typeof(ItemEnums.Rarity)).Length;
            int selectedNum = random.Next(maxRandom);
            rarity = ((ItemEnums.Rarity)selectedNum);
            getBonuses();
        }

        private void getArmor()
        {
            int maxRandom = Enum.GetNames(typeof(ItemEnums.ArmorTypes)).Length;
            int selectedNum = random.Next(maxRandom);
            armorType = ((ItemEnums.ArmorTypes)selectedNum);
            getRarity();
        }
    }
}
