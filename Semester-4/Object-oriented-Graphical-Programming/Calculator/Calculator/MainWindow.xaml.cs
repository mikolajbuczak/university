namespace Calculator
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Globalization;

    public partial class MainWindow : Window
    {
        private const string defaultEntry = "";
        private const string defaultHistory = "";
        private const string defaultLastEntry = "";
        private const string defaultOperation = "";

        string entry;
        string historyString;
        string lastEntry;
        string operation;
        bool hasSeparator;
        bool toReset;

        public MainWindow()
        {
            InitializeComponent();

            SetDecimalSeparator(DetectDecimalSeparator());

            entry = "0";
            lastEntry = defaultLastEntry;
            historyString = defaultHistory;
            operation = defaultOperation;
            hasSeparator = false;
            toReset = false;

            UpdateEntry();
            UpdateHistory();
        }

        private static string DetectDecimalSeparator()
        {
            NumberFormatInfo culture = new NumberFormatInfo();
            return culture.NumberDecimalSeparator;
        }

        private void SetDecimalSeparator(string separator)
        {
            DecimalSeparator.Content = separator;
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (toReset) Reset();

            if (entry == "0") entry = defaultEntry;
            if (entry.Length < 12) entry += button.Content.ToString();
            UpdateEntry();
        }

        private void DecimalSeparator_Click(object sender, RoutedEventArgs e)
        {
            if (hasSeparator) return;
            if (entry == defaultEntry) entry = "0";
            entry += DecimalSeparator.Content.ToString();
            hasSeparator = true;
            UpdateEntry();
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (toReset) Reset();
            if (entry.Length < 2)
            {
                entry = defaultEntry;
                UpdateEntry();
                return;
            }

            if (entry.EndsWith(DecimalSeparator.Content.ToString())) hasSeparator = false;

            entry = entry.Substring(0, entry.Length - 1);
            UpdateEntry();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            if (toReset) Reset();
            entry = defaultEntry;

            hasSeparator = false;

            UpdateEntry();
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (toReset) SaveResult();

            if (entry.EndsWith(DecimalSeparator.Content.ToString()))
            {
                entry = entry.Substring(0, entry.Length - 1);
                hasSeparator = false;
            }

            if (lastEntry == defaultLastEntry)
            {
                lastEntry = entry;
            }
            else
            {
                string result = Calculate();
                if (!Double.TryParse(result, out double _))
                {
                    Error(result);
                    return;
                }
                lastEntry = entry;
                entry = result;
            }

            operation = button.Content.ToString();
            historyString += $"{lastEntry} {operation} ";
            lastEntry = entry;

            UpdateEntry();
            UpdateHistory();
            entry = defaultEntry;
            hasSeparator = false;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (toReset) SaveResult();

            if (entry.EndsWith(DecimalSeparator.Content.ToString()))
            {
                entry = entry.Substring(0, entry.Length - 1);
                hasSeparator = false;
            }

            if (entry == defaultEntry) entry = lastEntry;

            historyString += $"{entry} = ";

            if (lastEntry != defaultLastEntry)
            {
                string result = Calculate();
                if (!Double.TryParse(result, out double _))
                {
                    Error(result);
                    return;
                }
                entry = result;
            }

            UpdateEntry();
            UpdateHistory();
            lastEntry = entry;
            entry = defaultEntry;
            toReset = true;
        }

        private void Negate_Click(object sender, RoutedEventArgs e)
        {
            if (toReset) SaveResult();
            if (entry == defaultEntry && lastEntry == defaultLastEntry) return;
            if (entry == defaultEntry && lastEntry != defaultLastEntry)
            {
                entry = lastEntry;
                lastEntry = defaultLastEntry;
            }

            if (entry.StartsWith("-"))
            {
                entry = entry.Substring(1);
                UpdateEntry();
                return;
            }
            entry = entry.Insert(0, "-");
            UpdateEntry();
        }

        private void UpdateEntry()
        {
            if(entry == defaultEntry)
            {
                Entry_l.Content = "0";
                return;
            }
            Entry_l.Content = entry;
        }

        private void UpdateHistory()
        {
            History_l.Content = historyString;
        }

        private string Calculate()
        {
            string result = String.Empty;
            if (operation == "+")
                result = (Double.Parse(lastEntry) + Double.Parse(entry)).ToString();
            else if (operation == "-")
                result = (Double.Parse(lastEntry) - Double.Parse(entry)).ToString();
            else if (operation == "\u00D7")
                result = (Double.Parse(lastEntry) * Double.Parse(entry)).ToString();
            else if (operation == "\u00F7")
            {
                double denominator = Double.Parse(entry);
                if (denominator == 0) return "Can't divide by 0";
                result = (Double.Parse(lastEntry) / denominator).ToString();
            }

            if (result.Contains("E") && result.Length > 13) return "Overflow";
            if (result.Length > 13) result = result.Substring(0, 13);
            return result;
        }

        private void Reset()
        {
            entry = defaultEntry;
            lastEntry = defaultLastEntry;
            historyString = defaultHistory;
            operation = defaultOperation;
            hasSeparator = false;
            toReset = false;

            Add_btn.IsEnabled = true;
            Substract_btn.IsEnabled = true;
            Multiply_btn.IsEnabled = true;
            Divide_btn.IsEnabled = true;
            Negate_btn.IsEnabled = true;
            DecimalSeparator.IsEnabled = true;
            Equals_btn.IsEnabled = true;

            UpdateEntry();
            UpdateHistory();
        }

        private void SaveResult()
        {
            entry = lastEntry;
            lastEntry = defaultLastEntry;
            historyString = defaultHistory;
            operation = defaultOperation;
            hasSeparator = false;
            toReset = false;

            UpdateEntry();
            UpdateHistory();
        }

        public void Error(string message)
        {
            entry = message;
            Entry_l.Content = entry;

            toReset = true;

            Add_btn.IsEnabled = false;
            Substract_btn.IsEnabled = false;
            Multiply_btn.IsEnabled = false;
            Divide_btn.IsEnabled = false;
            Negate_btn.IsEnabled = false;
            DecimalSeparator.IsEnabled = false;
            Equals_btn.IsEnabled = false;
        }
    }
}
