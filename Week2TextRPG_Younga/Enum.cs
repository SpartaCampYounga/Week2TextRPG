using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2TextRPG_Younga
{
    enum SceneType
    {
        Main,
        Status,
        Inventory,
        Equipment,
        Store,
        Purchase
    }
    enum Ability
    {
        Attack,
        Defence,
        Health
    }
    public enum EquipSlot
    {
        Helmet,
        Armor,
        Weapon,
        Gloves,
        Boots,
        Accessory,
        Shield,
        Ring,
        Necklace
    }
}
