namespace Graphipcs_and_Detectors
{
    using System.Collections.Generic;
    using System.IO;
    class IrisDataset
    {
        public List<Iris> data { get; private set; } = new List<Iris>();

        public IrisDataset(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);
            foreach (var line in lines)
            {
                string[] line_split = line.Split(',');
                double.TryParse(line_split[0], out double sepalLength);
                double.TryParse(line_split[1], out double sepalWidth);
                double.TryParse(line_split[2], out double petalLength);
                double.TryParse(line_split[3], out double petalWidth);
                data.Add(new Iris(sepalLength, sepalWidth, petalLength, petalWidth, line_split[4]));
            }
        }
    }
}
