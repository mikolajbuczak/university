namespace Polish_Postfix_Notation
{
    class Program
    {
        static void Main()
        {
            string filePath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "data.txt");

            if (!CheckIfFileExists(filePath))
                CloseProgram(-1, "File doesn't exist!");

            string[] data = LoadData(filePath);

            if (data.Length < 1)
                CloseProgram(-2, "No data to work with.");

            ConvertData(data);

            CloseProgram(0, null);
        }

        private static bool CheckIfFileExists(string filePath)
        {
            return System.IO.File.Exists(filePath);
        }

        private static string[] LoadData(string filePath)
        {
            return System.IO.File.ReadAllLines(filePath);
        }

        private static void ConvertData(string[] data)
        {
            foreach (string singleData in data)
            {
                System.Console.WriteLine($"What activity do you want to perform for equation: {singleData} ?");
                System.Console.WriteLine("[1] Convert  TO  Polish Postfix Notation");
                System.Console.WriteLine("[2] Convert FROM Polish Postfix Notation");
                System.Console.WriteLine();
                System.Console.Write("Your choice: ");
                System.ConsoleKeyInfo input = System.Console.ReadKey();
                System.Console.WriteLine();
                System.Console.WriteLine();

                switch (input.Key)
                {
                    case System.ConsoleKey.D1:
                    case System.ConsoleKey.NumPad1:
                        System.Console.WriteLine($"{singleData} = {ConvertToPPN(singleData)}");
                        break;
                    case System.ConsoleKey.D2:
                    case System.ConsoleKey.NumPad2:
                        System.Console.WriteLine($"{singleData} = {ConvertFromPPN(singleData)}");
                        break;
                    default:
                        System.Console.WriteLine("Invalid choice.");
                        break;
                }

                System.Console.WriteLine();
            }
        }

        private static string ConvertToPPN(string equation)
        {
            var stack = new System.Collections.Generic.Stack<char>();
            var stringBuilder = new System.Text.StringBuilder();
            foreach (char element in equation)
            {
                switch (element)
                {
                    case '(':
                        stack.Push(element);
                        break;
                    case ')':
                        while (stack.Peek() != '(')
                            stringBuilder.Append(stack.Pop());
                        stack.Pop();
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '%':
                    case '^':
                        while (stack.Count != 0 && GetPriority(element) <= GetPriority(stack.Peek()))
                            stringBuilder.Append(stack.Pop());
                        stack.Push(element);
                        break;
                    default:
                        stringBuilder.Append(element);
                        break;
                }
            }
            while (stack.Count != 0)
                stringBuilder.Append(stack.Pop());
            return stringBuilder.ToString();
        }

        private static string ConvertFromPPN(string equation)
        {
            var stack = new System.Collections.Generic.Stack<string>();

            foreach (char element in equation)
            {
                switch (element)
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '%':
                    case '^':
                        string prev = stack.Pop();
                        stack.Push($"({stack.Pop()}{element}{prev})");
                        break;
                    default:
                        stack.Push(element.ToString());
                        break;
                }
            }
            return stack.Pop();
        }

        private static int GetPriority(char function)
        {
            switch (function)
            {
                case '(':
                    return 0;
                case '+':
                case '-':
                case ')':
                    return 1;
                case '*':
                case '/':
                case '%':
                    return 2;
                case '^':
                    return 3;
                default:
                    throw new System.Exception("Invalid function.");
            }
        }

        private static void CloseProgram(int code, string message)
        {
            if (message != null) System.Console.WriteLine(message);
            System.Console.WriteLine();

            System.Console.WriteLine($"Application closed with code {code}.");

            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();

            System.Environment.Exit(code);
        }
    }
}
