namespace Huffman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    static class Huffman
    {
        static List<Word> words = null;
        public static string Encode(string text)
        {
            string[] splittedText = text.Split(' ');

            words = new List<Word>();
            foreach(string singleWord in splittedText)
            {
                Word currentWord = words.Find(word => word.value == singleWord);
                if (currentWord == null)
                {
                    words.Add(new Word() { value = singleWord, probability = 1 });
                    continue;
                }
                currentWord.probability += 1;
            }

            foreach(Word word in words)
                word.probability /= splittedText.Length;

            CreateTree(ref words);

            string code = "";
            for (int i = 0; i < splittedText.Length; i++)
            {
                code += words.Find(x => x.value == splittedText[i]).code;
            }

            return code;
        }

        public static string Decode(string code)
        {
            int length = 1;
            string result = "";
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

        private static void CreateTree(ref List<Word> _words)
        {
            Node root = new Node() { words = new List<Word>(_words) };
            Node currentNode = root;
            string currentCode = string.Empty;
            while (currentNode.words.Count > 1)
            {
                Word highProb = currentNode.words[0];

                for (int i = 0; i < currentNode.words.Count; i++)
                {
                    if (currentNode.words[i].probability > highProb.probability)
                        highProb = currentNode.words[i];
                }
                highProb.code = currentCode + "1";
                _words.Find(x => x == highProb).code = highProb.code;
                currentCode += "0";
                currentNode.right = new Node() { words = new List<Word>() };
                currentNode.right.words.Add(highProb);
                currentNode.words.Remove(highProb);
                currentNode.left = new Node() { words = new List<Word>() };
                currentNode.left.words = currentNode.words;


                currentNode = currentNode.left;

            }
            currentNode.words[0].code = currentCode;
            _words.Find(x => x == currentNode.words[0]).code = currentCode;
        }

        private class Word
        {
            public string value = null;
            public double probability;

            public string code = string.Empty;
        }

        private class Node
        {
            public Node left = null;
            public Node right = null;

            public List<Word> words;
        }
    }
}
