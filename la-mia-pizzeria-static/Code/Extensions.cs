namespace la_mia_pizzeria_static.Code
{
    public static class Extensions
    {
        public static string SafeSubstring(this string input, int length, bool includeEllipsis = true)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            string ellipsis = "";
            if (includeEllipsis && input.Length > length)
                ellipsis = "...";
            length = input.Length;
            return input.Substring(0, length) + ellipsis;
        }
    }
}
