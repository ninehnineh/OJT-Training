using System.Text.Json.Serialization;

namespace SuperHeroAPI.Models
{
    // To convert a defaut value (int) of a enum into string
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight, // 0 for default value
        Mage,   // 1 ....
        Cleric  // 2
    }
}
