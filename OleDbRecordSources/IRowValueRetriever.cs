using Excello.OleDbRecordSources.Reader;

namespace Excello.OleDbRecordSources
{
    public interface IRowValueRetriever
    {
        ValueRetrievalResult TryRetrieve(IRowDataReader reader, out object value);
    }
}