namespace Shannon_Fano
{
    using System.Collections.Generic;
    using System.Linq;
    static class ShannonFano
    {
        static List<Word> words = null;

        public static string Encode(string text)
        {
            string[] splittedText = text.Split(' ');

            words = new List<Word>();
            foreach (string singleWord in splittedText)
            {
                Word currentWord = words.Find(word => word.value == singleWord);
                if (currentWord == null)
                {
                    words.Add(new Word() { value = singleWord, probability = 1 });
                    continue;
                }
                currentWord.probability += 1;
            }

            foreach (Word word in words)
                word.probability /= splittedText.Length;

            words = words.OrderBy(x => -x.probability).ToList();

            Split(ref words, words);

            string code = "";
            for (int i = 0; i < splittedText.Length; i++)
                code += words.Find(x => x.value == splittedText[i]).code;

            return code;
        }

        public static string Decode(string code)
        {
            int length = 1;
            string result = string.Empty;
            for (int i = 0; i < code.Length;)
            {
                while (true)
                {
                    Word w = words.Find(x => x.code == new string(code.Skip(i).Take(length).ToArray()));
                    if (w != null)
                    {
                        result += $"{w.value} ";
                        i += length;
                        length = 1;
                        break;
                    }
                    length++;
                }
            }
            return result;
        }

        static void Split(ref List<Word> words, List<Word> workWords)
        {
            if (workWords.Count < 2) return;

            var left = new List<Word>();
            var right = new List<Word>();
            left.Add(workWords[0]);
            words[words.IndexOf(workWords[0])].code += "0";
            right.Add(workWords[1]);
            words[words.IndexOf(workWords[1])].code += "1";
            if (workWords.Count == 2) return;

            for (int i = 2; i < workWords.Count; i++)
            {
                double leftSum = left.Sum(x => x.probability);
                double rightSum = right.Sum(x => x.probability);
                if (leftSum <= rightSum)
                {
                    left.Add(workWords[i]);
                    words[words.IndexOf(workWords[i])].code += "0";
                    continue;
                }
                right.Add(workWords[i]);
                words[words.IndexOf(workWords[i])].code += "1";
            }
            Split(ref words, left);
            Split(ref words, right);
        }

        public class Word
        {
            public string value = null;
            public double probability;

            public string code = string.Empty;
        }
    }
}
