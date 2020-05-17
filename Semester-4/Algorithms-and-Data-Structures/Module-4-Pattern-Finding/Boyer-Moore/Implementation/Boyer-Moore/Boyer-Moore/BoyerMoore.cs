namespace Boyer_Moore
{
    using System;
    static class BoyerMoore
    {
        public static int Find(string text, string match)
        {
            int[] badChar = new int[256];

            CreateBadCharTable(match, ref badChar);

            int s = 0;
            while (s <= (text.Length - match.Length))
            {
                int j = match.Length - 1;

                while (j >= 0 && match[j] == text[s + j])
                    --j;

                if (j < 0) return s;

                s += match.Length - Math.Min(j, 1 + badChar[text[s + j]]);
            }

            return -1;
        }

        private static void CreateBadCharTable(string match, ref int[] badChar)
        {
            for (int i = 0; i < 256; i++)
                badChar[i] = -1;

            for (int i = 0; i < match.Length; i++)
                badChar[(int)match[i]] = i;
        }
    }
}
