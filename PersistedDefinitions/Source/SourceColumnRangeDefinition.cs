using Newtonsoft.Json;

namespace Excello.PersistedDefinitions.Source
{
    [JsonObject]
    public struct SourceColumnRangeDefinition
    {
        [JsonProperty("ordinal")]
        public int SourceOrdinal { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parse-as")]
        public string FinalType { get; set; }

        [JsonProperty("parse-with")]
        public string[] ParsingFormats { get; set; }
    }
}