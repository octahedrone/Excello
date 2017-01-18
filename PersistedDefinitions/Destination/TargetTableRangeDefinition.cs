using System.Collections.Generic;
using Newtonsoft.Json;

namespace Excello.PersistedDefinitions.Destination
{
    [JsonObject]
    public struct TargetTableRangeDefinition
    {
        [JsonProperty("offset")]
        public int DocumentFirstRowOffset { get; set; }

        [JsonProperty("row-format")]
        public string RowRangeFormat { get; set; }

        [JsonProperty("columns")]
        public List<TargetColumnRangeDefinition> Columns { get; set; }
    }
}