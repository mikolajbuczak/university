namespace Graphipcs_and_Detectors
{
    using System.Collections.Generic;
    using System.IO;
    class Dataset
    {
        public List<Data> data { get; private set; } = new List<Data>();
        public Dataset(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);
            foreach (var line in lines)
            {
                string[] line_split = line.Split('\t');
                bool.TryParse(line_split[3], out bool windy);
                bool.TryParse(line_split[4], out bool playGolf);
                data.Add(new Data(line_split[0], line_split[1], line_split[2], windy, playGolf));
            }
        }
    }
}
