using System.Collections.Generic;

namespace WeatherForecast
{
    public class Layer
    {
        public List<Neuron> Neurony;

        public Layer()
        {
            Neurony = new List<Neuron>();
        }

        public Layer StworzWarstwe(int ilosc)
        {
            var warstwa = new Layer();
            for (var i = 0; i < ilosc; i++)
            {
                var neuron = new Neuron();
                warstwa.Neurony.Add(neuron);
            }
            return warstwa;
        }
    }
}
