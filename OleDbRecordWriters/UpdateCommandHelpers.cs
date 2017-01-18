using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Excello.RecordWriters;
using Excello.RecordWriters.Definitions;

namespace Excello.OleDbRecordWriters
{
    public static class UpdateCommandHelpers
    {
        public static IUpdateCommand PrepareCommandTemplate(OleDbCommand command,
            DestinationDocumentEntityDefinition documentDefinition)
        {
            string query = String.Format("Update [{0}] Set ", documentDefinition.RowRangeFormat);
            var mapping = new Dictionary<string, int>(documentDefinition.FieldMappings.Count);

            foreach (var fieldMapping in documentDefinition.FieldMappings)
            {
                var paramName = String.Format("@value{0}", command.Parameters.Count + 1);
                query += String.Format("F{0} = {1},", fieldMapping.Value.Ordinal + 1, paramName);

                var param = new OleDbParameter()
                {
                    ParameterName = paramName,
                    IsNullable = true,
                    DbType = DbType.String,
                };

                mapping.Add(fieldMapping.Key, command.Parameters.Count);
                command.Parameters.Add(param);
            }

            query = query.Substring(0, query.Length - 1);

            return new UpdateCommand(command, query, mapping) { RowOffset = documentDefinition.DocumentFirstRowOffset };
        }
    }
}