using System;
using Excello.OleDbRecordSources.Reader;
using Excello.RecordSources.Definitions;

namespace Excello.OleDbRecordSources
{
    public static class DocumentEntityDefinitionConversions
    {
        public static PropertyDataRetrieversCollection ToPropertyDataRetrievers(this DocumentEntityDefinition definition)
        {
            var entityProperties = new PropertyDataRetrieversCollection();
            foreach (var fieldDefinition in definition.FieldMappings.Values)
            {
                var valueType = fieldDefinition.ParserDefinition.FinalType;

                IValueConverter converter = null;

                if (valueType == typeof (DateTime))
                {
                    converter = new DateTimeValueConverter(fieldDefinition.ParserDefinition.ParsingFormats);
                }

                var sourceValueRetriever = new RowValueRetriever(fieldDefinition.Name)
                {
                    Converter = converter
                };

                var retriever = new PropertyDataRetriever(fieldDefinition.Name, sourceValueRetriever);

                entityProperties.Add(retriever);
            }

            return entityProperties;
        }
    }
}