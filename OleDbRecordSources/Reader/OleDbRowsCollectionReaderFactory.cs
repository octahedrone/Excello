using System;
using System.Data;
using System.Linq;
using Excello.RecordSources.Definitions;

namespace Excello.OleDbRecordSources.Reader
{
    public class OleDbRowsCollectionReaderFactory : IRowsCollectionReaderFactory
    {
        private readonly string _workbookPath;
        private readonly DocumentEntityDefinition _definition;

        public OleDbRowsCollectionReaderFactory(string workbookPath, DocumentEntityDefinition definition)
        {
            _workbookPath = workbookPath;
            _definition = definition;
        }

        public IRowsCollectionReader CreateReader()
        {
            var query = CreateSelectQuery(_definition);
            var fieldOrdinals = _definition.FieldMappings
                .Select(k => k.Value.SourceOrdinal)
                .OrderBy(k => k)
                .ToArray();

            var columnMappings = _definition.FieldMappings
                .ToDictionary(k => k.Key, k => Array.IndexOf(fieldOrdinals, k.Value.SourceOrdinal));

            var connection = _workbookPath.Connect();

            try
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = query;

                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                return new RowsCollectionReader(reader, columnMappings);
            }
            catch
            {
                connection.Close();

                throw;
            }
        }

        private static string CreateSelectQuery(DocumentEntityDefinition definition)
        {
            var query = String.Empty;
            foreach (var field in definition.FieldMappings.Values.OrderBy(r => r.SourceOrdinal))
            {
                query += string.Format("IIf(IsNull([F{0}]), Null, CStr([F{0}])) as F{0},", field.SourceOrdinal + 1);
            }

            if (query.Length == 0)
            {
                // there where no fields
                return string.Format("Select * From [{0}]", definition.Range);
            }

            query = query.Substring(0, query.Length - 1);

            return string.Format("Select {1} From [{0}]", definition.Range, query);
        }
    }
}