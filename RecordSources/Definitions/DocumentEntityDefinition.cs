using System;
using System.Collections.Generic;

namespace Excello.RecordSources.Definitions
{
    public class DocumentEntityDefinition
    {
        public DocumentEntityDefinition() 
            : this(new Dictionary<string, SourceFieldMappingDefinition>())
        {
        }

        public DocumentEntityDefinition(Dictionary<string, SourceFieldMappingDefinition> fieldMappings)
        {
            if (fieldMappings == null) throw new ArgumentNullException("fieldMappings");

            FieldMappings = fieldMappings;
        }

        public string Range { get; set; }

        public Dictionary<string, SourceFieldMappingDefinition> FieldMappings { get; private set; }
    }
}