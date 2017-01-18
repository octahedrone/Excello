using System;
using System.Collections.Generic;
using System.Data;

namespace Excello.OleDbRecordSources.Reader
{
    public class RowsCollectionReader : IRowsCollectionReader
    {
        private readonly IDataReader _dataReader;
        private readonly Dictionary<string, int> _columnMappings;

        public RowsCollectionReader(IDataReader dataReader, Dictionary<string, int> columnMappings)
        {
            if (dataReader == null) throw new ArgumentNullException("dataReader");
            if (columnMappings == null) throw new ArgumentNullException("columnMappings");

            _dataReader = dataReader;
            _columnMappings = columnMappings;
        }

        public ValueRetrievalResult TryGetValue(string name, out string value)
        {
            value = null;

            if (_dataReader.IsClosed)
                return ValueRetrievalResult.Absent;

            int ordinal;
            if (!_columnMappings.TryGetValue(name, out ordinal))
                return ValueRetrievalResult.Absent;

            if (_dataReader.IsDBNull(ordinal))
                return ValueRetrievalResult.Absent;

            value = _dataReader.GetString(ordinal);
            return ValueRetrievalResult.Success;
        }

        public bool MoveNext()
        {
            return _dataReader.Read();
        }

        public void Close()
        {
            _dataReader.Close();
        }
    }
}