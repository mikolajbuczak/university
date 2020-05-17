namespace Naive
{
    static class Naive
    {
        public static int Find(string text, string match)
        {
            for(int i = 0; i < text.Length - match.Length; i++)
            {
                for(int j = 0; j < match.Length; j++)
                {
                    if (text[i + j] != match[j]) break;
                    if (j == match.Length - 1) return i;
                }
            }
            return -1;
        }
    }
}
