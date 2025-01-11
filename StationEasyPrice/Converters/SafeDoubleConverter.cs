using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace StationEasyPrice.Converters
{
    public class SafeDoubleConverter : DoubleConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            // Check if the value is empty or null
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0.0;  // Return default value (0) for empty fields
            }

            // Try to parse the double value, return 0 if invalid
            if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                return result;  // Return parsed value
            }

            // Log or handle invalid data if necessary
            Console.WriteLine($"Invalid double value '{text}' encountered. Defaulting to 0.");

            return 0.0;  // Default to 0 if the value is not a valid double
        }
    }
}
