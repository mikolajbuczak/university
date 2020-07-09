namespace Graphipcs_and_Detectors
{
    using System;
    static class Bayes
    {
        public static bool Guess(Dataset dataset, Data data)
        {
            int positiveInputs = 0, positiveOutlook = 0, positiveTemperature = 0, positiveHumidity = 0, positiveWindy = 0;
            int negativeInputs = 0, negativeOutlook = 0, negativeTemperature = 0, negativeHumidity = 0, negativeWindy = 0;

            foreach (var element in dataset.data)
            {
                if (element.PlayGolf)
                {
                    positiveInputs++;
                    if (element.Outlook == data.Outlook) positiveOutlook++;
                    if (element.Temperature == data.Temperature) positiveTemperature++;
                    if (element.Humidity == data.Humidity) positiveHumidity++;
                    if (element.Windy == data.Windy) positiveWindy++;
                }
                else
                {
                    negativeInputs++;
                    if (element.Outlook == data.Outlook) negativeOutlook++;
                    if (element.Temperature == data.Temperature) negativeTemperature++;
                    if (element.Humidity == data.Humidity) negativeHumidity++;
                    if (element.Windy == data.Windy) negativeWindy++;
                }
            }

            double positiveResult = CalculateResult(positiveInputs, dataset.data.Count, positiveOutlook, positiveTemperature, positiveHumidity, positiveWindy);
            double negativeResult = CalculateResult(negativeInputs, dataset.data.Count, negativeOutlook, negativeTemperature, negativeHumidity, negativeWindy);

            if (positiveResult >= negativeResult) return true;
            return false;
        }

        static double CalculateResult(int inputs, int size, int outlooks, int temperatures, int humidities, int winds)
        {
            double result = (double)inputs / size;

            if (inputs == 0 || size == 0) return 0;

            if(outlooks != 0)
                result *= outlooks;
            if (temperatures != 0)
                result *= temperatures;
            if (humidities != 0)
                result *= humidities;
            if (winds != 0)
                result *= winds;

            return result / Math.Pow(inputs, 4);
        }
    }
}
