using System;
using System.Collections.Generic;
using System.Text;

namespace NPC_Generator
{
    public interface ICharacterInterface
    {
        string name { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        CharacterEnums.Race Race { get; set; }
        CharacterEnums.CharacterClass characterClass { get; set; }
        CharacterEnums.Gender gender { get; set; }
    }
}
