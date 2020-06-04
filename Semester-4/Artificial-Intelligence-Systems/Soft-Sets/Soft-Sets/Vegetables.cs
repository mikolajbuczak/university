namespace Soft_Sets
{
    using System.Collections.Generic;
    using System.Linq;
    using System;
    class Vegetables
    {
        public enum Attributes
        {
            Fresh = 0,
            Frozen = 1,
            Spicy = 2,
            Sweet = 3,
            Red = 4,
            Green = 5,
            Local = 6,
            Tropical = 7,
            Bulb = 8,
            Leafy = 9
        }

        readonly Dictionary<string, List<Attributes>> types = new Dictionary<string, List<Attributes>>()
        {
            { "Tomato", new List<Attributes>() { Attributes.Local, Attributes.Fresh, Attributes.Red}},
            { "Potato", new List<Attributes>() { Attributes.Local, Attributes.Fresh, Attributes.Bulb}},
            { "Sweet Potato",new List<Attributes>() { Attributes.Tropical, Attributes.Sweet, Attributes.Fresh, Attributes.Bulb}},
            { "Beetroot", new List<Attributes>() { Attributes.Local, Attributes.Fresh, Attributes.Bulb, Attributes.Sweet, Attributes.Red}},
            { "Spinach", new List<Attributes>() { Attributes.Local, Attributes.Frozen, Attributes.Leafy, Attributes.Green}},
            { "Lettuce", new List<Attributes>() { Attributes.Local, Attributes.Fresh, Attributes.Leafy, Attributes.Green}},
            { "Chili Pepper", new List<Attributes>() { Attributes.Tropical, Attributes.Fresh, Attributes.Red, Attributes.Spicy}},
            { "Carrot", new List<Attributes>() { Attributes.Local, Attributes.Fresh, Attributes.Sweet}},
            { "Green beans", new List<Attributes>() { Attributes.Local, Attributes.Frozen, Attributes.Green}}
        };

        readonly Dictionary<string, double> matches = new Dictionary<string, double>();

        public Vegetables(params Attributes[] attributes)
        {
            matches = GetBestMatches(attributes);
        }

        Dictionary<string, double> GetBestMatches(params Attributes[] attributes)
        {
            Dictionary<string, double> bestMatches = new Dictionary<string, double>();

            foreach (var type in types)
            {
                double matchPercentage = 0;
                foreach (var attribute in attributes)
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
