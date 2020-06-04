namespace Soft_Sets
{
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using System.Text.RegularExpressions;

    class Trousers
    {
        public enum Attributes
        {
            Expensive = 0,
            Cheap = 1,
            Jeans = 2,
            Sweatpants = 3,
            Classic = 4,
            Modern = 5,
            Fit = 6,
            Blue = 7,
            Black = 8,
            Zip = 9,
            Buttons = 10
        }

        readonly Dictionary<string, List<Attributes>> types = new Dictionary<string, List<Attributes>>()
        {
            { "Bell-bottoms", new List<Attributes>() {Attributes.Expensive, Attributes.Zip, Attributes.Jeans, Attributes.Blue } },
            { "Shorts", new List<Attributes>() {Attributes.Cheap, Attributes.Buttons, Attributes.Blue } },
            { "Training pants", new List<Attributes>() {Attributes.Cheap, Attributes.Sweatpants, Attributes.Fit ,Attributes.Black, Attributes.Modern } },
            { "Suit pants", new List<Attributes>() {Attributes.Expensive, Attributes.Zip, Attributes.Classic, Attributes.Black } },

        };

        readonly Dictionary<string, double> matches = new Dictionary<string, double>();

        public Trousers(params Attributes[] attributes)
        {
            matches = GetBestMatches(attributes);
        }

        Dictionary<string, double> GetBestMatches(params Attributes[] attributes)
        {
            Dictionary<string, double> bestMatches = new Dictionary<string, double>();

            foreach(var type in types)
            {
                double matchPercentage = 0;
                foreach(var attribute in attributes)
                    if (type.Value.Contains(attribute)) matchPercentage += 1;
                matchPercentage /= attributes.Length;
                bestMatches.Add(type.Key, matchPercentage);
            }

            bestMatches = (from entry in bestMatches orderby entry.Value descending select entry).ToDictionary(x => x.Key, y => y.Value);

            return bestMatches;
        }

        public void ShowBestMatches()
        {
            foreach (var match in matches)
                Console.WriteLine($"{match.Key} - {Math.Round(match.Value * 100, 2)}%");
            Console.WriteLine('\n');
        }
    }
}
