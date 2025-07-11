using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Week2TextRPG_Younga.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EquipSlot
    {
        //[EnumMember(Value = "helmet")]
        Helmet,
        //[EnumMember(Value = "armor")]
        Armor,
        //[EnumMember(Value = "weapon")]
        Weapon,
        //[EnumMember(Value = "gloves")]
        Gloves,
        //[EnumMember(Value = "boots")]
        Boots,
        //[EnumMember(Value = "accessory")]
        Accessory,
        //[EnumMember(Value = "shield")]
        Shield
    }
}
