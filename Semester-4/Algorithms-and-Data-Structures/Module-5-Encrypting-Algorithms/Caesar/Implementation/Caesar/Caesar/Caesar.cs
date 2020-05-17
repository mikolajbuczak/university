namespace Caesar
{
    static class Caesar
    {
        static int alphabetLength = 26;
        public static string Encode(string text, int shift)
        {
            shift %= alphabetLength;

            char[] result = new char[text.Length];

            for(int i = 0; i < text.Length; i++)
            {
                if (!char.IsLetter(text[i])) continue;
                char firstLetterofAlphabet = char.IsUpper(text[i]) ? 'A' : 'a';
                result[i] =  (char)((((text[i] + shift) - firstLetterofAlphabet) % 26) + firstLetterofAlphabet);
            }

            return new string(result);
        }

        public static string Decode(string text, int shift)
        {
            return Encode(text, alphabetLength - shift);
        }
    }
}
