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
            {
                ellipsis = "...";
                length -= ellipsis.Length;
            }

            if (length < 0) // Se la lunghezza è troppo piccola per includere i puntini
                length = 0;

            return input.Substring(0, Math.Min(length, input.Length)) + ellipsis;
        }
    }
}
