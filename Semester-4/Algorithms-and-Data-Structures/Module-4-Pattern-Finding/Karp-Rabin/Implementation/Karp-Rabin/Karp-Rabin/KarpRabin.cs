namespace Karp_Rabin
{
    static class KarpRabin
    {
        static int alphabetLength = 256;
        static int primeNumber = 17573;
        public static int Find(string text, string match)
        {
            int textHash = 0;
            int matchHash = Hash(match);

            for (int i = 0; i < text.Length - match.Length + 1; i++)
            {
                textHash = Hash(text.Substring(i, match.Length));
                if (textHash != matchHash) continue;
                return i;
            }

            return -1;
        }

        static int Hash(string word)
        {
            int result = 0;
            for (int i = 0; i < word.Length; i++)
                result = (alphabetLength * result + word[i]) % primeNumber;

            return result;
        }
    }
}
