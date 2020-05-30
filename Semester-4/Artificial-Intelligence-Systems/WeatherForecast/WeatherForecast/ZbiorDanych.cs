using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast
{
    public class ZbiorDanych
    {
        public double[] Wartosci { get; set; }
        public double[] Cel { get; set; }

        public ZbiorDanych(double[] wartosci,double[] cel)
        {
            Wartosci = wartosci;
            Cel = cel;
        }
    }
}
