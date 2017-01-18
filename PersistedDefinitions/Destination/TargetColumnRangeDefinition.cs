using Newtonsoft.Json;

namespace Excello.PersistedDefinitions.Destination
{
    [JsonObject]
    public struct TargetColumnRangeDefinition
    {
        [JsonProperty("ordinal")]
        public int Ordinal { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("format-with")]
        public string FormatString { get; set; }
    }
}