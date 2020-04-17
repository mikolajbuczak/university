namespace Max_Number
{
    class Program
    {
        static void Main()
        {
            string filePath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "data.txt");

            if (!System.IO.File.Exists(filePath))
                CloseProgram(-1, "File doesn't exist!");

            string[] data = System.IO.File.ReadAllLines(filePath);

            if (data.Length < 1)
                CloseProgram(-2, "No data to work with.");

            double[] dataAsDouble = ConvertDataToDouble(data);

            if (dataAsDouble.Length < 1)
                CloseProgram(-3, "No valid data to work with.");

            System.Console.WriteLine($"The largest number in given set is {FindLargestNumber(dataAsDouble)}.");

            CloseProgram(0, null);
        }

        private static double[] ConvertDataToDouble(string[] data)
        {
            var dataAsDouble = new System.Collections.Generic.List<double>();
            foreach (string singleData in data)
                if (System.Double.TryParse(singleData, out double singleDataAsDouble))
                    dataAsDouble.Add(singleDataAsDouble);
            return dataAsDouble.ToArray();
        }

        private static double FindLargestNumber(double[] data)
        {
            double maximum = data[0];

            foreach (double singleData in data)
                if (singleData > maximum)
                    maximum = singleData;

            return maximum;
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
