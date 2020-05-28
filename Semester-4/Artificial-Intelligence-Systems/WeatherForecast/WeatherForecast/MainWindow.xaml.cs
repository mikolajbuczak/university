namespace WeatherForecast
{
    using System.Windows;
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;
    using System.Globalization;


    public partial class MainWindow : Window
    {
        public string file = @"Data.csv";
        public decimal minTemp;
        public decimal maxTemp;
        public decimal minP;
        public decimal maxP;
        public int maxIndex;
        List<decimal[]> variablesList = new List<decimal[]>();
        List<string> datesList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-Gb");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-Gb");
        }

        private void Date_pick_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Start_button.IsEnabled = true;
        }

        private void Start_button_Click(object sender, RoutedEventArgs e)
        {
            Temperature_tb.Visibility = Visibility.Visible;
            Pressure_tb.Visibility = Visibility.Visible;
            Humidity_tb.Visibility = Visibility.Visible;
            Rain_tb.Visibility = Visibility.Visible;
            Cloud_tb.Visibility = Visibility.Visible;

            //TODO: calculate index based on picked date
            DateTime selectedDate = (DateTime)Date_pick.SelectedDate;
            string temp = selectedDate.ToString("dd.MM.yyyy");

            bool pickedDateinList = datesList.Contains(temp);
            if(!pickedDateinList)
            {
                for(DateTime i = Convert.ToDateTime(datesList[0]).AddDays(1); i <= selectedDate; i = i.AddDays(1))
                {
                    //For each date proccess 7 earlier days, neuralNetwork must save results to file to add each result, to process next day forecast
                    //neuralNetwork.Guess(data[index]);
                    //Save to Dane.csv
                }
            }
            else
            {
                int index = datesList.FindIndex(date => date.Contains(temp));
                //Find indexes of 7 earlier days then put them into neuralNetwork to procces
                //neuralNetwork.Guess(data[index]);
            }


            //TODO: get values from array

            decimal temperature = 10;
            decimal pressure = 10;
            decimal humidity = 10;
            decimal rain = 10;
            decimal cloud = 10;


            //TODO: denormalise values

            Temperature_run.Text = temperature.ToString();
            Pressure_run.Text = pressure.ToString();
            Humidity_run.Text = humidity.ToString();
            Rain_run.Text = rain.ToString();
            Cloud_run.Text = cloud.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 
            //DatePicker setup:
            string firstLine = File.ReadLines(file).Skip(1).Take(1).First();
            string lastLine = File.ReadLines(file).Last();

            firstLine = firstLine.Substring(0, 10);
            lastLine = lastLine.Substring(0, 10);

            DateTime start = DateTime.Parse(lastLine).AddDays(7);
            DateTime end = DateTime.Parse(firstLine).AddDays(4);
            Date_pick.DisplayDateStart = start;
            Date_pick.DisplayDateEnd = end;

            for (var dt = start; dt <= end; dt = dt.AddDays(1))
            {
                datesList.Add(dt.ToString("dd.MM.yyyy"));
            }

            //Loading data:
            string[] allLines = File.ReadAllLines(file);
            allLines = allLines.Skip(1).ToArray();
            string[][] data = new string[allLines.Length][];
            for(int i = 0; i < allLines.Length; i++)
            {
                data[i] = allLines[i].Split(',');
            }
            maxIndex = data.Length - 1;
            for(int i = 0; i < allLines.Length; i++)
            {
                decimal[] decimalData = new decimal[data[i].Length - 1];
                for(int j = 1; j < data[i].Length; j++)
                {
                    double.TryParse(data[i][j], out double temp);
                    decimalData[j - 1] = (decimal)temp;
                }
                variablesList.Add(decimalData);
            }

            //Normalize
            minTemp = variablesList[0][0];
            maxTemp = variablesList[0][0];
            minP = variablesList[0][1];
            maxP = variablesList[0][1];
            for(int i = 1; i < allLines.Length; i++)
            {
                if (minTemp > variablesList[i][0]) minTemp = variablesList[i][0];
                if (maxTemp < variablesList[i][0]) maxTemp = variablesList[i][0];
                if (minP > variablesList[i][1]) minP = variablesList[i][1];
                if (maxP < variablesList[i][1]) maxP = variablesList[i][1];
            }
            for (int i = 0; i < allLines.Length; i++)
            {
                variablesList[i][0] = System.Math.Round((variablesList[i][0] - minTemp) / (maxTemp - minTemp), 2);
                variablesList[i][1] = System.Math.Round((variablesList[i][1] - minP) / (maxP - minP), 2);
            }


            //Get Min/Max values
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Overwrtie data file 
            //Keep old dates, overwrite only dates that are in the future
        }
    }
}
