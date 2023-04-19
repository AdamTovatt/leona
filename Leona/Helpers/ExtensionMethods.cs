using System.Globalization;

namespace Leona.Helpers
{
    public static class ExtensionMethods
    {
        private static readonly char[] hexValues = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' }; // all possible alphabetical hex values

        public static string ToFormattedString(this double value)
        {
            return value.ToString("0.0000", CultureInfo.InvariantCulture);
        }

        public static bool GetIsHexadecimal(this char value)
        {
            return char.IsDigit(value) || hexValues.Contains(char.ToUpper(value));
        }
    }
}
