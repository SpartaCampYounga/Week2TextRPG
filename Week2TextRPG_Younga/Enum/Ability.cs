using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Week2TextRPG_Younga.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    enum Ability
    {
        Attack,
        Defence
    }
}
