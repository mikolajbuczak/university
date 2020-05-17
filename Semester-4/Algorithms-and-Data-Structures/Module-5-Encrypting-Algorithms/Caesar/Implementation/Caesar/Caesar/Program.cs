namespace Caesar
{
    using System;
    class Program
    {
        static void Main()
        {
            string text = "ab cdz";
            string encoded = Caesar.Encode(text, 2);
            string decoded = Caesar.Decode(encoded, 2);
            Console.WriteLine(encoded);
            Console.WriteLine(decoded);
            Console.ReadKey();
        }
    }
}
