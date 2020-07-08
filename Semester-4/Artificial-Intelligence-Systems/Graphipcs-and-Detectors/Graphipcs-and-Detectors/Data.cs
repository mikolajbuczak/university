namespace Graphipcs_and_Detectors
{
    class Data
    {
        public string Outlook { get; private set; }
        public string Temperature { get; private set; }
        public string Humidity { get; private set; }
        public bool Windy { get; private set; }
        public bool PlayGolf { get; set; }

        public Data(string outlook, string temperature, string humidity, bool windy, bool playGolf)
        {
            Outlook = outlook;
            Temperature = temperature;
            Humidity = humidity;
            Windy = windy;
            PlayGolf = playGolf;
        }
    }
}
