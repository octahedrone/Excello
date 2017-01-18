namespace Excello.RecordSources.Definitions
{
    public class SourceFieldMappingDefinition
    {
        public int SourceOrdinal { get; set; }
        public string Name { get; set; }

        public ParserDefinition ParserDefinition { get; set; }
    }
}