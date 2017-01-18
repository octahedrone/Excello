namespace Excello.OleDbRecordSources.Reader
{
    public class RowValueRetriever : IRowValueRetriever
    {
        private readonly string _sourcePropertyName;

        public RowValueRetriever(string sourcePropertyName)
        {
            _sourcePropertyName = sourcePropertyName;
        }

        public IValueConverter Converter { get; set; }

        public ValueRetrievalResult TryRetrieve(IRowDataReader reader, out object value)
        {
            string stringValue;
            var result = reader.TryGetValue(_sourcePropertyName, out stringValue);

            value = stringValue;
            if (result != ValueRetrievalResult.Success)
                return result;

            return Converter != null
                ? Converter.TryConvert(stringValue, out value)
                : ValueRetrievalResult.Success;
        }
    }
}