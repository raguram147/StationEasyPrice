using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace StationEasyPrice.Converters
{
    public class SafeDecimalConverter : DecimalConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            // Check if the value is empty or null
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0.0m;  // Return default value (0) for empty fields
            }

            // Try to parse the decimal value, return 0 if invalid
            if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;  // Return parsed value
            }

            // Log or handle invalid data if necessary
            Console.WriteLine($"Invalid decimal value '{text}' encountered. Defaulting to 0.");

            return 0.0m;  // Default to 0 if the value is not a valid decimal
        }
    }

}
