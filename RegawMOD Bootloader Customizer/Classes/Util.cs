namespace RegawMOD
{
    public static class ExtensionMethods
    {
        public static bool ContainsIgnoreCase(this string s, string str)
        {
            return s.ToLower().Contains(str.ToLower());
        }

        public static string ProperCase(this string s)
        {
            string final = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0 && char.IsLetter(s[i]))
                {
                    final += char.ToUpper(s[i]);
                    continue;
                }

                if (char.IsWhiteSpace(s[i - 1]) || char.IsControl(s[i - 1]) && char.IsLetter(s[i]))
                    final += char.ToUpper(s[i]);
                else
                    final += char.ToLower(s[i]);
            }

            return final;
        }

        public static string PadCenter(this string s, int width, char c)
        {
            if (s == null || width <= s.Length) return s;

            int padding = width - s.Length;
            return s.PadLeft((padding / 2) + s.Length, c).PadRight(width, c);
        }
    }
}