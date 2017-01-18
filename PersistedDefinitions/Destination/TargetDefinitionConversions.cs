using System.Linq;
using Excello.RecordWriters.Definitions;

namespace Excello.PersistedDefinitions.Destination
{
    public static class TargetDefinitionConversions
    {
        public static DestinationDocumentEntityDefinition ToDestinationDocumentEntityDefinition(
            this TargetTableRangeDefinition dto)
        {
            var mappings = dto.Columns
                .Select(ToFieldMappingDefinition)
                .ToDictionary(c => c.Name);

            return new DestinationDocumentEntityDefinition(mappings)
            {
                DocumentFirstRowOffset = dto.DocumentFirstRowOffset,
                RowRangeFormat = dto.RowRangeFormat,
            };
        }

        private static DestinationFieldMappingDefinition ToFieldMappingDefinition(this TargetColumnRangeDefinition dto)
        {
            return new DestinationFieldMappingDefinition
            {
                Name = dto.Name,
                FormatString = dto.FormatString,
                Ordinal = dto.Ordinal
            };
        }
    }
}