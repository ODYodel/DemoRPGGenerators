using System.Collections.Generic;

namespace Item_Generator
{
    public interface IArmorInterface
    {
        string name { get; set; }
        SharedCode.ItemEnums.ArmorTypes armorType {get;set; }
        SharedCode.ItemEnums.Rarity rarity { get; set; }
    }
}