using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Week2TextRPG_Younga.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
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
