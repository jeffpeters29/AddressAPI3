using System.Linq;
using System.Text.RegularExpressions;

namespace AddressAPI3.Application.Helpers
{
    public static class StringExtensions
    {
        public static string RemoveWhiteSpace(this string self)
        {
            return new string(self.Trim().Where(c => !char.IsWhiteSpace(c)).ToArray());

            //return Regex.Replace(self.Trim(), @"\s", "");
        }

        public static bool IsStartsTwoChars(this string self)
        {
            return Regex.IsMatch(self, @"/[A-Za-z]{2}[0-9]+");
        }
    }
}
