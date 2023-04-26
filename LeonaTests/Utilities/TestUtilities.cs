using System.Reflection;

namespace LeonaTests.Utilities
{
    public static class TestUtilities
    {
        public static string? ReadTestFile(string filename)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(filename));

                using (Stream stream = assembly.GetManifestResourceStream(resourceName)!)
                using (StreamReader reader = new StreamReader(stream!))
                {
                    return reader.ReadToEnd();
                }
            }
            catch
            {
                return null;
            }
        }

        public static string RemoveControlCharacters(this string input)
        {
            return new string(input.Where(c => !char.IsControl(c) && c != ' ').ToArray());
        }
    }
}
