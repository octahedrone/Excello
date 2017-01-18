using System.Globalization;
using Excello.OleDbRecordSources.Reader;

namespace Excello.OleDbRecordSources
{
    public class StringToIntValueConverter : IValueConverter
    {
        public CultureInfo Culture { get; set; }

        public ValueRetrievalResult TryConvert(string source, out object value)
        {
            value = null;
            if (source == null)
                return ValueRetrievalResult.Unconvertible;

            int intValue;
            var conversionResult = int.TryParse(source, NumberStyles.Any, Culture, out intValue);
            value = intValue;

            return conversionResult
                ? ValueRetrievalResult.Success
                : ValueRetrievalResult.Unconvertible;
        }
    }
}