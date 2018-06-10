
using SharedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NPC_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Npc npc = new Npc();
            Console.WriteLine("Hello there. My Name is {0} and I'm a {1} {2}", npc.name, npc.Race, npc.characterClass);
            string highestStat = GetHighestStat(npc);
            if(nameof(npc.strength) == highestStat)
            {
                Console.WriteLine("My greatest asset is my strength");
            }
            if (nameof(npc.wisdom) == highestStat)
            {
                Console.WriteLine("My greatest asset is my wisdom");
            }
            if (nameof(npc.intelligence) == highestStat)
            {
                Console.WriteLine("My greatest asset is my intelligence");
            }
            if (nameof(npc.charisma) == highestStat)
            {
                Console.WriteLine("My greatest asset is my charisma");
            }
            if (nameof(npc.constitution) == highestStat)
            {
                Console.WriteLine("My greatest asset is my health");
            }
            Console.ReadLine();
        }
        private static string GetHighestStat(Object obj)
        {
            Type t = obj.GetType();
            PropertyInfo[] props = t.GetProperties();
            double highestValue = 0;
            string highestStat = "";
            foreach (var prop in props)
            {
                if (prop.GetIndexParameters().Length == 0
                    && prop.PropertyType == typeof(double)
                    && prop.Name != "hitPoints"
                    && prop.Name != "armorClass"
                    && prop.Name != "attack")
                {
                    if ((double)prop.GetValue(obj) > highestValue)
                    {
                        highestValue = (double)prop.GetValue(obj);
                        highestStat = prop.Name;
                    }
                }
            }
            return highestStat;

        }
    }
    public class Npc : Stats, ICharacterInterface
    {
        private Random random = new Random();
        public string name { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public CharacterEnums.Race Race { get; set; }
        public CharacterEnums.CharacterClass characterClass { get; set; }
        public double hitPoints { get; set; }
        public CharacterEnums.Gender gender { get; set; }

        public Npc()
        {
            getStats();
            getGender();
            Race = getRace();
            getName();
            characterClass = getCharacterClass();
            hitPoints = getHitPoints();
        }

        private void getGender()
        {
            int maxRandom = Enum.GetNames(typeof(CharacterEnums.Gender)).Length;
            int selectedNum = random.Next(0, maxRandom);
            CharacterEnums.Gender gender = ((CharacterEnums.Gender)selectedNum);
        }

        private double getHitPoints()
        {
            if (characterClass == CharacterEnums.CharacterClass.Barbarian)
            {
                hitPoints = random.Next(1, 11);
            }
            if (characterClass == CharacterEnums.CharacterClass.Wizard)
            {
                hitPoints = random.Next(1, 3);
            }
            if (characterClass == CharacterEnums.CharacterClass.Druid || characterClass == CharacterEnums.CharacterClass.Cleric)
            {
                hitPoints = random.Next(1, 7);
            }
            if (characterClass == CharacterEnums.CharacterClass.Fighter || characterClass == CharacterEnums.CharacterClass.Paladin)
            {
                hitPoints = random.Next(1, 9);
            }
            if (characterClass == CharacterEnums.CharacterClass.Rogue)
            {
                hitPoints = random.Next(1, 5);
            }
            if (hitPoints <= 4 && characterClass != CharacterEnums.CharacterClass.Wizard)
            {
                hitPoints = 6;
            }
            return hitPoints;
        }

        private CharacterEnums.CharacterClass getCharacterClass()
        {
            int maxRandom = Enum.GetNames(typeof(CharacterEnums.CharacterClass)).Length;
            int selectedNum = random.Next(0, maxRandom);
            CharacterEnums.CharacterClass characterClass = ((CharacterEnums.CharacterClass)selectedNum);
            return characterClass;
        }

        private CharacterEnums.Race getRace()
        {
            int maxRandom = Enum.GetNames(typeof(CharacterEnums.Race)).Length;
            int selectedNum = random.Next(0, maxRandom);
            CharacterEnums.Race Race = ((CharacterEnums.Race)selectedNum);
            getRacials();
            return Race;
        }

        private void getRacials()
        {
            if (Race == CharacterEnums.Race.Human)
            {
                return;
            }
            if (Race == CharacterEnums.Race.Dwarf)
            {
                strength = strength + 2;
            }
            return;
        }

        private void getName()
        {
            if (Race == CharacterEnums.Race.Human && gender == CharacterEnums.Gender.Male)
            {
                List<string> humanMaleFirstNames = new List<string>() { "Alister", "Strider", "Barnubus" };
                firstName = (string)humanMaleFirstNames[random.Next(humanMaleFirstNames.Count)];
                lastName = "Bob";
            }
            else
            {
                firstName = "fail";
                lastName = "loser";
            }
            name = string.Format("{0} {1}", firstName, lastName);
        }
    }
}
