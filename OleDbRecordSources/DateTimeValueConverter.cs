using System;
using System.Globalization;
using Excello.OleDbRecordSources.Reader;

namespace Excello.OleDbRecordSources
{
    public class DateTimeValueConverter : IValueConverter
    {
        private readonly string[] _parseFormats;

        public DateTimeValueConverter(string[] parseFormats)
        {
            _parseFormats = parseFormats;
        }

        public ValueRetrievalResult TryConvert(string source, out object value)
        {
            DateTime date;
            if (DateTime.TryParse(source, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out date))
            {
                value = date;
                return ValueRetrievalResult.Success;
            }

            value = null;
            return ValueRetrievalResult.Unconvertible;
        }
    }
}