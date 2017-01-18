using System;
using System.Collections.Generic;
using System.Linq;
using Excello.RecordSources.Definitions;

namespace Excello.PersistedDefinitions.Source
{
    public static class SourceDefintionConversions
    {
        private static readonly Dictionary<string, Type>
            TypeMapping = new Dictionary<string, Type>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"string", typeof (String)},
                {"int", typeof (int)},
                {"date", typeof (DateTime)},
                {"decimal", typeof (decimal)},
            };

        public static DocumentEntityDefinition ToDocumentEntityDefinition(this SourceTableRangeDefinition dto)
        {
            var mappings = dto.Columns
                .Select(ToFieldDefinition)
                .ToDictionary(c => c.Name);

            return new DocumentEntityDefinition(mappings)
            {
                Range = dto.Range
            };
        }

        private static SourceFieldMappingDefinition ToFieldDefinition(this SourceColumnRangeDefinition dto)
        {
            Type mappedType;
            if (!TypeMapping.TryGetValue(dto.FinalType, out mappedType))
            {
                mappedType = null;
            }

            return new SourceFieldMappingDefinition
            {
                Name = dto.Name,
                SourceOrdinal = dto.SourceOrdinal,
                ParserDefinition = new ParserDefinition
                {
                    FinalType = mappedType,
                    ParsingFormats = dto.ParsingFormats
                }
            };
        }
    }
}