using System;
using System.Collections.Generic;
using Excello.OleDbRecordSources.Reader;
using Excello.RecordSources;

namespace Excello.OleDbRecordSources
{
    public class DataRecordSource : IDataRecordSource
    {
        private readonly IRowsCollectionReaderFactory _rawReaderFactory;
        private readonly PropertyDataRetrieversCollection _retrievers;

        public DataRecordSource(IRowsCollectionReaderFactory rawReaderFactory,
            PropertyDataRetrieversCollection retrievers)
        {
            if (rawReaderFactory == null) throw new ArgumentNullException("rawReaderFactory");

            _rawReaderFactory = rawReaderFactory;
            _retrievers = retrievers;
        }
        
        public IEnumerable<IEntityDataRecord> GetRecords()
        {
            var rawReader = _rawReaderFactory.CreateReader();

            try
            {
                while (rawReader.MoveNext())
                {
                    var record = new EntityDataRecord();

                    foreach (var property in _retrievers)
                    {
                        object value;
                        if (property.Retriever.TryRetrieve(rawReader, out value) != ValueRetrievalResult.Success)
                            continue;

                        record.Values.Add(property.Name, value);
                    }

                    yield return record;
                }
            }
            finally
            {
                if (rawReader != null)
                    rawReader.Close();
            }
        }
    }
}