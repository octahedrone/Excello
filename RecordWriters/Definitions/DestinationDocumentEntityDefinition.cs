using System;
using System.Collections.Generic;

namespace Excello.RecordWriters.Definitions
{
    public class DestinationDocumentEntityDefinition
    {
        public DestinationDocumentEntityDefinition()
            : this(new Dictionary<string, DestinationFieldMappingDefinition>())
        {
        }

        public DestinationDocumentEntityDefinition(Dictionary<string, DestinationFieldMappingDefinition> fieldMappings)
        {
            if (fieldMappings == null)
                throw new ArgumentNullException("fieldMappings");

            FieldMappings = fieldMappings;
        }

        public int DocumentFirstRowOffset { get; set; }

        public string RowRangeFormat { get; set; }

        public Dictionary<string, DestinationFieldMappingDefinition> FieldMappings { get; private set; }
    }
}