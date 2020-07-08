namespace Graphipcs_and_Detectors
{
    class Iris
    {
        public double SepalLength { get; private set; }
        public double SepalWidth { get; private set; }
        public double PetalLength { get; private set; }
        public double PetalWidth { get; private set; }
        public string Type { get; set; }
        public Iris(double sepalLength, double sepalWidth, double petalLength, double petalWidth, string type)
        {
            SepalLength = sepalLength;
            SepalWidth = sepalWidth;
            PetalLength = petalLength;
            PetalWidth = petalWidth;
            Type = type;
        }
    }
}
