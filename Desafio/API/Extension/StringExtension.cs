using System.Linq;

namespace API.Extension
{
    public static class StringExtension
    {
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

        public static string UpperFirst(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            return $"{text.ToUpper().FirstOrDefault()}";
        }
    }
}
