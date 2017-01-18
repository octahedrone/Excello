namespace Excello.OleDbRecordSources.Reader
{
    public interface IRowDataReader
    {
        ValueRetrievalResult TryGetValue(string name, out string value);
    }
}