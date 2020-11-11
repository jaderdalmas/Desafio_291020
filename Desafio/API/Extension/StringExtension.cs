using System.Linq;

namespace API.Extension
{
    /// <summary>
    /// String Extension
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Convert phone into E164 format
        /// </summary>
        /// <param name="phone">phone number</param>
        /// <returns>phone in E164 format</returns>
        public static string E164(this string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return string.Empty;

            var result = phone.Where(x => char.IsDigit(x)).ToArray();

            if (result.Any())
                return $"+55{new string(result)}";
            else
                return string.Empty;
        }

        /// <summary>
        /// Upper first word of a text
        /// </summary>
        /// <param name="text">text</param>
        /// <returns>upper first word if the text</returns>
        public static string UpperFirst(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            return $"{text.ToUpper().FirstOrDefault()}";
        }
    }
}
