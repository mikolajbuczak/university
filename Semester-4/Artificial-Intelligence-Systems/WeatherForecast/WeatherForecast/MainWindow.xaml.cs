namespace WeatherForecast
{
    using System.Windows;
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;
    using System.Globalization;
    using System.Net;
    using System.Data;
    using System.Windows.Media;

    public partial class MainWindow : Window
    {
        public string file = @"Data.csv";

        public double minTemp;
        public double maxTemp;
        public double minP;
        public double maxP;
        public double minWind;
        public double maxWind;
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

            variablesList.Clear();

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
        }

        private void Start_button_Click(object sender, RoutedEventArgs e)
        {
            NormalizeData();

            Start_button.IsEnabled = false;

            Temperature_tb.Visibility = Visibility.Visible;
            Pressure_tb.Visibility = Visibility.Visible;
            Humidity_tb.Visibility = Visibility.Visible;
            Wind_tb.Visibility = Visibility.Visible;
            Cloud_tb.Visibility = Visibility.Visible;

            double[] inputs = new double[25];
            double[] result = null;

            if (Date_pick.SelectedDate != null)
            {
                DateTime selectedDate = (DateTime)Date_pick.SelectedDate;
                bool pickedDateinList = datesList.Contains(selectedDate);
                if (!pickedDateinList)
                {
                    for (DateTime i = datesList[0].AddDays(1); i <= selectedDate; i = i.AddDays(1))
                    {
                        int index = 0;

                        variablesList[index].CopyTo(inputs, 0);
                        variablesList[index + 1].CopyTo(inputs, variablesList[index].Length);
                        variablesList[index + 2].CopyTo(inputs, variablesList[index].Length + variablesList[index + 1].Length);
                        variablesList[index + 3].CopyTo(inputs, variablesList[index].Length + variablesList[index + 2].Length + variablesList[index + 3].Length);
                        variablesList[index + 4].CopyTo(inputs, variablesList[index].Length + variablesList[index + 2].Length + variablesList[index + 3].Length + variablesList[index + 4].Length);

                        result = neuralNetwork.Oblicz(inputs);

                        for (int j = 0; j < result.Length; j++)
                            result[j] = Math.Round(result[j], 2);

                        variablesList.Insert(0, result);
                        datesList.Insert(0, i);
                    }
                }
                else
                {
                    int index = datesList.FindIndex(date => date == selectedDate);

                    variablesList[index + 1].CopyTo(inputs, 0);
                    variablesList[index + 2].CopyTo(inputs, variablesList[index].Length);
                    variablesList[index + 3].CopyTo(inputs, variablesList[index].Length + variablesList[index + 1].Length);
                    variablesList[index + 4].CopyTo(inputs, variablesList[index].Length + variablesList[index + 2].Length + variablesList[index + 3].Length);
                    variablesList[index + 5].CopyTo(inputs, variablesList[index].Length + variablesList[index + 2].Length + variablesList[index + 3].Length + variablesList[index + 4].Length);                

                    result = neuralNetwork.Oblicz(inputs);

                    for (int j = 0; j < result.Length; j++)
                        result[j] = Math.Round(result[j], 2);
                }
            }
            else
            {
                int index = 0;

                variablesList[index].CopyTo(inputs, 0);
                variablesList[index + 1].CopyTo(inputs, variablesList[index].Length);
                variablesList[index + 2].CopyTo(inputs, variablesList[index].Length + variablesList[index + 1].Length);
                variablesList[index + 3].CopyTo(inputs, variablesList[index].Length + variablesList[index + 2].Length + variablesList[index + 3].Length);
                variablesList[index + 4].CopyTo(inputs, variablesList[index].Length + variablesList[index + 2].Length + variablesList[index + 3].Length + variablesList[index + 4].Length);
                
                result = neuralNetwork.Oblicz(inputs);

                for (int j = 0; j < result.Length; j++)
                    result[j] = Math.Round(result[j], 2);
            }

            double temperature = Math.Round(result[0] * (maxTemp - minTemp) + minTemp);
            double pressure = Math.Round(result[1] * (maxP - minP) + minP);
            double humidity = Math.Round(result[2] * 100);
            double wind = Math.Round(result[3] * (maxWind - minWind) + minWind);
            double cloud = Math.Round(result[4] * 100);

            Temperature_run.Text = temperature.ToString();
            Pressure_run.Text = pressure.ToString();
            Humidity_run.Text = humidity.ToString();
            Wind_run.Text = wind.ToString();
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

            for (var dt = start; dt <= end; dt = dt.AddDays(1))
                datesList.Add(dt);

            datesList.Reverse();

            Date_pick.DisplayDateStart = datesList.Last();
            Date_pick.DisplayDateEnd = datesList[0].AddDays(4);

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
        }

        private long ConvertToUnixTime(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (long)(datetime - sTime).TotalSeconds;
        }

        private void GetDataFromApi()
        {
            Date_pick.SelectedDate = null;

            List<double> temperature = new List<double>();
            List<double> pressure = new List<double>();
            List<double> humidity = new List<double>();
            List<double> wind = new List<double>();
            List<double> cloudCover = new List<double>();

            for (DateTime i = DateTime.UtcNow.AddDays(-4); i <= DateTime.UtcNow; i = i.AddDays(1))
            {
                double[] dayVariables = new double[5];

                string url = "here goes your API key"
                long temp = ConvertToUnixTime(i);
                url = url.Replace("@unixDate@", temp.ToString());
                HttpWebRequest apiRequest = WebRequest.Create(url) as HttpWebRequest;

                string apiResponse = "";
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                }

                string[] ApiData = apiResponse.Split(new char[] { ',' });

                string file = "ApiData - " + i.ToString("dd.MM.yyyy") + ".txt";

                foreach (var data in ApiData)
                {
                    var line = data;


                    if (data.Contains("\"temp\":"))
                    {
                        line = data.Replace("\"temp\":", string.Empty);
                        double.TryParse(line, out double value);
                        temperature.Add(value);
                    }
                    else if (data.Contains("\"pressure\":"))
                    {
                        line = data.Replace("\"pressure\":", string.Empty);
                        double.TryParse(line, out double value);
                        pressure.Add(value);
                    }
                    else if (data.Contains("\"humidity\":"))
                    {
                        line =data.Replace("\"humidity\":", string.Empty);
                        double.TryParse(line, out double value);
                        humidity.Add(value);
                    }
                    else if (data.Contains("\"clouds\":"))
                    {
                        line = data.Replace("\"clouds\":", string.Empty);
                        double.TryParse(line, out double value);
                        cloudCover.Add(value);
                    }
                    else if (data.Contains("\"wind_speed\":"))
                    {
                        line = data.Replace("\"wind_speed\":", string.Empty);
                        double.TryParse(line, out double value);
                        wind.Add(value * 3.6);
                    }

                }

                dayVariables[0] = Math.Round(temperature.Average(), 0);
                dayVariables[1] = Math.Round(pressure.Average(), 0);
                dayVariables[2] = Math.Round(humidity.Average() / 100, 2);
                dayVariables[3] = Math.Round(wind.Average(), 0);
                dayVariables[4] = Math.Round(cloudCover.Average() / 100, 2);

                variablesList.Insert(0, dayVariables);

                temperature.Clear();
                pressure.Clear();
                humidity.Clear();
                wind.Clear();
                cloudCover.Clear();
            }
        }

        private void Api_button_Click(object sender, RoutedEventArgs e)
        {
            GetDataFromApi();

            Date_pick.SelectedDate = null;
            Api_button.IsEnabled = false;
            Date_pick.SelectedDate = null;

            Date_pick.IsEnabled = false;
            Reverse_button.Visibility = Visibility.Visible;
            Reverse_button.IsEnabled = true;
            Start_button.IsEnabled = true;
        }

        private void NormalizeData()
        {
            minTemp = variablesList[0][0];
            maxTemp = variablesList[0][0];
            minP = variablesList[0][1];
            maxP = variablesList[0][1];
            minWind = variablesList[0][3];
            maxWind = variablesList[0][3];
            for (int i = 1; i < variablesList.Count; i++)
            {
                if (minTemp > variablesList[i][0]) minTemp = variablesList[i][0];
                if (maxTemp < variablesList[i][0]) maxTemp = variablesList[i][0];
                if (minP > variablesList[i][1]) minP = variablesList[i][1];
                if (maxP < variablesList[i][1]) maxP = variablesList[i][1];
                if (minWind > variablesList[i][3]) minWind = variablesList[i][3];
                if (maxWind < variablesList[i][3]) maxWind = variablesList[i][3];
            }

            for (int i = 0; i < variablesList.Count; i++)
            {
                variablesList[i][0] = Math.Round((variablesList[i][0] - minTemp) / (maxTemp - minTemp), 2);
                variablesList[i][1] = Math.Round((variablesList[i][1] - minP) / (maxP - minP), 2);
                variablesList[i][3] = Math.Round((variablesList[i][3] - minWind) / (maxWind - minWind), 2);
            }
        }
        private void Reverse_button_Click(object sender, RoutedEventArgs e)
        {
            Date_pick.IsEnabled = true;
            Reverse_button.Visibility = Visibility.Hidden;
            Reverse_button.IsEnabled = false;
            Start_button.IsEnabled = false;
            Api_button.IsEnabled = true;

            variablesList.Clear();

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
        }

    }
}
