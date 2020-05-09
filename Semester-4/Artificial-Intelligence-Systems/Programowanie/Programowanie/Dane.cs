namespace Programowanie
{
    class Dane
    {
        public static System.Collections.Generic.List<double> POBIERZ(string filePath)
        {
            System.Collections.Generic.List<double> numbers = new System.Collections.Generic.List<double>();

            double n;

            string[] allLines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in allLines)
                if (System.Double.TryParse(line, out n))
                    numbers.Add(n);

            return numbers;
        }

        public static void TASUJ(ref System.Collections.Generic.List<double> numbers)
        {
            if (numbers.Count == 0) return;
            System.Random random = new System.Random();
            for (int i = 0; i < numbers.Count; i++)
            {
                int b = random.Next(i, numbers.Count);
                double temp = numbers[i];
                numbers[i] = numbers[b];
                numbers[b] = temp;
            }
        }

        public static void MINMAX(ref System.Collections.Generic.List<double> numbers)
        {
            if (numbers.Count < 2)
            {
                System.Windows.MessageBox.Show("Za mało danych,a by wykonać polecenie!", "Za mało danych");
                return;
            }
            double min = numbers[0];
            double max = numbers[0];
            double nmin = 0;
            double nmax = 1;
            foreach (double number in numbers)
            {
                if (number < min)
                    min = number;
                if (number > max)
                    max = number;
            }

            for (int i = 0; i < numbers.Count; i++)
                numbers[i] = System.Math.Round((double)(((numbers[i] - min) / (max - min))) * (nmax - nmin) + nmin, 10);
        }

        public static void MEAN(ref System.Collections.Generic.List<double> numbers)
        {
            if (numbers.Count < 2)
            {
                System.Windows.MessageBox.Show("Za mało danych,a by wykonać polecenie!", "Za mało danych");
                return;
            }
            double min = numbers[0];
            double max = numbers[0];
            double average = 0;

            foreach(double number in numbers)
            {
                if (number < min)
                    min = number;
                if (number > max)
                    max = number;
                average += number;
            }

            average /= numbers.Count;

            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = (double)((numbers[i] - average) / (max - min));
            }
        }

        public static void STANDARD(ref System.Collections.Generic.List<double> numbers)
        {
            if (numbers.Count < 2)
            {
                System.Windows.MessageBox.Show("Za mało danych,a by wykonać polecenie!", "Za mało danych");
                return;
            }
            double average = 0;

            foreach (double number in numbers)
                average += number;

            average /= numbers.Count;
            double suma = 0;

            foreach (double number in numbers)
                suma += (number - average) * (number - average);

            double sd = System.Math.Sqrt(suma / numbers.Count);

            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = (double)(((numbers[i] - average) / sd));
            }

        }
    }
}
