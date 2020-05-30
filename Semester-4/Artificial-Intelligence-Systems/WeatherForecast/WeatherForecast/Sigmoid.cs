using System;

namespace WeatherForecast
{
    public static class Sigmoid
    {
        public static double Wyjscie(double x)
        {
            return x < -45.0 ? 0.0 : x > 45.0 ? 1.0 : 1.0 / (1.0 + Math.Exp(-x));
        }

        public static double Pochodna(double x)
        {
            return x * (1 - x);
        }
    }
}
