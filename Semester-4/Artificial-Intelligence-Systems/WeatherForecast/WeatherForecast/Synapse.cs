using System;

namespace WeatherForecast
{
    public class Synapse
    {
        public Guid Id { get; set; }
        public Neuron WejsciowyNeuron { get; set; }
        public Neuron WyjsciowyNeuron { get; set; }
        public double Waga { get; set; }
        public double WagaDelta { get; set; }

        public Synapse() { }

        public Synapse(Neuron wejsciowy,Neuron wyjsciowy)
        {
            Id = Guid.NewGuid();
            WejsciowyNeuron = wejsciowy;
            WyjsciowyNeuron = wyjsciowy;
            Waga = Network.Losuj();
        }
    }
}
