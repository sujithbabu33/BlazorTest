using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System.Globalization;

namespace SalesDataViewer.Helpers
{
    public class CurrencyConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return default(decimal);
            }

            // Remove symbols and convert to decimal
            if (decimal.TryParse(text.Substring(1).Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
            {
                return value;
            }

            return base.ConvertFromString(text, row, memberMapData);
        }
    }
}
