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
        public double minTemp;
        public double maxTemp;
        public double minP;
        public double maxP;
        public int maxIndex;
        List<double[]> variablesList = new List<double[]>();
        List<DateTime> datesList = new List<DateTime>();

        Network neuralNetwork;

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

            //Calculate index based on picked date
            DateTime selectedDate = (DateTime)Date_pick.SelectedDate;

            bool pickedDateinList = datesList.Contains(selectedDate);

            double[] result = null;

            if (!pickedDateinList)
            {
                //07.04.2016
                //04.04.2016, 05.04.2016, 06.04.2016
                for(DateTime i = datesList[0].AddDays(1); i <= selectedDate; i = i.AddDays(1))
                {
                    int index = 0;

                    double[] inputs = new double[35];

                    variablesList[index].CopyTo(inputs, 0);
                    variablesList[index + 1].CopyTo(inputs, variablesList[index].Length);
                    variablesList[index + 2].CopyTo(inputs, variablesList[index].Length + variablesList[index + 1].Length);
                    variablesList[index + 3].CopyTo(inputs, variablesList[index].Length + variablesList[index + 2].Length + variablesList[index + 3].Length);
                    variablesList[index + 4].CopyTo(inputs, variablesList[index].Length + variablesList[index + 2].Length + variablesList[index + 3].Length + variablesList[index + 4].Length);
                    variablesList[index + 5].CopyTo(inputs, variablesList[index].Length + variablesList[index + 2].Length + variablesList[index + 3].Length + variablesList[index + 4].Length + variablesList[index + 5].Length);
                    variablesList[index + 6].CopyTo(inputs, variablesList[index].Length + variablesList[index + 2].Length + variablesList[index + 3].Length + variablesList[index + 4].Length + variablesList[index + 5].Length + variablesList[index + 6].Length);

                    result = neuralNetwork.Oblicz(inputs);

                    for (int j = 0; j < result.Length; j++)
                        result[j] = Math.Round(result[j], 2);

                    variablesList.Insert(0, result);
                    datesList.Insert(0, i);

                    //For each date proccess 3 earlier days, neuralNetwork must save results to file then add each result for processing next day forecast
                    //neuralNetwork.Guess(data[index]);
                    //Save to Dane.csv, normalize again*, update variableList - variableList.Insert(0, outputData from network)
                }
            }
            else
            {
                int index = datesList.FindIndex(date => date == selectedDate);
                result = variablesList[index];
            }


            //TODO: get values from array

            double temperature = Math.Round(result[0] * (maxTemp - minTemp) + minTemp);
            double pressure = Math.Round(result[1] * (maxP - minP) + minP);
            double humidity = Math.Round(result[2] * 100);
            double rain = Math.Round(result[3] * 100);
            double cloud = Math.Round(result[4] * 100);


            //TODO: denormalise values

            Temperature_run.Text = temperature.ToString();
            Pressure_run.Text = pressure.ToString();
            Humidity_run.Text = humidity.ToString();
            Rain_run.Text = rain.ToString();
            Cloud_run.Text = cloud.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            neuralNetwork = Network.WczytajWagi(@"jsonW1.json", @"jsonW2.json", @"jsonW3.json", @"jsonB1.json", @"jsonB2.json", @"jsonB3.json");

            //DatePicker setup:
            string firstLine = File.ReadLines(file).Skip(1).Take(1).First();
            string lastLine = File.ReadLines(file).Last();

            firstLine = firstLine.Substring(0, 10);
            lastLine = lastLine.Substring(0, 10);

            DateTime start = DateTime.Parse(lastLine);
            DateTime end = DateTime.Parse(firstLine);
            Date_pick.DisplayDateStart = start;
            Date_pick.DisplayDateEnd = end.AddDays(4);

            for (var dt = start; dt <= end; dt = dt.AddDays(1))
                datesList.Add(dt);

            datesList.Reverse();

            //Loading data to variableList
            string[] allLines = File.ReadAllLines(file);
            allLines = allLines.Skip(1).ToArray();
            string[][] data = new string[allLines.Length][];
            for (int i = 0; i < allLines.Length; i++)
                data[i] = allLines[i].Split(',');

            maxIndex = data.Length - 1;
            for (int i = 0; i < allLines.Length; i++)
            {
                double[] doubleData = new double[data[i].Length - 1];
                for (int j = 1; j < data[i].Length; j++)
                {
                    double.TryParse(data[i][j], out double temp);
                    doubleData[j - 1] = temp;
                }
                variablesList.Add(doubleData);
            }

            //Normalize
            minTemp = variablesList[0][0];
            maxTemp = variablesList[0][0];
            minP = variablesList[0][1];
            maxP = variablesList[0][1];
            for (int i = 1; i < allLines.Length; i++)
            {
                if (minTemp > variablesList[i][0]) minTemp = variablesList[i][0];
                if (maxTemp < variablesList[i][0]) maxTemp = variablesList[i][0];
                if (minP > variablesList[i][1]) minP = variablesList[i][1];
                if (maxP < variablesList[i][1]) maxP = variablesList[i][1];
            }

            //Get Min/Max values
            for (int i = 0; i < allLines.Length; i++)
            {
                variablesList[i][0] = Math.Round((variablesList[i][0] - minTemp) / (maxTemp - minTemp), 2);
                variablesList[i][1] = Math.Round((variablesList[i][1] - minP) / (maxP - minP), 2);
            }
            //neuralNetwork = new Network(35, new int[] { 17, 8 }, 5);
            //Data dataClass = new Data();

            //var daneTreningowe = new List<ZbiorDanych>();
            //for (int i = 0; i < dataClass.trainingInputs.Count; i++)
            //{
            //    daneTreningowe.Add(new ZbiorDanych(dataClass.trainingInputs[i], dataClass.trainingTargets[i]));
            //}

            //neuralNetwork.Trenuj(daneTreningowe, 50);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Overwrtie data file
            //Keep old dates, overwrite only dates that are in the future
        }
    }
}
