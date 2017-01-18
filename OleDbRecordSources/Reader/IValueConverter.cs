namespace Excello.OleDbRecordSources.Reader
{
    public interface IValueConverter
    {
        ValueRetrievalResult TryConvert(string source, out object value);
    }
}