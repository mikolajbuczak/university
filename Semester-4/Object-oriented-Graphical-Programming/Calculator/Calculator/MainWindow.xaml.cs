namespace Calculator
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Globalization;
    using System.Windows.Input;

    public partial class MainWindow : Window
    {
        private const string defaultEntry = "";
        private const string defaultHistory = "";
        private const string defaultLastEntry = "";
        private const string defaultOperation = "";

        string entry;
        string history;
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
            history = defaultHistory;
            operation = defaultOperation;
            hasSeparator = false;
            toReset = false;

            TextCompositionManager.AddTextInputHandler(this, new TextCompositionEventHandler(OnTextComposition));

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
            AddDigit(button.Content.ToString());
            Equals_btn.Focus();
        }

        private void DecimalSeparator_Click(object sender, RoutedEventArgs e)
        {
            AddSeparator(DecimalSeparator.Content.ToString());
            Equals_btn.Focus();
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            Backspace();
            Equals_btn.Focus();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            Equals_btn.Focus();
        }

        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            ClearEntry();
            Equals_btn.Focus();
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            Operatation(button.Content.ToString());

            Equals_btn.Focus();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            Equals();
            Equals_btn.Focus();
        }

        private void Negate_Click(object sender, RoutedEventArgs e)
        {
            Negate();
            Equals_btn.Focus();
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
            History_l.Content = history;
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
            history = defaultHistory;
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
            history = defaultHistory;
            operation = defaultOperation;
            hasSeparator = false;
            toReset = false;

            UpdateEntry();
            UpdateHistory();
        }

        private void Error(string message)
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

        private void AddDigit(string digit)
        {
            if (toReset) Reset();

            if (entry == "0") entry = defaultEntry;
            if (entry.Length < 12) entry += digit;
            UpdateEntry();
        }

        private void AddSeparator(string separator)
        {
            if (toReset) Reset();
            if (hasSeparator) return;
            if (entry == defaultEntry) entry = "0";
            entry += DecimalSeparator.Content.ToString();
            hasSeparator = true;
            UpdateEntry();
        }

        private void Backspace()
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

        private void Operatation(string op)
        {
            if (toReset) SaveResult();

            if((entry == defaultEntry || entry == "0") && lastEntry == defaultLastEntry) return;

            Double.TryParse(entry, out double val);
            if (val == 0) entry = "0";
            if(entry == defaultEntry)
            {
                operation = op;
                history = history.Substring(0, history.Length - 2);
                history += $"{operation} ";
                UpdateHistory();
                return;
            }

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
                if (!Double.TryParse(result, out _))
                {
                    Error(result);
                    return;
                }
                lastEntry = entry;
                entry = result;
            }

            operation = op;
            history += $"{lastEntry} {operation} ";
            lastEntry = entry;

            UpdateEntry();
            UpdateHistory();
            entry = defaultEntry;
            hasSeparator = false;
        }

        private void Equals()
        {
            if (toReset) SaveResult();

            if (entry.EndsWith(DecimalSeparator.Content.ToString()))
            {
                entry = entry.Substring(0, entry.Length - 1);
                hasSeparator = false;
            }

            if (entry == defaultEntry) entry = lastEntry;

            history += $"{entry} = ";

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

        private void Negate()
        {
            if (toReset) SaveResult();
            if ((entry == defaultEntry || entry == "0") && lastEntry == defaultLastEntry) return;
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

        private void ClearEntry()
        {
            if (toReset) Reset();
            entry = defaultEntry;

            hasSeparator = false;

            UpdateEntry();
        }

        private void OnTextComposition(object sender, TextCompositionEventArgs e)
        {
            string text = e.Text;
            if (int.TryParse(text, out _)) AddDigit(text);
            else if (text == "\b") Backspace();
            else if (text == "\u001b") Reset();
            if (!Add_btn.IsEnabled) return;
            if (text == DecimalSeparator.Content.ToString()) AddSeparator(text);
            else if (text == "/") Operatation("\u00F7");
            else if (text == "*") Operatation("\u00D7");
            else if (text == "-" || text == "+") Operatation(text);
            else if (text == "=" || text == "\r") Equals();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    ClearEntry();
                    break;
                case Key.F9:
                    if (!Add_btn.IsEnabled) return;
                    Negate();
                    break;
            }
        }
    }
}
