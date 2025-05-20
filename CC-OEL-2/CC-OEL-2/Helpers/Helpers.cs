using System.Text.RegularExpressions;

namespace SensitiveDataDetection.Helpers
{
    public static class PatternHelper
    {
        public static bool IsMatch(string pattern, string value)
        {
            return Regex.IsMatch(value, pattern);
        }
    }
}

