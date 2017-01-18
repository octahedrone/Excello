using System.Collections.Generic;
using Newtonsoft.Json;

namespace Excello.PersistedDefinitions.Source
{
    [JsonObject]
    public struct SourceTableRangeDefinition
    {
        [JsonProperty("range")]
        public string Range { get; set; }

        [JsonProperty("columns")]
        public List<SourceColumnRangeDefinition> Columns { get; set; }
    }
}