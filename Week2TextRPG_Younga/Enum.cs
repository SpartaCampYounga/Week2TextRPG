using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2TextRPG_Younga
{
    enum SceneType
    {
        Title,
        Status,
        Inventory,
        Equipment,
        Store,
        Purchase,
        Rest,
        Dungeon,
        Sell
    }
    enum Ability
    {
        Attack,
        Defence
    }
    public enum EquipSlot
    {
        Helmet,
        Armor,
        Weapon,
        Gloves,
        Boots,
        Accessory,
        Shield
    }
}
